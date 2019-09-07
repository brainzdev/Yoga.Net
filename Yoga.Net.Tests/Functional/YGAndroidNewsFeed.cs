using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGAndroidNewsFeed
    {
        [Test]
        public void android_news_feed()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root, 1080);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root_child0_child0, YogaAlign.Stretch);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root_child0_child0_child0, YogaAlign.Stretch);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YogaNode root_child0_child0_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child0_child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0_child0_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetAlignItems(root_child0_child0_child0_child0, YogaAlign.FlexStart);
            YGNodeStyleSetMargin(root_child0_child0_child0_child0, Edge.Start, 36);
            YGNodeStyleSetMargin(root_child0_child0_child0_child0, Edge.Top, 24);
            YGNodeInsertChild(
                root_child0_child0_child0,
                root_child0_child0_child0_child0,
                0);

            YogaNode root_child0_child0_child0_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child0_child0_child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child0,
                YogaAlign.Stretch);
            YGNodeInsertChild(
                root_child0_child0_child0_child0,
                root_child0_child0_child0_child0_child0,
                0);

            YogaNode root_child0_child0_child0_child0_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child0_child0,
                YogaAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0_child0_child0_child0_child0, 120);
            YGNodeStyleSetHeight(root_child0_child0_child0_child0_child0_child0, 120);
            YGNodeInsertChild(
                root_child0_child0_child0_child0_child0,
                root_child0_child0_child0_child0_child0_child0,
                0);

            YogaNode root_child0_child0_child0_child0_child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child1,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child0_child0_child1, 1);
            YGNodeStyleSetMargin(
                root_child0_child0_child0_child0_child1,
                Edge.Right,
                36);
            YGNodeStyleSetPadding(
                root_child0_child0_child0_child0_child1,
                Edge.Left,
                36);
            YGNodeStyleSetPadding(root_child0_child0_child0_child0_child1, Edge.Top, 21);
            YGNodeStyleSetPadding(
                root_child0_child0_child0_child0_child1,
                Edge.Right,
                36);
            YGNodeStyleSetPadding(
                root_child0_child0_child0_child0_child1,
                Edge.Bottom,
                18);
            YGNodeInsertChild(
                root_child0_child0_child0_child0,
                root_child0_child0_child0_child0_child1,
                1);

            YogaNode root_child0_child0_child0_child0_child1_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child0_child0_child1_child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child1_child0,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child0_child0_child1_child0, 1);
            YGNodeInsertChild(
                root_child0_child0_child0_child0_child1,
                root_child0_child0_child0_child0_child1_child0,
                0);

            YogaNode root_child0_child0_child0_child0_child1_child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child1_child1,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child0_child0_child1_child1, 1);
            YGNodeInsertChild(
                root_child0_child0_child0_child0_child1,
                root_child0_child0_child0_child0_child1_child1,
                1);

            YogaNode root_child0_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root_child0_child0_child1, YogaAlign.Stretch);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child1, 1);

            YogaNode root_child0_child0_child1_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child1_child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0_child0_child1_child0, YogaAlign.Stretch);
            YGNodeStyleSetAlignItems(root_child0_child0_child1_child0, YogaAlign.FlexStart);
            YGNodeStyleSetMargin(root_child0_child0_child1_child0, Edge.Start, 174);
            YGNodeStyleSetMargin(root_child0_child0_child1_child0, Edge.Top, 24);
            YGNodeInsertChild(
                root_child0_child0_child1,
                root_child0_child0_child1_child0,
                0);

            YogaNode root_child0_child0_child1_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child1_child0_child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child0,
                YogaAlign.Stretch);
            YGNodeInsertChild(
                root_child0_child0_child1_child0,
                root_child0_child0_child1_child0_child0,
                0);

            YogaNode root_child0_child0_child1_child0_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child0_child0,
                YogaAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0_child1_child0_child0_child0, 72);
            YGNodeStyleSetHeight(root_child0_child0_child1_child0_child0_child0, 72);
            YGNodeInsertChild(
                root_child0_child0_child1_child0_child0,
                root_child0_child0_child1_child0_child0_child0,
                0);

            YogaNode root_child0_child0_child1_child0_child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child1,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child1_child0_child1, 1);
            YGNodeStyleSetMargin(
                root_child0_child0_child1_child0_child1,
                Edge.Right,
                36);
            YGNodeStyleSetPadding(
                root_child0_child0_child1_child0_child1,
                Edge.Left,
                36);
            YGNodeStyleSetPadding(root_child0_child0_child1_child0_child1, Edge.Top, 21);
            YGNodeStyleSetPadding(
                root_child0_child0_child1_child0_child1,
                Edge.Right,
                36);
            YGNodeStyleSetPadding(
                root_child0_child0_child1_child0_child1,
                Edge.Bottom,
                18);
            YGNodeInsertChild(
                root_child0_child0_child1_child0,
                root_child0_child0_child1_child0_child1,
                1);

            YogaNode root_child0_child0_child1_child0_child1_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child1_child0_child1_child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child1_child0,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child1_child0_child1_child0, 1);
            YGNodeInsertChild(
                root_child0_child0_child1_child0_child1,
                root_child0_child0_child1_child0_child1_child0,
                0);

            YogaNode root_child0_child0_child1_child0_child1_child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child1_child1,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child1_child0_child1_child1, 1);
            YGNodeInsertChild(
                root_child0_child0_child1_child0_child1,
                root_child0_child0_child1_child0_child1_child1,
                1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(144, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(36, YGNodeLayoutGetLeft(root_child0_child0_child0_child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(root_child0_child0_child0_child0));
            Assert.AreEqual(1044, YGNodeLayoutGetWidth(root_child0_child0_child0_child0));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root_child0_child0_child0_child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child0_child0));

            Assert.AreEqual(
                120,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                39,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1_child0));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child1));
            Assert.AreEqual(144, YGNodeLayoutGetTop(root_child0_child0_child1));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0_child0_child1));
            Assert.AreEqual(96, YGNodeLayoutGetHeight(root_child0_child0_child1));

            Assert.AreEqual(174, YGNodeLayoutGetLeft(root_child0_child0_child1_child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(root_child0_child0_child1_child0));
            Assert.AreEqual(906, YGNodeLayoutGetWidth(root_child0_child0_child1_child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(root_child0_child0_child1_child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child0_child0));

            Assert.AreEqual(
                72,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                39,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1_child0));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(144, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0_child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(root_child0_child0_child0_child0));
            Assert.AreEqual(1044, YGNodeLayoutGetWidth(root_child0_child0_child0_child0));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root_child0_child0_child0_child0));

            Assert.AreEqual(
                924,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child0_child0));

            Assert.AreEqual(
                816,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                39,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1_child0));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child1));
            Assert.AreEqual(144, YGNodeLayoutGetTop(root_child0_child0_child1));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0_child0_child1));
            Assert.AreEqual(96, YGNodeLayoutGetHeight(root_child0_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child1_child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(root_child0_child0_child1_child0));
            Assert.AreEqual(906, YGNodeLayoutGetWidth(root_child0_child0_child1_child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(root_child0_child0_child1_child0));

            Assert.AreEqual(
                834,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child0_child0));

            Assert.AreEqual(
                726,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                39,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1_child0));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1_child1));
        }
    }
}
