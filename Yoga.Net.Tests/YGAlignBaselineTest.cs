using NUnit.Framework;
using static Yoga.Net.YogaGlobal;



namespace Yoga.Net.Tests
{

    [TestFixture]
    public class YGAlignBaselineTest
    {
        static YGBaselineFunc _baselineFunc = (YGNode node, float width, float height, object context) =>
        {
            return height / 2;
        };

        static YGMeasureFunc _measure1 = (
        YGNode node,
        float width,
        YGMeasureMode widthMode,
        float height,
        YGMeasureMode heightMode,
            object context) =>
        {
            return new YogaSize(42, 50);
        };

        static YGMeasureFunc _measure2 = (
            YGNode node,
            float width,
            YGMeasureMode widthMode,
            float height,
            YGMeasureMode heightMode, object context) =>
        {
            return new YogaSize(279, 126);
        };

        // Test case for bug in T32999822
        [Test]
        public void align_baseline_parent_ht_not_specified()
        {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetAlignItems(root, YGAlign.Baseline);
            YGNodeStyleSetWidth(root, 340);
            YGNodeStyleSetMaxHeight(root, 170);
            YGNodeStyleSetMinHeight(root, 0);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 0);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeSetMeasureFunc(root_child0, _measure1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 0);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeSetMeasureFunc(root_child1, _measure2);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(340, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(126, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(42, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));
            Assert.AreEqual(76, YGNodeLayoutGetTop(root_child0));

            Assert.AreEqual(42, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(279, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(126, YGNodeLayoutGetHeight(root_child1));

            

            
        }

        [Test]
        public void align_baseline_with_no_parent_ht()
        {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YGAlign.Baseline);
            YGNodeStyleSetWidth(root, 150);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 40);
            YGNodeSetBaselineFunc(root_child1, _baselineFunc);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(70, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child1));

            

            
        }

        [Test]
        public void align_baseline_with_no_baseline_func_and_no_parent_ht()
        {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YGAlign.Baseline);
            YGNodeStyleSetWidth(root, 150);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 80);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            

            
        }
    }
}
