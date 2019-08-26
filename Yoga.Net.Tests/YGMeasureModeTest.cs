using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;
using System.Collections.Generic;

namespace Yoga.Net
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

        static YGMeasureFunc _measure = (YGNodeRef node,
                               float width,
                               YGMeasureMode widthMode,
                               float height,
                               YGMeasureMode heightMode,
            object context) =>
        {
            var constraintList = (_MeasureConstraintList)node.getContext();

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

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            //  root_child0.setContext(&constraintList);
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            //  root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(YGMeasureMode.Exactly, constraintList[0].widthMode);

            //free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }

        [Test]
        public void exactly_measure_stretched_child_row()
        {
            _MeasureConstraintList constraintList = new _MeasureConstraintList();

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            //  root_child0.setContext(&constraintList);
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.Exactly, constraintList[0].heightMode);

            // free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }

        [Test]
        public void at_most_main_axis_column()
        {
            var constraintList = new _MeasureConstraintList();

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].heightMode);

            //free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }

        [Test]
        public void at_most_cross_axis_column()
        {
            var constraintList = new _MeasureConstraintList();

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].widthMode);

            // free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }

        [Test]
        public void at_most_main_axis_row()
        {
            var constraintList = new _MeasureConstraintList();

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].widthMode);

            // free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }

        [Test]
        public void at_most_cross_axis_row()
        {
            var constraintList = new _MeasureConstraintList();

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].heightMode);

            // free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }

        [Test]
        public void flex_child()
        {
            var constraintList = new _MeasureConstraintList();

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(2, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].heightMode);

            Assert.AreEqual(100, constraintList[1].height);
            Assert.AreEqual(YGMeasureMode.Exactly, constraintList[1].heightMode);

            // free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }

        [Test]
        public void flex_child_with_flex_basis()
        {
            var constraintList = new _MeasureConstraintList();

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 0);
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.Exactly, constraintList[0].heightMode);

            // free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }

        [Test]
        public void overflow_scroll_column()
        {
            var constraintList = new _MeasureConstraintList();

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetOverflow(root, YGOverflow.Scroll);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetWidth(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].widthMode);

            Assert.IsTrue(YogaIsUndefined(constraintList[0].height));
            Assert.AreEqual(YGMeasureMode.Undefined, constraintList[0].heightMode);

            // free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }

        [Test]
        public void overflow_scroll_row()
        {
            var constraintList = new _MeasureConstraintList();

            YGNodeRef root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YGAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetOverflow(root, YGOverflow.Scroll);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetWidth(root, 100);

            YGNodeRef root_child0 = YGNodeNew();
            root_child0.setContext(constraintList);
            root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.IsTrue(YogaIsUndefined(constraintList[0].width));
            Assert.AreEqual(YGMeasureMode.Undefined, constraintList[0].widthMode);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(YGMeasureMode.AtMost, constraintList[0].heightMode);

            // free(constraintList.constraints);
            YGNodeFreeRecursive(root);
        }
    }
}
