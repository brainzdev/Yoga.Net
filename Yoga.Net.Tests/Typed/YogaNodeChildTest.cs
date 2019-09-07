using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaNodeChildTest
    {
        [Test]
        public void reset_layout_when_child_removed()
        {
            YogaNode root = YGNodeNew();

            YogaNode root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            YGNodeRemoveChild(root, root_child0);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.IsTrue(YGNodeLayoutGetWidth(root_child0).IsUndefined());
            Assert.IsTrue(YGNodeLayoutGetHeight(root_child0).IsUndefined());
        }
    }
}
