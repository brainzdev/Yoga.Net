using System;
using System.Runtime.CompilerServices;

namespace Yoga.Net
{
    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
                originalArray[i] = with;
        }

        public static void Fill<T>(this T[] originalArray, Func<T> action)
        {
            for (int i = 0; i < originalArray.Length; i++)
                originalArray[i] = action();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRow(this FlexDirection flexDirection)
        {
            return flexDirection == FlexDirection.Row || flexDirection == FlexDirection.RowReverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Resolve(this YogaValue value, float ownerSize)
        {
            switch (value.Unit)
            {
            case YogaUnit.Point:
                return value.Value;
            case YogaUnit.Percent:
                return (value.Value * ownerSize * 0.01f);
            default:
                return float.NaN;
            }
        }

        public static FlexDirection CrossAxis(this FlexDirection flexDirection, Direction direction)
        {
            return flexDirection.IsColumn()
                ? FlexDirection.Row.Resolve(direction)
                : FlexDirection.Column;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsColumn(this FlexDirection flexDirection)
        {
            return flexDirection == FlexDirection.Column ||
                flexDirection == FlexDirection.ColumnReverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FlexDirection Resolve(this FlexDirection flexDirection, Direction direction)
        {
            if (direction == Direction.RTL)
            {
                if (flexDirection == FlexDirection.Row)
                    return FlexDirection.RowReverse;

                if (flexDirection == FlexDirection.RowReverse)
                    return FlexDirection.Row;
            }

            return flexDirection;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ResolveValueMargin(this YogaValue value, in float ownerSize)
        {
            return value.IsAuto ? 0f : value.Resolve(ownerSize);
        }
    }
}
