using System;

namespace Yoga.Net
{
    public enum YGAlign
    {
        Auto,
        FlexStart,
        Center,
        FlexEnd,
        Stretch,
        Baseline,
        SpaceBetween,
        SpaceAround
    }

    public enum YGDimension
    {
        Width,
        Height
    }

    public enum YGDirection
    {
        Unknown = -1,
        Inherit = 0,
        LTR = 1,
        RTL = 2
    }

    public enum YGDisplay
    {
        Flex,
        None
    }

    public enum YGEdge
    {
        Left,
        Top,
        Right,
        Bottom,
        Start,
        End,
        Horizontal,
        Vertical,
        All
    }

    public enum YGExperimentalFeature
    {
        WebFlexBasis
    }

    public enum YGFlexDirection
    {
        Column,
        ColumnReverse,
        Row,
        RowReverse
    }

    public enum YGJustify
    {
        FlexStart,
        Center,
        FlexEnd,
        SpaceBetween,
        SpaceAround,
        SpaceEvenly
    }

    public enum YGLogLevel
    {
        Error,
        Warn,
        Info,
        Debug,
        Verbose,
        Fatal
    }

    public enum YGMeasureMode
    {
        Undefined = -1,
        Exactly = 0,
        AtMost = 1
    }

    public enum YGNodeType
    {
        Default,
        Text
    }

    public enum YGOverflow
    {
        Visible,
        Hidden,
        Scroll
    }

    public enum YGPositionType
    {
        Relative,
        Absolute
    }


    [Flags]
    public enum YGPrintOptions
    {
        Layout = 1,
        Style = 2,
        Children = 4
    }

    public enum YGUnit
    {
        Undefined,
        Point,
        Percent,
        Auto
    }

    public enum YGWrap
    {
        NoWrap,
        Wrap,
        WrapReverse
    }
}
