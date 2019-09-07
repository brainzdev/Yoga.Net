using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaFlexTest
    {
        [Test]
        public void flex_basis_flex_grow_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(75, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(75, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void flex_shrink_flex_grow_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 0);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetWidth(root_child0, 500);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 0);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetWidth(root_child1, 500);
            YGNodeStyleSetHeight(root_child1, 100);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(250, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(250, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void flex_shrink_flex_grow_child_flex_shrink_other_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 0);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetWidth(root_child0, 500);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetWidth(root_child1, 500);
            YGNodeStyleSetHeight(root_child1, 100);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(250, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(250, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void flex_basis_flex_grow_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(75, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void flex_basis_flex_shrink_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void flex_basis_flex_shrink_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexShrink(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));
        }

        [Test]
        public void flex_shrink_to_zero()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root, 75);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void flex_basis_overrides_main_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 1);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child2));
        }

        [Test]
        public void flex_grow_shrink_at_most()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0_child0));
        }

        [Test]
        public void flex_grow_less_than_factor_one()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 500);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 0.2f);
            YGNodeStyleSetFlexBasis(root_child0, 40);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 0.2f);
            YGNodeInsertChild(root, root_child1, 1);

            YogaNode root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child2, 0.4f);
            YGNodeInsertChild(root, root_child2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(132, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(132, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(92, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(224, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(184, YGNodeLayoutGetHeight(root_child2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(132, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(132, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(92, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(224, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(184, YGNodeLayoutGetHeight(root_child2));
        }
    }
}
