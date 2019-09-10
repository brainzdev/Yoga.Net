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
            YogaNode root = new YogaNode();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            float baselineValue = 10;
            YogaNode root_child1_child0 = new YogaNode();
            root_child1_child0.Context = baselineValue;
            YGNodeStyleSetWidth(root_child1_child0, 50);
            root_child1_child0.BaselineFunc = _baseline;
            YGNodeStyleSetHeight(root_child1_child0, 20);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);
        }
    }
}
