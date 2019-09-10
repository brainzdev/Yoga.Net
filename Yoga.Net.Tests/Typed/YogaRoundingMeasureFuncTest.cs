using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaRoundingMeasureFuncTest
    {
        static MeasureFunc _measureFloor = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            return new YogaSize(10.2f, 10.2f);
        };

        static MeasureFunc _measureCeil = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            return new YogaSize(10.5f, 10.5f);
        };

        static MeasureFunc _measureFractial = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            return new YogaSize(0.5f, 0.5f);
        };

        [Test]
        public void rounding_feature_with_custom_measure_func_floor()
        {
            YogaConfig config = new YogaConfig();
            YogaNode root = new YogaNode(config);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeSetMeasureFunc(root_child0, _measureFloor);
            YGNodeInsertChild(root, root_child0, 0);

            config.PointScaleFactor = 0.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(10.2f, root_child0.Layout.Width);
            Assert.AreEqual(10.2f, root_child0.Layout.Height);

            config.PointScaleFactor = 1.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(11f, root_child0.Layout.Width);
            Assert.AreEqual(11f, root_child0.Layout.Height);

            config.PointScaleFactor = 2.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(10.5f, root_child0.Layout.Width);
            Assert.AreEqual(10.5f, root_child0.Layout.Height);

            config.PointScaleFactor = 4.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10.25f, root_child0.Layout.Width);
            Assert.AreEqual(10.25f, root_child0.Layout.Height);

            config.PointScaleFactor = 1.0f / 3.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(12.0f, root_child0.Layout.Width);
            Assert.AreEqual(12.0f, root_child0.Layout.Height);
        }

        [Test]
        public void rounding_feature_with_custom_measure_func_ceil()
        {
            YogaConfig config = new YogaConfig();
            YogaNode root = new YogaNode(config);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeSetMeasureFunc(root_child0, _measureCeil);
            YGNodeInsertChild(root, root_child0, 0);
            config.PointScaleFactor = 1.0f);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(11, root_child0.Layout.Width);
            Assert.AreEqual(11, root_child0.Layout.Height);
        }

        [Test]
        public void rounding_feature_with_custom_measure_and_fractial_matching_scale()
        {
            YogaConfig config = new YogaConfig();
            YogaNode root = new YogaNode(config);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetPosition(root_child0, Edge.Left, 73.625f);
            YGNodeSetMeasureFunc(root_child0, _measureFractial);
            YGNodeInsertChild(root, root_child0, 0);

            config.PointScaleFactor = 2.0f);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0.5, root_child0.Layout.Width);
            Assert.AreEqual(0.5, root_child0.Layout.Height);
            Assert.AreEqual(73.5, root_child0.Layout.Left);
        }
    }
}
