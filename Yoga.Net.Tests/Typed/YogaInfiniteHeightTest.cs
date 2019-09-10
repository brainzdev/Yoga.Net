using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaInfiniteHeightTest
    {
        // This test isn't correct from the Flexbox standard standpoint,
        // because percentages are calculated with parent constraints.
        // However, we need to make sure we fail gracefully in this case, not returning NaN
        [Test]
        public void percent_absolute_position_infinite_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 300);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 300);
            YGNodeStyleSetHeight(root_child0, 300);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetPositionType(root_child1, PositionType.Absolute);
            YGNodeStyleSetPositionPercent(root_child1, Edge.Left, 20);
            YGNodeStyleSetPositionPercent(root_child1, Edge.Top, 20);
            YGNodeStyleSetWidthPercent(root_child1, 20);
            YGNodeStyleSetHeightPercent(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(300, root.Layout.Width);
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(300, root_child0.Layout.Width);
            Assert.AreEqual(300, root_child0.Layout.Height);

            Assert.AreEqual(60, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(60, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);
        }
    }
}
