using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaRelayoutTest
    {
        [Test]
        public void dont_cache_computed_flex_basis_between_layouts()
        {
            YogaConfig config = new YogaConfig();
            config.ExperimentalFeatures[(int)ExperimentalFeature.WebFlexBasis] = true;

            YogaNode root_child0;
            YogaNode root = Node(
                    config: config,
                    height: 100.Percent(),
                    width: 100.Percent())
               .AddChild(root_child0 = Node(config, flexBasis: 100.Percent()));

            YogaArrange.CalculateLayout(root, 100, YogaValue.YGUndefined, Direction.LTR);
            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(100, root_child0.Layout.Height);
        }

        [Test]
        public void recalculate_resolvedDimonsion_onchange()
        {
            YogaNode root_child0;
            YogaNode root = Node()
               .AddChild(root_child0 = Node(minHeight: 10, maxHeight: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, root_child0.Layout.Height);

            root_child0.Style.MinHeight = YogaValue.YGUndefined;
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root_child0.Layout.Height);
        }
    }
}
