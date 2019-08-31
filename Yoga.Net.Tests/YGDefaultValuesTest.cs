using NUnit.Framework;
using static Yoga.Net.YogaGlobal;



namespace Yoga.Net.Tests
{

    [TestFixture]
    public class YGDefaultValuesTest
    {

        [Test] public void assert_default_values() {
            YGNode root = YGNodeNew();

            Assert.AreEqual(0, YGNodeGetChildCount(root));

            Assert.AreEqual(YGDirection.Inherit, YGNodeStyleGetDirection(root));
            Assert.AreEqual(YGFlexDirection.Column, YGNodeStyleGetFlexDirection(root));
            Assert.AreEqual(YGJustify.FlexStart, YGNodeStyleGetJustifyContent(root));
            Assert.AreEqual(YGAlign.FlexStart, YGNodeStyleGetAlignContent(root));
            Assert.AreEqual(YGAlign.Stretch, YGNodeStyleGetAlignItems(root));
            Assert.AreEqual(YGAlign.Auto, YGNodeStyleGetAlignSelf(root));
            Assert.AreEqual(YGPositionType.Relative, YGNodeStyleGetPositionType(root));
            Assert.AreEqual(YGWrap.NoWrap, YGNodeStyleGetFlexWrap(root));
            Assert.AreEqual(YGOverflow.Visible, YGNodeStyleGetOverflow(root));
            Assert.AreEqual(0, YGNodeStyleGetFlexGrow(root));
            Assert.AreEqual(0, YGNodeStyleGetFlexShrink(root));
            Assert.AreEqual(YGUnit.Auto, YGNodeStyleGetFlexBasis(root).Unit);

            Assert.AreEqual(YGNodeStyleGetPosition(root, YGEdge.Left).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, YGEdge.Top).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, YGEdge.Right).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, YGEdge.Bottom).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, YGEdge.Start).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, YGEdge.End).Unit, YGUnit.Undefined);

            Assert.AreEqual(YGNodeStyleGetMargin(root, YGEdge.Left).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, YGEdge.Top).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, YGEdge.Right).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, YGEdge.Bottom).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, YGEdge.Start).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, YGEdge.End).Unit, YGUnit.Undefined);

            Assert.AreEqual(YGNodeStyleGetPadding(root, YGEdge.Left).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, YGEdge.Top).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, YGEdge.Right).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, YGEdge.Bottom).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, YGEdge.Start).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, YGEdge.End).Unit, YGUnit.Undefined);

            Assert.IsTrue(YogaIsUndefined(YGNodeStyleGetBorder(root, YGEdge.Left)));
            Assert.IsTrue(YogaIsUndefined(YGNodeStyleGetBorder(root, YGEdge.Top)));
            Assert.IsTrue(YogaIsUndefined(YGNodeStyleGetBorder(root, YGEdge.Right)));
            Assert.IsTrue(YogaIsUndefined(YGNodeStyleGetBorder(root, YGEdge.Bottom)));
            Assert.IsTrue(YogaIsUndefined(YGNodeStyleGetBorder(root, YGEdge.Start)));
            Assert.IsTrue(YogaIsUndefined(YGNodeStyleGetBorder(root, YGEdge.End)));

            Assert.AreEqual(YGNodeStyleGetWidth(root).Unit, YGUnit.Auto);
            Assert.AreEqual(YGNodeStyleGetHeight(root).Unit, YGUnit.Auto);
            Assert.AreEqual(YGNodeStyleGetMinWidth(root).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMinHeight(root).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMaxWidth(root).Unit, YGUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMaxHeight(root).Unit, YGUnit.Undefined);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetRight(root));
            Assert.AreEqual(0, YGNodeLayoutGetBottom(root));

            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, YGEdge.Left));
            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, YGEdge.Top));
            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, YGEdge.Right));
            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, YGEdge.Bottom));

            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, YGEdge.Left));
            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, YGEdge.Top));
            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, YGEdge.Right));
            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, YGEdge.Bottom));

            Assert.AreEqual(0, YGNodeLayoutGetBorder(root, YGEdge.Left));
            Assert.AreEqual(0, YGNodeLayoutGetBorder(root, YGEdge.Top));
            Assert.AreEqual(0, YGNodeLayoutGetBorder(root, YGEdge.Right));
            Assert.AreEqual(0, YGNodeLayoutGetBorder(root, YGEdge.Bottom));

            Assert.IsTrue(YogaIsUndefined(YGNodeLayoutGetWidth(root)));
            Assert.IsTrue(YogaIsUndefined(YGNodeLayoutGetHeight(root)));
            Assert.AreEqual(YGDirection.Inherit, YGNodeLayoutGetDirection(root));

            
        }
    }
}
