using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGMeasureCacheTest
    {
        static MeasureFunc _measureMax = (
            YGNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            int measureCount = (int)node.Context;
            measureCount++;
            node.Context = measureCount;

            return new YogaSize(
                widthMode == MeasureMode.Undefined ? 10 : width,
                heightMode == MeasureMode.Undefined ? 10 : height);
        };

        static MeasureFunc _measureMin = (
            YGNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            int measureCount = (int)node.Context;
            measureCount = measureCount + 1;
            node.Context = measureCount;
            return new YogaSize(
                widthMode == MeasureMode.Undefined || (widthMode == MeasureMode.AtMost && width > 10)
                    ? 10
                    : width,
                heightMode == MeasureMode.Undefined || (heightMode == MeasureMode.AtMost && height > 10)
                    ? 10
                    : height);
        };

        static MeasureFunc _measure_84_49 = (
            YGNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            int measureCount = (int)node.Context;
            measureCount++;
            node.Context = measureCount;

            return new YogaSize(84f, 49f);
        };

        [Test]
        public void measure_once_single_flexible_child()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            root_child0.SetMeasureFunc(_measureMax);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_same_exact_width_larger_than_needed_height()
        {
            YGNode root = YGNodeNew();

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            root_child0.SetMeasureFunc(_measureMin);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);
            YGNodeCalculateLayout(root, 100, 50, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_same_atmost_width_larger_than_needed_height()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            root_child0.SetMeasureFunc(_measureMin);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);
            YGNodeCalculateLayout(root, 100, 50, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_computed_width_larger_than_needed_height()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            root_child0.SetMeasureFunc(_measureMin);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);
            YGNodeStyleSetAlignItems(root, YogaAlign.Stretch);
            YGNodeCalculateLayout(root, 10, 50, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_atmost_computed_width_undefined_height()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = 0;
            root_child0.SetMeasureFunc(_measureMin);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 100, YogaValue.YGUndefined, Direction.LTR);
            YGNodeCalculateLayout(root, 10, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_already_measured_value_smaller_but_still_float_equal()
        {
            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 288f);
            YGNodeStyleSetHeight(root, 288f);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetPadding(root_child0, Edge.All, 2.88f);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNew();
            root_child0_child0.Context = 0;
            root_child0_child0.SetMeasureFunc(_measure_84_49);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);


            Assert.AreEqual(1, (int)root_child0_child0.Context);
        }
    }
}
