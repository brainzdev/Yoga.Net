using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using static Yoga.Net.YogaMath;


namespace Yoga.Net
{
    public class YogaNode
    {
        public const float DefaultFlexGrow = 0.0f;
        public const float DefaultFlexShrink = 0.0f;

        /// <summary>
        /// the YogaNode that owns this YogaNode. An owner is used to identify
        /// the YogaTree that a YogaNode belongs to. This method will return the parent
        /// of the YogaNode when a YogaNode only belongs to one YogaTree or null when
        /// the YogaNode is shared between two or more YogaTrees.
        /// </summary>
        public YogaNode Owner { get; set; }

        public object Context { get; set; }
        public YogaConfig Config { get; private set; }
        public YogaLayout Layout { get; set; } = new YogaLayout();
        public int LineIndex { get; set; }
        public NodeType NodeType { get; set; } = NodeType.Default;
        public bool HasNewLayout { get; set; } = true;
        public string Trace { get; set; }

        public BaselineFunc BaselineFunc { get; set; }
        public DirtiedFunc DirtiedFunc { get; set; }
        public PrintFunc PrintFunc { get; set; }
        public MeasureFunc MeasureFunc
        {
            get => _measureFunc;
            set
            {
                _measureFunc = value;
                if (_measureFunc == null)
                {
                    NodeType = NodeType.Default;
                }
                else
                {
                    Debug.Assert(_children.Count == 0, "Cannot set measure function: Nodes with measure functions cannot have children.");
                    NodeType = NodeType.Text;
                }
            }
        }

        public bool HasMeasureFunc => _measureFunc != null;

        YogaStyle Style
        {
            get => _style;
            set
            {
                if (value != _style)
                {
                    _style = value;
                    MarkDirtyAndPropagate();
                }
            }
        }

        public YogaStyleReadonly StyleReadonly => Style;

        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                if (value == IsDirty)
                    return;

                _isDirty = value;
                if (value)
                    DirtiedFunc?.Invoke(this);
            }
        }

        public bool IsReferenceBaseline
        {
            get => _isReferenceBaseline;
            set
            {
                if (value != _isReferenceBaseline)
                {
                    _isReferenceBaseline = value;
                    MarkDirtyAndPropagate();
                }
            }
        }


        YogaStyle _style = new YogaStyle();
        YogaNodes _children = new YogaNodes();
        MeasureFunc _measureFunc;
        
        YogaValue[] _resolvedDimensions = {YogaValue.Undefined, YogaValue.Undefined};
        bool _isReferenceBaseline;
        bool _isDirty;

        public YogaNode(YogaConfig config = null)
        {
            Config = config ?? YogaConfig.DefaultConfig;
            Event.Hub.Publish(new NodeAllocationEventArgs(this, config));
        }

        public YogaNode([NotNull] YogaNode other, YogaConfig config = null)
        {
            Context      = other.Context;
            MeasureFunc  = other.MeasureFunc;
            BaselineFunc = other.BaselineFunc;
            PrintFunc    = other.PrintFunc;
            DirtiedFunc  = other.DirtiedFunc;
            _style       = new YogaStyle(other.Style);
            Layout       = new YogaLayout(other.Layout);
            LineIndex    = other.LineIndex;
            Owner        = other.Owner;
            Config       = config ?? other.Config ?? YogaConfig.DefaultConfig;
            Array.Copy(other._resolvedDimensions, _resolvedDimensions, _resolvedDimensions.Length);

            // Lazy-clone
            _children.AddRange(other.Children);

            Event.Hub.Publish(new NodeAllocationEventArgs(this, Config));
        }

        public static YogaNode Clone(YogaNode oldNode) => new YogaNode(oldNode) { Owner = null };

        public static YogaNode DeepClone(YogaNode oldNode)
        {
            var node = new YogaNode(oldNode, new YogaConfig(oldNode.Config)) {Owner = null};

            var children = new YogaNodes(oldNode.Children.Count);
            foreach (var item in oldNode.Children)
            {
                var childNode = DeepClone(item);
                childNode.Owner = node;
                children.Add(childNode);
            }

            node.SetChildren(children);

            return node;
        }

        public void InsertChild(YogaNode child, int index)
        {
            Debug.Assert( child.Owner == null, "Child already has a owner, it must be removed first.");
            Debug.Assert( MeasureFunc == null, "Cannot add child: Nodes with measure functions cannot have children.");

            _children.Insert(index, child);
            child.Owner = this;
            MarkDirtyAndPropagate();
        }

        public void RemoveChild(YogaNode excludedChild)
        {
            if (_children.Count == 0)
                return;

            // Children may be shared between parents, which is indicated by not having an
            // owner. We only want to reset the child completely if it is owned exclusively by one node.
            var childOwner = excludedChild.Owner;
            if (_children.Contains(excludedChild) && _children.Remove(excludedChild))
            {
                if (this == childOwner)
                {
                    excludedChild.Layout = new YogaLayout(); // layout is no longer valid
                    excludedChild.Owner  = null;
                }

                MarkDirtyAndPropagate();
            }
        }

        public void RemoveAllChildren()
        {
            var childCount = _children.Count;
            if (childCount == 0)
                return;

            var firstChild = _children[0];
            if (firstChild.Owner == this)
            {
                // If the first child has this node as its owner, we assume that this child set is unique.
                for (var i = 0; i < childCount; i++)
                {
                    var oldChild = _children[i];
                    oldChild.Layout = new YogaNode().Layout; // layout is no longer valid
                    oldChild.Owner  = null;
                }
            }
            ClearChildren();
            MarkDirtyAndPropagate();
        }

        public void SetChildren(IEnumerable<YogaNode> childs)
        {
            var newChildren = childs.ToList();
            if (newChildren.Count == 0)
            {
                if (_children.Count > 0)
                {
                    foreach (var child in _children)
                    {
                        child.Layout = new YogaLayout();
                        child.Owner  = null;
                    }

                    ClearChildren();
                    MarkDirtyAndPropagate();
                }
            }
            else
            {
                if (_children.Count > 0)
                {
                    foreach (var oldChild in _children)
                    {
                        // Our new children may have nodes in common with the old children. We don't reset these common nodes.
                        if (!newChildren.Contains(oldChild))
                        {
                            oldChild.Layout = new YogaLayout();
                            oldChild.Owner  = null;
                        }
                    }
                }

                _children = new YogaNodes(newChildren);
                foreach (var child in newChildren)
                    child.Owner = this;

                MarkDirtyAndPropagate();
            }
        }

        // If both left and right are defined, then use left. Otherwise return +left or
        // -right depending on which is defined.
        float RelativePosition(FlexDirection axis, float axisSize)
        {
            if (IsLeadingPositionDefined(axis))
            {
                return GetLeadingPosition(axis, axisSize);
            }

            float trailingPosition = GetTrailingPosition(axis, axisSize);
            if (trailingPosition.HasValue())
            {
                trailingPosition = (-1f * trailingPosition);
            }

            return trailingPosition;
        }

        public void Print(object printContext) => PrintFunc?.Invoke(this, printContext);

        public YogaSize Measure(float width, MeasureMode widthMode, float height, MeasureMode heightMode, object layoutContext)
        {
            return MeasureFunc?.Invoke(this, width, widthMode, height, heightMode, layoutContext) ?? new YogaSize();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public YogaAlign AlignItem(YogaNode child)
        {
            var align = child.Style.AlignSelf == YogaAlign.Auto
                ? Style.AlignItems
                : child.Style.AlignSelf;
            if (align == YogaAlign.Baseline && Style.FlexDirection.IsColumn())
                return YogaAlign.FlexStart;

            return align;
        }


        public float Baseline(float width, float height, object layoutContext)
        {
            return BaselineFunc?.Invoke(this, width, height, layoutContext) ?? 0f;
        }

        public float Baseline(object layoutContext = null)
        {
            if (BaselineFunc != null)
            {
                Event.Hub.Publish(new NodeBaselineStartEventArgs(this));

                var layoutBaseline = Baseline(
                    Layout.MeasuredDimensions[(int)Dimension.Width],
                    Layout.MeasuredDimensions[(int)Dimension.Height],
                    layoutContext);

                Event.Hub.Publish(new NodeBaselineEndEventArgs(this));

                Debug.Assert(layoutBaseline.HasValue(), "Expect custom baseline function to not return NaN");
                return layoutBaseline;
            }

            YogaNode baselineChild = null;
            var childCount = _children.Count;
            for (var i = 0; i < childCount; i++)
            {
                var child = _children[i];
                if (child.LineIndex > 0)
                    break;

                if (child.Style.PositionType == PositionType.Absolute)
                    continue;

                if (AlignItem(child) == YogaAlign.Baseline || child.IsReferenceBaseline)
                {
                    baselineChild = child;
                    break;
                }

                if (baselineChild == null)
                    baselineChild = child;
            }

            if (baselineChild == null)
                return Layout.MeasuredDimensions[(int)Dimension.Height];

            var baseline = baselineChild.Baseline(layoutContext);
            return baseline + baselineChild.Layout.Position[(int)Edge.Top];
        }

        public bool IsBaselineLayout()
        {
            if (Style.FlexDirection.IsColumn())
                return false;

            if (Style.AlignItems == YogaAlign.Baseline)
                return true;

            var childCount = _children.Count;
            for (var i = 0; i < childCount; i++)
            {
                var child = _children[i];
                if (child.Style.PositionType == PositionType.Relative && child.Style.AlignSelf == YogaAlign.Baseline)
                    return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsStyleDimDefined(FlexDirection axis, float ownerSize)
        {
            var isUndefined = GetResolvedDimension(YogaArrange.Dim[(int)axis]).IsUndefined;
            return !(
                GetResolvedDimension(YogaArrange.Dim[(int)axis]).Unit == YogaUnit.Auto ||
                GetResolvedDimension(YogaArrange.Dim[(int)axis]).Unit == YogaUnit.Undefined ||
                GetResolvedDimension(YogaArrange.Dim[(int)axis]).Unit == YogaUnit.Point &&
                !isUndefined && GetResolvedDimension(YogaArrange.Dim[(int)axis]).Value < 0.0f ||
                GetResolvedDimension(YogaArrange.Dim[(int)axis]).Unit == YogaUnit.Percent &&
                !isUndefined &&
                (GetResolvedDimension(YogaArrange.Dim[(int)axis]).Value < 0.0f || ownerSize.IsUndefined()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsLayoutDimDefined(FlexDirection axis)
        {
            var value = Layout.MeasuredDimensions[(int)YogaArrange.Dim[(int)axis]];
            return value.HasValue() && value >= 0.0f;
        }

        public float BoundAxisWithinMinAndMax(FlexDirection axis,float value,float axisSize)
        {
            var min = float.NaN;
            var max = float.NaN;

            if (axis.IsColumn())
            {
                min = Style.MinDimensions[(int)Dimension.Height].Resolve(axisSize);
                max = Style.MaxDimensions[(int)Dimension.Height].Resolve(axisSize);
            }
            else if (axis.IsRow())
            {
                min = Style.MinDimensions[(int)Dimension.Width].Resolve(axisSize);
                max = Style.MaxDimensions[(int)Dimension.Width].Resolve(axisSize);
            }

            if (max >= 0f && value > max)
                return max;

            if (min >= 0f && value < min)
                return min;

            return value;
        }

        // Like YGNodeBoundAxisWithinMinAndMax but also ensures that the value doesn't go below the padding and border amount.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float BoundAxis(FlexDirection axis,float value,float axisSize,float widthSize) =>
            FloatMax(
                BoundAxisWithinMinAndMax(axis,value,axisSize), 
                GetLeadingPaddingAndBorder(axis, widthSize));

        public void SetChildTrailingPosition(YogaNode child,FlexDirection axis)
        {
            var size = child.Layout.MeasuredDimensions[(int)YogaArrange.Dim[(int)axis]];
            child.SetLayoutPosition(
                Layout.MeasuredDimensions[(int)YogaArrange.Dim[(int)axis]] - size -
                child.Layout.Position[(int)YogaArrange.Pos[(int)axis]],
                (int)YogaArrange.Trailing[(int)axis]);
        }

        public void ConstrainMaxSizeForMode(FlexDirection axis,float ownerAxisSize,float ownerWidth,ref MeasureMode mode,ref float size)
        {
            var maxSize = Style.MaxDimensions[(int)YogaArrange.Dim[(int)axis]].Resolve(ownerAxisSize) + GetMarginForAxis(axis, ownerWidth);
            switch (mode)
            {
            case MeasureMode.Exactly:
            case MeasureMode.AtMost:
                size = maxSize.IsUndefined() || size < maxSize ? size : maxSize;
                break;
            case MeasureMode.Undefined:
                if (maxSize.HasValue())
                {
                    mode = MeasureMode.AtMost;
                    size = maxSize;
                }
                break;
            }
        }

        // Applies a callback to all children, after cloning them if they are not owned.
        public void IterChildrenAfterCloningIfNeeded(Action<YogaNode, object> callback, object cloneContext)
        {
            for (int i = 0; i < _children.Count; i++)
            {
                var child = _children[i];
                if (child.Owner != this)
                {
                    child       = Config.CloneNode(child, this, i, cloneContext);
                    child.Owner = this;
                }

                _children[i] = child;
                callback?.Invoke(child, cloneContext);
            }
        }

        [Obsolete("use Children[i]")]
        public YogaNode GetChild(int index) => _children[index];

        public IReadOnlyList<YogaNode> Children => _children;


        public void UpdateStyle<TEntity, T>(Expression<Func<TEntity, T>> outExpr, T value) where T : struct
        {
            var expr = (MemberExpression)outExpr.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = (T)prop.GetValue(Style);

            if (!EqualityComparer<T>.Default.Equals(propValue, value))
            {
                prop.SetValue(Style, value);
                MarkDirtyAndPropagate();
            }
        }

        public void UpdateStyleObject<TEntity, T>(Expression<Func<TEntity, T>> outExpr, T value) where T : class
        {
            var expr = (MemberExpression)outExpr.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = (T)prop.GetValue(Style);

            if (!EqualityComparer<T>.Default.Equals(propValue, value))
            {
                prop.SetValue(Style, value);
                MarkDirtyAndPropagate();
            }
        }

        public void UpdateIndexedStyleProp<TKey, TValue>(Values<TKey, TValue> values, int idx, TValue value) where TKey : struct, IConvertible
        {
            var propValue = values[idx];

            if (!value.Equals(propValue))
            {
                values[idx] = value;
                MarkDirtyAndPropagate();
            }
        }

        public float StyleFlex
        {
            get => Style.Flex.IsUndefined() ? YogaValue.YGUndefined : Style.Flex;
            set => UpdateStyle<YogaStyle, float>(s => s.Flex, value);
        }

        public float StyleFlexGrow
        {
            get => Style.FlexGrow.IsUndefined() ? DefaultFlexGrow : Style.FlexGrow;
            set => UpdateStyle<YogaStyle, float>(s => s.FlexGrow, value);
        }

        public float StyleFlexShrink
        {
            get => Style.FlexShrink.IsUndefined() ? DefaultFlexShrink : Style.FlexShrink;
            set => UpdateStyle<YogaStyle, float>(s => s.FlexShrink, value);
        }

        public Direction StyleDirection
        {
            get => Style.Direction;
            set => UpdateStyle<YogaStyle, Direction>(s => s.Direction, value);
        }

        public FlexDirection StyleFlexDirection
        {
            get => Style.FlexDirection;
            set => UpdateStyle<YogaStyle, FlexDirection>(s => s.FlexDirection, value);
        }

        public Justify StyleJustifyContent
        {
            get => Style.JustifyContent;
            set => UpdateStyle<YogaStyle, Justify>(s => s.JustifyContent, value);
        }

        public YogaAlign StyleAlignContent
        {
            get => Style.AlignContent;
            set => UpdateStyle<YogaStyle, YogaAlign>(s => s.AlignContent, value);
        }

        public YogaAlign StyleAlignItems
        {
            get => Style.AlignItems;
            set => UpdateStyle<YogaStyle, YogaAlign>(s => s.AlignItems, value);
        }

        public YogaAlign StyleAlignSelf
        {
            get => Style.AlignSelf;
            set => UpdateStyle<YogaStyle, YogaAlign>(s => s.AlignSelf, value);
        }

        public PositionType StylePositionType
        {
            get => Style.PositionType;
            set => UpdateStyle<YogaStyle, PositionType>(s => s.PositionType, value);
        }

        public YogaValue StyleFlexBasis
        {
            get => Style.FlexBasis;
            set => UpdateStyleObject<YogaStyle, YogaValue>(s => s.FlexBasis, value);
        }

        public Wrap StyleFlexWrap
        {
            get => Style.FlexWrap;
            set => UpdateStyle<YogaStyle, Wrap>(s => s.FlexWrap, value);
        }

        public Overflow StyleOverflow
        {
            get => Style.Overflow;
            set => UpdateStyle<YogaStyle, Overflow>(s => s.Overflow, value);
        }

        public Display StyleDisplay
        {
            get => Style.Display;
            set => UpdateStyle<YogaStyle, Display>(s => s.Display, value);
        }

        public EdgesReadonly StylePosition => Style.Position;
        public YogaValue StyleGetPosition(Edge edge) => Style.Position[edge];
        public void StyleSetPosition(Edge edge, YogaValue value)
        {
            UpdateIndexedStyleProp(Style.Position, (int)edge, value);
        }

        public EdgesReadonly StyleMargin => Style.Margin;
        public YogaValue StyleGetMargin(Edge edge) => Style.Margin[edge];
        public void StyleSetMargin(Edge edge, YogaValue value)
        {
            UpdateIndexedStyleProp(Style.Margin, (int)edge, value);
        }

        public EdgesReadonly StylePadding => Style.Padding;
        public YogaValue StyleGetPadding(Edge edge) => Style.Padding[edge];
        public void StyleSetPadding(Edge edge, YogaValue value)
        {
            UpdateIndexedStyleProp(Style.Padding, (int)edge, value);
        }

        public EdgesReadonly StyleBorder => Style.Border;
        public YogaValue StyleGetBorder(Edge edge) => Style.Border[edge].IsUndefined ? YogaValue.Undefined : Style.Border[edge];
        public void StyleSetBorder(Edge edge, YogaValue value)
        {
            UpdateIndexedStyleProp(Style.Border, (int)edge, value);
        }

        /// <summary>
        /// Yoga specific properties, not compatible with flexbox specification Aspect
        /// ratio control the size of the undefined dimension of a node. Aspect ratio is
        /// encoded as a floating point value width/height. e.g. A value of 2 leads to a
        /// node with a width twice the size of its height while a value of 0.5 gives the
        /// opposite effect.
        ///
        /// - On a node with a set width/height aspect ratio control the size of the
        ///   unset dimension
        /// - On a node with a set flex basis aspect ratio controls the size of the node
        ///   in the cross axis if unset
        /// - On a node with a measure function aspect ratio works as though the measure
        ///   function measures the flex basis
        /// - On a node with flex grow/shrink aspect ratio controls the size of the node
        ///   in the cross axis if unset
        /// - Aspect ratio takes min/max dimensions into account
        /// </summary>
        public float StyleAspectRatio
        {
            get => Style.AspectRatio.IsUndefined() ? YogaValue.YGUndefined : Style.AspectRatio;
            set => UpdateStyle<YogaStyle, float>(s => s.AspectRatio, value);
        }

        public YogaValue StyleWidth
        {
            get => Style.Dimensions[(int)Dimension.Width];
            set => UpdateIndexedStyleProp(Style.Dimensions, (int)Dimension.Width, value);
        }

        public YogaValue StyleHeight
        {
            get => Style.Dimensions[(int)Dimension.Height];
            set => UpdateIndexedStyleProp(Style.Dimensions, (int)Dimension.Height, value);
        }

        public DimensionsReadonly StyleMinDimensions => Style.MinDimensions;

        public YogaValue StyleMinWidth
        {
            get => Style.MinDimensions[(int)Dimension.Width];
            set => UpdateIndexedStyleProp(Style.MinDimensions, (int)Dimension.Width, value);
        }

        public YogaValue StyleMinHeight
        {
            get => Style.MinDimensions[(int)Dimension.Height];
            set => UpdateIndexedStyleProp(Style.MinDimensions, (int)Dimension.Height, value);
        }

        public DimensionsReadonly StyleMaxDimensions => Style.MaxDimensions;

        public YogaValue StyleMaxWidth
        {
            get => Style.MaxDimensions[(int)Dimension.Width];
            set => UpdateIndexedStyleProp(Style.MaxDimensions, (int)Dimension.Width, value);
        }

        public YogaValue StyleMaxHeight
        {
            get => Style.MaxDimensions[(int)Dimension.Height];
            set => UpdateIndexedStyleProp(Style.MaxDimensions, (int)Dimension.Height, value);
        }



        public YogaValue[] GetResolvedDimensions() => _resolvedDimensions;

        public YogaValue GetResolvedDimension(Dimension index) => _resolvedDimensions[(int)index];

        // Methods related to positions, margin, padding and border
        public float GetLeadingPosition(FlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var lp = Style.Position.ComputedEdgeValue(Edge.Start);
                if (!lp.IsUndefined)
                {
                    return lp.Resolve(axisSize);
                }
            }

            var leadingPosition = Style.Position.ComputedEdgeValue(YogaArrange.Leading[(int)axis]);

            return leadingPosition.IsUndefined ? 0f : leadingPosition.Resolve(axisSize);
        }

        public bool IsLeadingPositionDefined(FlexDirection axis)
        {
            return (axis.IsRow() &&
                    !Style.Position.ComputedEdgeValue(Edge.Start).IsUndefined) ||
                !Style.Position.ComputedEdgeValue(YogaArrange.Leading[(int)axis]).IsUndefined;
        }

        public bool IsTrailingPosDefined(FlexDirection axis)
        {
            return (axis.IsRow() &&
                    !Style.Position.ComputedEdgeValue(Edge.End).IsUndefined) ||
                !Style.Position.ComputedEdgeValue(YogaArrange.Trailing[(int)axis]).IsUndefined;
        }

        public float GetTrailingPosition(FlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var tp = Style.Position.ComputedEdgeValue(Edge.End);
                if (!tp.IsUndefined)
                {
                    return tp.Resolve(axisSize);
                }
            }

            var trailingPosition = Style.Position.ComputedEdgeValue(YogaArrange.Trailing[(int)axis]);

            return trailingPosition.IsUndefined ? 0f : trailingPosition.Resolve(axisSize);
        }

        public float GetLeadingMargin(FlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() &&
                !Style.Margin[Edge.Start].IsUndefined)
            {
                return Style.Margin[Edge.Start].ResolveValueMargin(widthSize);
            }

            return Style.Margin.ComputedEdgeValue(YogaArrange.Leading[(int)axis], YogaValue.Zero)
                        .ResolveValueMargin(widthSize);
        }

        public float GetTrailingMargin(FlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() && !Style.Margin[Edge.End].IsUndefined)
            {
                return Style.Margin[Edge.End].ResolveValueMargin(widthSize);
            }

            return Style.Margin.ComputedEdgeValue(YogaArrange.Trailing[(int)axis], YogaValue.Zero)
                        .ResolveValueMargin(widthSize);
        }

        public float GetLeadingBorder(FlexDirection axis)
        {
            YogaValue leadingBorder;
            if (axis.IsRow() &&
                !Style.Border[Edge.Start].IsUndefined)
            {
                leadingBorder = Style.Border[Edge.Start];
                if (leadingBorder.Value >= 0)
                    return leadingBorder.Value;
            }

            leadingBorder = Style.Border.ComputedEdgeValue(YogaArrange.Leading[(int)axis], YogaValue.Zero);
            return FloatMax(leadingBorder.Value, 0.0f);
        }

        public float GetTrailingBorder(FlexDirection flexDirection)
        {
            YogaValue trailingBorder;
            if (flexDirection.IsRow() && !Style.Border[Edge.End].IsUndefined)
            {
                trailingBorder = Style.Border[Edge.End];
                if (trailingBorder.Value >= 0.0f)
                {
                    return trailingBorder.Value;
                }
            }

            trailingBorder = Style.Border.ComputedEdgeValue(YogaArrange.Trailing[(int)flexDirection], YogaValue.Zero);
            return FloatMax(trailingBorder.Value, 0.0f);
        }

        public float GetLeadingPadding(FlexDirection axis, in float widthSize)
        {
            float paddingEdgeStart = Style.Padding[Edge.Start].Resolve(widthSize);
            if (axis.IsRow() &&
                !Style.Padding[Edge.Start].IsUndefined &&
                paddingEdgeStart.HasValue() && paddingEdgeStart >= 0.0f)
            {
                return paddingEdgeStart;
            }

            var resolvedValue = Style.Padding.ComputedEdgeValue(YogaArrange.Leading[(int)axis], YogaValue.Zero).Resolve(widthSize);
            return Math.Max(resolvedValue, 0f);
        }

        public float GetTrailingPadding(FlexDirection axis, float widthSize)
        {
            float paddingEdgeEnd = Style.Padding[Edge.End].Resolve(widthSize);
            if (axis.IsRow() && paddingEdgeEnd >= 0f)
            {
                return paddingEdgeEnd;
            }

            var resolvedValue = Style.Padding.ComputedEdgeValue(YogaArrange.Trailing[(int)axis], YogaValue.Zero).Resolve(widthSize);

            return Math.Max(resolvedValue, 0f);
        }

        public float GetLeadingPaddingAndBorder(FlexDirection axis, float widthSize) => GetLeadingPadding(axis, widthSize) + GetLeadingBorder(axis);

        public float GetTrailingPaddingAndBorder(FlexDirection axis, float widthSize) => GetTrailingPadding(axis, widthSize) + GetTrailingBorder(axis);

        public float GetMarginForAxis(FlexDirection axis, in float widthSize) => GetLeadingMargin(axis, widthSize) + GetTrailingMargin(axis, widthSize);

        public void SetLayoutLastOwnerDirection(Direction direction) => Layout.LastOwnerDirection = direction;

        public void SetLayoutComputedFlexBasis(float computedFlexBasis) => Layout.ComputedFlexBasis = computedFlexBasis;

        public void SetLayoutComputedFlexBasisGeneration(int computedFlexBasisGeneration) => Layout.ComputedFlexBasisGeneration = computedFlexBasisGeneration;

        public void SetLayoutMeasuredDimension(float measuredDimension, int index) => Layout.MeasuredDimensions[index] = measuredDimension;

        public void SetLayoutMeasuredDimension(float measuredDimension, Dimension index) => Layout.MeasuredDimensions[(int)index] = measuredDimension;

        public void SetLayoutHadOverflow(bool hadOverflow) => Layout.HadOverflow = hadOverflow;

        public void SetLayoutDirection(Direction direction) => Layout.Direction = direction;

        public void SetLayoutMargin(float margin, Edge edge) => Layout.Margin[(int)edge] = margin;

        public void SetLayoutBorder(float border, Edge edge) => Layout.Border[(int)edge] = border;

        public void SetLayoutPadding(float padding, Edge edge) => Layout.Padding[(int)edge] = padding;

        public void SetLayoutPosition(float position, int index) => Layout.Position[index] = position;

        public void SetLayoutPosition(float position, Edge edge) => Layout.Position[edge] = position;


        public float LayoutMargin(Edge edge) => LayoutResolvedProperty(Layout.Margin, edge);

        public float LayoutBorder(Edge edge) => LayoutResolvedProperty(Layout.Border, edge);

        public float LayoutPadding(Edge edge) => LayoutResolvedProperty(Layout.Padding, edge);

        float LayoutResolvedProperty(LTRBEdge instanceName, Edge edge)
        {
            Debug.Assert(edge <= Edge.End, "Cannot get layout properties of multi-edge shorthands");
            if (edge == Edge.Start)
            {
                if (Layout.Direction == Direction.RTL)
                    return instanceName[(int)Edge.Right];
                return instanceName[(int)Edge.Left];
            }

            if (edge == Edge.End)
            {
                if (Layout.Direction == Direction.RTL)
                    return instanceName[(int)Edge.Left];
                return instanceName[(int)Edge.Right];
            }

            return instanceName[(int)edge];
        }

        public float PaddingAndBorderForAxis(FlexDirection axis, float widthSize) => 
            GetLeadingPaddingAndBorder(axis, widthSize) + 
            GetTrailingPaddingAndBorder(axis, widthSize);

        public float DimWithMargin(FlexDirection axis, float widthSize) => 
            Layout.MeasuredDimensions[(int)YogaArrange.Dim[(int)axis]] + 
            GetLeadingMargin(axis, widthSize) + 
            GetTrailingMargin(axis, widthSize);

        public void SetPosition(
            in Direction direction,
            in float mainSize,
            in float crossSize,
            in float ownerWidth)
        {
            /* Root nodes should be always layouted as LTR, so we don't return negative
             * values. */
            Direction directionRespectingRoot = Owner != null ? direction : Direction.LTR;
            FlexDirection mainAxis = Style.FlexDirection.Resolve(directionRespectingRoot);
            FlexDirection crossAxis = mainAxis.CrossAxis(directionRespectingRoot);

            float relativePositionMain = RelativePosition(mainAxis, mainSize);
            float relativePositionCross = RelativePosition(crossAxis, crossSize);

            SetLayoutPosition(
                (GetLeadingMargin(mainAxis, ownerWidth) + relativePositionMain),
                YogaArrange.Leading[(int)mainAxis]);
            SetLayoutPosition(
                (GetTrailingMargin(mainAxis, ownerWidth) + relativePositionMain),
                YogaArrange.Trailing[(int)mainAxis]);
            SetLayoutPosition(
                (GetLeadingMargin(crossAxis, ownerWidth) + relativePositionCross),
                YogaArrange.Leading[(int)crossAxis]);
            SetLayoutPosition(
                (GetTrailingMargin(crossAxis, ownerWidth) + relativePositionCross),
                YogaArrange.Trailing[(int)crossAxis]);
        }

        public void MarkDirtyAndPropagateDownwards()
        {
            IsDirty = true;
            foreach (var child in _children)
            {
                child.MarkDirtyAndPropagateDownwards();
            }
        }

        // Other methods
        public YogaValue MarginLeadingValue(FlexDirection axis)
        {
            if (axis.IsRow() && !Style.Margin[Edge.Start].IsUndefined)
                return Style.Margin[Edge.Start];
            return Style.Margin[YogaArrange.Leading[(int)axis]];
        }

        public YogaValue MarginTrailingValue(FlexDirection axis)
        {
            if (axis.IsRow() && !Style.Margin[Edge.End].IsUndefined)
                return Style.Margin[Edge.End];
            return Style.Margin[YogaArrange.Trailing[(int)axis]];
        }

        public YogaValue ResolveFlexBasisPtr()
        {
            YogaValue flexBasis = Style.FlexBasis;
            if (flexBasis.Unit != YogaUnit.Auto && flexBasis.Unit != YogaUnit.Undefined)
            {
                return flexBasis;
            }

            if (Style.Flex.HasValue() && Style.Flex > 0.0f)
                return YogaValue.Zero;
            return YogaValue.Auto;
        }

        public void ResolveDimension()
        {
            YogaStyle style = Style;
            foreach (var dim in new[] {Dimension.Width, Dimension.Height})
            {
                if (!style.MaxDimensions[dim].IsUndefined &&
                    style.MaxDimensions[dim] == style.MinDimensions[dim])
                {
                    _resolvedDimensions[(int)dim] = style.MaxDimensions[dim];
                }
                else
                {
                    _resolvedDimensions[(int)dim] = style.Dimensions[dim];
                }
            }
        }

        public Direction ResolveDirection(Direction ownerDirection)
        {
            if (Style.Direction == Direction.Inherit)
                return ownerDirection > Direction.Inherit ? ownerDirection : Direction.LTR;

            return Style.Direction;
        }

        void ClearChildren()
        {
            _children.Clear();
            //children_.shrink_to_fit();
        }

        /// Replaces the occurrences of oldChild with newChild
        void ReplaceChild(YogaNode oldChild, YogaNode newChild)
        {
            ReplaceChild(newChild, _children.IndexOf(oldChild));
        }

        void ReplaceChild(YogaNode child, int index)
        {
            _children[index] = child;
        }

        void RemoveChild(int index)
        {
            _children.RemoveAt(index);
        }

        public void CloneChildrenIfNeeded(object cloneContext)
        {
            IterChildrenAfterCloningIfNeeded(null, cloneContext);
        }

        public void CopyStyle(YogaNode node)
        {
            Style = node.Style;
        }

        /// <summary>
        /// Mark a node as dirty. Only valid for nodes with a custom measure function
        /// set.
        ///
        /// Yoga knows when to mark all other nodes as dirty but because nodes with
        /// measure functions depend on information not known to Yoga they must perform
        /// this dirty marking manually.
        /// </summary>
        public void MarkDirty()
        {
            Debug.Assert( MeasureFunc != null, "Only leaf nodes with custom measure functions should manually mark themselves as dirty");
            MarkDirtyAndPropagate();
        }

        public void MarkDirtyAndPropagate()
        {
            if (!IsDirty)
            {
                IsDirty = true;
                SetLayoutComputedFlexBasis(float.NaN);
                Owner?.MarkDirtyAndPropagate();
            }
        }

        public float ResolveFlexGrow()
        {
            // Root nodes flexGrow should always be 0
            if (Owner == null)
                return 0.0f;

            if (Style.FlexGrow.HasValue())
                return Style.FlexGrow;

            if (Style.Flex.HasValue() && Style.Flex > 0.0f)
                return Style.Flex;

            return DefaultFlexGrow;
        }

        public float ResolveFlexShrink()
        {
            if (Owner == null)
                return 0.0f;

            if (Style.FlexShrink.HasValue())
                return Style.FlexShrink;

            if (Style.Flex.HasValue() && Style.Flex < 0.0f)
                return -Style.Flex;

            return DefaultFlexShrink;
        }

        public bool IsNodeFlexible()
        {
            return (
                (Style.PositionType == PositionType.Relative) &&
                (ResolveFlexGrow().IsNotZero() || ResolveFlexShrink().IsNotZero()));
        }

        public bool IsLayoutTreeEqualToNode(YogaNode node)
        {
            if (_children.Count != node._children.Count)
                return false;

            if (Layout != node.Layout)
                return false;

            if (_children.Count == 0)
                return true;


            for (var i = 0; i < _children.Count; ++i)
            {
                var otherNodeChildren = node._children[i];
                if (!_children[i].IsLayoutTreeEqualToNode(otherNodeChildren))
                    return false;
            }

            return true;
        }

        public YogaNode Reset()
        {
            Debug.Assert(_children.Count == 0,"Cannot reset a node which still has children attached");
            Debug.Assert(Owner == null,"Cannot reset a node still attached to a owner");

            return new YogaNode(Config);
        }

        public void TraversePreOrder(Action<YogaNode> action)
        {
            action(this);

            foreach (var child in _children)
                child.TraversePreOrder(action);
        }
        
        protected bool Equals(YogaNode other)
        {
            if (ReferenceEquals(this, other))
                return true;

            var isEqual = Equals(Style, other.Style);
            isEqual = isEqual & Equals(Layout, other.Layout);
            isEqual = isEqual & LineIndex == other.LineIndex;
            isEqual = isEqual & Equals(Config, other.Config);
            isEqual = isEqual & HasNewLayout == other.HasNewLayout;
            isEqual = isEqual & IsReferenceBaseline == other.IsReferenceBaseline;
            isEqual = isEqual & IsDirty == other.IsDirty;
            isEqual = isEqual & NodeType == other.NodeType;
            isEqual = isEqual & (_children.Count == other.Children.Count);

            if (isEqual)
            {
                isEqual = isEqual & _resolvedDimensions[0] == other._resolvedDimensions[0];
                isEqual = isEqual & _resolvedDimensions[1] == other._resolvedDimensions[1];
                for (int i = 0; i < _children.Count && isEqual; i++)
                {
                    isEqual = isEqual & _children[i] == other.Children[0];
                }
            }

            return isEqual;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YogaNode)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Style != null ? Style.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Layout != null ? Layout.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LineIndex;
                hashCode = (hashCode * 397) ^ (_children != null ? _children.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Config != null ? Config.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_resolvedDimensions != null ? _resolvedDimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ HasNewLayout.GetHashCode();
                hashCode = (hashCode * 397) ^ IsReferenceBaseline.GetHashCode();
                hashCode = (hashCode * 397) ^ IsDirty.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)NodeType;
                return hashCode;
            }
        }

        public static bool operator ==(YogaNode left, YogaNode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(YogaNode left, YogaNode right)
        {
            return !Equals(left, right);
        }
    }
}
