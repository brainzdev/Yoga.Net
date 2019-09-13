using NUnit.Framework;
using System.Collections.Generic;

using static Yoga.Net.YogaBuild;

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

            YogaNode root_child0;
            YogaNode root = Node(width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].widthMode);
        }

        [Test]
        public void exactly_measure_stretched_child_row()
        {
            _MeasureConstraintList constraintList = new _MeasureConstraintList();

            YogaNode root_child0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].heightMode);
        }

        [Test]
        public void at_most_main_axis_column()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root_child0;
            YogaNode root = Node(width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].heightMode);
        }

        [Test]
        public void at_most_cross_axis_column()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].widthMode);
        }

        [Test]
        public void at_most_main_axis_row()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root_child0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].widthMode);
        }

        [Test]
        public void at_most_cross_axis_row()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root_child0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].heightMode);
        }

        [Test]
        public void flex_child()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root_child0;
            YogaNode root = Node(height: 100)
               .AddChild(root_child0 = Node(flexGrow:1, measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].heightMode);

            Assert.AreEqual(100, constraintList[1].height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[1].heightMode);
        }

        [Test]
        public void flex_child_with_flex_basis()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root_child0;
            YogaNode root = Node(height: 100)
               .AddChild(root_child0 = Node(flexGrow:1, flexBasis:0, measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].heightMode);
        }

        [Test]
        public void overflow_scroll_column()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, overflow:Overflow.Scroll, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].widthMode);

            Assert.IsTrue(constraintList[0].height.IsUndefined());
            Assert.AreEqual(MeasureMode.Undefined, constraintList[0].heightMode);
        }

        [Test]
        public void overflow_scroll_row()
        {
            var constraintList = new _MeasureConstraintList();

            YogaNode root_child0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, flexDirection:FlexDirection.Row, overflow:Overflow.Scroll, width: 100, height: 100)
               .AddChild(root_child0 = Node(measureFunc:_measure));
            root_child0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.IsTrue(constraintList[0].width.IsUndefined());
            Assert.AreEqual(MeasureMode.Undefined, constraintList[0].widthMode);

            Assert.AreEqual(100, constraintList[0].height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].heightMode);
        }
    }
}
