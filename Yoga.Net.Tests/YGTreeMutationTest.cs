using NUnit.Framework;
using static Yoga.Net.YGGlobal;


using System.Collections.Generic;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGTreeMutationTest
    {
        static List<YGNode> getChildren(YGNode node)
        {
            var count = YGNodeGetChildCount(node);
            List<YGNode> children = new List<YGNode>(count);
            for (int i = 0; i < count; i++)
                children.Add(node.Children[i]);
            return children;
        }

        [Test]
        public void set_children_adds_children_to_parent()
        {
            YGNode root = YGNodeNew();
            YGNode root_child0 = YGNodeNew();
            YGNode root_child1 = YGNodeNew();

            YGNodeSetChildren(root, new List<YGNode> { root_child0, root_child1 });

            List<YGNode> children = getChildren(root);
            List<YGNode> expectedChildren = new List<YGNode> { root_child0, root_child1 };
            Assert.AreEqual(children, expectedChildren);

            List<YGNode> owners = new List<YGNode> { YGNodeGetOwner(root_child0), YGNodeGetOwner(root_child1) };
            List<YGNode> expectedOwners = new List<YGNode> { root, root };
            Assert.AreEqual(owners, expectedOwners);

            
        }

        [Test]
        public void set_children_to_empty_removes_old_children()
        {
            YGNode root = YGNodeNew();
            YGNode root_child0 = YGNodeNew();
            YGNode root_child1 = YGNodeNew();

            YGNodeSetChildren(root, new List<YGNode> { root_child0, root_child1 });
            YGNodeSetChildren(root, new List<YGNode> { });

            List<YGNode> children = getChildren(root);
            List<YGNode> expectedChildren = new List<YGNode> { };
            Assert.AreEqual(children, expectedChildren);

            List<YGNode> owners = new List<YGNode> { YGNodeGetOwner(root_child0), YGNodeGetOwner(root_child1) };
            List<YGNode> expectedOwners = new List<YGNode> { null, null };
            Assert.AreEqual(owners, expectedOwners);

            
        }

        [Test]
        public void set_children_replaces_non_common_children()
        {
            YGNode root = YGNodeNew();
            YGNode root_child0 = YGNodeNew();
            YGNode root_child1 = YGNodeNew();
            YGNode root_child2 = YGNodeNew();
            YGNode root_child3 = YGNodeNew();

            root_child0.setLineIndex(0);
            root_child1.setLineIndex(1);
            root_child2.setLineIndex(2);
            root_child3.setLineIndex(3);

            YGNodeSetChildren(root, new List<YGNode> { root_child0, root_child1 });

            YGNodeSetChildren(root, new List<YGNode> { root_child2, root_child3 });

            List<YGNode> children = getChildren(root);
            List<YGNode> expectedChildren = new List<YGNode> { root_child2, root_child3 };
            Assert.AreEqual(children, expectedChildren);

            List<YGNode> owners = new List<YGNode> { YGNodeGetOwner(root_child0), YGNodeGetOwner(root_child1) };
            List<YGNode> expectedOwners = new List<YGNode> { null, null };
            Assert.AreEqual(owners, expectedOwners);

            
        }

        [Test]
        public void set_children_keeps_and_reorders_common_children()
        {
            YGNode root = YGNodeNew();
            YGNode root_child0 = YGNodeNew();
            YGNode root_child1 = YGNodeNew();
            YGNode root_child2 = YGNodeNew();
            YGNode root_child3 = YGNodeNew();

            root_child0.setLineIndex(0);
            root_child1.setLineIndex(1);
            root_child2.setLineIndex(2);
            root_child3.setLineIndex(3);

            YGNodeSetChildren(root, new YGNode[] { root_child0, root_child1, root_child2 });

            YGNodeSetChildren(root, new YGNode[] { root_child2, root_child1, root_child3 });

            List<YGNode> children = getChildren(root);
            List<YGNode> expectedChildren = new List<YGNode> { root_child2, root_child1, root_child3 };
            Assert.AreEqual(children, expectedChildren);

            List<YGNode> owners = new List<YGNode>
            {
                YGNodeGetOwner(root_child0),
                YGNodeGetOwner(root_child1),
                YGNodeGetOwner(root_child2),
                YGNodeGetOwner(root_child3)
            };
            var expectedOwners = new List<YGNode> { null, root, root, root };
            Assert.AreEqual(owners, expectedOwners);

        }
    }
}
