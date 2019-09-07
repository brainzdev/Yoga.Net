using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Yoga.Net
{
    public static partial class YogaGlobal
    {
        // This value was chosen based on empirical data:
        // 98% of analyzed layouts require less than 8 entries.
        public const int MaxCachedResultCount = 8;

        public const float DefaultFlexGrow = 0.0f;
        public const float DefaultFlexShrink = 0.0f;

        public static bool YogaIsUndefined(float value) => float.IsNaN(value) || float.IsInfinity(value);

        public static bool IsValid(this float value) => !float.IsNaN(value) && !float.IsInfinity(value);

        public static bool IsUndefined(this float value) => float.IsNaN(value) || float.IsInfinity(value);

        public static bool IsZero(this float value) => Math.Abs(value) < 0.0001f;

        public static bool IsNotZero(this float value) => Math.Abs(value) > 0.0001f;

        // This custom float equality function returns true if either absolute
        // difference between two floats is less than 0.0001f or both are undefined.
        public static bool FloatsEqual(float a, float b)
        {
            if (!YogaIsUndefined(a) && !YogaIsUndefined(b))
                return Math.Abs(a - b) < 0.0001f;

            return YogaIsUndefined(a) && YogaIsUndefined(b);
        }

        public static float FloatMax(float a, float b)
        {
            if (!YogaIsUndefined(a) && !YogaIsUndefined(b))
                return Math.Max(a, b);

            return YogaIsUndefined(a) ? b : a;
        }

        public static float FloatMod(float x, float y) => (float)Math.IEEERemainder(x, y);

        public static float FloatMin(float a, float b)
        {
            if (!YogaIsUndefined(a) && !YogaIsUndefined(b))
                return Math.Min(a, b);

            return YogaIsUndefined(a) ? b : a;
        }

        // This custom float comparison function compares the array of float with
        // FloatsEqual, as the default float comparison operator will not work(Look
        // at the comments of FloatsEqual function).
        public static bool FloatArrayEqual(float[] val1, float[] val2) => val1.SequenceEqual(val2);

        // This function returns 0 if YGFloatIsUndefined(val) is true and val otherwise
        public static float FloatSanitize(float val) => YogaIsUndefined(val) ? 0 : val;

        public static YogaNode DefaultYogaNode { get; } = new YogaNode();

        public static object YGNodeGetContext(YogaNode node) => node.Context;

        public static void YGNodeSetContext(YogaNode node, object context) => node.Context = context;

        public static bool YGNodeHasMeasureFunc(YogaNode node) => node.MeasureFunc != null;

        public static void YGNodeSetMeasureFunc(YogaNode node, MeasureFunc measureFunc) => node.MeasureFunc = measureFunc;

        public static bool YGNodeHasBaselineFunc(YogaNode node) => node.BaselineFunc != null;

        public static void YGNodeSetBaselineFunc(YogaNode node, BaselineFunc baselineFunc) => node.BaselineFunc = baselineFunc;

        public static DirtiedFunc YGNodeGetDirtiedFunc(YogaNode node) => node.DirtiedFunc;

        public static void YGNodeSetDirtiedFunc(YogaNode node, DirtiedFunc dirtiedFunc) => node.DirtiedFunc = dirtiedFunc;

        public static void YGNodeSetPrintFunc(YogaNode node, PrintFunc printFunc) => node.PrintFunc = printFunc;

        public static bool YGNodeGetHasNewLayout(YogaNode node) => node.HasNewLayout;

        public static void YGConfigSetPrintTreeFlag(YogaConfig config, bool enabled) => config.PrintTree = enabled;

        public static void YGNodeSetHasNewLayout(YogaNode node, bool hasNewLayout) => node.HasNewLayout = hasNewLayout;

        public static NodeType YGNodeGetNodeType(YogaNode node) => node.NodeType;

        public static void YGNodeSetNodeType(YogaNode node, NodeType nodeType) => node.NodeType = nodeType;

        public static bool YGNodeIsDirty(YogaNode node) => node.IsDirty;

        /// <summary>
        /// Marks the current node and all its descendants as dirty.
        ///
        /// Intended to be used for Uoga benchmarks. Don't use in production, as calling
        /// `YGCalculateLayout` will cause the recalculation of each and every node.
        /// </summary>
        public static void YGNodeMarkDirtyAndPropagateToDescendants(YogaNode node) => node.MarkDirtyAndPropagateDownwards();

        public static YogaNode YGNodeNew() => YGNodeNewWithConfig(YogaConfig.DefaultConfig);

        public static YogaNode YGNodeNewWithConfig(YogaConfig config) => new YogaNode(config);

        public static YogaNode YGNodeClone(YogaNode oldNode) => YogaNode.Clone(oldNode);

        public static YogaConfig YGConfigClone(YogaConfig oldConfig) => new YogaConfig(oldConfig);

        public static YogaNode YGNodeDeepClone(YogaNode oldNode) => YogaNode.DeepClone(oldNode);

        public static void YGNodeReset(YogaNode node) => node.Reset();

        public static YogaConfig YGConfigNew() => new YogaConfig();

        public static void YGConfigCopy(YogaConfig dest, YogaConfig src) => dest.CopyFrom(src);

        public static void YGNodeSetIsReferenceBaseline(YogaNode node, bool isReferenceBaseline) => node.IsReferenceBaseline = isReferenceBaseline;

        public static bool YGNodeIsReferenceBaseline(YogaNode node) => node.IsReferenceBaseline;

        public static void YGNodeInsertChild(YogaNode owner, YogaNode child, int index) => owner.InsertChild(child, index);

        public static void YGNodeRemoveChild(YogaNode owner, YogaNode excludedChild) => owner.RemoveChild(excludedChild);

        public static void YGNodeRemoveAllChildren(YogaNode owner) => owner.RemoveAllChildren();

        public static void YGNodeSetChildren(YogaNode owner, YogaNode[] c, int count) => owner.SetChildren(c.Take(count));

        public static void YGNodeSetChildren(YogaNode owner, IEnumerable<YogaNode> children) => owner.SetChildren(children);

        [Obsolete("use node.Children[index]")]
        public static YogaNode YGNodeGetChild(YogaNode node, int index) => index < node.Children.Count ? node.Children[index] : null;

        public static int YGNodeGetChildCount(YogaNode node) => node.Children.Count;

        public static YogaNode YGNodeGetOwner(YogaNode node) => node.Owner;

        public static YogaNode YGNodeGetParent(YogaNode node) => node.Owner;

        public static void YGNodeMarkDirty(YogaNode node) => node.MarkDirty();

        public static void YGNodeCopyStyle(YogaNode dstNode, YogaNode srcNode) => dstNode.CopyStyle(srcNode);

        public static float YGNodeStyleGetFlexGrow(YogaNode node) => node.StyleFlexGrow;

        public static float YGNodeStyleGetFlexShrink(YogaNode node) => node.StyleFlexShrink;


        public static void YGNodeStyleSetDirection(YogaNode node, Direction value) => node.StyleDirection = value;

        public static Direction YGNodeStyleGetDirection(YogaNode node) => node.StyleDirection;

        public static void YGNodeStyleSetFlexDirection(YogaNode node, FlexDirection flexDirection) => node.StyleFlexDirection = flexDirection;

        public static FlexDirection YGNodeStyleGetFlexDirection(YogaNode node) => node.StyleFlexDirection;

        public static void YGNodeStyleSetJustifyContent(YogaNode node, Justify justifyContent) => node.StyleJustifyContent = justifyContent;

        public static Justify YGNodeStyleGetJustifyContent(YogaNode node) => node.StyleJustifyContent;

        public static void YGNodeStyleSetAlignContent(YogaNode node, YogaAlign alignContent) => node.StyleAlignContent = alignContent;

        public static YogaAlign YGNodeStyleGetAlignContent(YogaNode node) => node.StyleAlignContent;

        public static void YGNodeStyleSetAlignItems(YogaNode node, YogaAlign alignItems) => node.StyleAlignItems =  alignItems;

        public static YogaAlign YGNodeStyleGetAlignItems(YogaNode node) => node.StyleAlignItems;

        public static void YGNodeStyleSetAlignSelf(YogaNode node, YogaAlign alignSelf) => node.StyleAlignSelf = alignSelf;

        public static YogaAlign YGNodeStyleGetAlignSelf(YogaNode node) => node.StyleAlignSelf;

        public static void YGNodeStyleSetPositionType(YogaNode node, PositionType positionType) => node.StylePositionType = positionType;

        public static PositionType YGNodeStyleGetPositionType(YogaNode node) => node.StylePositionType;

        public static void YGNodeStyleSetFlexWrap(YogaNode node, Wrap flexWrap) => node.StyleFlexWrap = flexWrap;

        public static Wrap YGNodeStyleGetFlexWrap(YogaNode node) => node.StyleFlexWrap;

        public static void YGNodeStyleSetOverflow(YogaNode node, Overflow overflow) => node.StyleOverflow = overflow;

        public static Overflow YGNodeStyleGetOverflow(YogaNode node) => node.StyleOverflow;

        public static void YGNodeStyleSetDisplay(YogaNode node, Display display) => node.StyleDisplay = display;

        public static Display YGNodeStyleGetDisplay(YogaNode node) => node.StyleDisplay;

        public static void YGNodeStyleSetFlex(YogaNode node, float flex) => node.StyleFlex = flex;

        public static float YGNodeStyleGetFlex(YogaNode node) => node.StyleFlex;

        public static void YGNodeStyleSetFlexGrow(YogaNode node, float flexGrow) => node.StyleFlexGrow = flexGrow;

        public static void YGNodeStyleSetFlexShrink(YogaNode node, float flexShrink) => node.StyleFlexShrink = flexShrink;

        public static YogaValue YGNodeStyleGetFlexBasis(YogaNode node) => node.StyleFlexBasis;

        public static void YGNodeStyleSetFlexBasis(YogaNode node, float flexBasis) => node.StyleFlexBasis = new YogaValue(flexBasis, YogaUnit.Point);

        public static void YGNodeStyleSetFlexBasisPercent(YogaNode node, float flexBasisPercent)=> node.StyleFlexBasis = new YogaValue(flexBasisPercent, YogaUnit.Percent);

        public static void YGNodeStyleSetFlexBasisAuto(YogaNode node) => node.StyleFlexBasis = YogaValue.Auto;

        public static void YGNodeStyleSetPosition(YogaNode node, Edge edge, float points) => node.StyleSetPosition(edge, new YogaValue(points, YogaUnit.Point));

        public static void YGNodeStyleSetPositionPercent(YogaNode node, Edge edge, float percent)  => node.StyleSetPosition(edge, new YogaValue(percent, YogaUnit.Percent));

        public static YogaValue YGNodeStyleGetPosition(YogaNode node, Edge edge) => node.StyleGetPosition(edge);

        public static void YGNodeStyleSetMargin(YogaNode node, Edge edge, float points) => node.StyleSetMargin(edge, new YogaValue(points, YogaUnit.Point));

        public static void YGNodeStyleSetMarginPercent(YogaNode node, Edge edge, float percent) => node.StyleSetMargin(edge, new YogaValue(percent, YogaUnit.Percent));

        public static void YGNodeStyleSetMarginAuto(YogaNode node, Edge edge)  => node.StyleSetMargin(edge, YogaValue.Auto);

        public static YogaValue YGNodeStyleGetMargin(YogaNode node, Edge edge) => node.StyleGetMargin(edge);

        public static void YGNodeStyleSetPadding(YogaNode node, Edge edge, float points) => node.StyleSetPadding(edge, new YogaValue(points, YogaUnit.Point));

        public static void YGNodeStyleSetPaddingPercent(YogaNode node, Edge edge, float percent) => node.StyleSetPadding(edge, new YogaValue(percent, YogaUnit.Percent));

        public static YogaValue YGNodeStyleGetPadding(YogaNode node, Edge edge) => node.StyleGetPadding(edge);

        public static void YGNodeStyleSetBorder(YogaNode node, Edge edge, float points) => node.StyleSetBorder(edge, new YogaValue(points, YogaUnit.Point));

        public static float YGNodeStyleGetBorder(YogaNode node, Edge edge) => node.StyleGetBorder(edge).Value;

        public static float YGNodeStyleGetAspectRatio(YogaNode node) => node.StyleAspectRatio;

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
        public static void YGNodeStyleSetAspectRatio(YogaNode node, float aspectRatio) => node.StyleAspectRatio = aspectRatio;

        public static void YGNodeStyleSetWidth(YogaNode node, float points) => node.StyleWidth = points.Point();

        public static void YGNodeStyleSetWidthPercent(YogaNode node, float percent) => node.StyleWidth = percent.Percent();

        public static void YGNodeStyleSetWidthAuto(YogaNode node) => node.StyleWidth = YogaValue.Auto;

        public static YogaValue YGNodeStyleGetWidth(YogaNode node) => node.StyleWidth;

        public static void YGNodeStyleSetHeight(YogaNode node, float points) => node.StyleHeight = points.Point();

        public static void YGNodeStyleSetHeightPercent(YogaNode node, float percent) => node.StyleHeight = percent.Percent();

        public static void YGNodeStyleSetHeightAuto(YogaNode node) => node.StyleHeight = YogaValue.Auto;

        public static YogaValue YGNodeStyleGetHeight(YogaNode node) => node.StyleHeight;

        public static void YGNodeStyleSetMinWidth(YogaNode node, float points) => node.StyleMinWidth = points.Point();

        public static void YGNodeStyleSetMinWidthPercent(YogaNode node, float percent) => node.StyleMinWidth = percent.Percent();

        public static YogaValue YGNodeStyleGetMinWidth(YogaNode node) => node.StyleMinWidth;

        public static void YGNodeStyleSetMinHeight(YogaNode node, float points) => node.StyleMinHeight = points.Point();

        public static void YGNodeStyleSetMinHeightPercent(YogaNode node, float percent) => node.StyleMinHeight = percent.Percent();

        public static YogaValue YGNodeStyleGetMinHeight(YogaNode node) => node.StyleMinHeight;

        public static void YGNodeStyleSetMaxWidth(YogaNode node, float points) => node.StyleMaxWidth = points.Point();

        public static void YGNodeStyleSetMaxWidthPercent(YogaNode node, float percent) => node.StyleMaxWidth = percent.Percent();

        public static YogaValue YGNodeStyleGetMaxWidth(YogaNode node) => node.StyleMaxWidth;

        public static void YGNodeStyleSetMaxHeight(YogaNode node, float points) => node.StyleMaxHeight = points.Point();

        public static void YGNodeStyleSetMaxHeightPercent(YogaNode node, float percent)  => node.StyleMaxHeight = percent.Percent();

        public static YogaValue YGNodeStyleGetMaxHeight(YogaNode node) => node.StyleMaxHeight;

        public static float YGNodeLayoutGetLeft(YogaNode node) => node.Layout.Position[(int)Edge.Left];

        public static float YGNodeLayoutGetTop(YogaNode node) => node.Layout.Position[(int)Edge.Top];

        public static float YGNodeLayoutGetRight(YogaNode node) => node.Layout.Position[(int)Edge.Right];

        public static float YGNodeLayoutGetBottom(YogaNode node) => node.Layout.Position[(int)Edge.Bottom];

        public static float YGNodeLayoutGetWidth(YogaNode node) => node.Layout.Width;

        public static float YGNodeLayoutGetHeight(YogaNode node) => node.Layout.Height;

        public static Direction YGNodeLayoutGetDirection(YogaNode node) => node.Layout.Direction;

        public static bool YGNodeLayoutGetHadOverflow(YogaNode node) => node.Layout.HadOverflow;

        // Get the computed values for these nodes after performing layout. If they were
        // set using point values then the returned value will be the same as
        // YGNodeStyleGetXXX. However if they were set using a percentage value then the
        // returned value is the computed value used during layout.
        public static float YGNodeLayoutGetMargin(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Margin, edge);

        public static float YGNodeLayoutGetBorder(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Border, edge);

        public static float YGNodeLayoutGetPadding(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Padding, edge);

        public static float Margin(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Margin, edge);

        public static float Border(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Border, edge);

        public static float Padding(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Padding, edge);

        public static float LayoutResolvedProperty(YogaNode node, LTRBEdge instanceName, Edge edge)
        {
            YGAssertWithNode(node, edge <= Edge.End, "Cannot get layout properties of multi-edge shorthands");
            if (edge == Edge.Start)
            {
                if (node.Layout.Direction == Direction.RTL)
                    return instanceName[(int)Edge.Right];
                return instanceName[(int)Edge.Left];
            }

            if (edge == Edge.End)
            {
                if (node.Layout.Direction == Direction.RTL)
                    return instanceName[(int)Edge.Left];
                return instanceName[(int)Edge.Right];
            }

            return instanceName[(int)edge];
        }
    }
}
