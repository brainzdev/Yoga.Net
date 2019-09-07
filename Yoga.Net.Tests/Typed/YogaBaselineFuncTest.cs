using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaBaselineFuncTest
    {
        static BaselineFunc _baseline = (YogaNode node, float width, float height, object context) => { return (float)node.Context; };

        [Test]
        public void align_baseline_customer_func()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNew();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            float baselineValue = 10;
            YogaNode root_child1_child0 = YGNodeNew();
            root_child1_child0.Context = baselineValue;
            YGNodeStyleSetWidth(root_child1_child0, 50);
            root_child1_child0.BaselineFunc = _baseline;
            YGNodeStyleSetHeight(root_child1_child0, 20);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1_child0));
        }
    }
}
