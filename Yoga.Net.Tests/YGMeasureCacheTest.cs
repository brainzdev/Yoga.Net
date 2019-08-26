using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;

namespace Yoga.Net
{
    [TestFixture]
    public class YGMeasureCacheTest
    {

        static YGMeasureFunc _measureMax = (YGNodeRef node,
                                  float width,
                                  YGMeasureMode widthMode,
                                  float height,
                                  YGMeasureMode heightMode,
            object context) =>
        {
            int measureCount = (int)node.getContext();
            measureCount++;
            node.setContext(measureCount);

            return new YGSize(
                widthMode == YGMeasureMode.Undefined ? 10 : width,
                heightMode == YGMeasureMode.Undefined ? 10 : height);
        };

        static YGMeasureFunc _measureMin = (YGNodeRef node,
                                  float width,
                                  YGMeasureMode widthMode,
                                  float height,
                                  YGMeasureMode heightMode, object context) =>
        {
            int measureCount = (int)node.getContext();
            measureCount = measureCount + 1;
            node.setContext(measureCount);
            return new YGSize(
                widthMode == YGMeasureMode.Undefined || (widthMode == YGMeasureMode.AtMost && width > 10)
                    ? 10
                    : width,
          heightMode == YGMeasureMode.Undefined || (heightMode == YGMeasureMode.AtMost && height > 10)
              ? 10
              : height);
        };

        static YGMeasureFunc _measure_84_49 = (YGNodeRef node,
                                     float width,
                                     YGMeasureMode widthMode,
                                     float height,
                                     YGMeasureMode heightMode,
            object context) =>
        {
            int measureCount = (int)node.getContext();
            measureCount++;
            node.setContext(measureCount);

            return new YGSize(84f, 49f);
        };

        [Test] public void measure_once_single_flexible_child() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(0);
            root_child0.setMeasureFunc(_measureMax);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, (int)root_child0.getContext());

            YGNodeFreeRecursive(root);
        }

        [Test] public void remeasure_with_same_exact_width_larger_than_needed_height() {
            YGNodeRef root = YGNodeNew();

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(0);
            root_child0.setMeasureFunc(_measureMin);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 100, 100, YGDirection.LTR);
            YGNodeCalculateLayout(root, 100, 50, YGDirection.LTR);

            Assert.AreEqual(1, (int)root_child0.getContext());

            YGNodeFreeRecursive(root);
        }

        [Test] public void remeasure_with_same_atmost_width_larger_than_needed_height() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(0);
            root_child0.setMeasureFunc(_measureMin);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 100, 100, YGDirection.LTR);
            YGNodeCalculateLayout(root, 100, 50, YGDirection.LTR);

            Assert.AreEqual(1, (int)root_child0.getContext());

            YGNodeFreeRecursive(root);
        }

        [Test] public void remeasure_with_computed_width_larger_than_needed_height() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(0);
            root_child0.setMeasureFunc(_measureMin);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 100, 100, YGDirection.LTR);
            YGNodeStyleSetAlignItems(root, YGAlign.Stretch);
            YGNodeCalculateLayout(root, 10, 50, YGDirection.LTR);

            Assert.AreEqual(1, (int)root_child0.getContext());

            YGNodeFreeRecursive(root);
        }

        [Test] public void remeasure_with_atmost_computed_width_undefined_height() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(0);
            root_child0.setMeasureFunc(_measureMin);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 100, YGValue.YGUndefined, YGDirection.LTR);
            YGNodeCalculateLayout(root, 10, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, (int)root_child0.getContext());

            YGNodeFreeRecursive(root);
        }

        [Test] public void remeasure_with_already_measured_value_smaller_but_still_float_equal() {

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetWidth(root, 288f);
            YGNodeStyleSetHeight(root, 288f);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);

            YGNodeRef root_child0 = YGNodeNew();
            YGNodeStyleSetPadding(root_child0, YGEdge.All, 2.88f);
            YGNodeStyleSetFlexDirection(root_child0, YGFlexDirection.Row);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child0_child0 = YGNodeNew();
            root_child0_child0.setContext(0);
            root_child0_child0.setMeasureFunc(_measure_84_49);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            YGNodeFreeRecursive(root);

            Assert.AreEqual(1, (int)root_child0_child0.getContext());
        }
    }
}
