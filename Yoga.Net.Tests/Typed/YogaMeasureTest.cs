using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaMeasureTest
    {
        static MeasureFunc _measure = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            var nodeContext = node.Context;

            int measureCount = (int?)nodeContext ?? 0;
            measureCount++;
            node.Context = measureCount;

            return new YogaSize(10, 10);
        };

        static MeasureFunc _simulate_wrapping_text = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            if (widthMode == MeasureMode.Undefined || width >= 68)
            {
                return new YogaSize(68, 16);
            }

            return new YogaSize(50, 32);
        };

        static MeasureFunc _measure_assert_negative = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            Assert.GreaterOrEqual(width, 0);
            Assert.GreaterOrEqual(height, 0);

            return new YogaSize(0, 0);
        };

        [Test]
        public void dont_measure_single_grow_shrink_child()
        {
            YogaNode root_child0;
            YogaNode root = Node(width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure, flexGrow:1, flexShrink:1));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
        }

        [Test]
        public void measure_absolute_child_with_no_constraints()
        {
            YogaNode root_child0, root_child0_child0;
            YogaNode root = Node()
               .AddChild(root_child0 = Node()
                   .AddChild(root_child0_child0 = Node(positionType:PositionType.Absolute, measureFunc:_measure))
                );
            root_child0_child0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0_child0.Context);
        }

        [Test]
        public void dont_measure_when_min_equals_max()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure, minWidth:10, maxWidth:10, minHeight:10, maxHeight:10));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void dont_measure_when_min_equals_max_percentages()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure, minWidth:10, maxWidth:10, minHeight:10, maxHeight:10));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }


        [Test]
        public void measure_nodes_with_margin_auto_and_stretch()
        {
            YogaNode root_child0;
            YogaNode root = Node(width: 500, height: 500)
               .AddChild(root_child0 = Node(measureFunc:_measure, margin:new Edges(left:YogaValue.Auto)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(490, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void dont_measure_when_min_equals_max_mixed_width_percent()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure, minWidth:10.Percent(), maxWidth:10.Percent(), minHeight:10, maxHeight:10 ));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void dont_measure_when_min_equals_max_mixed_height_percent()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure, minWidth:10, maxWidth:10, minHeight:10.Percent(), maxHeight:10.Percent()));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void measure_enough_size_should_be_in_single_line()
        {
            YogaNode root_child0;
            YogaNode root = Node(width: 100)
               .AddChild(root_child0 = Node(measureFunc:_simulate_wrapping_text, alignSelf:YogaAlign.FlexStart));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(68, root_child0.Layout.Width);
            Assert.AreEqual(16, root_child0.Layout.Height);
        }

        [Test]
        public void measure_not_enough_size_should_wrap()
        {
            YogaNode root_child0;
            YogaNode root = Node(width: 55)
               .AddChild(root_child0 = Node(measureFunc:_simulate_wrapping_text, alignSelf:YogaAlign.FlexStart));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(32, root_child0.Layout.Height);
        }

        [Test]
        public void measure_zero_space_should_grow()
        {
            YogaNode root_child0;
            YogaNode root = Node(height: 200, flexDirection:FlexDirection.Column, flexGrow:0)
               .AddChild(root_child0 = Node(flexDirection:FlexDirection.Column, padding:new Edges(100), measureFunc:_measure));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, 282, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(282, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Top);
        }

        [Test]
        public void measure_flex_direction_row_and_padding()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection: FlexDirection.Row, padding: new Edges(25), width: 50, height: 50)
                           .AddChild(root_child0 = Node(config, measureFunc: _simulate_wrapping_text))
                           .AddChild(root_child1 = Node(config, width:5, height:5));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(25, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(25, root_child1.Layout.Top);
            Assert.AreEqual(5, root_child1.Layout.Width);
            Assert.AreEqual(5, root_child1.Layout.Height);
        }

        [Test]
        public void measure_flex_direction_column_and_padding()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, margin: new Edges(top: 20), padding: new Edges(25), width: 50, height: 50)
                           .AddChild(root_child0 = Node(config, measureFunc: _simulate_wrapping_text))
                           .AddChild(root_child1 = Node(config, width:5, height:5));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(25, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(32, root_child0.Layout.Height);

            Assert.AreEqual(25, root_child1.Layout.Left);
            Assert.AreEqual(57, root_child1.Layout.Top);
            Assert.AreEqual(5, root_child1.Layout.Width);
            Assert.AreEqual(5, root_child1.Layout.Height);
        }

        [Test]
        public void measure_flex_direction_row_no_padding()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, margin: new Edges(top: 20), width: 50, height: 50)
                           .AddChild(root_child0 = Node(config, measureFunc: _simulate_wrapping_text))
                           .AddChild(root_child1 = Node(config, width:5, height:5));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(5, root_child1.Layout.Width);
            Assert.AreEqual(5, root_child1.Layout.Height);
        }

        [Test]
        public void measure_flex_direction_row_no_padding_align_items_flexstart()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection: FlexDirection.Row, margin: new Edges(top: 20), width: 50, height: 50, alignItems:YogaAlign.FlexStart)
                           .AddChild(root_child0 = Node(config, measureFunc: _simulate_wrapping_text))
                           .AddChild(root_child1 = Node(config, width:5, height:5));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(32, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(5, root_child1.Layout.Width);
            Assert.AreEqual(5, root_child1.Layout.Height);
        }

        [Test]
        public void measure_with_fixed_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(margin: new Edges(top: 20), padding:new Edges(25), width: 50, height: 50)
                           .AddChild(root_child0 = Node(config, measureFunc: _simulate_wrapping_text, width:10, height:10))
                           .AddChild(root_child1 = Node(config, width:5, height:5));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(25, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(25, root_child1.Layout.Left);
            Assert.AreEqual(35, root_child1.Layout.Top);
            Assert.AreEqual(5, root_child1.Layout.Width);
            Assert.AreEqual(5, root_child1.Layout.Height);
        }

        [Test]
        public void measure_with_flex_shrink()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(margin: new Edges(top: 20), padding:new Edges(25), width: 50, height: 50)
                           .AddChild(root_child0 = Node(config, measureFunc: _simulate_wrapping_text, flexShrink:1))
                           .AddChild(root_child1 = Node(config, width:5, height:5));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(25, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(25, root_child1.Layout.Left);
            Assert.AreEqual(25, root_child1.Layout.Top);
            Assert.AreEqual(5, root_child1.Layout.Width);
            Assert.AreEqual(5, root_child1.Layout.Height);
        }

        [Test]
        public void measure_no_padding()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(margin: new Edges(top: 20), width: 50, height: 50)
                           .AddChild(root_child0 = Node(config, measureFunc: _simulate_wrapping_text, flexShrink:1))
                           .AddChild(root_child1 = Node(config, width:5, height:5));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(32, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(32, root_child1.Layout.Top);
            Assert.AreEqual(5, root_child1.Layout.Width);
            Assert.AreEqual(5, root_child1.Layout.Height);
        }

        [Test]
        public void can_nullify_measure_func_on_any_node()
        {
            YogaNode root = Node(measureFunc:null)
               .AddChild(Node());

            Assert.IsTrue(root.MeasureFunc == null);
        }

        [Test]
        public void cant_call_negative_measure()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection: FlexDirection.Column, width: 50, height: 10)
               .AddChild(root_child0 = Node(config, measureFunc: _measure_assert_negative, margin:new Edges(top:20)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
        }

        [Test]
        public void cant_call_negative_measure_horizontal()
        {
            YogaConfig config = new YogaConfig();

            var edge = new Edges {Start = 20};
            YogaNode root_child0, root_child1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 10, height: 20)
               .AddChild(root_child0 = Node(config, measureFunc: _measure_assert_negative, margin:new Edges {Start = 20}));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
        }

        static MeasureFunc _measure_90_10 = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            return new YogaSize(90, 10);
        };

        [Test]
        public void percent_with_text_node()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.SpaceBetween, alignItems:YogaAlign.Center, width: 100, height: 80)
                           .AddChild(root_child0 = Node(config))
                           .AddChild(root_child1 = Node(config, measureFunc:_measure_90_10, maxWidth:50.Percent(), padding:new Edges(top:50.Percent())));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(40, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(15, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }
    }
}
