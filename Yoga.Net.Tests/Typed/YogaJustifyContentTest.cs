using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaJustifyContentTest
    {
        [Test]
        public void justify_content_row_flex_start()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 102, height: 102)
                           .Add(root_child0 = Node(width:10))
                           .Add(root_child1 = Node(width:10))
                           .Add(root_child2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(20, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(92, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(82, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(72, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_flex_end()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.FlexEnd, width: 102, height: 102)
                           .Add(root_child0 = Node(width:10))
                           .Add(root_child1 = Node(width:10))
                           .Add(root_child2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(72, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(82, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(92, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(20, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_center()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.Center, width: 102, height: 102)
                           .Add(root_child0 = Node(width:10))
                           .Add(root_child1 = Node(width:10))
                           .Add(root_child2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(36, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(56, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(56, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(36, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_space_between()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.SpaceBetween, width: 102, height: 102)
                           .Add(root_child0 = Node(width:10))
                           .Add(root_child1 = Node(width:10))
                           .Add(root_child2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(92, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(92, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_space_around()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.SpaceAround, width: 102, height: 102)
                           .Add(root_child0 = Node(width:10))
                           .Add(root_child1 = Node(width:10))
                           .Add(root_child2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(12, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(80, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(102, root_child0.Layout.Height);

            Assert.AreEqual(46, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(102, root_child1.Layout.Height);

            Assert.AreEqual(12, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(102, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_flex_start()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(width: 102, height: 102)
                           .Add(root_child0 = Node(height:10))
                           .Add(root_child1 = Node(height:10))
                           .Add(root_child2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_flex_end()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(justifyContent:Justify.FlexEnd, width: 102, height: 102)
                           .Add(root_child0 = Node(height:10))
                           .Add(root_child1 = Node(height:10))
                           .Add(root_child2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(72, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(82, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(92, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(72, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(82, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(92, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_center()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(justifyContent:Justify.Center, width: 102, height: 102)
                           .Add(root_child0 = Node(height:10))
                           .Add(root_child1 = Node(height:10))
                           .Add(root_child2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(36, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(56, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(36, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(56, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_space_between()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(justifyContent:Justify.SpaceBetween, width: 102, height: 102)
                           .Add(root_child0 = Node(height:10))
                           .Add(root_child1 = Node(height:10))
                           .Add(root_child2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(92, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(92, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_column_space_around()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(justifyContent:Justify.SpaceAround, width: 102, height: 102)
                           .Add(root_child0 = Node(height:10))
                           .Add(root_child1 = Node(height:10))
                           .Add(root_child2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(12, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(12, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_min_width_and_margin()
        {
            YogaNode root_child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent: Justify.Center, margin: Edges(left: 100), minWidth: 50)
               .Add(root_child0 = Node(width:20, height: 20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(15, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(15, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_greater_than_parent()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child0_child0;
            YogaNode root = Node(alignContent: YogaAlign.Stretch, width: 1000, height: 1584)
               .Add(root_child0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch)
                       .Add(root_child0_child0 = Node(flexDirection: FlexDirection.Row, justifyContent: Justify.Center, alignContent: YogaAlign.Stretch, minWidth: 400, padding: Edges(horizontal: 100))
                               .Add(root_child0_child0_child0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, width: 300, height: 100))
                        )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1000, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(1000, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(100, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(300, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1000, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(1000, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(500, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(500, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(100, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(300, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0_child0.Layout.Height);
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_lower_than_parent()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child0_child0;
            YogaNode root = Node(alignContent: YogaAlign.Stretch, width: 1080, height: 1584)
               .Add(root_child0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch)
                   .Add(root_child0_child0 = Node(flexDirection: FlexDirection.Row, justifyContent: Justify.Center, alignContent: YogaAlign.Stretch, minWidth: 400, padding: Edges(horizontal: 100))
                       .Add(root_child0_child0_child0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, width: 199, height: 100))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1080, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(1080, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(400, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(101, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(199, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1080, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(1080, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(680, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(400, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(101, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(199, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0_child0.Layout.Height);
        }

        [Test]
        public void justify_content_row_max_width_and_margin()
        {
            YogaNode root_child0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, justifyContent:Justify.Center, margin:Edges(left:100), width:100, maxWidth:80)
               .Add(root_child0 = Node(width:20, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(80, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(30, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(80, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(30, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void justify_content_column_min_height_and_margin()
        {
            YogaNode root_child0;
            YogaNode root = Node(justifyContent:Justify.Center, margin:Edges(top:100), minHeight:50)
               .Add(root_child0 = Node(width:20, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(15, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(15, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void justify_content_colunn_max_height_and_margin()
        {
            YogaNode root_child0;
            YogaNode root = Node(justifyContent:Justify.Center, margin:Edges(top:100), height:100, maxHeight:80)
               .Add(root_child0 = Node(width:20, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(20, root_child0.Layout.Width);
            Assert.AreEqual(20, root_child0.Layout.Height);
        }

        [Test]
        public void justify_content_column_space_evenly()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(justifyContent: Justify.SpaceEvenly, width: 102, height: 102)
                           .Add(root_child0 = Node(height: 10))
                           .Add(root_child1 = Node(height: 10))
                           .Add(root_child2 = Node(height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(18, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(74, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(18, root_child0.Layout.Top);
            Assert.AreEqual(102, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(46, root_child1.Layout.Top);
            Assert.AreEqual(102, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(74, root_child2.Layout.Top);
            Assert.AreEqual(102, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void justify_content_row_space_evenly()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection:FlexDirection.Row, justifyContent:Justify.SpaceEvenly, width: 102, height: 102)
                           .Add(root_child0 = Node(height: 10))
                           .Add(root_child1 = Node(height: 10))
                           .Add(root_child2 = Node(height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(26, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(51, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(77, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(0, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(77, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(0, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(51, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(26, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(0, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }
    }
}
