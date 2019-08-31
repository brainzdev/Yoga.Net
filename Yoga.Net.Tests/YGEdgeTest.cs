using NUnit.Framework;
using static Yoga.Net.YogaGlobal;



namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGEdgeTest
    {

        [Test] public void start_overrides() {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, YGEdge.Start, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.Left, 20);
            YGNodeStyleSetMargin(root_child0, YGEdge.Right, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetRight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);
            Assert.AreEqual(20, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(root_child0));

            
        }

        [Test] public void end_overrides() {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, YGEdge.End, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.Left, 20);
            YGNodeStyleSetMargin(root_child0, YGEdge.Right, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(20, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(root_child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.RTL);
            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetRight(root_child0));

            
        }

        [Test] public void horizontal_overridden() {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, YGEdge.Horizontal, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.Left, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(20, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(root_child0));

            
        }

        [Test] public void vertical_overridden() {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Column);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, YGEdge.Vertical, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.Top, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetBottom(root_child0));

            
        }

        [Test] public void horizontal_overrides_all() {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Column);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, YGEdge.Horizontal, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.All, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetBottom(root_child0));

            
        }

        [Test] public void vertical_overrides_all() {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Column);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, YGEdge.Vertical, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.All, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(20, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(20, YGNodeLayoutGetRight(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetBottom(root_child0));

            
        }

        [Test] public void all_overridden() {
            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Column);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetMargin(root_child0, YGEdge.Left, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.Top, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.Right, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.Bottom, 10);
            YGNodeStyleSetMargin(root_child0, YGEdge.All, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);
            Assert.AreEqual(10, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetBottom(root_child0));

            
        }
    }
}
