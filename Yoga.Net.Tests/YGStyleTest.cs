using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGStyleTest
    {

        [Test] public void copy_style_same() {
            YGNodeRef node0 = YGNodeNew();
            YGNodeRef node1 = YGNodeNew();
            Assert.IsFalse(node0.isDirty());

            YGNodeCopyStyle(node0, node1);
            Assert.IsFalse(node0.isDirty());

            
            
        }

        [Test] public void copy_style_modified() {
            YGNodeRef node0 = YGNodeNew();
            Assert.IsFalse(node0.isDirty());
            Assert.AreEqual(YGFlexDirection.Column, YGNodeStyleGetFlexDirection(node0));
            Assert.IsFalse(YGNodeStyleGetMaxHeight(node0).unit != YGUnit.Undefined);

            YGNodeRef node1 = YGNodeNew();
            YGNodeStyleSetFlexDirection(node1, YGFlexDirection.Row);
            YGNodeStyleSetMaxHeight(node1, 10);

            YGNodeCopyStyle(node0, node1);
            Assert.IsTrue(node0.isDirty());
            Assert.AreEqual(YGFlexDirection.Row, YGNodeStyleGetFlexDirection(node0));
            Assert.AreEqual(10, YGNodeStyleGetMaxHeight(node0).value);

            
            
        }

        [Test] public void copy_style_modified_same() {
            YGNodeRef node0 = YGNodeNew();
            YGNodeStyleSetFlexDirection(node0, YGFlexDirection.Row);
            YGNodeStyleSetMaxHeight(node0, 10);
            YGNodeCalculateLayout(node0, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            Assert.IsFalse(node0.isDirty());

            YGNodeRef node1 = YGNodeNew();
            YGNodeStyleSetFlexDirection(node1, YGFlexDirection.Row);
            YGNodeStyleSetMaxHeight(node1, 10);

            YGNodeCopyStyle(node0, node1);
            Assert.IsFalse(node0.isDirty());

            
            
        }

        [Test] public void initialise_flexShrink_flexGrow() {
            YGNodeRef node0 = YGNodeNew();
            YGNodeStyleSetFlexShrink(node0, 1);
            Assert.AreEqual(1, YGNodeStyleGetFlexShrink(node0));

            YGNodeStyleSetFlexShrink(node0, YGValue.YGUndefined);
            YGNodeStyleSetFlexGrow(node0, 3);
            Assert.AreEqual(
                0,
                YGNodeStyleGetFlexShrink(
                    node0)); // Default value is Zero, if flex shrink is not defined
            Assert.AreEqual(3, YGNodeStyleGetFlexGrow(node0));

            YGNodeStyleSetFlexGrow(node0, YGValue.YGUndefined);
            YGNodeStyleSetFlexShrink(node0, 3);
            Assert.AreEqual(
                0,
                YGNodeStyleGetFlexGrow(
                    node0)); // Default value is Zero, if flex grow is not defined
            Assert.AreEqual(3, YGNodeStyleGetFlexShrink(node0));
            
        }
    }
}