using NUnit.Framework;
using System.Collections.Generic;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaTreeMutationTest
    {
        static List<YogaNode> getChildren(YogaNode node)
        {
            var count = node.ChildCount;
            List<YogaNode> children = new List<YogaNode>(count);
            for (int i = 0; i < count; i++)
                children.Add(node.Children[i]);
            return children;
        }

        [Test]
        public void set_children_adds_children_to_parent()
        {
            YogaNode root = new YogaNode();
            YogaNode root_child0 = new YogaNode();
            YogaNode root_child1 = new YogaNode();

            root.SetChildren(new List<YogaNode> {root_child0, root_child1});

            List<YogaNode> children = getChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> {root_child0, root_child1};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {root_child0.Owner, root_child1.Owner};
            List<YogaNode> expectedOwners = new List<YogaNode> {root, root};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_to_empty_removes_old_children()
        {
            YogaNode root = new YogaNode();
            YogaNode root_child0 = new YogaNode();
            YogaNode root_child1 = new YogaNode();

            root.SetChildren(new List<YogaNode> {root_child0, root_child1});
            root.SetChildren(new List<YogaNode> { });

            List<YogaNode> children = getChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> { };
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {root_child0.Owner, root_child1.Owner};
            List<YogaNode> expectedOwners = new List<YogaNode> {null, null};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_replaces_non_common_children()
        {
            YogaNode root = new YogaNode();
            YogaNode root_child0 = new YogaNode();
            YogaNode root_child1 = new YogaNode();
            YogaNode root_child2 = new YogaNode();
            YogaNode root_child3 = new YogaNode();

            root_child0.LineIndex = 0;
            root_child1.LineIndex = 1;
            root_child2.LineIndex = 2;
            root_child3.LineIndex = 3;

            root.SetChildren(new List<YogaNode> {root_child0, root_child1});

            root.SetChildren(new List<YogaNode> {root_child2, root_child3});

            List<YogaNode> children = getChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> {root_child2, root_child3};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {root_child0.Owner, root_child1.Owner};
            List<YogaNode> expectedOwners = new List<YogaNode> {null, null};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_keeps_and_reorders_common_children()
        {
            YogaNode root = new YogaNode();
            YogaNode root_child0 = new YogaNode();
            YogaNode root_child1 = new YogaNode();
            YogaNode root_child2 = new YogaNode();
            YogaNode root_child3 = new YogaNode();

            root_child0.LineIndex = 0;
            root_child1.LineIndex = 1;
            root_child2.LineIndex = 2;
            root_child3.LineIndex = 3;

            root.SetChildren(new YogaNode[] {root_child0, root_child1, root_child2});

            root.SetChildren(new YogaNode[] {root_child2, root_child1, root_child3});

            List<YogaNode> children = getChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> {root_child2, root_child1, root_child3};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode>
            {
                root_child0.Owner,
                root_child1.Owner,
                root_child2.Owner,
                root_child3.Owner
            };
            var expectedOwners = new List<YogaNode> {null, root, root, root};
            Assert.AreEqual(owners, expectedOwners);
        }
    }
}
