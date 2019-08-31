using System;
using System.Linq;
using System.Runtime.CompilerServices;
using static Yoga.Net.YGGlobal;

namespace Yoga.Net
{
    public static class ArrayExtensions 
    {
        public static void Fill<T>(this T[] originalArray, T with) 
        {
            for(int i = 0; i < originalArray.Length; i++)
                originalArray[i] = with;
        }  

        public static void Fill<T>(this T[] originalArray, Func<T> action) 
        {
            for(int i = 0; i < originalArray.Length; i++)
                originalArray[i] = action();
        }  

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRow(this YGFlexDirection flexDirection) 
        {
            return flexDirection == YGFlexDirection.Row || flexDirection == YGFlexDirection.RowReverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YGFloatOptional Resolve(this YGValue value, float ownerSize) 
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
        public static YGFloatOptional Resolve(this CompactValue value, float ownerSize) 
        {
            return Resolve((YGValue) value, ownerSize);
        }

        public static YGFlexDirection CrossAxis(this YGFlexDirection flexDirection, YGDirection direction)
        {
            return flexDirection.IsColumn()
                ? YGFlexDirection.Row.Resolve(direction)
                : YGFlexDirection.Column;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsColumn(this YGFlexDirection flexDirection) 
        {
            return flexDirection == YGFlexDirection.Column ||
                flexDirection == YGFlexDirection.ColumnReverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YGFlexDirection Resolve(this YGFlexDirection flexDirection, YGDirection direction) 
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
        public static YGFloatOptional ResolveValueMargin(this CompactValue value, in float ownerSize) 
        {
            return value.IsAuto ? new YGFloatOptional(0) : value.Resolve(ownerSize);
        }
    }

}
