using System;
using System.Collections.Generic;

using static Yoga.Net.YogaGlobal;

using uint8_t = System.Byte;

namespace Yoga.Net
{
    public class YGNode
    {
        public const float DefaultFlexGrow = 0.0f;
        public const float DefaultFlexShrink = 0.0f;

        public object Context { get; set; }

        bool HasNewLayout { get; set; } = true;
        YGNodeType NodeType { get; set; } = YGNodeType.Default;

        uint8_t _reserved = 0;

        YGMeasureFunc _measureFunc;
        YGBaselineFunc _baselineFunc;
        YGPrintFunc _printFunc;

        YGDirtiedFunc _dirtiedFunc = null;
        YogaStyle _style = new YogaStyle();
        YogaLayout _layout = new YogaLayout();
        int _lineIndex = 0;
        YGNode _owner = null;
        YGVector _children = new YGVector();
        YogaConfig _config;

        YogaValue[] _resolvedDimensions = { YogaValue.Undefined, YogaValue.Undefined };


        public bool IsDirty { get; set; }
        public bool IsReferenceBaseline { get; set; }

        public YGNode() : this(DefaultConfig) { }

        public YGNode(in YogaConfig config)
        {
            _config = config;
        }

        public YGNode(in YGNode other)
        {
            Context = other.Context;
            _measureFunc = other._measureFunc;
            _baselineFunc = other._baselineFunc;
            _printFunc = other._printFunc;
            _dirtiedFunc = other._dirtiedFunc;
            _style = new YogaStyle(other._style);
            _layout = new YogaLayout(other._layout);
            _lineIndex = other._lineIndex;
            _owner = other._owner;
            _config = other._config;
            Array.Copy(other._resolvedDimensions, _resolvedDimensions, _resolvedDimensions.Length);

            // Lazy-clone
            _children.AddRange(other.Children);
        }

        // Does not expose true value semantics, as children are not cloned eagerly.
        // Should we remove this?
        //public YGNode(const YGNode& node) = default;

        // for RB fabric
        public YGNode(in YGNode node, YogaConfig config) : this(node)
        {
            _config = config;
        }

        // If both left and right are defined, then use left. Otherwise return +left or
        // -right depending on which is defined.
        FloatOptional RelativePosition(
            YGFlexDirection axis,
            float axisSize)
        {
            if (IsLeadingPositionDefined(axis))
            {
                return GetLeadingPosition(axis, axisSize);
            }

            FloatOptional trailingPosition = GetTrailingPosition(axis, axisSize);
            if (!trailingPosition.IsUndefined())
            {
                trailingPosition = new FloatOptional(-1 * trailingPosition.Unwrap());
            }
            return trailingPosition;
        }

        public uint8_t Reserved() { return _reserved; }

        public void Print(object printContext)
        {
            _printFunc?.Invoke(this, printContext);
        }

        public bool GetHasNewLayout() { return HasNewLayout; }

        public YGNodeType GetNodeType() { return NodeType; }

        public bool HasMeasureFunc()
        {
            return _measureFunc != null;
        }

        public YogaSize Measure(float width, YGMeasureMode widthMode, float height, YGMeasureMode heightMode, object layoutContext)
        {
            return _measureFunc?.Invoke(this, width, widthMode, height, heightMode, layoutContext)
                ?? new YogaSize();
        }

        public bool HasBaselineFunc()
        {
            return _baselineFunc != null;
        }

        public float Baseline(float width, float height, object layoutContext)
        {
            return _baselineFunc?.Invoke(this, width, height, layoutContext) ?? 0f;
        }

        public YGDirtiedFunc GetDirtied() { return _dirtiedFunc; }

        //// For Performance reasons passing as reference.
        public YogaStyle GetStyle() { return _style; }

        //// For Performance reasons passing as reference.
        public YogaLayout GetLayout() { return _layout; }

        public int GetLineIndex() { return _lineIndex; }

        // returns the YGNode that owns this YGNode. An owner is used to identify
        // the YogaTree that a YGNode belongs to. This method will return the parent
        // of the YGNode when a YGNode only belongs to one YogaTree or nullptr when
        // the YGNode is shared between two or more YogaTrees.
        public YGNode GetOwner() { return _owner; }

        // Deprecated, use getOwner() instead.
        //public YGNode getParent() const { return getOwner(); }

        public YGVector GetChildren() { return _children; }

        // Applies a callback to all children, after cloning them if they are not
        // owned.
        //template <typename T>
        public void IterChildrenAfterCloningIfNeeded(Action<YGNode, object> callback, object cloneContext)
        {
            for (int i = 0; i < _children.Count; i++)
            {
                var child = _children[i];
                if (child.GetOwner() != this)
                {
                    child = _config.CloneNode(child, this, i, cloneContext);
                    child.SetOwner(this);
                }
                _children[i] = child;
                callback?.Invoke(child, cloneContext);
            }
        }

        [Obsolete("use Children[i]")]
        public YGNode GetChild(int index)
        {
            return _children[index];
        }

        public IReadOnlyList<YGNode> Children => _children;

        public YogaConfig GetConfig() { return _config; }

        public YogaValue[] GetResolvedDimensions() { return _resolvedDimensions; }

        public YogaValue GetResolvedDimension(YGDimension index) { return _resolvedDimensions[(int)index]; }

        // Methods related to positions, margin, padding and border
        public FloatOptional GetLeadingPosition(in YGFlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var lp = _style.Position.ComputedEdgeValue(YGEdge.Start);
                if (!lp.IsUndefined)
                {
                    return lp.Resolve(axisSize);
                }
            }

            var leadingPosition = _style.Position.ComputedEdgeValue(leading[(int)axis]);

            return leadingPosition.IsUndefined ? new FloatOptional(0f) : leadingPosition.Resolve(axisSize);
        }

        public bool IsLeadingPositionDefined(in YGFlexDirection axis)
        {
            return (axis.IsRow() &&
                    !_style.Position.ComputedEdgeValue( YGEdge.Start).IsUndefined) ||
                    !_style.Position.ComputedEdgeValue( leading[(int)axis]).IsUndefined;
        }

        public bool IsTrailingPosDefined(in YGFlexDirection axis)
        {
            return (axis.IsRow() &&
                    !_style.Position.ComputedEdgeValue( YGEdge.End).IsUndefined) ||
                    !_style.Position.ComputedEdgeValue( trailing[(int)axis]).IsUndefined;
        }

        public FloatOptional GetTrailingPosition(in YGFlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var tp = _style.Position.ComputedEdgeValue(YGEdge.End);
                if (!tp.IsUndefined)
                {
                    return tp.Resolve(axisSize);
                }
            }

            var trailingPosition = _style.Position.ComputedEdgeValue(trailing[(int)axis]);

            return trailingPosition.IsUndefined ? new FloatOptional(0f) : trailingPosition.Resolve(axisSize);
        }

        public FloatOptional GetLeadingMargin(in YGFlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() &&
                !_style.Margin[YGEdge.Start].IsUndefined)
            {
                return _style.Margin[YGEdge.Start].ResolveValueMargin(widthSize);
            }

            return _style.Margin.ComputedEdgeValue( leading[(int)axis], CompactValue.Zero)
                   .ResolveValueMargin(widthSize);
        }

        public FloatOptional GetTrailingMargin(in YGFlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() && !_style.Margin[YGEdge.End].IsUndefined)
            {
                return _style.Margin[YGEdge.End].ResolveValueMargin(widthSize);
            }

            return _style.Margin.ComputedEdgeValue(trailing[(int)axis], CompactValue.Zero)
               .ResolveValueMargin(widthSize);
        }
        public float GetLeadingBorder(in YGFlexDirection axis)
        {
            YogaValue leadingBorder;
            if (axis.IsRow() &&
                !_style.Border[YGEdge.Start].IsUndefined)
            {
                leadingBorder = _style.Border[YGEdge.Start];
                if (leadingBorder.Value >= 0)
                    return leadingBorder.Value;
            }

            leadingBorder = _style.Border.ComputedEdgeValue(leading[(int)axis], CompactValue.Zero);
            return FloatMax(leadingBorder.Value, 0.0f);
        }

        public float GetTrailingBorder(in YGFlexDirection flexDirection)
        {
            YogaValue trailingBorder;
            if (flexDirection.IsRow() && !_style.Border[YGEdge.End].IsUndefined)
            {
                trailingBorder = _style.Border[YGEdge.End];
                if (trailingBorder.Value >= 0.0f)
                {
                    return trailingBorder.Value;
                }
            }

            trailingBorder = _style.Border.ComputedEdgeValue(trailing[(int)flexDirection], CompactValue.Zero);
            return FloatMax(trailingBorder.Value, 0.0f);
        }

        public FloatOptional GetLeadingPadding(in YGFlexDirection axis, in float widthSize)
        {
            FloatOptional paddingEdgeStart = _style.Padding[YGEdge.Start].Resolve(widthSize);
            if (axis.IsRow() &&
                !_style.Padding[YGEdge.Start].IsUndefined &&
                !paddingEdgeStart.IsUndefined() && paddingEdgeStart.Unwrap() >= 0.0f)
            {
                return paddingEdgeStart;
            }

            var resolvedValue = _style.Padding.ComputedEdgeValue(leading[(int)axis], CompactValue.Zero).Resolve(widthSize);
            return FloatOptional.Max(resolvedValue, new FloatOptional(0.0f));
        }

        public FloatOptional GetTrailingPadding(in YGFlexDirection axis, in float widthSize)
        {
            FloatOptional paddingEdgeEnd = _style.Padding[YGEdge.End].Resolve(widthSize);
            if (axis.IsRow() && paddingEdgeEnd >= new FloatOptional(0.0f))
            {
                return paddingEdgeEnd;
            }

            var resolvedValue = _style.Padding.ComputedEdgeValue( trailing[(int)axis], CompactValue.Zero).Resolve(widthSize);

            return FloatOptional.Max(resolvedValue, new FloatOptional(0.0f));
        }

        public FloatOptional GetLeadingPaddingAndBorder(in YGFlexDirection axis, in float widthSize)
        {
            return GetLeadingPadding(axis, widthSize) + new FloatOptional(GetLeadingBorder(axis));
        }

        public FloatOptional GetTrailingPaddingAndBorder(in YGFlexDirection axis, in float widthSize)
        {
            return GetTrailingPadding(axis, widthSize) + new FloatOptional(GetTrailingBorder(axis));
        }

        public FloatOptional GetMarginForAxis(in YGFlexDirection axis, in float widthSize)
        {
            return GetLeadingMargin(axis, widthSize) + GetTrailingMargin(axis, widthSize);
        }

        public void SetPrintFunc(YGPrintFunc printFunc = null)
        {
            _printFunc = printFunc;
        }

        public void SetHasNewLayout(bool hasNewLayout)
        {
            HasNewLayout = hasNewLayout;
        }

        public void SetNodeType(YGNodeType nodeType) { NodeType = nodeType; }

        void SetMeasureFunc() // decltype(measure_)
        {
            if (_measureFunc == null)
            {
                // TODO: t18095186 Move nodeType to opt-in function and mark appropriate places in Litho
                NodeType = YGNodeType.Default;
            }
            else
            {
                YGAssertWithNode(
                    this,
                    _children.Count == 0,
                    "Cannot set measure function: Nodes with measure functions cannot have children.");

                // TODO: t18095186 Move nodeType to opt-in function and mark appropriate places in Litho
                SetNodeType(YGNodeType.Text);
            }
        }

        public void SetMeasureFunc(YGMeasureFunc measureFunc)
        {
            _measureFunc = measureFunc;
            SetMeasureFunc();
        }

        public YGMeasureFunc GetMeasure() => _measureFunc;

        public void SetBaselineFunc(YGBaselineFunc baseLineFunc)
        {
            _baselineFunc = baseLineFunc;
        }

        public YGBaselineFunc GetBaselineFunc() => _baselineFunc;

        public void SetDirtiedFunc(YGDirtiedFunc dirtiedFunc) { _dirtiedFunc = dirtiedFunc; }

        public void SetStyle(in YogaStyle style) { _style = style; }

        public void SetLayout(in YogaLayout layout) { _layout = layout; }

        public void SetLineIndex(int lineIndex) { _lineIndex = lineIndex; }

        public void SetIsReferenceBaseline(bool isReferenceBaseline)
        {
            IsReferenceBaseline = isReferenceBaseline;
        }

        public void SetOwner(YGNode owner) { _owner = owner; }

        public void SetChildren(in YGVector children) { _children = children; }

        public void SetChildren(IEnumerable<YGNode> children)
        {
            _children = new YGVector(children);
        }

        // TODO: rvalue override for setChildren
        //YG_DEPRECATED void setConfig(YogaConfig config) { config_ = config; }

        public void SetDirty(bool isDirty)
        {
            if (isDirty == IsDirty)
                return;

            IsDirty = isDirty;
            if (isDirty)
                _dirtiedFunc?.Invoke(this);
        }

        public void SetLayoutLastOwnerDirection(YGDirection direction)
        {
            _layout.LastOwnerDirection = direction;
        }

        public void SetLayoutComputedFlexBasis(in FloatOptional computedFlexBasis)
        {
            _layout.ComputedFlexBasis = computedFlexBasis;
        }

        public void SetLayoutComputedFlexBasisGeneration(int computedFlexBasisGeneration)
        {
            _layout.ComputedFlexBasisGeneration = computedFlexBasisGeneration;
        }

        public void SetLayoutMeasuredDimension(float measuredDimension, int index)
        {
            _layout.MeasuredDimensions[index] = measuredDimension;
        }
        public void SetLayoutMeasuredDimension(float measuredDimension, YGDimension index)
        {
            _layout.MeasuredDimensions[(int)index] = measuredDimension;
        }

        public void SetLayoutHadOverflow(bool hadOverflow)
        {
            _layout.HadOverflow = hadOverflow;
        }

        public void SetLayoutDimension(float dimension, int index)
        {
            _layout.Dimensions[index] = dimension;
        }

        public void SetLayoutDirection(YGDirection direction)
        {
            _layout.Direction = direction;
        }

        public void SetLayoutMargin(float margin, YGEdge edge) => _layout.Margin[(int)edge] = margin;

        public void SetLayoutBorder(float border, YGEdge edge) => _layout.Border[(int)edge] = border;

        public void SetLayoutPadding(float padding, YGEdge edge) => _layout.Padding[(int)edge] = padding;

        public void SetLayoutPosition(float position, int index)
        {
            _layout.Position[index] = position;
        }

        public void SetPosition(
              in YGDirection direction,
              in float mainSize,
              in float crossSize,
              in float ownerWidth)
        {
            /* Root nodes should be always layouted as LTR, so we don't return negative
             * values. */
            YGDirection directionRespectingRoot = _owner != null ? direction : YGDirection.LTR;
            YGFlexDirection mainAxis = _style.FlexDirection.Resolve(directionRespectingRoot);
            YGFlexDirection crossAxis = mainAxis.CrossAxis(directionRespectingRoot);

            FloatOptional relativePositionMain = RelativePosition(mainAxis, mainSize);
            FloatOptional relativePositionCross = RelativePosition(crossAxis, crossSize);

            SetLayoutPosition(
                (GetLeadingMargin(mainAxis, ownerWidth) + relativePositionMain).Unwrap(),
                (int)leading[(int)mainAxis]);
            SetLayoutPosition(
                (GetTrailingMargin(mainAxis, ownerWidth) + relativePositionMain).Unwrap(),
                (int)trailing[(int)mainAxis]);
            SetLayoutPosition(
                (GetLeadingMargin(crossAxis, ownerWidth) + relativePositionCross).Unwrap(),
                (int)leading[(int)crossAxis]);
            SetLayoutPosition(
                (GetTrailingMargin(crossAxis, ownerWidth) + relativePositionCross).Unwrap(),
                (int)trailing[(int)crossAxis]);
        }

        public void MarkDirtyAndPropogateDownwards()
        {
            IsDirty = true;
            foreach (var child in _children)
            {
                child.MarkDirtyAndPropogateDownwards();
            }
        }

        // Other methods
        public YogaValue MarginLeadingValue(in YGFlexDirection axis)
        {
            if (axis.IsRow() && !_style.Margin[YGEdge.Start].IsUndefined)
                return _style.Margin[YGEdge.Start];
            return _style.Margin[leading[(int)axis]];
        }

        public YogaValue MarginTrailingValue(in YGFlexDirection axis)
        {
            if (axis.IsRow() && !_style.Margin[YGEdge.End].IsUndefined)
                return _style.Margin[YGEdge.End];
            return _style.Margin[trailing[(int)axis]];
        }

        public YogaValue ResolveFlexBasisPtr()
        {
            YogaValue flexBasis = _style.FlexBasis;
            if (flexBasis.Unit != YGUnit.Auto && flexBasis.Unit != YGUnit.Undefined)
            {
                return flexBasis;
            }

            if (!_style.Flex.IsUndefined() && _style.Flex.Unwrap() > 0.0f)
                return YogaValue.Zero;
            return YogaValue.Auto;
        }

        public void ResolveDimension()
        {
            YogaStyle style = GetStyle();
            foreach (var dim in new[] { YGDimension.Width, YGDimension.Height })
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

        public YGDirection ResolveDirection(in YGDirection ownerDirection)
        {
            if (_style.Direction == YGDirection.Inherit)
                return ownerDirection > YGDirection.Inherit ? ownerDirection : YGDirection.LTR;

            return _style.Direction;
        }

        public void ClearChildren()
        {
            _children.Clear();
            //children_.shrink_to_fit();
        }

        /// Replaces the occurrences of oldChild with newChild
        public void ReplaceChild(YGNode oldChild, YGNode newChild)
        {
            ReplaceChild(newChild, _children.IndexOf(oldChild));
        }

        public void ReplaceChild(YGNode child, int index)
        {
            _children[index] = child;
        }

        public void InsertChild(YGNode child, int index)
        {
            _children.Insert(index, child);
        }

        /// Removes the first occurrence of child
        public bool RemoveChild(YGNode child)
        {
            if (_children.Contains(child))
                return _children.Remove(child);
            return false;
        }

        public void RemoveChild(int index)
        {
            _children.RemoveAt(index);
        }

        public void CloneChildrenIfNeeded(object cloneContext)
        {
            IterChildrenAfterCloningIfNeeded(null, cloneContext);
        }

        public void MarkDirtyAndPropogate()
        {
            if (!IsDirty)
            {
                SetDirty(true);
                SetLayoutComputedFlexBasis(new FloatOptional());
                _owner?.MarkDirtyAndPropogate();
            }
        }

        public float ResolveFlexGrow()
        {
            // Root nodes flexGrow should always be 0
            if (_owner == null)
                return 0.0f;

            if (!_style.FlexGrow.IsUndefined())
                return _style.FlexGrow.Unwrap();

            if (!_style.Flex.IsUndefined() && _style.Flex.Unwrap() > 0.0f)
                return _style.Flex.Unwrap();

            return DefaultFlexGrow;
        }

        public float ResolveFlexShrink()
        {
            if (_owner == null)
                return 0.0f;

            if (!_style.FlexShrink.IsUndefined())
                return _style.FlexShrink.Unwrap();

            if (!_style.Flex.IsUndefined() && _style.Flex.Unwrap() < 0.0f)
            {
                return -_style.Flex.Unwrap();
            }
            return DefaultFlexShrink;
        }

        public bool IsNodeFlexible()
        {
            return (
                (_style.PositionType == YGPositionType.Relative) &&
                (ResolveFlexGrow() != 0 || ResolveFlexShrink() != 0));
        }

        public bool IsLayoutTreeEqualToNode(in YGNode node)
        {
            if (_children.Count != node._children.Count)
                return false;

            if (_layout != node._layout)
                return false;

            if (_children.Count == 0)
                return true;


            bool isLayoutTreeEqual = true;
            YGNode otherNodeChildren = null;
            for (var i = 0; i < _children.Count; ++i)
            {
                otherNodeChildren = node._children[i];
                isLayoutTreeEqual = _children[i].IsLayoutTreeEqualToNode(otherNodeChildren);
                if (!isLayoutTreeEqual)
                    return false;
            }
            return isLayoutTreeEqual;
        }

        public YGNode Reset()
        {
            YGAssertWithNode(
                this,
                _children.Count == 0,
                "Cannot reset a node which still has children attached");
            YGAssertWithNode(
                this, _owner == null, "Cannot reset a node still attached to a owner");

            // *this = YGNode{getConfig()};
            return new YGNode(GetConfig());
        }

        protected bool Equals(YGNode other)
        {
            if (ReferenceEquals(this, other))
                return true;

            var isEqual = Equals(_style, other._style);
            isEqual = isEqual & Equals(_layout, other._layout);
            isEqual = isEqual & _lineIndex == other._lineIndex;
            isEqual = isEqual & Equals(_config, other._config);
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
            return Equals((YGNode)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_style != null ? _style.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_layout != null ? _layout.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _lineIndex;
                hashCode = (hashCode * 397) ^ (_children != null ? _children.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_config != null ? _config.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_resolvedDimensions != null ? _resolvedDimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ HasNewLayout.GetHashCode();
                hashCode = (hashCode * 397) ^ IsReferenceBaseline.GetHashCode();
                hashCode = (hashCode * 397) ^ IsDirty.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)NodeType;
                return hashCode;
            }
        }

        public static bool operator ==(YGNode left, YGNode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(YGNode left, YGNode right)
        {
            return !Equals(left, right);
        }
    }

}