using NUnit.Framework;
using System.Collections.Generic;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaMeasureModeTest
    {
        class _MeasureConstraint
        {
            public float width;
            public MeasureMode widthMode;
            public float height;
            public MeasureMode heightMode;
        };

        class _MeasureConstraintList : List<_MeasureConstraint> { };

        static MeasureFunc _measure = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            var constraintList = (_MeasureConstraintList)node.Context;

            constraintList.Add(
                new YogaMeasureModeTest._MeasureConstraint
                {
                    width      = width,
                    widthMode  = widthMode,
                    height     = height,
                    heightMode = heightMode
                });

            YogaSize x = new YogaSize(
                widthMode == MeasureMode.Undefined ? 10 : width,
                heightMode == MeasureMode.Undefined ? 10 : width);
            return new YogaSize(
                widthMode == MeasureMode.Undefined ? 10 : width,
                heightMode == MeasureMode.Undefined ? 10 : width);
        };

        [Test]
        public void exactly_measure_stretched_child_column()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            //  root_child0.Context = &constraintList);
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            //  root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].widthMode);

            //free(constraintList.constraints);
        }

        [Test]
        public void exactly_measure_stretched_child_row()
        {
            _MeasureConstraintList constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            //  root_child0.Context = &constraintList);
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].heightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void at_most_main_axis_column()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].heightMode);

            //free(constraintList.constraints);
        }

        [Test]
        public void at_most_cross_axis_column()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].widthMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void at_most_main_axis_row()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].widthMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void at_most_cross_axis_row()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].heightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void flex_child()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].heightMode);

            Assert.AreEqual(100, constraintList[1].height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[1].heightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void flex_child_with_flex_basis()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetHeight(root, 100);

            YogaNode root_child0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasis(root_child0, 0);
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].heightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void overflow_scroll_column()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetOverflow(root, Overflow.Scroll);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].widthMode);

            Assert.IsTrue(constraintList[0].height.IsUndefined());
            Assert.AreEqual(MeasureMode.Undefined, constraintList[0].heightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void overflow_scroll_row()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetOverflow(root, Overflow.Scroll);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetWidth(root, 100);

            YogaNode root_child0 = YGNodeNew();
            root_child0.Context = constraintList;
            YGNodeSetMeasureFunc(root_child0, _measure);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.IsTrue(constraintList[0].width.IsUndefined());
            Assert.AreEqual(MeasureMode.Undefined, constraintList[0].widthMode);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].heightMode);

            // free(constraintList.constraints);
        }
    }
}
