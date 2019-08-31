using System;

namespace Yoga.Net
{
    public class Dimensions : Values<Dimension, YogaValue>
    {
        public Dimensions(YogaValue defaultValue) : base(defaultValue) { }

        public Dimensions(Dimensions other) : base(YogaValue.Undefined)
        {
            Array.Copy(other._values, _values, _values.Length);
        }
    }
}
