using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaDisplayTest
    {
        [Test]
        public void display_none()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetDisplay(root_child1, Display.None);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);
        }

        [Test]
        public void display_none_fixed_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 20);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeStyleSetDisplay(root_child1, Display.None);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);
        }

        [Test]
        public void display_none_with_margin()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Top, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Right, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeStyleSetDisplay(root_child0, Display.None);
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
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void display_none_with_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0, 0);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetDisplay(root_child1, Display.None);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1_child0, 1);
            YGNodeStyleSetFlexShrink(root_child1_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1_child0, 0);
            YGNodeStyleSetWidth(root_child1_child0, 20);
            YGNodeStyleSetMinWidth(root_child1_child0, 0);
            YGNodeStyleSetMinHeight(root_child1_child0, 0);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetFlexShrink(root_child2, 1);
            YGNodeStyleSetFlexBasisPercent(root_child2, 0);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(0, root_child1_child0.Layout.Width);
            Assert.AreEqual(0, root_child1_child0.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(0, root_child1_child0.Layout.Width);
            Assert.AreEqual(0, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void display_none_with_position()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetPosition(root_child1, Edge.Top, 10);
            YGNodeStyleSetDisplay(root_child1, Display.None);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);
        }
    }
}
