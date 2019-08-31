using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGAspectRatioTest
    {
        static MeasureFunc _measure = (
            YGNode node,
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
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_main_defined()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_both_dimensions_defined_row()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_both_dimensions_defined_column()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_align_stretch()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_flex_grow()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_flex_shrink()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 150);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_flex_shrink_2()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeightPercent(root_child0, 100);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNew();
            YGNodeStyleSetHeightPercent(root_child1, 100);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetAspectRatio(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void aspect_ratio_basis()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_absolute_layout_width_defined()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 0);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 0);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_absolute_layout_height_defined()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 0);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 0);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_with_max_cross_defined()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetMaxWidth(root_child0, 40);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_with_max_main_defined()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetMaxHeight(root_child0, 40);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_with_min_cross_defined()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 30);
            YGNodeStyleSetMinWidth(root_child0, 40);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_with_min_main_defined()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetMinHeight(root_child0, 40);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_double_cross()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_half_cross()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0, 0.5f);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_double_main()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 0.5f);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_half_main()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_with_measure_func()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            root_child0.SetMeasureFunc(_measure);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_width_height_flex_grow_row()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 200);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_width_height_flex_grow_column()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_height_as_flex_basis()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNew();
            YGNodeStyleSetHeight(root_child1, 100);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetAspectRatio(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(75, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(125, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(125, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void aspect_ratio_width_as_flex_basis()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNew();
            YGNodeStyleSetWidth(root_child1, 100);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetAspectRatio(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(75, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(125, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(125, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void aspect_ratio_overrides_flex_grow_row()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 0.5f);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_overrides_flex_grow_column()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_left_right_absolute()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Right, 10);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_top_bottom_absolute()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetPositionType(root_child0, PositionType.Absolute);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 10);
            YGNodeStyleSetPosition(root_child0, Edge.Bottom, 10);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_width_overrides_align_stretch_row()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_height_overrides_align_stretch_column()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_allow_child_overflow_parent_size()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 4);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_defined_main_with_margin()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Right, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_defined_cross_with_margin()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Right, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void aspect_ratio_defined_cross_with_main_margin()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetAspectRatio(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, Edge.Top, 10);
            YGNodeStyleSetMargin(root_child0, Edge.Bottom, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
        }

        /*
        [Test] public void aspect_ratio_should_prefer_explicit_height() {
            YGConfig config = YGConfigNew();
            YGConfigSetUseWebDefaults(config, true);

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Column);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Column);
            YGNodeStyleSetHeight(root_child0_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0_child0, 2);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeCalculateLayout(root, 100, 200, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            
        }
        */

        /*
        [Test] public void aspect_ratio_should_prefer_explicit_width() {
            YGConfig config = YGConfigNew();
            YGConfigSetUseWebDefaults(config, true);

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Row);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0_child0, 0.5f);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeCalculateLayout(root, 200, 100, Direction.LTR);

            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0_child0));

            
        }
        */

        /*
        [Test] public void aspect_ratio_should_prefer_flexed_dimension() {
            YGConfig config = YGConfigNew();
            YGConfigSetUseWebDefaults(config, true);

            YGNode root = YGNodeNewWithConfig(config);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Column);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAspectRatio(root_child0_child0, 4);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0_child0));

            
        }
        */
    }
}
