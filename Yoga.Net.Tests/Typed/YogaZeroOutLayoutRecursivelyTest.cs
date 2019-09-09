using NUnit.Framework;
using static Yoga.Net.YogaGlobal;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaZeroOutLayoutRecursivelyTest
    {
        [Test]
        public void zero_out_layout()
        {
            YogaNode child;
            YogaNode root = new YogaNode
            {
                Trace  = "root",
                Config = {PrintTree = true},
                Style = new YogaStyle
                {
                    Width         = 200,
                    Height        = 200,
                    FlexDirection = FlexDirection.Row
                },
                Children =
                {
                    (child = new YogaNode
                    {
                        Trace = "child",
                        Style = new YogaStyle
                        {
                            Width   = 100,
                            Height  = 100,
                            Margin  = new Edges(top: 10),
                            Padding = new Edges(top: 10)
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, child.LayoutMargin(Edge.Top));
            Assert.AreEqual(10, child.LayoutPadding(Edge.Top));

            child.Style.Display = Display.None;

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(0, child.LayoutMargin(Edge.Top));
            Assert.AreEqual(0, child.LayoutPadding(Edge.Top));
        }
    }
}
