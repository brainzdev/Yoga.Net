using System;
using System.Linq;
using System.Runtime.CompilerServices;
using static Yoga.Net.YogaGlobal;

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
        public static FloatOptional Resolve(this YogaValue value, float ownerSize) 
        {
            switch (value.Unit) {
            case YGUnit.Point:
                return new FloatOptional(value.Value);
            case YGUnit.Percent:
                return new FloatOptional(value.Value * ownerSize * 0.01f);
            default:
                return new FloatOptional();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FloatOptional Resolve(this CompactValue value, float ownerSize) 
        {
            return Resolve((YogaValue) value, ownerSize);
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
        public static FloatOptional ResolveValueMargin(this CompactValue value, in float ownerSize) 
        {
            return value.IsAuto ? new FloatOptional(0) : value.Resolve(ownerSize);
        }
    }

}
