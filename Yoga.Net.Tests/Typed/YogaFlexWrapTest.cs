using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaFlexWrapTest
    {
        [Test]
        public void wrap_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 30);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 30);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));
        }

        [Test]
        public void wrap_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 30);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 30);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));
        }

        [Test]
        public void wrap_row_align_items_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));
        }

        [Test]
        public void wrap_row_align_items_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));
        }

        [Test]
        public void flex_wrap_children_with_min_main_overriding_flex_basis()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetMinWidth(root_child0, 55);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child1, 50);
            YGNodeStyleSetMinWidth(root_child1, 55);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void flex_wrap_wrap_to_child_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root_child0, YogaAlign.FlexStart);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 100);
            YGNodeStyleSetHeight(root_child0_child0_child0, 100);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 100);
            YGNodeStyleSetHeight(root_child1, 100);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));
        }

        [Ignore("Exactly the same result as the c++ library")]
        [Test]
        public void flex_wrap_align_stretch_fits_one_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void wrap_reverse_row_align_content_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));
        }

        [Test]
        public void wrap_reverse_row_align_content_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));
        }

        [Test]
        public void wrap_reverse_row_single_line_different_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 300);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(270, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(240, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(210, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(180, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(150, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));
        }

        [Test]
        public void wrap_reverse_row_align_content_stretch()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));
        }

        [Test]
        public void wrap_reverse_row_align_content_space_around()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.SpaceAround);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));
        }

        [Test]
        public void wrap_reverse_column_fixed_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(140, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));
        }

        [Test]
        public void wrapped_row_within_align_items_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 150);
            YGNodeStyleSetHeight(root_child0_child0, 80);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1, 80);
            YGNodeStyleSetHeight(root_child0_child1, 80);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));
        }

        [Test]
        public void wrapped_row_within_align_items_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 150);
            YGNodeStyleSetHeight(root_child0_child0, 80);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1, 80);
            YGNodeStyleSetHeight(root_child0_child1, 80);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));
        }

        [Test]
        public void wrapped_row_within_align_items_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 150);
            YGNodeStyleSetHeight(root_child0_child0, 80);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1, 80);
            YGNodeStyleSetHeight(root_child0_child1, 80);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));
        }

        [Test]
        public void wrapped_column_max_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignContent(root, YogaAlign.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 700);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 500);
            YGNodeStyleSetMaxHeight(root_child0, 200);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root_child1, Edge.Left, 20);
            YGNodeStyleSetMargin(root_child1, Edge.Top, 20);
            YGNodeStyleSetMargin(root_child1, Edge.Right, 20);
            YGNodeStyleSetMargin(root_child1, Edge.Bottom, 20);
            YGNodeStyleSetWidth(root_child1, 200);
            YGNodeStyleSetHeight(root_child1, 200);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 100);
            YGNodeStyleSetHeight(root_child2, 100);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(200, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(250, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(420, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(200, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(350, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(250, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(180, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(200, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void wrapped_column_max_height_flex()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignContent(root, YogaAlign.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 700);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0, 0);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 500);
            YGNodeStyleSetMaxHeight(root_child0, 200);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetMargin(root_child1, Edge.Left, 20);
            YGNodeStyleSetMargin(root_child1, Edge.Top, 20);
            YGNodeStyleSetMargin(root_child1, Edge.Right, 20);
            YGNodeStyleSetMargin(root_child1, Edge.Bottom, 20);
            YGNodeStyleSetWidth(root_child1, 200);
            YGNodeStyleSetHeight(root_child1, 200);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 100);
            YGNodeStyleSetHeight(root_child2, 100);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(400, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(400, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void wrap_nodes_with_content_sizing_overflowing_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeStyleSetWidth(root_child0, 85);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 40);
            YGNodeStyleSetHeight(root_child0_child0_child0, 40);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YogaNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root_child0_child1, Edge.Right, 10);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);

            YogaNode root_child0_child1_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1_child0, 40);
            YGNodeStyleSetHeight(root_child0_child1_child0, 40);
            YGNodeInsertChild(root_child0_child1, root_child0_child1_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(85, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(415, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(85, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(35, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));
        }

        [Test]
        public void wrap_nodes_with_content_sizing_margin_cross()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeStyleSetWidth(root_child0, 70);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 40);
            YGNodeStyleSetHeight(root_child0_child0_child0, 40);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YogaNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root_child0_child1, Edge.Top, 10);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);

            YogaNode root_child0_child1_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1_child0, 40);
            YGNodeStyleSetHeight(root_child0_child1_child0, 40);
            YGNodeInsertChild(root_child0_child1, root_child0_child1_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(430, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));
        }
    }
}