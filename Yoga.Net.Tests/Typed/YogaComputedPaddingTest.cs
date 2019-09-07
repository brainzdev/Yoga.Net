using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaComputedPaddingTest
    {
        [Test]
        public void computed_layout_padding()
        {
            var root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetPaddingPercent(root, Edge.Start, 10);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetPadding(root, Edge.Left));
            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, Edge.Right));

            YGNodeCalculateLayout(root, 100, 100, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, Edge.Left));
            Assert.AreEqual(10, YGNodeLayoutGetPadding(root, Edge.Right));
        }
    }
}
