namespace Yoga.Net
{
    public class YogaArrange
    {
        internal static readonly Edge[] Leading = {Edge.Top, Edge.Bottom, Edge.Left, Edge.Right};
        internal static readonly Edge[] Trailing = {Edge.Bottom, Edge.Top, Edge.Right, Edge.Left};
        internal static readonly Edge[] Pos = {Edge.Top, Edge.Bottom, Edge.Left, Edge.Right};
        internal static readonly Dimension[] Dim = {Dimension.Height, Dimension.Height, Dimension.Width, Dimension.Width};
    }
}
