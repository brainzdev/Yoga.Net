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

        /// <summary>
        /// the YGNode that owns this YGNode. An owner is used to identify
        /// the YogaTree that a YGNode belongs to. This method will return the parent
        /// of the YGNode when a YGNode only belongs to one YogaTree or null when
        /// the YGNode is shared between two or more YogaTrees.
        /// </summary>
        public YGNode Owner { get; set; }
        public object Context { get; set; }
        public YogaConfig Config { get; private set; }
        public YogaLayout Layout { get; set; } = new YogaLayout();

        public YogaStyle Style
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

        YogaStyle _style = new YogaStyle();
        YGNodes _children = new YGNodes();

        bool HasNewLayout { get; set; } = true;
        NodeType NodeType { get; set; } = NodeType.Default;

        uint8_t _reserved = 0;

        MeasureFunc _measureFunc;
        BaselineFunc _baselineFunc;
        PrintFunc _printFunc;
        bool _isReferenceBaseline;

        DirtiedFunc _dirtiedFunc = null;
        
        int _lineIndex = 0;

        YogaValue[] _resolvedDimensions = {YogaValue.Undefined, YogaValue.Undefined};


        public bool IsDirty { get; set; }

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

        public YGNode() : this(DefaultConfig) { }

        public YGNode(YogaConfig config)
        {
            Config = config;
        }

        public YGNode(YGNode other)
        {
            Context       = other.Context;
            _measureFunc  = other._measureFunc;
            _baselineFunc = other._baselineFunc;
            _printFunc    = other._printFunc;
            _dirtiedFunc  = other._dirtiedFunc;
            _style        = new YogaStyle(other.Style);
            Layout        = new YogaLayout(other.Layout);
            _lineIndex    = other._lineIndex;
            Owner         = other.Owner;
            Config       = other.Config;
            Array.Copy(other._resolvedDimensions, _resolvedDimensions, _resolvedDimensions.Length);

            // Lazy-clone
            _children.AddRange(other.Children);
        }

        // for RB fabric
        public YGNode(YGNode node, YogaConfig config) : this(node)
        {
            Config = config;
        }

        // If both left and right are defined, then use left. Otherwise return +left or
        // -right depending on which is defined.
        FloatOptional RelativePosition(
            FlexDirection axis,
            float axisSize)
        {
            if (IsLeadingPositionDefined(axis))
            {
                return GetLeadingPosition(axis, axisSize);
            }

            FloatOptional trailingPosition = GetTrailingPosition(axis, axisSize);
            if (!trailingPosition.IsUndefined)
            {
                trailingPosition = new FloatOptional(-1 * trailingPosition.Unwrap());
            }

            return trailingPosition;
        }

        public uint8_t Reserved()
        {
            return _reserved;
        }

        public void Print(object printContext)
        {
            _printFunc?.Invoke(this, printContext);
        }

        public bool GetHasNewLayout()
        {
            return HasNewLayout;
        }

        public NodeType GetNodeType()
        {
            return NodeType;
        }

        public bool HasMeasureFunc()
        {
            return _measureFunc != null;
        }

        public YogaSize Measure(float width, MeasureMode widthMode, float height, MeasureMode heightMode, object layoutContext)
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

        public DirtiedFunc GetDirtied()
        {
            return _dirtiedFunc;
        }

        public int GetLineIndex()
        {
            return _lineIndex;
        }


        // Applies a callback to all children, after cloning them if they are not
        // owned.
        //template <typename T>
        public void IterChildrenAfterCloningIfNeeded(Action<YGNode, object> callback, object cloneContext)
        {
            for (int i = 0; i < _children.Count; i++)
            {
                var child = _children[i];
                if (child.Owner != this)
                {
                    child = Config.CloneNode(child, this, i, cloneContext);
                    child.Owner = this;
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

        public YogaValue[] GetResolvedDimensions()
        {
            return _resolvedDimensions;
        }

        public YogaValue GetResolvedDimension(Dimension index)
        {
            return _resolvedDimensions[(int)index];
        }

        // Methods related to positions, margin, padding and border
        public FloatOptional GetLeadingPosition(FlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var lp = Style.Position.ComputedEdgeValue(Edge.Start);
                if (!lp.IsUndefined)
                {
                    return lp.Resolve(axisSize);
                }
            }

            var leadingPosition = Style.Position.ComputedEdgeValue(leading[(int)axis]);

            return leadingPosition.IsUndefined ? new FloatOptional(0f) : leadingPosition.Resolve(axisSize);
        }

        public bool IsLeadingPositionDefined(FlexDirection axis)
        {
            return (axis.IsRow() &&
                    !Style.Position.ComputedEdgeValue(Edge.Start).IsUndefined) ||
                !Style.Position.ComputedEdgeValue(leading[(int)axis]).IsUndefined;
        }

        public bool IsTrailingPosDefined(FlexDirection axis)
        {
            return (axis.IsRow() &&
                    !Style.Position.ComputedEdgeValue(Edge.End).IsUndefined) ||
                !Style.Position.ComputedEdgeValue(trailing[(int)axis]).IsUndefined;
        }

        public FloatOptional GetTrailingPosition(FlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var tp = Style.Position.ComputedEdgeValue(Edge.End);
                if (!tp.IsUndefined)
                {
                    return tp.Resolve(axisSize);
                }
            }

            var trailingPosition = Style.Position.ComputedEdgeValue(trailing[(int)axis]);

            return trailingPosition.IsUndefined ? new FloatOptional(0f) : trailingPosition.Resolve(axisSize);
        }

        public FloatOptional GetLeadingMargin(FlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() &&
                !Style.Margin[Edge.Start].IsUndefined)
            {
                return Style.Margin[Edge.Start].ResolveValueMargin(widthSize);
            }

            return Style.Margin.ComputedEdgeValue(leading[(int)axis], YogaValue.Zero)
                         .ResolveValueMargin(widthSize);
        }

        public FloatOptional GetTrailingMargin(FlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() && !Style.Margin[Edge.End].IsUndefined)
            {
                return Style.Margin[Edge.End].ResolveValueMargin(widthSize);
            }

            return Style.Margin.ComputedEdgeValue(trailing[(int)axis], YogaValue.Zero)
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

            leadingBorder = Style.Border.ComputedEdgeValue(leading[(int)axis], YogaValue.Zero);
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

            trailingBorder = Style.Border.ComputedEdgeValue(trailing[(int)flexDirection], YogaValue.Zero);
            return FloatMax(trailingBorder.Value, 0.0f);
        }

        public FloatOptional GetLeadingPadding(FlexDirection axis, in float widthSize)
        {
            FloatOptional paddingEdgeStart = Style.Padding[Edge.Start].Resolve(widthSize);
            if (axis.IsRow() &&
                !Style.Padding[Edge.Start].IsUndefined &&
                !paddingEdgeStart.IsUndefined && paddingEdgeStart.Unwrap() >= 0.0f)
            {
                return paddingEdgeStart;
            }

            var resolvedValue = Style.Padding.ComputedEdgeValue(leading[(int)axis], YogaValue.Zero).Resolve(widthSize);
            return FloatOptional.Max(resolvedValue, new FloatOptional(0.0f));
        }

        public FloatOptional GetTrailingPadding(FlexDirection axis, in float widthSize)
        {
            FloatOptional paddingEdgeEnd = Style.Padding[Edge.End].Resolve(widthSize);
            if (axis.IsRow() && paddingEdgeEnd >= new FloatOptional(0.0f))
            {
                return paddingEdgeEnd;
            }

            var resolvedValue = Style.Padding.ComputedEdgeValue(trailing[(int)axis], YogaValue.Zero).Resolve(widthSize);

            return FloatOptional.Max(resolvedValue, new FloatOptional(0.0f));
        }

        public FloatOptional GetLeadingPaddingAndBorder(FlexDirection axis, in float widthSize)
        {
            return GetLeadingPadding(axis, widthSize) + new FloatOptional(GetLeadingBorder(axis));
        }

        public FloatOptional GetTrailingPaddingAndBorder(FlexDirection axis, in float widthSize)
        {
            return GetTrailingPadding(axis, widthSize) + new FloatOptional(GetTrailingBorder(axis));
        }

        public FloatOptional GetMarginForAxis(FlexDirection axis, in float widthSize)
        {
            return GetLeadingMargin(axis, widthSize) + GetTrailingMargin(axis, widthSize);
        }

        public void SetPrintFunc(PrintFunc printFunc = null)
        {
            _printFunc = printFunc;
        }

        public void SetHasNewLayout(bool hasNewLayout)
        {
            HasNewLayout = hasNewLayout;
        }

        public void SetNodeType(NodeType nodeType)
        {
            NodeType = nodeType;
        }

        void SetMeasureFunc() // decltype(measure_)
        {
            if (_measureFunc == null)
            {
                // TODO: t18095186 Move nodeType to opt-in function and mark appropriate places in Litho
                NodeType = NodeType.Default;
            }
            else
            {
                YGAssertWithNode(
                    this,
                    _children.Count == 0,
                    "Cannot set measure function: Nodes with measure functions cannot have children.");

                // TODO: t18095186 Move nodeType to opt-in function and mark appropriate places in Litho
                SetNodeType(NodeType.Text);
            }
        }

        public void SetMeasureFunc(MeasureFunc measureFunc)
        {
            _measureFunc = measureFunc;
            SetMeasureFunc();
        }

        public MeasureFunc GetMeasure() => _measureFunc;

        public void SetBaselineFunc(BaselineFunc baseLineFunc)
        {
            _baselineFunc = baseLineFunc;
        }

        public BaselineFunc GetBaselineFunc() => _baselineFunc;

        public void SetDirtiedFunc(DirtiedFunc dirtiedFunc)
        {
            _dirtiedFunc = dirtiedFunc;
        }

        public void SetLineIndex(int lineIndex)
        {
            _lineIndex = lineIndex;
        }

        public void SetIsReferenceBaseline(bool isReferenceBaseline)
        {
            IsReferenceBaseline = isReferenceBaseline;
        }

        public void SetChildren(IEnumerable<YGNode> nodes)
        {
            _children = new YGNodes(nodes);
        }

        public void SetDirty(bool isDirty)
        {
            if (isDirty == IsDirty)
                return;

            IsDirty = isDirty;
            if (isDirty)
                _dirtiedFunc?.Invoke(this);
        }

        public void SetLayoutLastOwnerDirection(Direction direction)
        {
            Layout.LastOwnerDirection = direction;
        }

        public void SetLayoutComputedFlexBasis(FloatOptional computedFlexBasis)
        {
            Layout.ComputedFlexBasis = computedFlexBasis;
        }

        public void SetLayoutComputedFlexBasisGeneration(int computedFlexBasisGeneration)
        {
            Layout.ComputedFlexBasisGeneration = computedFlexBasisGeneration;
        }

        public void SetLayoutMeasuredDimension(float measuredDimension, int index)
        {
            Layout.MeasuredDimensions[index] = measuredDimension;
        }

        public void SetLayoutMeasuredDimension(float measuredDimension, Dimension index)
        {
            Layout.MeasuredDimensions[(int)index] = measuredDimension;
        }

        public void SetLayoutHadOverflow(bool hadOverflow)
        {
            Layout.HadOverflow = hadOverflow;
        }

        public void SetLayoutDirection(Direction direction)
        {
            Layout.Direction = direction;
        }

        public void SetLayoutMargin(float margin, Edge edge) => Layout.Margin[(int)edge] = margin;

        public void SetLayoutBorder(float border, Edge edge) => Layout.Border[(int)edge] = border;

        public void SetLayoutPadding(float padding, Edge edge) => Layout.Padding[(int)edge] = padding;

        public void SetLayoutPosition(float position, int index)
        {
            Layout.Position[index] = position;
        }

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
            return Style.Margin[leading[(int)axis]];
        }

        public YogaValue MarginTrailingValue(FlexDirection axis)
        {
            if (axis.IsRow() && !Style.Margin[Edge.End].IsUndefined)
                return Style.Margin[Edge.End];
            return Style.Margin[trailing[(int)axis]];
        }

        public YogaValue ResolveFlexBasisPtr()
        {
            YogaValue flexBasis = Style.FlexBasis;
            if (flexBasis.Unit != YogaUnit.Auto && flexBasis.Unit != YogaUnit.Undefined)
            {
                return flexBasis;
            }

            if (!Style.Flex.IsUndefined && Style.Flex.Unwrap() > 0.0f)
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

        public void MarkDirtyAndPropagate()
        {
            if (!IsDirty)
            {
                SetDirty(true);
                SetLayoutComputedFlexBasis(new FloatOptional());
                Owner?.MarkDirtyAndPropagate();
            }
        }

        public float ResolveFlexGrow()
        {
            // Root nodes flexGrow should always be 0
            if (Owner == null)
                return 0.0f;

            if (!Style.FlexGrow.IsUndefined)
                return Style.FlexGrow.Unwrap();

            if (!Style.Flex.IsUndefined && Style.Flex.Unwrap() > 0.0f)
                return Style.Flex.Unwrap();

            return DefaultFlexGrow;
        }

        public float ResolveFlexShrink()
        {
            if (Owner == null)
                return 0.0f;

            if (!Style.FlexShrink.IsUndefined)
                return Style.FlexShrink.Unwrap();

            if (!Style.Flex.IsUndefined && Style.Flex.Unwrap() < 0.0f)
            {
                return -Style.Flex.Unwrap();
            }

            return DefaultFlexShrink;
        }

        public bool IsNodeFlexible()
        {
            return (
                (Style.PositionType == PositionType.Relative) &&
                (ResolveFlexGrow().IsNotZero() || ResolveFlexShrink().IsNotZero()));
        }

        public bool IsLayoutTreeEqualToNode(YGNode node)
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

        public YGNode Reset()
        {
            YGAssertWithNode(
                this,
                _children.Count == 0,
                "Cannot reset a node which still has children attached");
            YGAssertWithNode(
                this,
                Owner == null,
                "Cannot reset a node still attached to a owner");

            return new YGNode(Config);
        }

        protected bool Equals(YGNode other)
        {
            if (ReferenceEquals(this, other))
                return true;

            var isEqual = Equals(Style, other.Style);
            isEqual = isEqual & Equals(Layout, other.Layout);
            isEqual = isEqual & _lineIndex == other._lineIndex;
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
            return Equals((YGNode)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Style != null ? Style.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Layout != null ? Layout.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _lineIndex;
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
