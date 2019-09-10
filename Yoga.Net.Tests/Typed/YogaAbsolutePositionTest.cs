using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAbsolutePositionTest
    {
        [Test]
        public void absolute_layout_width_height_start_top()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Start, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 10);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_width_height_end_bottom()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.End, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(80, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(80, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_start_top_end_bottom()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Start, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 10);
            YGNodeStyleSetPosition(root_child0, Edge.End, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Bottom, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_width_height_start_top_end_bottom()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Start, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 10);
            YGNodeStyleSetPosition(root_child0, Edge.End, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void do_not_clamp_height_of_absolute_node_to_height_of_its_overflow_hidden_parent()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetOverflow(root, Overflow.Hidden);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Start, 0);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 0);
            YGNodeInsertChild(root, root_child0, 0);

            var root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeStyleSetHeight(root_child0_child0, 100);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(-50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_within_border()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetMargin(root, Edge.Left, 10);
            YGNodeStyleSetMargin(root, Edge.Top, 10);
            YGNodeStyleSetMargin(root, Edge.Right, 10);
            YGNodeStyleSetMargin(root, Edge.Bottom, 10);
            YGNodeStyleSetPadding(root, Edge.Left, 10);
            YGNodeStyleSetPadding(root, Edge.Top, 10);
            YGNodeStyleSetPadding(root, Edge.Right, 10);
            YGNodeStyleSetPadding(root, Edge.Bottom, 10);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 0);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 0);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            var root_child1 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child1, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child1, Edge.Right, 0);
            YGNodeStyleSetPosition(root_child1, Edge.Bottom, 0);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            var root_child2 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child2, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child2, Edge.Left, 0);
            YGNodeStyleSetPosition(root_child2, Edge.Top, 0);
            YGNodeStyleSetMargin(root_child2, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child2, Edge.Top, 10);
            YGNodeStyleSetMargin(root_child2, Edge.Right, 10);
            YGNodeStyleSetMargin(root_child2, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            var root_child3 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child3, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child3, Edge.Right, 0);
            YGNodeStyleSetPosition(root_child3, Edge.Bottom, 0);
            YGNodeStyleSetMargin(root_child3, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child3, Edge.Top, 10);
            YGNodeStyleSetMargin(root_child3, Edge.Right, 10);
            YGNodeStyleSetMargin(root_child3, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, root.Layout.Left);
            Assert.AreEqual(10, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(20, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(10, root.Layout.Left);
            Assert.AreEqual(10, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(20, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_flex_end()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(60, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(60, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_justify_content_center()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_center()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_center_on_child_only()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetAlignSelf(root_child0, YogaAlign.Center);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_top_position()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 10);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_bottom_position()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(50, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(50, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_left_position()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 5);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_right_position()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Right, 5);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void position_root_with_rtl_should_position_withoutdirection()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetPosition(root, Edge.Left, 72);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(72, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(72, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);
        }

        [Test]
        public void absolute_layout_percentage_bottom_based_on_parent_height()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 200);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPositionPercent(root_child0, Edge.Top, 50);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            var root_child1 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child1, PositionType.Absolute);
            YGNodeStyleSetPositionPercent(root_child1, Edge.Bottom, 50);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            var root_child2 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child2, PositionType.Absolute);
            YGNodeStyleSetPositionPercent(root_child2, Edge.Top, 10);
            YGNodeStyleSetPositionPercent(root_child2, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(100, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(90, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(160, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(100, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(90, root_child1.Layout.Left);
            Assert.AreEqual(90, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(90, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(160, root_child2.Layout.Height);
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_column_container()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_row_container()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(80, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(80, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_column_container_flex_end()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetAlignSelf(root_child0, YogaAlign.FlexEnd);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_row_container_flex_end()
        {
            var config = new YogaConfig();

            var root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = new YogaNode(config);
            YGNodeStyleSetAlignSelf(root_child0, YogaAlign.FlexEnd);
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }
    }
}
