using NUnit.Framework;
using static Yoga.Net.YGGlobal;


using System.Collections.Generic;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGMeasureModeTest
    {

        class _MeasureConstraint
        {
            public float width;
            public YGMeasureMode widthMode;
            public float height;
            public YGMeasureMode heightMode;
        };

        class _MeasureConstraintList : List<_MeasureConstraint>
        {
        };

        static YGMeasureFunc _measure = (YGNode node,
                               float width,
                               YGMeasureMode widthMode,
                               float height,
                               YGMeasureMode heightMode,
            object context) =>
        {
            var constraintList = (_MeasureConstraintList)node.Context;

            constraintList.Add(new YGMeasureModeTest._MeasureConstraint
            {
                width = width,
                widthMode = widthMode,
                height = height,
                heightMode = heightMode
            });

            YGSize x = new YGSize(
                widthMode == YGMeasureMode.Undefined ? 10 : width,
                heightMode == YGMeasureMode.Undefined ? 10 : width);
            return new YGSize(
                widthMode == YGMeasureMode.Undefined ? 10 : width,
                heightMode == YGMeasureMode.Undefined ? 10 : width);
        };

        [Test]
        public void exactly_measure_stretched_child_column()
        {
            var constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            //  root_child0.Context = &constraintList);
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            //  root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(YGMeasureMode.Exactly, constraintList[0].widthMode);

            //free(constraintList.constraints);
            
        }

        [Test]
        public void exactly_measure_stretched_child_row()
        {
            _MeasureConstraintList constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            //  root_child0.Context = &constraintList);
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.Exactly, constraintList[0].heightMode);

            // free(constraintList.constraints);
            
        }

        [Test]
        public void at_most_main_axis_column()
        {
            var constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].heightMode);

            //free(constraintList.constraints);
            
        }

        [Test]
        public void at_most_cross_axis_column()
        {
            var constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].widthMode);

            // free(constraintList.constraints);
            
        }

        [Test]
        public void at_most_main_axis_row()
        {
            var constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].widthMode);

            // free(constraintList.constraints);
            
        }

        [Test]
        public void at_most_cross_axis_row()
        {
            var constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].heightMode);

            // free(constraintList.constraints);
            
        }

        [Test]
        public void flex_child()
        {
            var constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(2, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].heightMode);

            Assert.AreEqual(100, constraintList[1].height);
            Assert.AreEqual(YGMeasureMode.Exactly, constraintList[1].heightMode);

            // free(constraintList.constraints);
            
        }

        [Test]
        public void flex_child_with_flex_basis()
        {
            var constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetHeight(root, 100);

            YGNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 0);
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.Exactly, constraintList[0].heightMode);

            // free(constraintList.constraints);
            
        }

        [Test]
        public void overflow_scroll_column()
        {
            var constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetOverflow(root, YGOverflow.Scroll);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].widthMode);

            Assert.IsTrue(YogaIsUndefined(constraintList[0].height));
            Assert.AreEqual(YGMeasureMode.Undefined, constraintList[0].heightMode);

            // free(constraintList.constraints);
            
        }

        [Test]
        public void overflow_scroll_row()
        {
            var constraintList = new _MeasureConstraintList();

            YGNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetOverflow(root, YGOverflow.Scroll);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetWidth(root, 100);

            YGNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.IsTrue(YogaIsUndefined(constraintList[0].width));
            Assert.AreEqual(YGMeasureMode.Undefined, constraintList[0].widthMode);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].heightMode);

            // free(constraintList.constraints);
            
        }
    }
}
