using System;
using System.Runtime.InteropServices;
using uint32_t = System.UInt32;

namespace Yoga.Net
{
    // This class stores YGValue in 32 bits.
    // - The value does not matter for Undefined and Auto. NaNs are used for their
    //   representation.
    // - To differentiate between Point and Percent, one exponent bit is used.
    //   Supported the range [0x40, 0xbf] (0xbf is inclusive for point, but
    //   exclusive for percent).
    // - Value ranges:
    //   points:  1.08420217e-19f to 36893485948395847680
    //            0x00000000         0x3fffffff
    //   percent: 1.08420217e-19f to 18446742974197923840
    //            0x40000000         0x7f7fffff
    // - Zero is supported, negative zero is not
    // - values outside of the representable range are clamped
    public class CompactValue
    {
        const float LOWER_BOUND = 1.08420217e-19f;
        const float UPPER_BOUND_POINT = 36893485948395847680.0f;
        const float UPPER_BOUND_PERCENT = 18446742974197923840.0f;

        // these are signaling NaNs with specific bit pattern as payload they will be
        // silenced whenever going through an FPU operation on ARM + x86
        const int AUTO_BITS = 0x7faaaaaa;
        const int ZERO_BITS_POINT = 0x7f8f0f0f;
        const int ZERO_BITS_PERCENT = 0x7f80f0f0;

        const int BIAS = 0x20000000;
        const int PERCENT_BIT = 0x40000000;

        public static CompactValue Auto = new CompactValue(AUTO_BITS);
        public static CompactValue Undefined = new CompactValue(float.NaN);
        public static CompactValue Zero = new CompactValue(ZERO_BITS_POINT);

        [StructLayout(LayoutKind.Explicit)]
        struct Payload
        {
            [FieldOffset(0)] public float value;

            [FieldOffset(0)] public int repr;

            public Payload(int r) : this() => repr = r;
            public Payload(float v) : this() => value = v;
        }

        readonly Payload _payload;

        CompactValue()
        {
            _payload.value = float.NaN;
        }

        CompactValue(float value)
        {
            _payload.value = value;
        }

        CompactValue(Payload payload)
        {
            _payload = payload;
        }

        public static CompactValue of(float value, YGUnit unit) => new CompactValue(Build(value, unit));

        public float value => _payload.value;

        static Payload Build(float value, YGUnit unit)
        {
            if (Math.Abs(value) < float.Epsilon || (value < LOWER_BOUND && value > -LOWER_BOUND))
            {
                var zero = unit == YGUnit.Percent ? ZERO_BITS_PERCENT : ZERO_BITS_POINT;
                return new Payload(zero);
            }

            var upperBound = unit == YGUnit.Percent ? UPPER_BOUND_PERCENT : UPPER_BOUND_POINT;
            if (value > upperBound)
                value = upperBound;
            else if (value < -upperBound)
                value = -upperBound;

            int unitBit = unit == YGUnit.Percent ? PERCENT_BIT : 0;
            var data = new Payload(value);
            data.repr -= BIAS;
            data.repr |= unitBit;
            return data;
        }

        public static CompactValue ofMaybe(float value, YGUnit unit)
        {
            if (float.IsNaN(value) || float.IsInfinity(value))
                return Undefined;
            return of(value, unit);
        }

        public CompactValue(YGValue x)
        {
            _payload.repr = 0;
            switch (x.unit)
            {
            case YGUnit.Undefined:
                _payload.value = Undefined._payload.value;
                break;
            case YGUnit.Auto:
                _payload.value = Auto._payload.value;
                break;
            case YGUnit.Point:
            case YGUnit.Percent:
                _payload = Build(x.value, x.unit);
                break;
            }
        }

        public static implicit operator YGValue(CompactValue cv)
        {
            switch (cv._payload.repr)
            {
            case AUTO_BITS:
                return YGValue.Auto;
            case ZERO_BITS_POINT:
                return of(0f, YGUnit.Point);
            case ZERO_BITS_PERCENT:
                return of(0f, YGUnit.Percent);
            }

            if (float.IsNaN(cv._payload.value))
            {
                return YGValue.Undefined;
            }

            var data = cv._payload;
            data.repr &= ~PERCENT_BIT;
            data.repr += BIAS;

            return new YGValue(
                data.value,
                ((cv._payload.repr & 0x40000000) == 0x40000000) ? YGUnit.Percent : YGUnit.Point);
        }

        public bool IsUndefined =>
            _payload.repr != AUTO_BITS &&
            _payload.repr != ZERO_BITS_POINT &&
            _payload.repr != ZERO_BITS_PERCENT &&
            float.IsNaN(_payload.value);

        public bool isUndefined() => IsUndefined;

        public bool IsAuto => _payload.repr == AUTO_BITS;

        protected bool Equals(CompactValue other)
        {
            return _payload.repr == other._payload.repr;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CompactValue)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return _payload.repr.GetHashCode();
        }

        public static bool operator ==(CompactValue left, CompactValue right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CompactValue left, CompactValue right)
        {
            return !Equals(left, right);
        }
    }
}
