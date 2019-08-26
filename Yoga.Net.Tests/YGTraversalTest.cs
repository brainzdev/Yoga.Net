using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;
using System.Collections.Generic;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGTraversalTest
    {

        [Test]
        public void pre_order_traversal()
        {
            YGNodeRef root = YGNodeNew();
            YGNodeRef root_child0 = YGNodeNew();
            YGNodeRef root_child1 = YGNodeNew();
            YGNodeRef root_child0_child0 = YGNodeNew();

            YGNodeSetChildren(root, new List<YGNode> { root_child0, root_child1 });
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            List<YGNodeRef> visited = new List<YGNodeRef>();
            YGTraversePreOrder(root, (node) => visited.Add(node));

            YGNodeRef[] expected = new YGNodeRef[] {
                root,
                root_child0,
                root_child0_child0,
                root_child1
            };
            Assert.AreEqual(visited, expected);

            YGNodeFreeRecursive(root);
        }
    }
}
