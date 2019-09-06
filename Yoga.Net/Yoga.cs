using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Yoga.Net
{
    public delegate YogaSize MeasureFunc(YogaNode node, float width, MeasureMode widthMode, float height, MeasureMode heightMode, object layoutContext = null);

    public delegate float BaselineFunc(YogaNode node, float width, float height, object layoutContext = null);

    public delegate void PrintFunc(YogaNode node, object layoutContext = null);

    public delegate void DirtiedFunc(YogaNode node);

    public delegate YogaNode YogaCloneNodeFunc(YogaNode oldNode, YogaNode owner, int childIndex, object context);

    public static partial class YogaGlobal
    {
        public static object YGNodeGetContext(YogaNode node)
        {
            return node.Context;
        }

        public static void YGNodeSetContext(YogaNode node, object context)
        {
            node.Context = context;
        }

        public static bool YGNodeHasMeasureFunc(YogaNode node)
        {
            return node.MeasureFunc != null;
        }

        public static void YGNodeSetMeasureFunc(YogaNode node, MeasureFunc measureFunc)
        {
            node.SetMeasureFunc(measureFunc);
        }

        public static bool YGNodeHasBaselineFunc(YogaNode node)
        {
            return node.BaselineFunc != null;
        }

        public static void YGNodeSetBaselineFunc(YogaNode node, BaselineFunc baselineFunc)
        {
            node.BaselineFunc = baselineFunc;
        }

        public static DirtiedFunc YGNodeGetDirtiedFunc(YogaNode node)
        {
            return node.DirtiedFunc;
        }

        public static void YGNodeSetDirtiedFunc(YogaNode node, DirtiedFunc dirtiedFunc)
        {
            node.DirtiedFunc = dirtiedFunc;
        }

        public static void YGNodeSetPrintFunc(YogaNode node, PrintFunc printFunc)
        {
            node.PrintFunc = printFunc;
        }

        public static bool YGNodeGetHasNewLayout(YogaNode node)
        {
            return node.GetHasNewLayout();
        }

        public static void YGConfigSetPrintTreeFlag(YogaConfig config, bool enabled)
        {
            config.PrintTree = enabled;
        }

        public static void YGNodeSetHasNewLayout(YogaNode node, bool hasNewLayout)
        {
            node.SetHasNewLayout(hasNewLayout);
        }

        public static NodeType YGNodeGetNodeType(YogaNode node)
        {
            return node.GetNodeType();
        }

        public static void YGNodeSetNodeType(YogaNode node, NodeType nodeType)
        {
            node.SetNodeType(nodeType);
        }

        public static bool YGNodeIsDirty(YogaNode node)
        {
            return node.IsDirty;
        }

        /// <summary>
        /// Marks the current node and all its descendants as dirty.
        ///
        /// Intended to be used for Uoga benchmarks. Don't use in production, as calling
        /// `YGCalculateLayout` will cause the recalculation of each and every node.
        /// </summary>
        public static void YGNodeMarkDirtyAndPropagateToDescendants(YogaNode node)
        {
            node.MarkDirtyAndPropagateDownwards();
        }


        public static YogaNode YGNodeNew()
        {
            return YGNodeNewWithConfig(YogaConfig.DefaultConfig);
        }

        public static YogaNode YGNodeNewWithConfig(YogaConfig config)
        {
            YogaNode node = new YogaNode(config);
            YGAssertWithConfig(
                config,
                node != null,
                "Could not allocate memory for node");
            Event.Hub.Publish(new NodeAllocationEventArgs(node, config));

            return node;
        }

        public static YogaNode YGNodeClone(YogaNode oldNode)
        {
            YogaNode node = new YogaNode(oldNode);
            YGAssertWithConfig(
                oldNode.Config,
                node != null,
                "Could not allocate memory for node");
            Event.Hub.Publish(new NodeAllocationEventArgs(node, node.Config));
            node.Owner = null;
            return node;
        }

        public static YogaConfig YGConfigClone(YogaConfig oldConfig)
        {
            YogaConfig config = new YogaConfig(oldConfig);
            return config;
        }

        public static YogaNode DeepClone(YogaNode oldNode)
        {
            var node = new YogaNode(oldNode, new YogaConfig(oldNode.Config));
            node.Owner = null;

            var children = new YogaNodes(oldNode.Children.Count);
            foreach (var item in oldNode.Children)
            {
                var childNode = YGNodeDeepClone(item);
                childNode.Owner = node;
                children.Add(childNode);
            }

            node.SetChildren(children);

            return node;
        }

        public static YogaNode YGNodeDeepClone(YogaNode oldNode)
        {
            var config = YGConfigClone(oldNode.Config);
            var node = new YogaNode(oldNode, config);
            node.Owner = null;
            Event.Hub.Publish(new NodeAllocationEventArgs(node, node.Config));

            YogaNodes vec = new YogaNodes(); // .reserve(oldNode.Children.size());
            YogaNode childNode = null;
            foreach (var item in oldNode.Children)
            {
                childNode = YGNodeDeepClone(item);
                childNode.Owner = node;
                vec.Add(childNode);
            }

            node.SetChildren(vec);

            return node;
        }

        public static void YGNodeReset(YogaNode node) => node.Reset();

        public static YogaConfig YGConfigNew() => new YogaConfig();

        public static void YGConfigCopy(YogaConfig dest, YogaConfig src) => dest.CopyFrom(src);

        public static void YGNodeSetIsReferenceBaseline(YogaNode node, bool isReferenceBaseline)
        {
            if (node.IsReferenceBaseline != isReferenceBaseline)
            {
                node.SetIsReferenceBaseline(isReferenceBaseline);
                node.MarkDirtyAndPropagate();
            }
        }

        public static bool YGNodeIsReferenceBaseline(YogaNode node)
        {
            return node.IsReferenceBaseline;
        }

        public static void YGNodeInsertChild(
            YogaNode owner,
            YogaNode child,
            int index)
        {
            YGAssertWithNode(
                owner,
                child.Owner == null,
                "Child already has a owner, it must be removed first.");

            YGAssertWithNode(
                owner,
                owner.MeasureFunc == null,
                "Cannot add child: Nodes with measure functions cannot have children.");

            owner.InsertChild(child, index);
            child.Owner = owner;
            owner.MarkDirtyAndPropagate();
        }

        public static void YGNodeRemoveChild(YogaNode owner, YogaNode excludedChild)
        {
            if (YGNodeGetChildCount(owner) == 0)
            {
                // This is an empty set. Nothing to remove.
                return;
            }

            // Children may be shared between parents, which is indicated by not having an
            // owner. We only want to reset the child completely if it is owned
            // exclusively by one node.
            var childOwner = excludedChild.Owner;
            if (owner.RemoveChild(excludedChild))
            {
                if (owner == childOwner)
                {
                    excludedChild.Layout = new YogaLayout(); // layout is no longer valid
                    excludedChild.Owner = null;
                }

                owner.MarkDirtyAndPropagate();
            }
        }

        public static void YGNodeRemoveAllChildren(YogaNode owner)
        {
            int childCount = YGNodeGetChildCount(owner);
            if (childCount == 0)
            {
                // This is an empty set already. Nothing to do.
                return;
            }

            YogaNode firstChild = owner.Children[0];
            if (firstChild.Owner == owner)
            {
                // If the first child has this node as its owner, we assume that this child
                // set is unique.
                for (int i = 0; i < childCount; i++)
                {
                    YogaNode oldChild = owner.Children[i];
                    oldChild.Layout = new YogaNode().Layout; // layout is no longer valid
                    oldChild.Owner = null;
                }

                owner.ClearChildren();
                owner.MarkDirtyAndPropagate();
                return;
            }

            // Otherwise, we are not the owner of the child set. We don't have to do
            // anything to clear it.
            owner.SetChildren(new YogaNodes());
            owner.MarkDirtyAndPropagate();
        }

        public static void YGNodeSetChildrenInternal(
            YogaNode owner,
            IEnumerable<YogaNode> childs)
        {
            if (owner == null)
            {
                return;
            }

            var newChildren = childs.ToList();
            if (newChildren.Count == 0)
            {
                if (YGNodeGetChildCount(owner) > 0)
                {
                    foreach (YogaNode child in owner.Children)
                    {
                        child.Layout = new YogaLayout();
                        child.Owner = null;
                    }

                    owner.SetChildren(new YogaNodes());
                    owner.MarkDirtyAndPropagate();
                }
            }
            else
            {
                if (YGNodeGetChildCount(owner) > 0)
                {
                    foreach (YogaNode oldChild in owner.Children)
                    {
                        // Our new children may have nodes in common with the old children. We don't reset these common nodes.
                        //if (std::find(children.begin(), children.end(), oldChild) == children.end()) 
                        if (!newChildren.Contains(oldChild))
                        {
                            oldChild.Layout = new YogaLayout();
                            oldChild.Owner = null;
                        }
                    }
                }

                owner.SetChildren(newChildren);
                foreach (YogaNode child in newChildren)
                    child.Owner = owner;

                owner.MarkDirtyAndPropagate();
            }
        }

        public static void YGNodeSetChildren(
            YogaNode owner,
            YogaNode[] c,
            int count)
        {
            var children = c.Take(count); // {c, c + count};
            YGNodeSetChildrenInternal(owner, children);
        }

        public static void YGNodeSetChildren(
            YogaNode owner,
            IEnumerable<YogaNode> children)
        {
            YGNodeSetChildrenInternal(owner, children);
        }

        [Obsolete("use node.Children[index]")]
        public static YogaNode YGNodeGetChild(YogaNode node, int index)
        {
            if (index < node.Children.Count)
                return node.Children[index];

            return null;
        }

        public static int YGNodeGetChildCount(YogaNode node)
        {
            return node.Children.Count;
        }

        public static YogaNode YGNodeGetOwner(YogaNode node)
        {
            return node.Owner;
        }

        public static YogaNode YGNodeGetParent(YogaNode node)
        {
            return node.Owner;
        }

        /// <summary>
        /// Mark a node as dirty. Only valid for nodes with a custom measure function
        /// set.
        ///
        /// Yoga knows when to mark all other nodes as dirty but because nodes with
        /// measure functions depend on information not known to Yoga they must perform
        /// this dirty marking manually.
        /// </summary>
        public static void YGNodeMarkDirty(YogaNode node)
        {
            YGAssertWithNode(
                node,
                node.MeasureFunc != null,
                "Only leaf nodes with custom measure functions should manually mark themselves as dirty");

            node.MarkDirtyAndPropagate();
        }

        public static void YGNodeCopyStyle(YogaNode dstNode, YogaNode srcNode)
        {
            dstNode.Style = srcNode.Style;

            //if (!(dstNode.Style == srcNode.Style))
            //{
            //    dstNode.Style = srcNode.Style;
            //    dstNode.MarkDirtyAndPropagate();
            //}
        }

        public static float YGNodeStyleGetFlexGrow(YogaNode node)
        {
            return node.Style.FlexGrow.IsUndefined()
                ? DefaultFlexGrow
                : node.Style.FlexGrow;
        }

        public static float YGNodeStyleGetFlexShrink(YogaNode node)
        {
            return node.Style.FlexShrink.IsUndefined()
                ? DefaultFlexShrink
                : node.Style.FlexShrink;
        }

        //namespace {

        //template <typename Ref, typename T>
        public static void updateStyle<TEntity, T>(
            YogaNode node,
            Expression<Func<TEntity, T>> outExpr, //Ref (YogaStyle::*prop)(), 
            T value) where T : struct
        {
            var expr = (MemberExpression)outExpr.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = (T)prop.GetValue(node.Style);

            if (!EqualityComparer<T>.Default.Equals(propValue, value))
            {
                prop.SetValue(node.Style, value);
                node.MarkDirtyAndPropagate();
            }
        }

        public static void updateStyleObject<TEntity, T>(
            YogaNode node,
            Expression<Func<TEntity, T>> outExpr, //Ref (YogaStyle::*prop)(), 
            T value) where T : class
        {
            var expr = (MemberExpression)outExpr.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = (T)prop.GetValue(node.Style);

            if (!EqualityComparer<T>.Default.Equals(propValue, value))
            {
                prop.SetValue(node.Style, value);
                node.MarkDirtyAndPropagate();
            }
        }

        //template <typename Ref, typename Idx>
        public static void updateIndexedStyleProp<TKey, TValue>(
            YogaNode node,
            Values<TKey, TValue> values,
            int idx,
            TValue value) where TKey : struct, IConvertible
        {
            var propValue = values[idx];

            if (!value.Equals(propValue))
            {
                values[idx] = value;
                node.MarkDirtyAndPropagate();
            }
        }

        //} // namespace

        // MSVC has trouble inferring the return type of pointer to member functions
        // with and non-overloads, instead of preferring the non-const
        // overload like clang and GCC. For the purposes of updateStyle(), we can help
        // MSVC by specifying that return type explicitely. In combination with
        // decltype, MSVC will prefer the non-version.
        //#define MSVC_HINT(PROP) decltype(YogaStyle{}.PROP())

        public static void YGNodeStyleSetDirection(YogaNode node, Direction value)
        {
            updateStyle<Net.YogaStyle, Net.Direction>(node, s => s.Direction, value);
            //updateStyle<MSVC_HINT(direction)>(node, &Net.YogaStyle::direction, value);
        }

        public static Direction YGNodeStyleGetDirection(YogaNode node)
        {
            return node.Style.Direction;
        }

        public static void YGNodeStyleSetFlexDirection(
            YogaNode node,
            FlexDirection flexDirection)
        {
            updateStyle<Net.YogaStyle, Net.FlexDirection>(node, s => s.FlexDirection, flexDirection);
        }

        public static FlexDirection YGNodeStyleGetFlexDirection(YogaNode node)
        {
            return node.Style.FlexDirection;
        }

        public static void YGNodeStyleSetJustifyContent(
            YogaNode node,
            Justify justifyContent)
        {
            updateStyle<Net.YogaStyle, Net.Justify>(node, s => s.JustifyContent, justifyContent);
        }

        public static Justify YGNodeStyleGetJustifyContent(YogaNode node)
        {
            return node.Style.JustifyContent;
        }

        public static void YGNodeStyleSetAlignContent(
            YogaNode node,
            YogaAlign alignContent)
        {
            updateStyle<Net.YogaStyle, Net.YogaAlign>(node, s => s.AlignContent, alignContent);
        }

        public static YogaAlign YGNodeStyleGetAlignContent(YogaNode node)
        {
            return node.Style.AlignContent;
        }

        public static void YGNodeStyleSetAlignItems(YogaNode node, YogaAlign alignItems)
        {
            updateStyle<Net.YogaStyle, Net.YogaAlign>(node, s => s.AlignItems, alignItems);
        }

        public static YogaAlign YGNodeStyleGetAlignItems(YogaNode node)
        {
            return node.Style.AlignItems;
        }

        public static void YGNodeStyleSetAlignSelf(YogaNode node, YogaAlign alignSelf)
        {
            updateStyle<Net.YogaStyle, Net.YogaAlign>(node, s => s.AlignSelf, alignSelf);
        }

        public static YogaAlign YGNodeStyleGetAlignSelf(YogaNode node)
        {
            return node.Style.AlignSelf;
        }

        public static void YGNodeStyleSetPositionType(
            YogaNode node,
            PositionType positionType)
        {
            updateStyle<Net.YogaStyle, Net.PositionType>(node, s => s.PositionType, positionType);
        }

        public static PositionType YGNodeStyleGetPositionType(YogaNode node)
        {
            return node.Style.PositionType;
        }

        public static void YGNodeStyleSetFlexWrap(YogaNode node, Wrap flexWrap)
        {
            updateStyle<Net.YogaStyle, Net.Wrap>(node, s => s.FlexWrap, flexWrap);
        }

        public static Wrap YGNodeStyleGetFlexWrap(YogaNode node)
        {
            return node.Style.FlexWrap;
        }

        public static void YGNodeStyleSetOverflow(YogaNode node, Overflow overflow)
        {
            updateStyle<Net.YogaStyle, Net.Overflow>(node, s => s.Overflow, overflow);
        }

        public static Overflow YGNodeStyleGetOverflow(YogaNode node)
        {
            return node.Style.Overflow;
        }

        public static void YGNodeStyleSetDisplay(YogaNode node, Display display)
        {
            updateStyle<Net.YogaStyle, Net.Display>(node, s => s.Display, display);
        }

        public static Display YGNodeStyleGetDisplay(YogaNode node)
        {
            return node.Style.Display;
        }

        // TODO(T26792433): Change the API to accept float.
        public static void YGNodeStyleSetFlex(YogaNode node, float flex)
        {
            updateStyle<Net.YogaStyle, float>(node, s => s.Flex, flex);
        }

        // TODO(T26792433): Change the API to accept float.
        public static float YGNodeStyleGetFlex(YogaNode node)
        {
            return node.Style.Flex.IsUndefined()
                ? YogaValue.YGUndefined
                : node.Style.Flex;
        }

        // TODO(T26792433): Change the API to accept float.
        public static void YGNodeStyleSetFlexGrow(YogaNode node, float flexGrow)
        {
            updateStyle<Net.YogaStyle, float>(node, s => s.FlexGrow, flexGrow);
        }

        // TODO(T26792433): Change the API to accept float.
        public static void YGNodeStyleSetFlexShrink(YogaNode node, float flexShrink)
        {
            updateStyle<Net.YogaStyle, float>(node, s => s.FlexShrink, flexShrink);
        }

        public static YogaValue YGNodeStyleGetFlexBasis(YogaNode node)
        {
            return node.Style.FlexBasis;
            //YogaValue flexBasis = node.Style.flexBasis;
            //if (flexBasis.unit == YogaUnit.Undefined || flexBasis.unit == YogaUnit.Auto)
            //{
            //    // TODO(T26792433): Get rid off the use of YGUndefined at client side
            //    flexBasis.value = YogaValue.YGUndefined;
            //}
            //return flexBasis;
        }

        public static void YGNodeStyleSetFlexBasis(YogaNode node, float flexBasis)
        {
            var value = new YogaValue(flexBasis, YogaUnit.Point);
            updateStyleObject<Net.YogaStyle, YogaValue>(node, s => s.FlexBasis, value);
            //updateStyle<MSVC_HINT(flexBasis)>(node, &YogaStyle::flexBasis, value);
        }

        public static void YGNodeStyleSetFlexBasisPercent(
            YogaNode node,
            float flexBasisPercent)
        {
            var value = new YogaValue(flexBasisPercent, YogaUnit.Percent);
            updateStyleObject<Net.YogaStyle, YogaValue>(node, s => s.FlexBasis, value);
        }

        public static void YGNodeStyleSetFlexBasisAuto(YogaNode node)
        {
            updateStyleObject<Net.YogaStyle, YogaValue>(node, s => s.FlexBasis, YogaValue.Auto);
        }

        public static void YGNodeStyleSetPosition(YogaNode node, Edge edge, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.Position, (int)edge, value);

            //var value = YogaValue::ofMaybe<YGUnitPoint>(points);
            //updateIndexedStyleProp<MSVC_HINT(position)>(node, &YogaStyle::position, edge, value);
        }

        public static void YGNodeStyleSetPositionPercent(YogaNode node, Edge edge, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            updateIndexedStyleProp(node, node.Style.Position, (int)edge, value);
        }

        public static YogaValue YGNodeStyleGetPosition(YogaNode node, Edge edge)
        {
            return node.Style.Position[edge];
        }

        public static void YGNodeStyleSetMargin(YogaNode node, Edge edge, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.Margin, (int)edge, value);
        }

        public static void YGNodeStyleSetMarginPercent(YogaNode node, Edge edge, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            updateIndexedStyleProp(node, node.Style.Margin, (int)edge, value);
        }

        public static void YGNodeStyleSetMarginAuto(YogaNode node, Edge edge)
        {
            updateIndexedStyleProp(node, node.Style.Margin, (int)edge, YogaValue.Auto);
        }

        public static YogaValue YGNodeStyleGetMargin(YogaNode node, Edge edge)
        {
            return node.Style.Margin[edge];
        }

        public static void YGNodeStyleSetPadding(YogaNode node, Edge edge, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.Padding, (int)edge, value);
        }

        public static void YGNodeStyleSetPaddingPercent(YogaNode node, Edge edge, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            updateIndexedStyleProp(node, node.Style.Padding, (int)edge, value);
        }

        public static YogaValue YGNodeStyleGetPadding(YogaNode node, Edge edge)
        {
            return node.Style.Padding[edge];
        }

        // TODO(T26792433): Change the API to accept float.
        public static void YGNodeStyleSetBorder(YogaNode node, Edge edge, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.Border, (int)edge, value);
        }

        public static float YGNodeStyleGetBorder(YogaNode node, Edge edge)
        {
            var border = node.Style.Border[edge];
            if (border.IsUndefined || border.IsAuto)
            {
                // TODO(T26792433): Rather than returning YGUndefined, change the api to
                // return float.
                return YogaValue.YGUndefined;
            }

            return border.Value;
        }

        // Yoga specific properties, not compatible with flexbox specification

        // TODO(T26792433): Change the API to accept float.
        public static float YGNodeStyleGetAspectRatio(YogaNode node)
        {
            float op = node.Style.AspectRatio;
            return op.IsUndefined() ? YogaValue.YGUndefined : op;
        }

        // TODO(T26792433): Change the API to accept float.
        /// <summary>
        /// Yoga specific properties, not compatible with flexbox specification Aspect
        /// ratio control the size of the undefined dimension of a node. Aspect ratio is
        /// encoded as a floating point value width/height. e.g. A value of 2 leads to a
        /// node with a width twice the size of its height while a value of 0.5 gives the
        /// opposite effect.
        ///
        /// - On a node with a set width/height aspect ratio control the size of the
        ///   unset dimension
        /// - On a node with a set flex basis aspect ratio controls the size of the node
        ///   in the cross axis if unset
        /// - On a node with a measure function aspect ratio works as though the measure
        ///   function measures the flex basis
        /// - On a node with flex grow/shrink aspect ratio controls the size of the node
        ///   in the cross axis if unset
        /// - Aspect ratio takes min/max dimensions into account
        /// </summary>
        public static void YGNodeStyleSetAspectRatio(YogaNode node, float aspectRatio)
        {
            updateStyle<Net.YogaStyle, float>(node, s => s.AspectRatio, aspectRatio);
        }

        public static void YGNodeStyleSetWidth(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Width, value);
        }

        public static void YGNodeStyleSetWidthPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            updateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Width, value);
        }

        public static void YGNodeStyleSetWidthAuto(YogaNode node)
        {
            updateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Width, YogaValue.Auto);
        }

        public static YogaValue YGNodeStyleGetWidth(YogaNode node)
        {
            return node.Style.Dimensions[(int)Dimension.Width];
        }

        public static void YGNodeStyleSetHeight(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Height, value);
        }

        public static void YGNodeStyleSetHeightPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            updateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Height, value);
        }

        public static void YGNodeStyleSetHeightAuto(YogaNode node)
        {
            updateIndexedStyleProp(node, node.Style.Dimensions, (int)Dimension.Height, YogaValue.Auto);
        }

        public static YogaValue YGNodeStyleGetHeight(YogaNode node)
        {
            return node.Style.Dimensions[(int)Dimension.Height];
        }

        public static void YGNodeStyleSetMinWidth(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.MinDimensions, (int)Dimension.Width, value);
        }

        public static void YGNodeStyleSetMinWidthPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            updateIndexedStyleProp(node, node.Style.MinDimensions, (int)Dimension.Width, value);
        }

        public static YogaValue YGNodeStyleGetMinWidth(YogaNode node)
        {
            return node.Style.MinDimensions[(int)Dimension.Width];
        }

        public static void YGNodeStyleSetMinHeight(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.MinDimensions, (int)Dimension.Height, value);
        }

        public static void YGNodeStyleSetMinHeightPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            updateIndexedStyleProp(node, node.Style.MinDimensions, (int)Dimension.Height, value);
        }

        public static YogaValue YGNodeStyleGetMinHeight(YogaNode node)
        {
            return node.Style.MinDimensions[(int)Dimension.Height];
        }

        public static void YGNodeStyleSetMaxWidth(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.MaxDimensions, (int)Dimension.Width, value);
        }

        public static void YGNodeStyleSetMaxWidthPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            updateIndexedStyleProp(node, node.Style.MaxDimensions, (int)Dimension.Width, value);
        }

        public static YogaValue YGNodeStyleGetMaxWidth(YogaNode node)
        {
            return node.Style.MaxDimensions[(int)Dimension.Width];
        }

        public static void YGNodeStyleSetMaxHeight(YogaNode node, float points)
        {
            var value = new YogaValue(points, YogaUnit.Point);
            updateIndexedStyleProp(node, node.Style.MaxDimensions, (int)Dimension.Height, value);
        }

        public static void YGNodeStyleSetMaxHeightPercent(YogaNode node, float percent)
        {
            var value = new YogaValue(percent, YogaUnit.Percent);
            updateIndexedStyleProp(node, node.Style.MaxDimensions, (int)Dimension.Height, value);
        }

        public static YogaValue YGNodeStyleGetMaxHeight(YogaNode node)
        {
            return node.Style.MaxDimensions[(int)Dimension.Height];
        }

        public static float YGNodeLayoutGetLeft(YogaNode node) => node.Layout.Position[(int)Edge.Left];
        public static float YGNodeLayoutGetTop(YogaNode node) => node.Layout.Position[(int)Edge.Top];
        public static float YGNodeLayoutGetRight(YogaNode node) => node.Layout.Position[(int)Edge.Right];
        public static float YGNodeLayoutGetBottom(YogaNode node) => node.Layout.Position[(int)Edge.Bottom];
        public static float YGNodeLayoutGetWidth(YogaNode node) => node.Layout.Width;
        public static float YGNodeLayoutGetHeight(YogaNode node) => node.Layout.Height;
        public static Direction YGNodeLayoutGetDirection(YogaNode node) => node.Layout.Direction;
        public static bool YGNodeLayoutGetHadOverflow(YogaNode node) => node.Layout.HadOverflow;

        // Get the computed values for these nodes after performing layout. If they were
        // set using point values then the returned value will be the same as
        // YGNodeStyleGetXXX. However if they were set using a percentage value then the
        // returned value is the computed value used during layout.
        public static float YGNodeLayoutGetMargin(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Margin, edge);
        public static float YGNodeLayoutGetBorder(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Border, edge);
        public static float YGNodeLayoutGetPadding(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Padding, edge);

        public static float Margin(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Margin, edge);
        public static float Border(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Border, edge);
        public static float Padding(YogaNode node, Edge edge) => LayoutResolvedProperty(node, node.Layout.Padding, edge);

        public static float LayoutResolvedProperty(YogaNode node, LTRBEdge instanceName, Edge edge)
        {
            YGAssertWithNode(
                node,
                edge <= Edge.End,
                "Cannot get layout properties of multi-edge shorthands");
            if (edge == Edge.Start)
            {
                if (node.Layout.Direction == Direction.RTL)
                    return instanceName[(int)Edge.Right];
                return instanceName[(int)Edge.Left];
            }

            if (edge == Edge.End)
            {
                if (node.Layout.Direction == Direction.RTL)
                    return instanceName[(int)Edge.Left];
                return instanceName[(int)Edge.Right];
            }

            return instanceName[(int)edge];
        }

        public static int gCurrentGenerationCount = 0;

#if DEBUG
        public static void YGNodePrintInternal(
            YogaNode node,
            PrintOptions options)
        {
            var sb = new StringBuilder();

            var np = new YogaNodePrint(sb);
            np.Output(node, options, 0);
            Logger.Log(node, LogLevel.Debug, sb.ToString());
        }

        public static void YGNodePrint(YogaNode node, PrintOptions options)
        {
            YGNodePrintInternal(node, options);
        }
#endif

        internal static readonly Edge[] leading = {Edge.Top, Edge.Bottom, Edge.Left, Edge.Right};
        internal static readonly Edge[] trailing = {Edge.Bottom, Edge.Top, Edge.Right, Edge.Left};
        internal static readonly Edge[] pos = {Edge.Top, Edge.Bottom, Edge.Left, Edge.Right};
        internal static Dimension[] dim = {Dimension.Height, Dimension.Height, Dimension.Width, Dimension.Width};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YGNodePaddingAndBorderForAxis(YogaNode node, FlexDirection axis, float widthSize)
        {
            return node.GetLeadingPaddingAndBorder(axis, widthSize) +
                   node.GetTrailingPaddingAndBorder(axis, widthSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YogaAlign YGNodeAlignItem(YogaNode node, YogaNode child)
        {
            YogaAlign align = child.Style.AlignSelf == YogaAlign.Auto
                ? node.Style.AlignItems
                : child.Style.AlignSelf;
            if (align == YogaAlign.Baseline && node.Style.FlexDirection.IsColumn())
            {
                return YogaAlign.FlexStart;
            }

            return align;
        }

        public static float YGBaseline(YogaNode node, object layoutContext)
        {
            if (node.BaselineFunc != null)
            {
                Event.Hub.Publish(new NodeBaselineStartEventArgs(node));

                float layoutBaseline = node.Baseline(
                    node.Layout.MeasuredDimensions[(int)Dimension.Width],
                    node.Layout.MeasuredDimensions[(int)Dimension.Height],
                    layoutContext);

                Event.Hub.Publish(new NodeBaselineEndEventArgs(node));

                YGAssertWithNode(
                    node,
                    !YogaIsUndefined(layoutBaseline),
                    "Expect custom baseline function to not return NaN");
                return layoutBaseline;
            }

            YogaNode baselineChild = null;
            int childCount = YGNodeGetChildCount(node);
            for (int i = 0; i < childCount; i++)
            {
                YogaNode child = node.Children[i];
                if (child.LineIndex > 0)
                {
                    break;
                }

                if (child.Style.PositionType == PositionType.Absolute)
                {
                    continue;
                }

                if (YGNodeAlignItem(node, child) == YogaAlign.Baseline ||
                    child.IsReferenceBaseline)
                {
                    baselineChild = child;
                    break;
                }

                if (baselineChild == null)
                {
                    baselineChild = child;
                }
            }

            if (baselineChild == null)
            {
                return node.Layout.MeasuredDimensions[(int)Dimension.Height];
            }

            float baseline = YGBaseline(baselineChild, layoutContext);
            return baseline + baselineChild.Layout.Position[(int)Edge.Top];
        }

        public static bool YGIsBaselineLayout(YogaNode node)
        {
            if (node.Style.FlexDirection.IsColumn())
            {
                return false;
            }

            if (node.Style.AlignItems == YogaAlign.Baseline)
            {
                return true;
            }

            int childCount = YGNodeGetChildCount(node);
            for (int i = 0; i < childCount; i++)
            {
                YogaNode child = node.Children[i];
                if (child.Style.PositionType == PositionType.Relative &&
                    child.Style.AlignSelf == YogaAlign.Baseline)
                {
                    return true;
                }
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YGNodeDimWithMargin(
            YogaNode node,
            FlexDirection axis,
            float widthSize)
        {
            return node.Layout.MeasuredDimensions[(int)dim[(int)axis]] +
                (node.GetLeadingMargin(axis, widthSize) +
                    node.GetTrailingMargin(axis, widthSize));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGNodeIsStyleDimDefined(
            YogaNode node,
            FlexDirection axis,
            float ownerSize)
        {
            bool isUndefined = YogaIsUndefined(node.GetResolvedDimension(dim[(int)axis]).Value);
            return !(
                node.GetResolvedDimension(dim[(int)axis]).Unit == YogaUnit.Auto ||
                node.GetResolvedDimension(dim[(int)axis]).Unit == YogaUnit.Undefined ||
                (node.GetResolvedDimension(dim[(int)axis]).Unit == YogaUnit.Point &&
                    !isUndefined && node.GetResolvedDimension(dim[(int)axis]).Value < 0.0f) ||
                (node.GetResolvedDimension(dim[(int)axis]).Unit == YogaUnit.Percent &&
                    !isUndefined &&
                    (node.GetResolvedDimension(dim[(int)axis]).Value < 0.0f ||
                        YogaIsUndefined(ownerSize))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGNodeIsLayoutDimDefined(
            YogaNode node,
            FlexDirection axis)
        {
            float value = node.Layout.MeasuredDimensions[(int)dim[(int)axis]];
            return !YogaIsUndefined(value) && value >= 0.0f;
        }

        public static float YGNodeBoundAxisWithinMinAndMax(
            in YogaNode node,
            FlexDirection axis,
            float value,
            float axisSize)
        {
            float min = float.NaN;
            float max = float.NaN;

            if (axis.IsColumn())
            {
                min = node.Style.MinDimensions[(int)Dimension.Height].Resolve(axisSize);
                max = node.Style.MaxDimensions[(int)Dimension.Height].Resolve(axisSize);
            }
            else if (axis.IsRow())
            {
                min = node.Style.MinDimensions[(int)Dimension.Width].Resolve(axisSize);
                max = node.Style.MaxDimensions[(int)Dimension.Width].Resolve(axisSize);
            }

            if (max >= 0f && value > max)
            {
                return max;
            }

            if (min >= 0f && value < min)
            {
                return min;
            }

            return value;
        }

        // Like YGNodeBoundAxisWithinMinAndMax but also ensures that the value doesn't
        // go below the padding and border amount.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YGNodeBoundAxis(
            YogaNode node,
            FlexDirection axis,
            float value,
            float axisSize,
            float widthSize)
        {
            return FloatMax(
                YGNodeBoundAxisWithinMinAndMax(
                        node,
                        axis,
                        value,
                        axisSize),
                YGNodePaddingAndBorderForAxis(node, axis, widthSize));
        }

        public static void YGNodeSetChildTrailingPosition(
            YogaNode node,
            YogaNode child,
            FlexDirection axis)
        {
            float size = child.Layout.MeasuredDimensions[(int)dim[(int)axis]];
            child.SetLayoutPosition(
                node.Layout.MeasuredDimensions[(int)dim[(int)axis]] - size -
                child.Layout.Position[(int)pos[(int)axis]],
                (int)trailing[(int)axis]);
        }

        public static void YGConstrainMaxSizeForMode(
            in YogaNode node,
            FlexDirection axis,
            float ownerAxisSize,
            float ownerWidth,
            ref MeasureMode mode,
            ref float size)
        {
            float maxSize =
                node.Style.MaxDimensions[(int)dim[(int)axis]].Resolve(ownerAxisSize) + node.GetMarginForAxis(axis, ownerWidth);
            switch (mode)
            {
            case MeasureMode.Exactly:
            case MeasureMode.AtMost:
                size = (maxSize.IsUndefined() || size < maxSize)
                    ? size
                    : maxSize;
                break;
            case MeasureMode.Undefined:
                if (maxSize.IsValid())
                {
                    mode = MeasureMode.AtMost;
                    size = maxSize;
                }

                break;
            }
        }

        public static void YGNodeComputeFlexBasisForChild(
            YogaNode node,
            YogaNode child,
            float width,
            MeasureMode widthMode,
            float height,
            float ownerWidth,
            float ownerHeight,
            MeasureMode heightMode,
            Direction direction,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            FlexDirection mainAxis = node.Style.FlexDirection.Resolve(direction);
            bool isMainAxisRow = mainAxis.IsRow();
            float mainAxisSize = isMainAxisRow ? width : height;
            float mainAxisownerSize = isMainAxisRow ? ownerWidth : ownerHeight;

            float childWidth;
            float childHeight;
            MeasureMode childWidthMeasureMode;
            MeasureMode childHeightMeasureMode;

            float resolvedFlexBasis = child.ResolveFlexBasisPtr().Resolve(mainAxisownerSize);
            bool isRowStyleDimDefined = YGNodeIsStyleDimDefined(child, FlexDirection.Row, ownerWidth);
            bool isColumnStyleDimDefined = YGNodeIsStyleDimDefined(child, FlexDirection.Column, ownerHeight);

            if (resolvedFlexBasis.IsValid() && !YogaIsUndefined(mainAxisSize))
            {
                if (child.Layout.ComputedFlexBasis.IsUndefined() ||
                    (YGConfigIsExperimentalFeatureEnabled(child.Config, ExperimentalFeature.WebFlexBasis) &&
                        child.Layout.ComputedFlexBasisGeneration != generationCount))
                {
                    float paddingAndBorder = YGNodePaddingAndBorderForAxis(child, mainAxis, ownerWidth);
                    child.SetLayoutComputedFlexBasis(Math.Max(resolvedFlexBasis, paddingAndBorder));
                }
            }
            else if (isMainAxisRow && isRowStyleDimDefined)
            {
                // The width is definite, so use that as the flex basis.
                float paddingAndBorder = YGNodePaddingAndBorderForAxis(child, FlexDirection.Row, ownerWidth);

                child.SetLayoutComputedFlexBasis(Math.Max(child.GetResolvedDimensions()[(int)Dimension.Width].Resolve(ownerWidth), paddingAndBorder));
            }
            else if (!isMainAxisRow && isColumnStyleDimDefined)
            {
                // The height is definite, so use that as the flex basis.
                float paddingAndBorder = YGNodePaddingAndBorderForAxis(child, FlexDirection.Column, ownerWidth);
                child.SetLayoutComputedFlexBasis(Math.Max(child.GetResolvedDimensions()[(int)Dimension.Height].Resolve(ownerHeight), paddingAndBorder));
            }
            else
            {
                // Compute the flex basis and hypothetical main size (i.e. the clamped flex
                // basis).
                childWidth             = YogaValue.YGUndefined;
                childHeight            = YogaValue.YGUndefined;
                childWidthMeasureMode  = MeasureMode.Undefined;
                childHeightMeasureMode = MeasureMode.Undefined;

                var marginRow = child.GetMarginForAxis(FlexDirection.Row, ownerWidth);
                var marginColumn = child.GetMarginForAxis(FlexDirection.Column, ownerWidth);

                if (isRowStyleDimDefined)
                {
                    childWidth = child.GetResolvedDimensions()[(int)Dimension.Width]
                                      .Resolve(ownerWidth)
                                      + marginRow;
                    childWidthMeasureMode = MeasureMode.Exactly;
                }

                if (isColumnStyleDimDefined)
                {
                    childHeight = child.GetResolvedDimensions()[(int)Dimension.Height]
                                       .Resolve(ownerHeight) + marginColumn;
                    childHeightMeasureMode = MeasureMode.Exactly;
                }

                // The W3C spec doesn't say anything about the 'overflow' property, but all
                // major browsers appear to implement the following logic.
                if ((!isMainAxisRow && node.Style.Overflow == Overflow.Scroll) ||
                    node.Style.Overflow != Overflow.Scroll)
                {
                    if (YogaIsUndefined(childWidth) && !YogaIsUndefined(width))
                    {
                        childWidth            = width;
                        childWidthMeasureMode = MeasureMode.AtMost;
                    }
                }

                if ((isMainAxisRow && node.Style.Overflow == Overflow.Scroll) ||
                    node.Style.Overflow != Overflow.Scroll)
                {
                    if (YogaIsUndefined(childHeight) && !YogaIsUndefined(height))
                    {
                        childHeight            = height;
                        childHeightMeasureMode = MeasureMode.AtMost;
                    }
                }

                var childStyle = child.Style;
                if (childStyle.AspectRatio.IsValid())
                {
                    if (!isMainAxisRow && childWidthMeasureMode == MeasureMode.Exactly)
                    {
                        childHeight = marginColumn +
                            (childWidth - marginRow) / childStyle.AspectRatio;
                        childHeightMeasureMode = MeasureMode.Exactly;
                    }
                    else if (
                        isMainAxisRow && childHeightMeasureMode == MeasureMode.Exactly)
                    {
                        childWidth = marginRow +
                            (childHeight - marginColumn) * childStyle.AspectRatio;
                        childWidthMeasureMode = MeasureMode.Exactly;
                    }
                }

                // If child has no defined size in the cross axis and is set to stretch, set
                // the cross axis to be measured exactly with the available inner width

                bool hasExactWidth =
                    !YogaIsUndefined(width) && widthMode == MeasureMode.Exactly;
                bool childWidthStretch =
                    YGNodeAlignItem(node, child) == YogaAlign.Stretch &&
                    childWidthMeasureMode != MeasureMode.Exactly;
                if (!isMainAxisRow && !isRowStyleDimDefined && hasExactWidth &&
                    childWidthStretch)
                {
                    childWidth            = width;
                    childWidthMeasureMode = MeasureMode.Exactly;
                    if (childStyle.AspectRatio.IsValid())
                    {
                        childHeight = (childWidth - marginRow) / childStyle.AspectRatio;
                        childHeightMeasureMode = MeasureMode.Exactly;
                    }
                }

                bool hasExactHeight =
                    !YogaIsUndefined(height) && heightMode == MeasureMode.Exactly;
                bool childHeightStretch =
                    YGNodeAlignItem(node, child) == YogaAlign.Stretch &&
                    childHeightMeasureMode != MeasureMode.Exactly;
                if (isMainAxisRow && !isColumnStyleDimDefined && hasExactHeight &&
                    childHeightStretch)
                {
                    childHeight            = height;
                    childHeightMeasureMode = MeasureMode.Exactly;

                    if (childStyle.AspectRatio.IsValid())
                    {
                        childWidth            = (childHeight - marginColumn) * childStyle.AspectRatio;
                        childWidthMeasureMode = MeasureMode.Exactly;
                    }
                }

                YGConstrainMaxSizeForMode(
                    child,
                    FlexDirection.Row,
                    ownerWidth,
                    ownerWidth,
                    ref childWidthMeasureMode,
                    ref childWidth);
                YGConstrainMaxSizeForMode(
                    child,
                    FlexDirection.Column,
                    ownerHeight,
                    ownerWidth,
                    ref childHeightMeasureMode,
                    ref childHeight);

                // Measure the child
                YGLayoutNodeInternal(
                    child,
                    childWidth,
                    childHeight,
                    direction,
                    childWidthMeasureMode,
                    childHeightMeasureMode,
                    ownerWidth,
                    ownerHeight,
                    false,
                    LayoutPassReason.MeasureChild,
                    config,
                    layoutMarkerData,
                    layoutContext,
                    depth,
                    generationCount);

                child.SetLayoutComputedFlexBasis(
                    FloatMax(
                            child.Layout.MeasuredDimensions[(int)dim[(int)mainAxis]],
                            YGNodePaddingAndBorderForAxis(child, mainAxis, ownerWidth)));
            }

            child.SetLayoutComputedFlexBasisGeneration(generationCount);
        }

        public static void YGNodeAbsoluteLayoutChild(
            YogaNode node,
            YogaNode child,
            float width,
            MeasureMode widthMode,
            float height,
            Direction direction,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            FlexDirection mainAxis = node.Style.FlexDirection.Resolve(direction);
            FlexDirection crossAxis = mainAxis.CrossAxis(direction);
            bool isMainAxisRow = mainAxis.IsRow();

            float childWidth = YogaValue.YGUndefined;
            float childHeight = YogaValue.YGUndefined;
            MeasureMode childWidthMeasureMode = MeasureMode.Undefined;
            MeasureMode childHeightMeasureMode = MeasureMode.Undefined;

            var marginRow = child.GetMarginForAxis(FlexDirection.Row, width);
            var marginColumn =
                child.GetMarginForAxis(FlexDirection.Column, width);

            if (YGNodeIsStyleDimDefined(child, FlexDirection.Row, width))
            {
                childWidth =
                    child.GetResolvedDimensions()[(int)Dimension.Width].Resolve(width) + marginRow;
            }
            else
            {
                // If the child doesn't have a specified width, compute the width based on
                // the left/right offsets if they're defined.
                if (child.IsLeadingPositionDefined(FlexDirection.Row) &&
                    child.IsTrailingPosDefined(FlexDirection.Row))
                {
                    childWidth = node.Layout.MeasuredDimensions[(int)Dimension.Width] -
                        (node.GetLeadingBorder(FlexDirection.Row) +
                            node.GetTrailingBorder(FlexDirection.Row)) -
                        (child.GetLeadingPosition(FlexDirection.Row, width) +
                            child.GetTrailingPosition(FlexDirection.Row, width));
                    childWidth = YGNodeBoundAxis(child, FlexDirection.Row, childWidth, width, width);
                }
            }

            if (YGNodeIsStyleDimDefined(child, FlexDirection.Column, height))
            {
                childHeight = child.GetResolvedDimensions()[(int)Dimension.Height]
                                   .Resolve(height) + marginColumn;
            }
            else
            {
                // If the child doesn't have a specified height, compute the height based on
                // the top/bottom offsets if they're defined.
                if (child.IsLeadingPositionDefined(FlexDirection.Column) &&
                    child.IsTrailingPosDefined(FlexDirection.Column))
                {
                    childHeight = node.Layout.MeasuredDimensions[(int)Dimension.Height] -
                        (node.GetLeadingBorder(FlexDirection.Column) +
                            node.GetTrailingBorder(FlexDirection.Column)) -
                        (child.GetLeadingPosition(FlexDirection.Column, height) +
                            child.GetTrailingPosition(FlexDirection.Column, height));
                    childHeight = YGNodeBoundAxis(
                        child,
                        FlexDirection.Column,
                        childHeight,
                        height,
                        width);
                }
            }

            // Exactly one dimension needs to be defined for us to be able to do aspect
            // ratio calculation. One dimension being the anchor and the other being
            // flexible.
            var childStyle = child.Style;
            if (YogaIsUndefined(childWidth) ^ YogaIsUndefined(childHeight))
            {
                if (childStyle.AspectRatio.IsValid())
                {
                    if (YogaIsUndefined(childWidth))
                    {
                        childWidth = marginRow + (childHeight - marginColumn) * childStyle.AspectRatio;
                    }
                    else if (YogaIsUndefined(childHeight))
                    {
                        childHeight = marginColumn + (childWidth - marginRow) / childStyle.AspectRatio;
                    }
                }
            }

            // If we're still missing one or the other dimension, measure the content.
            if (YogaIsUndefined(childWidth) || YogaIsUndefined(childHeight))
            {
                childWidthMeasureMode = YogaIsUndefined(childWidth)
                    ? MeasureMode.Undefined
                    : MeasureMode.Exactly;
                childHeightMeasureMode = YogaIsUndefined(childHeight)
                    ? MeasureMode.Undefined
                    : MeasureMode.Exactly;

                // If the size of the owner is defined then try to constrain the absolute
                // child to that size as well. This allows text within the absolute child to
                // wrap to the size of its owner. This is the same behavior as many browsers
                // implement.
                if (!isMainAxisRow && YogaIsUndefined(childWidth) &&
                    widthMode != MeasureMode.Undefined && !YogaIsUndefined(width) &&
                    width > 0)
                {
                    childWidth            = width;
                    childWidthMeasureMode = MeasureMode.AtMost;
                }

                YGLayoutNodeInternal(
                    child,
                    childWidth,
                    childHeight,
                    direction,
                    childWidthMeasureMode,
                    childHeightMeasureMode,
                    childWidth,
                    childHeight,
                    false,
                    LayoutPassReason.AbsMeasureChild,
                    config,
                    layoutMarkerData,
                    layoutContext,
                    depth,
                    generationCount);
                childWidth = child.Layout.MeasuredDimensions[(int)Dimension.Width] +
                    child.GetMarginForAxis(FlexDirection.Row, width);
                childHeight = child.Layout.MeasuredDimensions[(int)Dimension.Height] +
                    child.GetMarginForAxis(FlexDirection.Column, width);
            }

            YGLayoutNodeInternal(
                child,
                childWidth,
                childHeight,
                direction,
                MeasureMode.Exactly,
                MeasureMode.Exactly,
                childWidth,
                childHeight,
                true,
                LayoutPassReason.AbsLayout,
                config,
                layoutMarkerData,
                layoutContext,
                depth,
                generationCount);

            if (child.IsTrailingPosDefined(mainAxis) &&
                !child.IsLeadingPositionDefined(mainAxis))
            {
                child.SetLayoutPosition(
                    node.Layout.MeasuredDimensions[(int)dim[(int)mainAxis]] -
                    child.Layout.MeasuredDimensions[(int)dim[(int)mainAxis]] -
                    node.GetTrailingBorder(mainAxis) -
                    child.GetTrailingMargin(mainAxis, width) -
                    child.GetTrailingPosition(mainAxis, isMainAxisRow ? width : height),
                    (int)leading[(int)mainAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(mainAxis) &&
                node.Style.JustifyContent == Justify.Center)
            {
                child.SetLayoutPosition(
                    (node.Layout.MeasuredDimensions[(int)dim[(int)mainAxis]] -
                        child.Layout.MeasuredDimensions[(int)dim[(int)mainAxis]]) /
                    2.0f,
                    (int)leading[(int)mainAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(mainAxis) &&
                node.Style.JustifyContent == Justify.FlexEnd)
            {
                child.SetLayoutPosition(
                    (node.Layout.MeasuredDimensions[(int)dim[(int)mainAxis]] -
                        child.Layout.MeasuredDimensions[(int)dim[(int)mainAxis]]),
                    (int)leading[(int)mainAxis]);
            }

            if (child.IsTrailingPosDefined(crossAxis) &&
                !child.IsLeadingPositionDefined(crossAxis))
            {
                child.SetLayoutPosition(
                    node.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]] -
                    child.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]] -
                    node.GetTrailingBorder(crossAxis) -
                    child.GetTrailingMargin(crossAxis, width) - 
                    child.GetTrailingPosition(crossAxis, isMainAxisRow ? height : width),
                    (int)leading[(int)crossAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(crossAxis) &&
                YGNodeAlignItem(node, child) == YogaAlign.Center)
            {
                child.SetLayoutPosition(
                    (node.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]] -
                        child.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]]) /
                    2.0f,
                    (int)leading[(int)crossAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(crossAxis) &&
                ((YGNodeAlignItem(node, child) == YogaAlign.FlexEnd) ^
                    (node.Style.FlexWrap == Wrap.WrapReverse)))
            {
                child.SetLayoutPosition(
                    (node.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]] -
                        child.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]]),
                    (int)leading[(int)crossAxis]);
            }
        }

        public static void YGNodeWithMeasureFuncSetMeasuredDimensions(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight,
            LayoutData layoutMarkerData,
            object layoutContext,
            LayoutPassReason reason)
        {
            YGAssertWithNode(
                node,
                node.MeasureFunc != null,
                "Expected node to have custom measure function");

            float paddingAndBorderAxisRow =
                YGNodePaddingAndBorderForAxis(node, FlexDirection.Row, availableWidth);
            float paddingAndBorderAxisColumn = YGNodePaddingAndBorderForAxis(
                node,
                FlexDirection.Column,
                availableWidth);
            float marginAxisRow = node.GetMarginForAxis(FlexDirection.Row, availableWidth);
            float marginAxisColumn = node.GetMarginForAxis(FlexDirection.Column, availableWidth);

            // We want to make sure we don't call measure with negative size
            float innerWidth = YogaIsUndefined(availableWidth)
                ? availableWidth
                : FloatMax(0, availableWidth - marginAxisRow - paddingAndBorderAxisRow);
            float innerHeight = YogaIsUndefined(availableHeight)
                ? availableHeight
                : FloatMax(
                    0,
                    availableHeight - marginAxisColumn - paddingAndBorderAxisColumn);

            if (widthMeasureMode == MeasureMode.Exactly &&
                heightMeasureMode == MeasureMode.Exactly)
            {
                // Don't bother sizing the text if both dimensions are already defined.
                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        FlexDirection.Row,
                        availableWidth - marginAxisRow,
                        ownerWidth,
                        ownerWidth),
                    Dimension.Width);
                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        FlexDirection.Column,
                        availableHeight - marginAxisColumn,
                        ownerHeight,
                        ownerWidth),
                    Dimension.Height);
            }
            else
            {
                Event.Hub.Publish(new MeasureCallbackStartEventArgs(node));

                // Measure the text under the current constraints.
                YogaSize measuredSize = node.Measure(
                    innerWidth,
                    widthMeasureMode,
                    innerHeight,
                    heightMeasureMode,
                    layoutContext);

                unsafe
                {
                    layoutMarkerData.MeasureCallbacks                         += 1;
                    layoutMarkerData.MeasureCallbackReasonsCount[(int)reason] += 1;
                }

                Event.Hub.Publish(
                    new MeasureCallbackEndEventArgs(
                        node,
                        layoutContext,
                        innerWidth,
                        widthMeasureMode,
                        innerHeight,
                        heightMeasureMode,
                        measuredSize.Width,
                        measuredSize.Height,
                        reason));

                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        FlexDirection.Row,
                        (widthMeasureMode == MeasureMode.Undefined ||
                            widthMeasureMode == MeasureMode.AtMost)
                            ? measuredSize.Width + paddingAndBorderAxisRow
                            : availableWidth - marginAxisRow,
                        ownerWidth,
                        ownerWidth),
                    Dimension.Width);

                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        FlexDirection.Column,
                        (heightMeasureMode == MeasureMode.Undefined ||
                            heightMeasureMode == MeasureMode.AtMost)
                            ? measuredSize.Height + paddingAndBorderAxisColumn
                            : availableHeight - marginAxisColumn,
                        ownerHeight,
                        ownerWidth),
                    Dimension.Height);
            }
        }

        // For nodes with no children, use the available values if they were provided,
        // or the minimum size as indicated by the padding and border sizes.
        public static void YGNodeEmptyContainerSetMeasuredDimensions(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight)
        {
            float paddingAndBorderAxisRow = YGNodePaddingAndBorderForAxis(node, FlexDirection.Row, ownerWidth);
            float paddingAndBorderAxisColumn = YGNodePaddingAndBorderForAxis(node, FlexDirection.Column, ownerWidth);
            float marginAxisRow = node.GetMarginForAxis(FlexDirection.Row, ownerWidth);
            float marginAxisColumn = node.GetMarginForAxis(FlexDirection.Column, ownerWidth);

            node.SetLayoutMeasuredDimension(
                YGNodeBoundAxis(
                    node,
                    FlexDirection.Row,
                    (widthMeasureMode == MeasureMode.Undefined ||
                        widthMeasureMode == MeasureMode.AtMost)
                        ? paddingAndBorderAxisRow
                        : availableWidth - marginAxisRow,
                    ownerWidth,
                    ownerWidth),
                Dimension.Width);

            node.SetLayoutMeasuredDimension(
                YGNodeBoundAxis(
                    node,
                    FlexDirection.Column,
                    (heightMeasureMode == MeasureMode.Undefined ||
                        heightMeasureMode == MeasureMode.AtMost)
                        ? paddingAndBorderAxisColumn
                        : availableHeight - marginAxisColumn,
                    ownerHeight,
                    ownerWidth),
                Dimension.Height);
        }

        public static bool YGNodeFixedSizeSetMeasuredDimensions(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight)
        {
            if ((!YogaIsUndefined(availableWidth) &&
                    widthMeasureMode == MeasureMode.AtMost && availableWidth <= 0.0f) ||
                (!YogaIsUndefined(availableHeight) &&
                    heightMeasureMode == MeasureMode.AtMost && availableHeight <= 0.0f) ||
                (widthMeasureMode == MeasureMode.Exactly &&
                    heightMeasureMode == MeasureMode.Exactly))
            {
                var marginAxisColumn = node.GetMarginForAxis(FlexDirection.Column, ownerWidth);
                var marginAxisRow = node.GetMarginForAxis(FlexDirection.Row, ownerWidth);

                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        FlexDirection.Row,
                        YogaIsUndefined(availableWidth) ||
                        (widthMeasureMode == MeasureMode.AtMost &&
                            availableWidth < 0.0f)
                            ? 0.0f
                            : availableWidth - marginAxisRow,
                        ownerWidth,
                        ownerWidth),
                    Dimension.Width);

                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        FlexDirection.Column,
                        YogaIsUndefined(availableHeight) ||
                        (heightMeasureMode == MeasureMode.AtMost &&
                            availableHeight < 0.0f)
                            ? 0.0f
                            : availableHeight - marginAxisColumn,
                        ownerHeight,
                        ownerWidth),
                    Dimension.Height);
                return true;
            }

            return false;
        }

        public static void YGZeroOutLayoutRecursivly(
            YogaNode node,
            object layoutContext)
        {
            node.Layout = new YogaLayout();
            node.Layout.Width = 0f;
            node.Layout.Height = 0f;
            node.SetHasNewLayout(true);

            node.IterChildrenAfterCloningIfNeeded(
                YGZeroOutLayoutRecursivly,
                layoutContext);
        }

        public static float YGNodeCalculateAvailableInnerDim(
            in YogaNode node,
            FlexDirection axis,
            float availableDim,
            float ownerDim)
        {
            FlexDirection direction = axis.IsRow() ? FlexDirection.Row : FlexDirection.Column;
            Dimension dimension = axis.IsRow() ? Dimension.Width : Dimension.Height;

            float margin = node.GetMarginForAxis(direction, ownerDim);
            float paddingAndBorder =
                YGNodePaddingAndBorderForAxis(node, direction, ownerDim);

            float availableInnerDim = availableDim - margin - paddingAndBorder;
            // Max dimension overrides predefined dimension value; Min dimension in turn
            // overrides both of the above
            if (!YogaIsUndefined(availableInnerDim))
            {
                // We want to make sure our available height does not violate min and max
                // constraints
                float minDimensionOptional = node.Style.MinDimensions[dimension].Resolve(ownerDim);
                float minInnerDim = minDimensionOptional.IsUndefined()
                    ? 0.0f
                    : minDimensionOptional - paddingAndBorder;

                float maxDimensionOptional = node.Style.MaxDimensions[dimension].Resolve(ownerDim);

                float maxInnerDim = maxDimensionOptional.IsUndefined()
                    ? float.MaxValue
                    : maxDimensionOptional - paddingAndBorder;
                availableInnerDim = FloatMax(FloatMin(availableInnerDim, maxInnerDim), minInnerDim);
            }

            return availableInnerDim;
        }

        public static float YGNodeComputeFlexBasisForChildren(
            YogaNode node,
            float availableInnerWidth,
            float availableInnerHeight,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            Direction direction,
            FlexDirection mainAxis,
            YogaConfig config,
            bool performLayout,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            float totalOuterFlexBasis = 0.0f;
            YogaNode singleFlexChild = null;
            YogaNodes children = new YogaNodes(node.Children);
            MeasureMode measureModeMainDim =
                mainAxis.IsRow() ? widthMeasureMode : heightMeasureMode;
            // If there is only one child with flexGrow + flexShrink it means we can set
            // the computedFlexBasis to 0 instead of measuring and shrinking / flexing the
            // child to exactly match the remaining space
            if (measureModeMainDim == MeasureMode.Exactly)
            {
                foreach (var child in children)
                {
                    if (child.IsNodeFlexible())
                    {
                        if (singleFlexChild != null ||
                            FloatsEqual(child.ResolveFlexGrow(), 0.0f) ||
                            FloatsEqual(child.ResolveFlexShrink(), 0.0f))
                        {
                            // There is already a flexible child, or this flexible child doesn't
                            // have flexGrow and flexShrink, abort
                            singleFlexChild = null;
                            break;
                        }
                        else
                        {
                            singleFlexChild = child;
                        }
                    }
                }
            }

            foreach (var child in children)
            {
                child.ResolveDimension();
                if (child.Style.Display == Display.None)
                {
                    YGZeroOutLayoutRecursivly(child, layoutContext);
                    child.SetHasNewLayout(true);
                    child.SetDirty(false);
                    continue;
                }

                if (performLayout)
                {
                    // Set the initial position (relative to the owner).
                    Direction childDirection = child.ResolveDirection(direction);
                    float mainDim = mainAxis.IsRow() ? availableInnerWidth : availableInnerHeight;
                    float crossDim = mainAxis.IsRow() ? availableInnerHeight : availableInnerWidth;
                    child.SetPosition(
                        childDirection,
                        mainDim,
                        crossDim,
                        availableInnerWidth);
                }

                if (child.Style.PositionType == PositionType.Absolute)
                {
                    continue;
                }

                if (child == singleFlexChild)
                {
                    child.SetLayoutComputedFlexBasisGeneration(generationCount);
                    child.SetLayoutComputedFlexBasis(0f);
                }
                else
                {
                    YGNodeComputeFlexBasisForChild(
                        node,
                        child,
                        availableInnerWidth,
                        widthMeasureMode,
                        availableInnerHeight,
                        availableInnerWidth,
                        availableInnerHeight,
                        heightMeasureMode,
                        direction,
                        config,
                        layoutMarkerData,
                        layoutContext,
                        depth,
                        generationCount);
                }

                totalOuterFlexBasis +=
                    (child.Layout.ComputedFlexBasis + child.GetMarginForAxis(mainAxis, availableInnerWidth));
            }

            return totalOuterFlexBasis;
        }

        // This function assumes that all the children of node have their
        // computedFlexBasis properly computed(To do this use
        // YGNodeComputeFlexBasisForChildren function). This function calculates
        // YGCollectFlexItemsRowMeasurement
        public static CollectFlexItemsRowValues YGCalculateCollectFlexItemsRowValues(
            YogaNode node,
            Direction ownerDirection,
            float mainAxisownerSize,
            float availableInnerWidth,
            float availableInnerMainDim,
            int startOfLineIndex,
            int lineCount)
        {
            CollectFlexItemsRowValues flexAlgoRowMeasurement = new CollectFlexItemsRowValues();
            flexAlgoRowMeasurement.RelativeChildren = new List<YogaNode>(node.Children.Count);

            float sizeConsumedOnCurrentLineIncludingMinConstraint = 0;
            FlexDirection mainAxis = node.Style.FlexDirection.Resolve(node.ResolveDirection(ownerDirection));
            bool isNodeFlexWrap = node.Style.FlexWrap != Wrap.NoWrap;

            // Add items to the current line until it's full or we run out of items.
            int endOfLineIndex = startOfLineIndex;
            for (; endOfLineIndex < node.Children.Count; endOfLineIndex++)
            {
                YogaNode child = node.Children[endOfLineIndex];
                if (child.Style.Display == Display.None ||
                    child.Style.PositionType == PositionType.Absolute)
                {
                    continue;
                }

                child.LineIndex = lineCount;
                float childMarginMainAxis =
                    child.GetMarginForAxis(mainAxis, availableInnerWidth);
                float flexBasisWithMinAndMaxConstraints =
                    YGNodeBoundAxisWithinMinAndMax(
                            child,
                            mainAxis,
                            child.Layout.ComputedFlexBasis,
                            mainAxisownerSize);

                // If this is a multi-line flow and this item pushes us over the available
                // size, we've hit the end of the current line. Break out of the loop and
                // lay out the current line.
                if (sizeConsumedOnCurrentLineIncludingMinConstraint +
                    flexBasisWithMinAndMaxConstraints + childMarginMainAxis >
                    availableInnerMainDim &&
                    isNodeFlexWrap && flexAlgoRowMeasurement.ItemsOnLine > 0)
                {
                    break;
                }

                sizeConsumedOnCurrentLineIncludingMinConstraint +=
                    flexBasisWithMinAndMaxConstraints + childMarginMainAxis;
                flexAlgoRowMeasurement.SizeConsumedOnCurrentLine +=
                    flexBasisWithMinAndMaxConstraints + childMarginMainAxis;
                flexAlgoRowMeasurement.ItemsOnLine++;

                if (child.IsNodeFlexible())
                {
                    flexAlgoRowMeasurement.TotalFlexGrowFactors += child.ResolveFlexGrow();

                    // Unlike the grow factor, the shrink factor is scaled relative to the
                    // child dimension.
                    flexAlgoRowMeasurement.TotalFlexShrinkScaledFactors +=
                        -child.ResolveFlexShrink() *
                        child.Layout.ComputedFlexBasis;
                }

                flexAlgoRowMeasurement.RelativeChildren.Add(child);
            }

            // The total flex factor needs to be floored to 1.
            if (flexAlgoRowMeasurement.TotalFlexGrowFactors > 0 &&
                flexAlgoRowMeasurement.TotalFlexGrowFactors < 1)
            {
                flexAlgoRowMeasurement.TotalFlexGrowFactors = 1;
            }

            // The total flex shrink factor needs to be floored to 1.
            if (flexAlgoRowMeasurement.TotalFlexShrinkScaledFactors > 0 &&
                flexAlgoRowMeasurement.TotalFlexShrinkScaledFactors < 1)
            {
                flexAlgoRowMeasurement.TotalFlexShrinkScaledFactors = 1;
            }

            flexAlgoRowMeasurement.EndOfLineIndex = endOfLineIndex;
            return flexAlgoRowMeasurement;
        }

        // It distributes the free space to the flexible items and ensures that the size
        // of the flex items abide the min and max constraints. At the end of this
        // function the child nodes would have proper size. Prior using this function
        // please ensure that YGDistributeFreeSpaceFirstPass is called.
        public static float YGDistributeFreeSpaceSecondPass(
            CollectFlexItemsRowValues collectedFlexItemsValues,
            YogaNode node,
            FlexDirection mainAxis,
            FlexDirection crossAxis,
            float mainAxisownerSize,
            float availableInnerMainDim,
            float availableInnerCrossDim,
            float availableInnerWidth,
            float availableInnerHeight,
            bool flexBasisOverflows,
            MeasureMode measureModeCrossDim,
            bool performLayout,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            float childFlexBasis = 0;
            float flexShrinkScaledFactor = 0;
            float flexGrowFactor = 0;
            float deltaFreeSpace = 0;
            bool isMainAxisRow = mainAxis.IsRow();
            bool isNodeFlexWrap = node.Style.FlexWrap != Wrap.NoWrap;

            foreach (var currentRelativeChild in collectedFlexItemsValues.RelativeChildren)
            {
                childFlexBasis = YGNodeBoundAxisWithinMinAndMax(
                        currentRelativeChild,
                        mainAxis,
                        currentRelativeChild.Layout.ComputedFlexBasis,
                        mainAxisownerSize);
                float updatedMainSize = childFlexBasis;

                if (!YogaIsUndefined(collectedFlexItemsValues.RemainingFreeSpace) &&
                    collectedFlexItemsValues.RemainingFreeSpace < 0)
                {
                    flexShrinkScaledFactor =
                        -currentRelativeChild.ResolveFlexShrink() * childFlexBasis;
                    // Is this child able to shrink?
                    if (flexShrinkScaledFactor != 0)
                    {
                        float childSize;

                        if (!YogaIsUndefined(
                                collectedFlexItemsValues.TotalFlexShrinkScaledFactors) &&
                            collectedFlexItemsValues.TotalFlexShrinkScaledFactors == 0)
                        {
                            childSize = childFlexBasis + flexShrinkScaledFactor;
                        }
                        else
                        {
                            childSize = childFlexBasis +
                                (collectedFlexItemsValues.RemainingFreeSpace /
                                    collectedFlexItemsValues.TotalFlexShrinkScaledFactors) *
                                flexShrinkScaledFactor;
                        }

                        updatedMainSize = YGNodeBoundAxis(
                            currentRelativeChild,
                            mainAxis,
                            childSize,
                            availableInnerMainDim,
                            availableInnerWidth);
                    }
                }
                else if (
                    !YogaIsUndefined(collectedFlexItemsValues.RemainingFreeSpace) &&
                    collectedFlexItemsValues.RemainingFreeSpace > 0)
                {
                    flexGrowFactor = currentRelativeChild.ResolveFlexGrow();

                    // Is this child able to grow?
                    if (!YogaIsUndefined(flexGrowFactor) && flexGrowFactor.IsNotZero())
                    {
                        updatedMainSize = YGNodeBoundAxis(
                            currentRelativeChild,
                            mainAxis,
                            childFlexBasis +
                            collectedFlexItemsValues.RemainingFreeSpace /
                            collectedFlexItemsValues.TotalFlexGrowFactors *
                            flexGrowFactor,
                            availableInnerMainDim,
                            availableInnerWidth);
                    }
                }

                deltaFreeSpace += updatedMainSize - childFlexBasis;

                float marginMain =
                    currentRelativeChild.GetMarginForAxis(mainAxis, availableInnerWidth);
                float marginCross =
                    currentRelativeChild.GetMarginForAxis(crossAxis, availableInnerWidth);

                float childCrossSize;
                float childMainSize = updatedMainSize + marginMain;
                MeasureMode childCrossMeasureMode;
                MeasureMode childMainMeasureMode = MeasureMode.Exactly;

                var childStyle = currentRelativeChild.Style;
                if (childStyle.AspectRatio.IsValid())
                {
                    childCrossSize = isMainAxisRow
                        ? (childMainSize - marginMain) / childStyle.AspectRatio
                        : (childMainSize - marginMain) * childStyle.AspectRatio;
                    childCrossMeasureMode = MeasureMode.Exactly;

                    childCrossSize += marginCross;
                }
                else if (
                    !YogaIsUndefined(availableInnerCrossDim) &&
                    !YGNodeIsStyleDimDefined(
                        currentRelativeChild,
                        crossAxis,
                        availableInnerCrossDim) &&
                    measureModeCrossDim == MeasureMode.Exactly &&
                    !(isNodeFlexWrap && flexBasisOverflows) &&
                    YGNodeAlignItem(node, currentRelativeChild) == YogaAlign.Stretch &&
                    currentRelativeChild.MarginLeadingValue(crossAxis).Unit != YogaUnit.Auto &&
                    currentRelativeChild.MarginTrailingValue(crossAxis).Unit != YogaUnit.Auto)
                {
                    childCrossSize        = availableInnerCrossDim;
                    childCrossMeasureMode = MeasureMode.Exactly;
                }
                else if (!YGNodeIsStyleDimDefined(
                    currentRelativeChild,
                    crossAxis,
                    availableInnerCrossDim))
                {
                    childCrossSize = availableInnerCrossDim;
                    childCrossMeasureMode = YogaIsUndefined(childCrossSize)
                        ? MeasureMode.Undefined
                        : MeasureMode.AtMost;
                }
                else
                {
                    childCrossSize = currentRelativeChild.GetResolvedDimension(dim[(int)crossAxis])
                                                         .Resolve(availableInnerCrossDim)
                                                         + marginCross;
                    bool isLoosePercentageMeasurement =
                        currentRelativeChild.GetResolvedDimension(dim[(int)crossAxis]).Unit == YogaUnit.Percent &&
                        measureModeCrossDim != MeasureMode.Exactly;
                    childCrossMeasureMode =
                        YogaIsUndefined(childCrossSize) || isLoosePercentageMeasurement
                            ? MeasureMode.Undefined
                            : MeasureMode.Exactly;
                }

                YGConstrainMaxSizeForMode(
                    currentRelativeChild,
                    mainAxis,
                    availableInnerMainDim,
                    availableInnerWidth,
                    ref childMainMeasureMode,
                    ref childMainSize);
                YGConstrainMaxSizeForMode(
                    currentRelativeChild,
                    crossAxis,
                    availableInnerCrossDim,
                    availableInnerWidth,
                    ref childCrossMeasureMode,
                    ref childCrossSize);

                bool requiresStretchLayout =
                    !YGNodeIsStyleDimDefined(
                        currentRelativeChild,
                        crossAxis,
                        availableInnerCrossDim) &&
                    YGNodeAlignItem(node, currentRelativeChild) == YogaAlign.Stretch &&
                    currentRelativeChild.MarginLeadingValue(crossAxis).Unit !=
                    YogaUnit.Auto &&
                    currentRelativeChild.MarginTrailingValue(crossAxis).Unit != YogaUnit.Auto;

                float childWidth = isMainAxisRow ? childMainSize : childCrossSize;
                float childHeight = !isMainAxisRow ? childMainSize : childCrossSize;

                MeasureMode childWidthMeasureMode =
                    isMainAxisRow ? childMainMeasureMode : childCrossMeasureMode;
                MeasureMode childHeightMeasureMode =
                    !isMainAxisRow ? childMainMeasureMode : childCrossMeasureMode;

                bool isLayoutPass = performLayout && !requiresStretchLayout;
                // Recursively call the layout algorithm for this child with the updated
                // main size.
                YGLayoutNodeInternal(
                    currentRelativeChild,
                    childWidth,
                    childHeight,
                    node.Layout.Direction,
                    childWidthMeasureMode,
                    childHeightMeasureMode,
                    availableInnerWidth,
                    availableInnerHeight,
                    isLayoutPass,
                    isLayoutPass
                        ? LayoutPassReason.FlexLayout
                        : LayoutPassReason.FlexMeasure,
                    config,
                    layoutMarkerData,
                    layoutContext,
                    depth,
                    generationCount);
                node.SetLayoutHadOverflow(
                    node.Layout.HadOverflow |
                    currentRelativeChild.Layout.HadOverflow);
            }

            return deltaFreeSpace;
        }

        // It distributes the free space to the flexible items.For those flexible items
        // whose min and max constraints are triggered, those flex item's clamped size
        // is removed from the remaingfreespace.
        public static void YGDistributeFreeSpaceFirstPass(
            CollectFlexItemsRowValues collectedFlexItemsValues,
            FlexDirection mainAxis,
            float mainAxisownerSize,
            float availableInnerMainDim,
            float availableInnerWidth)
        {
            float flexShrinkScaledFactor = 0;
            float flexGrowFactor = 0;
            float baseMainSize = 0;
            float boundMainSize = 0;
            float deltaFreeSpace = 0;

            foreach (var currentRelativeChild in collectedFlexItemsValues.RelativeChildren)
            {
                float childFlexBasis =
                    YGNodeBoundAxisWithinMinAndMax(
                            currentRelativeChild,
                            mainAxis,
                            currentRelativeChild.Layout.ComputedFlexBasis,
                            mainAxisownerSize);

                if (collectedFlexItemsValues.RemainingFreeSpace < 0)
                {
                    flexShrinkScaledFactor =
                        -currentRelativeChild.ResolveFlexShrink() * childFlexBasis;

                    // Is this child able to shrink?
                    if (!YogaIsUndefined(flexShrinkScaledFactor) &&
                        flexShrinkScaledFactor != 0)
                    {
                        baseMainSize = childFlexBasis +
                            collectedFlexItemsValues.RemainingFreeSpace /
                            collectedFlexItemsValues.TotalFlexShrinkScaledFactors *
                            flexShrinkScaledFactor;
                        boundMainSize = YGNodeBoundAxis(
                            currentRelativeChild,
                            mainAxis,
                            baseMainSize,
                            availableInnerMainDim,
                            availableInnerWidth);
                        if (!YogaIsUndefined(baseMainSize) &&
                            !YogaIsUndefined(boundMainSize) &&
                            baseMainSize != boundMainSize)
                        {
                            // By excluding this item's size and flex factor from remaining, this
                            // item's min/max constraints should also trigger in the second pass
                            // resulting in the item's size calculation being identical in the
                            // first and second passes.
                            deltaFreeSpace += boundMainSize - childFlexBasis;
                            collectedFlexItemsValues.TotalFlexShrinkScaledFactors -=
                                flexShrinkScaledFactor;
                        }
                    }
                }
                else if (
                    !YogaIsUndefined(collectedFlexItemsValues.RemainingFreeSpace) &&
                    collectedFlexItemsValues.RemainingFreeSpace > 0)
                {
                    flexGrowFactor = currentRelativeChild.ResolveFlexGrow();

                    // Is this child able to grow?
                    if (!YogaIsUndefined(flexGrowFactor) && flexGrowFactor != 0)
                    {
                        baseMainSize = childFlexBasis +
                            collectedFlexItemsValues.RemainingFreeSpace /
                            collectedFlexItemsValues.TotalFlexGrowFactors * flexGrowFactor;
                        boundMainSize = YGNodeBoundAxis(
                            currentRelativeChild,
                            mainAxis,
                            baseMainSize,
                            availableInnerMainDim,
                            availableInnerWidth);

                        if (!YogaIsUndefined(baseMainSize) &&
                            !YogaIsUndefined(boundMainSize) &&
                            baseMainSize != boundMainSize)
                        {
                            // By excluding this item's size and flex factor from remaining, this
                            // item's min/max constraints should also trigger in the second pass
                            // resulting in the item's size calculation being identical in the
                            // first and second passes.
                            deltaFreeSpace                                += boundMainSize - childFlexBasis;
                            collectedFlexItemsValues.TotalFlexGrowFactors -= flexGrowFactor;
                        }
                    }
                }
            }

            collectedFlexItemsValues.RemainingFreeSpace -= deltaFreeSpace;
        }

        // Do two passes over the flex items to figure out how to distribute the
        // remaining space.
        //
        // The first pass finds the items whose min/max constraints trigger, freezes
        // them at those sizes, and excludes those sizes from the remaining space.
        //
        // The second pass sets the size of each flexible item. It distributes the
        // remaining space amongst the items whose min/max constraints didn't trigger in
        // the first pass. For the other items, it sets their sizes by forcing their
        // min/max constraints to trigger again.
        //
        // This two pass approach for resolving min/max constraints deviates from the
        // spec. The spec
        // (https://www.w3.org/TR/CSS-flexbox-1/#resolve-flexible-lengths) describes a
        // process that needs to be repeated a variable number of times. The algorithm
        // implemented here won't handle all cases but it was simpler to implement and
        // it mitigates performance concerns because we know exactly how many passes
        // it'll do.
        //
        // At the end of this function the child nodes would have the proper size
        // assigned to them.
        //
        public static void YGResolveFlexibleLength(
            YogaNode node,
            CollectFlexItemsRowValues collectedFlexItemsValues,
            FlexDirection mainAxis,
            FlexDirection crossAxis,
            float mainAxisownerSize,
            float availableInnerMainDim,
            float availableInnerCrossDim,
            float availableInnerWidth,
            float availableInnerHeight,
            bool flexBasisOverflows,
            MeasureMode measureModeCrossDim,
            bool performLayout,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            float originalFreeSpace = collectedFlexItemsValues.RemainingFreeSpace;
            // First pass: detect the flex items whose min/max constraints trigger
            YGDistributeFreeSpaceFirstPass(
                collectedFlexItemsValues,
                mainAxis,
                mainAxisownerSize,
                availableInnerMainDim,
                availableInnerWidth);

            // Second pass: resolve the sizes of the flexible items
            float distributedFreeSpace = YGDistributeFreeSpaceSecondPass(
                collectedFlexItemsValues,
                node,
                mainAxis,
                crossAxis,
                mainAxisownerSize,
                availableInnerMainDim,
                availableInnerCrossDim,
                availableInnerWidth,
                availableInnerHeight,
                flexBasisOverflows,
                measureModeCrossDim,
                performLayout,
                config,
                layoutMarkerData,
                layoutContext,
                depth,
                generationCount);

            collectedFlexItemsValues.RemainingFreeSpace =
                originalFreeSpace - distributedFreeSpace;
        }

        public static void YGJustifyMainAxis(
            YogaNode node,
            CollectFlexItemsRowValues collectedFlexItemsValues,
            int startOfLineIndex,
            FlexDirection mainAxis,
            FlexDirection crossAxis,
            MeasureMode measureModeMainDim,
            MeasureMode measureModeCrossDim,
            float mainAxisownerSize,
            float ownerWidth,
            float availableInnerMainDim,
            float availableInnerCrossDim,
            float availableInnerWidth,
            bool performLayout,
            object layoutContext)
        {
            var style = node.Style;
            float leadingPaddingAndBorderMain = node.GetLeadingPaddingAndBorder(mainAxis, ownerWidth);
            float trailingPaddingAndBorderMain =
                node.GetTrailingPaddingAndBorder(mainAxis, ownerWidth);
            // If we are using "at most" rules in the main axis, make sure that
            // remainingFreeSpace is 0 when min main dimension is not given
            if (measureModeMainDim == MeasureMode.AtMost &&
                collectedFlexItemsValues.RemainingFreeSpace > 0)
            {
                if (style.MinDimensions[(int)dim[(int)mainAxis]].IsValid &&
                    style.MinDimensions[(int)dim[(int)mainAxis]].Resolve(mainAxisownerSize).IsValid())
                {
                    // This condition makes sure that if the size of main dimension(after
                    // considering child nodes main dim, leading and trailing padding etc)
                    // falls below min dimension, then the remainingFreeSpace is reassigned
                    // considering the min dimension

                    // `minAvailableMainDim` denotes minimum available space in which child
                    // can be laid out, it will exclude space consumed by padding and border.
                    float minAvailableMainDim = style.MinDimensions[(int)dim[(int)mainAxis]]
                                                     .Resolve(mainAxisownerSize)
                                                     - leadingPaddingAndBorderMain - trailingPaddingAndBorderMain;
                    float occupiedSpaceByChildNodes = availableInnerMainDim - collectedFlexItemsValues.RemainingFreeSpace;
                    collectedFlexItemsValues.RemainingFreeSpace =
                        FloatMax(0, minAvailableMainDim - occupiedSpaceByChildNodes);
                }
                else
                {
                    collectedFlexItemsValues.RemainingFreeSpace = 0;
                }
            }

            int numberOfAutoMarginsOnCurrentLine = 0;
            for (var i = startOfLineIndex;
                 i < collectedFlexItemsValues.EndOfLineIndex;
                 i++)
            {
                YogaNode child = node.Children[i];
                if (child.Style.PositionType == PositionType.Relative)
                {
                    if (child.MarginLeadingValue(mainAxis).Unit == YogaUnit.Auto)
                    {
                        numberOfAutoMarginsOnCurrentLine++;
                    }

                    if (child.MarginTrailingValue(mainAxis).Unit == YogaUnit.Auto)
                    {
                        numberOfAutoMarginsOnCurrentLine++;
                    }
                }
            }

            // In order to position the elements in the main axis, we have two controls.
            // The space between the beginning and the first element and the space between
            // each two elements.
            float leadingMainDim = 0;
            float betweenMainDim = 0;
            Justify justifyContent = node.Style.JustifyContent;

            if (numberOfAutoMarginsOnCurrentLine == 0)
            {
                switch (justifyContent)
                {
                case Justify.Center:
                    leadingMainDim = collectedFlexItemsValues.RemainingFreeSpace / 2;
                    break;
                case Justify.FlexEnd:
                    leadingMainDim = collectedFlexItemsValues.RemainingFreeSpace;
                    break;
                case Justify.SpaceBetween:
                    if (collectedFlexItemsValues.ItemsOnLine > 1)
                    {
                        betweenMainDim =
                            FloatMax(collectedFlexItemsValues.RemainingFreeSpace, 0) /
                            (collectedFlexItemsValues.ItemsOnLine - 1);
                    }
                    else
                    {
                        betweenMainDim = 0;
                    }

                    break;
                case Justify.SpaceEvenly:
                    // Space is distributed evenly across all elements
                    betweenMainDim = collectedFlexItemsValues.RemainingFreeSpace /
                        (collectedFlexItemsValues.ItemsOnLine + 1);
                    leadingMainDim = betweenMainDim;
                    break;
                case Justify.SpaceAround:
                    // Space on the edges is half of the space between elements
                    betweenMainDim = collectedFlexItemsValues.RemainingFreeSpace /
                        collectedFlexItemsValues.ItemsOnLine;
                    leadingMainDim = betweenMainDim / 2;
                    break;
                case Justify.FlexStart:
                    break;
                }
            }

            collectedFlexItemsValues.MainDim =
                leadingPaddingAndBorderMain + leadingMainDim;
            collectedFlexItemsValues.CrossDim = 0;

            float maxAscentForCurrentLine = 0;
            float maxDescentForCurrentLine = 0;
            bool isNodeBaselineLayout = YGIsBaselineLayout(node);
            for (var i = startOfLineIndex;
                 i < collectedFlexItemsValues.EndOfLineIndex;
                 i++)
            {
                YogaNode child = node.Children[i];
                YogaStyle childStyle = child.Style;
                YogaLayout childLayout = child.Layout;
                if (childStyle.Display == Display.None)
                {
                    continue;
                }

                if (childStyle.PositionType == PositionType.Absolute &&
                    child.IsLeadingPositionDefined(mainAxis))
                {
                    if (performLayout)
                    {
                        // In case the child is position absolute and has left/top being
                        // defined, we override the position to whatever the user said (and
                        // margin/border).
                        child.SetLayoutPosition(
                            child.GetLeadingPosition(mainAxis, availableInnerMainDim)
                                  +
                            node.GetLeadingBorder(mainAxis) +
                            child.GetLeadingMargin(mainAxis, availableInnerWidth),
                            (int)pos[(int)mainAxis]);
                    }
                }
                else
                {
                    // Now that we placed the element, we need to update the variables.
                    // We need to do that only for relative elements. Absolute elements do not
                    // take part in that phase.
                    if (childStyle.PositionType == PositionType.Relative)
                    {
                        if (child.MarginLeadingValue(mainAxis).Unit == YogaUnit.Auto)
                        {
                            collectedFlexItemsValues.MainDim +=
                                collectedFlexItemsValues.RemainingFreeSpace /
                                numberOfAutoMarginsOnCurrentLine;
                        }

                        if (performLayout)
                        {
                            child.SetLayoutPosition(
                                childLayout.Position[(int)pos[(int)mainAxis]] +
                                collectedFlexItemsValues.MainDim,
                                (int)pos[(int)mainAxis]);
                        }

                        if (child.MarginTrailingValue(mainAxis).Unit == YogaUnit.Auto)
                        {
                            collectedFlexItemsValues.MainDim +=
                                collectedFlexItemsValues.RemainingFreeSpace /
                                numberOfAutoMarginsOnCurrentLine;
                        }

                        bool canSkipFlex =
                            !performLayout && measureModeCrossDim == MeasureMode.Exactly;
                        if (canSkipFlex)
                        {
                            // If we skipped the flex step, then we can't rely on the measuredDims
                            // because they weren't computed. This means we can't call
                            // YGNodeDimWithMargin.
                            collectedFlexItemsValues.MainDim += betweenMainDim +
                                child.GetMarginForAxis(mainAxis, availableInnerWidth) +
                                childLayout.ComputedFlexBasis;
                            collectedFlexItemsValues.CrossDim = availableInnerCrossDim;
                        }
                        else
                        {
                            // The main dimension is the sum of all the elements dimension plus
                            // the spacing.
                            collectedFlexItemsValues.MainDim += betweenMainDim +
                                YGNodeDimWithMargin(child, mainAxis, availableInnerWidth);

                            if (isNodeBaselineLayout)
                            {
                                // If the child is baseline aligned then the cross dimension is
                                // calculated by adding maxAscent and maxDescent from the baseline.
                                float ascent = YGBaseline(child, layoutContext) +
                                    child
                                       .GetLeadingMargin(
                                            FlexDirection.Column,
                                            availableInnerWidth);
                                float descent =
                                    child.Layout.MeasuredDimensions[(int)Dimension.Height] +
                                    child
                                       .GetMarginForAxis(
                                            FlexDirection.Column,
                                            availableInnerWidth) - ascent;

                                maxAscentForCurrentLine =
                                    FloatMax(maxAscentForCurrentLine, ascent);
                                maxDescentForCurrentLine =
                                    FloatMax(maxDescentForCurrentLine, descent);
                            }
                            else
                            {
                                // The cross dimension is the max of the elements dimension since
                                // there can only be one element in that cross dimension in the case
                                // when the items are not baseline aligned
                                collectedFlexItemsValues.CrossDim = FloatMax(
                                    collectedFlexItemsValues.CrossDim,
                                    YGNodeDimWithMargin(child, crossAxis, availableInnerWidth));
                            }
                        }
                    }
                    else if (performLayout)
                    {
                        child.SetLayoutPosition(
                            childLayout.Position[(int)pos[(int)mainAxis]] +
                            node.GetLeadingBorder(mainAxis) + leadingMainDim,
                            (int)pos[(int)mainAxis]);
                    }
                }
            }

            collectedFlexItemsValues.MainDim += trailingPaddingAndBorderMain;

            if (isNodeBaselineLayout)
            {
                collectedFlexItemsValues.CrossDim =
                    maxAscentForCurrentLine + maxDescentForCurrentLine;
            }
        }

        //
        // This is the main routine that implements a subset of the flexbox layout
        // algorithm described in the W3C CSS documentation:
        // https://www.w3.org/TR/CSS3-flexbox/.
        //
        // Limitations of this algorithm, compared to the full standard:
        //  * Display property is always assumed to be 'flex' except for Text nodes,
        //    which are assumed to be 'inline-flex'.
        //  * The 'zIndex' property (or any form of z ordering) is not supported. Nodes
        //    are stacked in document order.
        //  * The 'order' property is not supported. The order of flex items is always
        //    defined by document order.
        //  * The 'visibility' property is always assumed to be 'visible'. Values of
        //    'collapse' and 'hidden' are not supported.
        //  * There is no support for forced breaks.
        //  * It does not support vertical inline directions (top-to-bottom or
        //    bottom-to-top text).
        //
        // Deviations from standard:
        //  * Section 4.5 of the spec indicates that all flex items have a default
        //    minimum main size. For text blocks, for example, this is the width of the
        //    widest word. Calculating the minimum width is expensive, so we forego it
        //    and assume a default minimum main size of 0.
        //  * Min/Max sizes in the main axis are not honored when resolving flexible
        //    lengths.
        //  * The spec indicates that the default value for 'flexDirection' is 'row',
        //    but the algorithm below assumes a default of 'column'.
        //
        // Input parameters:
        //    - node: current node to be sized and laid out
        //    - availableWidth & availableHeight: available size to be used for sizing
        //      the node or YGUndefined if the size is not available; interpretation
        //      depends on layout flags
        //    - ownerDirection: the inline (text) direction within the owner
        //      (left-to-right or right-to-left)
        //    - widthMeasureMode: indicates the sizing rules for the width (see below
        //      for explanation)
        //    - heightMeasureMode: indicates the sizing rules for the height (see below
        //      for explanation)
        //    - performLayout: specifies whether the caller is interested in just the
        //      dimensions of the node or it requires the entire node and its subtree to
        //      be laid out (with final positions)
        //
        // Details:
        //    This routine is called recursively to lay out subtrees of flexbox
        //    elements. It uses the information in node.style, which is treated as a
        //    read-only input. It is responsible for setting the layout.direction and
        //    layout.measuredDimensions fields for the input node as well as the
        //    layout.position and layout.lineIndex fields for its child nodes. The
        //    layout.measuredDimensions field includes any border or padding for the
        //    node but does not include margins.
        //
        //    The spec describes four different layout modes: "fill available", "max
        //    content", "min content", and "fit content". Of these, we don't use "min
        //    content" because we don't support default minimum main sizes (see above
        //    for details). Each of our measure modes maps to a layout mode from the
        //    spec (https://www.w3.org/TR/CSS3-sizing/#terms):
        //      - MeasureMode.Undefined: max content
        //      - MeasureMode.Exactly: fill available
        //      - MeasureMode.AtMost: fit content
        //
        //    When calling YGNodelayoutImpl and YGLayoutNodeInternal, if the caller
        //    passes an available size of undefined then it must also pass a measure
        //    mode of MeasureMode.Undefined in that dimension.
        //
        public static void YGNodelayoutImpl(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            Direction ownerDirection,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight,
            bool performLayout,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount,
            LayoutPassReason reason)
        {
            YGAssertWithNode(
                node,
                YogaIsUndefined(availableWidth)
                    ? widthMeasureMode == MeasureMode.Undefined
                    : true,
                "availableWidth is indefinite so widthMeasureMode must be MeasureMode.Undefined");
            YGAssertWithNode(
                node,
                YogaIsUndefined(availableHeight)
                    ? heightMeasureMode == MeasureMode.Undefined
                    : true,
                "availableHeight is indefinite so heightMeasureMode must be MeasureMode.Undefined");

            if (performLayout)
                layoutMarkerData.Layouts++;
            else
                layoutMarkerData.Measures++;

            // Set the resolved resolution in the node's layout.
            Direction direction = node.ResolveDirection(ownerDirection);
            node.SetLayoutDirection(direction);

            FlexDirection flexRowDirection = FlexDirection.Row.Resolve(direction);
            FlexDirection flexColumnDirection = FlexDirection.Column.Resolve(direction);

            Edge startEdge =
                direction == Direction.LTR ? Edge.Left : Edge.Right;
            Edge endEdge = direction == Direction.LTR ? Edge.Right : Edge.Left;
            node.SetLayoutMargin(
                node.GetLeadingMargin(flexRowDirection, ownerWidth),
                startEdge);
            node.SetLayoutMargin(
                node.GetTrailingMargin(flexRowDirection, ownerWidth),
                endEdge);
            node.SetLayoutMargin(
                node.GetLeadingMargin(flexColumnDirection, ownerWidth),
                Edge.Top);
            node.SetLayoutMargin(
                node.GetTrailingMargin(flexColumnDirection, ownerWidth),
                Edge.Bottom);

            node.SetLayoutBorder(node.GetLeadingBorder(flexRowDirection), startEdge);
            node.SetLayoutBorder(node.GetTrailingBorder(flexRowDirection), endEdge);
            node.SetLayoutBorder(node.GetLeadingBorder(flexColumnDirection), Edge.Top);
            node.SetLayoutBorder(
                node.GetTrailingBorder(flexColumnDirection),
                Edge.Bottom);

            node.SetLayoutPadding(
                node.GetLeadingPadding(flexRowDirection, ownerWidth),
                startEdge);
            node.SetLayoutPadding(
                node.GetTrailingPadding(flexRowDirection, ownerWidth),
                endEdge);
            node.SetLayoutPadding(
                node.GetLeadingPadding(flexColumnDirection, ownerWidth),
                Edge.Top);
            node.SetLayoutPadding(
                node.GetTrailingPadding(flexColumnDirection, ownerWidth),
                Edge.Bottom);

            if (node.MeasureFunc != null)
            {
                YGNodeWithMeasureFuncSetMeasuredDimensions(
                    node,
                    availableWidth,
                    availableHeight,
                    widthMeasureMode,
                    heightMeasureMode,
                    ownerWidth,
                    ownerHeight,
                    layoutMarkerData,
                    layoutContext,
                    reason);
                return;
            }

            int childCount = YGNodeGetChildCount(node);
            if (childCount == 0)
            {
                YGNodeEmptyContainerSetMeasuredDimensions(
                    node,
                    availableWidth,
                    availableHeight,
                    widthMeasureMode,
                    heightMeasureMode,
                    ownerWidth,
                    ownerHeight);
                return;
            }

            // If we're not being asked to perform a full layout we can skip the algorithm
            // if we already know the size
            if (!performLayout &&
                YGNodeFixedSizeSetMeasuredDimensions(
                    node,
                    availableWidth,
                    availableHeight,
                    widthMeasureMode,
                    heightMeasureMode,
                    ownerWidth,
                    ownerHeight))
            {
                return;
            }

            // At this point we know we're going to perform work. Ensure that each child
            // has a mutable copy.
            node.CloneChildrenIfNeeded(layoutContext);
            // Reset layout flags, as they could have changed.
            node.SetLayoutHadOverflow(false);

            // STEP 1: CALCULATE VALUES FOR REMAINDER OF ALGORITHM
            FlexDirection mainAxis = node.Style.FlexDirection.Resolve(direction);
            FlexDirection crossAxis = mainAxis.CrossAxis(direction);
            bool isMainAxisRow = mainAxis.IsRow();
            bool isNodeFlexWrap = node.Style.FlexWrap != Wrap.NoWrap;

            float mainAxisownerSize = isMainAxisRow ? ownerWidth : ownerHeight;
            float crossAxisownerSize = isMainAxisRow ? ownerHeight : ownerWidth;

            float leadingPaddingAndBorderCross =
                node.GetLeadingPaddingAndBorder(crossAxis, ownerWidth);
            float paddingAndBorderAxisMain =
                YGNodePaddingAndBorderForAxis(node, mainAxis, ownerWidth);
            float paddingAndBorderAxisCross =
                YGNodePaddingAndBorderForAxis(node, crossAxis, ownerWidth);

            MeasureMode measureModeMainDim =
                isMainAxisRow ? widthMeasureMode : heightMeasureMode;
            MeasureMode measureModeCrossDim =
                isMainAxisRow ? heightMeasureMode : widthMeasureMode;

            float paddingAndBorderAxisRow =
                isMainAxisRow ? paddingAndBorderAxisMain : paddingAndBorderAxisCross;
            float paddingAndBorderAxisColumn =
                isMainAxisRow ? paddingAndBorderAxisCross : paddingAndBorderAxisMain;

            float marginAxisRow =
                node.GetMarginForAxis(FlexDirection.Row, ownerWidth);
            float marginAxisColumn =
                node.GetMarginForAxis(FlexDirection.Column, ownerWidth);

            var minDimensions = node.Style.MinDimensions;
            var maxDimensions = node.Style.MaxDimensions;
            float minInnerWidth = minDimensions[(int)Dimension.Width].Resolve(ownerWidth) - paddingAndBorderAxisRow;
            float maxInnerWidth = maxDimensions[(int)Dimension.Width].Resolve(ownerWidth) - paddingAndBorderAxisRow;
            float minInnerHeight = minDimensions[(int)Dimension.Height].Resolve(ownerHeight) - paddingAndBorderAxisColumn;
            float maxInnerHeight = maxDimensions[(int)Dimension.Height].Resolve(ownerHeight) - paddingAndBorderAxisColumn;

            float minInnerMainDim = isMainAxisRow ? minInnerWidth : minInnerHeight;
            float maxInnerMainDim = isMainAxisRow ? maxInnerWidth : maxInnerHeight;

            // STEP 2: DETERMINE AVAILABLE SIZE IN MAIN AND CROSS DIRECTIONS

            float availableInnerWidth = YGNodeCalculateAvailableInnerDim(
                node,
                FlexDirection.Row,
                availableWidth,
                ownerWidth);
            float availableInnerHeight = YGNodeCalculateAvailableInnerDim(
                node,
                FlexDirection.Column,
                availableHeight,
                ownerHeight);

            float availableInnerMainDim =
                isMainAxisRow ? availableInnerWidth : availableInnerHeight;
            float availableInnerCrossDim =
                isMainAxisRow ? availableInnerHeight : availableInnerWidth;

            // STEP 3: DETERMINE FLEX BASIS FOR EACH ITEM

            float totalOuterFlexBasis = YGNodeComputeFlexBasisForChildren(
                node,
                availableInnerWidth,
                availableInnerHeight,
                widthMeasureMode,
                heightMeasureMode,
                direction,
                mainAxis,
                config,
                performLayout,
                layoutMarkerData,
                layoutContext,
                depth,
                generationCount);

            bool flexBasisOverflows = measureModeMainDim == MeasureMode.Undefined
                ? false
                : totalOuterFlexBasis > availableInnerMainDim;
            if (isNodeFlexWrap && flexBasisOverflows &&
                measureModeMainDim == MeasureMode.AtMost)
            {
                measureModeMainDim = MeasureMode.Exactly;
            }
            // STEP 4: COLLECT FLEX ITEMS INTO FLEX LINES

            // Indexes of children that represent the first and last items in the line.
            int startOfLineIndex = 0;
            int endOfLineIndex = 0;

            // Number of lines.
            int lineCount = 0;

            // Accumulated cross dimensions of all lines so far.
            float totalLineCrossDim = 0;

            // Max main dimension of all the lines.
            float maxLineMainDim = 0;
            CollectFlexItemsRowValues collectedFlexItemsValues;
            for (;
                endOfLineIndex < childCount;
                lineCount++, startOfLineIndex = endOfLineIndex)
            {
                collectedFlexItemsValues = YGCalculateCollectFlexItemsRowValues(
                    node,
                    ownerDirection,
                    mainAxisownerSize,
                    availableInnerWidth,
                    availableInnerMainDim,
                    startOfLineIndex,
                    lineCount);
                endOfLineIndex = collectedFlexItemsValues.EndOfLineIndex;

                // If we don't need to measure the cross axis, we can skip the entire flex
                // step.
                bool canSkipFlex =
                    !performLayout && measureModeCrossDim == MeasureMode.Exactly;

                // STEP 5: RESOLVING FLEXIBLE LENGTHS ON MAIN AXIS
                // Calculate the remaining available space that needs to be allocated. If
                // the main dimension size isn't known, it is computed based on the line
                // length, so there's no more space left to distribute.

                bool sizeBasedOnContent = false;
                // If we don't measure with exact main dimension we want to ensure we don't
                // violate min and max
                if (measureModeMainDim != MeasureMode.Exactly)
                {
                    if (!YogaIsUndefined(minInnerMainDim) &&
                        collectedFlexItemsValues.SizeConsumedOnCurrentLine <
                        minInnerMainDim)
                    {
                        availableInnerMainDim = minInnerMainDim;
                    }
                    else if (
                        !YogaIsUndefined(maxInnerMainDim) &&
                        collectedFlexItemsValues.SizeConsumedOnCurrentLine >
                        maxInnerMainDim)
                    {
                        availableInnerMainDim = maxInnerMainDim;
                    }
                    else
                    {
                        if (((YogaIsUndefined(collectedFlexItemsValues.TotalFlexGrowFactors) && collectedFlexItemsValues.TotalFlexGrowFactors == 0) ||
                            (YogaIsUndefined(node.ResolveFlexGrow()) && node.ResolveFlexGrow() == 0)))
                        {
                            // If we don't have any children to flex or we can't flex the node
                            // itself, space we've used is all space we need. Root node also
                            // should be shrunk to minimum
                            availableInnerMainDim =
                                collectedFlexItemsValues.SizeConsumedOnCurrentLine;
                        }

                        sizeBasedOnContent = true;
                    }
                }

                if (!sizeBasedOnContent && !YogaIsUndefined(availableInnerMainDim))
                {
                    collectedFlexItemsValues.RemainingFreeSpace = availableInnerMainDim -
                        collectedFlexItemsValues.SizeConsumedOnCurrentLine;
                }
                else if (collectedFlexItemsValues.SizeConsumedOnCurrentLine < 0)
                {
                    // availableInnerMainDim is indefinite which means the node is being sized
                    // based on its content. sizeConsumedOnCurrentLine is negative which means
                    // the node will allocate 0 points for its content. Consequently,
                    // remainingFreeSpace is 0 - sizeConsumedOnCurrentLine.
                    collectedFlexItemsValues.RemainingFreeSpace =
                        -collectedFlexItemsValues.SizeConsumedOnCurrentLine;
                }

                if (!canSkipFlex)
                {
                    YGResolveFlexibleLength(
                        node,
                        collectedFlexItemsValues,
                        mainAxis,
                        crossAxis,
                        mainAxisownerSize,
                        availableInnerMainDim,
                        availableInnerCrossDim,
                        availableInnerWidth,
                        availableInnerHeight,
                        flexBasisOverflows,
                        measureModeCrossDim,
                        performLayout,
                        config,
                        layoutMarkerData,
                        layoutContext,
                        depth,
                        generationCount);
                }

                node.SetLayoutHadOverflow(
                    node.Layout.HadOverflow | (collectedFlexItemsValues.RemainingFreeSpace < 0));

                // STEP 6: MAIN-AXIS JUSTIFICATION & CROSS-AXIS SIZE DETERMINATION

                // At this point, all the children have their dimensions set in the main
                // axis. Their dimensions are also set in the cross axis with the exception
                // of items that are aligned "stretch". We need to compute these stretch
                // values and set the final positions.

                YGJustifyMainAxis(
                    node,
                    collectedFlexItemsValues,
                    startOfLineIndex,
                    mainAxis,
                    crossAxis,
                    measureModeMainDim,
                    measureModeCrossDim,
                    mainAxisownerSize,
                    ownerWidth,
                    availableInnerMainDim,
                    availableInnerCrossDim,
                    availableInnerWidth,
                    performLayout,
                    layoutContext);

                float containerCrossAxis = availableInnerCrossDim;
                if (measureModeCrossDim == MeasureMode.Undefined ||
                    measureModeCrossDim == MeasureMode.AtMost)
                {
                    // Compute the cross axis from the max cross dimension of the children.
                    containerCrossAxis =
                        YGNodeBoundAxis(
                            node,
                            crossAxis,
                            collectedFlexItemsValues.CrossDim + paddingAndBorderAxisCross,
                            crossAxisownerSize,
                            ownerWidth) -
                        paddingAndBorderAxisCross;
                }

                // If there's no flex wrap, the cross dimension is defined by the container.
                if (!isNodeFlexWrap && measureModeCrossDim == MeasureMode.Exactly)
                {
                    collectedFlexItemsValues.CrossDim = availableInnerCrossDim;
                }

                // Clamp to the min/max size specified on the container.
                collectedFlexItemsValues.CrossDim =
                    YGNodeBoundAxis(
                        node,
                        crossAxis,
                        collectedFlexItemsValues.CrossDim + paddingAndBorderAxisCross,
                        crossAxisownerSize,
                        ownerWidth) -
                    paddingAndBorderAxisCross;

                // STEP 7: CROSS-AXIS ALIGNMENT
                // We can skip child alignment if we're just measuring the container.
                if (performLayout)
                {
                    for (var i = startOfLineIndex; i < endOfLineIndex; i++)
                    {
                        YogaNode child = node.Children[i];
                        if (child.Style.Display == Display.None)
                        {
                            continue;
                        }

                        if (child.Style.PositionType == PositionType.Absolute)
                        {
                            // If the child is absolutely positioned and has a
                            // top/left/bottom/right set, override all the previously computed
                            // positions to set it correctly.
                            bool isChildLeadingPosDefined =
                                child.IsLeadingPositionDefined(crossAxis);
                            if (isChildLeadingPosDefined)
                            {
                                child.SetLayoutPosition(
                                    child.GetLeadingPosition(crossAxis, availableInnerCrossDim) +
                                    node.GetLeadingBorder(crossAxis) +
                                    child.GetLeadingMargin(crossAxis, availableInnerWidth),
                                    (int)pos[(int)crossAxis]);
                            }

                            // If leading position is not defined or calculations result in Nan,
                            // default to border + margin
                            if (!isChildLeadingPosDefined ||
                                YogaIsUndefined(child.Layout.Position[(int)pos[(int)crossAxis]]))
                            {
                                child.SetLayoutPosition(
                                    node.GetLeadingBorder(crossAxis) +
                                    child.GetLeadingMargin(crossAxis, availableInnerWidth),
                                    (int)pos[(int)crossAxis]);
                            }
                        }
                        else
                        {
                            float leadingCrossDim = leadingPaddingAndBorderCross;

                            // For a relative children, we're either using alignItems (owner) or
                            // alignSelf (child) in order to determine the position in the cross
                            // axis
                            YogaAlign alignItem = YGNodeAlignItem(node, child);

                            // If the child uses align stretch, we need to lay it out one more
                            // time, this time forcing the cross-axis size to be the computed
                            // cross size for the current line.
                            if (alignItem == YogaAlign.Stretch &&
                                child.MarginLeadingValue(crossAxis).Unit != YogaUnit.Auto &&
                                child.MarginTrailingValue(crossAxis).Unit != YogaUnit.Auto)
                            {
                                // If the child defines a definite size for its cross axis, there's
                                // no need to stretch.
                                if (!YGNodeIsStyleDimDefined(
                                    child,
                                    crossAxis,
                                    availableInnerCrossDim))
                                {
                                    float childMainSize =
                                        child.Layout.MeasuredDimensions[(int)dim[(int)mainAxis]];
                                    var childStyle = child.Style;
                                    float childCrossSize = childStyle.AspectRatio.IsValid()
                                        ? child.GetMarginForAxis(crossAxis, availableInnerWidth)
                                                +
                                        (isMainAxisRow
                                            ? childMainSize / childStyle.AspectRatio
                                            : childMainSize * childStyle.AspectRatio)
                                        : collectedFlexItemsValues.CrossDim;

                                    childMainSize +=
                                        child.GetMarginForAxis(mainAxis, availableInnerWidth);

                                    MeasureMode childMainMeasureMode = MeasureMode.Exactly;
                                    MeasureMode childCrossMeasureMode = MeasureMode.Exactly;
                                    YGConstrainMaxSizeForMode(
                                        child,
                                        mainAxis,
                                        availableInnerMainDim,
                                        availableInnerWidth,
                                        ref childMainMeasureMode,
                                        ref childMainSize);
                                    YGConstrainMaxSizeForMode(
                                        child,
                                        crossAxis,
                                        availableInnerCrossDim,
                                        availableInnerWidth,
                                        ref childCrossMeasureMode,
                                        ref childCrossSize);

                                    float childWidth =
                                        isMainAxisRow ? childMainSize : childCrossSize;
                                    float childHeight =
                                        !isMainAxisRow ? childMainSize : childCrossSize;

                                    var alignContent = node.Style.AlignContent;
                                    var crossAxisDoesNotGrow =
                                        alignContent != YogaAlign.Stretch && isNodeFlexWrap;
                                    MeasureMode childWidthMeasureMode =
                                        YogaIsUndefined(childWidth) ||
                                        (!isMainAxisRow && crossAxisDoesNotGrow)
                                            ? MeasureMode.Undefined
                                            : MeasureMode.Exactly;
                                    MeasureMode childHeightMeasureMode =
                                        YogaIsUndefined(childHeight) ||
                                        (isMainAxisRow && crossAxisDoesNotGrow)
                                            ? MeasureMode.Undefined
                                            : MeasureMode.Exactly;

                                    YGLayoutNodeInternal(
                                        child,
                                        childWidth,
                                        childHeight,
                                        direction,
                                        childWidthMeasureMode,
                                        childHeightMeasureMode,
                                        availableInnerWidth,
                                        availableInnerHeight,
                                        true,
                                        LayoutPassReason.Stretch,
                                        config,
                                        layoutMarkerData,
                                        layoutContext,
                                        depth,
                                        generationCount);
                                }
                            }
                            else
                            {
                                float remainingCrossDim = containerCrossAxis -
                                    YGNodeDimWithMargin(child, crossAxis, availableInnerWidth);

                                if (child.MarginLeadingValue(crossAxis).Unit == YogaUnit.Auto &&
                                    child.MarginTrailingValue(crossAxis).Unit == YogaUnit.Auto)
                                {
                                    leadingCrossDim += FloatMax(0.0f, remainingCrossDim / 2);
                                }
                                else if (
                                    child.MarginTrailingValue(crossAxis).Unit == YogaUnit.Auto)
                                {
                                    // No-Op
                                }
                                else if (
                                    child.MarginLeadingValue(crossAxis).Unit == YogaUnit.Auto)
                                {
                                    leadingCrossDim += FloatMax(0.0f, remainingCrossDim);
                                }
                                else if (alignItem == YogaAlign.FlexStart)
                                {
                                    // No-Op
                                }
                                else if (alignItem == YogaAlign.Center)
                                {
                                    leadingCrossDim += remainingCrossDim / 2;
                                }
                                else
                                {
                                    leadingCrossDim += remainingCrossDim;
                                }
                            }

                            // And we apply the position
                            child.SetLayoutPosition(
                                child.Layout.Position[(int)pos[(int)crossAxis]] + totalLineCrossDim +
                                leadingCrossDim,
                                (int)pos[(int)crossAxis]);
                        }
                    }
                }

                totalLineCrossDim += collectedFlexItemsValues.CrossDim;
                maxLineMainDim =
                    FloatMax(maxLineMainDim, collectedFlexItemsValues.MainDim);
            }

            // STEP 8: MULTI-LINE CONTENT ALIGNMENT
            // currentLead stores the size of the cross dim
            if (performLayout && (isNodeFlexWrap || YGIsBaselineLayout(node)))
            {
                float crossDimLead = 0;
                float currentLead = leadingPaddingAndBorderCross;
                if (!YogaIsUndefined(availableInnerCrossDim))
                {
                    float remainingAlignContentDim =
                        availableInnerCrossDim - totalLineCrossDim;
                    switch (node.Style.AlignContent)
                    {
                    case YogaAlign.FlexEnd:
                        currentLead += remainingAlignContentDim;
                        break;
                    case YogaAlign.Center:
                        currentLead += remainingAlignContentDim / 2;
                        break;
                    case YogaAlign.Stretch:
                        if (availableInnerCrossDim > totalLineCrossDim)
                        {
                            crossDimLead = remainingAlignContentDim / lineCount;
                        }

                        break;
                    case YogaAlign.SpaceAround:
                        if (availableInnerCrossDim > totalLineCrossDim)
                        {
                            currentLead += remainingAlignContentDim / (2 * lineCount);
                            if (lineCount > 1)
                            {
                                crossDimLead = remainingAlignContentDim / lineCount;
                            }
                        }
                        else
                        {
                            currentLead += remainingAlignContentDim / 2;
                        }

                        break;
                    case YogaAlign.SpaceBetween:
                        if (availableInnerCrossDim > totalLineCrossDim && lineCount > 1)
                        {
                            crossDimLead = remainingAlignContentDim / (lineCount - 1);
                        }

                        break;
                    case YogaAlign.Auto:
                    case YogaAlign.FlexStart:
                    case YogaAlign.Baseline:
                        break;
                    }
                }

                int endIndex = 0;
                for (var i = 0; i < lineCount; i++)
                {
                    int startIndex = endIndex;
                    int ii;

                    // compute the line's height and find the endIndex
                    float lineHeight = 0;
                    float maxAscentForCurrentLine = 0;
                    float maxDescentForCurrentLine = 0;
                    for (ii = startIndex; ii < childCount; ii++)
                    {
                        YogaNode child = node.Children[ii];
                        if (child.Style.Display == Display.None)
                        {
                            continue;
                        }

                        if (child.Style.PositionType == PositionType.Relative)
                        {
                            if (child.LineIndex != i)
                            {
                                break;
                            }

                            if (YGNodeIsLayoutDimDefined(child, crossAxis))
                            {
                                lineHeight = FloatMax(
                                    lineHeight,
                                    child.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]] +
                                    child.GetMarginForAxis(crossAxis, availableInnerWidth));
                            }

                            if (YGNodeAlignItem(node, child) == YogaAlign.Baseline)
                            {
                                float ascent = YGBaseline(child, layoutContext) +
                                    child
                                       .GetLeadingMargin(
                                            FlexDirection.Column,
                                            availableInnerWidth);
                                float descent =
                                    child.Layout.MeasuredDimensions[(int)Dimension.Height] +
                                    child
                                       .GetMarginForAxis(
                                            FlexDirection.Column,
                                            availableInnerWidth)
                                        - ascent;
                                maxAscentForCurrentLine =
                                    FloatMax(maxAscentForCurrentLine, ascent);
                                maxDescentForCurrentLine =
                                    FloatMax(maxDescentForCurrentLine, descent);
                                lineHeight = FloatMax(
                                    lineHeight,
                                    maxAscentForCurrentLine + maxDescentForCurrentLine);
                            }
                        }
                    }

                    endIndex   =  ii;
                    lineHeight += crossDimLead;

                    if (performLayout)
                    {
                        for (ii = startIndex; ii < endIndex; ii++)
                        {
                            YogaNode child = node.Children[ii];
                            if (child.Style.Display == Display.None)
                            {
                                continue;
                            }

                            if (child.Style.PositionType == PositionType.Relative)
                            {
                                switch (YGNodeAlignItem(node, child))
                                {
                                case YogaAlign.FlexStart:
                                {
                                    child.SetLayoutPosition(
                                        currentLead +
                                        child.GetLeadingMargin(crossAxis, availableInnerWidth),
                                        (int)pos[(int)crossAxis]);
                                    break;
                                }
                                case YogaAlign.FlexEnd:
                                {
                                    child.SetLayoutPosition(
                                        currentLead + lineHeight -
                                        child.GetTrailingMargin(crossAxis, availableInnerWidth)
                                              -
                                        child.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]],
                                        (int)pos[(int)crossAxis]);
                                    break;
                                }
                                case YogaAlign.Center:
                                {
                                    float childHeight =
                                        child.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]];

                                    child.SetLayoutPosition(
                                        currentLead + (lineHeight - childHeight) / 2,
                                        (int)pos[(int)crossAxis]);
                                    break;
                                }
                                case YogaAlign.Stretch:
                                {
                                    child.SetLayoutPosition(
                                        currentLead +
                                        child.GetLeadingMargin(crossAxis, availableInnerWidth),
                                        (int)pos[(int)crossAxis]);

                                    // Remeasure child with the line height as it as been only
                                    // measured with the owners height yet.
                                    if (!YGNodeIsStyleDimDefined(
                                        child,
                                        crossAxis,
                                        availableInnerCrossDim))
                                    {
                                        float childWidth = isMainAxisRow
                                            ? (child.Layout
                                                    .MeasuredDimensions[(int)Dimension.Width] +
                                                child.GetMarginForAxis(mainAxis, availableInnerWidth))
                                            : lineHeight;

                                        float childHeight = !isMainAxisRow
                                            ? (child.Layout
                                                    .MeasuredDimensions[(int)Dimension.Height] +
                                                child.GetMarginForAxis(crossAxis, availableInnerWidth)
                                                     )
                                            : lineHeight;

                                        if (!(FloatsEqual(
                                                childWidth,
                                                child.Layout
                                                     .MeasuredDimensions[(int)Dimension.Width]) &&
                                            FloatsEqual(
                                                childHeight,
                                                child.Layout
                                                     .MeasuredDimensions[(int)Dimension.Height])))
                                        {
                                            YGLayoutNodeInternal(
                                                child,
                                                childWidth,
                                                childHeight,
                                                direction,
                                                MeasureMode.Exactly,
                                                MeasureMode.Exactly,
                                                availableInnerWidth,
                                                availableInnerHeight,
                                                true,
                                                LayoutPassReason.MultilineStretch,
                                                config,
                                                layoutMarkerData,
                                                layoutContext,
                                                depth,
                                                generationCount);
                                        }
                                    }

                                    break;
                                }
                                case YogaAlign.Baseline:
                                {
                                    child.SetLayoutPosition(
                                        currentLead + maxAscentForCurrentLine -
                                        YGBaseline(child, layoutContext) +
                                        child
                                           .GetLeadingPosition(
                                                FlexDirection.Column,
                                                availableInnerCrossDim),
                                        (int)Edge.Top);

                                    break;
                                }
                                case YogaAlign.Auto:
                                case YogaAlign.SpaceBetween:
                                case YogaAlign.SpaceAround:
                                    break;
                                }
                            }
                        }
                    }

                    currentLead += lineHeight;
                }
            }

            // STEP 9: COMPUTING FINAL DIMENSIONS

            node.SetLayoutMeasuredDimension(
                YGNodeBoundAxis(
                    node,
                    FlexDirection.Row,
                    availableWidth - marginAxisRow,
                    ownerWidth,
                    ownerWidth),
                (int)Dimension.Width);

            node.SetLayoutMeasuredDimension(
                YGNodeBoundAxis(
                    node,
                    FlexDirection.Column,
                    availableHeight - marginAxisColumn,
                    ownerHeight,
                    ownerWidth),
                (int)Dimension.Height);

            // If the user didn't specify a width or height for the node, set the
            // dimensions based on the children.
            if (measureModeMainDim == MeasureMode.Undefined ||
                (node.Style.Overflow != Overflow.Scroll &&
                    measureModeMainDim == MeasureMode.AtMost))
            {
                // Clamp the size to the min/max size, if specified, and make sure it
                // doesn't go below the padding and border amount.
                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        mainAxis,
                        maxLineMainDim,
                        mainAxisownerSize,
                        ownerWidth),
                    (int)dim[(int)mainAxis]);
            }
            else if (
                measureModeMainDim == MeasureMode.AtMost &&
                node.Style.Overflow == Overflow.Scroll)
            {
                node.SetLayoutMeasuredDimension(
                    FloatMax(
                        FloatMin(
                            availableInnerMainDim + paddingAndBorderAxisMain,
                            YGNodeBoundAxisWithinMinAndMax(
                                    node,
                                    mainAxis,
                                    maxLineMainDim,
                                    mainAxisownerSize)
                               ),
                        paddingAndBorderAxisMain),
                    (int)dim[(int)mainAxis]);
            }

            if (measureModeCrossDim == MeasureMode.Undefined ||
                (node.Style.Overflow != Overflow.Scroll &&
                    measureModeCrossDim == MeasureMode.AtMost))
            {
                // Clamp the size to the min/max size, if specified, and make sure it
                // doesn't go below the padding and border amount.
                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        crossAxis,
                        totalLineCrossDim + paddingAndBorderAxisCross,
                        crossAxisownerSize,
                        ownerWidth),
                    (int)dim[(int)crossAxis]);
            }
            else if (
                measureModeCrossDim == MeasureMode.AtMost &&
                node.Style.Overflow == Overflow.Scroll)
            {
                node.SetLayoutMeasuredDimension(
                    FloatMax(
                        FloatMin(
                            availableInnerCrossDim + paddingAndBorderAxisCross,
                            YGNodeBoundAxisWithinMinAndMax(
                                    node,
                                    crossAxis,
                                    (totalLineCrossDim + paddingAndBorderAxisCross),
                                    crossAxisownerSize)
                               ),
                        paddingAndBorderAxisCross),
                    (int)dim[(int)crossAxis]);
            }

            // As we only wrapped in normal direction yet, we need to reverse the
            // positions on wrap-reverse.
            if (performLayout && node.Style.FlexWrap == Wrap.WrapReverse)
            {
                for (var i = 0; i < childCount; i++)
                {
                    YogaNode child = node.Children[i];
                    if (child.Style.PositionType == PositionType.Relative)
                    {
                        child.SetLayoutPosition(
                            node.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]] -
                            child.Layout.Position[(int)pos[(int)crossAxis]] -
                            child.Layout.MeasuredDimensions[(int)dim[(int)crossAxis]],
                            (int)pos[(int)crossAxis]);
                    }
                }
            }

            if (performLayout)
            {
                // STEP 10: SIZING AND POSITIONING ABSOLUTE CHILDREN
                foreach (var child in node.Children)
                {
                    if (child.Style.PositionType != PositionType.Absolute)
                    {
                        continue;
                    }

                    YGNodeAbsoluteLayoutChild(
                        node,
                        child,
                        availableInnerWidth,
                        isMainAxisRow ? measureModeMainDim : measureModeCrossDim,
                        availableInnerHeight,
                        direction,
                        config,
                        layoutMarkerData,
                        layoutContext,
                        depth,
                        generationCount);
                }

                // STEP 11: SETTING TRAILING POSITIONS FOR CHILDREN
                bool needsMainTrailingPos = mainAxis == FlexDirection.RowReverse ||
                    mainAxis == FlexDirection.ColumnReverse;
                bool needsCrossTrailingPos = crossAxis == FlexDirection.RowReverse ||
                    crossAxis == FlexDirection.ColumnReverse;

                // Set trailing position if necessary.
                if (needsMainTrailingPos || needsCrossTrailingPos)
                {
                    for (int i = 0; i < childCount; i++)
                    {
                        YogaNode child = node.Children[i];
                        if (child.Style.Display == Display.None)
                        {
                            continue;
                        }

                        if (needsMainTrailingPos)
                        {
                            YGNodeSetChildTrailingPosition(node, child, mainAxis);
                        }

                        if (needsCrossTrailingPos)
                        {
                            YGNodeSetChildTrailingPosition(node, child, crossAxis);
                        }
                    }
                }
            }
        }

#if DEBUG
        public static bool gPrintChanges = false;
        public static bool gPrintSkips = false;
#else
        public static bool gPrintChanges = false;
        public static bool gPrintSkips = false;
#endif

        public static string spacer = "                                                            ";

        public static string YGSpacer(int level)
        {
            var spacerLen = spacer.Length;
            if (level > spacerLen)
                return spacer;
            return spacer.Substring(spacerLen - level);
        }

        public static string YGMeasureModeName(
            MeasureMode mode,
            bool performLayout)
        {
            var kMeasureModeNames = new Dictionary<MeasureMode, string>
            {
                {MeasureMode.Undefined, "UNDEFINED"},
                {MeasureMode.Exactly, "EXACTLY"},
                {MeasureMode.AtMost, "AT_MOST"}
            };
            var kLayoutModeNames = new Dictionary<MeasureMode, string>
            {
                {MeasureMode.Undefined, "LAY_UNDEFINED"},
                {MeasureMode.Exactly, "LAY_EXACTLY"},
                {MeasureMode.AtMost, "LAY_AT_MOST"}
            };

            if (mode >= MeasureMode.AtMost)
                return "";

            return performLayout ? kLayoutModeNames[mode] : kMeasureModeNames[mode];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGMeasureModeSizeIsExactAndMatchesOldMeasuredSize(
            MeasureMode sizeMode,
            float size,
            float lastComputedSize)
        {
            return sizeMode == MeasureMode.Exactly &&
                FloatsEqual(size, lastComputedSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGMeasureModeOldSizeIsUnspecifiedAndStillFits(
            MeasureMode sizeMode,
            float size,
            MeasureMode lastSizeMode,
            float lastComputedSize)
        {
            return sizeMode == MeasureMode.AtMost &&
                lastSizeMode == MeasureMode.Undefined &&
                (size >= lastComputedSize || FloatsEqual(size, lastComputedSize));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGMeasureModeNewMeasureSizeIsStricterAndStillValid(
            MeasureMode sizeMode,
            float size,
            MeasureMode lastSizeMode,
            float lastSize,
            float lastComputedSize)
        {
            return lastSizeMode == MeasureMode.AtMost &&
                sizeMode == MeasureMode.AtMost && !YogaIsUndefined(lastSize) &&
                !YogaIsUndefined(size) && !YogaIsUndefined(lastComputedSize) &&
                lastSize > size &&
                (lastComputedSize <= size || FloatsEqual(size, lastComputedSize));
        }

        public static float YGRoundValueToPixelGrid(
            float value,
            float pointScaleFactor,
            bool forceCeil,
            bool forceFloor)
        {
            float scaledValue = value * pointScaleFactor;
            // We want to calculate `fractial` such that `floor(scaledValue) = scaledValue
            // - fractial`.
            //float f = 0.0000019f;
            float fractial = FloatMod(scaledValue, 1.0f);
            if (fractial < 0)
            {
                // This branch is for handling negative numbers for `value`.
                //
                // Regarding `floor` and `ceil`. Note that for a number x, `floor(x) <= x <=
                // ceil(x)` even for negative numbers. Here are a couple of examples:
                //   - x =  2.2: floor( 2.2) =  2, ceil( 2.2) =  3
                //   - x = -2.2: floor(-2.2) = -3, ceil(-2.2) = -2
                //
                // Regarding `fmodf`. For fractional negative numbers, `fmodf` returns a
                // negative number. For example, `fmodf(-2.2) = -0.2`. However, we want
                // `fractial` to be the number such that subtracting it from `value` will
                // give us `floor(value)`. In the case of negative numbers, adding 1 to
                // `fmodf(value)` gives us this. Let's continue the example from above:
                //   - fractial = fmodf(-2.2) = -0.2
                //   - Add 1 to the fraction: fractial2 = fractial + 1 = -0.2 + 1 = 0.8
                //   - Finding the `floor`: -2.2 - fractial2 = -2.2 - 0.8 = -3
                ++fractial;
            }

            if (FloatsEqual(fractial, 0))
            {
                // First we check if the value is already rounded
                scaledValue = scaledValue - fractial;
            }
            else if (FloatsEqual(fractial, 1.0f))
            {
                scaledValue = scaledValue - fractial + 1.0f;
            }
            else if (forceCeil)
            {
                var d = Math.Ceiling(scaledValue);
                // Next we check if we need to use forced rounding
                scaledValue = scaledValue - fractial + 1.0f;
            }
            else if (forceFloor)
            {
                scaledValue = scaledValue - fractial;
            }
            else
            {
                // Finally we just round the value
                scaledValue = scaledValue - fractial +
                    (!YogaIsUndefined(fractial) &&
                        (fractial > 0.5f || FloatsEqual(fractial, 0.5f))
                            ? 1.0f
                            : 0.0f);
            }

            return (YogaIsUndefined(scaledValue) ||
                YogaIsUndefined(pointScaleFactor))
                ? YogaValue.YGUndefined
                : scaledValue / pointScaleFactor;
        }

        public static bool YGNodeCanUseCachedMeasurement(
            MeasureMode widthMode,
            float width,
            MeasureMode heightMode,
            float height,
            MeasureMode lastWidthMode,
            float lastWidth,
            MeasureMode lastHeightMode,
            float lastHeight,
            float lastComputedWidth,
            float lastComputedHeight,
            float marginRow,
            float marginColumn,
            YogaConfig config)
        {
            if ((!YogaIsUndefined(lastComputedHeight) && lastComputedHeight < 0) ||
                (!YogaIsUndefined(lastComputedWidth) && lastComputedWidth < 0))
            {
                return false;
            }

            bool useRoundedComparison =
                config != null && config.PointScaleFactor != 0;
            float effectiveWidth = useRoundedComparison
                ? YGRoundValueToPixelGrid(width, config.PointScaleFactor, false, false)
                : width;
            float effectiveHeight = useRoundedComparison
                ? YGRoundValueToPixelGrid(height, config.PointScaleFactor, false, false)
                : height;
            float effectiveLastWidth = useRoundedComparison
                ? YGRoundValueToPixelGrid(
                    lastWidth,
                    config.PointScaleFactor,
                    false,
                    false)
                : lastWidth;
            float effectiveLastHeight = useRoundedComparison
                ? YGRoundValueToPixelGrid(
                    lastHeight,
                    config.PointScaleFactor,
                    false,
                    false)
                : lastHeight;

            bool hasSameWidthSpec = lastWidthMode == widthMode &&
                FloatsEqual(effectiveLastWidth, effectiveWidth);
            bool hasSameHeightSpec = lastHeightMode == heightMode &&
                FloatsEqual(effectiveLastHeight, effectiveHeight);

            bool widthIsCompatible =
                hasSameWidthSpec ||
                YGMeasureModeSizeIsExactAndMatchesOldMeasuredSize(
                    widthMode,
                    width - marginRow,
                    lastComputedWidth) ||
                YGMeasureModeOldSizeIsUnspecifiedAndStillFits(
                    widthMode,
                    width - marginRow,
                    lastWidthMode,
                    lastComputedWidth) ||
                YGMeasureModeNewMeasureSizeIsStricterAndStillValid(
                    widthMode,
                    width - marginRow,
                    lastWidthMode,
                    lastWidth,
                    lastComputedWidth);

            bool heightIsCompatible =
                hasSameHeightSpec ||
                YGMeasureModeSizeIsExactAndMatchesOldMeasuredSize(
                    heightMode,
                    height - marginColumn,
                    lastComputedHeight) ||
                YGMeasureModeOldSizeIsUnspecifiedAndStillFits(
                    heightMode,
                    height - marginColumn,
                    lastHeightMode,
                    lastComputedHeight) ||
                YGMeasureModeNewMeasureSizeIsStricterAndStillValid(
                    heightMode,
                    height - marginColumn,
                    lastHeightMode,
                    lastHeight,
                    lastComputedHeight);

            return widthIsCompatible && heightIsCompatible;
        }

        //
        // This is a wrapper around the YGNodelayoutImpl function. It determines whether
        // the layout request is redundant and can be skipped.
        //
        // Parameters:
        //  Input parameters are the same as YGNodelayoutImpl (see above)
        //  Return parameter is true if layout was performed, false if skipped
        //
        public static bool YGLayoutNodeInternal(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            Direction ownerDirection,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight,
            bool performLayout,
            LayoutPassReason reason,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            YogaLayout layout = node.Layout;

            depth++;

            bool needToVisitNode =
                (node.IsDirty && layout.GenerationCount != generationCount) ||
                layout.LastOwnerDirection != ownerDirection;

            if (needToVisitNode)
            {
                // Invalidate the cached results.
                layout.NextCachedMeasurementsIndex    = 0;
                layout.CachedLayout.WidthMeasureMode  = MeasureMode.Undefined;
                layout.CachedLayout.HeightMeasureMode = MeasureMode.Undefined;
                layout.CachedLayout.ComputedWidth     = -1;
                layout.CachedLayout.ComputedHeight    = -1;
            }

            YogaCachedMeasurement cachedResults = null;

            // Determine whether the results are already cached. We maintain a separate
            // cache for layouts and measurements. A layout operation modifies the
            // positions and dimensions for nodes in the subtree. The algorithm assumes
            // that each node gets laid out a maximum of one time per tree layout, but
            // multiple measurements may be required to resolve all of the flex
            // dimensions. We handle nodes with measure functions specially here because
            // they are the most expensive to measure, so it's worth avoiding redundant
            // measurements if at all possible.
            if (node.MeasureFunc != null)
            {
                float marginAxisRow = node.GetMarginForAxis(FlexDirection.Row, ownerWidth);
                float marginAxisColumn = node.GetMarginForAxis(FlexDirection.Column, ownerWidth);

                // First, try to use the layout cache.
                if (YGNodeCanUseCachedMeasurement(
                    widthMeasureMode,
                    availableWidth,
                    heightMeasureMode,
                    availableHeight,
                    layout.CachedLayout.WidthMeasureMode,
                    layout.CachedLayout.AvailableWidth,
                    layout.CachedLayout.HeightMeasureMode,
                    layout.CachedLayout.AvailableHeight,
                    layout.CachedLayout.ComputedWidth,
                    layout.CachedLayout.ComputedHeight,
                    marginAxisRow,
                    marginAxisColumn,
                    config))
                {
                    cachedResults = layout.CachedLayout;
                }
                else
                {
                    // Try to use the measurement cache.
                    for (var i = 0; i < layout.NextCachedMeasurementsIndex; i++)
                    {
                        if (YGNodeCanUseCachedMeasurement(
                            widthMeasureMode,
                            availableWidth,
                            heightMeasureMode,
                            availableHeight,
                            layout.CachedMeasurements[i].WidthMeasureMode,
                            layout.CachedMeasurements[i].AvailableWidth,
                            layout.CachedMeasurements[i].HeightMeasureMode,
                            layout.CachedMeasurements[i].AvailableHeight,
                            layout.CachedMeasurements[i].ComputedWidth,
                            layout.CachedMeasurements[i].ComputedHeight,
                            marginAxisRow,
                            marginAxisColumn,
                            config))
                        {
                            cachedResults = layout.CachedMeasurements[i];
                            break;
                        }
                    }
                }
            }
            else if (performLayout)
            {
                if (FloatsEqual(layout.CachedLayout.AvailableWidth, availableWidth) &&
                    FloatsEqual(layout.CachedLayout.AvailableHeight, availableHeight) &&
                    layout.CachedLayout.WidthMeasureMode == widthMeasureMode &&
                    layout.CachedLayout.HeightMeasureMode == heightMeasureMode)
                {
                    cachedResults = layout.CachedLayout;
                }
            }
            else
            {
                for (var i = 0; i < layout.NextCachedMeasurementsIndex; i++)
                {
                    if (FloatsEqual(
                            layout.CachedMeasurements[i].AvailableWidth,
                            availableWidth) &&
                        FloatsEqual(
                            layout.CachedMeasurements[i].AvailableHeight,
                            availableHeight) &&
                        layout.CachedMeasurements[i].WidthMeasureMode == widthMeasureMode &&
                        layout.CachedMeasurements[i].HeightMeasureMode ==
                        heightMeasureMode)
                    {
                        cachedResults = layout.CachedMeasurements[i];
                        break;
                    }
                }
            }

            if (!needToVisitNode && cachedResults != null)
            {
                layout.MeasuredDimensions[(int)Dimension.Width]  = cachedResults.ComputedWidth;
                layout.MeasuredDimensions[(int)Dimension.Height] = cachedResults.ComputedHeight;
                if (performLayout)
                    layoutMarkerData.CachedLayouts++;
                else
                    layoutMarkerData.CachedMeasures++;

                if (gPrintChanges && gPrintSkips)
                {
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"{YGSpacer(depth)}{depth}.([skipped] ");
                    node.Print(layoutContext);
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"wm: {YGMeasureModeName(widthMeasureMode, performLayout)}, hm: {YGMeasureModeName(heightMeasureMode, performLayout)}, aw: {availableWidth} ah: {availableHeight} => d: ({cachedResults.ComputedWidth}, {cachedResults.ComputedHeight}) {reason.ToString()}\n");
                }
            }
            else
            {
                if (gPrintChanges)
                {
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"{YGSpacer(depth)}{depth}.({(needToVisitNode ? "*" : "")}");
                    node.Print(layoutContext);
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"wm: {YGMeasureModeName(widthMeasureMode, performLayout)}, hm: {YGMeasureModeName(heightMeasureMode, performLayout)}, aw: {availableWidth} ah: {availableHeight} {reason.ToString()}\n");
                }

                YGNodelayoutImpl(
                    node,
                    availableWidth,
                    availableHeight,
                    ownerDirection,
                    widthMeasureMode,
                    heightMeasureMode,
                    ownerWidth,
                    ownerHeight,
                    performLayout,
                    config,
                    layoutMarkerData,
                    layoutContext,
                    depth,
                    generationCount,
                    reason);

                if (gPrintChanges)
                {
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"{YGSpacer(depth)}{depth}.){(needToVisitNode ? "*" : "")}");
                    node.Print(layoutContext);
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"wm: {YGMeasureModeName(widthMeasureMode, performLayout)}, hm: {YGMeasureModeName(heightMeasureMode, performLayout)}, d: ({layout.MeasuredDimensions[(int)Dimension.Width]}, {layout.MeasuredDimensions[(int)Dimension.Height]}) {reason.ToString()}\n");
                }

                layout.LastOwnerDirection = ownerDirection;

                if (cachedResults == null)
                {
                    if (layout.NextCachedMeasurementsIndex + 1 > layoutMarkerData.MaxMeasureCache)
                    {
                        layoutMarkerData.MaxMeasureCache =
                            layout.NextCachedMeasurementsIndex + 1;
                    }

                    if (layout.NextCachedMeasurementsIndex == MaxCachedResultCount)
                    {
                        if (gPrintChanges)
                        {
                            Logger.Log(node, LogLevel.Verbose, "Out of cache entries!\n");
                        }

                        layout.NextCachedMeasurementsIndex = 0;
                    }

                    YogaCachedMeasurement newCacheEntry;
                    if (performLayout)
                    {
                        // Use the single layout cache entry.
                        newCacheEntry = layout.CachedLayout;
                    }
                    else
                    {
                        // Allocate a new measurement cache entry.
                        newCacheEntry = layout.CachedMeasurements[layout.NextCachedMeasurementsIndex];
                        layout.NextCachedMeasurementsIndex++;
                    }

                    newCacheEntry.AvailableWidth    = availableWidth;
                    newCacheEntry.AvailableHeight   = availableHeight;
                    newCacheEntry.WidthMeasureMode  = widthMeasureMode;
                    newCacheEntry.HeightMeasureMode = heightMeasureMode;
                    newCacheEntry.ComputedWidth     = layout.MeasuredDimensions[(int)Dimension.Width];
                    newCacheEntry.ComputedHeight    = layout.MeasuredDimensions[(int)Dimension.Height];
                }
            }

            if (performLayout)
            {
                node.Layout.Width = node.Layout.MeasuredDimensions[(int)Dimension.Width];
                node.Layout.Height = node.Layout.MeasuredDimensions[(int)Dimension.Height];

                node.SetHasNewLayout(true);
                node.SetDirty(false);
            }

            layout.GenerationCount = generationCount;

            LayoutType layoutType;
            if (performLayout)
            {
                layoutType = !needToVisitNode && cachedResults == layout.CachedLayout
                    ? LayoutType.CachedLayout
                    : LayoutType.Layout;
            }
            else
            {
                layoutType = cachedResults != null
                    ? LayoutType.CachedMeasure
                    : LayoutType.Measure;
            }

            Event.Hub.Publish(new NodeLayoutEventArgs(node, layoutType, (LayoutData)layoutContext));

            return (needToVisitNode || cachedResults == null);
        }

        /// <summary>
        /// Set this to number of pixels in 1 point to round calculation results If you
        /// want to avoid rounding - set PointScaleFactor to 0
        /// </summary>
        public static void YGConfigSetPointScaleFactor(
            YogaConfig config,
            float pixelsInPoint)
        {
            YGAssertWithConfig(
                config,
                pixelsInPoint >= 0.0f,
                "Scale factor should not be less than zero");

            // We store points for Pixel as we will use it for rounding
            if (pixelsInPoint == 0.0f)
            {
                // Zero is used to skip rounding
                config.PointScaleFactor = 0.0f;
            }
            else
            {
                config.PointScaleFactor = pixelsInPoint;
            }
        }

        public static void YGRoundToPixelGrid(
            YogaNode node,
            float pointScaleFactor,
            float absoluteLeft,
            float absoluteTop)
        {
            if (pointScaleFactor == 0.0f)
            {
                return;
            }

            float nodeLeft = node.Layout.Position[(int)Edge.Left];
            float nodeTop = node.Layout.Position[(int)Edge.Top];

            float nodeWidth = node.Layout.Width;
            float nodeHeight = node.Layout.Height;

            float absoluteNodeLeft = absoluteLeft + nodeLeft;
            float absoluteNodeTop = absoluteTop + nodeTop;

            float absoluteNodeRight = absoluteNodeLeft + nodeWidth;
            float absoluteNodeBottom = absoluteNodeTop + nodeHeight;

            // If a node has a custom measure function we never want to round down its
            // size as this could lead to unwanted text truncation.
            bool textRounding = node.GetNodeType() == NodeType.Text;

            node.SetLayoutPosition(
                YGRoundValueToPixelGrid(nodeLeft, pointScaleFactor, false, textRounding),
                (int)Edge.Left);

            node.SetLayoutPosition(
                YGRoundValueToPixelGrid(nodeTop, pointScaleFactor, false, textRounding),
                (int)Edge.Top);

            // We multiply dimension by scale factor and if the result is close to the
            // whole number, we don't have any fraction To verify if the result is close
            // to whole number we want to check both floor and ceil numbers
            bool hasFractionalWidth =
                !FloatsEqual(FloatMod(nodeWidth * pointScaleFactor, 1.0f), 0f) &&
                !FloatsEqual(FloatMod(nodeWidth * pointScaleFactor, 1.0f), 1f);
            bool hasFractionalHeight =
                !FloatsEqual(FloatMod(nodeHeight * pointScaleFactor, 1.0f), 0f) &&
                !FloatsEqual(FloatMod(nodeHeight * pointScaleFactor, 1.0f), 1f);

            node.Layout.Width = 
                YGRoundValueToPixelGrid(
                    absoluteNodeRight,
                    pointScaleFactor,
                    (textRounding && hasFractionalWidth),
                    (textRounding && !hasFractionalWidth)) -
                YGRoundValueToPixelGrid(
                    absoluteNodeLeft,
                    pointScaleFactor,
                    false,
                    textRounding);

            node.Layout.Height =
                YGRoundValueToPixelGrid(
                    absoluteNodeBottom,
                    pointScaleFactor,
                    (textRounding && hasFractionalHeight),
                    (textRounding && !hasFractionalHeight)) -
                YGRoundValueToPixelGrid(
                    absoluteNodeTop,
                    pointScaleFactor,
                    false,
                    textRounding);

            int childCount = YGNodeGetChildCount(node);
            for (int i = 0; i < childCount; i++)
            {
                YGRoundToPixelGrid(
                    node.Children[i],
                    pointScaleFactor,
                    absoluteNodeLeft,
                    absoluteNodeTop);
            }
        }

        public static void YGNodeCalculateLayoutWithContext(
            YogaNode node,
            float ownerWidth,
            float ownerHeight,
            Direction ownerDirection,
            object layoutContext)
        {
            Event.Hub.Publish(new LayoutPassStartEventArgs(node, layoutContext));
            LayoutData markerData = new LayoutData();

            // Increment the generation count. This will force the recursive routine to
            // visit all dirty nodes at least once. Subsequent visits will be skipped if
            // the input parameters don't change.
            gCurrentGenerationCount++;
            node.ResolveDimension();
            float width = YogaValue.YGUndefined;
            MeasureMode widthMeasureMode = MeasureMode.Undefined;
            var maxDimensions = node.Style.MaxDimensions;
            if (YGNodeIsStyleDimDefined(node, FlexDirection.Row, ownerWidth))
            {
                width =
                    (node.GetResolvedDimension(dim[(int)FlexDirection.Row]).Resolve(ownerWidth) +
                        node.GetMarginForAxis(FlexDirection.Row, ownerWidth));
                widthMeasureMode = MeasureMode.Exactly;
            }
            else if (maxDimensions[(int)Dimension.Width].Resolve(ownerWidth).IsValid())
            {
                width            = maxDimensions[(int)Dimension.Width].Resolve(ownerWidth);
                widthMeasureMode = MeasureMode.AtMost;
            }
            else
            {
                width = ownerWidth;
                widthMeasureMode = YogaIsUndefined(width)
                    ? MeasureMode.Undefined
                    : MeasureMode.Exactly;
            }

            float height = YogaValue.YGUndefined;
            MeasureMode heightMeasureMode = MeasureMode.Undefined;
            if (YGNodeIsStyleDimDefined(node, FlexDirection.Column, ownerHeight))
            {
                height = (node.GetResolvedDimension(dim[(int)FlexDirection.Column])
                              .Resolve(ownerHeight)
                        + node.GetMarginForAxis(FlexDirection.Column, ownerWidth));
                heightMeasureMode = MeasureMode.Exactly;
            }
            else if (maxDimensions[(int)Dimension.Height].Resolve(ownerHeight).IsValid())
            {
                height            = maxDimensions[(int)Dimension.Height].Resolve(ownerHeight);
                heightMeasureMode = MeasureMode.AtMost;
            }
            else
            {
                height = ownerHeight;
                heightMeasureMode = YogaIsUndefined(height)
                    ? MeasureMode.Undefined
                    : MeasureMode.Exactly;
            }

            if (YGLayoutNodeInternal(
                node,
                width,
                height,
                ownerDirection,
                widthMeasureMode,
                heightMeasureMode,
                ownerWidth,
                ownerHeight,
                true,
                LayoutPassReason.Initial,
                node.Config,
                markerData,
                layoutContext,
                0, // tree root
                gCurrentGenerationCount))
            {
                node.SetPosition(
                    node.Layout.Direction,
                    ownerWidth,
                    ownerHeight,
                    ownerWidth);
                YGRoundToPixelGrid(node, node.Config.PointScaleFactor, 0.0f, 0.0f);

#if DEBUG
                if (node.Config.PrintTree)
                {
                    YGNodePrint(node, PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style);
                }
#endif
            }

            Event.Hub.Publish(new LayoutPassEndEventArgs(node, layoutContext, markerData));
        }

        public static void YGNodeCalculateLayout(
            YogaNode node,
            float ownerWidth,
            float ownerHeight,
            Direction ownerDirection)
        {
            YGNodeCalculateLayoutWithContext(
                node,
                ownerWidth,
                ownerHeight,
                ownerDirection,
                null);
        }

        public static void YGConfigSetLogger(YogaConfig config, LoggerFunc logger) => config.LoggerFunc = logger;

        public static void YGAssert(bool condition, string message)
        {
            if (!condition)
                Logger.Log(LogLevel.Fatal, $"{message}\n");
        }

        public static void YGAssertWithNode(
            in YogaNode node,
            bool condition,
            string message)
        {
            if (!condition)
                Logger.Log(node, LogLevel.Fatal, $"{message}\n");
        }

        public static void YGAssertWithConfig(
            in YogaConfig config,
            bool condition,
            string message)
        {
            if (!condition)
                Logger.Log(config, LogLevel.Fatal, $"{message}\n");
        }

        public static void YGConfigSetExperimentalFeatureEnabled(
            YogaConfig config,
            ExperimentalFeature feature,
            bool enabled)
        {
            config.ExperimentalFeatures[(int)feature] = enabled;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGConfigIsExperimentalFeatureEnabled(
            YogaConfig config,
            ExperimentalFeature feature)
        {
            return config.ExperimentalFeatures[(int)feature];
        }

        public static void YGConfigSetCloneNodeFunc(
            YogaConfig config,
            YogaCloneNodeFunc cloneNodeFunc)
        {
            config.CloneNodeFunc = cloneNodeFunc;
        }

        public static void YGTraverseChildrenPreOrder(IReadOnlyCollection<YogaNode> children, Action<YogaNode> action)
        {
            foreach (YogaNode node in children)
            {
                action(node);
                YGTraverseChildrenPreOrder(node.Children, action);
            }
        }

        public static void YGTraversePreOrder(YogaNode node, Action<YogaNode> action)
        {
            if (node == null)
                return;

            action(node);
            YGTraverseChildrenPreOrder(node.Children, action);
        }
    }
}
