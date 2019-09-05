using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGDirtiedTest
    {
        static void _dirtied(YGNode node)
        {
            int dirtiedCount = (int)node.Context;
            dirtiedCount++;
            node.Context = dirtiedCount;
        }

        [Test]
        public void dirtied()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            //int dirtiedCount = 0;
            root.Context = 0;
            root.DirtiedFunc = _dirtied;

            Assert.AreEqual(0, (int)root.Context);

            // `_dirtied` MUST be called in case of explicit dirtying.
            root.SetDirty(true);
            Assert.AreEqual(1, (int)root.Context);

            // `_dirtied` MUST be called ONCE.
            root.SetDirty(true);
            Assert.AreEqual(1, (int)root.Context);
        }

        [Test]
        public void dirtied_propagation()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNew();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

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
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNew();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

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
