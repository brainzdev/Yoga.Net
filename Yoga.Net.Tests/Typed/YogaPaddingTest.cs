using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaPaddingTest
    {
        [Test]
        public void padding_no_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Padding = new Edges(10, 10, 10, 10)
                }
            };
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);
        }

        [Test]
        public void padding_container_match_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Padding = new Edges(10, 10, 10, 10)
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width = 10,
                            Height = 10
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void padding_flex_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Padding = new Edges(10, 10, 10, 10),
                    Width = 100,
                    Height = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Width = 10
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);
        }

        [Test]
        public void padding_stretch_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Padding = new Edges(10, 10, 10, 10),
                    Width   = 100,
                    Height  = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Height = 10
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void padding_center_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    JustifyContent = Justify.Center,
                    AlignItems = YogaAlign.Center,
                    Padding = new Edges
                    {
                        Start = 10,
                        End = 20,
                        Bottom = 20
                    },
                    Width   = 100,
                    Height  = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width    = 10,
                            Height = 10
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, root_child0.Layout.Left);
            Assert.AreEqual(35, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(35, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void child_with_padding_align_end()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    JustifyContent = Justify.FlexEnd,
                    AlignItems     = YogaAlign.FlexEnd,
                    Width  = 200,
                    Height = 200
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Padding = new Edges(20, 20, 20, 20),
                            Width  = 100,
                            Height = 100
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(100, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(100, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }
    }
}
