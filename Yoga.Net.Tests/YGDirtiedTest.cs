using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGDirtiedTest
    {

        static void _dirtied(YGNodeRef node)
        {
            int dirtiedCount = (int)node.getContext();
            dirtiedCount++;
            node.setContext(dirtiedCount);
        }

        [Test] public void dirtied() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            //int dirtiedCount = 0;
            root.setContext(0);
            root.setDirtiedFunc(_dirtied);

            Assert.AreEqual(0, (int)root.getContext());

            // `_dirtied` MUST be called in case of explicit dirtying.
            root.setDirty(true);
            Assert.AreEqual(1, (int)root.getContext());

            // `_dirtied` MUST be called ONCE.
            root.setDirty(true);
            Assert.AreEqual(1, (int)root.getContext());
        }

        [Test] public void dirtied_propagation() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNew();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            root.setContext(0);
            root.setDirtiedFunc(_dirtied);

            Assert.AreEqual(0, (int)root.getContext());

            // `_dirtied` MUST be called for the first time.
            root_child0.markDirtyAndPropogate();
            Assert.AreEqual(1, (int)root.getContext());

            // `_dirtied` must NOT be called for the second time.
            root_child0.markDirtyAndPropogate();
            Assert.AreEqual(1, (int)root.getContext());
        }

        [Test] public void dirtied_hierarchy() {
            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 20);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNew();
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            root_child0.setContext(0);
            root_child0.setDirtiedFunc(_dirtied);

            Assert.AreEqual(0, (int)root_child0.getContext());

            // `_dirtied` must NOT be called for descendants.
            root.markDirtyAndPropogate();
            Assert.AreEqual(0, (int)root_child0.getContext());

            // `_dirtied` must NOT be called for the sibling node.
            root_child1.markDirtyAndPropogate();
            Assert.AreEqual(0, (int)root_child0.getContext());

            // `_dirtied` MUST be called in case of explicit dirtying.
            root_child0.markDirtyAndPropogate();
            Assert.AreEqual(1, (int)root_child0.getContext());
        }
    }
}
