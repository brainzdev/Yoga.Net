using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
// ReSharper disable RedundantCaseLabel

namespace Yoga.Net
{
    [DebuggerDisplay("{Value} {Unit}")]
    public class YogaValue
    {
        public const float YGUndefined = float.NaN;

        public static readonly YogaValue Auto = new YogaValue(0f, YGUnit.Auto);
        public static readonly YogaValue Undefined = new YogaValue(0f, YGUnit.Undefined);
        public static readonly YogaValue Zero = new YogaValue(0f, YGUnit.Point);

        public readonly float Value;
        public readonly YGUnit Unit;

        public YogaValue(float value, YGUnit unit)
        {
            Unit = unit;
            Value = (unit == YGUnit.Auto || unit == YGUnit.Undefined) ? YGUndefined : value;
        }

        public bool IsNaN() => float.IsNaN(Value);

        public bool Equals(YogaValue other)
        {
            if (Unit != other.Unit)
                return false;

            switch (Unit)
            {
            case YGUnit.Undefined:
            case YGUnit.Auto:
                return true;
            case YGUnit.Point:
            case YGUnit.Percent:
                return
                    Value.Equals(other.Value);
            }

            return false;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            switch (Unit)
            {
            case YGUnit.Auto:
                return $"auto";
            case YGUnit.Percent:
                return $"{Value}%";
            case YGUnit.Point:
                return $"{Value}px";
            case YGUnit.Undefined:
            default:
                return string.Empty;
            }
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is YogaValue other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ (int)Unit;
            }
        }

        public static bool operator ==([NotNull] YogaValue left, YogaValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=([NotNull] YogaValue left, YogaValue right)
        {
            return !left.Equals(right);
        }

        public static YogaValue operator -([NotNull] YogaValue left)
        {
            return new YogaValue(-left.Value, left.Unit);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator YogaValue(int i)
        {
            return new YogaValue(i, YGUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator YogaValue(short s)
        {
            return new YogaValue(s, YGUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator YogaValue(float f)
        {
            return new YogaValue(f, YGUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator YogaValue(double d)
        {
            return new YogaValue((float)d, YGUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YogaValue Percent(float f)
        {
            return new YogaValue(f, YGUnit.Percent);
        }

        public static YogaValue Sanitized(float value, YGUnit unit)
        {
            if (float.IsNaN(value))
                return new YogaValue(0f, YGUnit.Undefined);
            return new YogaValue(value, unit);
        }
    }
}
