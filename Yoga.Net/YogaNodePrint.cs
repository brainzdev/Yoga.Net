using System.Text;
using static Yoga.Net.YogaGlobal;

namespace Yoga.Net
{
    public class YogaNodePrint
    {
        StringBuilder sb;

        public YogaNodePrint(StringBuilder sb = null)
        {
            this.sb = sb ?? new StringBuilder();
        }

        void Indent(int level)
        {
            for (int i = 0; i < level; ++i)
                sb.Append("  ");
        }

        bool AreFourValuesEqual(Edges four)
        {
            return
                four[0] == four[1] &&
                four[0] == four[2] &&
                four[0] == four[3];
        }

        void AppendString(string str) => sb.Append(str);

        void AppendFloatOptionalIfDefined(
            string key,
            float num)
        {
            if (num.IsValid())
                sb.Append($"{key}: {num:G}; ");
        }

        void AppendNumberIfNotUndefined(
            string key,
            YogaValue number)
        {
            if (number.Unit == YogaUnit.Undefined)
                return;

            if (number.Unit == YogaUnit.Auto)
                sb.Append($"{key}: auto; ");
            else
                sb.Append($"{key}: {number}; ");
        }

        void AppendNumberIfNotAuto(
            string key,
            YogaValue number)
        {
            if (number.Unit != YogaUnit.Auto)
                AppendNumberIfNotUndefined(key, number);
        }

        void AppendNumberIfNotZero(
            string str,
            YogaValue number)
        {
            if (number.Unit == YogaUnit.Auto)
            {
                sb.Append(str + ": auto; ");
            }
            else if (!FloatsEqual(number.Value, 0))
            {
                AppendNumberIfNotUndefined(str, number);
            }
        }

        void AppendEdges(
            string key,
            Edges edges)
        {
            if (AreFourValuesEqual(edges))
            {
                AppendNumberIfNotZero(key, edges[Edge.Left]);
            }
            else
            {
                for (var edge = Edge.Left; edge != Edge.All; ++edge)
                {
                    string str = key + "-" + (edge.ToString().ToLower());
                    AppendNumberIfNotZero(str, edges[edge]);
                }
            }
        }

        void AppendEdgeIfNotUndefined(
            string str,
            Edges edges,
            Edge edge)
        {
            AppendNumberIfNotUndefined(
                str,
                edges.ComputedEdgeValue(edge, YogaValue.Undefined));
        }

        public void Output(YogaNode node, PrintOptions options, int level)
        {
            Indent(level);
            AppendString("<div ");

            if (options.HasFlag(PrintOptions.Layout))
            {
                AppendString("layout=\"");
                AppendString($"width: {node.Layout.Width:G}; ");
                AppendString($"height: {node.Layout.Height:G}; ");
                AppendString($"top: {node.Layout.Position[Edge.Top]:G}; ");
                AppendString($"left: {node.Layout.Position[(int)Edge.Left]:G};");
                AppendString("\" ");
            }

            if (options.HasFlag(PrintOptions.Style))
            {
                AppendString("style=\"");
                var style = node.Style;
                if (style.FlexDirection != DefaultYogaNode.Style.FlexDirection)
                {
                    AppendString($"flex-direction: {style.FlexDirection.ToString().ToLower()}; ");
                }

                if (style.JustifyContent != DefaultYogaNode.Style.JustifyContent)
                {
                    AppendString($"justify-content: {style.JustifyContent.ToString().ToLower()}; ");
                }

                if (style.AlignItems != DefaultYogaNode.Style.AlignItems)
                {
                    AppendString($"align-items: {style.AlignItems.ToString().ToLower()}; ");
                }

                if (style.AlignContent != DefaultYogaNode.Style.AlignContent)
                {
                    AppendString($"align-content: {style.AlignContent.ToString().ToLower()}; ");
                }

                if (style.AlignSelf != DefaultYogaNode.Style.AlignSelf)
                {
                    AppendString($"align-self: {style.AlignSelf.ToString().ToLower()}; ");
                }

                AppendFloatOptionalIfDefined("flex-grow", style.FlexGrow);
                AppendFloatOptionalIfDefined("flex-shrink", style.FlexShrink);
                AppendNumberIfNotAuto("flex-basis", style.FlexBasis);
                AppendFloatOptionalIfDefined("flex", style.Flex);

                if (style.FlexWrap != DefaultYogaNode.Style.FlexWrap)
                {
                    AppendString($"flex-wrap: {style.FlexWrap.ToString().ToLower()}; ");
                }

                if (style.Overflow != DefaultYogaNode.Style.Overflow)
                {
                    AppendString($"overflow: {style.Overflow.ToString().ToLower()}; ");
                }

                if (style.Display != DefaultYogaNode.Style.Display)
                {
                    AppendString($"display: {style.Display.ToString().ToLower()}; ");
                }

                AppendEdges("margin", style.Margin);
                AppendEdges("padding", style.Padding);
                AppendEdges("border", style.Border);

                AppendNumberIfNotAuto("width", style.Dimensions[Dimension.Width]);
                AppendNumberIfNotAuto("height", style.Dimensions[Dimension.Height]);
                AppendNumberIfNotAuto("max-width", style.MaxDimensions[Dimension.Width]);
                AppendNumberIfNotAuto("max-height", style.MaxDimensions[Dimension.Height]);
                AppendNumberIfNotAuto("min-width", style.MinDimensions[Dimension.Width]);
                AppendNumberIfNotAuto("min-height", style.MinDimensions[Dimension.Height]);

                if (style.PositionType != DefaultYogaNode.Style.PositionType)
                {
                    AppendString($"position: {style.PositionType.ToString().ToLower()}; ");
                }

                AppendEdgeIfNotUndefined("left", style.Position, Edge.Left);
                AppendEdgeIfNotUndefined("right", style.Position, Edge.Right);
                AppendEdgeIfNotUndefined("top", style.Position, Edge.Top);
                AppendEdgeIfNotUndefined("bottom", style.Position, Edge.Bottom);
                AppendString("\" ");

                if (node.MeasureFunc != null)
                {
                    AppendString("has-custom-measure=\"true\"");
                }
            }

            AppendString(">");

            var childCount = node.Children.Count;
            if (options.HasFlag(PrintOptions.Children) && childCount > 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    AppendString("\n");
                    Output(node.Children[i], options, level + 1);
                }

                AppendString("\n");
                Indent(level);
            }

            AppendString("</div>");
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
