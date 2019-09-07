using System;

namespace Yoga.Net
{
    public interface DimensionsReadonly 
    {
        YogaValue this[Dimension i] { get; }
    }

    public class Dimensions : Values<Dimension, YogaValue>, DimensionsReadonly
    {
        public Dimensions(YogaValue defaultValue) : base(defaultValue) { }

        public Dimensions(Dimensions other) : base(YogaValue.Undefined)
        {
            Array.Copy(other._values, _values, _values.Length);
        }
    }

    public class DimensionsFloat : Values<Dimension, float>
    {
        public DimensionsFloat(float defaultValue) : base(defaultValue) { }

        public DimensionsFloat(DimensionsFloat other) : base(float.NaN)
        {
            Array.Copy(other._values, _values, _values.Length);
        }
    }

}
