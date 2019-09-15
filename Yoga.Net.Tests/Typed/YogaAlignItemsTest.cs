using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAlignItemsTest
    {
        [Test]
        public void align_items_stretch()
        {
            YogaNode root_child0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(root_child0 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void align_items_center()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 100, height: 100)
               .Add(root_child0 = Node(width:10, height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_start()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .Add(root_child0 = Node(width:10, height:10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_end()
        {
            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexEnd, width: 100, height: 100)
               .Add(root_child0 = Node(width:10, height:10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);
        }

        [Test]
        public void align_baseline()
        {
            YogaNode root_child0, root_child1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50))
                           .Add(root_child1 = Node(width: 50, height: 20));
            
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
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);
        }

        [Test]
        public void align_baseline_child()
        {
            YogaNode root_child0, root_child1, root_child1_child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50))
                           .Add(
                                root_child1 = Node(width: 50, height: 20)
                                   .Add(root_child1_child0 = Node(width: 50, height: 10))
                            );
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
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_child_multiline()
        {
            YogaNode root_child0, root_child1, root_child1_child0, root_child1_child1, root_child1_child2, root_child1_child3;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 60))
                           .Add(
                                root_child1 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap, width: 50, height: 25)
                                             .Add(root_child1_child0 = Node(width:25, height:20))
                                             .Add(root_child1_child1 = Node(width:25, height:10))
                                             .Add(root_child1_child2 = Node(width:25, height:20))
                                             .Add(root_child1_child3 = Node(width:25, height:10))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(25, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child2.Layout.Left);
            Assert.AreEqual(20, root_child1_child2.Layout.Top);
            Assert.AreEqual(25, root_child1_child2.Layout.Width);
            Assert.AreEqual(20, root_child1_child2.Layout.Height);

            Assert.AreEqual(25, root_child1_child3.Layout.Left);
            Assert.AreEqual(20, root_child1_child3.Layout.Top);
            Assert.AreEqual(25, root_child1_child3.Layout.Width);
            Assert.AreEqual(10, root_child1_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(25, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(25, root_child1_child2.Layout.Left);
            Assert.AreEqual(20, root_child1_child2.Layout.Top);
            Assert.AreEqual(25, root_child1_child2.Layout.Width);
            Assert.AreEqual(20, root_child1_child2.Layout.Height);

            Assert.AreEqual(0, root_child1_child3.Layout.Left);
            Assert.AreEqual(20, root_child1_child3.Layout.Top);
            Assert.AreEqual(25, root_child1_child3.Layout.Width);
            Assert.AreEqual(10, root_child1_child3.Layout.Height);
        }

        [Test]
        public void align_baseline_child_multiline_override()
        {
            YogaNode root_child0, root_child1, root_child1_child0, root_child1_child1, root_child1_child2, root_child1_child3;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 60))
                           .Add(
                                root_child1 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap, width: 50, height: 25)
                                             .Add(root_child1_child0 = Node(width:25, height:20))
                                             .Add(root_child1_child1 = Node( alignSelf:YogaAlign.Baseline, width:25, height:10))
                                             .Add(root_child1_child2 = Node(width:25, height:20))
                                             .Add(root_child1_child3 = Node(alignSelf:YogaAlign.Baseline, width:25, height:10))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(25, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child2.Layout.Left);
            Assert.AreEqual(20, root_child1_child2.Layout.Top);
            Assert.AreEqual(25, root_child1_child2.Layout.Width);
            Assert.AreEqual(20, root_child1_child2.Layout.Height);

            Assert.AreEqual(25, root_child1_child3.Layout.Left);
            Assert.AreEqual(20, root_child1_child3.Layout.Top);
            Assert.AreEqual(25, root_child1_child3.Layout.Width);
            Assert.AreEqual(10, root_child1_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(25, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(25, root_child1_child2.Layout.Left);
            Assert.AreEqual(20, root_child1_child2.Layout.Top);
            Assert.AreEqual(25, root_child1_child2.Layout.Width);
            Assert.AreEqual(20, root_child1_child2.Layout.Height);

            Assert.AreEqual(0, root_child1_child3.Layout.Left);
            Assert.AreEqual(20, root_child1_child3.Layout.Top);
            Assert.AreEqual(25, root_child1_child3.Layout.Width);
            Assert.AreEqual(10, root_child1_child3.Layout.Height);
        }

        [Test]
        public void align_baseline_child_multiline_no_override_on_secondline()
        {
            YogaNode root_child0, root_child1, root_child1_child0, root_child1_child1, root_child1_child2, root_child1_child3;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 60))
                           .Add(
                                root_child1 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap, width: 50, height: 25)
                                             .Add(root_child1_child0 = Node(width:25, height:20))
                                             .Add(root_child1_child1 = Node(width:25, height:10))
                                             .Add(root_child1_child2 = Node(width:25, height:20))
                                             .Add(root_child1_child3 = Node(alignSelf:YogaAlign.Baseline,width:25, height:10))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(25, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child2.Layout.Left);
            Assert.AreEqual(20, root_child1_child2.Layout.Top);
            Assert.AreEqual(25, root_child1_child2.Layout.Width);
            Assert.AreEqual(20, root_child1_child2.Layout.Height);

            Assert.AreEqual(25, root_child1_child3.Layout.Left);
            Assert.AreEqual(20, root_child1_child3.Layout.Top);
            Assert.AreEqual(25, root_child1_child3.Layout.Width);
            Assert.AreEqual(10, root_child1_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(60, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(25, root_child1.Layout.Height);

            Assert.AreEqual(25, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(25, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child1_child1.Layout.Left);
            Assert.AreEqual(0, root_child1_child1.Layout.Top);
            Assert.AreEqual(25, root_child1_child1.Layout.Width);
            Assert.AreEqual(10, root_child1_child1.Layout.Height);

            Assert.AreEqual(25, root_child1_child2.Layout.Left);
            Assert.AreEqual(20, root_child1_child2.Layout.Top);
            Assert.AreEqual(25, root_child1_child2.Layout.Width);
            Assert.AreEqual(20, root_child1_child2.Layout.Height);

            Assert.AreEqual(0, root_child1_child3.Layout.Left);
            Assert.AreEqual(20, root_child1_child3.Layout.Top);
            Assert.AreEqual(25, root_child1_child3.Layout.Width);
            Assert.AreEqual(10, root_child1_child3.Layout.Height);
        }

        [Test]
        public void align_baseline_child_top()
        {
            YogaNode root_child0, root_child1, root_child1_child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50, top:10))
                           .Add(
                                root_child1 = Node(width: 50, height: 20)
                                             .Add(root_child1_child0 = Node(width:50, height:10))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_child_top2()
        {
            YogaNode root_child0, root_child1, root_child1_child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50))
                           .Add(
                                root_child1 = Node(top:5, width: 50, height: 20)
                                             .Add(root_child1_child0 = Node(width:50, height:10))
                            );

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
            Assert.AreEqual(45, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(45, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_double_nested_child()
        {
            YogaNode root_child0, root_child0_child0, root_child1, root_child1_child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50)
                               .Add(root_child0_child0 = Node(width:50, height:20))
                            )
                           .Add(
                                root_child1 = Node(width: 50, height: 20)
                                   .Add(root_child1_child0 = Node(width:50, height:15))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(5, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(15, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(5, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(15, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_column()
        {
            YogaNode root_child0, root_child1;
            YogaNode root = Node(alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50))
                           .Add(root_child1 = Node(width: 50, height: 20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);
        }

        [Test]
        public void align_baseline_child_margin()
        {
            YogaNode root_child0, root_child1, root_child1_child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50, margin:Edges(left:5, top:5, right:5, bottom:5)))
                           .Add(root_child1 = Node(width: 50, height: 20)
                                   .Add(root_child1_child0 = Node(width:50, height:10, margin:Edges(left:1, top:1, right:1, bottom:1)))
                            );
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, root_child0.Layout.Left);
            Assert.AreEqual(5, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(60, root_child1.Layout.Left);
            Assert.AreEqual(44, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(1, root_child1_child0.Layout.Left);
            Assert.AreEqual(1, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(5, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(-10, root_child1.Layout.Left);
            Assert.AreEqual(44, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(-1, root_child1_child0.Layout.Left);
            Assert.AreEqual(1, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_child_padding()
        {
            YogaNode root_child0, root_child1, root_child1_child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100, padding:new Edges(5))
                           .Add(root_child0 = Node(width: 50, height: 50))
                           .Add(root_child1 = Node(width: 50, height: 20, padding:new Edges(5))
                               .Add(root_child1_child0 = Node(width:50, height:10))
                            );
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, root_child0.Layout.Left);
            Assert.AreEqual(5, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(55, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(5, root_child1_child0.Layout.Left);
            Assert.AreEqual(5, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(5, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(-5, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(-5, root_child1_child0.Layout.Left);
            Assert.AreEqual(5, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline()
        {
            YogaNode root_child0, root_child1, root_child1_child0, root_child2, root_child2_child0, root_child3;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50))
                           .Add(root_child1 = Node(width: 50, height: 20)
                               .Add(root_child1_child0 = Node(width:50, height:10))
                            )
                           .Add(root_child2 = Node(width:50, height:20)
                               .Add(root_child2_child0 = Node(width:50, height:10))
                            )
                           .Add(root_child3 = Node(width:50, height:50));
            
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
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(100, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child2_child0.Layout.Left);
            Assert.AreEqual(0, root_child2_child0.Layout.Top);
            Assert.AreEqual(50, root_child2_child0.Layout.Width);
            Assert.AreEqual(10, root_child2_child0.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(60, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(100, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child2_child0.Layout.Left);
            Assert.AreEqual(0, root_child2_child0.Layout.Top);
            Assert.AreEqual(50, root_child2_child0.Layout.Width);
            Assert.AreEqual(10, root_child2_child0.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(60, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline_column()
        {
            YogaNode root_child0, root_child1, root_child1_child0, root_child2, root_child2_child0, root_child3;
            YogaNode root = Node(alignItems: YogaAlign.Baseline, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50))
                           .Add(root_child1 = Node(width: 30, height: 50)
                               .Add(root_child1_child0 = Node(width:20, height:20))
                            )
                           .Add(root_child2 = Node(width:40, height:70)
                               .Add(root_child2_child0 = Node(width:10, height:10))
                            )
                           .Add(root_child3 = Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(20, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(40, root_child2.Layout.Width);
            Assert.AreEqual(70, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child2_child0.Layout.Left);
            Assert.AreEqual(0, root_child2_child0.Layout.Top);
            Assert.AreEqual(10, root_child2_child0.Layout.Width);
            Assert.AreEqual(10, root_child2_child0.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(70, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(70, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(20, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(40, root_child2.Layout.Width);
            Assert.AreEqual(70, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child2_child0.Layout.Left);
            Assert.AreEqual(0, root_child2_child0.Layout.Top);
            Assert.AreEqual(10, root_child2_child0.Layout.Width);
            Assert.AreEqual(10, root_child2_child0.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(70, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline_column2()
        {
            YogaNode root_child0, root_child1, root_child1_child0, root_child2, root_child2_child0, root_child3;
            YogaNode root = Node(alignItems: YogaAlign.Baseline, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50))
                           .Add(root_child1 = Node(width: 30, height: 50)
                               .Add(root_child1_child0 = Node(width:20, height:20))
                            )
                           .Add(root_child2 = Node(width:40, height:70)
                               .Add(root_child2_child0 = Node(width:10, height:10))
                            )
                           .Add(root_child3 = Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(20, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(40, root_child2.Layout.Width);
            Assert.AreEqual(70, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child2_child0.Layout.Left);
            Assert.AreEqual(0, root_child2_child0.Layout.Top);
            Assert.AreEqual(10, root_child2_child0.Layout.Width);
            Assert.AreEqual(10, root_child2_child0.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(70, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(70, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(20, root_child1_child0.Layout.Width);
            Assert.AreEqual(20, root_child1_child0.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(40, root_child2.Layout.Width);
            Assert.AreEqual(70, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child2_child0.Layout.Left);
            Assert.AreEqual(0, root_child2_child0.Layout.Top);
            Assert.AreEqual(10, root_child2_child0.Layout.Width);
            Assert.AreEqual(10, root_child2_child0.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(70, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline_row_and_column()
        {
            YogaNode root_child0, root_child1, root_child1_child0, root_child2, root_child2_child0, root_child3;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems: YogaAlign.Baseline, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 50))
                           .Add(root_child1 = Node(width: 50, height: 50)
                               .Add(root_child1_child0 = Node(width:50, height:10))
                            )
                           .Add(root_child2 = Node(width:50, height:20)
                               .Add(root_child2_child0 = Node(width:50, height:10))
                            )
                           .Add(root_child3 = Node(width:50, height:20));

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
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(100, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child2_child0.Layout.Left);
            Assert.AreEqual(0, root_child2_child0.Layout.Top);
            Assert.AreEqual(50, root_child2_child0.Layout.Width);
            Assert.AreEqual(10, root_child2_child0.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(90, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child1_child0.Layout.Top);
            Assert.AreEqual(50, root_child1_child0.Layout.Width);
            Assert.AreEqual(10, root_child1_child0.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(100, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(20, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child2_child0.Layout.Left);
            Assert.AreEqual(0, root_child2_child0.Layout.Top);
            Assert.AreEqual(50, root_child2_child0.Layout.Width);
            Assert.AreEqual(10, root_child2_child0.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(90, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);
        }

        [Test]
        public void align_items_center_child_with_margin_bigger_than_parent()
        {
            YogaNode root_child0, root_child0_child0;
            YogaNode root = Node(justifyContent:Justify.Center, alignItems:YogaAlign.Center, width: 52, height: 52)
                           .Add(root_child0 = Node(alignItems:YogaAlign.Center)
                               .Add(root_child0_child0 = Node(width:52, height:52, margin:Edges(left:10, right:10)))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(52, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(52, root_child0_child0.Layout.Width);
            Assert.AreEqual(52, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(52, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(52, root_child0_child0.Layout.Width);
            Assert.AreEqual(52, root_child0_child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_end_child_with_margin_bigger_than_parent()
        {
            YogaNode root_child0, root_child0_child0;
            YogaNode root = Node(justifyContent:Justify.Center, alignItems:YogaAlign.Center, width: 52, height: 52)
               .Add(root_child0 = Node(alignItems:YogaAlign.FlexEnd)
                   .Add(root_child0_child0 = Node(width:52, height:52, margin:Edges(left:10, right:10)))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(52, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(52, root_child0_child0.Layout.Width);
            Assert.AreEqual(52, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(52, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(52, root_child0_child0.Layout.Width);
            Assert.AreEqual(52, root_child0_child0.Layout.Height);
        }

        [Test]
        public void align_items_center_child_without_margin_bigger_than_parent()
        {
            YogaNode root_child0, root_child0_child0;
            YogaNode root = Node(justifyContent:Justify.Center, alignItems:YogaAlign.Center, width: 52, height: 52)
               .Add(root_child0 = Node(alignItems:YogaAlign.Center)
                   .Add(root_child0_child0 = Node(width:72, height:72))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(72, root_child0_child0.Layout.Width);
            Assert.AreEqual(72, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(72, root_child0_child0.Layout.Width);
            Assert.AreEqual(72, root_child0_child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_end_child_without_margin_bigger_than_parent()
        {
            YogaNode root_child0, root_child0_child0;
            YogaNode root = Node(justifyContent:Justify.Center, alignItems:YogaAlign.Center, width: 52, height: 52)
               .Add(root_child0 = Node(alignItems:YogaAlign.FlexEnd)
                   .Add(root_child0_child0 = Node(width:72, height:72))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(72, root_child0_child0.Layout.Width);
            Assert.AreEqual(72, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, root_child0.Layout.Left);
            Assert.AreEqual(-10, root_child0.Layout.Top);
            Assert.AreEqual(72, root_child0.Layout.Width);
            Assert.AreEqual(72, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(72, root_child0_child0.Layout.Width);
            Assert.AreEqual(72, root_child0_child0.Layout.Height);
        }

        [Test]
        public void align_center_should_size_based_on_content()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child0_child0;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 100, height: 100, margin:Edges(top:20))
               .Add(root_child0 = Node(alignItems:YogaAlign.Center, flexShrink:1)
                   .Add(root_child0_child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(root_child0_child0_child0 = Node(width:20, height:20))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(20, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(20, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(20, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(20, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0_child0.Layout.Height);
        }

        [Test]
        public void align_strech_should_size_based_on_parent()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child0_child0;
            YogaNode root = Node(width: 100, height: 100, margin:Edges(top:20))
               .Add(root_child0 = Node(justifyContent:Justify.Center, flexShrink:1)
                   .Add(root_child0_child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(root_child0_child0_child0 = Node(width:20, height:20))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(20, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0.Layout.Height);

            Assert.AreEqual(80, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(20, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(20, root_child0_child0_child0.Layout.Height);
        }

        [Test]
        public void align_flex_start_with_shrinking_children()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child0_child0;
            YogaNode root = Node(width: 500, height: 500)
               .Add(root_child0 = Node(alignItems:YogaAlign.FlexStart)
                   .Add(root_child0_child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(root_child0_child0_child0 = Node(flexGrow:1, flexShrink:1))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(500, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Height);
        }

        [Test]
        public void align_flex_start_with_stretching_children()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child0_child0;
            YogaNode root = Node(width: 500, height: 500)
               .Add(root_child0 = Node()
                   .Add(root_child0_child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(root_child0_child0_child0 = Node(flexGrow:1, flexShrink:1))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Height);
        }

        [Test]
        public void align_flex_start_with_shrinking_children_with_stretch()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child0_child0;
            YogaNode root = Node(width: 500, height: 500)
               .Add(root_child0 = Node(alignItems:YogaAlign.FlexStart)
                   .Add(root_child0_child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(root_child0_child0_child0 = Node(flexGrow:1, flexShrink:1))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(500, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(500, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Height);
        }
    }
}
