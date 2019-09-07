using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaJustifyContentTest
    {
        [Test]
        public void justify_content_row_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(92, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(82, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(72, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_row_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(72, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(82, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(92, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_row_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(36, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(56, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(56, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(36, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_row_space_between()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceBetween);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(92, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(92, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_row_space_around()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceAround);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(12, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(12, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_column_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_column_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(72, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(82, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(92, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(72, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(82, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(92, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_column_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(36, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(56, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(36, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(56, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_column_space_between()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceBetween);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(92, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(92, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_column_space_around()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceAround);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(12, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(12, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_row_min_width_and_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Left, 100);
            YGNodeStyleSetMinWidth(root, 50);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(15, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(15, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_greater_than_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root, 1000);
            YGNodeStyleSetHeight(root, 1584);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0, YogaAlign.Stretch);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root_child0_child0, Justify.Center);
            YGNodeStyleSetAlignContent(root_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetMinWidth(root_child0_child0, 400);
            YGNodeStyleSetPadding(root_child0_child0, Edge.Horizontal, 100);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0_child0_child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0_child0, 300);
            YGNodeStyleSetHeight(root_child0_child0_child0, 100);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1000, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(1584, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(1000, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1000, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(1584, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(1000, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(500, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_lower_than_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root, 1080);
            YGNodeStyleSetHeight(root, 1584);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0, YogaAlign.Stretch);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root_child0_child0, Justify.Center);
            YGNodeStyleSetAlignContent(root_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetMinWidth(root_child0_child0, 400);
            YGNodeStyleSetPadding(root_child0_child0, Edge.Horizontal, 100);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0_child0_child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0_child0, 199);
            YGNodeStyleSetHeight(root_child0_child0_child0, 100);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(1584, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(400, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(101, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(199, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(1584, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(680, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(400, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(101, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(199, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));
            //
        }

        [Test]
        public void justify_content_row_max_width_and_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Left, 100);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetMaxWidth(root, 80);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void justify_content_column_min_height_and_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Top, 100);
            YGNodeStyleSetMinHeight(root, 50);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(15, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(15, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void justify_content_colunn_max_height_and_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Top, 100);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetMaxHeight(root, 80);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 20);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void justify_content_column_space_evenly()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceEvenly);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(18, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(74, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(18, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(74, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void justify_content_row_space_evenly()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceEvenly);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(26, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(51, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(77, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(77, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(51, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(26, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));
        }
    }
}
