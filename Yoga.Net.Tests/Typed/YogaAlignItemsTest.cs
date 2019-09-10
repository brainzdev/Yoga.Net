using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAlignItemsTest
    {
        [Test]
        public void align_items_stretch()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void align_items_center()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_start()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_end()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void align_baseline()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);
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
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);
        }

        [Test]
        public void align_baseline_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 50);
            YGNodeStyleSetHeight(root_child1_child0, 10);
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
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_child_multiline()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 60);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child1, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child1, Wrap.Wrap);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 25);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 25);
            YGNodeStyleSetHeight(root_child1_child0, 20);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child1_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child1, 25);
            YGNodeStyleSetHeight(root_child1_child1, 10);
            YGNodeInsertChild(root_child1, root_child1_child1, 1);

            YogaNode root_child1_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child2, 25);
            YGNodeStyleSetHeight(root_child1_child2, 20);
            YGNodeInsertChild(root_child1, root_child1_child2, 2);

            YogaNode root_child1_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child3, 25);
            YGNodeStyleSetHeight(root_child1_child3, 10);
            YGNodeInsertChild(root_child1, root_child1_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(25, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1_child2));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1_child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1_child3));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(25, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1_child3));
        }

        [Test]
        public void align_baseline_child_multiline_override()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 60);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child1, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child1, Wrap.Wrap);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 25);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 25);
            YGNodeStyleSetHeight(root_child1_child0, 20);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child1_child1 = new YogaNode(config);
            YGNodeStyleSetAlignSelf(root_child1_child1, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root_child1_child1, 25);
            YGNodeStyleSetHeight(root_child1_child1, 10);
            YGNodeInsertChild(root_child1, root_child1_child1, 1);

            YogaNode root_child1_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child2, 25);
            YGNodeStyleSetHeight(root_child1_child2, 20);
            YGNodeInsertChild(root_child1, root_child1_child2, 2);

            YogaNode root_child1_child3 = new YogaNode(config);
            YGNodeStyleSetAlignSelf(root_child1_child3, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root_child1_child3, 25);
            YGNodeStyleSetHeight(root_child1_child3, 10);
            YGNodeInsertChild(root_child1, root_child1_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(25, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1_child2));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1_child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1_child3));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(25, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1_child3));
        }

        [Test]
        public void align_baseline_child_multiline_no_override_on_secondline()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 60);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child1, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child1, Wrap.Wrap);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 25);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 25);
            YGNodeStyleSetHeight(root_child1_child0, 20);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child1_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child1, 25);
            YGNodeStyleSetHeight(root_child1_child1, 10);
            YGNodeInsertChild(root_child1, root_child1_child1, 1);

            YogaNode root_child1_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child2, 25);
            YGNodeStyleSetHeight(root_child1_child2, 20);
            YGNodeInsertChild(root_child1, root_child1_child2, 2);

            YogaNode root_child1_child3 = new YogaNode(config);
            YGNodeStyleSetAlignSelf(root_child1_child3, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root_child1_child3, 25);
            YGNodeStyleSetHeight(root_child1_child3, 10);
            YGNodeInsertChild(root_child1, root_child1_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(25, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1_child2));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1_child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1_child3));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(25, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child1_child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1_child3));
        }

        [Test]
        public void align_baseline_child_top()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetPosition(root_child0, Edge.Top, 10);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 50);
            YGNodeStyleSetHeight(root_child1_child0, 10);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_child_top2()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetPosition(root_child1, Edge.Top, 5);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 50);
            YGNodeStyleSetHeight(root_child1_child0, 10);
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
            Assert.AreEqual(45, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(45, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_double_nested_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0, 50);
            YGNodeStyleSetHeight(root_child0_child0, 20);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 50);
            YGNodeStyleSetHeight(root_child1_child0, 15);
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

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(5, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(15, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(5, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(15, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);
        }

        [Test]
        public void align_baseline_child_margin()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0, Edge.Left, 5);
            YGNodeStyleSetMargin(root_child0, Edge.Top, 5);
            YGNodeStyleSetMargin(root_child0, Edge.Right, 5);
            YGNodeStyleSetMargin(root_child0, Edge.Bottom, 5);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child1_child0, Edge.Left, 1);
            YGNodeStyleSetMargin(root_child1_child0, Edge.Top, 1);
            YGNodeStyleSetMargin(root_child1_child0, Edge.Right, 1);
            YGNodeStyleSetMargin(root_child1_child0, Edge.Bottom, 1);
            YGNodeStyleSetWidth(root_child1_child0, 50);
            YGNodeStyleSetHeight(root_child1_child0, 10);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, root_child0.Layout.Left);
            Assert.AreEqual(5, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(60, root_child1.Layout.Left);
            Assert.AreEqual(44, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(1, root_child1_child0.Layout.Left);
            Assert.AreEqual(1, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(5, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(-10, root_child1.Layout.Left);
            Assert.AreEqual(44, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(-1, root_child1_child0.Layout.Left);
            Assert.AreEqual(1, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_child_padding()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetPadding(root, Edge.Left, 5);
            YGNodeStyleSetPadding(root, Edge.Top, 5);
            YGNodeStyleSetPadding(root, Edge.Right, 5);
            YGNodeStyleSetPadding(root, Edge.Bottom, 5);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetPadding(root_child1, Edge.Left, 5);
            YGNodeStyleSetPadding(root_child1, Edge.Top, 5);
            YGNodeStyleSetPadding(root_child1, Edge.Right, 5);
            YGNodeStyleSetPadding(root_child1, Edge.Bottom, 5);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 50);
            YGNodeStyleSetHeight(root_child1_child0, 10);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, root_child0.Layout.Left);
            Assert.AreEqual(5, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(55, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(5, root_child1_child0.Layout.Left);
            Assert.AreEqual(5, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(5, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(-5, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(-5, root_child1_child0.Layout.Left);
            Assert.AreEqual(5, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 50);
            YGNodeStyleSetHeight(root_child1_child0, 10);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 20);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child2_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2_child0, 50);
            YGNodeStyleSetHeight(root_child2_child0, 10);
            YGNodeInsertChild(root_child2, root_child2_child0, 0);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);
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
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(100, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2_child0));

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(60, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(100, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2_child0));

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(60, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 20);
            YGNodeStyleSetHeight(root_child1_child0, 20);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 40);
            YGNodeStyleSetHeight(root_child2, 70);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child2_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2_child0, 10);
            YGNodeStyleSetHeight(root_child2_child0, 10);
            YGNodeInsertChild(root_child2, root_child2_child0, 0);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 20);
            YGNodeInsertChild(root, root_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(20, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(40, root_child2.Layout.Width);
            Assert.AreEqual(70, root_child2.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2_child0));

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(70, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(70, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(20, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(40, root_child2.Layout.Width);
            Assert.AreEqual(70, root_child2.Layout.Height);

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child2_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2_child0));

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(70, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline_column2()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 20);
            YGNodeStyleSetHeight(root_child1_child0, 20);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 40);
            YGNodeStyleSetHeight(root_child2, 70);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child2_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2_child0, 10);
            YGNodeStyleSetHeight(root_child2_child0, 10);
            YGNodeInsertChild(root_child2, root_child2_child0, 0);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 20);
            YGNodeInsertChild(root, root_child3, 3);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(20, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(40, root_child2.Layout.Width);
            Assert.AreEqual(70, root_child2.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2_child0));

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(70, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(70, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(20, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(40, root_child2.Layout.Width);
            Assert.AreEqual(70, root_child2.Layout.Height);

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child2_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2_child0));

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(70, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline_row_and_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1_child0, 50);
            YGNodeStyleSetHeight(root_child1_child0, 10);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 20);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child2_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2_child0, 50);
            YGNodeStyleSetHeight(root_child2_child0, 10);
            YGNodeInsertChild(root_child2, root_child2_child0, 0);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 20);
            YGNodeInsertChild(root, root_child3, 3);
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
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(100, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2_child0));

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(90, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(100, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2_child0));

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(90, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);
        }

        [Test]
        public void align_items_center_child_with_margin_bigger_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetAlignItems(root_child0, YogaAlign.Center);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0_child0, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child0_child0, Edge.Right, 10);
            YGNodeStyleSetWidth(root_child0_child0, 52);
            YGNodeStyleSetHeight(root_child0_child0, 52);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(52, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(52, root_child0_child0.Layout.Width);
            Assert.AreEqual(52, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(52, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(52, root_child0_child0.Layout.Width);
            Assert.AreEqual(52, root_child0_child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_end_child_with_margin_bigger_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetAlignItems(root_child0, YogaAlign.FlexEnd);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child0_child0, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child0_child0, Edge.Right, 10);
            YGNodeStyleSetWidth(root_child0_child0, 52);
            YGNodeStyleSetHeight(root_child0_child0, 52);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(52, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(52, root_child0_child0.Layout.Width);
            Assert.AreEqual(52, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(52, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(52, root_child0_child0.Layout.Width);
            Assert.AreEqual(52, root_child0_child0.Layout.Height);
        }

        [Test]
        public void align_items_center_child_without_margin_bigger_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetAlignItems(root_child0, YogaAlign.Center);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0, 72);
            YGNodeStyleSetHeight(root_child0_child0, 72);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(72, root_child0_child0.Layout.Width);
            Assert.AreEqual(72, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(72, root_child0_child0.Layout.Width);
            Assert.AreEqual(72, root_child0_child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_end_child_without_margin_bigger_than_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetAlignItems(root_child0, YogaAlign.FlexEnd);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0, 72);
            YGNodeStyleSetHeight(root_child0_child0, 72);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(72, root_child0_child0.Layout.Width);
            Assert.AreEqual(72, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(72, root_child0_child0.Layout.Width);
            Assert.AreEqual(72, root_child0_child0.Layout.Height);
        }

        [Test]
        public void align_center_should_size_based_on_content()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root_child0, Justify.Center);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 20);
            YGNodeStyleSetHeight(root_child0_child0_child0, 20);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(20, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0_child0_child0));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(20, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0_child0_child0));
        }

        [Test]
        public void align_strech_should_size_based_on_parent()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetJustifyContent(root_child0, Justify.Center);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 20);
            YGNodeStyleSetHeight(root_child0_child0_child0, 20);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0_child0_child0));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child0_child0_child0));
        }

        [Test]
        public void align_flex_start_with_shrinking_children()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetAlignItems(root_child0, YogaAlign.FlexStart);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0_child0, 1);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0_child0_child0));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(500, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0_child0_child0));
        }

        [Test]
        public void align_flex_start_with_stretching_children()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0_child0, 1);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0_child0_child0));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0_child0_child0));
        }

        [Test]
        public void align_flex_start_with_shrinking_children_with_stretch()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetAlignItems(root_child0, YogaAlign.FlexStart);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0_child0, 1);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0_child0_child0));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(500, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0_child0_child0));
        }
    }
}
