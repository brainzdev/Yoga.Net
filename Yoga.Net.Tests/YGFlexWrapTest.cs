using NUnit.Framework;
using static Yoga.Net.YogaGlobal;



namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGFlexWrapTest
    {

        [Test] public void wrap_column() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 30);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 30);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            

            
        }

        [Test] public void wrap_row() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 30);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 30);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            

            
        }

        [Test] public void wrap_row_align_items_flex_end() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YGAlign.FlexEnd);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            

            
        }

        [Test] public void wrap_row_align_items_center() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 30);
            YGNodeInsertChild(root, root_child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(5, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child3));

            

            
        }

        [Test] public void flex_wrap_children_with_min_main_overriding_flex_basis() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetMinWidth(root_child0, 55);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child1, 50);
            YGNodeStyleSetMinWidth(root_child1, 55);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            

            
        }

        [Test] public void flex_wrap_wrap_to_child_height() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, YGFlexDirection.Row);
            YGNodeStyleSetAlignItems(root_child0, YGAlign.FlexStart);
            YGNodeStyleSetFlexWrap(root_child0, YGWrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNode root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 100);
            YGNodeStyleSetHeight(root_child0_child0_child0, 100);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 100);
            YGNodeStyleSetHeight(root_child1, 100);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            

            
        }

        [Ignore("Exactly the same result as the c++ library")]
        [Test] public void flex_wrap_align_stretch_fits_one_row() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            

            
        }

        [Test] public void wrap_reverse_row_align_content_flex_start() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YGNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void wrap_reverse_row_align_content_center() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Center);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YGNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void wrap_reverse_row_single_line_different_size() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 300);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YGNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(270, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(240, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(210, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(180, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(150, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void wrap_reverse_row_align_content_stretch() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YGNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void wrap_reverse_row_align_content_space_around() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.SpaceAround);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YGNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void wrap_reverse_column_fixed_size() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexWrap(root, YGWrap.WrapReverse);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 30);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 30);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 30);
            YGNodeStyleSetHeight(root_child2, 30);
            YGNodeInsertChild(root, root_child2, 2);

            YGNode root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 30);
            YGNodeStyleSetHeight(root_child3, 40);
            YGNodeInsertChild(root, root_child3, 3);

            YGNode root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 30);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(140, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void wrapped_row_within_align_items_center() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, YGWrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 150);
            YGNodeStyleSetHeight(root_child0_child0, 80);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1, 80);
            YGNodeStyleSetHeight(root_child0_child1, 80);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));

            

            
        }

        [Test] public void wrapped_row_within_align_items_flex_start() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, YGWrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 150);
            YGNodeStyleSetHeight(root_child0_child0, 80);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1, 80);
            YGNodeStyleSetHeight(root_child0_child1, 80);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));

            

            
        }

        [Test] public void wrapped_row_within_align_items_flex_end() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YGAlign.FlexEnd);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, YGWrap.Wrap);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 150);
            YGNodeStyleSetHeight(root_child0_child0, 80);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1, 80);
            YGNodeStyleSetHeight(root_child0_child1, 80);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0_child1));

            

            
        }

        [Test] public void wrapped_column_max_height() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, YGJustify.Center);
            YGNodeStyleSetAlignContent(root, YGAlign.Center);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 700);
            YGNodeStyleSetHeight(root, 500);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 500);
            YGNodeStyleSetMaxHeight(root_child0, 200);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root_child1, YGEdge.Left, 20);
            YGNodeStyleSetMargin(root_child1, YGEdge.Top, 20);
            YGNodeStyleSetMargin(root_child1, YGEdge.Right, 20);
            YGNodeStyleSetMargin(root_child1, YGEdge.Bottom, 20);
            YGNodeStyleSetWidth(root_child1, 200);
            YGNodeStyleSetHeight(root_child1, 200);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 100);
            YGNodeStyleSetHeight(root_child2, 100);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(200, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(250, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(420, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(200, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(350, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(250, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(180, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(200, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void wrapped_column_max_height_flex() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, YGJustify.Center);
            YGNodeStyleSetAlignContent(root, YGAlign.Center);
            YGNodeStyleSetAlignItems(root, YGAlign.Center);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 700);
            YGNodeStyleSetHeight(root, 500);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0, 0);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 500);
            YGNodeStyleSetMaxHeight(root_child0, 200);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetMargin(root_child1, YGEdge.Left, 20);
            YGNodeStyleSetMargin(root_child1, YGEdge.Top, 20);
            YGNodeStyleSetMargin(root_child1, YGEdge.Right, 20);
            YGNodeStyleSetMargin(root_child1, YGEdge.Bottom, 20);
            YGNodeStyleSetWidth(root_child1, 200);
            YGNodeStyleSetHeight(root_child1, 200);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 100);
            YGNodeStyleSetHeight(root_child2, 100);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(400, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(400, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            

            
        }

        [Test] public void wrap_nodes_with_content_sizing_overflowing_margin() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, YGWrap.Wrap);
            YGNodeStyleSetWidth(root_child0, 85);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNode root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 40);
            YGNodeStyleSetHeight(root_child0_child0_child0, 40);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YGNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root_child0_child1, YGEdge.Right, 10);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);

            YGNode root_child0_child1_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1_child0, 40);
            YGNodeStyleSetHeight(root_child0_child1_child0, 40);
            YGNodeInsertChild(root_child0_child1, root_child0_child1_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(85, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(415, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(85, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(35, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));

            

            
        }

        [Test] public void wrap_nodes_with_content_sizing_margin_cross() {
            YogaConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root_child0, YGWrap.Wrap);
            YGNodeStyleSetWidth(root_child0, 70);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNode root_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0_child0, 40);
            YGNodeStyleSetHeight(root_child0_child0_child0, 40);
            YGNodeInsertChild(root_child0_child0, root_child0_child0_child0, 0);

            YGNode root_child0_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root_child0_child1, YGEdge.Top, 10);
            YGNodeInsertChild(root_child0, root_child0_child1, 1);

            YGNode root_child0_child1_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child1_child0, 40);
            YGNodeStyleSetHeight(root_child0_child1_child0, 40);
            YGNodeInsertChild(root_child0_child1, root_child0_child1_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(430, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(70, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child0_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child0_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child0_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child1_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(root_child0_child1_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0_child1_child0));

            

            
        }
    }
}
