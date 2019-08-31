using NUnit.Framework;
using static Yoga.Net.YogaGlobal;



namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGPersistenceTest
    {

        [Test] public void cloning_shared_root() {
            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(75, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));

            YGNode root2 = YGNodeClone(root);
            YGNodeStyleSetWidth(root2, 100);

            Assert.AreEqual(2, YGNodeGetChildCount(root2));
            // The children should have referential equality at this point.
            Assert.AreEqual(root_child0, root2.Children[0]);
            Assert.AreEqual(root_child1, root2.Children[1]);

            YGNodeCalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(2, YGNodeGetChildCount(root2));
            // Relayout with no changed input should result in referential equality.
            Assert.AreEqual(root_child0, root2.Children[0]);
            Assert.AreEqual(root_child1, root2.Children[1]);

            YGNodeStyleSetWidth(root2, 150);
            YGNodeStyleSetHeight(root2, 200);
            YGNodeCalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(2, YGNodeGetChildCount(root2));
            // Relayout with changed input should result in cloned children.
            YGNode root2_child0 = root2.Children[0];
            YGNode root2_child1 = root2.Children[1];

            Assert.AreNotEqual(root_child0, root2_child0);
            Assert.AreNotEqual(root_child1, root2_child1);

            // Everything in the root should remain unchanged.
            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(75, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1));

            // The new root now has new layout.
            Assert.AreEqual(0, YGNodeLayoutGetLeft(root2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root2));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root2));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root2_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root2_child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root2_child0));
            Assert.AreEqual(125, YGNodeLayoutGetHeight(root2_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root2_child1));
            Assert.AreEqual(125, YGNodeLayoutGetTop(root2_child1));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root2_child1));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root2_child1));

            
        }

        [Test] public void mutating_children_of_a_clone_clones() {
            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);

            YGNode root = YGNodeNewWithConfig(config);
            Assert.AreEqual(0, YGNodeGetChildCount(root));

            YGNode root2 = YGNodeClone(root);
            Assert.AreEqual(0, YGNodeGetChildCount(root2));

            YGNode root2_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root2, root2_child0, 0);

            Assert.AreEqual(0, YGNodeGetChildCount(root));
            Assert.AreEqual(1, YGNodeGetChildCount(root2));

            YGNode root3 = YGNodeClone(root2);
            Assert.AreEqual(1, YGNodeGetChildCount(root2));
            Assert.AreEqual(1, YGNodeGetChildCount(root3));
            Assert.AreEqual(root2.Children[0], root3.Children[0]);

            YGNode root3_child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root3, root3_child1, 1);
            Assert.AreEqual(1, YGNodeGetChildCount(root2));
            Assert.AreEqual(2, YGNodeGetChildCount(root3));
            Assert.AreEqual(root3_child1, root3.Children[1]);
            Assert.IsFalse(ReferenceEquals(root2.Children[0], root3.Children[1]));

            YGNode root4 = YGNodeClone(root3);
            Assert.AreEqual(root3_child1, root4.Children[1]);

            YGNodeRemoveChild(root4, root3_child1);
            Assert.AreEqual(2, YGNodeGetChildCount(root3));
            Assert.AreEqual(1, YGNodeGetChildCount(root4));
            Assert.IsFalse(ReferenceEquals(root3.Children[0], root4.Children[0]));
        }

        [Test] public void cloning_two_levels() {
            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 15);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeInsertChild(root, root_child1, 1);

            YGNode root_child1_0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child1_0, 10);
            YGNodeStyleSetFlexGrow(root_child1_0, 1);
            YGNodeInsertChild(root_child1, root_child1_0, 0);

            YGNode root_child1_1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(root_child1_1, 25);
            YGNodeInsertChild(root_child1, root_child1_1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root_child1));
            Assert.AreEqual(35, YGNodeLayoutGetHeight(root_child1_0));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1_1));

            YGNode root2_child0 = YGNodeClone(root_child0);
            YGNode root2_child1 = YGNodeClone(root_child1);
            YGNode root2 = YGNodeClone(root);

            YGNodeStyleSetFlexGrow(root2_child0, 0);
            YGNodeStyleSetFlexBasis(root2_child0, 40);

            YGNodeRemoveAllChildren(root2);
            YGNodeInsertChild(root2, root2_child0, 0);
            YGNodeInsertChild(root2, root2_child1, 1);
            Assert.AreEqual(2, YGNodeGetChildCount(root2));

            YGNodeCalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            // Original root is unchanged
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root_child1));
            Assert.AreEqual(35, YGNodeLayoutGetHeight(root_child1_0));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(root_child1_1));

            // New root has new layout at the top
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root2_child0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root2_child1));

            // The deeper children are untouched.
            Assert.AreEqual(root_child1_0, root2_child1.Children[0]);
            Assert.AreEqual(root_child1_1, root2_child1.Children[1]);

        }

        [Test] public void cloning_and_freeing() {
            //int initialInstanceCount = YGNodeGetInstanceCount();

            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);
            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, root_child0, 0);
            YGNode root_child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            YGNode root2 = YGNodeClone(root);

            // Freeing the original root should be safe as long as we don't free its
            // children.
            

            YGNodeCalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);

            //Assert.AreEqual(initialInstanceCount, YGNodeGetInstanceCount());
        }
    }
}