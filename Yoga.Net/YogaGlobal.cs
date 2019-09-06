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

        public static void YGNodeCopyStyle(YogaNode dstNode, YogaNode srcNode) => dstNode.Style = srcNode.Style;

        public static float YGNodeStyleGetFlexGrow(YogaNode node) => node.Style.FlexGrow.IsUndefined() ? DefaultFlexGrow : node.Style.FlexGrow;

        public static float YGNodeStyleGetFlexShrink(YogaNode node) => node.Style.FlexShrink.IsUndefined() ? DefaultFlexShrink : node.Style.FlexShrink;

        public static void UpdateStyle<TEntity, T>(YogaNode node, Expression<Func<TEntity, T>> outExpr, T value) where T : struct
        {
            var expr = (MemberExpression)outExpr.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = (T)prop.GetValue(node.Style);

            if (!EqualityComparer<T>.Default.Equals(propValue, value))
            {
                prop.SetValue(node.Style, value);
                node.MarkDirtyAndPropagate();
            }
        }

        public static void UpdateStyleObject<TEntity, T>(YogaNode node, Expression<Func<TEntity, T>> outExpr, T value) where T : class
        {
            var expr = (MemberExpression)outExpr.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = (T)prop.GetValue(node.Style);

            if (!EqualityComparer<T>.Default.Equals(propValue, value))
            {
                prop.SetValue(node.Style, value);
                node.MarkDirtyAndPropagate();
            }
        }

        public static void UpdateIndexedStyleProp<TKey, TValue>(YogaNode node, Values<TKey, TValue> values, int idx, TValue value) where TKey : struct, IConvertible
        {
            var propValue = values[idx];

            if (!value.Equals(propValue))
            {
                values[idx] = value;
                node.MarkDirtyAndPropagate();
            }
        }

        public static void YGNodeStyleSetDirection(YogaNode node, Direction value) => UpdateStyle<YogaStyle, Direction>(node, s => s.Direction, value);

        public static Direction YGNodeStyleGetDirection(YogaNode node) => node.Style.Direction;

        public static void YGNodeStyleSetFlexDirection(YogaNode node, FlexDirection flexDirection) => UpdateStyle<YogaStyle, FlexDirection>(node, s => s.FlexDirection, flexDirection);

        public static FlexDirection YGNodeStyleGetFlexDirection(YogaNode node) => node.Style.FlexDirection;

        public static void YGNodeStyleSetJustifyContent(YogaNode node, Justify justifyContent) => UpdateStyle<YogaStyle, Justify>(node, s => s.JustifyContent, justifyContent);

        public static Justify YGNodeStyleGetJustifyContent(YogaNode node) => node.Style.JustifyContent;

        public static void YGNodeStyleSetAlignContent(YogaNode node, YogaAlign alignContent) => UpdateStyle<YogaStyle, YogaAlign>(node, s => s.AlignContent, alignContent);

        public static YogaAlign YGNodeStyleGetAlignContent(YogaNode node) => node.Style.AlignContent;

        public static void YGNodeStyleSetAlignItems(YogaNode node, YogaAlign alignItems) => UpdateStyle<YogaStyle, YogaAlign>(node, s => s.AlignItems, alignItems);

        public static YogaAlign YGNodeStyleGetAlignItems(YogaNode node) => node.Style.AlignItems;

        public static void YGNodeStyleSetAlignSelf(YogaNode node, YogaAlign alignSelf) => UpdateStyle<YogaStyle, YogaAlign>(node, s => s.AlignSelf, alignSelf);

        public static YogaAlign YGNodeStyleGetAlignSelf(YogaNode node) => node.Style.AlignSelf;

        public static void YGNodeStyleSetPositionType(YogaNode node, PositionType positionType) => UpdateStyle<YogaStyle, PositionType>(node, s => s.PositionType, positionType);

        public static PositionType YGNodeStyleGetPositionType(YogaNode node) => node.Style.PositionType;

        public static void YGNodeStyleSetFlexWrap(YogaNode node, Wrap flexWrap) => UpdateStyle<YogaStyle, Wrap>(node, s => s.FlexWrap, flexWrap);

        public static Wrap YGNodeStyleGetFlexWrap(YogaNode node) => node.Style.FlexWrap;

        public static void YGNodeStyleSetOverflow(YogaNode node, Overflow overflow) => UpdateStyle<YogaStyle, Overflow>(node, s => s.Overflow, overflow);

        public static Overflow YGNodeStyleGetOverflow(YogaNode node) => node.Style.Overflow;

        public static void YGNodeStyleSetDisplay(YogaNode node, Display display) => UpdateStyle<YogaStyle, Display>(node, s => s.Display, display);

        public static Display YGNodeStyleGetDisplay(YogaNode node) => node.Style.Display;

        public static void YGNodeStyleSetFlex(YogaNode node, float flex) => UpdateStyle<YogaStyle, float>(node, s => s.Flex, flex);

        public static float YGNodeStyleGetFlex(YogaNode node) => node.Style.Flex.IsUndefined() ? YogaValue.YGUndefined : node.Style.Flex;

        public static void YGNodeStyleSetFlexGrow(YogaNode node, float flexGrow) => UpdateStyle<YogaStyle, float>(node, s => s.FlexGrow, flexGrow);

        public static void YGNodeStyleSetFlexShrink(YogaNode node, float flexShrink) => UpdateStyle<YogaStyle, float>(node, s => s.FlexShrink, flexShrink);

        public static YogaValue YGNodeStyleGetFlexBasis(YogaNode node) => node.Style.FlexBasis;

        public static void YGNodeStyleSetFlexBasis(YogaNode node, float flexBasis)
        {
            var value = new YogaValue(flexBasis, YogaUnit.Point);
            UpdateStyleObject<YogaStyle, YogaValue>(node, s => s.FlexBasis, value);
        }

        public static void YGNodeStyleSetFlexBasisPercent(YogaNode node, float flexBasisPercent)
        {
            var value = new YogaValue(flexBasisPercent, YogaUnit.Percent);
            UpdateStyleObject<YogaStyle, YogaValue>(node, s => s.FlexBasis, value);
        }

        public static void YGNodeStyleSetFlexBasisAuto(YogaNode node) => UpdateStyleObject<YogaStyle, YogaValue>(node, s => s.FlexBasis, YogaValue.Auto);

        public static void YGNodeStyleSetPosition(YogaNode node, Edge edge, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.Position, (int)edge, value);
        }

        public static void YGNodeStyleSetPositionPercent(YogaNode node, Edge edge, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            UpdateIndexedStyleProp(node, node.Style.Position, (int)edge, value);
        }

        public static YogaValue YGNodeStyleGetPosition(YogaNode node, Edge edge) => node.Style.Position[edge];

        public static void YGNodeStyleSetMargin(YogaNode node, Edge edge, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.Margin, (int)edge, value);
        }

        public static void YGNodeStyleSetMarginPercent(YogaNode node, Edge edge, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            UpdateIndexedStyleProp(node, node.Style.Margin, (int)edge, value);
        }

        public static void YGNodeStyleSetMarginAuto(YogaNode node, Edge edge) => UpdateIndexedStyleProp(node, node.Style.Margin, (int)edge, YogaValue.Auto);

        public static YogaValue YGNodeStyleGetMargin(YogaNode node, Edge edge) => node.Style.Margin[edge];

        public static void YGNodeStyleSetPadding(YogaNode node, Edge edge, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.Padding, (int)edge, value);
        }

        public static void YGNodeStyleSetPaddingPercent(YogaNode node, Edge edge, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            UpdateIndexedStyleProp(node, node.Style.Padding, (int)edge, value);
        }

        public static YogaValue YGNodeStyleGetPadding(YogaNode node, Edge edge) => node.Style.Padding[edge];

        public static void YGNodeStyleSetBorder(YogaNode node, Edge edge, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.Border, (int)edge, value);
        }

        public static float YGNodeStyleGetBorder(YogaNode node, Edge edge)
        {
            var border = node.Style.Border[edge];
            if (border.IsUndefined || border.IsAuto)
                return YogaValue.YGUndefined;

            return border.Value;
        }

        public static float YGNodeStyleGetAspectRatio(YogaNode node)
        {
            var op = node.Style.AspectRatio;
            return op.IsUndefined() ? YogaValue.YGUndefined : op;
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
        public static void YGNodeStyleSetAspectRatio(YogaNode node, float aspectRatio) => UpdateStyle<YogaStyle, float>(node, s => s.AspectRatio, aspectRatio);

        public static void YGNodeStyleSetWidth(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Width, value);
        }

        public static void YGNodeStyleSetWidthPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            UpdateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Width, value);
        }

        public static void YGNodeStyleSetWidthAuto(YogaNode node) => UpdateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Width, YogaValue.Auto);

        public static YogaValue YGNodeStyleGetWidth(YogaNode node) => node.Style.Dimensions[(int)Dimension.Width];

        public static void YGNodeStyleSetHeight(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Height, value);
        }

        public static void YGNodeStyleSetHeightPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            UpdateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Height, value);
        }

        public static void YGNodeStyleSetHeightAuto(YogaNode node) => UpdateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Height, YogaValue.Auto);

        public static YogaValue YGNodeStyleGetHeight(YogaNode node) => node.Style.Dimensions[(int)Dimension.Height];

        public static void YGNodeStyleSetMinWidth(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.MinDimensions, (int)Dimension.Width, value);
        }

        public static void YGNodeStyleSetMinWidthPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            UpdateIndexedStyleProp(node, node.Style.MinDimensions, (int)Dimension.Width, value);
        }

        public static YogaValue YGNodeStyleGetMinWidth(YogaNode node) => node.Style.MinDimensions[(int)Dimension.Width];

        public static void YGNodeStyleSetMinHeight(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.MinDimensions, (int)Dimension.Height, value);
        }

        public static void YGNodeStyleSetMinHeightPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            UpdateIndexedStyleProp(node, node.Style.MinDimensions, (int)Dimension.Height, value);
        }

        public static YogaValue YGNodeStyleGetMinHeight(YogaNode node) => node.Style.MinDimensions[(int)Dimension.Height];

        public static void YGNodeStyleSetMaxWidth(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.MaxDimensions, (int)Dimension.Width, value);
        }

        public static void YGNodeStyleSetMaxWidthPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            UpdateIndexedStyleProp(node, node.Style.MaxDimensions, (int)Dimension.Width, value);
        }

        public static YogaValue YGNodeStyleGetMaxWidth(YogaNode node) => node.Style.MaxDimensions[(int)Dimension.Width];

        public static void YGNodeStyleSetMaxHeight(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            UpdateIndexedStyleProp(node, node.Style.MaxDimensions, (int)Dimension.Height, value);
        }

        public static void YGNodeStyleSetMaxHeightPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            UpdateIndexedStyleProp(node, node.Style.MaxDimensions, (int)Dimension.Height, value);
        }

        public static YogaValue YGNodeStyleGetMaxHeight(YogaNode node) => node.Style.MaxDimensions[(int)Dimension.Height];

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
