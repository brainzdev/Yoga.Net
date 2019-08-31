using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGDirtyMarkingTest
    {
        [Test]
        public void dirty_propagation()
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

            YGNodeStyleSetWidth(root_child0, 20);

            Assert.IsTrue(root_child0.IsDirty);
            Assert.IsFalse(root_child1.IsDirty);
            Assert.IsTrue(root.IsDirty);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.IsFalse(root_child0.IsDirty);
            Assert.IsFalse(root_child1.IsDirty);
            Assert.IsFalse(root.IsDirty);
        }

        [Test]
        public void dirty_propagation_only_if_prop_changed()
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

            YGNodeStyleSetWidth(root_child0, 50);

            Assert.IsFalse(root_child0.IsDirty);
            Assert.IsFalse(root_child1.IsDirty);
            Assert.IsFalse(root.IsDirty);
        }

        [Test]
        public void dirty_mark_all_children_as_dirty_when_display_changes()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetHeight(root, 100);

            YGNode child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(child0, 1);
            YGNode child1 = YGNodeNew();
            YGNodeStyleSetFlexGrow(child1, 1);

            YGNode child1_child0 = YGNodeNew();
            YGNode child1_child0_child0 = YGNodeNew();
            YGNodeStyleSetWidth(child1_child0_child0, 8);
            YGNodeStyleSetHeight(child1_child0_child0, 16);

            YGNodeInsertChild(child1_child0, child1_child0_child0, 0);

            YGNodeInsertChild(child1, child1_child0, 0);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 0);

            YGNodeStyleSetDisplay(child0, Display.Flex);
            YGNodeStyleSetDisplay(child1, Display.None);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(0, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeStyleSetDisplay(child0, Display.None);
            YGNodeStyleSetDisplay(child1, Display.Flex);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(8, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(16, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeStyleSetDisplay(child0, Display.Flex);
            YGNodeStyleSetDisplay(child1, Display.None);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(0, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeStyleSetDisplay(child0, Display.None);
            YGNodeStyleSetDisplay(child1, Display.Flex);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(8, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(16, YGNodeLayoutGetHeight(child1_child0_child0));
        }

        [Test]
        public void dirty_node_only_if_children_are_actually_removed()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YGNode child0 = YGNodeNew();
            YGNodeStyleSetWidth(child0, 50);
            YGNodeStyleSetHeight(child0, 25);
            YGNodeInsertChild(root, child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            YGNode child1 = YGNodeNew();
            YGNodeRemoveChild(root, child1);
            Assert.IsFalse(root.IsDirty);


            YGNodeRemoveChild(root, child0);
            Assert.IsTrue(root.IsDirty);
        }

        [Test]
        public void dirty_node_only_if_undefined_values_gets_set_to_undefined()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);
            YGNodeStyleSetMinWidth(root, YogaValue.YGUndefined);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.IsFalse(root.IsDirty);

            YGNodeStyleSetMinWidth(root, YogaValue.YGUndefined);

            Assert.IsFalse(root.IsDirty);
        }
    }
}
