using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaDirtiedTest
    {
        static void _dirtied(YogaNode node)
        {
            int dirtiedCount = (int)node.Context;
            dirtiedCount++;
            node.Context = dirtiedCount;
        }

        [Test]
        public void dirtied()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            //int dirtiedCount = 0;
            root.Context = 0;
            root.DirtiedFunc = _dirtied;

            Assert.AreEqual(0, (int)root.Context);

            // `_dirtied` MUST be called in case of explicit dirtying.
            root.IsDirty = true;
            Assert.AreEqual(1, (int)root.Context);

            // `_dirtied` MUST be called ONCE.
            root.IsDirty = true;
            Assert.AreEqual(1, (int)root.Context);
        }

        [Test]
        public void dirtied_propagation()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            root.Context = 0;
            root.DirtiedFunc = _dirtied;

            Assert.AreEqual(0, (int)root.Context);

            // `_dirtied` MUST be called for the first time.
            root_child0.MarkDirtyAndPropagate();
            Assert.AreEqual(1, (int)root.Context);

            // `_dirtied` must NOT be called for the second time.
            root_child0.MarkDirtyAndPropagate();
            Assert.AreEqual(1, (int)root.Context);
        }

        [Test]
        public void dirtied_hierarchy()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            root_child0.Context = 0;
            root_child0.DirtiedFunc = _dirtied;

            Assert.AreEqual(0, (int)root_child0.Context);

            // `_dirtied` must NOT be called for descendants.
            root.MarkDirtyAndPropagate();
            Assert.AreEqual(0, (int)root_child0.Context);

            // `_dirtied` must NOT be called for the sibling node.
            root_child1.MarkDirtyAndPropagate();
            Assert.AreEqual(0, (int)root_child0.Context);

            // `_dirtied` MUST be called in case of explicit dirtying.
            root_child0.MarkDirtyAndPropagate();
            Assert.AreEqual(1, (int)root_child0.Context);
        }
    }
}
