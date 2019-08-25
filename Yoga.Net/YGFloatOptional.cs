using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Yoga.Net
{
    public class YGFloatOptional
    {
        readonly float _value;

        public YGFloatOptional(float value = float.NaN)
        {
            _value = value;
        }

        // returns the wrapped value, or a value x with YGIsUndefined(x) == true
        public float unwrap() => _value;
        public bool isUndefined() => float.IsNaN(_value);


        public bool Equals(YGFloatOptional other)
        {
            return _value.Equals(other._value) ||
                isUndefined() && other.isUndefined();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is YGFloatOptional other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => _value.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(YGFloatOptional left, YGFloatOptional right) => left.Equals(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(YGFloatOptional left, YGFloatOptional right) => !left.Equals(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator==(YGFloatOptional lhs, float rhs) => lhs == new YGFloatOptional(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator!=(YGFloatOptional lhs, float rhs) => !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator==(float lhs, YGFloatOptional rhs) => rhs == lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator!=(float lhs, YGFloatOptional rhs) => !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YGFloatOptional operator+(YGFloatOptional lhs, YGFloatOptional rhs) => new YGFloatOptional( lhs.unwrap() + rhs.unwrap());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator>(YGFloatOptional lhs, YGFloatOptional rhs) => lhs.unwrap() > rhs.unwrap();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator<(YGFloatOptional lhs, YGFloatOptional rhs) => lhs.unwrap() < rhs.unwrap();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator>=(YGFloatOptional lhs, YGFloatOptional rhs) => lhs > rhs || lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator<=(YGFloatOptional lhs, YGFloatOptional rhs) => lhs < rhs || lhs == rhs;
    }
}
