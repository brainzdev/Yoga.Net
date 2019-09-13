using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaPersistenceTest
    {
        [Test]
        public void cloning_shared_root()
        {
            YogaConfig config = new YogaConfig {PrintTree = true};

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, width: 100, height: 100)
                           .AddChild(root_child0 = Node(flexGrow: 1, flexBasis: 50))
                           .AddChild(root_child1 = Node(flexGrow: 1));

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

            YogaNode root2 = YogaNode.Clone(root);
            root2.Style.Width = 100;

            Assert.AreEqual(2, root.ChildCount);
            // The children should have referential equality at this point.
            Assert.AreEqual(root_child0, root2.Children[0]);
            Assert.AreEqual(root_child1, root2.Children[1]);

            YogaArrange.CalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, root.ChildCount);
            // Relayout with no changed input should result in referential equality.
            Assert.AreEqual(root_child0, root2.Children[0]);
            Assert.AreEqual(root_child1, root2.Children[1]);

            root2.Style.Width = 150;
            root2.Style.Height = 200;
            YogaArrange.CalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, root2.ChildCount);
            // Re-layout with changed input should result in cloned children.
            YogaNode root2_child0 = root2.Children[0];
            YogaNode root2_child1 = root2.Children[1];

            Assert.AreNotEqual(root_child0, root2_child0);
            Assert.AreNotEqual(root_child1, root2_child1);

            // Everything in the root should remain unchanged.
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

            // The new root now has new layout.
            Assert.AreEqual(0, root2.Layout.Left);
            Assert.AreEqual(0, root2.Layout.Top);
            Assert.AreEqual(150, root2.Layout.Width);
            Assert.AreEqual(200, root2.Layout.Height);

            Assert.AreEqual(0, root2_child0.Layout.Left);
            Assert.AreEqual(0, root2_child0.Layout.Top);
            Assert.AreEqual(150, root2_child0.Layout.Width);
            Assert.AreEqual(125, root2_child0.Layout.Height);

            Assert.AreEqual(0, root2_child1.Layout.Left);
            Assert.AreEqual(125, root2_child1.Layout.Top);
            Assert.AreEqual(150, root2_child1.Layout.Width);
            Assert.AreEqual(75, root2_child1.Layout.Height);
        }

        [Test]
        public void mutating_children_of_a_clone_clones()
        {
            YogaConfig config = new YogaConfig
                { PrintTree = true };

            YogaNode root = Node(config);
            Assert.AreEqual(0, root.ChildCount);

            YogaNode root2 = YogaNode.Clone(root);
            Assert.AreEqual(0, root.ChildCount);

            YogaNode root2_child0 = new YogaNode(config);
            root2.Children.Add(root2_child0);

            Assert.AreEqual(0, root.ChildCount);
            Assert.AreEqual(1, root2.ChildCount);

            YogaNode root3 = YogaNode.Clone(root2);
            Assert.AreEqual(1, root2.ChildCount);
            Assert.AreEqual(1, root3.ChildCount);
            Assert.AreEqual(root2.Children[0], root3.Children[0]);

            YogaNode root3_child1 = new YogaNode(config);
            root3.Children.Add(root3_child1);
            Assert.AreEqual(1, root2.ChildCount);
            Assert.AreEqual(2, root3.ChildCount);
            Assert.AreEqual(root3_child1, root3.Children[1]);
            Assert.IsFalse(ReferenceEquals(root2.Children[0], root3.Children[1]));

            YogaNode root4 = YogaNode.Clone(root3);
            Assert.AreEqual(root3_child1, root4.Children[1]);

            root4.Children.Remove(root3_child1);
            Assert.AreEqual(2, root3.ChildCount);
            Assert.AreEqual(1, root4.ChildCount);
            //Assert.IsFalse(ReferenceEquals(root3.Children[0], root4.Children[0]));
        }

        [Test]
        public void cloning_two_levels()
        {
            YogaConfig config = new YogaConfig {PrintTree = true};

            YogaNode root_child0, root_child1, root_child1_0, root_child1_1;
            YogaNode root =
                Node(config, width: 100, height: 100)
                   .AddChild(root_child0 = Node(config, flexGrow: 1, flexBasis: 15))
                   .AddChild(root_child1 = Node(config, flexGrow: 1)
                                     .AddChild(root_child1_0 = Node(config, flexBasis: 10, flexGrow: 1))
                                     .AddChild(root_child1_1 = Node(config, flexBasis: 25)));


            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(40, root_child0.Layout.Height);
            Assert.AreEqual(60, root_child1.Layout.Height);
            Assert.AreEqual(35, root_child1_0.Layout.Height);
            Assert.AreEqual(25, root_child1_1.Layout.Height);

            YogaNode root2_child0 = YogaNode.Clone(root_child0);
            YogaNode root2_child1 = YogaNode.Clone(root_child1);
            YogaNode root2 = YogaNode.Clone(root);

            root2_child0.Style.FlexGrow = 0;
            root2_child0.Style.FlexBasis = 40;

            root2.Children.Clear();
            root2.Children.Add(root2_child0);
            root2.Children.Add(root2_child1);
            Assert.AreEqual(2, root.ChildCount);

            YogaArrange.CalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            // Original root is unchanged
            Assert.AreEqual(40, root_child0.Layout.Height);
            Assert.AreEqual(60, root_child1.Layout.Height);
            Assert.AreEqual(35, root_child1_0.Layout.Height);
            Assert.AreEqual(25, root_child1_1.Layout.Height);

            // New root has new layout at the top
            Assert.AreEqual(40, root2_child0.Layout.Height);
            Assert.AreEqual(60, root2_child1.Layout.Height);

            // The deeper children are untouched.
            Assert.AreEqual(root_child1_0, root2_child1.Children[0]);
            Assert.AreEqual(root_child1_1, root2_child1.Children[1]);
        }

        [Test]
        public void cloning_and_freeing()
        {
            //int initialInstanceCount = YGNodeGetInstanceCount();

            YogaConfig config = new YogaConfig {PrintTree = true};

            YogaNode root_child0, root_child1;
            YogaNode root = Node(config, width: 100, height: 100)
                           .AddChild(root_child0 = Node(config))
                           .AddChild(root_child1 = Node(config));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            YogaNode root2 = YogaNode.Clone(root);

            // Freeing the original root should be safe as long as we don't free its
            // children.

            YogaArrange.CalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            //Assert.AreEqual(initialInstanceCount, YGNodeGetInstanceCount());
        }
    }
}
