using System;

using uint8_t = System.Byte;

namespace Yoga.Net
{
    public enum LayoutType
    {
        kLayout = 0,
        kMeasure = 1,
        kCachedLayout = 2,
        kCachedMeasure = 3
    }

    public enum LayoutPassReason
    {
        kInitial = 0,
        kAbsLayout = 1,
        kStretch = 2,
        kMultilineStretch = 3,
        kFlexLayout = 4,
        kMeasureChild = 5,
        kAbsMeasureChild = 6,
        kFlexMeasure = 7,
        // ReSharper disable once InconsistentNaming Used for Sizing
        COUNT
    };


    public unsafe struct LayoutData
    {
        public int layouts;
        public int measures;
        public int maxMeasureCache;
        public int cachedLayouts;
        public int cachedMeasures;
        public int measureCallbacks;

        public fixed uint8_t measureCallbackReasonsCount[(int)LayoutPassReason.COUNT];
        //std::array<int, static_cast<uint8_t>(LayoutPassReason::COUNT)>
        //    measureCallbackReasonsCount;
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
