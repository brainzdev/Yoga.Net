using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaMarginTest
    {
        [Test]
        public void margin_start()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0, Edge.Start, 10);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void margin_top()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0, Edge.Top, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void margin_end()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0, Edge.End, 10);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void margin_bottom()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0, Edge.Bottom, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(80, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(80, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void margin_and_flex_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Start, 10);
            YGNodeStyleSetMargin(root_child0, Edge.End, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void margin_and_flex_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Top, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Bottom, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);
        }

        [Test]
        public void margin_and_stretch_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Top, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Bottom, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);
        }

        [Test]
        public void margin_and_stretch_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Start, 10);
            YGNodeStyleSetMargin(root_child0, Edge.End, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void margin_with_sibling_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.End, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(45, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(55, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(45, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(55, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(45, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(45, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void margin_with_sibling_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Bottom, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(45, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(55, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(45, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(45, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(55, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(45, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_bottom()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Bottom);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_top()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Top);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(100, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(100, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_bottom_and_top()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Top);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Bottom);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(50, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(50, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_bottom_and_top_justify_center()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Top);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Bottom);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(50, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(150, root_child0.Layout.Left);
            Assert.AreEqual(50, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(150, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_mutiple_children_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Top);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child1, Edge.Top);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(25, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(100, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(75, root_child2.Layout.Left);
            Assert.AreEqual(150, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(25, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(100, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(75, root_child2.Layout.Left);
            Assert.AreEqual(150, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);
        }

        [Test]
        public void margin_auto_mutiple_children_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Right);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child1, Edge.Right);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(75, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(75, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(150, root_child2.Layout.Left);
            Assert.AreEqual(75, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(125, root_child0.Layout.Left);
            Assert.AreEqual(75, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(75, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(75, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);
        }

        [Test]
        public void margin_auto_left_and_right_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Right);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(75, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(150, root_child1.Layout.Left);
            Assert.AreEqual(75, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(75, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(75, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_left_and_right()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Right);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(150, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_start_and_end_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Start);
            YGNodeStyleSetMarginAuto(root_child0, Edge.End);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(75, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(150, root_child1.Layout.Left);
            Assert.AreEqual(75, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(75, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(75, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_start_and_end()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Start);
            YGNodeStyleSetMarginAuto(root_child0, Edge.End);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(150, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_left_and_right_column_and_center()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Right);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_left()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(150, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(150, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_right()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Right);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_left_and_right_strech()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Right);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(150, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_top_and_bottom_strech()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Top);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Bottom);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(50, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(150, root_child0.Layout.Left);
            Assert.AreEqual(50, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(150, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_should_not_be_part_of_max_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 250);
            YGNodeStyleSetHeight(root, 250);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0, Edge.Top, 20);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeStyleSetMaxHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(250, root.Layout.Width);
            Assert.AreEqual(250, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(20, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(250, root.Layout.Width);
            Assert.AreEqual(250, root.Layout.Height);

            Assert.AreEqual(150, root_child0.Layout.Left);
            Assert.AreEqual(20, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void margin_should_not_be_part_of_max_width()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 250);
            YGNodeStyleSetHeight(root, 250);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0, Edge.Left, 20);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetMaxWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(250, root.Layout.Width);
            Assert.AreEqual(250, root.Layout.Height);

            Assert.AreEqual(20, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(250, root.Layout.Width);
            Assert.AreEqual(250, root.Layout.Height);

            Assert.AreEqual(150, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void margin_auto_left_right_child_bigger_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Right);
            YGNodeStyleSetWidth(root_child0, 72);
            YGNodeStyleSetHeight(root_child0, 72);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-20, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);
        }

        [Test]
        public void margin_auto_left_child_bigger_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeStyleSetWidth(root_child0, 72);
            YGNodeStyleSetHeight(root_child0, 72);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-20, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);
        }

        [Test]
        public void margin_fix_left_auto_right_child_bigger_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0, Edge.Left, 10);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Right);
            YGNodeStyleSetWidth(root_child0, 72);
            YGNodeStyleSetHeight(root_child0, 72);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-20, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);
        }

        [Test]
        public void margin_auto_left_fix_right_child_bigger_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeStyleSetMargin(root_child0, Edge.Right, 10);
            YGNodeStyleSetWidth(root_child0, 72);
            YGNodeStyleSetHeight(root_child0, 72);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-30, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);
        }

        [Test]
        public void margin_auto_top_stretching_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0, 0);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Top);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(150, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(150, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void margin_auto_left_stretching_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0, 0);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(200, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(150, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(200, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(150, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(150, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }
    }
}
