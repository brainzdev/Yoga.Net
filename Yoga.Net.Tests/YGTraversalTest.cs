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
            YogaNode root = YGNodeNew();
            YogaNode root_child0 = YGNodeNew();
            YogaNode root_child1 = YGNodeNew();
            YogaNode root_child0_child0 = YGNodeNew();

            YGNodeSetChildren(root, new List<YogaNode> {root_child0, root_child1});
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            List<YogaNode> visited = new List<YogaNode>();
            root.TraversePreOrder(node => visited.Add(node));

            YogaNode[] expected = new YogaNode[]
            {
                root,
                root_child0,
                root_child0_child0,
                root_child1
            };
            Assert.AreEqual(visited, expected);
        }
    }
}
