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
    //const char* LayoutPassReasonToString(const LayoutPassReason value);


    public unsafe struct LayoutData
    {
        public int layouts;
        public int measures;
        public int maxMeasureCache;
        public int cachedLayouts;
        public int cachedMeasures;
        public int measureCallbacks;

        fixed uint8_t measureCallbackReasonsCount[(int)LayoutPassReason.COUNT];
        //std::array<int, static_cast<uint8_t>(LayoutPassReason::COUNT)>
        //    measureCallbackReasonsCount;
    };

    public static class Event
    {
        public static TinyMessengerHub Hub { get; } = new TinyMessengerHub();
    }



    public class NodeAllocationEventArgs : EventArgs
    {
        public YGConfig config;
    }
    public class NodeDeallocationEventArgs : EventArgs
    {
        public YGConfig config;
    }
    public class LayoutPassStartEventArgs : EventArgs
    {
        public object layoutContext;
    }
    public class LayoutPassEndEventArgs : EventArgs
    {
        public object layoutContext;
        public LayoutData layoutData;
    }
    public class NodeLayoutEventArgs : EventArgs
    {
        public object layoutContext;
        public LayoutType layoutType;
    }
    public class MeasureCallbackEndEventArgs : EventArgs
    {
        public object layoutContext;
        public float width;
        public YGMeasureMode widthMeasureMode;
        public float height;
        public YGMeasureMode heightMeasureMode;
        public float measuredWidth;
        public float measuredHeight;
        public readonly LayoutPassReason reason;
    }

    public class MeasureCallbackStartEventArgs : EventArgs { }
    public class NodeBaselineStartEventArgs : EventArgs { }
    public class NodeBaselineEndEventArgs : EventArgs { }
}
