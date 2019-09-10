using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaComputedMarginTest
    {
        [Test]
        public void computed_layout_margin()
        {
            var root = new YogaNode();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetMarginPercent(root, Edge.Start, 10);

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, root.Layout.Margin.Left);
            Assert.AreEqual(0, root.Layout.Margin.Right);

            YogaArrange.CalculateLayout(root, 100, 100, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Margin.Left);
            Assert.AreEqual(10, root.Layout.Margin.Right);
        }
    }
}
