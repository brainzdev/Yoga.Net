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

        /// <inheritdoc />
        public override string ToString() => $"({this[Dimension.Width]}, {this[Dimension.Height]})";
    }

    public class DimensionsFloat
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public DimensionsFloat(float width = float.NaN, float height = float.NaN)
        {
            Width = width;
            Height = height;
        }

        public DimensionsFloat(DimensionsFloat other)
        {
            Width = other.Width;
            Height = other.Height;
        }

        public float this[Dimension dim]
        {
            get
            {
                switch (dim)
                {
                    case Dimension.Width: return Width;
                    case Dimension.Height: return Height;
                }

                throw new ArgumentException("Unknown dimension", nameof(dim));
            }
            set
            {
                switch (dim)
                {
                case Dimension.Width:  
                    Width = value;
                    return;
                case Dimension.Height: 
                    Height = value;
                    return;
                default:
                    throw new ArgumentException("Unknown dimension", nameof(dim));
                }
            }
        }

        /// <inheritdoc />
        public override string ToString() => $"({Width}, {Height})";
    }

}
