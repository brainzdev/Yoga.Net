using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaFlexTest
    {
        [Test]
        public void flex_basis_flex_grow_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, width: 100, height: 100)
                           .AddChild(root_child0 = Node(flexGrow:1, flexBasis:50))
                           .AddChild(root_child1 = Node(flexGrow:1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(75, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(75, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(75, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(75, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);
        }

        [Test]
        public void flex_shrink_flex_grow_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection: FlexDirection.Row, width: 500, height: 500)
                           .AddChild(root_child0 = Node(flexGrow: 0, flexShrink: 1, width: 500, height: 100))
                           .AddChild(root_child1 = Node(flexGrow: 0, flexShrink: 1, width: 500, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(250, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(250, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(250, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void flex_shrink_flex_grow_child_flex_shrink_other_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection: FlexDirection.Row, width: 500, height: 500)
                           .AddChild(root_child0 = Node(flexGrow: 0, flexShrink: 1, width: 500, height: 100))
                           .AddChild(root_child1 = Node(flexGrow: 1, flexShrink: 1, width: 500, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(250, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(250, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(250, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void flex_basis_flex_grow_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection:FlexDirection.Row, width: 100, height: 100)
                           .AddChild(root_child0 = Node(flexGrow:1, flexBasis:50))
                           .AddChild(root_child1 = Node(flexGrow:1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(75, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(75, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(25, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(75, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(25, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void flex_basis_flex_shrink_column()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, width: 100, height: 100)
                           .AddChild(root_child0 = Node(flexShrink:1, flexBasis:100))
                           .AddChild(root_child1 = Node(flexBasis:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void flex_basis_flex_shrink_row()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, flexDirection:FlexDirection.Row, width: 100, height: 100)
                           .AddChild(root_child0 = Node(flexShrink:1, flexBasis:100))
                           .AddChild(root_child1 = Node(flexBasis:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
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
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void flex_shrink_to_zero()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(config, height: 75)
                           .AddChild(root_child0 = Node(width: 50, height: 50))
                           .AddChild(root_child1 = Node(flexShrink: 1, width: 50, height: 50))
                           .AddChild(root_child2 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(75, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(75, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);
        }

        [Test]
        public void flex_basis_overrides_main_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(config, width: 100, height: 100)
                           .AddChild(root_child0 = Node(flexGrow: 1, flexBasis: 50, height: 20))
                           .AddChild(root_child1 = Node(flexGrow: 1, height: 10))
                           .AddChild(root_child2 = Node(flexGrow:1, height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);
        }

        [Test]
        public void flex_grow_shrink_at_most()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child0_child0;
            YogaNode root = Node(config, width: 100, height: 100)
               .AddChild(
                    root_child0 = Node()
                       .AddChild(
                            root_child0_child0 = Node(flexGrow: 1, flexShrink: 1)
                        ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);
        }

        [Test]
        public void flex_grow_less_than_factor_one()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(config, width: 200, height: 500)
                           .AddChild(root_child0 = Node(flexGrow: 0.2f, flexBasis: 40))
                           .AddChild(root_child1 = Node(flexGrow: 0.2f))
                           .AddChild(root_child2 = Node(flexGrow: 0.4f));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(132, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(132, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(92, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(224, root_child2.Layout.Top);
            Assert.AreEqual(200, root_child2.Layout.Width);
            Assert.AreEqual(184, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(132, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(132, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(92, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(224, root_child2.Layout.Top);
            Assert.AreEqual(200, root_child2.Layout.Width);
            Assert.AreEqual(184, root_child2.Layout.Height);
        }
    }
}
