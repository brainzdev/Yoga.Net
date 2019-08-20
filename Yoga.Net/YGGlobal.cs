using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Yoga.Net
{
    public delegate YGSize YGMeasureFunc(
        YGNode node,
        float width,
        YGMeasureMode widthMode,
        float height,
        YGMeasureMode heightMode);
    public delegate float YGBaselineFunc(YGNode node, float width, float height);
    public delegate void YGDirtiedFunc(YGNode node);
    public delegate void YGPrintFunc(YGNode node);
    public delegate void YGNodeCleanupFunc(YGNode node);
    public delegate int YGLogger(
        YGConfig config,
        YGNode node,
        YGLogLevel level,
        string format,
        params object[] args);
    public delegate YGNode YGCloneNodeFunc(YGNode oldNode, YGNode owner, int childIndex);

    internal static class YGGlobal
    {
        // This value was chosen based on empirical data:
        // 98% of analyzed layouts require less than 8 entries.
        public const int YG_MAX_CACHED_RESULT_COUNT = 8;

        public const float kDefaultFlexGrow = 0.0f;
        public const float kDefaultFlexShrink = 0.0f;
        public const float kWebDefaultFlexShrink = 1.0f;

        internal static readonly YGEdge[] leading = {YGEdge.Top, YGEdge.Bottom, YGEdge.Left, YGEdge.Right};
        internal static readonly YGEdge[] trailing = {YGEdge.Bottom, YGEdge.Top, YGEdge.Right, YGEdge.Left};
        internal static readonly YGEdge[] pos = {YGEdge.Top,YGEdge.Bottom,YGEdge.Left,YGEdge.Right};


        public static CompactValue CompactPercent(this float value)
        {
            return CompactValue.of(value, YGUnit.Percent);
        }

        public static CompactValue CompactPoint(this float value)
        {
            return CompactValue.of(value, YGUnit.Point);
        }
    
        public static bool YGValueEqual(in YGValue a, in YGValue b)
        {
            if (a.unit != b.unit) 
                return false;

            if (a.unit == YGUnit.Undefined ||
                (Yoga.isUndefined(a.value) && Yoga.isUndefined(b.value))) 
            {
                return true;
            }

            return Math.Abs(a.value - b.value) < 0.0001f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGValueEqual(
            CompactValue a,
            CompactValue b) 
        {
            return YGValueEqual((YGValue) a, (YGValue) b);
        }

        // This custom float equality function returns true if either absolute
        // difference between two floats is less than 0.0001f or both are undefined.
        public static bool YGFloatsEqual(in float a, in float b)
        {
            if (!Yoga.isUndefined(a) && !Yoga.isUndefined(b)) {
                return Math.Abs(a - b) < float.Epsilon;
            }
            return Yoga.isUndefined(a) && Yoga.isUndefined(b);
        }

        public static float YGFloatMax(in float a, in float b)
        {
            if (!Yoga.isUndefined(a) && !Yoga.isUndefined(b)) {
                return Math.Max(a, b);
            }
            return Yoga.isUndefined(a) ? b : a;
        }

        public static YGFloatOptional YGFloatOptionalMax(
            in YGFloatOptional op1,
            in YGFloatOptional op2)
        {
            if (op1 >= op2) {
                return op1;
            }
            if (op2 > op1) {
                return op2;
            }
            return op1.isUndefined() ? op2 : op1;
        }

        public static float YGFloatMin(in float a, in float b)
        {
            if (!Yoga.isUndefined(a) && !Yoga.isUndefined(b)) {
                return Math.Min(a, b);
            }

            return Yoga.isUndefined(a) ? b : a;
        }

        // This custom float comparison function compares the array of float with
        // YGFloatsEqual, as the default float comparison operator will not work(Look
        // at the comments of YGFloatsEqual function).
        public static bool YGFloatArrayEqual(
            in float[] val1,
            in float[] val2)
        {
            return val1.SequenceEqual(val2);
        }

        // This function returns 0 if YGFloatIsUndefined(val) is true and val otherwise
        public static float YGFloatSanitize(in float val)
        {
            return Yoga.isUndefined(val) ? 0 : val;
        }

        public static YGFlexDirection YGFlexDirectionCross(
            in YGFlexDirection flexDirection,
            in YGDirection direction)
            {
                return YGFlexDirectionIsColumn(flexDirection)
                    ? YGResolveFlexDirection(YGFlexDirection.Row, direction)
                    : YGFlexDirection.Column;
            }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGFlexDirectionIsRow(in YGFlexDirection flexDirection) 
        {
            return flexDirection == YGFlexDirection.Row ||
                flexDirection == YGFlexDirection.RowReverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YGFloatOptional YGResolveValue(
            in YGValue value,
            in float ownerSize) 
        {
            switch (value.unit) {
            case YGUnit.Point:
                return new YGFloatOptional(value.value);
            case YGUnit.Percent:
                return new YGFloatOptional(value.value * ownerSize * 0.01f);
            default:
                return new YGFloatOptional();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YGFloatOptional YGResolveValue(
            CompactValue value,
            float ownerSize) 
        {
            return YGResolveValue((YGValue) value, ownerSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGFlexDirectionIsColumn(in YGFlexDirection flexDirection) 
        {
            return flexDirection == YGFlexDirection.Column ||
                flexDirection == YGFlexDirection.ColumnReverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YGFlexDirection YGResolveFlexDirection(
            in YGFlexDirection flexDirection,
            in YGDirection direction) 
        {
            if (direction == YGDirection.RTL) 
            {
                if (flexDirection == YGFlexDirection.Row) 
                    return YGFlexDirection.RowReverse;

                if (flexDirection == YGFlexDirection.RowReverse) 
                    return YGFlexDirection.Row;
            }

            return flexDirection;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YGFloatOptional YGResolveValueMargin(
            CompactValue value,
            in float ownerSize) 
        {
            return value.IsAuto ? new YGFloatOptional(0) : YGResolveValue(value, ownerSize);
        }

        static YGLogger YGDefaultLog = (config, node, level, format, args) =>
        {
            switch (level)
            {
            case YGLogLevel.Error:
            case YGLogLevel.Fatal:
                Console.Error.Write(format, args);
                break;

            case YGLogLevel.Warn:
            case YGLogLevel.Info:
            case YGLogLevel.Debug:
            case YGLogLevel.Verbose:
            default:
                Console.Write(format, args);
                break;
            }

            return 0;
        };

        static YGConfig defaultConfig = new YGConfig(YGDefaultLog);
        public static YGConfig YGConfigGetDefault() 
        {
            return defaultConfig;
        }

        public static YGNode DefaultYGNode { get; }

        [Obsolete("use node.Children[index]")]
        public static YGNode YGNodeGetChild(YGNode node, int index) => node.Children[index];

        public static CompactValue YGComputedEdgeValue(
            Edges edges,
            YGEdge edge,
            CompactValue defaultValue) 
        {
            if (!edges[edge].isUndefined()) 
            {
                return edges[edge];
            }

            if ((edge == YGEdge.Top || edge == YGEdge.Bottom) &&
                !edges[YGEdge.Vertical].isUndefined()) {
                return edges[YGEdge.Vertical];
            }

            if ((edge == YGEdge.Left || edge == YGEdge.Right || edge == YGEdge.Start ||
                    edge == YGEdge.End) &&
                !edges[YGEdge.Horizontal].isUndefined()) {
                return edges[YGEdge.Horizontal];
            }

            if (!edges[YGEdge.All].isUndefined()) {
                return edges[YGEdge.All];
            }

            if (edge == YGEdge.Start || edge == YGEdge.End) {
                return CompactValue.Undefined;
            }

            return defaultValue;
        }

        public static void YGAssertWithNode(
            YGNode node,
            bool condition,
            string message)
        {
            throw new NotImplementedException();
        }

        public static YGNode YGNodeClone(YGNode node)
        {
            throw new NotImplementedException();
        }
    }
}
