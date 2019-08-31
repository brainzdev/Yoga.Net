using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGRelayoutTest
    {
        [Test]
        public void dont_cache_computed_flex_basis_between_layouts()
        {
            YogaConfig config = YGConfigNew();
            YGConfigSetExperimentalFeatureEnabled(config, ExperimentalFeature.WebFlexBasis, true);

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeightPercent(root, 100);
            YGNodeStyleSetWidthPercent(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasisPercent(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, 100, YogaValue.YGUndefined, Direction.LTR);
            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));
        }

        [Test]
        public void recalculate_resolvedDimonsion_onchange()
        {
            YGNode root = YGNodeNew();

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetMinHeight(root_child0, 10);
            YGNodeStyleSetMaxHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            YGNodeStyleSetMinHeight(root_child0, YogaValue.YGUndefined);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));
        }
    }
}
