using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaNodeChildTest
    {
        [Test]
        public void reset_layout_when_child_removed()
        {
            YogaNode root_child0;
            YogaNode root = new YogaNode
            {
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width  = 100,
                            Height = 100
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            root.Children.Remove(root_child0);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.IsTrue(root_child0.Layout.Width.IsUndefined());
            Assert.IsTrue(root_child0.Layout.Height.IsUndefined());
        }
    }
}
