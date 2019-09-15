using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaFlexDirectionTest
    {
        [Test]
        public void flex_direction_column_no_height()
        {

            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(width: 100)
                           .AddChild(root_child0 = Node(height: 10))
                           .AddChild(root_child1 = Node(height: 10))
                           .AddChild(root_child2 = Node(height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void flex_direction_row_no_width()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection:FlexDirection.Row, height: 100)
                           .AddChild(root_child0 = Node(width: 10))
                           .AddChild(root_child1 = Node(width: 10))
                           .AddChild(root_child2 = Node(width: 10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(20, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void flex_direction_column()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(width: 100, height:100)
                           .AddChild(root_child0 = Node(height: 10))
                           .AddChild(root_child1 = Node(height: 10))
                           .AddChild(root_child2 = Node(height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void flex_direction_row()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 100, height:100)
                           .AddChild(root_child0 = Node(width: 10))
                           .AddChild(root_child1 = Node(width: 10))
                           .AddChild(root_child2 = Node(width: 10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(20, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(80, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(70, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void flex_direction_column_reverse()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection:FlexDirection.ColumnReverse, width: 100, height:100)
                           .AddChild(root_child0 = Node(height: 10))
                           .AddChild(root_child1 = Node(height: 10))
                           .AddChild(root_child2 = Node(height: 10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(90, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(80, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(70, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(90, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(80, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(70, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);
        }

        [Test]
        public void flex_direction_row_reverse()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(flexDirection:FlexDirection.RowReverse, width: 100, height:100)
                           .AddChild(root_child0 = Node(width: 10))
                           .AddChild(root_child1 = Node(width: 10))
                           .AddChild(root_child2 = Node(width: 10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(80, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(70, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(10, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(10, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(10, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(20, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(10, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }
    }
}
