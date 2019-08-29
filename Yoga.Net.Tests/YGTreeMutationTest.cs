using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;
using System.Collections.Generic;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGTreeMutationTest
    {
        static List<YGNodeRef> getChildren(YGNodeRef node)
        {
            var count = YGNodeGetChildCount(node);
            List<YGNodeRef> children = new List<YGNodeRef>(count);
            for (int i = 0; i < count; i++)
                children.Add(node.Children[i]);
            return children;
        }

        [Test]
        public void set_children_adds_children_to_parent()
        {
            YGNodeRef root = YGNodeNew();
            YGNodeRef root_child0 = YGNodeNew();
            YGNodeRef root_child1 = YGNodeNew();

            YGNodeSetChildren(root, new List<YGNodeRef> { root_child0, root_child1 });

            List<YGNodeRef> children = getChildren(root);
            List<YGNodeRef> expectedChildren = new List<YGNodeRef> { root_child0, root_child1 };
            Assert.AreEqual(children, expectedChildren);

            List<YGNodeRef> owners = new List<YGNodeRef> { YGNodeGetOwner(root_child0), YGNodeGetOwner(root_child1) };
            List<YGNodeRef> expectedOwners = new List<YGNodeRef> { root, root };
            Assert.AreEqual(owners, expectedOwners);

            
        }

        [Test]
        public void set_children_to_empty_removes_old_children()
        {
            YGNodeRef root = YGNodeNew();
            YGNodeRef root_child0 = YGNodeNew();
            YGNodeRef root_child1 = YGNodeNew();

            YGNodeSetChildren(root, new List<YGNodeRef> { root_child0, root_child1 });
            YGNodeSetChildren(root, new List<YGNodeRef> { });

            List<YGNodeRef> children = getChildren(root);
            List<YGNodeRef> expectedChildren = new List<YGNodeRef> { };
            Assert.AreEqual(children, expectedChildren);

            List<YGNodeRef> owners = new List<YGNodeRef> { YGNodeGetOwner(root_child0), YGNodeGetOwner(root_child1) };
            List<YGNodeRef> expectedOwners = new List<YGNodeRef> { null, null };
            Assert.AreEqual(owners, expectedOwners);

            
        }

        [Test]
        public void set_children_replaces_non_common_children()
        {
            YGNodeRef root = YGNodeNew();
            YGNodeRef root_child0 = YGNodeNew();
            YGNodeRef root_child1 = YGNodeNew();
            YGNodeRef root_child2 = YGNodeNew();
            YGNodeRef root_child3 = YGNodeNew();

            root_child0.setLineIndex(0);
            root_child1.setLineIndex(1);
            root_child2.setLineIndex(2);
            root_child3.setLineIndex(3);

            YGNodeSetChildren(root, new List<YGNodeRef> { root_child0, root_child1 });

            YGNodeSetChildren(root, new List<YGNodeRef> { root_child2, root_child3 });

            List<YGNodeRef> children = getChildren(root);
            List<YGNodeRef> expectedChildren = new List<YGNodeRef> { root_child2, root_child3 };
            Assert.AreEqual(children, expectedChildren);

            List<YGNodeRef> owners = new List<YGNodeRef> { YGNodeGetOwner(root_child0), YGNodeGetOwner(root_child1) };
            List<YGNodeRef> expectedOwners = new List<YGNodeRef> { null, null };
            Assert.AreEqual(owners, expectedOwners);

            
        }

        [Test]
        public void set_children_keeps_and_reorders_common_children()
        {
            YGNodeRef root = YGNodeNew();
            YGNodeRef root_child0 = YGNodeNew();
            YGNodeRef root_child1 = YGNodeNew();
            YGNodeRef root_child2 = YGNodeNew();
            YGNodeRef root_child3 = YGNodeNew();

            root_child0.setLineIndex(0);
            root_child1.setLineIndex(1);
            root_child2.setLineIndex(2);
            root_child3.setLineIndex(3);

            YGNodeSetChildren(root, new YGNodeRef[] { root_child0, root_child1, root_child2 });

            YGNodeSetChildren(root, new YGNodeRef[] { root_child2, root_child1, root_child3 });

            List<YGNodeRef> children = getChildren(root);
            List<YGNodeRef> expectedChildren = new List<YGNodeRef> { root_child2, root_child1, root_child3 };
            Assert.AreEqual(children, expectedChildren);

            List<YGNodeRef> owners = new List<YGNodeRef>
            {
                YGNodeGetOwner(root_child0),
                YGNodeGetOwner(root_child1),
                YGNodeGetOwner(root_child2),
                YGNodeGetOwner(root_child3)
            };
            var expectedOwners = new List<YGNodeRef> { null, root, root, root };
            Assert.AreEqual(owners, expectedOwners);

        }
    }
}
