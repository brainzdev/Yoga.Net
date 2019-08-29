using NUnit.Framework;
using static Yoga.Net.YGGlobal;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGAbsolutePositionTest
    {
        [Test] public void absolute_layout_width_height_start_top()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.Start, 10);
            YGNodeStyleSetPosition(root_child0, YGEdge.Top, 10);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_width_height_end_bottom()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.End, 10);
            YGNodeStyleSetPosition(root_child0, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_start_top_end_bottom()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.Start, 10);
            YGNodeStyleSetPosition(root_child0, YGEdge.Top, 10);
            YGNodeStyleSetPosition(root_child0, YGEdge.End, 10);
            YGNodeStyleSetPosition(root_child0, YGEdge.Bottom, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_width_height_start_top_end_bottom()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.Start, 10);
            YGNodeStyleSetPosition(root_child0, YGEdge.Top, 10);
            YGNodeStyleSetPosition(root_child0, YGEdge.End, 10);
            YGNodeStyleSetPosition(root_child0, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void do_not_clamp_height_of_absolute_node_to_height_of_its_overflow_hidden_parent()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetOverflow(root, YGOverflow.Hidden);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.Start, 0);
            YGNodeStyleSetPosition(root_child0, YGEdge.Top, 0);
            YGNodeInsertChild(root, root_child0, 0);

            var root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeStyleSetHeight(root_child0_child0, 100);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            

            
        }

        [Test]
        public void absolute_layout_within_border()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, YGEdge.Left, 10);
            YGNodeStyleSetMargin(root, YGEdge.Top, 10);
            YGNodeStyleSetMargin(root, YGEdge.Right, 10);
            YGNodeStyleSetMargin(root, YGEdge.Bottom, 10);
            YGNodeStyleSetPadding(root, YGEdge.Left, 10);
            YGNodeStyleSetPadding(root, YGEdge.Top, 10);
            YGNodeStyleSetPadding(root, YGEdge.Right, 10);
            YGNodeStyleSetPadding(root, YGEdge.Bottom, 10);
            YGNodeStyleSetBorder(root, YGEdge.Left, 10);
            YGNodeStyleSetBorder(root, YGEdge.Top, 10);
            YGNodeStyleSetBorder(root, YGEdge.Right, 10);
            YGNodeStyleSetBorder(root, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.Left, 0);
            YGNodeStyleSetPosition(root_child0, YGEdge.Top, 0);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            var root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child1, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child1, YGEdge.Right, 0);
            YGNodeStyleSetPosition(root_child1, YGEdge.Bottom, 0);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            var root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child2, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child2, YGEdge.Left, 0);
            YGNodeStyleSetPosition(root_child2, YGEdge.Top, 0);
            YGNodeStyleSetMargin(root_child2, YGEdge.Left, 10);
            YGNodeStyleSetMargin(root_child2, YGEdge.Top, 10);
            YGNodeStyleSetMargin(root_child2, YGEdge.Right, 10);
            YGNodeStyleSetMargin(root_child2, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            var root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child3, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child3, YGEdge.Right, 0);
            YGNodeStyleSetPosition(root_child3, YGEdge.Bottom, 0);
            YGNodeStyleSetMargin(root_child3, YGEdge.Left, 10);
            YGNodeStyleSetMargin(root_child3, YGEdge.Top, 10);
            YGNodeStyleSetMargin(root_child3, YGEdge.Right, 10);
            YGNodeStyleSetMargin(root_child3, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            

            
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, YGJustify.Center);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_flex_end()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, YGJustify.FlexEnd);
            YGNodeStyleSetAlignItems(root, YGAlign.FlexEnd);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_justify_content_center()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, YGJustify.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_align_items_center()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_align_items_center_on_child_only()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(root_child0, YGAlign.Center);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_top_position()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, YGJustify.Center);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.Top, 10);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_bottom_position()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, YGJustify.Center);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_left_position()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, YGJustify.Center);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.Left, 5);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(5, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(5, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_right_position()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, YGJustify.Center);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, YGEdge.Right, 5);
            YGNodeStyleSetWidth(root_child0, 60);
            YGNodeStyleSetHeight(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void position_root_with_rtl_should_position_withoutdirection()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPosition(root, YGEdge.Left, 72);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(72, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(72, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            

            
        }

        [Test]
        public void absolute_layout_percentage_bottom_based_on_parent_height()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 200);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetPositionPercent(root_child0, YGEdge.Top, 50);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            var root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child1, YGPositionType.Absolute);
            YGNodeStyleSetPositionPercent(root_child1, YGEdge.Bottom, 50);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            var root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child2, YGPositionType.Absolute);
            YGNodeStyleSetPositionPercent(root_child2, YGEdge.Top, 10);
            YGNodeStyleSetPositionPercent(root_child2, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(90, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(90, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_column_container()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_row_container()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_column_container_flex_end()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(root_child0, YGAlign.FlexEnd);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            

            
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_row_container_flex_end()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(root_child0, YGAlign.FlexEnd);
            YGNodeStyleSetPositionType(root_child0, YGPositionType.Absolute);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            

            
        }
    }
}
