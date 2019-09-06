using System.Collections.Generic;

namespace Yoga.Net
{
    public class YogaNodes : List<YogaNode>
    {
        public YogaNodes() { }
        public YogaNodes(int capacity): base(capacity) { }
        public YogaNodes(IEnumerable<YogaNode> collection) : base(collection) { }
    }
}
