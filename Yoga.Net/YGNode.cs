using System;
using System.Collections.Generic;

using static Yoga.Net.YGGlobal;

using uint8_t = System.Byte;

namespace Yoga.Net
{
    public class YGNode
    {
        public const float DefaultFlexGrow = 0.0f;
        public const float DefaultFlexShrink = 0.0f;

        public object Context { get; set; }

        bool hasNewLayout_ { get; set; } = true;
        bool isReferenceBaseline_ { get; set; } = false;
        bool isDirty_ { get; set; } = false;
        YGNodeType nodeType_ { get; set; } = YGNodeType.Default;

        uint8_t reserved_ = 0;

        YGMeasureFunc measureFunc_;
        YGBaselineFunc baselineFunc_;
        YGPrintFunc printFunc_;

        YGDirtiedFunc dirtiedFunc_ = null;
        YGStyle style_ = new YGStyle();
        YGLayout layout_ = new YGLayout();
        int lineIndex_ = 0;
        YGNode owner_ = null;
        YGVector children_ = new YGVector();
        YGConfig config_;

        YGValue[] resolvedDimensions_ = { YGValue.Undefined, YGValue.Undefined };

        public YGNode() : this(DefaultConfig) { }

        public YGNode(in YGConfig config)
        {
            config_ = config;
        }

        public YGNode(in YGNode other)
        {
            Context = other.Context;
            measureFunc_ = other.measureFunc_;
            baselineFunc_ = other.baselineFunc_;
            printFunc_ = other.printFunc_;
            dirtiedFunc_ = other.dirtiedFunc_;
            style_ = new YGStyle(other.style_);
            layout_ = new YGLayout(other.layout_);
            lineIndex_ = other.lineIndex_;
            owner_ = other.owner_;
            config_ = other.config_;
            Array.Copy(other.resolvedDimensions_, resolvedDimensions_, resolvedDimensions_.Length);

            // Lazy-clone
            children_.AddRange(other.Children);
        }

        // Does not expose true value semantics, as children are not cloned eagerly.
        // Should we remove this?
        //public YGNode(const YGNode& node) = default;

        // for RB fabric
        public YGNode(in YGNode node, YGConfig config) : this(node)
        {
            config_ = config;
        }

        // If both left and right are defined, then use left. Otherwise return +left or
        // -right depending on which is defined.
        YGFloatOptional relativePosition(
            YGFlexDirection axis,
            float axisSize)
        {
            if (isLeadingPositionDefined(axis))
            {
                return getLeadingPosition(axis, axisSize);
            }

            YGFloatOptional trailingPosition = getTrailingPosition(axis, axisSize);
            if (!trailingPosition.IsUndefined())
            {
                trailingPosition = new YGFloatOptional(-1 * trailingPosition.Unwrap());
            }
            return trailingPosition;
        }

        public uint8_t reserved() { return reserved_; }

        public void print(object printContext)
        {
            printFunc_?.Invoke(this, printContext);
        }

        public bool getHasNewLayout() { return hasNewLayout_; }

        public YGNodeType getNodeType() { return nodeType_; }

        public bool hasMeasureFunc()
        {
            return measureFunc_ != null;
        }

        public YGSize measure(float width, YGMeasureMode widthMode, float height, YGMeasureMode heightMode, object layoutContext)
        {
            return measureFunc_?.Invoke(this, width, widthMode, height, heightMode, layoutContext)
                ?? new YGSize();
        }

        public bool hasBaselineFunc()
        {
            return baselineFunc_ != null;
        }

        public float baseline(float width, float height, object layoutContext)
        {
            return baselineFunc_?.Invoke(this, width, height, layoutContext) ?? 0f;
        }

        public YGDirtiedFunc getDirtied() { return dirtiedFunc_; }

        //// For Performance reasons passing as reference.
        public YGStyle getStyle() { return style_; }

        //// For Performance reasons passing as reference.
        public YGLayout getLayout() { return layout_; }

        public int getLineIndex() { return lineIndex_; }

        public bool isReferenceBaseline() { return isReferenceBaseline_; }

        // returns the YGNode that owns this YGNode. An owner is used to identify
        // the YogaTree that a YGNode belongs to. This method will return the parent
        // of the YGNode when a YGNode only belongs to one YogaTree or nullptr when
        // the YGNode is shared between two or more YogaTrees.
        public YGNode getOwner() { return owner_; }

        // Deprecated, use getOwner() instead.
        //public YGNode getParent() const { return getOwner(); }

        public YGVector getChildren() { return children_; }

        // Applies a callback to all children, after cloning them if they are not
        // owned.
        //template <typename T>
        public void iterChildrenAfterCloningIfNeeded(Action<YGNode, object> callback, object cloneContext)
        {
            for (int i = 0; i < children_.Count; i++)
            {
                var child = children_[i];
                if (child.getOwner() != this)
                {
                    child = config_.CloneNode(child, this, i, cloneContext);
                    child.setOwner(this);
                }
                children_[i] = child;
                callback?.Invoke(child, cloneContext);
            }
        }

        [Obsolete("use Children[i]")]
        public YGNode getChild(int index)
        {
            return children_[index];
        }

        public IReadOnlyList<YGNode> Children => children_;

        public YGConfig getConfig() { return config_; }

        public bool isDirty() { return isDirty_; }

        public YGValue[] getResolvedDimensions() { return resolvedDimensions_; }

        public YGValue getResolvedDimension(YGDimension index) { return resolvedDimensions_[(int)index]; }

        // Methods related to positions, margin, padding and border
        public YGFloatOptional getLeadingPosition(in YGFlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var lp = YGComputedEdgeValue(style_.position, YGEdge.Start, CompactValue.Undefined);
                if (!lp.IsUndefined)
                {
                    return lp.Resolve(axisSize);
                }
            }

            var leadingPosition = YGComputedEdgeValue(style_.position, leading[(int)axis], CompactValue.Undefined);

            return leadingPosition.IsUndefined ? new YGFloatOptional(0f) : leadingPosition.Resolve(axisSize);
        }

        public bool isLeadingPositionDefined(in YGFlexDirection axis)
        {
            return (axis.IsRow() &&
                    !YGComputedEdgeValue(style_.position, YGEdge.Start, CompactValue.Undefined).IsUndefined) ||
                    !YGComputedEdgeValue(style_.position, leading[(int)axis], CompactValue.Undefined).IsUndefined;
        }

        public bool isTrailingPosDefined(in YGFlexDirection axis)
        {
            return (axis.IsRow() &&
                    !YGComputedEdgeValue(style_.position, YGEdge.End, CompactValue.Undefined).IsUndefined) ||
                    !YGComputedEdgeValue(style_.position, trailing[(int)axis], CompactValue.Undefined).IsUndefined;
        }

        public YGFloatOptional getTrailingPosition(in YGFlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var tp = YGComputedEdgeValue(style_.position, YGEdge.End, CompactValue.Undefined);
                if (!tp.IsUndefined)
                {
                    return tp.Resolve(axisSize);
                }
            }

            var trailingPosition = YGComputedEdgeValue(style_.position, trailing[(int)axis], CompactValue.Undefined);

            return trailingPosition.IsUndefined ? new YGFloatOptional(0f) : trailingPosition.Resolve(axisSize);
        }

        public YGFloatOptional getLeadingMargin(in YGFlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() &&
                !style_.margin[YGEdge.Start].IsUndefined)
            {
                return style_.margin[YGEdge.Start].ResolveValueMargin(widthSize);
            }

            return YGComputedEdgeValue(style_.margin, leading[(int)axis], CompactValue.Zero)
                   .ResolveValueMargin(widthSize);
        }

        public YGFloatOptional getTrailingMargin(in YGFlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() && !style_.margin[YGEdge.End].IsUndefined)
            {
                return style_.margin[YGEdge.End].ResolveValueMargin(widthSize);
            }

            return YGComputedEdgeValue(style_.margin, trailing[(int)axis], CompactValue.Zero)
               .ResolveValueMargin(widthSize);
        }
        public float getLeadingBorder(in YGFlexDirection axis)
        {
            YGValue leadingBorder;
            if (axis.IsRow() &&
                !style_.border[YGEdge.Start].IsUndefined)
            {
                leadingBorder = style_.border[YGEdge.Start];
                if (leadingBorder.value >= 0)
                    return leadingBorder.value;
            }

            leadingBorder = YGComputedEdgeValue(style_.border, leading[(int)axis], CompactValue.Zero);
            return FloatMax(leadingBorder.value, 0.0f);
        }

        public float getTrailingBorder(in YGFlexDirection flexDirection)
        {
            YGValue trailingBorder;
            if (flexDirection.IsRow() && !style_.border[YGEdge.End].IsUndefined)
            {
                trailingBorder = style_.border[YGEdge.End];
                if (trailingBorder.value >= 0.0f)
                {
                    return trailingBorder.value;
                }
            }

            trailingBorder = YGComputedEdgeValue(
                style_.border, trailing[(int)flexDirection], CompactValue.Zero);
            return FloatMax(trailingBorder.value, 0.0f);
        }

        public YGFloatOptional getLeadingPadding(in YGFlexDirection axis, in float widthSize)
        {
            YGFloatOptional paddingEdgeStart = style_.padding[YGEdge.Start].Resolve(widthSize);
            if (axis.IsRow() &&
                !style_.padding[YGEdge.Start].IsUndefined &&
                !paddingEdgeStart.IsUndefined() && paddingEdgeStart.Unwrap() >= 0.0f)
            {
                return paddingEdgeStart;
            }

            YGFloatOptional resolvedValue = YGComputedEdgeValue(style_.padding, leading[(int)axis], CompactValue.Zero).Resolve(widthSize);
            return FloatOptionalMax(resolvedValue, new YGFloatOptional(0.0f));
        }

        public YGFloatOptional getTrailingPadding(in YGFlexDirection axis, in float widthSize)
        {
            YGFloatOptional paddingEdgeEnd = style_.padding[YGEdge.End].Resolve(widthSize);
            if (axis.IsRow() && paddingEdgeEnd >= new YGFloatOptional(0.0f))
            {
                return paddingEdgeEnd;
            }

            YGFloatOptional resolvedValue = YGComputedEdgeValue(style_.padding, trailing[(int)axis], CompactValue.Zero).Resolve(widthSize);

            return FloatOptionalMax(resolvedValue, new YGFloatOptional(0.0f));
        }

        public YGFloatOptional getLeadingPaddingAndBorder(in YGFlexDirection axis, in float widthSize)
        {
            return getLeadingPadding(axis, widthSize) + new YGFloatOptional(getLeadingBorder(axis));
        }

        public YGFloatOptional getTrailingPaddingAndBorder(in YGFlexDirection axis, in float widthSize)
        {
            return getTrailingPadding(axis, widthSize) + new YGFloatOptional(getTrailingBorder(axis));
        }

        public YGFloatOptional getMarginForAxis(in YGFlexDirection axis, in float widthSize)
        {
            return getLeadingMargin(axis, widthSize) + getTrailingMargin(axis, widthSize);
        }

        public void setPrintFunc(YGPrintFunc printFunc = null)
        {
            printFunc_ = printFunc;
        }

        public void setHasNewLayout(bool hasNewLayout)
        {
            hasNewLayout_ = hasNewLayout;
        }

        public void setNodeType(YGNodeType nodeType) { nodeType_ = nodeType; }

        void setMeasureFunc() // decltype(measure_)
        {
            if (measureFunc_ == null)
            {
                // TODO: t18095186 Move nodeType to opt-in function and mark appropriate places in Litho
                nodeType_ = YGNodeType.Default;
            }
            else
            {
                YGAssertWithNode(
                    this,
                    children_.Count == 0,
                    "Cannot set measure function: Nodes with measure functions cannot have children.");

                // TODO: t18095186 Move nodeType to opt-in function and mark appropriate places in Litho
                setNodeType(YGNodeType.Text);
            }
        }

        public void setMeasureFunc(YGMeasureFunc measureFunc)
        {
            measureFunc_ = measureFunc;
            setMeasureFunc();
        }

        public YGMeasureFunc getMeasure() => measureFunc_;

        public void setBaselineFunc(YGBaselineFunc baseLineFunc)
        {
            baselineFunc_ = baseLineFunc;
        }

        public YGBaselineFunc getBaselineFunc() => baselineFunc_;

        public void setDirtiedFunc(YGDirtiedFunc dirtiedFunc) { dirtiedFunc_ = dirtiedFunc; }

        public void setStyle(in YGStyle style) { style_ = style; }

        public void setLayout(in YGLayout layout) { layout_ = layout; }

        public void setLineIndex(int lineIndex) { lineIndex_ = lineIndex; }

        public void setIsReferenceBaseline(bool isReferenceBaseline)
        {
            isReferenceBaseline_ = isReferenceBaseline;
        }

        public void setOwner(YGNode owner) { owner_ = owner; }

        public void setChildren(in YGVector children) { children_ = children; }

        public void setChildren(IEnumerable<YGNode> children)
        {
            children_ = new YGVector(children);
        }

        // TODO: rvalue override for setChildren
        //YG_DEPRECATED void setConfig(YGConfig config) { config_ = config; }

        public void setDirty(bool isDirty)
        {
            if (isDirty == isDirty_)
                return;

            isDirty_ = isDirty;
            if (isDirty)
                dirtiedFunc_?.Invoke(this);
        }

        public void setLayoutLastOwnerDirection(YGDirection direction)
        {
            layout_.LastOwnerDirection = direction;
        }

        public void setLayoutComputedFlexBasis(in YGFloatOptional computedFlexBasis)
        {
            layout_.ComputedFlexBasis = computedFlexBasis;
        }

        public void setLayoutComputedFlexBasisGeneration(int computedFlexBasisGeneration)
        {
            layout_.ComputedFlexBasisGeneration = computedFlexBasisGeneration;
        }

        public void setLayoutMeasuredDimension(float measuredDimension, int index)
        {
            layout_.MeasuredDimensions[index] = measuredDimension;
        }
        public void setLayoutMeasuredDimension(float measuredDimension, YGDimension index)
        {
            layout_.MeasuredDimensions[(int)index] = measuredDimension;
        }

        public void setLayoutHadOverflow(bool hadOverflow)
        {
            layout_.HadOverflow = hadOverflow;
        }

        public void setLayoutDimension(float dimension, int index)
        {
            layout_.Dimensions[index] = dimension;
        }

        public void setLayoutDirection(YGDirection direction)
        {
            layout_.Direction = direction;
        }

        public void setLayoutMargin(float margin, YGEdge edge) => layout_.Margin[(int)edge] = margin;

        public void setLayoutBorder(float border, YGEdge edge) => layout_.Border[(int)edge] = border;

        public void setLayoutPadding(float padding, YGEdge edge) => layout_.Padding[(int)edge] = padding;

        public void setLayoutPosition(float position, int index)
        {
            layout_.Position[index] = position;
        }

        public void setPosition(
              in YGDirection direction,
              in float mainSize,
              in float crossSize,
              in float ownerWidth)
        {
            /* Root nodes should be always layouted as LTR, so we don't return negative
             * values. */
            YGDirection directionRespectingRoot = owner_ != null ? direction : YGDirection.LTR;
            YGFlexDirection mainAxis = style_.flexDirection.Resolve(directionRespectingRoot);
            YGFlexDirection crossAxis = mainAxis.CrossAxis(directionRespectingRoot);

            YGFloatOptional relativePositionMain = relativePosition(mainAxis, mainSize);
            YGFloatOptional relativePositionCross = relativePosition(crossAxis, crossSize);

            setLayoutPosition(
                (getLeadingMargin(mainAxis, ownerWidth) + relativePositionMain).Unwrap(),
                (int)leading[(int)mainAxis]);
            setLayoutPosition(
                (getTrailingMargin(mainAxis, ownerWidth) + relativePositionMain).Unwrap(),
                (int)trailing[(int)mainAxis]);
            setLayoutPosition(
                (getLeadingMargin(crossAxis, ownerWidth) + relativePositionCross).Unwrap(),
                (int)leading[(int)crossAxis]);
            setLayoutPosition(
                (getTrailingMargin(crossAxis, ownerWidth) + relativePositionCross).Unwrap(),
                (int)trailing[(int)crossAxis]);
        }

        public void markDirtyAndPropogateDownwards()
        {
            isDirty_ = true;
            foreach (var child in children_)
            {
                child.markDirtyAndPropogateDownwards();
            }
        }

        // Other methods
        public YGValue marginLeadingValue(in YGFlexDirection axis)
        {
            if (axis.IsRow() && !style_.margin[YGEdge.Start].IsUndefined)
                return style_.margin[YGEdge.Start];
            return style_.margin[leading[(int)axis]];
        }

        public YGValue marginTrailingValue(in YGFlexDirection axis)
        {
            if (axis.IsRow() && !style_.margin[YGEdge.End].IsUndefined)
                return style_.margin[YGEdge.End];
            return style_.margin[trailing[(int)axis]];
        }

        public YGValue resolveFlexBasisPtr()
        {
            YGValue flexBasis = style_.flexBasis;
            if (flexBasis.unit != YGUnit.Auto && flexBasis.unit != YGUnit.Undefined)
            {
                return flexBasis;
            }

            if (!style_.flex.IsUndefined() && style_.flex.Unwrap() > 0.0f)
                return YGValue.Zero;
            return YGValue.Auto;
        }

        public void resolveDimension()
        {
            YGStyle style = getStyle();
            foreach (var dim in new[] { YGDimension.Width, YGDimension.Height })
            {
                if (!style.maxDimensions[dim].IsUndefined &&
                    style.maxDimensions[dim] == style.minDimensions[dim])
                {
                    resolvedDimensions_[(int)dim] = style.maxDimensions[dim];
                }
                else
                {
                    resolvedDimensions_[(int)dim] = style.dimensions[dim];
                }
            }
        }

        public YGDirection resolveDirection(in YGDirection ownerDirection)
        {
            if (style_.direction == YGDirection.Inherit)
                return ownerDirection > YGDirection.Inherit ? ownerDirection : YGDirection.LTR;

            return style_.direction;
        }

        public void clearChildren()
        {
            children_.Clear();
            //children_.shrink_to_fit();
        }

        /// Replaces the occurrences of oldChild with newChild
        public void replaceChild(YGNode oldChild, YGNode newChild)
        {
            replaceChild(newChild, children_.IndexOf(oldChild));
        }

        public void replaceChild(YGNode child, int index)
        {
            children_[index] = child;
        }

        public void insertChild(YGNode child, int index)
        {
            children_.Insert(index, child);
        }

        /// Removes the first occurrence of child
        public bool removeChild(YGNode child)
        {
            if (children_.Contains(child))
                return children_.Remove(child);
            return false;
        }

        public void removeChild(int index)
        {
            children_.RemoveAt(index);
        }

        public void cloneChildrenIfNeeded(object cloneContext)
        {
            iterChildrenAfterCloningIfNeeded(null, cloneContext);
        }

        public void markDirtyAndPropogate()
        {
            if (!isDirty_)
            {
                setDirty(true);
                setLayoutComputedFlexBasis(new YGFloatOptional());
                owner_?.markDirtyAndPropogate();
            }
        }

        public float resolveFlexGrow()
        {
            // Root nodes flexGrow should always be 0
            if (owner_ == null)
                return 0.0f;

            if (!style_.flexGrow.IsUndefined())
                return style_.flexGrow.Unwrap();

            if (!style_.flex.IsUndefined() && style_.flex.Unwrap() > 0.0f)
                return style_.flex.Unwrap();

            return DefaultFlexGrow;
        }

        public float resolveFlexShrink()
        {
            if (owner_ == null)
                return 0.0f;

            if (!style_.flexShrink.IsUndefined())
                return style_.flexShrink.Unwrap();

            if (!style_.flex.IsUndefined() && style_.flex.Unwrap() < 0.0f)
            {
                return -style_.flex.Unwrap();
            }
            return DefaultFlexShrink;
        }

        public bool isNodeFlexible()
        {
            return (
                (style_.positionType == YGPositionType.Relative) &&
                (resolveFlexGrow() != 0 || resolveFlexShrink() != 0));
        }

        public bool isLayoutTreeEqualToNode(in YGNode node)
        {
            if (children_.Count != node.children_.Count)
                return false;

            if (layout_ != node.layout_)
                return false;

            if (children_.Count == 0)
                return true;


            bool isLayoutTreeEqual = true;
            YGNode otherNodeChildren = null;
            for (var i = 0; i < children_.Count; ++i)
            {
                otherNodeChildren = node.children_[i];
                isLayoutTreeEqual = children_[i].isLayoutTreeEqualToNode(otherNodeChildren);
                if (!isLayoutTreeEqual)
                    return false;
            }
            return isLayoutTreeEqual;
        }

        public YGNode reset()
        {
            YGAssertWithNode(
                this,
                children_.Count == 0,
                "Cannot reset a node which still has children attached");
            YGAssertWithNode(
                this, owner_ == null, "Cannot reset a node still attached to a owner");

            // *this = YGNode{getConfig()};
            return new YGNode(getConfig());
        }

        protected bool Equals(YGNode other)
        {
            if (ReferenceEquals(this, other))
                return true;

            var isEqual = Equals(style_, other.style_);
            isEqual = isEqual & Equals(layout_, other.layout_);
            isEqual = isEqual & lineIndex_ == other.lineIndex_;
            isEqual = isEqual & Equals(config_, other.config_);
            isEqual = isEqual & hasNewLayout_ == other.hasNewLayout_;
            isEqual = isEqual & isReferenceBaseline_ == other.isReferenceBaseline_;
            isEqual = isEqual & isDirty_ == other.isDirty_;
            isEqual = isEqual & nodeType_ == other.nodeType_;
            isEqual = isEqual & (children_.Count == other.Children.Count);

            if (isEqual)
            {
                isEqual = isEqual & resolvedDimensions_[0] == other.resolvedDimensions_[0];
                isEqual = isEqual & resolvedDimensions_[1] == other.resolvedDimensions_[1];
                for (int i = 0; i < children_.Count && isEqual; i++)
                {
                    isEqual = isEqual & children_[i] == other.Children[0];
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
                var hashCode = (style_ != null ? style_.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (layout_ != null ? layout_.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ lineIndex_;
                hashCode = (hashCode * 397) ^ (children_ != null ? children_.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (config_ != null ? config_.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (resolvedDimensions_ != null ? resolvedDimensions_.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ hasNewLayout_.GetHashCode();
                hashCode = (hashCode * 397) ^ isReferenceBaseline_.GetHashCode();
                hashCode = (hashCode * 397) ^ isDirty_.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)nodeType_;
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