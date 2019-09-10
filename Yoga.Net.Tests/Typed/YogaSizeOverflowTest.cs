using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaSizeOverflowTest
    {
        [Test]
        public void nested_overflowing_child()
        {
            //YogaConfig config = YGConfigNew();

            YogaNode root_child0;
            YogaNode root_child0_child0;
            YogaNode root = new YogaNode
            {
                Style = new YogaStyle
                {
                    Width  = 100,
                    Height = 100,
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    Width = 200,
                                    Height = 200
                                }
                            })
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(-100, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);
        }

        [Test]
        public void nested_overflowing_child_in_constraint_parent()
        {
            YogaNode root_child0, root_child0_child0;
            YogaNode root = new YogaNode
            {
                Style = new YogaStyle
                {
                    Width  = 100,
                    Height = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width = 100,
                            Height = 100
                        },
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    Width = 200,
                                    Height = 200
                                }
                            })
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(-100, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);
        }

        [Test]
        public void parent_wrap_child_size_overflowing_parent()
        {
            YogaNode root_child0, root_child0_child0;
            YogaNode root = new YogaNode
            {
                Style = new YogaStyle
                {
                    Width  = 100,
                    Height = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width  = 100
                        },
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    Width  = 100,
                                    Height = 200
                                }
                            })
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);
        }
    }
}
