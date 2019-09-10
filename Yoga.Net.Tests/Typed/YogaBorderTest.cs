using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaBorderTest
    {
        [Test]
        public void border_no_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);
        }

        [Test]
        public void border_container_match_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void border_flex_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);
        }

        [Test]
        public void border_stretch_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void border_center_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetBorder(root, Edge.Start, 10);
            YGNodeStyleSetBorder(root, Edge.End, 20);
            YGNodeStyleSetBorder(root, Edge.Bottom, 20);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, root_child0.Layout.Left);
            Assert.AreEqual(35, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(35, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }
    }
}
