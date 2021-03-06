using NUnit.Framework;
using static Yoga.Net.YGGlobal;



namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGRoundingTest
    {
        [Test] public void rounding_flex_basis_flex_grow_row_width_of_100() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(33, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(33, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(34, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(67, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(33, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(67, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(33, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(33, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(34, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(33, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_flex_basis_flex_grow_row_prime_number_width() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 113);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child3, 1);
            YGNodeInsertChild(root, root_child3, 3);

            YGNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child4, 1);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(113, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(23, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(22, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(68, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(22, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(113, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(68, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(22, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(23, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(22, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void rounding_flex_basis_flex_shrink_row() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 101);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child1, 25);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child2, 25);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(101, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(51, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(51, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(76, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(101, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(51, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_flex_basis_overrides_main_size() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_total_fractial() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 87.4f);
            YGNodeStyleSetHeight(root, 113.4f);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 0.7f);
            YGNodeStyleSetFlexBasis(root_child0, 50.3f);
            YGNodeStyleSetHeight(root_child0, 20.3f);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1.6f);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1.1f);
            YGNodeStyleSetHeight(root_child2, 10.7f);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(59, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(59, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(59, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(59, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_total_fractial_nested() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 87.4f);
            YGNodeStyleSetHeight(root, 113.4f);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 0.7f);
            YGNodeStyleSetFlexBasis(root_child0, 50.3f);
            YGNodeStyleSetHeight(root_child0, 20.3f);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0_child0, 0.3f);
            YGNodeStyleSetPosition(root_child0_child0, YGEdge.Bottom, 13.3f);
            YGNodeStyleSetHeight(root_child0_child0, 9.9f);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0_child1, 4);
            YGNodeStyleSetFlexBasis(root_child0_child1, 0.3f);
            YGNodeStyleSetPosition(root_child0_child1, YGEdge.Top, 13.3f);
            YGNodeStyleSetHeight(root_child0_child1, 1.1f);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1.6f);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1.1f);
            YGNodeStyleSetHeight(root_child2, 10.7f);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(59, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(-13, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(12, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(25, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(47, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(59, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(59, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(-13, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(12, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(25, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(47, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(59, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_fractial_input_1() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.4f);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_fractial_input_2() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.6f);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(114, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(65, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(65, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(114, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(65, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(65, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_fractial_input_3() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPosition(root, YGEdge.Top, 0.3f);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.4f);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(114, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(65, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(114, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(65, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_fractial_input_4() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPosition(root, YGEdge.Top, 0.7f);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.4f);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(1, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(1, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_inner_node_controversy_horizontal() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 320);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child1_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1_child0, 1);
            YGNodeStyleSetHeight(root_child1_child0, 10);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(320, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(107, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(107, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(106, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1_child0));
            Assert.AreEqual(106, YGNodeLayoutGetWidth(root_child1_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1_child0));

            Assert.AreEqual(213, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(107, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(320, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(213, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(107, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(107, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(106, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1_child0));
            Assert.AreEqual(106, YGNodeLayoutGetWidth(root_child1_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(107, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_inner_node_controversy_vertical() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root, 320);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetWidth(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetWidth(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child1_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1_child0, 1);
            YGNodeStyleSetWidth(root_child1_child0, 10);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetWidth(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(107, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1_child0));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(root_child1_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(213, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(107, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child1_child0));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(root_child1_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(213, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void rounding_inner_node_controversy_combined() {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 640);
            YGNodeStyleSetHeight(root, 320);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetHeightPercent(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeightPercent(root_child1, 100);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child1_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1_child0, 1);
            YGNodeStyleSetWidthPercent(root_child1_child0, 100);
            YGNodeInsertChild(root_child1, root_child1_child0, 0);

            YGNode root_child1_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1_child1, 1);
            YGNodeStyleSetWidthPercent(root_child1_child1, 100);
            YGNodeInsertChild(root_child1, root_child1_child1, 1);

            YGNode root_child1_child1_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1_child1_child0, 1);
            YGNodeStyleSetWidthPercent(root_child1_child1_child0, 100);
            YGNodeInsertChild(root_child1_child1, root_child1_child1_child0, 0);

            YGNode root_child1_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1_child2, 1);
            YGNodeStyleSetWidthPercent(root_child1_child2, 100);
            YGNodeInsertChild(root_child1, root_child1_child2, 2);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeightPercent(root_child2, 100);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(640, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(213, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(213, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1_child0));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1_child0));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(root_child1_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child1));
            Assert.AreEqual(107, YGNodeLayoutGetTop(root_child1_child1));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1_child1));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(root_child1_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1_child1_child0));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1_child1_child0));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(root_child1_child1_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child2));
            Assert.AreEqual(213, YGNodeLayoutGetTop(root_child1_child2));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1_child2));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(root_child1_child2));

            Assert.AreEqual(427, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(213, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(640, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(427, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(213, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(213, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1_child0));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1_child0));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(root_child1_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child1));
            Assert.AreEqual(107, YGNodeLayoutGetTop(root_child1_child1));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1_child1));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(root_child1_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1_child1_child0));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1_child1_child0));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(root_child1_child1_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1_child2));
            Assert.AreEqual(213, YGNodeLayoutGetTop(root_child1_child2));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(root_child1_child2));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(root_child1_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(213, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root_child2));

            

            
        }
    }
}
