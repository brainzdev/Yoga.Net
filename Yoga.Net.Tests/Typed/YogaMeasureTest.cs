using NUnit.Framework;

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

            int measureCount = nodeContext == null ? 0 : (int)nodeContext;
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
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
        }

        [Test]
        public void measure_absolute_child_with_no_constraints()
        {
            YogaNode root = YGNodeNew();

            YogaNode root_child0 = YGNodeNew();
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNew();
            YGNodeStyleSetPositionType(root_child0_child0, PositionType.Absolute);
            root_child0_child0.Context = 0;
            YGNodeSetMeasureFunc(root_child0_child0, _measure);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0_child0.Context);
        }

        [Test]
        public void dont_measure_when_min_equals_max()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeStyleSetMinWidth(root_child0, 10);
            YGNodeStyleSetMaxWidth(root_child0, 10);
            YGNodeStyleSetMinHeight(root_child0, 10);
            YGNodeStyleSetMaxHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void dont_measure_when_min_equals_max_percentages()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeStyleSetMinWidthPercent(root_child0, 10);
            YGNodeStyleSetMaxWidthPercent(root_child0, 10);
            YGNodeStyleSetMinHeightPercent(root_child0, 10);
            YGNodeStyleSetMaxHeightPercent(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));
        }


        [Test]
        public void measure_nodes_with_margin_auto_and_stretch()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = YGNodeNew();
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeStyleSetMarginAuto(root_child0, Edge.Left);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(490, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void dont_measure_when_min_equals_max_mixed_width_percent()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeStyleSetMinWidthPercent(root_child0, 10);
            YGNodeStyleSetMaxWidthPercent(root_child0, 10);
            YGNodeStyleSetMinHeight(root_child0, 10);
            YGNodeStyleSetMaxHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void dont_measure_when_min_equals_max_mixed_height_percent()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeStyleSetMinWidth(root_child0, 10);
            YGNodeStyleSetMaxWidth(root_child0, 10);
            YGNodeStyleSetMinHeightPercent(root_child0, 10);
            YGNodeStyleSetMaxHeightPercent(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)root_child0.Context);
            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void measure_enough_size_should_be_in_single_line()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNew();
            YGNodeStyleSetAlignSelf(root_child0, YogaAlign.FlexStart);
            YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);

            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(68, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(16, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void measure_not_enough_size_should_wrap()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 55);

            YogaNode root_child0 = YGNodeNew();
            YGNodeStyleSetAlignSelf(root_child0, YogaAlign.FlexStart);
            //  YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(32, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void measure_zero_space_should_grow()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetHeight(root, 200);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);
            YGNodeStyleSetFlexGrow(root, 0);

            YogaNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Column);
            YGNodeStyleSetPadding(root_child0, Edge.All, 100);
            root_child0.Context = 0;
            YGNodeSetMeasureFunc(root_child0, _measure);

            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 282, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(282, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
        }

        [Test]
        public void measure_flex_direction_row_and_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetPadding(root, Edge.Left, 25);
            YGNodeStyleSetPadding(root, Edge.Top, 25);
            YGNodeStyleSetPadding(root, Edge.Right, 25);
            YGNodeStyleSetPadding(root, Edge.Bottom, 25);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            //  YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 5);
            YGNodeStyleSetHeight(root_child1, 5);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(25, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(75, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void measure_flex_direction_column_and_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetPadding(root, Edge.All, 25);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            //  YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 5);
            YGNodeStyleSetHeight(root_child1, 5);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(25, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(32, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(57, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void measure_flex_direction_row_no_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            //  YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 5);
            YGNodeStyleSetHeight(root_child1, 5);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void measure_flex_direction_row_no_padding_align_items_flexstart()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 5);
            YGNodeStyleSetHeight(root_child1, 5);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(32, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void measure_with_fixed_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetPadding(root, Edge.All, 25);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 5);
            YGNodeStyleSetHeight(root_child1, 5);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(25, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(35, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void measure_with_flex_shrink()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetPadding(root, Edge.All, 25);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 5);
            YGNodeStyleSetHeight(root_child1, 5);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(25, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void measure_no_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 5);
            YGNodeStyleSetHeight(root_child1, 5);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(32, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(32, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(root_child1));
        }

#if GTEST_HAS_DEATH_TEST
TEST(YogaDeathTest, cannot_add_child_to_node_with_measure_func() {
  YogaNode root = YGNodeNew();
  root.setMeasureFunc(_measure);

  YogaNode root_child0 = YGNodeNew();
  ASSERT_DEATH(YGNodeInsertChild(root, root_child0, 0), "Cannot add child.*");
  YGNodeFree(root_child0);
  
}

TEST(YogaDeathTest, cannot_add_nonnull_measure_func_to_non_leaf_node() {
  YogaNode root = YGNodeNew();
  YogaNode root_child0 = YGNodeNew();
  YGNodeInsertChild(root, root_child0, 0);
  ASSERT_DEATH(root.setMeasureFunc(_measure), "Cannot set measure function.*");
  
}

#endif

        [Test]
        public void can_nullify_measure_func_on_any_node()
        {
            YogaNode root = YGNodeNew();
            YGNodeInsertChild(root, YGNodeNew(), 0);
            YGNodeSetMeasureFunc(root, null);
            Assert.IsTrue(root.MeasureFunc == null);
        }

        [Test]
        public void cant_call_negative_measure()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 10);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(root_child0, _measure_assert_negative);
            YGNodeStyleSetMargin(root_child0, Edge.Top, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
        }

        [Test]
        public void cant_call_negative_measure_horizontal()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 10);
            YGNodeStyleSetHeight(root, 20);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(root_child0, _measure_assert_negative);
            YGNodeStyleSetMargin(root_child0, Edge.Start, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
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
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceBetween);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 80);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(root_child1, _measure_90_10);
            YGNodeStyleSetMaxWidthPercent(root_child1, 50);
            YGNodeStyleSetPaddingPercent(root_child1, Edge.Top, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(15, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));
        }
    }
}
