using NUnit.Framework;
using static Yoga.Net.YGGlobal;



namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGSizeOverflowTest
    {

        [Test]
        public void nested_overflowing_child()
        {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 200);
            YGNodeStyleSetHeight(root_child0_child0, 200);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(-100, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0_child0));

            

            
        }

        [Test]
        public void nested_overflowing_child_in_constraint_parent()
        {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 200);
            YGNodeStyleSetHeight(root_child0_child0, 200);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(-100, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0_child0));

            

            
        }

        [Test]
        public void parent_wrap_child_size_overflowing_parent()
        {
            YGConfig config = YGConfigNew();

            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YGNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeStyleSetHeight(root_child0_child0, 200);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0_child0));

            

            
        }
    }
}
