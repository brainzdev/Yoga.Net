using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaDirtyMarkingTest
    {
        [Test]
        public void dirty_propagation()
        {
            YogaNode root_child0, root_child1;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
                           .AddChild(root_child0 = Node(width:50, height:20))
                           .AddChild(root_child1 = Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);


            root_child0.Style.Width = 20;

            Assert.IsTrue(root_child0.IsDirty);
            Assert.IsFalse(root_child1.IsDirty);
            Assert.IsTrue(root.IsDirty);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.IsFalse(root_child0.IsDirty);
            Assert.IsFalse(root_child1.IsDirty);
            Assert.IsFalse(root.IsDirty);
        }

        [Test]
        public void dirty_propagation_only_if_prop_changed()
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

            YGNodeStyleSetWidth(root_child0, 50);

            Assert.IsFalse(root_child0.IsDirty);
            Assert.IsFalse(root_child1.IsDirty);
            Assert.IsFalse(root.IsDirty);
        }

        [Test]
        public void dirty_mark_all_children_as_dirty_when_display_changes()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetHeight(root, 100);

            YogaNode child0 = new YogaNode();
            YGNodeStyleSetFlexGrow(child0, 1);
            YogaNode child1 = new YogaNode();
            YGNodeStyleSetFlexGrow(child1, 1);

            YogaNode child1_child0 = new YogaNode();
            YogaNode child1_child0_child0 = new YogaNode();
            YGNodeStyleSetWidth(child1_child0_child0, 8);
            YGNodeStyleSetHeight(child1_child0_child0, 16);

            YGNodeInsertChild(child1_child0, child1_child0_child0, 0);

            YGNodeInsertChild(child1, child1_child0, 0);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 0);

            YGNodeStyleSetDisplay(child0, Display.Flex);
            YGNodeStyleSetDisplay(child1, Display.None);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(0, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeStyleSetDisplay(child0, Display.None);
            YGNodeStyleSetDisplay(child1, Display.Flex);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(8, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(16, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeStyleSetDisplay(child0, Display.Flex);
            YGNodeStyleSetDisplay(child1, Display.None);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(0, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeStyleSetDisplay(child0, Display.None);
            YGNodeStyleSetDisplay(child1, Display.Flex);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(8, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(16, YGNodeLayoutGetHeight(child1_child0_child0));
        }

        [Test]
        public void dirty_node_only_if_children_are_actually_removed()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode child0 = new YogaNode();
            YGNodeStyleSetWidth(child0, 50);
            YGNodeStyleSetHeight(child0, 25);
            YGNodeInsertChild(root, child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            YogaNode child1 = new YogaNode();
            YGNodeRemoveChild(root, child1);
            Assert.IsFalse(root.IsDirty);


            YGNodeRemoveChild(root, child0);
            Assert.IsTrue(root.IsDirty);
        }

        [Test]
        public void dirty_node_only_if_undefined_values_gets_set_to_undefined()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);
            YGNodeStyleSetMinWidth(root, YogaValue.YGUndefined);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.IsFalse(root.IsDirty);

            YGNodeStyleSetMinWidth(root, YogaValue.YGUndefined);

            Assert.IsFalse(root.IsDirty);
        }
    }
}
