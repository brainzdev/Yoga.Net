﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Yoga.Net
{
    public static partial class YGGlobal
    {
        // This value was chosen based on empirical data:
        // 98% of analyzed layouts require less than 8 entries.
        public const int YG_MAX_CACHED_RESULT_COUNT = 8;

        public const float kDefaultFlexGrow = 0.0f;
        public const float kDefaultFlexShrink = 0.0f;

        public static CompactValue CompactPercent(this float value)
        {
            return CompactValue.Of(value, YGUnit.Percent);
        }

        public static CompactValue CompactPoint(this float value)
        {
            return CompactValue.Of(value, YGUnit.Point);
        }

        public static bool YGValueEqual(in YGValue a, in YGValue b)
        {
            if (a.unit != b.unit) 
                return false;

            if (a.unit == YGUnit.Undefined ||
                (YogaIsUndefined(a.value) && YogaIsUndefined(b.value))) 
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
            if (!YogaIsUndefined(a) && !YogaIsUndefined(b)) {
                return Math.Abs(a - b) < 0.0001f;
            }
            return YogaIsUndefined(a) && YogaIsUndefined(b);
        }

        public static float YGFloatMax(in float a, in float b)
        {
            if (!YogaIsUndefined(a) && !YogaIsUndefined(b)) {
                return Math.Max(a, b);
            }
            return YogaIsUndefined(a) ? b : a;
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
            return op1.IsUndefined() ? op2 : op1;
        }

        public static float fmodf(float x, float y) => (float) Math.IEEERemainder(x, y);

        public static float YGFloatMin(in float a, in float b)
        {
            if (!YogaIsUndefined(a) && !YogaIsUndefined(b)) {
                return Math.Min(a, b);
            }

            return YogaIsUndefined(a) ? b : a;
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
            return YogaIsUndefined(val) ? 0 : val;
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

        public static YGLoggerFunc YGDefaultLog = (config, node, level, context, message) =>
        {
            Trace.Write(message);
            switch (level)
            {
            case YGLogLevel.Error:
            case YGLogLevel.Fatal:
                Console.Error.Write(message);
                break;

            case YGLogLevel.Warn:
            case YGLogLevel.Info:
            case YGLogLevel.Debug:
            case YGLogLevel.Verbose:
            default:
                    Console.Write(message);
                break;
            }

            return 0;
        };

        static YGConfig defaultConfig = new YGConfig(YGDefaultLog);
        public static YGConfig YGConfigGetDefault() 
        {
            return defaultConfig;
        }

        public static YGNode DefaultYGNode { get; } = new YGNode();

        public static CompactValue YGComputedEdgeValue(
            Edges edges,
            YGEdge edge,
            CompactValue defaultValue) 
        {
            if (!edges[edge].IsUndefined) 
            {
                return edges[edge];
            }

            if ((edge == YGEdge.Top || edge == YGEdge.Bottom) &&
                !edges[YGEdge.Vertical].IsUndefined) {
                return edges[YGEdge.Vertical];
            }

            if ((edge == YGEdge.Left || edge == YGEdge.Right || edge == YGEdge.Start || edge == YGEdge.End) &&
                !edges[YGEdge.Horizontal].IsUndefined) {
                return edges[YGEdge.Horizontal];
            }

            if (!edges[YGEdge.All].IsUndefined) {
                return edges[YGEdge.All];
            }

            if (edge == YGEdge.Start || edge == YGEdge.End) {
                return CompactValue.Undefined;
            }

            return defaultValue;
        }
    }
}
