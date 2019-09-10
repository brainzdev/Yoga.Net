using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaComputedPaddingTest
    {
        [Test]
        public void computed_layout_padding()
        {
            var root = new YogaNode();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetPaddingPercent(root, Edge.Start, 10);

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, root.Layout.Padding.Left);
            Assert.AreEqual(0, root.Layout.Padding.Right);

            YogaArrange.CalculateLayout(root, 100, 100, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Padding.Left);
            Assert.AreEqual(10, root.Layout.Padding.Right);
        }
    }
}
