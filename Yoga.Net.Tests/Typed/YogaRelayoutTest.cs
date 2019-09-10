using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaRelayoutTest
    {
        [Test]
        public void dont_cache_computed_flex_basis_between_layouts()
        {
            YogaConfig config = new YogaConfig();
            YGConfigSetExperimentalFeatureEnabled(config, ExperimentalFeature.WebFlexBasis, true);

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetHeightPercent(root, 100);
            YGNodeStyleSetWidthPercent(root, 100);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexBasisPercent(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, 100, YogaValue.YGUndefined, Direction.LTR);
            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void recalculate_resolvedDimonsion_onchange()
        {
            YogaNode root = new YogaNode();

            YogaNode root_child0 = new YogaNode();
            YGNodeStyleSetMinHeight(root_child0, 10);
            YGNodeStyleSetMaxHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YGNodeStyleSetMinHeight(root_child0, YogaValue.YGUndefined);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Height);
        }
    }
}
