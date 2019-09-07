using System;

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

        public new float this[Edge edge]
        {
            get => _values[GetIndex(edge)];
            set => _values[GetIndex(edge)] = value;
        }

        int GetIndex(Edge edge)
        {
            switch (edge)
            {
            case Edge.Left:   return 0;
            case Edge.Top:    return 1;
            case Edge.Right:  return 2;
            case Edge.Bottom: return 3;
            default:
                throw new IndexOutOfRangeException();
            }
        }
    }
}
