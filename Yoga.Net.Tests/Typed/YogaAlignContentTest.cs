using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAlignContentTest
    {
        [Test]
        public void align_content_flex_start()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 130);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeStyleSetHeight(root_child4, 10);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(10, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(20, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(80, root_child2.Layout.Left);
            Assert.AreEqual(10, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(80, root_child4.Layout.Left);
            Assert.AreEqual(20, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_flex_start_without_height_on_children()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(10, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(20, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(10, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(20, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_flex_start_with_flex()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 120);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0, 0);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child3, 1);
            YGNodeStyleSetFlexShrink(root_child3, 1);
            YGNodeStyleSetFlexBasisPercent(root_child3, 0);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(40, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(80, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(120, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(40, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(80, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(120, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);
        }

        [Ignore("Exactly the same results as the C++ library")]
        [Test]
        public void align_content_flex_end()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.FlexEnd);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeStyleSetHeight(root_child4, 10);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(40, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(40, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(0, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(100, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(0, root_child3.Layout.Height);

            Assert.AreEqual(100, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_spacebetween()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.SpaceBetween);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 130);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeStyleSetHeight(root_child4, 10);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(45, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(45, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(90, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(80, root_child2.Layout.Left);
            Assert.AreEqual(45, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child3.Layout.Left);
            Assert.AreEqual(45, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(80, root_child4.Layout.Left);
            Assert.AreEqual(90, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_spacearound()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.SpaceAround);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 140);
            YGNodeStyleSetHeight(root, 120);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeStyleSetHeight(root_child4, 10);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(140, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(15, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(15, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(55, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(55, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(95, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(140, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(15, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(15, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(90, root_child2.Layout.Left);
            Assert.AreEqual(55, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(40, root_child3.Layout.Left);
            Assert.AreEqual(55, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(90, root_child4.Layout.Left);
            Assert.AreEqual(95, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_children()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0_child0, 0);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_flex()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child3, 1);
            YGNodeStyleSetFlexShrink(root_child3, 1);
            YGNodeStyleSetFlexBasisPercent(root_child3, 0);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(0, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(100, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(100, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(0, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_flex_no_shrink()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child3, 1);
            YGNodeStyleSetFlexBasisPercent(root_child3, 0);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(0, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(100, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(100, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(0, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_margin()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child1, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child1, Edge.Top, 10);
            YGNodeStyleSetMargin(root_child1, Edge.Right, 10);
            YGNodeStyleSetMargin(root_child1, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetMargin(root_child3, Edge.Left, 10);
            YGNodeStyleSetMargin(root_child3, Edge.Top, 10);
            YGNodeStyleSetMargin(root_child3, Edge.Right, 10);
            YGNodeStyleSetMargin(root_child3, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            Assert.AreEqual(60, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(40, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(40, root_child2.Layout.Height);

            Assert.AreEqual(60, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(80, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(20, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(40, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(40, root_child2.Layout.Height);

            Assert.AreEqual(40, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            Assert.AreEqual(100, root_child4.Layout.Left);
            Assert.AreEqual(80, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(20, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_padding()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetPadding(root_child1, Edge.Left, 10);
            YGNodeStyleSetPadding(root_child1, Edge.Top, 10);
            YGNodeStyleSetPadding(root_child1, Edge.Right, 10);
            YGNodeStyleSetPadding(root_child1, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetPadding(root_child3, Edge.Left, 10);
            YGNodeStyleSetPadding(root_child3, Edge.Top, 10);
            YGNodeStyleSetPadding(root_child3, Edge.Right, 10);
            YGNodeStyleSetPadding(root_child3, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_single_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_fixed_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 60);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(60, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(80, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(80, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(80, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(20, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(60, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(80, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(80, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(80, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(20, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_max_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetMaxHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_min_height()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetMinHeight(root_child1, 80);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(90, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(90, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(90, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(90, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(90, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(90, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(90, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(90, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(90, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(90, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 150);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0_child0, 0);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(150, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(100, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(150, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(100, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_is_not_overriding_align_items()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0, YogaAlign.Stretch);
            YGNodeStyleSetAlignItems(root_child0, YogaAlign.Center);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetAlignContent(root_child0_child0, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0, 10);
            YGNodeStyleSetHeight(root_child0_child0, 10);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(45, root_child0_child0.Layout.Top);
            Assert.AreEqual(10, root_child0_child0.Layout.Width);
            Assert.AreEqual(10, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(90, root_child0_child0.Layout.Left);
            Assert.AreEqual(45, root_child0_child0.Layout.Top);
            Assert.AreEqual(10, root_child0_child0.Layout.Width);
            Assert.AreEqual(10, root_child0_child0.Layout.Height);
        }
    }
}
