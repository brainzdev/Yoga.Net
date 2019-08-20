using System;
using System.Collections.Generic;
using static Yoga.Net.YGGlobal;

using YGConfigRef = Yoga.Net.YGConfig;
using YGNodeRef = Yoga.Net.YGNode;
using uint32_t = System.UInt32;
using uint8_t = System.Byte;

namespace Yoga.Net
{
    public delegate YGSize MeasureWithContextFn(YGNode node, float width, YGMeasureMode widthMode, float height, YGMeasureMode heightMode, object layoutContext);
    public delegate float BaselineWithContextFn(YGNode node, float width, float height, object layoutContext);
    public delegate void PrintWithContextFn(YGNode node, object layoutContext);


    public class YGNode
    {

        //private:

        bool hasNewLayout_ { get; set; } = true;
        bool isReferenceBaseline_ { get; set; } = false;
        bool isDirty_ { get; set; } = false;
        YGNodeType nodeType_ { get; set; } = YGNodeType.Default;
        bool measureUsesContext_ { get; set; } = false;
        bool baselineUsesContext_ { get; set; } = false;
        bool printUsesContext_ { get; set; } = false;
        bool useWebDefaults_ { get; set; } = false;

        //const size_t hasNewLayout_ = 0;
        //const size_t isReferenceBaseline_ = 1;
        //const size_t isDirty_ = 2;
        //const size_t nodeType_ = 3;
        //const size_t measureUsesContext_ = 4;
        //const size_t baselineUsesContext_ = 5;
        //const size_t printUsesContext_ = 6;
        //const size_t useWebDefaults_ = 7;

        object context_ = null;
        uint8_t reserved_ = 0;

        //using Flags = facebook::yoga::Bitfield<uint8_t, bool, bool, bool, YGNodeType, bool, bool, bool, bool>;
        //Flags flags_ = {true, false, false, YGNodeTypeDefault, false, false, false, false};

        //union {
        YGMeasureFunc measureNoContext;
        MeasureWithContextFn measureWithContext;
        //} measure_ = {nullptr};
        //union {
        YGBaselineFunc baselineNoContext;
        BaselineWithContextFn baselineWithContext;
        //} baseline_ = {nullptr};
        //union {
        YGPrintFunc printNoContext;
        PrintWithContextFn printWithContext;
        //} print_ = {nullptr};

        YGDirtiedFunc dirtied_ = null;
        YGStyle style_ = new YGStyle();
        YGLayout layout_ = new YGLayout();
        uint32_t lineIndex_ = 0;
        YGNodeRef owner_ = null;
        YGVector children_ = new YGVector();
        YGConfigRef config_;

        YGValue[] resolvedDimensions_ = { YGValue.Undefined, YGValue.Undefined };

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
            if (!trailingPosition.isUndefined()) 
            {
                trailingPosition = new YGFloatOptional(-1 * trailingPosition.unwrap());
            }
            return trailingPosition;
        }

        void useWebDefaults()
        {
            useWebDefaults_ = true;
            style_.flexDirection = YGFlexDirection.Row;
            style_.alignContent = YGAlign.Stretch;
        }

        // DANGER DANGER DANGER!
        // If the the node assigned to has children, we'd either have to deallocate
        // them (potentially incorrect) or ignore them (danger of leaks). Only ever
        // use this after checking that there are no children.
        // DO NOT CHANGE THE VISIBILITY OF THIS METHOD!
        //YGNode& operator=(YGNode&&) = default;

        //public:
        public YGNode() : this(YGConfigGetDefault()) { }

        public YGNode(in YGConfigRef config)
        {
            config_ = config;
            if (config.useWebDefaults) 
                useWebDefaults();
        }
        //~YGNode() = default; // cleanup of owner/children relationships in YGNodeFree

        public YGNode(in YGNode node)
        {
            context_            = node.context_;
            measureNoContext = node.measureNoContext;
            measureWithContext = node.measureWithContext;
            baselineNoContext = node.baselineNoContext;
            baselineWithContext = node.baselineWithContext;
            printNoContext = node.printNoContext;
            printWithContext = node.printWithContext;
            dirtied_            = node.dirtied_;
            style_              = node.style_;
            layout_             = node.layout_;
            lineIndex_          = node.lineIndex_;
            owner_              = node.owner_;
            config_             = node.config_;
            resolvedDimensions_ = node.resolvedDimensions_;

            foreach (var c in node.children_)
            {
                node.children_.Remove(c);
                children_.Add(c);
                c.setOwner(this);       // c->setOwner(c);
            }
        }

        // Does not expose true value semantics, as children are not cloned eagerly.
        // Should we remove this?
        //public YGNode(const YGNode& node) = default;

        // for RB fabric
        public YGNode(in YGNode node, YGConfigRef config) : this(node)
        {
            config_ = config;
            if (config.useWebDefaults) 
                useWebDefaults();
        }

        // assignment means potential leaks of existing children, or alternatively
        // freeing unowned memory, double free, or freeing stack memory.
        //public YGNode& operator=(const YGNode&) = delete;

        // Getters
        public object getContext() { return context_; }

        public uint8_t reserved() { return reserved_; }

        public void print(object printContext)
        {  
            if (printUsesContext_) 
                printWithContext?.Invoke(this, printContext);
            else 
                printNoContext?.Invoke(this);
        }

        public bool getHasNewLayout() { return hasNewLayout_; }

        public YGNodeType getNodeType() { return nodeType_; }

        public bool hasMeasureFunc()
        {
            return measureNoContext != null || measureWithContext != null;
        }

        public YGSize measure(float width, YGMeasureMode widthMode, float height, YGMeasureMode heightMode, object layoutContext)
        {
            return (measureUsesContext_
                ? measureWithContext?.Invoke(this, width, widthMode, height, heightMode, layoutContext)
                : measureNoContext?.Invoke(this, width, widthMode, height, heightMode)) 
                ?? new YGSize();
        }

        public bool hasBaselineFunc() 
        {
            return baselineNoContext != null || baselineWithContext != null;
        }

        public float baseline(float width, float height, object layoutContext)
        {
            return (baselineUsesContext_
                ? baselineWithContext?.Invoke(this, width, height, layoutContext)
                : baselineNoContext(this, width, height)) ?? 0f;
        }

        public YGDirtiedFunc getDirtied() { return dirtied_; }

        //// For Performance reasons passing as reference.
        public YGStyle getStyle() { return style_; }

        //// For Performance reasons passing as reference.
        public YGLayout getLayout() { return layout_; }

        public uint32_t getLineIndex() { return lineIndex_; }

        public bool isReferenceBaseline() { return isReferenceBaseline_; }

        // returns the YGNodeRef that owns this YGNode. An owner is used to identify
        // the YogaTree that a YGNode belongs to. This method will return the parent
        // of the YGNode when a YGNode only belongs to one YogaTree or nullptr when
        // the YGNode is shared between two or more YogaTrees.
        public YGNodeRef getOwner() { return owner_; }

        // Deprecated, use getOwner() instead.
        //public YGNodeRef getParent() const { return getOwner(); }

        public YGVector getChildren() { return children_; }

        // Applies a callback to all children, after cloning them if they are not
        // owned.
        //template <typename T>
        public void iterChildrenAfterCloningIfNeeded(Action<YGNodeRef,object> callback, object cloneContext)
        {
            for (int i = 0; i < children_.Count; i++)
            {
                var child = children_[i];
                if (child.getOwner() != this)
                {
                    child = config_.cloneNode(child, this, i, cloneContext);
                    child.setOwner(this);
                }

                callback?.Invoke(child, cloneContext);
            }
        }

        [Obsolete("use Children[i]")]
        public YGNodeRef getChild(int index)
        {
            return children_[index];
        }

        public List<YGNode> Children => children_;

        public YGConfigRef getConfig() { return config_; }

        public bool isDirty() { return isDirty_; }

        public YGValue[] getResolvedDimensions() { return resolvedDimensions_; }

        public YGValue getResolvedDimension(int index) {return resolvedDimensions_[index]; }

        // Methods related to positions, margin, padding and border
        public YGFloatOptional getLeadingPosition(in YGFlexDirection axis, in float axisSize)
        {
            if (YGFlexDirectionIsRow(axis)) 
            {
                var lp = YGComputedEdgeValue(style_.position, YGEdge.Start, CompactValue.Undefined);
                if (!lp.isUndefined()) 
                {
                    return YGResolveValue(lp, axisSize);
                }
            }

            var leadingPosition = YGComputedEdgeValue(style_.position, leading[(int)axis], CompactValue.Undefined);

            return leadingPosition.isUndefined() ? new YGFloatOptional(0f) : YGResolveValue(leadingPosition, axisSize);
        }

        public bool isLeadingPositionDefined(in YGFlexDirection axis)
        {
            return (YGFlexDirectionIsRow(axis) &&
                    !YGComputedEdgeValue(style_.position, YGEdge.Start, CompactValue.Undefined).isUndefined()) ||
                    !YGComputedEdgeValue(style_.position, leading[(int)axis], CompactValue.Undefined).isUndefined();
        }

        public bool isTrailingPosDefined(in YGFlexDirection axis)
        {
            return (YGFlexDirectionIsRow(axis) &&
                    !YGComputedEdgeValue(style_.position, YGEdge.End, CompactValue.Undefined).isUndefined()) ||
                    !YGComputedEdgeValue(style_.position, trailing[(int)axis], CompactValue.Undefined).isUndefined();
        }

        public YGFloatOptional getTrailingPosition(in YGFlexDirection axis, in float axisSize)
        {
            if (YGFlexDirectionIsRow(axis))
            {
                var tp = YGComputedEdgeValue(style_.position, YGEdge.End, CompactValue.Undefined);
                if (!tp.isUndefined()) 
                {
                    return YGResolveValue(tp, axisSize);
                }
            }

            var trailingPosition = YGComputedEdgeValue(style_.position, trailing[(int)axis], CompactValue.Undefined);

            return trailingPosition.isUndefined() ? new YGFloatOptional(0f) : YGResolveValue(trailingPosition, axisSize);
        }

        public YGFloatOptional getLeadingMargin(in YGFlexDirection axis, in float widthSize)
        {
            if (YGFlexDirectionIsRow(axis) &&
                !style_.margin[YGEdge.Start].isUndefined()) 
            {
                return YGResolveValueMargin(style_.margin[YGEdge.Start], widthSize);
            }

            return YGResolveValueMargin(
                YGComputedEdgeValue(style_.margin, leading[(int)axis], CompactValue.Zero),
                widthSize);
        }

        public YGFloatOptional getTrailingMargin(in YGFlexDirection axis, in float widthSize)
        {
            if (YGFlexDirectionIsRow(axis) && !style_.margin[YGEdge.End].isUndefined()) 
            {
                return YGResolveValueMargin(style_.margin[YGEdge.End], widthSize);
            }

            return YGResolveValueMargin(
                YGComputedEdgeValue(style_.margin, trailing[(int)axis], CompactValue.Zero), 
                widthSize);
        }
        public float getLeadingBorder(in YGFlexDirection axis)
        {
            YGValue leadingBorder;
            if (YGFlexDirectionIsRow(axis) &&
                !style_.border[YGEdge.Start].isUndefined()) 
            {
                leadingBorder = style_.border[YGEdge.Start];
                if (leadingBorder.value >= 0) 
                    return leadingBorder.value;
            }

            leadingBorder = YGComputedEdgeValue(style_.border, leading[(int)axis], CompactValue.Zero);
            return YGFloatMax(leadingBorder.value, 0.0f);
        }

        public float getTrailingBorder(in YGFlexDirection flexDirection)
        {
            YGValue trailingBorder;
            if (YGFlexDirectionIsRow(flexDirection) &&
                !style_.border[YGEdge.End].isUndefined()) 
            {
                trailingBorder = style_.border[YGEdge.End];
                if (trailingBorder.value >= 0.0f) 
                {
                    return trailingBorder.value;
                }
            }

            trailingBorder = YGComputedEdgeValue(
                style_.border, trailing[(int)flexDirection], CompactValue.Zero);
            return YGFloatMax(trailingBorder.value, 0.0f);
        }

        public YGFloatOptional getLeadingPadding(in YGFlexDirection axis,in float widthSize)
        {
            YGFloatOptional paddingEdgeStart =
                YGResolveValue(style_.padding[YGEdge.Start], widthSize);
            if (YGFlexDirectionIsRow(axis) &&
                !style_.padding[YGEdge.Start].isUndefined() &&
                !paddingEdgeStart.isUndefined() && paddingEdgeStart.unwrap() >= 0.0f) 
            {
                return paddingEdgeStart;
            }

            YGFloatOptional resolvedValue = YGResolveValue(
                YGComputedEdgeValue(style_.padding, leading[(int)axis], CompactValue.Zero),
                widthSize);
            return YGFloatOptionalMax(resolvedValue, new YGFloatOptional(0.0f));
        }

        public YGFloatOptional getTrailingPadding(in YGFlexDirection axis,in float widthSize)
        {
            YGFloatOptional paddingEdgeEnd =
                YGResolveValue(style_.padding[YGEdge.End], widthSize);
            if (YGFlexDirectionIsRow(axis) && paddingEdgeEnd >= new YGFloatOptional(0.0f)) 
            {
                return paddingEdgeEnd;
            }

            YGFloatOptional resolvedValue = YGResolveValue(
                YGComputedEdgeValue(style_.padding, trailing[(int)axis], CompactValue.Zero),
                widthSize);

            return YGFloatOptionalMax(resolvedValue, new YGFloatOptional(0.0f));
        }

        public YGFloatOptional getLeadingPaddingAndBorder(in YGFlexDirection axis,in float widthSize)
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

        // Setters
        public void setContext(object context) { context_ = context; }

        public void setPrintFunc(YGPrintFunc printFunc = null)
        {
            printNoContext = printFunc;
            printWithContext = null;
            printUsesContext_ = false;
        }
        public void setPrintFunc(PrintWithContextFn printFunc)
        {
            printWithContext = printFunc;
            printNoContext = null;
            printUsesContext_ = true;
        }

        public void setHasNewLayout(bool hasNewLayout)
        {
            hasNewLayout_ = hasNewLayout;
        }

        public void setNodeType(YGNodeType nodeType) { nodeType_ = nodeType; }

        void setMeasureFunc( /*decltype(measure_)*/)
        {
            if (measureNoContext == null && measureWithContext == null) 
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

        public void setMeasureFunc(YGMeasureFunc measureFunc = null)
        {
            measureUsesContext_ = false;
            measureNoContext = measureFunc;
            measureWithContext = null;
            setMeasureFunc();
        }

        public void setMeasureFunc(MeasureWithContextFn measureFunc)
        {
            measureUsesContext_ = true;
            measureNoContext    = null;
            measureWithContext  = measureFunc;
            setMeasureFunc();
        }

        public void setBaselineFunc(YGBaselineFunc baseLineFunc = null)
        {
            baselineUsesContext_ = false;
            baselineNoContext = baseLineFunc;
            baselineWithContext = null;
        }
        public void setBaselineFunc(BaselineWithContextFn baseLineFunc)
        {
            baselineUsesContext_ = true;
            baselineWithContext = baseLineFunc;
            baselineNoContext = null;
        }

        public void setDirtiedFunc(YGDirtiedFunc dirtiedFunc) { dirtied_ = dirtiedFunc; }

        public void setStyle(in YGStyle style) { style_ = style; }

        public void setLayout(in YGLayout layout) { layout_ = layout; }

        public void setLineIndex(uint32_t lineIndex) { lineIndex_ = lineIndex; }

        public void setIsReferenceBaseline(bool isReferenceBaseline)
        {
            isReferenceBaseline_ = isReferenceBaseline;
        }

        public void setOwner(YGNodeRef owner) { owner_ = owner; }

        public void setChildren(in YGVector children) { children_ = children; }

        // TODO: rvalue override for setChildren
        //YG_DEPRECATED void setConfig(YGConfigRef config) { config_ = config; }

        public void setDirty(bool isDirty)
        {
            if (isDirty == isDirty_) 
                return;
            
            isDirty_ = isDirty;
            if (isDirty) 
                dirtied_?.Invoke(this);
        }

        public void setLayoutLastOwnerDirection(YGDirection direction)
        {
            layout_.lastOwnerDirection = direction;
        }

        public void setLayoutComputedFlexBasis(in YGFloatOptional computedFlexBasis)
        {
            layout_.computedFlexBasis = computedFlexBasis;
        }

        public void setLayoutComputedFlexBasisGeneration(uint32_t computedFlexBasisGeneration)
        {
            layout_.computedFlexBasisGeneration = computedFlexBasisGeneration;
        }

        public void setLayoutMeasuredDimension(float measuredDimension, int index)
        {
            layout_.measuredDimensions[index] = measuredDimension;
        }

        public void setLayoutHadOverflow(bool hadOverflow)
        {
            layout_.hadOverflow = hadOverflow;
        }

        public void setLayoutDimension(float dimension, int index)
        {
            layout_.dimensions[index] = dimension;
        }

        public void setLayoutDirection(YGDirection direction)
        {
            layout_.direction = direction;
        }

        public void setLayoutMargin(float margin, int index)
        {
            layout_.margin[index] = margin;
        }

        public void setLayoutBorder(float border, int index)
        {
            layout_.border[index] = border;
        }

        public void setLayoutPadding(float padding, int index)
        {
            layout_.padding[index] = padding;
        }

        public void setLayoutPosition(float position, int index)
        {
            layout_.position[index] = position;
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
            YGFlexDirection mainAxis = YGResolveFlexDirection(style_.flexDirection, directionRespectingRoot);
            YGFlexDirection crossAxis = YGFlexDirectionCross(mainAxis, directionRespectingRoot);

            YGFloatOptional relativePositionMain = relativePosition(mainAxis, mainSize);
            YGFloatOptional relativePositionCross = relativePosition(crossAxis, crossSize);

            setLayoutPosition(
                (getLeadingMargin(mainAxis, ownerWidth) + relativePositionMain).unwrap(),
                (int)leading[(int)mainAxis]);
            setLayoutPosition(
                (getTrailingMargin(mainAxis, ownerWidth) + relativePositionMain).unwrap(),
                (int)trailing[(int)mainAxis]);
            setLayoutPosition(
                (getLeadingMargin(crossAxis, ownerWidth) + relativePositionCross).unwrap(),
                (int)leading[(int)crossAxis]);
            setLayoutPosition(
                (getTrailingMargin(crossAxis, ownerWidth) + relativePositionCross).unwrap(),
                (int)trailing[(int)crossAxis]);
        }

        public void setLayoutDoesLegacyFlagAffectsLayout(bool doesLegacyFlagAffectsLayout)
        {
            layout_.doesLegacyStretchFlagAffectsLayout = doesLegacyFlagAffectsLayout;
        }

        public void setLayoutDidUseLegacyFlag(bool didUseLegacyFlag)
        {
            layout_.didUseLegacyFlag = didUseLegacyFlag;
        }

        public void markDirtyAndPropogateDownwards()
        {
            isDirty_ = true;
            foreach(var child in children_) 
            {
                child.markDirtyAndPropogateDownwards();
            }
        }

        // Other methods
        public YGValue marginLeadingValue(in YGFlexDirection axis)
        {
            if (YGFlexDirectionIsRow(axis) && !style_.margin[YGEdge.Start].isUndefined()) 
                return style_.margin[YGEdge.Start];
            return style_.margin[leading[(int)axis]];
        }

        public YGValue marginTrailingValue(in YGFlexDirection axis)
        {
            if (YGFlexDirectionIsRow(axis) && !style_.margin[YGEdge.End].isUndefined()) 
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

            if (!style_.flex.isUndefined() && style_.flex.unwrap() > 0.0f) 
            {
                return useWebDefaults_ ? YGValue.Auto : YGValue.Zero;
            }
            return YGValue.Auto;
        }

        public void resolveDimension()
        {
            YGStyle style = getStyle();
            foreach (var dim in new[]{YGDimension.Width, YGDimension.Height}) 
            {
                if (!style.maxDimensions[dim].isUndefined() &&
                    YGValueEqual(style.maxDimensions[dim], style.minDimensions[dim])) 
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
        public void replaceChild(YGNodeRef oldChild, YGNodeRef newChild)
        {
            replaceChild(newChild, children_.IndexOf(oldChild));
        }

        public void replaceChild(YGNodeRef child, int index)
        {
            children_[index] = child;
        }

        public void insertChild(YGNodeRef child, int index)
        {
            children_.Insert(index, child);
        }

        /// Removes the first occurrence of child
        public bool removeChild(YGNodeRef child)
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
            if (isDirty_) 
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

            if (!style_.flexGrow.isUndefined()) 
                return style_.flexGrow.unwrap();

            if (!style_.flex.isUndefined() && style_.flex.unwrap() > 0.0f) 
                return style_.flex.unwrap();

            return kDefaultFlexGrow;
        }

        public float resolveFlexShrink()
        {
            if (owner_ == null) 
                return 0.0f;
            
            if (!style_.flexShrink.isUndefined()) 
                return style_.flexShrink.unwrap();

            if (!useWebDefaults_ && !style_.flex.isUndefined() &&
                style_.flex.unwrap() < 0.0f) {
                return -style_.flex.unwrap();
            }
            return useWebDefaults_ ? kWebDefaultFlexShrink : kDefaultFlexShrink;
        }

        public bool isNodeFlexible()
        {
            return (
                (style_.positionType == YGPositionType.Relative) &&
                (resolveFlexGrow() != 0 || resolveFlexShrink() != 0));
        }

        public bool didUseLegacyFlag()
        {
            bool didUseLegacyFlag = layout_.didUseLegacyFlag;
            if (didUseLegacyFlag) 
                return true;
            
            foreach (var child in children_) 
            {
                if (child. layout_.didUseLegacyFlag) 
                {
                    didUseLegacyFlag = true;
                    break;
                }
            }
            return didUseLegacyFlag;
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
            YGNodeRef otherNodeChildren = null;
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
            return new YGNode(getConfig())
            {
                useWebDefaults_ = useWebDefaults_
            };
        }
    }

}