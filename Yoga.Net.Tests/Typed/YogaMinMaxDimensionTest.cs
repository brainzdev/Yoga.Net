using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaMinMaxDimensionTest
    {
        [Test]
        public void max_width()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
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
                            MaxWidth = 50,
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

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void max_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row,
                    Width = 100,
                    Height = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width = 10,
                            MaxHeight = 50
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
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void min_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
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
                            MinHeight = 60
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1
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
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(80, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(80, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);
        }

        [Test]
        public void min_width()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row,
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
                            MinWidth = 60
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1
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
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(80, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(20, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(20, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void justify_content_min_max()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    JustifyContent = Justify.Center,
                    Width = 100,
                    MinHeight = 100,
                    MaxHeight = 200
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width = 60,
                            Height = 60
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
            Assert.AreEqual(20, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, root_child0.Layout.Left);
            Assert.AreEqual(20, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);
        }

        [Test]
        public void align_items_min_max()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    AlignItems = YogaAlign.Center,
                    MinWidth = 100,
                    MaxWidth = 200,
                    Height = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width = 60,
                            Height = 60
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(60, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);
        }

        [Test]
        public void justify_content_overflow_min_max()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    JustifyContent = Justify.Center,
                    MinHeight = 100,
                    MaxHeight = 110
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width = 50,
                            Height = 50
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width = 50,
                            Height = 50
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width = 50,
                            Height = 50
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(110, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(-20, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(110, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(-20, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);
        }

        [Test]
        public void flex_grow_to_min()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 100,
                    MinHeight = 100,
                    MaxHeight = 500
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            FlexShrink = 1
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Height = 50
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
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void flex_grow_in_at_most_container()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child0_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row,
                    AlignItems    = YogaAlign.FlexStart,
                    Width         = 100,
                    Height        = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexDirection = FlexDirection.Row
                        },
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    FlexBasis = 0
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
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);
        }

        [Test]
        public void flex_grow_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            FlexBasis = 0,
                            Height = 100
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_min_max_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    MinHeight = 100,
                    MaxHeight = 200
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Height = 50
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_max_width()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child0_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 200,
                    Height = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexDirection = FlexDirection.Row,
                            MaxWidth = 100
                        },
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    Height = 20
                                }
                            })
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_max_width()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child0_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 200,
                    Height = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexDirection = FlexDirection.Row,
                            MaxWidth = 300
                        },
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    Height = 20
                                }
                            })
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);
        }

        [Test]
        public void flex_root_ignored()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexGrow = 1,
                    Width = 100,
                    MinHeight = 100,
                    MaxHeight = 500
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            FlexBasis = 200

                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Height = 100
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(200, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(200, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void flex_grow_root_minimized()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child0_child0, root_child0_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 100,
                    MinHeight = 100,
                    MaxHeight = 500
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            MinHeight = 100,
                            MaxHeight = 500
                        },
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    FlexBasis = 200
                                }
                            }),
                            (root_child0_child1 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    Height = 100
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
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(300, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(200, root_child0_child1.Layout.Top);
            Assert.AreEqual(100, root_child0_child1.Layout.Width);
            Assert.AreEqual(100, root_child0_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(300, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(200, root_child0_child1.Layout.Top);
            Assert.AreEqual(100, root_child0_child1.Layout.Width);
            Assert.AreEqual(100, root_child0_child1.Layout.Height);
        }

        [Test]
        public void flex_grow_height_maximized()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child0_child0, root_child0_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 100,
                    Height = 500
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            MinHeight = 100,
                            MaxHeight = 500
                        },
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    FlexBasis = 200
                                }
                            }),
                            (root_child0_child1 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    Height = 100
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
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(500, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(400, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(400, root_child0_child1.Layout.Top);
            Assert.AreEqual(100, root_child0_child1.Layout.Width);
            Assert.AreEqual(100, root_child0_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(500, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(400, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(400, root_child0_child1.Layout.Top);
            Assert.AreEqual(100, root_child0_child1.Layout.Width);
            Assert.AreEqual(100, root_child0_child1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_min_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row,
                    MinWidth = 100,
                    Height = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Width = 50
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
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_min_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    MinHeight = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Height = 50
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_max_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child0_child0, root_child0_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 200
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexDirection = FlexDirection.Row,
                            MaxWidth = 100,
                            Height = 100
                        },
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexShrink = 1,
                                    FlexBasis = 100
                                }
                            }),
                            (root_child0_child1 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    Width = 50
                                }
                            })

                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(50, root_child0_child1.Layout.Left);
            Assert.AreEqual(0, root_child0_child1.Layout.Top);
            Assert.AreEqual(50, root_child0_child1.Layout.Width);
            Assert.AreEqual(100, root_child0_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(0, root_child0_child1.Layout.Top);
            Assert.AreEqual(50, root_child0_child1.Layout.Width);
            Assert.AreEqual(100, root_child0_child1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_max_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 100,
                    MaxHeight = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexShrink = 1,
                            FlexBasis = 100

                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            Height = 50
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
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void child_min_max_width_flexing()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row,
                    Width = 120,
                    Height = 50
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            FlexBasis = 0,
                            MinWidth = 60
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            FlexBasis = 50f.Percent(),
                            MaxWidth = 20
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(120, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(100, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(20, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(120, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(20, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(20, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void min_width_overrides_width()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 50,
                    MinWidth = 100
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);
        }

        [Test]
        public void max_width_overrides_width()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 200,
                    MaxWidth = 100
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);
        }

        [Test]
        public void min_height_overrides_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Height = 50,
                    MinHeight = 100
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);
        }

        [Test]
        public void max_height_overrides_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Height = 200,
                    MaxHeight = 100
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);
        }

        [Test]
        public void min_max_percent_no_width_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    AlignItems = YogaAlign.FlexStart,
                    Width = 100,
                    Height = 100
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            MinWidth = 10.Percent(),
                            MaxWidth = 10.Percent(),
                            MinHeight = 10.Percent(),
                            MaxHeight = 10.Percent()
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
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }
    }
}
