using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAlignBaselineTest
    {
        static BaselineFunc _baselineFunc = (YogaNode node, float width, float height, object context) => { return height / 2; };

        static MeasureFunc _measure1 = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            return new YogaSize(42, 50);
        };

        static MeasureFunc _measure2 = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            return new YogaSize(279, 126);
        };

        // Test case for bug in T32999822
        [Test]
        public void align_baseline_parent_ht_not_specified()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 340);
            YGNodeStyleSetMaxHeight(root, 170);
            YGNodeStyleSetMinHeight(root, 0);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 0);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeSetMeasureFunc(root_child0, _measure1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 0);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeSetMeasureFunc(root_child1, _measure2);
            YGNodeInsertChild(root, root_child1, 1);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(340, root.Layout.Width);
            Assert.AreEqual(126, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(42, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);
            Assert.AreEqual(76, root_child0.Layout.Top);

            Assert.AreEqual(42, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(279, root_child1.Layout.Width);
            Assert.AreEqual(126, root_child1.Layout.Height);
        }

        [Test]
        public void align_baseline_with_no_parent_ht()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 150);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 40);
            YGNodeSetBaselineFunc(root_child1, _baselineFunc);
            YGNodeInsertChild(root, root_child1, 1);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(70, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(40, root_child1.Layout.Height);
        }

        [Test]
        public void align_baseline_with_no_baseline_func_and_no_parent_ht()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 150);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 80);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }
    }
}
