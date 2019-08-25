using System;

using uint8_t = System.Byte;

namespace Yoga.Net
{
    public enum LayoutType
    {
        Layout = 0,
        Measure = 1,
        CachedLayout = 2,
        CachedMeasure = 3
    }

    public enum LayoutPassReason
    {
        Initial = 0,
        AbsLayout = 1,
        Stretch = 2,
        MultilineStretch = 3,
        FlexLayout = 4,
        MeasureChild = 5,
        AbsMeasureChild = 6,
        FlexMeasure = 7,
        // ReSharper disable once InconsistentNaming Used for Sizing
        COUNT
    };


    public class LayoutData
    {
        public int layouts;
        public int measures;
        public int maxMeasureCache;
        public int cachedLayouts;
        public int cachedMeasures;
        public int measureCallbacks;

        public uint8_t[] measureCallbackReasonsCount = new uint8_t[(int)LayoutPassReason.COUNT];
    };

    public static class Event
    {
        public static TinyMessengerHub Hub { get; } = new TinyMessengerHub();
    }


    public abstract class YGNodeEventArgs : EventArgs
    {
        public YGNode node;

        public YGNodeEventArgs(YGNode node)
        {
            this.node = node;
        }
    }

    public class NodeAllocationEventArgs : YGNodeEventArgs
    {
        public YGConfig config;

        public NodeAllocationEventArgs(YGNode node, YGConfig config) : base(node)
        {
            this.config = config;
        }
    }
    public class NodeDeallocationEventArgs : YGNodeEventArgs
    {
        public YGConfig config;

        public NodeDeallocationEventArgs(YGNode node, YGConfig config) : base(node)
        {
            this.config = config;
        }
    }
    public class LayoutPassStartEventArgs : YGNodeEventArgs
    {
        public object layoutContext;

        /// <inheritdoc />
        public LayoutPassStartEventArgs(YGNode node, object layoutContext) : base(node)
        {
            this.layoutContext = layoutContext;
        }
    }
    public class LayoutPassEndEventArgs : YGNodeEventArgs
    {
        public object layoutContext;
        public LayoutData layoutData;

        /// <inheritdoc />
        public LayoutPassEndEventArgs(YGNode node, object layoutContext, LayoutData layoutData) : base(node)
        {
            this.layoutContext = layoutContext;
            this.layoutData = layoutData;
        }
    }
    public class NodeLayoutEventArgs : YGNodeEventArgs
    {
        public LayoutType layoutType;
        public object layoutContext;

        /// <inheritdoc />
        public NodeLayoutEventArgs(YGNode node, LayoutType layoutType, object layoutContext) : base(node)
        {
            this.layoutType = layoutType;
            this.layoutContext = layoutContext;
        }
    }
    public class MeasureCallbackEndEventArgs : YGNodeEventArgs
    {
        public object layoutContext;
        public float width;
        public YGMeasureMode widthMeasureMode;
        public float height;
        public YGMeasureMode heightMeasureMode;
        public float measuredWidth;
        public float measuredHeight;
        public LayoutPassReason reason;

        /// <inheritdoc />
        public MeasureCallbackEndEventArgs(YGNode node) : base(node) { }
    }

    public class MeasureCallbackStartEventArgs : YGNodeEventArgs {
        /// <inheritdoc />
        public MeasureCallbackStartEventArgs(YGNode node) : base(node) { }
    }
    public class NodeBaselineStartEventArgs : YGNodeEventArgs {
        /// <inheritdoc />
        public NodeBaselineStartEventArgs(YGNode node) : base(node) { }
    }
    public class NodeBaselineEndEventArgs : YGNodeEventArgs {
        /// <inheritdoc />
        public NodeBaselineEndEventArgs(YGNode node) : base(node) { }
    }
}
