using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaComputedMarginTest
    {
        [Test]
        public void computed_layout_margin()
        {
            var root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetMarginPercent(root, Edge.Start, 10);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetMargin(root, Edge.Left));
            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, Edge.Right));

            YGNodeCalculateLayout(root, 100, 100, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, Edge.Left));
            Assert.AreEqual(10, YGNodeLayoutGetMargin(root, Edge.Right));
        }
    }
}
