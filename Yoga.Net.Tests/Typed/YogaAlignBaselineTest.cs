using NUnit.Framework;
using static Yoga.Net.YogaBuild;

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

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, alignItems: YogaAlign.Baseline, width: 340, maxHeight: 170, minHeight: 0)
                           .Add(root_child0 = Node(flexGrow: 0, flexShrink: 1, measureFunc: _measure1))
                           .Add(root_child1 = Node(flexGrow:0, flexShrink:1, measureFunc:_measure2));

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

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 150)
                           .Add(root_child0 = Node(width:50, height:50))
                           .Add(root_child1 = Node(width:50, height:40));
            root_child1.BaselineFunc = _baselineFunc;

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

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 150)
                           .Add(root_child0 = Node(width: 50, height: 80))
                           .Add(root_child1 = Node(width:50, height:50));

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
