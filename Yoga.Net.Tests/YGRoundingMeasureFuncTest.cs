using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;

namespace Yoga.Net
{
    [TestFixture]
    public class YGRoundingMeasureFuncTest
    {

        static YGMeasureFunc _measureFloor = (YGNodeRef node,
                                    float width,
                                    YGMeasureMode widthMode,
                                    float height,
                                    YGMeasureMode heightMode,
            object context) =>
            {
                return new YGSize(10.2f, 10.2f);
            };

        static YGMeasureFunc _measureCeil = (YGNodeRef node,
                                   float width,
                                   YGMeasureMode widthMode,
                                   float height,
                                   YGMeasureMode heightMode,
            object context) =>
        {
            return new YGSize(10.5f, 10.5f);
        };

        static YGMeasureFunc _measureFractial = (YGNodeRef node,
          float width,
          YGMeasureMode widthMode,
          float height,
          YGMeasureMode heightMode, object context) =>
            {
                return new YGSize(0.5f, 0.5f);
            };

        [Test] public void rounding_feature_with_custom_measure_func_floor() {
            YGConfigRef config = YGConfigNew();
            YGNodeRef root = YGNodeNewWithConfig(config);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            root_child0.setMeasureFunc(_measureFloor);
            YGNodeInsertChild(root, root_child0, 0);

            YGConfigSetPointScaleFactor(config, 0.0f);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(10.2, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10.2, YGNodeLayoutGetHeight(root_child0));

            YGConfigSetPointScaleFactor(config, 1.0f);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(11, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(11, YGNodeLayoutGetHeight(root_child0));

            YGConfigSetPointScaleFactor(config, 2.0f);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(10.5, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10.5, YGNodeLayoutGetHeight(root_child0));

            YGConfigSetPointScaleFactor(config, 4.0f);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(10.25, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10.25, YGNodeLayoutGetHeight(root_child0));

            YGConfigSetPointScaleFactor(config, 1.0f / 3.0f);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(12.0, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(12.0, YGNodeLayoutGetHeight(root_child0));

            YGNodeFreeRecursive(root);

            YGConfigFree(config);
        }

        [Test] public void rounding_feature_with_custom_measure_func_ceil() {
            YGConfigRef config = YGConfigNew();
            YGNodeRef root = YGNodeNewWithConfig(config);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            root_child0.setMeasureFunc(_measureCeil);
            YGNodeInsertChild(root, root_child0, 0);
            YGConfigSetPointScaleFactor(config, 1.0f);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(11, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(11, YGNodeLayoutGetHeight(root_child0));

            YGNodeFreeRecursive(root);

            YGConfigFree(config);
        }

        [Test] public void rounding_feature_with_custom_measure_and_fractial_matching_scale() {
            YGConfigRef config = YGConfigNew();
            YGNodeRef root = YGNodeNewWithConfig(config);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPosition(root_child0, YGEdge.Left, 73.625f);
            root_child0.setMeasureFunc(_measureFractial);
            YGNodeInsertChild(root, root_child0, 0);

            YGConfigSetPointScaleFactor(config, 2.0f);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0.5, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0.5, YGNodeLayoutGetHeight(root_child0));
            Assert.AreEqual(73.5, YGNodeLayoutGetLeft(root_child0));

            YGNodeFreeRecursive(root);

            YGConfigFree(config);
        }
    }
}
