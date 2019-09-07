using System;

namespace Yoga.Net
{
    public interface EdgesReadonly {
        YogaValue ComputedEdgeValue(Edge edge, YogaValue defaultValue = null);
        YogaValue this[Edge i] { get; }
    }

    public class Edges : Values<Edge, YogaValue>, EdgesReadonly
    {
        public Edges(YogaValue defaultValue) : base(defaultValue) { }

        public Edges(Edges other) : base(YogaValue.Undefined)
        {
            Array.Copy(other._values, _values, _values.Length);
        }

        public YogaValue ComputedEdgeValue(Edge edge, YogaValue defaultValue = null)
        {
            if (!this[edge].IsUndefined)
                return this[edge];

            if ((edge == Edge.Top || edge == Edge.Bottom) && !this[Edge.Vertical].IsUndefined)
                return this[Edge.Vertical];

            if ((edge == Edge.Left || edge == Edge.Right || edge == Edge.Start || edge == Edge.End) && !this[Edge.Horizontal].IsUndefined)
                return this[Edge.Horizontal];

            if (!this[Edge.All].IsUndefined)
                return this[Edge.All];

            if (edge == Edge.Start || edge == Edge.End)
                return YogaValue.Undefined;

            return defaultValue ?? YogaValue.Undefined;
        }
    }
}
