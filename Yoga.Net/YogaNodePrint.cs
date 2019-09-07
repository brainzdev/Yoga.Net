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

        bool AreFourValuesEqual(EdgesReadonly four)
        {
            return
                four[Edge.Left] == four[Edge.Top] &&
                four[Edge.Left] == four[Edge.Right] &&
                four[Edge.Left] == four[Edge.Bottom];
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

        void AppendEdges(string key, EdgesReadonly edges)
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

        void AppendEdgeIfNotUndefined(string str, EdgesReadonly edges, Edge edge)
        {
            AppendNumberIfNotUndefined(str, edges.ComputedEdgeValue(edge, YogaValue.Undefined));
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
                if (node.StyleFlexDirection != DefaultYogaNode.StyleFlexDirection)
                {
                    AppendString($"flex-direction: {node.StyleFlexDirection.ToString().ToLower()}; ");
                }

                if (node.StyleJustifyContent != DefaultYogaNode.StyleJustifyContent)
                {
                    AppendString($"justify-content: {node.StyleJustifyContent.ToString().ToLower()}; ");
                }

                if (node.StyleAlignItems != DefaultYogaNode.StyleAlignItems)
                {
                    AppendString($"align-items: {node.StyleAlignItems.ToString().ToLower()}; ");
                }

                if (node.StyleAlignContent != DefaultYogaNode.StyleAlignContent)
                {
                    AppendString($"align-content: {node.StyleAlignContent.ToString().ToLower()}; ");
                }

                if (node.StyleAlignSelf != DefaultYogaNode.StyleAlignSelf)
                {
                    AppendString($"align-self: {node.StyleAlignSelf.ToString().ToLower()}; ");
                }

                AppendFloatOptionalIfDefined("flex-grow", node.StyleReadonly.FlexGrow);
                AppendFloatOptionalIfDefined("flex-shrink", node.StyleReadonly.FlexShrink);
                AppendNumberIfNotAuto("flex-basis", node.StyleFlexBasis);
                AppendFloatOptionalIfDefined("flex", node.StyleReadonly.Flex);

                if (node.StyleFlexWrap != DefaultYogaNode.StyleFlexWrap)
                {
                    AppendString($"flex-wrap: {node.StyleFlexWrap.ToString().ToLower()}; ");
                }

                if (node.StyleOverflow != DefaultYogaNode.StyleOverflow)
                {
                    AppendString($"overflow: {node.StyleOverflow.ToString().ToLower()}; ");
                }

                if (node.StyleDisplay != DefaultYogaNode.StyleDisplay)
                {
                    AppendString($"display: {node.StyleDisplay.ToString().ToLower()}; ");
                }

                AppendEdges("margin", node.StyleMargin);
                AppendEdges("padding", node.StylePadding);
                AppendEdges("border", node.StyleBorder);

                AppendNumberIfNotAuto("width", node.StyleWidth);
                AppendNumberIfNotAuto("height", node.StyleHeight);
                AppendNumberIfNotAuto("max-width", node.StyleMaxWidth);
                AppendNumberIfNotAuto("max-height", node.StyleMaxHeight);
                AppendNumberIfNotAuto("min-width", node.StyleMinWidth);
                AppendNumberIfNotAuto("min-height", node.StyleMinHeight);

                if (node.StylePositionType != DefaultYogaNode.StylePositionType)
                {
                    AppendString($"position: {node.StylePositionType.ToString().ToLower()}; ");
                }

                AppendEdgeIfNotUndefined("left", node.StylePosition, Edge.Left);
                AppendEdgeIfNotUndefined("right", node.StylePosition, Edge.Right);
                AppendEdgeIfNotUndefined("top", node.StylePosition, Edge.Top);
                AppendEdgeIfNotUndefined("bottom", node.StylePosition, Edge.Bottom);
                AppendString("\" ");

                if (node.HasMeasureFunc)
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
