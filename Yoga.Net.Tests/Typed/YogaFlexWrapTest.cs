using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaFlexWrapTest
    {
        [Test]
        public void wrap_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 30);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 30);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(60, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(30, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(60, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(60, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(30, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(30, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(30, root_child2.Layout.Left);
            Assert.AreEqual(60, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);
        }

        [Test]
        public void wrap_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 30);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 30);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(30, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(30, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);
        }

        [Test]
        public void wrap_row_align_items_flex_end()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(20, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(20, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);
        }

        [Test]
        public void wrap_row_align_items_center()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(5, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(5, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);
        }

        [Test]
        public void flex_wrap_children_with_min_main_overriding_flex_basis()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetMinWidth(root_child0, 55);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexBasis(root_child1, 50);
            YGNodeStyleSetMinWidth(root_child1, 55);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(55, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(55, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(55, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(45, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(55, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void flex_wrap_wrap_to_child_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root_child0, YogaAlign.FlexStart);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 100);
            YGNodeStyleSetHeight(root_child0_child0_child0, 100);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 100);
            YGNodeStyleSetHeight(root_child1, 100);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(100, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(100, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Ignore("Exactly the same result as the c++ library")]
        [Test]
        public void flex_wrap_align_stretch_fits_one_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_flex_start()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(40, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_center()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(40, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_single_line_different_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 300);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(300, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(40, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(90, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(120, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(300, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(270, root_child0.Layout.Left);
            Assert.AreEqual(40, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(240, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(210, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(180, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(150, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_stretch()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(40, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_space_around()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.SpaceAround);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(40, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_column_fixed_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(170, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(170, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(170, root_child2.Layout.Left);
            Assert.AreEqual(30, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(170, root_child3.Layout.Left);
            Assert.AreEqual(60, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(140, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(30, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(60, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrapped_row_within_align_items_center()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0, 150);
            YGNodeStyleSetHeight(root_child0_child0, 80);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child1, 80);
            YGNodeStyleSetHeight(root_child0_child1, 80);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(120, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);
        }

        [Test]
        public void wrapped_row_within_align_items_flex_start()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0, 150);
            YGNodeStyleSetHeight(root_child0_child0, 80);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child1, 80);
            YGNodeStyleSetHeight(root_child0_child1, 80);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(120, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);
        }

        [Test]
        public void wrapped_row_within_align_items_flex_end()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0, 150);
            YGNodeStyleSetHeight(root_child0_child0, 80);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child1, 80);
            YGNodeStyleSetHeight(root_child0_child1, 80);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(120, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);
        }

        [Test]
        public void wrapped_column_max_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignContent(root, YogaAlign.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 700);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 500);
            YGNodeStyleSetMaxHeight(root_child0, 200);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child1, Edge.Left, 20);
            YGNodeStyleSetMargin(root_child1, Edge.Top, 20);
            YGNodeStyleSetMargin(root_child1, Edge.Right, 20);
            YGNodeStyleSetMargin(root_child1, Edge.Bottom, 20);
            YGNodeStyleSetWidth(root_child1, 200);
            YGNodeStyleSetHeight(root_child1, 200);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 100);
            YGNodeStyleSetHeight(root_child2, 100);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(250, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(200, root_child1.Layout.Left);
            Assert.AreEqual(250, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(200, root_child1.Layout.Height);

            Assert.AreEqual(420, root_child2.Layout.Left);
            Assert.AreEqual(200, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(350, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(300, root_child1.Layout.Left);
            Assert.AreEqual(250, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(200, root_child1.Layout.Height);

            Assert.AreEqual(180, root_child2.Layout.Left);
            Assert.AreEqual(200, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void wrapped_column_max_height_flex()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignContent(root, YogaAlign.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 700);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0, 0);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 500);
            YGNodeStyleSetMaxHeight(root_child0, 200);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
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

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 100);
            YGNodeStyleSetHeight(root_child2, 100);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(300, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(180, root_child0.Layout.Height);

            Assert.AreEqual(250, root_child1.Layout.Left);
            Assert.AreEqual(200, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(180, root_child1.Layout.Height);

            Assert.AreEqual(300, root_child2.Layout.Left);
            Assert.AreEqual(400, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(300, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(180, root_child0.Layout.Height);

            Assert.AreEqual(250, root_child1.Layout.Left);
            Assert.AreEqual(200, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(180, root_child1.Layout.Height);

            Assert.AreEqual(300, root_child2.Layout.Left);
            Assert.AreEqual(400, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void wrap_nodes_with_content_sizing_overflowing_margin()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeStyleSetWidth(root_child0, 85);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 40);
            YGNodeStyleSetHeight(root_child0_child0_child0, 40);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YogaNode root_child0_child1 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0_child1, Edge.Right, 10);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);

            YogaNode root_child0_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child1_child0, 40);
            YGNodeStyleSetHeight(root_child0_child1_child0, 40);
            YGNodeInsertChild(root_child0_child1, root_child0_child1_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(85, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(40, root_child0_child1.Layout.Top);
            Assert.AreEqual(40, root_child0_child1.Layout.Width);
            Assert.AreEqual(40, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(415, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(85, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(45, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(35, root_child0_child1.Layout.Left);
            Assert.AreEqual(40, root_child0_child1.Layout.Top);
            Assert.AreEqual(40, root_child0_child1.Layout.Width);
            Assert.AreEqual(40, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));
        }

        [Test]
        public void wrap_nodes_with_content_sizing_margin_cross()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, Wrap.Wrap);
            YGNodeStyleSetWidth(root_child0, 70);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 40);
            YGNodeStyleSetHeight(root_child0_child0_child0, 40);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YogaNode root_child0_child1 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0_child1, Edge.Top, 10);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);

            YogaNode root_child0_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child1_child0, 40);
            YGNodeStyleSetHeight(root_child0_child1_child0, 40);
            YGNodeInsertChild(root_child0_child1, root_child0_child1_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(70, root_child0.Layout.Width);
            Assert.AreEqual(90, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(50, root_child0_child1.Layout.Top);
            Assert.AreEqual(40, root_child0_child1.Layout.Width);
            Assert.AreEqual(40, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(430, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(70, root_child0.Layout.Width);
            Assert.AreEqual(90, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(30, root_child0_child1.Layout.Left);
            Assert.AreEqual(50, root_child0_child1.Layout.Top);
            Assert.AreEqual(40, root_child0_child1.Layout.Width);
            Assert.AreEqual(40, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));
        }
    }
}
