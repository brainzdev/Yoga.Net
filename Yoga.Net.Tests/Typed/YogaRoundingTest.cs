using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaRoundingTest
    {
        [Test]
        public void rounding_flex_basis_flex_grow_row_width_of_100()
        {
            YogaNode root = new YogaNode();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(33, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(33, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(34, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(67, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(33, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(67, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(33, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(33, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(34, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(33, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_flex_basis_flex_grow_row_prime_number_width()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 113);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeInsertChild(root, root_child2, 2);

            YogaNode root_child3 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child3, 1);
            YGNodeInsertChild(root, root_child3, 3);

            YogaNode root_child4 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child4, 1);
            YGNodeInsertChild(root, root_child4, 4);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(113, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(23, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(23, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(22, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(45, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(23, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(68, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(22, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(90, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(23, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(113, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(23, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(68, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(22, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(45, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(23, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(23, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(22, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(23, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);
        }

        [Test]
        public void rounding_flex_basis_flex_shrink_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 101);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexBasis(root_child1, 25);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexBasis(root_child2, 25);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(101, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(51, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(51, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(25, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(76, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(25, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(101, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(51, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(25, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(25, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(25, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_flex_basis_overrides_main_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_total_fractial()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 87.4f);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 0.7f);
            YGNodeStyleSetFlexBasis(root_child0, 50.3f);
            YGNodeStyleSetHeight(root_child0, 20.3f);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1.6f);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1.1f);
            YGNodeStyleSetHeight(root_child2, 10.7f);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(87, root_child0.Layout.Width);
            Assert.AreEqual(59, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(59, root_child1.Layout.Top);
            Assert.AreEqual(87, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(87, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(87, root_child0.Layout.Width);
            Assert.AreEqual(59, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(59, root_child1.Layout.Top);
            Assert.AreEqual(87, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(87, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_total_fractial_nested()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 87.4f);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 0.7f);
            YGNodeStyleSetFlexBasis(root_child0, 50.3f);
            YGNodeStyleSetHeight(root_child0, 20.3f);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0_child0, 0.3f);
            YGNodeStyleSetPosition(root_child0_child0, Edge.Bottom, 13.3f);
            YGNodeStyleSetHeight(root_child0_child0, 9.9f);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaNode root_child0_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0_child1, 4);
            YGNodeStyleSetFlexBasis(root_child0_child1, 0.3f);
            YGNodeStyleSetPosition(root_child0_child1, Edge.Top, 13.3f);
            YGNodeStyleSetHeight(root_child0_child1, 1.1f);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1.6f);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1.1f);
            YGNodeStyleSetHeight(root_child2, 10.7f);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(87, root_child0.Layout.Width);
            Assert.AreEqual(59, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(-13, root_child0_child0.Layout.Top);
            Assert.AreEqual(87, root_child0_child0.Layout.Width);
            Assert.AreEqual(12, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(25, root_child0_child1.Layout.Top);
            Assert.AreEqual(87, root_child0_child1.Layout.Width);
            Assert.AreEqual(47, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(59, root_child1.Layout.Top);
            Assert.AreEqual(87, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(87, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(87, root_child0.Layout.Width);
            Assert.AreEqual(59, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(-13, root_child0_child0.Layout.Top);
            Assert.AreEqual(87, root_child0_child0.Layout.Width);
            Assert.AreEqual(12, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(25, root_child0_child1.Layout.Top);
            Assert.AreEqual(87, root_child0_child1.Layout.Width);
            Assert.AreEqual(47, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(59, root_child1.Layout.Top);
            Assert.AreEqual(87, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(87, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_fractial_input_1()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_fractial_input_2()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.6f);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(65, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(65, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(24, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(25, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(65, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(65, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(24, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(25, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_fractial_input_3()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetPosition(root, Edge.Top, 0.3f);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(65, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(24, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(25, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(65, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(24, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(25, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_fractial_input_4()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetPosition(root, Edge.Top, 0.7f);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(1, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(1, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(64, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(64, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(89, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(24, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_inner_node_controversy_horizontal()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 320);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1_child0, 1);
            YGNodeStyleSetHeight(root_child1_child0, 10);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(320, root.Layout.Width);
            Assert.AreEqual(10, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(107, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(107, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(106, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(106, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(213, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(107, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(320, root.Layout.Width);
            Assert.AreEqual(10, root.Layout.Height);

            Assert.AreEqual(213, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(107, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(107, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(106, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(106, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(107, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_inner_node_controversy_vertical()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetHeight(root, 320);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1_child0, 1);
            YGNodeStyleSetWidth(root_child1_child0, 10);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(10, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(107, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(107, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(106, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(10, root_child1_child0.Layout.Width);
            Assert.AreEqual(106, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(213, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(107, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(10, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(107, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(107, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(106, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(10, root_child1_child0.Layout.Width);
            Assert.AreEqual(106, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(213, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(107, root_child2.Layout.Height);
        }

        [Test]
        public void rounding_inner_node_controversy_combined()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 640);
            YGNodeStyleSetHeight(root, 320);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetHeightPercent(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeightPercent(root_child1, 100);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child1_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1_child0, 1);
            YGNodeStyleSetWidthPercent(root_child1_child0, 100);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YogaNode root_child1_child1 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1_child1, 1);
            YGNodeStyleSetWidthPercent(root_child1_child1, 100);
            YGNodeInsertChild(root_child1, root_child1_child1, 1);

            YogaNode root_child1_child1_child0 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1_child1_child0, 1);
            YGNodeStyleSetWidthPercent(root_child1_child1_child0, 100);
            YGNodeInsertChild(root_child1_child1, root_child1_child1_child0, 0);

            YogaNode root_child1_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child1_child2, 1);
            YGNodeStyleSetWidthPercent(root_child1_child2, 100);
            YGNodeInsertChild(root_child1, root_child1_child2, 2);

            YogaNode root_child2 = new YogaNode(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeightPercent(root_child2, 100);
            YGNodeInsertChild(root, root_child2, 2);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(640, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(213, root_child0.Layout.Width);
            Assert.AreEqual(320, root_child0.Layout.Height);

            Assert.AreEqual(213, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(214, root_child1.Layout.Width);
            Assert.AreEqual(320, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(214, root_child1_child0.Layout.Width);
            Assert.AreEqual(107, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(107, root_child1_child1.Layout.Top);
            Assert.AreEqual(214, root_child1_child1.Layout.Width);
            Assert.AreEqual(106, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child1_child0.Layout.Top);
            Assert.AreEqual(214, root_child1_child1_child0.Layout.Width);
            Assert.AreEqual(106, root_child1_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child2.Layout.Left);
            Assert.AreEqual(213, root_child1_child2.Layout.Top);
            Assert.AreEqual(214, root_child1_child2.Layout.Width);
            Assert.AreEqual(107, root_child1_child2.Layout.Height);

            Assert.AreEqual(427, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(213, root_child2.Layout.Width);
            Assert.AreEqual(320, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(640, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(427, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(213, root_child0.Layout.Width);
            Assert.AreEqual(320, root_child0.Layout.Height);

            Assert.AreEqual(213, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(214, root_child1.Layout.Width);
            Assert.AreEqual(320, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(214, root_child1_child0.Layout.Width);
            Assert.AreEqual(107, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(107, root_child1_child1.Layout.Top);
            Assert.AreEqual(214, root_child1_child1.Layout.Width);
            Assert.AreEqual(106, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child1_child0.Layout.Top);
            Assert.AreEqual(214, root_child1_child1_child0.Layout.Width);
            Assert.AreEqual(106, root_child1_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child2.Layout.Left);
            Assert.AreEqual(213, root_child1_child2.Layout.Top);
            Assert.AreEqual(214, root_child1_child2.Layout.Width);
            Assert.AreEqual(107, root_child1_child2.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(213, root_child2.Layout.Width);
            Assert.AreEqual(320, root_child2.Layout.Height);
        }
    }
}
