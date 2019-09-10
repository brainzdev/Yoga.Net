using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAspectRatioTest
    {
        static MeasureFunc _measure = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            return new YogaSize(
                widthMode == MeasureMode.Exactly ? width : 50,
                heightMode == MeasureMode.Exactly ? height : 50);
        };

        [Test]
        public void aspect_ratio_cross_defined()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_main_defined()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_both_dimensions_defined_row()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_both_dimensions_defined_column()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_align_stretch()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_flex_grow()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_flex_shrink()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 150);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_flex_shrink_2()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeightPercent(root_child0, 100);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode();
            YGNodeStyleSetHeightPercent(root_child1, 100);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetAspectRatio(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void aspect_ratio_basis()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_absolute_layout_width_defined()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 0);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 0);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_absolute_layout_height_defined()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 0);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 0);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_max_cross_defined()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetMaxWidth(root_child0, 40);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(40, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_max_main_defined()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetMaxHeight(root_child0, 40);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(40, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_min_cross_defined()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 30);
            YGNodeStyleSetMinWidth(root_child0, 40);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(40, root_child0.Layout.Width);
            Assert.AreEqual(30, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_min_main_defined()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetMinHeight(root_child0, 40);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(40, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_double_cross()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_half_cross()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0, 0.5f);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_double_main()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 0.5f);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_half_main()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_measure_func()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_width_height_flex_grow_row()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_width_height_flex_grow_column()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_height_as_flex_basis()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode();
            YGNodeStyleSetHeight(root_child1, 100);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetAspectRatio(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(75, root_child0.Layout.Width);
            Assert.AreEqual(75, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(125, root_child1.Layout.Width);
            Assert.AreEqual(125, root_child1.Layout.Height);
        }

        [Test]
        public void aspect_ratio_width_as_flex_basis()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode();
            YGNodeStyleSetWidth(root_child1, 100);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetAspectRatio(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(75, root_child0.Layout.Width);
            Assert.AreEqual(75, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(75, root_child1.Layout.Top);
            Assert.AreEqual(125, root_child1.Layout.Width);
            Assert.AreEqual(125, root_child1.Layout.Height);
        }

        [Test]
        public void aspect_ratio_overrides_flex_grow_row()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 0.5f);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_overrides_flex_grow_column()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_left_right_absolute()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Right, 10);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_top_bottom_absolute()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Bottom, 10);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(80, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_width_overrides_align_stretch_row()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_height_overrides_align_stretch_column()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_allow_child_overflow_parent_size()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 4);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_defined_main_with_margin()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Right, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_defined_cross_with_margin()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Right, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_defined_cross_with_main_margin()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Top, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Bottom, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
        }

        /*
        [Test] public void aspect_ratio_should_prefer_explicit_height() {
            YGConfig config = new YogaConfig();
            YGConfigSetUseWebDefaults(config, true);

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Column);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Column);
            YGNodeStyleSetHeight(root_child0_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0_child0, 2);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaArrange.CalculateLayout(root, 100, 200, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            
        }
        */

        /*
        [Test] public void aspect_ratio_should_prefer_explicit_width() {
            YGConfig config = new YogaConfig();
            YGConfigSetUseWebDefaults(config, true);

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Row);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0_child0, 0.5f);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaArrange.CalculateLayout(root, 200, 100, Direction.LTR);

            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);

            
        }
        */

        /*
        [Test] public void aspect_ratio_should_prefer_flexed_dimension() {
            YGConfig config = new YogaConfig();
            YGConfigSetUseWebDefaults(config, true);

            YogaNode root = new YogaNode(config);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Column);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetAspectRatio(root_child0_child0, 4);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            
        }
        */
    }
}
