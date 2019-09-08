using System;
using static Yoga.Net.YogaMath;

namespace Yoga.Net 
{
    public interface LTRBEdgeReadonly 
    {
        float this[Edge i] { get; }
    }

    /// <summary>
    /// Left Top Right Bottom edges
    /// </summary>
    public class LTRBEdge : Values<Edge, float>, LTRBEdgeReadonly
    {
        public LTRBEdge(float defaultValue = default) : base(defaultValue) { }

        public LTRBEdge(LTRBEdge other) : base(float.NaN)
        {
            Array.Copy(other._values, _values, _values.Length);
        }

        public bool IsZero =>
            this[0].IsZero() &&
            FloatsEqual(this[0], this[1]) &&
            FloatsEqual(this[0], this[2]) &&
            FloatsEqual(this[0], this[3]);

        public new float this[Edge edge]
        {
            get => _values[(int)edge];
            set => _values[(int)edge] = value;
        }

        /// <inheritdoc />
        public override string ToString() => $"({this[Edge.Left]}, {this[Edge.Top]}, {this[Edge.Right]}, {this[Edge.Bottom]})";
    }
}
