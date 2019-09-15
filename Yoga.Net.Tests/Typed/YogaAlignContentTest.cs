using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAlignContentTest
    {
        [Test]
        public void align_content_flex_start()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap, width: 130, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 10))
                           .Add(root_child1 = Node(width: 50, height: 10))
                           .Add(root_child2 = Node(width: 50, height: 10))
                           .Add(root_child3 = Node(width: 50, height: 10))
                           .Add(root_child4 = Node(width: 50, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(10, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(20, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(80, root_child2.Layout.Left);
            Assert.AreEqual(10, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(80, root_child4.Layout.Left);
            Assert.AreEqual(20, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_flex_start_without_height_on_children()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexWrap: Wrap.Wrap, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(width: 50, height: 10))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(width: 50, height: 10))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(10, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(20, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(10, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(10, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(20, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_flex_start_with_flex()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexWrap: Wrap.Wrap, width: 100, height: 120)
                           .Add(root_child0 = Node(flexGrow:1, flexBasis:0.Percent(), width: 50))
                           .Add(root_child1 = Node(flexGrow:1, flexBasis:0.Percent(), width: 50, height: 10))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(flexGrow:1, flexShrink:1,  flexBasis:0.Percent(), width: 50))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(40, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(80, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(120, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(40, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(40, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(80, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(80, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(40, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(120, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);
        }

        [Ignore("Exactly the same results as the C++ library")]
        [Test]
        public void align_content_flex_end()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(alignContent:YogaAlign.FlexEnd, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 10))
                           .Add(root_child1 = Node(width: 50, height: 10))
                           .Add(root_child2 = Node(width: 50, height: 10))
                           .Add(root_child3 = Node(width: 50, height: 10))
                           .Add(root_child4 = Node(width: 50, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(40, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(20, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(30, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(40, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(width: 50))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(width: 50))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(0, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(0, root_child0.Layout.Height);

            Assert.AreEqual(100, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(0, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(0, root_child3.Layout.Height);

            Assert.AreEqual(100, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(0, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_spacebetween()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.SpaceBetween, flexWrap:Wrap.Wrap, width: 130, height: 100)
                           .Add(root_child0 = Node(width: 50, height: 10))
                           .Add(root_child1 = Node(width: 50, height: 10))
                           .Add(root_child2 = Node(width: 50, height: 10))
                           .Add(root_child3 = Node(width: 50, height: 10))
                           .Add(root_child4 = Node(width: 50, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(45, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(45, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(90, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(30, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(80, root_child2.Layout.Left);
            Assert.AreEqual(45, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(30, root_child3.Layout.Left);
            Assert.AreEqual(45, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(80, root_child4.Layout.Left);
            Assert.AreEqual(90, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_spacearound()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.SpaceAround, flexWrap:Wrap.Wrap, width: 140, height: 120)
                           .Add(root_child0 = Node(width: 50, height: 10))
                           .Add(root_child1 = Node(width: 50, height: 10))
                           .Add(root_child2 = Node(width: 50, height: 10))
                           .Add(root_child3 = Node(width: 50, height: 10))
                           .Add(root_child4 = Node(width: 50, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(140, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(15, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(15, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(55, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(55, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(95, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(140, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(90, root_child0.Layout.Left);
            Assert.AreEqual(15, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(10, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(15, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(10, root_child1.Layout.Height);

            Assert.AreEqual(90, root_child2.Layout.Left);
            Assert.AreEqual(55, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(10, root_child2.Layout.Height);

            Assert.AreEqual(40, root_child3.Layout.Left);
            Assert.AreEqual(55, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(90, root_child4.Layout.Left);
            Assert.AreEqual(95, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(width: 50))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(width: 50))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_children()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4, root_child0_child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, flexWrap: Wrap.Wrap, width: 150, height: 100)
                           .Add(
                                root_child0 = Node(width: 50)
                                   .Add(root_child0_child0 = Node(flexGrow: 1, flexShrink: 1, flexBasis: 0.Percent()))
                            )
                           .Add(root_child1 = Node(width: 50))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(width: 50))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_flex()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 50))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 50))
                           .Add(root_child4 = Node(width: 50));
            
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
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(0, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(100, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(100, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(0, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_flex_no_shrink()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 50))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 50))
                           .Add(root_child4 = Node(width: 50));

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
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(0, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(100, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(100, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(0, root_child1.Layout.Width);
            Assert.AreEqual(100, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(100, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(0, root_child3.Layout.Top);
            Assert.AreEqual(0, root_child3.Layout.Width);
            Assert.AreEqual(100, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(100, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_margin()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(width: 50, margin:new Edges(10)))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(width: 50, margin:new Edges(10)))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            Assert.AreEqual(60, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(40, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(40, root_child2.Layout.Height);

            Assert.AreEqual(60, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(80, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(20, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(40, root_child0.Layout.Height);

            Assert.AreEqual(40, root_child1.Layout.Left);
            Assert.AreEqual(10, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(40, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(40, root_child2.Layout.Height);

            Assert.AreEqual(40, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            Assert.AreEqual(100, root_child4.Layout.Left);
            Assert.AreEqual(80, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(20, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_padding()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(width: 50, padding:new Edges(10)))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(width: 50, padding:new Edges(10)))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(50, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_single_row()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, flexWrap: Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(width: 50));
            
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
        public void align_content_stretch_row_with_fixed_height()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(width: 50, height:60))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(width: 50))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(60, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(80, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(80, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(80, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(20, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(80, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(60, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(80, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(80, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(20, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(80, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(20, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_max_height()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(width: 50, maxHeight:20))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(width: 50))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(20, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(50, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(50, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_min_height()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(root_child0 = Node(width: 50))
                           .Add(root_child1 = Node(width: 50, minHeight:80))
                           .Add(root_child2 = Node(width: 50))
                           .Add(root_child3 = Node(width: 50))
                           .Add(root_child4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(90, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(90, root_child1.Layout.Height);

            Assert.AreEqual(100, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(90, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(90, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(90, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(90, root_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(0, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(90, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(0, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(90, root_child2.Layout.Height);

            Assert.AreEqual(100, root_child3.Layout.Left);
            Assert.AreEqual(90, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(10, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(90, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(10, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_column()
        {
            YogaNode root_child0, root_child1, root_child2, root_child3, root_child4, root_child0_child0;
            YogaNode root = Node(alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 100, height: 150)
                           .Add(root_child0 = Node(height: 50)
                               .Add(root_child0_child0 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent()))
                            )
                           .Add(root_child1 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), height: 50))
                           .Add(root_child2 = Node(height: 50))
                           .Add(root_child3 = Node(height: 50))
                           .Add(root_child4 = Node(height: 50));


            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(150, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            Assert.AreEqual(0, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(0, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(0, root_child3.Layout.Left);
            Assert.AreEqual(100, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(50, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(150, root.Layout.Height);

            Assert.AreEqual(50, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(50, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(0, root_child0_child0.Layout.Top);
            Assert.AreEqual(50, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            Assert.AreEqual(50, root_child1.Layout.Left);
            Assert.AreEqual(50, root_child1.Layout.Top);
            Assert.AreEqual(50, root_child1.Layout.Width);
            Assert.AreEqual(0, root_child1.Layout.Height);

            Assert.AreEqual(50, root_child2.Layout.Left);
            Assert.AreEqual(50, root_child2.Layout.Top);
            Assert.AreEqual(50, root_child2.Layout.Width);
            Assert.AreEqual(50, root_child2.Layout.Height);

            Assert.AreEqual(50, root_child3.Layout.Left);
            Assert.AreEqual(100, root_child3.Layout.Top);
            Assert.AreEqual(50, root_child3.Layout.Width);
            Assert.AreEqual(50, root_child3.Layout.Height);

            Assert.AreEqual(0, root_child4.Layout.Left);
            Assert.AreEqual(0, root_child4.Layout.Top);
            Assert.AreEqual(50, root_child4.Layout.Width);
            Assert.AreEqual(50, root_child4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_is_not_overriding_align_items()
        {
            YogaNode root_child0, root_child0_child0;
            YogaNode root = Node(alignContent: YogaAlign.Stretch)
               .Add(
                    root_child0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, alignItems: YogaAlign.Center, width: 100, height: 100)
                       .Add(root_child0_child0 = Node(alignContent:YogaAlign.Stretch, width:10, height:10))
                );
           
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(0, root_child0_child0.Layout.Left);
            Assert.AreEqual(45, root_child0_child0.Layout.Top);
            Assert.AreEqual(10, root_child0_child0.Layout.Width);
            Assert.AreEqual(10, root_child0_child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, root_child0.Layout.Left);
            Assert.AreEqual(0, root_child0.Layout.Top);
            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(90, root_child0_child0.Layout.Left);
            Assert.AreEqual(45, root_child0_child0.Layout.Top);
            Assert.AreEqual(10, root_child0_child0.Layout.Width);
            Assert.AreEqual(10, root_child0_child0.Layout.Height);
        }
    }
}
