using System.Collections.Generic;

namespace Yoga.Net
{
    public class YGNodes : List<YGNode>
    {
        public YGNodes() { }
        public YGNodes(int capacity): base(capacity) { }
        public YGNodes(IEnumerable<YGNode> collection) : base(collection) { }
    }
}
