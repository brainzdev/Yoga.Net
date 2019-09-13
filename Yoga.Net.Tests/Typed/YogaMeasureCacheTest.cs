using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaMeasureCacheTest
    {
        static MeasureFunc _measureMax = (
            YogaNode node,
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
            YogaNode node,
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
            YogaNode node,
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
            YogaNode root_child0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measureMax, flexGrow:1));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_same_exact_width_larger_than_needed_height()
        {
            YogaNode root_child0;
            YogaNode root = Node(width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measureMin));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);
            YogaArrange.CalculateLayout(root, 100, 50, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_same_atmost_width_larger_than_needed_height()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart)
               .AddChild(root_child0 = Node(measureFunc:_measureMin));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);
            YogaArrange.CalculateLayout(root, 100, 50, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_computed_width_larger_than_needed_height()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart)
               .AddChild(root_child0 = Node(measureFunc:_measureMin));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);
            root.Style.AlignItems = YogaAlign.Stretch;

            YogaArrange.CalculateLayout(root, 10, 50, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_atmost_computed_width_undefined_height()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart)
               .AddChild(root_child0 = Node(measureFunc:_measureMin));
            root_child0.Context = 0;

            YogaArrange.CalculateLayout(root, 100, YogaValue.YGUndefined, Direction.LTR);
            YogaArrange.CalculateLayout(root, 10, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0.Context);
        }

        [Test]
        public void remeasure_with_already_measured_value_smaller_but_still_float_equal()
        {
            YogaNode root_child0, root_child0_child0;
            YogaNode root = Node(width: 288, height: 288, flexDirection:FlexDirection.Row)
               .AddChild(root_child0 = Node(padding:new Edges(2.88f), flexDirection:FlexDirection.Row)
                   .AddChild(root_child0_child0 = Node(measureFunc:_measure_84_49))
                );
            root_child0_child0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)root_child0_child0.Context);
        }
    }
}
