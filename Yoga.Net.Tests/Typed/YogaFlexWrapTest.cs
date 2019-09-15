using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaFlexWrapTest
    {
        [Test]
        public void wrap_column()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3;
            YogaNode root = Node(flexWrap:Wrap.Wrap, height:100)
                           .AddChild(root_child0 = Node(width:30, height:30))
                           .AddChild(root_child1 = Node(width:30, height:30))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:30));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(60, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(30, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(60, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(60, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(30, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(30, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(30, root_child2.Layout.Left);
            Assert.AreEqual(60, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);
        }

        [Test]
        public void wrap_row()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:100)
                           .AddChild(root_child0 = Node(width:30, height:30))
                           .AddChild(root_child1 = Node(width:30, height:30))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:30));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(30, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(30, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(30, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);
        }

        [Test]
        public void wrap_row_align_items_flex_end()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.FlexEnd, flexWrap:Wrap.Wrap, width:100)
                           .AddChild(root_child0 = Node(width:30, height:10))
                           .AddChild(root_child1 = Node(width:30, height:20))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:30));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(20, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(20, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);
        }

        [Test]
        public void wrap_row_align_items_center()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.Center, flexWrap:Wrap.Wrap, width:100)
                           .AddChild(root_child0 = Node(width:30, height:10))
                           .AddChild(root_child1 = Node(width:30, height:20))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:30));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(5, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(10, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(5, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(30, root_child3.Layout.Height);
        }

        [Test]
        public void flex_wrap_children_with_min_main_overriding_flex_basis()
        {
            YogaNode root_child0, root_child1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:100)
                           .AddChild(root_child0 = Node(flexBasis:50, minWidth:55, height:50))
                           .AddChild(root_child1 = Node(flexBasis:50, minWidth:55, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(55, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(55, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(55, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(45, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(55, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);
        }

        [Test]
        public void flex_wrap_wrap_to_child_height()
        {
            YogaNode root_child0, root_child1, root_child0_child0, root_child0_child0_child0;
            YogaNode root = Node()
                           .AddChild(
                                root_child0 = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.FlexStart, flexWrap: Wrap.Wrap)
                                   .AddChild(
                                        root_child0_child0 = Node(width:100)
                                           .AddChild(root_child0_child0_child0 = Node(width:100, height:100))
                                    )
                            )
                           .AddChild(root_child1 = Node(width: 100, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(100, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(100, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(100, root_child1.Layout.Top);
            Assert.AreEqual(100, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Ignore("Exactly the same result as the c++ library")]
        [Test]
        public void flex_wrap_align_stretch_fits_one_row()
        {
            YogaNode root_child0, root_child1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:150, height:100)
                           .AddChild(root_child0 = Node(width:50))
                           .AddChild(root_child1 = Node(width:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
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
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_flex_start()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.WrapReverse, width:100)
                           .AddChild(root_child0 = Node(width:30, height:10))
                           .AddChild(root_child1 = Node(width:30, height:20))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:40))
                           .AddChild(root_child4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(40, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_center()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Center, flexWrap:Wrap.WrapReverse, width:100)
                           .AddChild(root_child0 = Node(width:30, height:10))
                           .AddChild(root_child1 = Node(width:30, height:20))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:40))
                           .AddChild(root_child4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(40, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_single_line_different_size()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.WrapReverse, width:300)
                           .AddChild(root_child0 = Node(width:30, height:10))
                           .AddChild(root_child1 = Node(width:30, height:20))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:40))
                           .AddChild(root_child4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(300, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(40, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(90, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(120, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(300, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(270, root_child0.Layout.Left);
            Assert.AreEqual(40, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(240, root_child1.Layout.Left);
            Assert.AreEqual(30, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(210, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(180, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(150, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_stretch()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.WrapReverse, width:100)
                           .AddChild(root_child0 = Node(width:30, height:10))
                           .AddChild(root_child1 = Node(width:30, height:20))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:40))
                           .AddChild(root_child4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(40, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_space_around()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.SpaceAround, flexWrap:Wrap.WrapReverse, width:100)
                           .AddChild(root_child0 = Node(width:30, height:10))
                           .AddChild(root_child1 = Node(width:30, height:20))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:40))
                           .AddChild(root_child4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(60, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, root_child0.Layout.Left);
            Assert.AreEqual(70, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(60, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(10, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(70, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(40, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_column_fixed_size()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(alignItems:YogaAlign.Center, flexWrap:Wrap.WrapReverse, width:200, height:100)
                           .AddChild(root_child0 = Node(width:30, height:10))
                           .AddChild(root_child1 = Node(width:30, height:20))
                           .AddChild(root_child2 = Node(width:30, height:30))
                           .AddChild(root_child3 = Node(width:30, height:40))
                           .AddChild(root_child4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(170, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(170, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(170, root_child2.Layout.Left);
            Assert.AreEqual(30, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(170, root_child3.Layout.Left);
            Assert.AreEqual(60, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(140, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(30, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(30, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(30, root_child2.Layout.Top);
            Assert.AreEqual(30, root_child2.Layout.Width);
            Assert.AreEqual(30, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(60, root_child3.Layout.Top);
            Assert.AreEqual(30, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(30, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(30, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void wrapped_row_within_align_items_center()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child1;
            YogaNode root = Node(alignItems: YogaAlign.Center, width: 200, height: 200)
                           .AddChild(
                                root_child0 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap)
                                             .AddChild(root_child0_child0 = Node(width: 150, height: 80))
                                             .AddChild(root_child0_child1 = Node(width: 80, height:80))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(120, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);
        }

        [Test]
        public void wrapped_row_within_align_items_flex_start()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child1;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 200, height: 200)
               .AddChild(
                    root_child0 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap)
                                 .AddChild(root_child0_child0 = Node(width:150, height:80))
                                 .AddChild(root_child0_child1 = Node(width:80, height:80))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(120, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);
        }

        [Test]
        public void wrapped_row_within_align_items_flex_end()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child1;
            YogaNode root = Node(alignItems: YogaAlign.FlexEnd, width: 200, height: 200)
               .AddChild(
                    root_child0 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap)
                                 .AddChild(root_child0_child0 = Node(width:150, height:80))
                                 .AddChild(root_child0_child1 = Node(width:80, height:80))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(200, root_child0.Layout.Width);
            Assert.AreEqual(160, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(150, root_child0_child0.Layout.Width);
            Assert.AreEqual(80, root_child0_child0.Layout.Height);

            Assert.AreEqual(120, root_child0_child1.Layout.Left);
            Assert.AreEqual(80, root_child0_child1.Layout.Top);
            Assert.AreEqual(80, root_child0_child1.Layout.Width);
            Assert.AreEqual(80, root_child0_child1.Layout.Height);
        }

        [Test]
        public void wrapped_column_max_height()
        {
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(justifyContent: Justify.Center, alignContent: YogaAlign.Center, alignItems: YogaAlign.Center, flexWrap: Wrap.Wrap, width: 700, height: 500)
                           .AddChild(root_child0 = Node(width: 100, height: 500, maxHeight: 200))
                           .AddChild(root_child1 = Node(width: 200, height: 200, margin:Edges(left:20, top:20, right:20, bottom:20)))
                           .AddChild(root_child2 = Node(width: 100, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(250, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(200, root_child1.Layout.Left);
            Assert.AreEqual(250, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(200, root_child1.Layout.Height);

            Assert.AreEqual(420, root_child2.Layout.Left);
            Assert.AreEqual(200, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(350, root_child0.Layout.Left);
            Assert.AreEqual(30, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(200, root_child0.Layout.Height);

            Assert.AreEqual(300, root_child1.Layout.Left);
            Assert.AreEqual(250, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(200, root_child1.Layout.Height);

            Assert.AreEqual(180, root_child2.Layout.Left);
            Assert.AreEqual(200, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void wrapped_column_max_height_flex()
        {
            
            YogaNode root_child0, root_child1, root_child2;
            YogaNode root = Node(justifyContent: Justify.Center, alignContent: YogaAlign.Center, alignItems: YogaAlign.Center, flexWrap: Wrap.Wrap, width: 700, height: 500)
                           .AddChild(root_child0 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 100, height: 150, maxHeight: 200))
                           .AddChild(root_child1 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), margin:Edges(left:20, top:20, right:20, bottom:20), width: 200, height: 200))
                           .AddChild(root_child2 = Node(width: 100, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(300, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(180, root_child0.Layout.Height);

            Assert.AreEqual(250, root_child1.Layout.Left);
            Assert.AreEqual(200, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(180, root_child1.Layout.Height);

            Assert.AreEqual(300, root_child2.Layout.Left);
            Assert.AreEqual(400, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(300, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(180, root_child0.Layout.Height);

            Assert.AreEqual(250, root_child1.Layout.Left);
            Assert.AreEqual(200, root_child1.Layout.Top);
            Assert.AreEqual(200, root_child1.Layout.Width);
            Assert.AreEqual(180, root_child1.Layout.Height);

            Assert.AreEqual(300, root_child2.Layout.Left);
            Assert.AreEqual(400, root_child2.Layout.Top);
            Assert.AreEqual(100, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);
        }

        [Test]
        public void wrap_nodes_with_content_sizing_overflowing_margin()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child0_child0, root_child0_child1, root_child0_child1_child0;
            YogaNode root = Node(width: 500, height: 500)
               .AddChild(
                    root_child0 = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:85)
                                 .AddChild(
                                      root_child0_child0 = Node()
                                         .AddChild(root_child0_child0_child0 = Node(width:40, height:40))
                                  )
                                 .AddChild(
                                      root_child0_child1 = Node(margin:Edges(right:10))
                                         .AddChild(root_child0_child1_child0 = Node(width:40, height:40))
                                  )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(85, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(40, root_child0_child1.Layout.Top);
            Assert.AreEqual(40, root_child0_child1.Layout.Width);
            Assert.AreEqual(40, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, root_child0_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child1_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child1_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(415, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(85, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(45, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0_child0.Layout.Height);

            Assert.AreEqual(35, root_child0_child1.Layout.Left);
            Assert.AreEqual(40, root_child0_child1.Layout.Top);
            Assert.AreEqual(40, root_child0_child1.Layout.Width);
            Assert.AreEqual(40, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, root_child0_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child1_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child1_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child1_child0.Layout.Height);
        }

        [Test]
        public void wrap_nodes_with_content_sizing_margin_cross()
        {
            YogaNode root_child0, root_child0_child0, root_child0_child0_child0, root_child0_child1, root_child0_child1_child0;
            YogaNode root = Node(width: 500, height: 500)
               .AddChild(
                    root_child0 = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:70)
                                 .AddChild(
                                      root_child0_child0 = Node()
                                         .AddChild(root_child0_child0_child0 = Node(width:40, height:40))
                                  )
                                 .AddChild(
                                      root_child0_child1 = Node(margin:Edges(top:10))
                                         .AddChild(root_child0_child1_child0 = Node(width:40, height:40))
                                  )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(70, root_child0.Layout.Width);
            Assert.AreEqual(90, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child1.Layout.Left);
            Assert.AreEqual(50, root_child0_child1.Layout.Top);
            Assert.AreEqual(40, root_child0_child1.Layout.Width);
            Assert.AreEqual(40, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, root_child0_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child1_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child1_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child1_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(430, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(70, root_child0.Layout.Width);
            Assert.AreEqual(90, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child0_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child0_child0.Layout.Height);

            Assert.AreEqual(30, root_child0_child1.Layout.Left);
            Assert.AreEqual(50, root_child0_child1.Layout.Top);
            Assert.AreEqual(40, root_child0_child1.Layout.Width);
            Assert.AreEqual(40, root_child0_child1.Layout.Height);

            Assert.AreEqual(0, root_child0_child1_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child1_child0.Layout.Top);
            Assert.AreEqual(40, root_child0_child1_child0.Layout.Width);
            Assert.AreEqual(40, root_child0_child1_child0.Layout.Height);
        }
    }
}
