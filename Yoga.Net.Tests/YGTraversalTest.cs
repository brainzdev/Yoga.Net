using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


using System.Collections.Generic;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGTraversalTest
    {

        [Test]
        public void pre_order_traversal()
        {
            YGNode root = YGNodeNew();
            YGNode root_child0 = YGNodeNew();
            YGNode root_child1 = YGNodeNew();
            YGNode root_child0_child0 = YGNodeNew();

            YGNodeSetChildren(root, new List<YGNode> { root_child0, root_child1 });
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            List<YGNode> visited = new List<YGNode>();
            YGTraversePreOrder(root, (node) => visited.Add(node));

            YGNode[] expected = new YGNode[] {
                root,
                root_child0,
                root_child0_child0,
                root_child1
            };
            Assert.AreEqual(visited, expected);

            
        }
    }
}
