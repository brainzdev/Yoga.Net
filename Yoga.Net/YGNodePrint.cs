using System.Text;

using uint32_t = System.UInt32;
using static Yoga.Net.YGGlobal;

namespace Yoga.Net
{
    public static class YGNodePrint
    {
        static void indent(StringBuilder sb, uint32_t level)
        {
            for (uint32_t i = 0; i < level; ++i)
                sb.Append("  ");
        }

        static bool areFourValuesEqual(Edges four)
        {
            return
                YGValueEqual(four[0], four[1]) &&
                YGValueEqual(four[0], four[2]) &&
                YGValueEqual(four[0], four[3]);
        }

        static void appendString(StringBuilder sb, string str) => sb.Append(str);

        static void appendFloatOptionalIfDefined(
            StringBuilder sb,
            string key,
            YGFloatOptional num)
        {
            if (!num.IsUndefined())
            {
                sb.Append($"{key}: {num.Unwrap():G}; ");
            }
        }

        static void appendNumberIfNotUndefined(
            StringBuilder sb,
            string key,
            YGValue number)
        {
            if (number.unit == YGUnit.Undefined)
                return;

            if (number.unit == YGUnit.Auto)
                sb.Append($"{key}: auto; ");
            else
                sb.Append($"{key}: {number}; ");
        }

        static void appendNumberIfNotAuto(
            StringBuilder sb,
            string key,
            YGValue number)
        {
            if (number.unit != YGUnit.Auto)
                appendNumberIfNotUndefined(sb, key, number);
        }

        static void appendNumberIfNotZero(
            StringBuilder sb,
            string str,
            YGValue number)
        {
            if (number.unit == YGUnit.Auto)
            {
                sb.Append(str + ": auto; ");
            }
            else if (!YGFloatsEqual(number.value, 0))
            {
                appendNumberIfNotUndefined(sb, str, number);
            }
        }

        static void appendEdges(
            StringBuilder sb,
            string key,
            Edges edges)
        {
            if (areFourValuesEqual(edges))
            {
                appendNumberIfNotZero(sb, key, edges[YGEdge.Left]);
            }
            else
            {
                for (var edge = YGEdge.Left; edge != YGEdge.All; ++edge)
                {
                    string str = key + "-" + (edge.ToString().ToLower());
                    appendNumberIfNotZero(sb, str, edges[edge]);
                }
            }
        }

        static void appendEdgeIfNotUndefined(
            StringBuilder sb,
            string str,
            Edges edges,
            YGEdge edge)
        {
            appendNumberIfNotUndefined(
                sb,
                str,
                YGComputedEdgeValue(edges, edge, CompactValue.Undefined));
        }

        public static void YGNodeToString(
            StringBuilder sb,
            YGNode node,
            YGPrintOptions options,
            uint32_t level)
        {
            indent(sb, level);
            appendString(sb, "<div ");

            if (options.HasFlag(YGPrintOptions.Layout))
            {
                appendString(sb, "layout=\"");
                appendString(sb, $"width: {node.getLayout().Dimensions[(int)YGDimension.Width]:G}; ");
                appendString(sb, $"height: {node.getLayout().Dimensions[(int)YGDimension.Height]:G}; ");
                appendString(sb, $"top: {node.getLayout().Position[(int)YGEdge.Top]:G}; ");
                appendString(sb, $"left: {node.getLayout().Position[(int)YGEdge.Left]:G};");
                appendString(sb, "\" ");
            }

            if (options.HasFlag(YGPrintOptions.Style))
            {
                appendString(sb, "style=\"");
                var style = node.getStyle();
                if (style.flexDirection != DefaultYGNode.getStyle().flexDirection)
                {
                    appendString(sb,$"flex-direction: {style.flexDirection.ToString().ToLower()}; ");
                }

                if (style.justifyContent != DefaultYGNode.getStyle().justifyContent)
                {
                    appendString(sb,$"justify-content: {style.justifyContent.ToString().ToLower()}; ");
                }

                if (style.alignItems != DefaultYGNode.getStyle().alignItems)
                {
                    appendString(sb,$"align-items: {style.alignItems.ToString().ToLower()}; ");
                }

                if (style.alignContent != DefaultYGNode.getStyle().alignContent)
                {
                    appendString(sb,$"align-content: {style.alignContent.ToString().ToLower()}; ");
                }

                if (style.alignSelf != DefaultYGNode.getStyle().alignSelf)
                {
                    appendString(sb,$"align-self: {style.alignSelf.ToString().ToLower()}; ");
                }

                appendFloatOptionalIfDefined(sb, "flex-grow", style.flexGrow);
                appendFloatOptionalIfDefined(sb, "flex-shrink", style.flexShrink);
                appendNumberIfNotAuto(sb, "flex-basis", style.flexBasis);
                appendFloatOptionalIfDefined(sb, "flex", style.flex);

                if (style.flexWrap != DefaultYGNode.getStyle().flexWrap)
                {
                    appendString(sb,$"flex-wrap: {style.flexWrap.ToString().ToLower()}; ");
                }

                if (style.overflow != DefaultYGNode.getStyle().overflow)
                {
                    appendString(sb,$"overflow: {style.overflow.ToString().ToLower()}; ");
                }

                if (style.display != DefaultYGNode.getStyle().display)
                {
                    appendString(sb,$"display: {style.display.ToString().ToLower()}; ");
                }

                appendEdges(sb, "margin", style.margin);
                appendEdges(sb, "padding", style.padding);
                appendEdges(sb, "border", style.border);

                appendNumberIfNotAuto(sb, "width", style.dimensions[YGDimension.Width]);
                appendNumberIfNotAuto(sb, "height", style.dimensions[YGDimension.Height]);
                appendNumberIfNotAuto(sb, "max-width", style.maxDimensions[YGDimension.Width]);
                appendNumberIfNotAuto(sb, "max-height", style.maxDimensions[YGDimension.Height]);
                appendNumberIfNotAuto(sb, "min-width", style.minDimensions[YGDimension.Width]);
                appendNumberIfNotAuto(sb, "min-height", style.minDimensions[YGDimension.Height]);

                if (style.positionType != DefaultYGNode.getStyle().positionType)
                {
                    appendString(sb, $"position: {style.positionType.ToString().ToLower()}; ");
                }

                appendEdgeIfNotUndefined(sb, "left", style.position, YGEdge.Left);
                appendEdgeIfNotUndefined(sb, "right", style.position, YGEdge.Right);
                appendEdgeIfNotUndefined(sb, "top", style.position, YGEdge.Top);
                appendEdgeIfNotUndefined(sb, "bottom", style.position, YGEdge.Bottom);
                appendString(sb, "\" ");

                if (node.hasMeasureFunc())
                {
                    appendString(sb, "has-custom-measure=\"true\"");
                }
            }

            appendString(sb, ">");

            var childCount = node.getChildren().Count;
            if (options.HasFlag(YGPrintOptions.Children) && childCount > 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    appendString(sb, "\n");
                    YGNodeToString(sb, node.Children[i], options, level + 1);
                }

                appendString(sb, "\n");
                indent(sb, level);
            }

            appendString(sb, "</div>");
        }
    }
}
