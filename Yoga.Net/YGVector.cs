using System.Collections.Generic;

namespace Yoga.Net
{
    public class YGVector : List<YGNode>
    {
        public YGVector() { }
        public YGVector(IEnumerable<YGNode> collection) : base(collection) { }
    }
}
