using NUnit.Framework;
using NUnit.Framework.Constraints;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaHadOverflowTest
    {
        [SetUp]
        public void Setup()
        {
            config = new YogaConfig();
            root   = Node(config, width:200, height:100, flexDirection:FlexDirection.Column, flexWrap:Wrap.NoWrap);
        }

        [TearDown]
        public void Teardown()
        {
            root   = null;
            config = null;
            //
            //
        }

        YogaNode root;
        YogaConfig config;

        [Test]
        public void children_overflow_no_wrap_and_no_flex_children()
        {
            root.Children.Add(Node(config, width: 80, height: 40, margin: Edges(top: 10, bottom: 15)));
            root.Children.Add(Node(config, width: 80, height: 40, margin: Edges(bottom: 5)));

            YogaArrange.CalculateLayout(root, 200, 100, Direction.LTR);

            Assert.IsTrue(root.Layout.HadOverflow);
        }

        [Test]
        public void spacing_overflow_no_wrap_and_no_flex_children()
        {
            root.Children.Add(Node(config, width: 80, height: 40, margin: Edges(top: 10, bottom: 10)));
            root.Children.Add(Node(config, width: 80, height: 40, margin: Edges(bottom: 5)));

            YogaArrange.CalculateLayout(root, 200, 100, Direction.LTR);

            Assert.IsTrue(root.Layout.HadOverflow);
        }

        [Test]
        public void no_overflow_no_wrap_and_flex_children()
        {
            root.Children.Add(Node(config, width: 80, height: 40, margin: Edges(top: 10, bottom: 10)));
            root.Children.Add(Node(config, width: 80, height: 40, margin: Edges(bottom: 5), flexShrink: 1));

            YogaArrange.CalculateLayout(root, 200, 100, Direction.LTR);

            Assert.IsFalse(root.Layout.HadOverflow);
        }

        [Test]
        public void hadOverflow_gets_reset_if_not_logger_valid()
        {
            YogaNode child1;
            root.Children.Add(Node(config, width: 80, height: 40, margin: Edges(top: 10, bottom: 10)));
            root.Children.Add(child1 = Node(config, width: 80, height: 40, margin: Edges(bottom: 5)));

            YogaArrange.CalculateLayout(root, 200, 100, Direction.LTR);

            Assert.IsTrue(root.Layout.HadOverflow);

            child1.Style.FlexShrink = 1;

            YogaArrange.CalculateLayout(root, 200, 100, Direction.LTR);

            Assert.IsFalse(root.Layout.HadOverflow);
        }

        [Test]
        public void spacing_overflow_in_nested_nodes()
        {
            root.Children.Add(Node(config, width: 80, height: 40, margin: Edges(top: 10, bottom: 10)));
            root.Children.Add(
                Node(config, width: 80, height: 40)
                   .Add(Node(width: 80, height: 40, margin: Edges(bottom: 5)))
            );

            YogaArrange.CalculateLayout(root, 200, 100, Direction.LTR);

            Assert.IsTrue(root.Layout.HadOverflow);
        }
    }
}
