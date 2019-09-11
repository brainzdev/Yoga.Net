using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaRoundingTest
    {
        [Test]
        public void rounding_flex_basis_flex_grow_row_width_of_100()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = new YogaNode()
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
                            FlexGrow = 1
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1
                        }
                    })
                }
            };
            /*
            <Node x:Name=root FlexDirection="Row" Width=100 Height=100>
                <Node x:Name=root_child0 FlexGrow=1 />
                <Node x:Name=root_child1 FlexGrow=1 />
                <Node x:Name=root_child2 FlexGrow=1 />
            </Node>
             */

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(33, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(33, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(34, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(67, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(33, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(67, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(33, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(33, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(34, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(33, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_flex_basis_flex_grow_row_prime_number_width()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row,
                    Width         = 113,
                    Height        = 100
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
                            FlexGrow = 1
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1
                        }
                    }),
                    (root_child3 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1
                        }
                    }),
                    (root_child4 = new YogaNode
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
            Assert.AreEqual(113, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(23, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(23, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(22, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(45, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(23, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(68, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(22, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(90, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(23, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(113, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(23, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(68, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(22, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(45, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(23, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(23, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(22, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(23, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);
        }

        [Test]
        public void rounding_flex_basis_flex_shrink_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = new YogaNode()
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row,
                    Width         = 101,
                    Height        = 100
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
                            FlexBasis = 25
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexBasis = 25
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(101, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(51, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(51, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(25, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(76, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(25, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(101, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(51, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(25, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(25, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(25, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_flex_basis_overrides_main_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = new YogaNode()
            {
                Style = new YogaStyle
                {
                    Width         = 100,
                    Height        = 113
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            FlexBasis = 50,
                            Height = 20
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height = 10

                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height = 10
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_total_fractial()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width         = 87.4f,
                    Height        = 113.4f
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 0.7f,
                            FlexBasis = 50.3f,
                            Height = 20.3f
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1.6f,
                            Height = 10
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1.1f,
                            Height = 10.7f
                        }
                    })
                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(87, root_child0.Layout.Width);
            Assert.AreEqual(59, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(59, root_child1.Layout.Top);
            Assert.AreEqual(87, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(87, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(87, root_child0.Layout.Width);
            Assert.AreEqual(59, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(59, root_child1.Layout.Top);
            Assert.AreEqual(87, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(87, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_total_fractial_nested()
        {
            YogaConfig config = new YogaConfig();

            
            YogaNode root_child0, root_child1, root_child2, root_child0_child0, root_child0_child1;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 87.4f,
                    Height= 113.4f
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 0.7f,
                            FlexBasis = 50.3f,
                            Height = 20.3f
                        },
                        Children =
                        {
                            (root_child0_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    FlexBasis = 0.3f,
                                    Bottom = 13.3f,
                                    Height = 9.9f
                                }
                            }),
                            (root_child0_child1 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow  = 4,
                                    FlexBasis = 0.3f,
                                    Top       = 13.3f,
                                    Height    = 1.1f
                                }
                            })
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow  = 1.6f,
                            Height    = 10f
                        },
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1.1f,
                            Height   = 10.7f
                        },
                    })

                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(87, root_child0.Layout.Width);
            Assert.AreEqual(59, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(-13, root_child0_child0.Layout.Top);
            Assert.AreEqual(87, root_child0_child0.Layout.Width);
            Assert.AreEqual(12, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(25, root_child0_child1.Layout.Top);
            Assert.AreEqual(87, root_child0_child1.Layout.Width);
            Assert.AreEqual(47, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(59, root_child1.Layout.Top);
            Assert.AreEqual(87, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(87, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(87, root_child0.Layout.Width);
            Assert.AreEqual(59, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(-13, root_child0_child0.Layout.Top);
            Assert.AreEqual(87, root_child0_child0.Layout.Width);
            Assert.AreEqual(12, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(25, root_child0_child1.Layout.Top);
            Assert.AreEqual(87, root_child0_child1.Layout.Width);
            Assert.AreEqual(47, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(59, root_child1.Layout.Top);
            Assert.AreEqual(87, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(87, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_fractial_input_1()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width = 100,
                    Height = 113.4f
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            FlexBasis = 50,
                            Height = 20
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height = 10
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height = 10
                        }
                    })

                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_fractial_input_2()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Width  = 100,
                    Height = 113.6f
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow  = 1,
                            FlexBasis = 50,
                            Height    = 20
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 10
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 10
                        }
                    })

                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(65, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(65, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(24, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(25, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(65, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(65, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(24, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(25, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_fractial_input_3()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Top = 0.3f,
                    Width  = 100,
                    Height = 113.4f
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow  = 1,
                            FlexBasis = 50,
                            Height    = 20
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 10
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 10
                        }
                    })

                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(65, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(24, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(25, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(65, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(24, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(25, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_fractial_input_4()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Top = 0.7f,
                    Width  = 100,
                    Height = 113.4f
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow  = 1,
                            FlexBasis = 50,
                            Height    = 20
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 10
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 10
                        }
                    })

                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(1, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(1, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_inner_node_controversy_horizontal()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2, root_child1_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row,
                    Width = 320
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow  = 1,
                            Height    = 10
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 10
                        },
                        Children =
                        {
                            (root_child1_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    Height = 10
                                }
                            })
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 10
                        }
                    })

                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(320, root.Layout.Width);
            Assert.AreEqual(10, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(107, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(107, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(106, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(106, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(213, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(107, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(320, root.Layout.Width);
            Assert.AreEqual(10, root.Layout.Height);

            Assert.AreEqual(213, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(107, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(107, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(106, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(106, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(107, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_inner_node_controversy_vertical()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2, root_child1_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Height = 320
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Width   = 10
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Width   = 10
                        },
                        Children =
                        {
                            (root_child1_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    Width   = 10
                                }
                            })
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Width   = 10
                        }
                    })

                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(10, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(107, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(107, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(106, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(10, root_child1_child0.Layout.Width);
            Assert.AreEqual(106, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(213, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(107, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(10, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(107, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(107, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(106, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(10, root_child1_child0.Layout.Width);
            Assert.AreEqual(106, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(213, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(107, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_inner_node_controversy_combined()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2, root_child1_child0, root_child1_child1, root_child1_child2, root_child1_child1_child0;
            YogaNode root = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    FlexDirection = FlexDirection.Row,
                    Width = 640,
                    Height = 320
                },
                Children =
                {
                    (root_child0 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 100.Percent()
                        }
                    }),
                    (root_child1 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 100.Percent()
                        },
                        Children =
                        {
                            (root_child1_child0 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    Width   = 100.Percent()
                                }
                            }),
                            (root_child1_child1 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    Width    = 100.Percent()
                                },
                                Children =
                                {
                                    (root_child1_child1_child0 = new YogaNode
                                    {
                                        Style = new YogaStyle
                                        {
                                            FlexGrow = 1,
                                            Width = 100.Percent()
                                        }
                                    })
                                }
                            }),
                            (root_child1_child2 = new YogaNode
                            {
                                Style = new YogaStyle
                                {
                                    FlexGrow = 1,
                                    Width    = 100.Percent()
                                }
                            })
                        }
                    }),
                    (root_child2 = new YogaNode
                    {
                        Style = new YogaStyle
                        {
                            FlexGrow = 1,
                            Height   = 100.Percent()
                        }
                    })

                }
            };

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(640, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(213, root_child0.Layout.Width);
            Assert.AreEqual(320, root_child0.Layout.Height);

            Assert.AreEqual(213, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(214, root_child1.Layout.Width);
            Assert.AreEqual(320, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(214, root_child1_child0.Layout.Width);
            Assert.AreEqual(107, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(107, root_child1_child1.Layout.Top);
            Assert.AreEqual(214, root_child1_child1.Layout.Width);
            Assert.AreEqual(106, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child1_child0.Layout.Top);
            Assert.AreEqual(214, root_child1_child1_child0.Layout.Width);
            Assert.AreEqual(106, root_child1_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child2.Layout.Left);
            Assert.AreEqual(213, root_child1_child2.Layout.Top);
            Assert.AreEqual(214, root_child1_child2.Layout.Width);
            Assert.AreEqual(107, root_child1_child2.Layout.Height);

            Assert.AreEqual(427, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(213, root_child2.Layout.Width);
            Assert.AreEqual(320, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(640, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(427, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(213, root_child0.Layout.Width);
            Assert.AreEqual(320, root_child0.Layout.Height);

            Assert.AreEqual(213, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(214, root_child1.Layout.Width);
            Assert.AreEqual(320, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(214, root_child1_child0.Layout.Width);
            Assert.AreEqual(107, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(107, root_child1_child1.Layout.Top);
            Assert.AreEqual(214, root_child1_child1.Layout.Width);
            Assert.AreEqual(106, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child1_child0.Layout.Top);
            Assert.AreEqual(214, root_child1_child1_child0.Layout.Width);
            Assert.AreEqual(106, root_child1_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child2.Layout.Left);
            Assert.AreEqual(213, root_child1_child2.Layout.Top);
            Assert.AreEqual(214, root_child1_child2.Layout.Width);
            Assert.AreEqual(107, root_child1_child2.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(213, root_child2.Layout.Width);
            Assert.AreEqual(320, root_child2.Layout.Height);
        }
    }
}
