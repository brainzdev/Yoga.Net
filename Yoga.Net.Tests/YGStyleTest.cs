using NUnit.Framework;
using static Yoga.Net.YogaGlobal;



namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGStyleTest
    {

        [Test] public void copy_style_same() {
            YGNode node0 = YGNodeNew();
            YGNode node1 = YGNodeNew();
            Assert.IsFalse(node0.IsDirty);

            YGNodeCopyStyle(node0, node1);
            Assert.IsFalse(node0.IsDirty);

            
            
        }

        [Test] public void copy_style_modified() {
            YGNode node0 = YGNodeNew();
            Assert.IsFalse(node0.IsDirty);
            Assert.AreEqual(YGFlexDirection.Column, YGNodeStyleGetFlexDirection(node0));
            Assert.IsFalse(YGNodeStyleGetMaxHeight(node0).Unit != YGUnit.Undefined);

            YGNode node1 = YGNodeNew();
            YGNodeStyleSetFlexDirection(node1, YGFlexDirection.Row);
            YGNodeStyleSetMaxHeight(node1, 10);

            YGNodeCopyStyle(node0, node1);
            Assert.IsTrue(node0.IsDirty);
            Assert.AreEqual(YGFlexDirection.Row, YGNodeStyleGetFlexDirection(node0));
            Assert.AreEqual(10, YGNodeStyleGetMaxHeight(node0).Value);

            
            
        }

        [Test] public void copy_style_modified_same() {
            YGNode node0 = YGNodeNew();
            YGNodeStyleSetFlexDirection(node0, YGFlexDirection.Row);
            YGNodeStyleSetMaxHeight(node0, 10);
            YGNodeCalculateLayout(node0, YogaValue.YGUndefined, YogaValue.YGUndefined, YGDirection.LTR);
            Assert.IsFalse(node0.IsDirty);

            YGNode node1 = YGNodeNew();
            YGNodeStyleSetFlexDirection(node1, YGFlexDirection.Row);
            YGNodeStyleSetMaxHeight(node1, 10);

            YGNodeCopyStyle(node0, node1);
            Assert.IsFalse(node0.IsDirty);

            
            
        }

        [Test] public void initialise_flexShrink_flexGrow() {
            YGNode node0 = YGNodeNew();
            YGNodeStyleSetFlexShrink(node0, 1);
            Assert.AreEqual(1, YGNodeStyleGetFlexShrink(node0));

            YGNodeStyleSetFlexShrink(node0, YogaValue.YGUndefined);
            YGNodeStyleSetFlexGrow(node0, 3);
            Assert.AreEqual(
                0,
                YGNodeStyleGetFlexShrink(node0)); // Default value is Zero, if flex shrink is not defined
            Assert.AreEqual(3, YGNodeStyleGetFlexGrow(node0));

            YGNodeStyleSetFlexGrow(node0, YogaValue.YGUndefined);
            YGNodeStyleSetFlexShrink(node0, 3);
            Assert.AreEqual(
                0,
                YGNodeStyleGetFlexGrow(node0)); // Default value is Zero, if flex grow is not defined
                Assert.AreEqual(3, YGNodeStyleGetFlexShrink(node0));
            
        }
    }
}