using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaBorderTest
    {
        [Test]
        public void border_no_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));
        }

        [Test]
        public void border_container_match_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void border_flex_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void border_stretch_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void border_center_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetBorder(root, Edge.Start, 10);
            YGNodeStyleSetBorder(root, Edge.End, 20);
            YGNodeStyleSetBorder(root, Edge.Bottom, 20);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(35, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(35, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));
        }
    }
}
