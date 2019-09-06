using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGInfiniteHeightTest
    {
        // This test isn't correct from the Flexbox standard standpoint,
        // because percentages are calculated with parent constraints.
        // However, we need to make sure we fail gracefully in this case, not returning NaN
        [Test]
        public void percent_absolute_position_infinite_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 300);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 300);
            YGNodeStyleSetHeight(root_child0, 300);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root_child1, PositionType.Absolute);
            YGNodeStyleSetPositionPercent(root_child1, Edge.Left, 20);
            YGNodeStyleSetPositionPercent(root_child1, Edge.Top, 20);
            YGNodeStyleSetWidthPercent(root_child1, 20);
            YGNodeStyleSetHeightPercent(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child1));
        }
    }
}
