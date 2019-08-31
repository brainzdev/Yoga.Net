using System;

namespace Yoga.Net {
    public class Dimensions : Values<YGDimension>
    {
        public Dimensions() { }
        public Dimensions(YogaValue defaultValue) : base(defaultValue) { }
        public Dimensions(Dimensions other)
        {
            Array.Copy(other._values, _values, _values.Length);
        }
    }
}
