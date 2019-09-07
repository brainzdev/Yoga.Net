using NUnit.Framework;
using System.Collections.Generic;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaTreeMutationTest
    {
        static List<YogaNode> getChildren(YogaNode node)
        {
            var count = YGNodeGetChildCount(node);
            List<YogaNode> children = new List<YogaNode>(count);
            for (int i = 0; i < count; i++)
                children.Add(node.Children[i]);
            return children;
        }

        [Test]
        public void set_children_adds_children_to_parent()
        {
            YogaNode root = YGNodeNew();
            YogaNode root_child0 = YGNodeNew();
            YogaNode root_child1 = YGNodeNew();

            YGNodeSetChildren(root, new List<YogaNode> {root_child0, root_child1});

            List<YogaNode> children = getChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> {root_child0, root_child1};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {YGNodeGetOwner(root_child0), YGNodeGetOwner(root_child1)};
            List<YogaNode> expectedOwners = new List<YogaNode> {root, root};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_to_empty_removes_old_children()
        {
            YogaNode root = YGNodeNew();
            YogaNode root_child0 = YGNodeNew();
            YogaNode root_child1 = YGNodeNew();

            YGNodeSetChildren(root, new List<YogaNode> {root_child0, root_child1});
            YGNodeSetChildren(root, new List<YogaNode> { });

            List<YogaNode> children = getChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> { };
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {YGNodeGetOwner(root_child0), YGNodeGetOwner(root_child1)};
            List<YogaNode> expectedOwners = new List<YogaNode> {null, null};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_replaces_non_common_children()
        {
            YogaNode root = YGNodeNew();
            YogaNode root_child0 = YGNodeNew();
            YogaNode root_child1 = YGNodeNew();
            YogaNode root_child2 = YGNodeNew();
            YogaNode root_child3 = YGNodeNew();

            root_child0.LineIndex = 0;
            root_child1.LineIndex = 1;
            root_child2.LineIndex = 2;
            root_child3.LineIndex = 3;

            YGNodeSetChildren(root, new List<YogaNode> {root_child0, root_child1});

            YGNodeSetChildren(root, new List<YogaNode> {root_child2, root_child3});

            List<YogaNode> children = getChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> {root_child2, root_child3};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {YGNodeGetOwner(root_child0), YGNodeGetOwner(root_child1)};
            List<YogaNode> expectedOwners = new List<YogaNode> {null, null};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_keeps_and_reorders_common_children()
        {
            YogaNode root = YGNodeNew();
            YogaNode root_child0 = YGNodeNew();
            YogaNode root_child1 = YGNodeNew();
            YogaNode root_child2 = YGNodeNew();
            YogaNode root_child3 = YGNodeNew();

            root_child0.LineIndex = 0;
            root_child1.LineIndex = 1;
            root_child2.LineIndex = 2;
            root_child3.LineIndex = 3;

            YGNodeSetChildren(root, new YogaNode[] {root_child0, root_child1, root_child2});

            YGNodeSetChildren(root, new YogaNode[] {root_child2, root_child1, root_child3});

            List<YogaNode> children = getChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> {root_child2, root_child1, root_child3};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode>
            {
                YGNodeGetOwner(root_child0),
                YGNodeGetOwner(root_child1),
                YGNodeGetOwner(root_child2),
                YGNodeGetOwner(root_child3)
            };
            var expectedOwners = new List<YogaNode> {null, root, root, root};
            Assert.AreEqual(owners, expectedOwners);
        }
    }
}
