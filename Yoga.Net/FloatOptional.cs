using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using JetBrains.Annotations;

namespace Yoga.Net
{
    public class FloatOptional
    {
        readonly float _value;

        public FloatOptional(float value = float.NaN)
        {
            _value = value;
        }

        // returns the wrapped value, or a value x with YGIsUndefined(x) == true
        public float Unwrap() => _value;
        public bool IsUndefined() => float.IsNaN(_value);

        public bool Equals([CanBeNull] FloatOptional other)
        {
            return _value.Equals(other._value) ||
                IsUndefined() && other.IsUndefined();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is FloatOptional other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => _value.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==([NotNull] FloatOptional lhs, FloatOptional rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=([NotNull] FloatOptional lhs, FloatOptional rhs) => !lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==([NotNull] FloatOptional lhs, float rhs) => lhs == new FloatOptional(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=([NotNull] FloatOptional lhs, float rhs) => !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float lhs, FloatOptional rhs) => rhs == lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float lhs, FloatOptional rhs) => !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FloatOptional operator +([NotNull] FloatOptional lhs, FloatOptional rhs) => new FloatOptional(lhs.Unwrap() + rhs.Unwrap());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >([NotNull] FloatOptional lhs, FloatOptional rhs) => lhs.Unwrap() > rhs.Unwrap();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <([NotNull] FloatOptional lhs, FloatOptional rhs) => lhs.Unwrap() < rhs.Unwrap();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=([NotNull] FloatOptional lhs, FloatOptional rhs) => lhs > rhs || lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=([NotNull] FloatOptional lhs, FloatOptional rhs) => lhs < rhs || lhs == rhs;

        public static FloatOptional Max(FloatOptional lhs, FloatOptional rhs)
        {
            if (lhs >= rhs)
                return lhs;

            if (rhs > lhs)
                return rhs;

            return lhs.IsUndefined() ? rhs : lhs;
        }

    }
}
