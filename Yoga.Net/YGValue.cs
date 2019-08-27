using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Yoga.Net
{
    [DebuggerDisplay("{value} {unit}")]
    public class YGValue
    {
        public const float YGUndefined = float.NaN;

        public static YGValue Auto = new YGValue(0f, YGUnit.Auto);
        public static YGValue Undefined = new YGValue(0f, YGUnit.Undefined);
        public static YGValue Zero = new YGValue(0f, YGUnit.Point);

        public readonly float value;
        public readonly YGUnit unit;

        private YGValue() { }

        public YGValue(float value, YGUnit unit)
        {
            this.unit = unit;
            if (unit == YGUnit.Auto || unit == YGUnit.Undefined)
                this.value = YGUndefined;
            else
                this.value = value;
        }

        public bool IsNaN() => float.IsNaN(value);

        public bool Equals(YGValue other)
        {
            if (unit != other.unit)
                return false;

            switch (unit)
            {
            case YGUnit.Undefined:
            case YGUnit.Auto:
                return true;
            case YGUnit.Point:
            case YGUnit.Percent:
                return
                    value.Equals(other.value);
            }

            return false;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            switch (unit)
            {
            case YGUnit.Auto:
                return $"auto";
            case YGUnit.Percent:
                return $"{value}%";
            case YGUnit.Point:
                return $"{value}px";
            case YGUnit.Undefined:
            default:
                return string.Empty;
            }
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is YGValue other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (value.GetHashCode() * 397) ^ (int)unit;
            }
        }

        public static bool operator ==(YGValue left, YGValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(YGValue left, YGValue right)
        {
            return !left.Equals(right);
        }

        public static YGValue operator -(YGValue left)
        {
            return new YGValue(-left.value, left.unit);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator YGValue(int i)
        {
            return new YGValue(i, YGUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator YGValue(short s)
        {
            return new YGValue(s, YGUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator YGValue(float f)
        {
            return new YGValue(f, YGUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator YGValue(double d)
        {
            return new YGValue((float)d, YGUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YGValue Percent(float f)
        {
            return new YGValue(f, YGUnit.Percent);
        }

        public static YGValue Sanitized(float value, YGUnit unit)
        {
            if (float.IsNaN(value))
                return new YGValue(0f, YGUnit.Undefined);
            return new YGValue(value, unit);
        }
    }
}
