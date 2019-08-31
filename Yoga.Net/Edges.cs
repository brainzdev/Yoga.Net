using System;

namespace Yoga.Net 
{
    public class Edges : Values<YGEdge>
    {
        public Edges() { }
        public Edges(YogaValue defaultValue) : base(defaultValue) { }
        public Edges(Edges other)
        {
            Array.Copy(other._values, _values, _values.Length);
        }

        public CompactValue ComputedEdgeValue(YGEdge edge, CompactValue defaultValue = null)
        {
            if (!this[edge].IsUndefined)
                return this[edge];

            if ((edge == YGEdge.Top || edge == YGEdge.Bottom) && !this[YGEdge.Vertical].IsUndefined)
                return this[YGEdge.Vertical];

            if ((edge == YGEdge.Left || edge == YGEdge.Right || edge == YGEdge.Start || edge == YGEdge.End) && !this[YGEdge.Horizontal].IsUndefined)
                return this[YGEdge.Horizontal];

            if (!this[YGEdge.All].IsUndefined)
                return this[YGEdge.All];

            if (edge == YGEdge.Start || edge == YGEdge.End)
                return CompactValue.Undefined;

            return defaultValue ?? CompactValue.Undefined;
        }
    }
}
