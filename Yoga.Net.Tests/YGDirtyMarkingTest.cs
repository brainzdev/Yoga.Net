using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;

namespace Yoga.Net
{
    [TestFixture]
    public class YGDirtyMarkingTest
    {
        [Test] public void dirty_propagation() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNew();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            YGNodeStyleSetWidth(root_child0, 20);

            Assert.IsTrue(root_child0.isDirty());
            Assert.IsFalse(root_child1.isDirty());
            Assert.IsTrue(root.isDirty());

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.IsFalse(root_child0.isDirty());
            Assert.IsFalse(root_child1.isDirty());
            Assert.IsFalse(root.isDirty());

            YGNodeFreeRecursive(root);
        }

        [Test] public void dirty_propagation_only_if_prop_changed() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNew();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            YGNodeStyleSetWidth(root_child0, 50);

            Assert.IsFalse(root_child0.isDirty());
            Assert.IsFalse(root_child1.isDirty());
            Assert.IsFalse(root.isDirty());

            YGNodeFreeRecursive(root);
        }

        [Test] public void dirty_mark_all_children_as_dirty_when_display_changes() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(child0, 1);
            YGNodeRef child1 = YGNodeNew();
            YGNodeStyleSetFlexGrow(child1, 1);

            YGNodeRef child1_child0 = YGNodeNew();
            YGNodeRef child1_child0_child0 = YGNodeNew();
            YGNodeStyleSetWidth(child1_child0_child0, 8);
            YGNodeStyleSetHeight(child1_child0_child0, 16);

            YGNodeInsertChild(child1_child0, child1_child0_child0, 0);

            YGNodeInsertChild(child1, child1_child0, 0);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 0);

            YGNodeStyleSetDisplay(child0, YGDisplay.Flex);
            YGNodeStyleSetDisplay(child1, YGDisplay.None);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(0, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeStyleSetDisplay(child0, YGDisplay.None);
            YGNodeStyleSetDisplay(child1, YGDisplay.Flex);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(8, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(16, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeStyleSetDisplay(child0, YGDisplay.Flex);
            YGNodeStyleSetDisplay(child1, YGDisplay.None);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(0, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeStyleSetDisplay(child0, YGDisplay.None);
            YGNodeStyleSetDisplay(child1, YGDisplay.Flex);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(8, YGNodeLayoutGetWidth(child1_child0_child0));
            Assert.AreEqual(16, YGNodeLayoutGetHeight(child1_child0_child0));

            YGNodeFreeRecursive(root);
        }

        [Test] public void dirty_node_only_if_children_are_actually_removed() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YGNodeRef child0 = YGNodeNew();
            YGNodeStyleSetWidth(child0, 50);
            YGNodeStyleSetHeight(child0, 25);
            YGNodeInsertChild(root, child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            YGNodeRef child1 = YGNodeNew();
            YGNodeRemoveChild(root, child1);
            Assert.IsFalse(root.isDirty());
            YGNodeFree(child1);

            YGNodeRemoveChild(root, child0);
            Assert.IsTrue(root.isDirty());
            YGNodeFree(child0);

            YGNodeFreeRecursive(root);
        }

        [Test] public void dirty_node_only_if_undefined_values_gets_set_to_undefined() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);
            YGNodeStyleSetMinWidth(root, YGValue.YGUndefined);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.IsFalse(root.isDirty());

            YGNodeStyleSetMinWidth(root, YGValue.YGUndefined);

            Assert.IsFalse(root.isDirty());

            YGNodeFreeRecursive(root);
        }
    }
}
