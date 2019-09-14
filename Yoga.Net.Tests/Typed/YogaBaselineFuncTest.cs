using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaBaselineFuncTest
    {
        static BaselineFunc _baseline = (YogaNode node, float width, float height, object context) => { return (float)node.Context; };

        [Test]
        public void align_baseline_customer_func()
        {
            float baselineValue = 10;

            YogaNode root_child0, root_child1, root_child1_child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .AddChild(root_child0 = Node(width: 50, height: 50))
                           .AddChild(root_child1 = Node(width:50, height:20)
                               .AddChild(root_child1_child0 = Node(width:50, height:20))
                            );

            root_child1_child0.Context = baselineValue;
            root_child1_child0.BaselineFunc = _baseline;

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
            Assert.AreEqual(20, root_child1_child0.Layout.Height);
        }
    }
}
