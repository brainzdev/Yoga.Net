using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGPaddingTest
    {
        [Test]
        public void padding_no_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(root, Edge.Left, 10);
            YGNodeStyleSetPadding(root, Edge.Top, 10);
            YGNodeStyleSetPadding(root, Edge.Right, 10);
            YGNodeStyleSetPadding(root, Edge.Bottom, 10);
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
        public void padding_container_match_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(root, Edge.Left, 10);
            YGNodeStyleSetPadding(root, Edge.Top, 10);
            YGNodeStyleSetPadding(root, Edge.Right, 10);
            YGNodeStyleSetPadding(root, Edge.Bottom, 10);

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
        public void padding_flex_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(root, Edge.Left, 10);
            YGNodeStyleSetPadding(root, Edge.Top, 10);
            YGNodeStyleSetPadding(root, Edge.Right, 10);
            YGNodeStyleSetPadding(root, Edge.Bottom, 10);
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
        public void padding_stretch_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(root, Edge.Left, 10);
            YGNodeStyleSetPadding(root, Edge.Top, 10);
            YGNodeStyleSetPadding(root, Edge.Right, 10);
            YGNodeStyleSetPadding(root, Edge.Bottom, 10);
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
        public void padding_center_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetPadding(root, Edge.Start, 10);
            YGNodeStyleSetPadding(root, Edge.End, 20);
            YGNodeStyleSetPadding(root, Edge.Bottom, 20);
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

        [Test]
        public void child_with_padding_align_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(root_child0, Edge.Left, 20);
            YGNodeStyleSetPadding(root_child0, Edge.Top, 20);
            YGNodeStyleSetPadding(root_child0, Edge.Right, 20);
            YGNodeStyleSetPadding(root_child0, Edge.Bottom, 20);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }
    }
}
