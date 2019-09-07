using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Yoga.Net
{
    public static partial class YogaGlobal
    {
        // This value was chosen based on empirical data:
        // 98% of analyzed layouts require less than 8 entries.
        public const int MaxCachedResultCount = 8;

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
        public static float YGNodeLayoutGetMargin(YogaNode node, Edge edge) => node.LayoutMargin(edge);

        public static float YGNodeLayoutGetBorder(YogaNode node, Edge edge) => node.LayoutBorder(edge);

        public static float YGNodeLayoutGetPadding(YogaNode node, Edge edge) => node.LayoutPadding(edge);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YGNodePaddingAndBorderForAxis(YogaNode node, FlexDirection axis, float widthSize) => node.PaddingAndBorderForAxis(axis, widthSize);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YogaAlign YGNodeAlignItem(YogaNode node, YogaNode child) => node.AlignItem(child);

        public static float YGBaseline(YogaNode node, object layoutContext) => node.Baseline(layoutContext);

        public static bool YGIsBaselineLayout(YogaNode node) => node.IsBaselineLayout();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YGNodeDimWithMargin(YogaNode node, FlexDirection axis, float widthSize) => node.DimWithMargin(axis, widthSize);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGNodeIsStyleDimDefined(YogaNode node, FlexDirection axis, float ownerSize) => node.IsStyleDimDefined(axis, ownerSize);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGNodeIsLayoutDimDefined(YogaNode node, FlexDirection axis) => node.IsLayoutDimDefined(axis);

        public static float YGNodeBoundAxisWithinMinAndMax(YogaNode node, FlexDirection axis, float value, float axisSize) => node.BoundAxisWithinMinAndMax(axis, value, axisSize);
       

        // Like YGNodeBoundAxisWithinMinAndMax but also ensures that the value doesn't go below the padding and border amount.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YGNodeBoundAxis(YogaNode node, FlexDirection axis, float value, float axisSize, float widthSize) => node.BoundAxis(axis, value, axisSize, widthSize);

        public static void YGNodeSetChildTrailingPosition(YogaNode node, YogaNode child, FlexDirection axis) => node.SetChildTrailingPosition(child, axis);

        public static void YGConstrainMaxSizeForMode(YogaNode node, FlexDirection axis, float ownerAxisSize, float ownerWidth, ref MeasureMode mode, ref float size) => node.ConstrainMaxSizeForMode(axis, ownerAxisSize, ownerWidth, ref mode, ref size);


        public static void YGConfigSetExperimentalFeatureEnabled(YogaConfig config,ExperimentalFeature feature,bool enabled) => config.ExperimentalFeatures[(int)feature] = enabled;

        public static void YGConfigSetLogger(YogaConfig config, LoggerFunc logger) => config.LoggerFunc = logger;

        [Conditional("DEBUG")]
        public static void YGNodePrint(YogaNode node, PrintOptions options) => Logger.Log(node, LogLevel.Debug, new YogaNodePrint(options).Output(node).ToString());

        public static void YGConfigSetPointScaleFactor(YogaConfig config,float pixelsInPoint) => config.PointScaleFactor = pixelsInPoint.IsZero() ? 0.0f : pixelsInPoint;

    }
}
