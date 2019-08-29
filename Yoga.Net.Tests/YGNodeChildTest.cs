using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGNodeChildTest
    {

        [Test] public void reset_layout_when_child_removed() {
            YGNodeRef root = YGNodeNew();

            YGNodeRef root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            YGNodeRemoveChild(root, root_child0);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.IsTrue(YogaIsUndefined(YGNodeLayoutGetWidth(root_child0)));
            Assert.IsTrue(YogaIsUndefined(YGNodeLayoutGetHeight(root_child0)));

            
        }
    }
}
