using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaJustifyContentTest
    {
        [Test]
        public void justify_content_row_flex_start()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(20, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(92, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(82, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(72, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_flex_end()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(72, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(82, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(92, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(20, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_center()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(36, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(56, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(56, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(36, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_space_between()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceBetween);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(92, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(92, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_space_around()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceAround);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(12, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(80, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(12, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_flex_start()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_flex_end()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(72, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(82, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(92, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(72, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(82, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(92, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_center()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(36, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(56, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(36, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(56, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_space_between()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceBetween);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(92, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(92, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_space_around()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceAround);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(12, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(12, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_min_width_and_margin()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Left, 100);
            YGNodeStyleSetMinWidth(root, 50);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(15, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(15, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_greater_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root, 1000);
            YGNodeStyleSetHeight(root, 1584);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0, YogaAlign.Stretch);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root_child0_child0, Justify.Center);
            YGNodeStyleSetAlignContent(root_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetMinWidth(root_child0_child0, 400);
            YGNodeStyleSetPadding(root_child0_child0, Edge.Horizontal, 100);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0_child0_child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0_child0, 300);
            YGNodeStyleSetHeight(root_child0_child0_child0, 100);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1000, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(1000, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1000, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(1000, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(500, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_lower_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root, 1080);
            YGNodeStyleSetHeight(root, 1584);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0, YogaAlign.Stretch);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root_child0_child0, Justify.Center);
            YGNodeStyleSetAlignContent(root_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetMinWidth(root_child0_child0, 400);
            YGNodeStyleSetPadding(root_child0_child0, Edge.Horizontal, 100);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0_child0_child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0_child0, 199);
            YGNodeStyleSetHeight(root_child0_child0_child0, 100);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1080, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(1080, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(400, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(101, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(199, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1080, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(1080, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(680, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(400, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(101, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(199, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));
            //
        }

        [Test]
        public void justify_content_row_max_width_and_margin()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Left, 100);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetMaxWidth(root, 80);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(80, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(30, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(80, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(30, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void justify_content_column_min_height_and_margin()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Top, 100);
            YGNodeStyleSetMinHeight(root, 50);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(15, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(15, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void justify_content_colunn_max_height_and_margin()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Top, 100);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetMaxHeight(root, 80);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void justify_content_column_space_evenly()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceEvenly);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(18, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(74, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(18, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(74, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_space_evenly()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceEvenly);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(26, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(51, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(77, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(0, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(77, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(51, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(26, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(0, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }
    }
}
