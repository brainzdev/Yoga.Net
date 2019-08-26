using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;

namespace Yoga.Net.Tests
{

    [TestFixture]
    public class YGAndroidNewsFeed
    {

        [Test] public void android_news_feed() {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetWidth(root, 1080);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root_child0_child0, YGAlign.Stretch);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeRef root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root_child0_child0_child0, YGAlign.Stretch);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YGNodeRef root_child0_child0_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child0_child0, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0_child0_child0_child0, YGAlign.Stretch);
            YGNodeStyleSetAlignItems(root_child0_child0_child0_child0, YGAlign.FlexStart);
            YGNodeStyleSetMargin(root_child0_child0_child0_child0, YGEdge.Start, 36);
            YGNodeStyleSetMargin(root_child0_child0_child0_child0, YGEdge.Top, 24);
            YGNodeInsertChild(
                root_child0_child0_child0, root_child0_child0_child0_child0, 0);

            YGNodeRef root_child0_child0_child0_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child0_child0_child0, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child0, YGAlign.Stretch);
            YGNodeInsertChild(
                root_child0_child0_child0_child0,
                root_child0_child0_child0_child0_child0,
                0);

            YGNodeRef root_child0_child0_child0_child0_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child0_child0, YGAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0_child0_child0_child0_child0, 120);
            YGNodeStyleSetHeight(root_child0_child0_child0_child0_child0_child0, 120);
            YGNodeInsertChild(
                root_child0_child0_child0_child0_child0,
                root_child0_child0_child0_child0_child0_child0,
                0);

            YGNodeRef root_child0_child0_child0_child0_child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child1, YGAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child0_child0_child1, 1);
            YGNodeStyleSetMargin(
                root_child0_child0_child0_child0_child1, YGEdge.Right, 36);
            YGNodeStyleSetPadding(
                root_child0_child0_child0_child0_child1, YGEdge.Left, 36);
            YGNodeStyleSetPadding(root_child0_child0_child0_child0_child1, YGEdge.Top, 21);
            YGNodeStyleSetPadding(
                root_child0_child0_child0_child0_child1, YGEdge.Right, 36);
            YGNodeStyleSetPadding(
                root_child0_child0_child0_child0_child1, YGEdge.Bottom, 18);
            YGNodeInsertChild(
                root_child0_child0_child0_child0,
                root_child0_child0_child0_child0_child1,
                1);

            YGNodeRef root_child0_child0_child0_child0_child1_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child0_child0_child1_child0, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child1_child0, YGAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child0_child0_child1_child0, 1);
            YGNodeInsertChild(
                root_child0_child0_child0_child0_child1,
                root_child0_child0_child0_child0_child1_child0,
                0);

            YGNodeRef root_child0_child0_child0_child0_child1_child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child0_child0_child1_child1, YGAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child0_child0_child1_child1, 1);
            YGNodeInsertChild(
                root_child0_child0_child0_child0_child1,
                root_child0_child0_child0_child0_child1_child1,
                1);

            YGNodeRef root_child0_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root_child0_child0_child1, YGAlign.Stretch);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child1, 1);

            YGNodeRef root_child0_child0_child1_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child1_child0, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0_child0_child1_child0, YGAlign.Stretch);
            YGNodeStyleSetAlignItems(root_child0_child0_child1_child0, YGAlign.FlexStart);
            YGNodeStyleSetMargin(root_child0_child0_child1_child0, YGEdge.Start, 174);
            YGNodeStyleSetMargin(root_child0_child0_child1_child0, YGEdge.Top, 24);
            YGNodeInsertChild(
                root_child0_child0_child1, root_child0_child0_child1_child0, 0);

            YGNodeRef root_child0_child0_child1_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child1_child0_child0, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child0, YGAlign.Stretch);
            YGNodeInsertChild(
                root_child0_child0_child1_child0,
                root_child0_child0_child1_child0_child0,
                0);

            YGNodeRef root_child0_child0_child1_child0_child0_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child0_child0, YGAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0_child1_child0_child0_child0, 72);
            YGNodeStyleSetHeight(root_child0_child0_child1_child0_child0_child0, 72);
            YGNodeInsertChild(
                root_child0_child0_child1_child0_child0,
                root_child0_child0_child1_child0_child0_child0,
                0);

            YGNodeRef root_child0_child0_child1_child0_child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child1, YGAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child1_child0_child1, 1);
            YGNodeStyleSetMargin(
                root_child0_child0_child1_child0_child1, YGEdge.Right, 36);
            YGNodeStyleSetPadding(
                root_child0_child0_child1_child0_child1, YGEdge.Left, 36);
            YGNodeStyleSetPadding(root_child0_child0_child1_child0_child1, YGEdge.Top, 21);
            YGNodeStyleSetPadding(
                root_child0_child0_child1_child0_child1, YGEdge.Right, 36);
            YGNodeStyleSetPadding(
                root_child0_child0_child1_child0_child1, YGEdge.Bottom, 18);
            YGNodeInsertChild(
                root_child0_child0_child1_child0,
                root_child0_child0_child1_child0_child1,
                1);

            YGNodeRef root_child0_child0_child1_child0_child1_child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                root_child0_child0_child1_child0_child1_child0, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child1_child0, YGAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child1_child0_child1_child0, 1);
            YGNodeInsertChild(
                root_child0_child0_child1_child0_child1,
                root_child0_child0_child1_child0_child1_child0,
                0);

            YGNodeRef root_child0_child0_child1_child0_child1_child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                root_child0_child0_child1_child0_child1_child1, YGAlign.Stretch);
            YGNodeStyleSetFlexShrink(root_child0_child0_child1_child0_child1_child1, 1);
            YGNodeInsertChild(
                root_child0_child0_child1_child0_child1,
                root_child0_child0_child1_child0_child1_child1,
                1);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

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
                0, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120, YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120, YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child0));

            Assert.AreEqual(
                0, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child0_child0));

            Assert.AreEqual(
                120, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                72, YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                39, YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1));

            Assert.AreEqual(
                36, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                21, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1_child0));

            Assert.AreEqual(
                36, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                21, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child1));
            Assert.AreEqual(144, YGNodeLayoutGetTop(root_child0_child0_child1));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0_child0_child1));
            Assert.AreEqual(96, YGNodeLayoutGetHeight(root_child0_child0_child1));

            Assert.AreEqual(174, YGNodeLayoutGetLeft(root_child0_child0_child1_child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(root_child0_child0_child1_child0));
            Assert.AreEqual(906, YGNodeLayoutGetWidth(root_child0_child0_child1_child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(root_child0_child0_child1_child0));

            Assert.AreEqual(
                0, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                72, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                72, YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child0));

            Assert.AreEqual(
                0, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                72, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child0_child0));

            Assert.AreEqual(
                72, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                72, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                39, YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1));

            Assert.AreEqual(
                36, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                21, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1_child0));

            Assert.AreEqual(
                36, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                21, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1_child1));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

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
                924, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120, YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120, YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child0));

            Assert.AreEqual(
                0, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child0_child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child0_child0));

            Assert.AreEqual(
                816, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                72, YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1));
            Assert.AreEqual(
                39, YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1));

            Assert.AreEqual(
                36, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                21, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1_child0));

            Assert.AreEqual(
                36, YGNodeLayoutGetLeft(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                21, YGNodeLayoutGetTop(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetWidth(root_child0_child0_child0_child0_child1_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetHeight(root_child0_child0_child0_child0_child1_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child1));
            Assert.AreEqual(144, YGNodeLayoutGetTop(root_child0_child0_child1));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root_child0_child0_child1));
            Assert.AreEqual(96, YGNodeLayoutGetHeight(root_child0_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child1_child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(root_child0_child0_child1_child0));
            Assert.AreEqual(906, YGNodeLayoutGetWidth(root_child0_child0_child1_child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(root_child0_child0_child1_child0));

            Assert.AreEqual(
                834, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                72, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child0));
            Assert.AreEqual(
                72, YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child0));

            Assert.AreEqual(
                0, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                72, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child0_child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child0_child0));

            Assert.AreEqual(
                726, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                72, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1));
            Assert.AreEqual(
                39, YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1));

            Assert.AreEqual(
                36, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                21, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1_child0));
            Assert.AreEqual(
                0, YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1_child0));

            Assert.AreEqual(
                36, YGNodeLayoutGetLeft(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                21, YGNodeLayoutGetTop(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetWidth(root_child0_child0_child1_child0_child1_child1));
            Assert.AreEqual(
                0, YGNodeLayoutGetHeight(root_child0_child0_child1_child0_child1_child1));

            YGNodeFreeRecursive(root);

            YGConfigFree(config);
        }
    }
}
