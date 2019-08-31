using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Yoga.Net
{
    public delegate YogaSize YGMeasureFunc(YGNode node, float width, YGMeasureMode widthMode, float height, YGMeasureMode heightMode, object layoutContext = null);
    public delegate float YGBaselineFunc(YGNode node, float width, float height, object layoutContext = null);
    public delegate void YGPrintFunc(YGNode node, object layoutContext = null);

    public delegate void YGDirtiedFunc(YGNode node);
    public delegate void YGNodeCleanupFunc(YGNode node);
    public delegate int LoggerFunc(YogaConfig config, YGNode node, YGLogLevel level, string message);

    public delegate YGNode YogaCloneNodeFunc(YGNode oldNode, YGNode owner, int childIndex, object context);

    public static partial class YogaGlobal
    {
        public static object YGNodeGetContext(YGNode node)
        {
            return node.Context;
        }

        public static void YGNodeSetContext(YGNode node, object context)
        {
            node.Context = context;
        }

        public static bool YGNodeHasMeasureFunc(YGNode node)
        {
            return node.HasMeasureFunc();
        }

        public static void YGNodeSetMeasureFunc(YGNode node, YGMeasureFunc measureFunc)
        {
            node.SetMeasureFunc(measureFunc);
        }

        public static bool YGNodeHasBaselineFunc(YGNode node)
        {
            return node.HasBaselineFunc();
        }

        public static void YGNodeSetBaselineFunc(YGNode node, YGBaselineFunc baselineFunc)
        {
            node.SetBaselineFunc(baselineFunc);
        }

        public static YGDirtiedFunc YGNodeGetDirtiedFunc(YGNode node)
        {
            return node.GetDirtied();
        }

        public static void YGNodeSetDirtiedFunc(YGNode node, YGDirtiedFunc dirtiedFunc)
        {
            node.SetDirtiedFunc(dirtiedFunc);
        }

        public static void YGNodeSetPrintFunc(YGNode node, YGPrintFunc printFunc)
        {
            node.SetPrintFunc(printFunc);
        }

        public static bool YGNodeGetHasNewLayout(YGNode node)
        {
            return node.GetHasNewLayout();
        }

        public static void YGConfigSetPrintTreeFlag(YogaConfig config, bool enabled)
        {
            config.PrintTree = enabled;
        }

        public static void YGNodeSetHasNewLayout(YGNode node, bool hasNewLayout)
        {
            node.SetHasNewLayout(hasNewLayout);
        }

        public static YGNodeType YGNodeGetNodeType(YGNode node)
        {
            return node.GetNodeType();
        }

        public static void YGNodeSetNodeType(YGNode node, YGNodeType nodeType)
        {
            node.SetNodeType(nodeType);
        }

        public static bool YGNodeIsDirty(YGNode node)
        {
            return node.IsDirty;
        }

        /// <summary>
        /// Marks the current node and all its descendants as dirty.
        ///
        /// Intended to be used for Uoga benchmarks. Don't use in production, as calling
        /// `YGCalculateLayout` will cause the recalculation of each and every node.
        /// </summary>
        public static void YGNodeMarkDirtyAndPropogateToDescendants(YGNode node)
        {
            node.MarkDirtyAndPropogateDownwards();
        }


        public static YGNode YGNodeNew()
        {
            return YGNodeNewWithConfig(DefaultConfig);
        }

        public static YGNode YGNodeNewWithConfig(YogaConfig config)
        {
            YGNode node = new YGNode(config);
            YGAssertWithConfig(
                config,
                node != null,
                "Could not allocate memory for node");
            Event.Hub.Publish(new NodeAllocationEventArgs(node, config));

            return node;
        }

        public static YGNode YGNodeClone(YGNode oldNode)
        {
            YGNode node = new YGNode(oldNode);
            YGAssertWithConfig(
                oldNode.GetConfig(),
                node != null,
                "Could not allocate memory for node");
            Event.Hub.Publish(new NodeAllocationEventArgs(node, node.GetConfig()));
            node.SetOwner(null);
            return node;
        }

        public static YogaConfig YGConfigClone(YogaConfig oldConfig)
        {
            YogaConfig config = new YogaConfig(oldConfig);
            return config;
        }

        public static YGNode YGNodeDeepClone(YGNode oldNode)
        {
            var config = YGConfigClone(oldNode.GetConfig());
            var node = new YGNode(oldNode, config);
            node.SetOwner(null);
            Event.Hub.Publish(new NodeAllocationEventArgs(node, node.GetConfig()));

            YGVector vec = new YGVector(); // .reserve(oldNode.getChildren().size());
            YGNode childNode = null;
            foreach (var item in oldNode.GetChildren())
            {
                childNode = YGNodeDeepClone(item);
                childNode.SetOwner(node);
                vec.Add(childNode);
            }

            node.SetChildren(vec);

            return node;
        }

        public static void YGNodeReset(YGNode node)
        {
            node.Reset();
        }

        public static YogaConfig YGConfigNew()
        {
            YogaConfig config = new YogaConfig(DefaultLogger);
            return config;
        }

        public static void YGConfigCopy(YogaConfig dest, YogaConfig src)
        {
            throw new NotImplementedException();
            //memcpy(dest, src, sizeof(YogaConfig));
        }

        public static void YGNodeSetIsReferenceBaseline(YGNode node, bool isReferenceBaseline)
        {
            if (node.IsReferenceBaseline != isReferenceBaseline)
            {
                node.SetIsReferenceBaseline(isReferenceBaseline);
                node.MarkDirtyAndPropogate();
            }
        }

        public static bool YGNodeIsReferenceBaseline(YGNode node)
        {
            return node.IsReferenceBaseline;
        }

        public static void YGNodeInsertChild(
            YGNode owner,
            YGNode child,
            int index)
        {
            YGAssertWithNode(
                owner,
                child.GetOwner() == null,
                "Child already has a owner, it must be removed first.");

            YGAssertWithNode(
                owner,
                !owner.HasMeasureFunc(),
                "Cannot add child: Nodes with measure functions cannot have children.");

            owner.InsertChild(child, index);
            child.SetOwner(owner);
            owner.MarkDirtyAndPropogate();
        }

        public static void YGNodeRemoveChild(YGNode owner, YGNode excludedChild)
        {
            if (YGNodeGetChildCount(owner) == 0)
            {
                // This is an empty set. Nothing to remove.
                return;
            }

            // Children may be shared between parents, which is indicated by not having an
            // owner. We only want to reset the child completely if it is owned
            // exclusively by one node.
            var childOwner = excludedChild.GetOwner();
            if (owner.RemoveChild(excludedChild))
            {
                if (owner == childOwner)
                {
                    excludedChild.SetLayout(new YogaLayout()); // layout is no longer valid
                    excludedChild.SetOwner(null);
                }

                owner.MarkDirtyAndPropogate();
            }
        }

        public static void YGNodeRemoveAllChildren(YGNode owner)
        {
            int childCount = YGNodeGetChildCount(owner);
            if (childCount == 0)
            {
                // This is an empty set already. Nothing to do.
                return;
            }

            YGNode firstChild = owner.Children[0];
            if (firstChild.GetOwner() == owner)
            {
                // If the first child has this node as its owner, we assume that this child
                // set is unique.
                for (int i = 0; i < childCount; i++)
                {
                    YGNode oldChild = owner.Children[i];
                    oldChild.SetLayout(new YGNode().GetLayout()); // layout is no longer valid
                    oldChild.SetOwner(null);
                }

                owner.ClearChildren();
                owner.MarkDirtyAndPropogate();
                return;
            }

            // Otherwise, we are not the owner of the child set. We don't have to do
            // anything to clear it.
            owner.SetChildren(new YGVector());
            owner.MarkDirtyAndPropogate();
        }

        public static void YGNodeSetChildrenInternal(
            YGNode owner,
            IEnumerable<YGNode> childs)
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
                    foreach (YGNode child in owner.GetChildren())
                    {
                        child.SetLayout(new YogaLayout());
                        child.SetOwner(null);
                    }

                    owner.SetChildren(new YGVector());
                    owner.MarkDirtyAndPropogate();
                }
            }
            else
            {
                if (YGNodeGetChildCount(owner) > 0)
                {
                    foreach (YGNode oldChild in owner.Children)
                    {
                        // Our new children may have nodes in common with the old children. We don't reset these common nodes.
                        //if (std::find(children.begin(), children.end(), oldChild) == children.end()) 
                        if (!newChildren.Contains(oldChild))
                        {
                            oldChild.SetLayout(new YogaLayout());
                            oldChild.SetOwner(null);
                        }
                    }
                }

                owner.SetChildren(newChildren);
                foreach (YGNode child in newChildren)
                    child.SetOwner(owner);

                owner.MarkDirtyAndPropogate();
            }
        }

        public static void YGNodeSetChildren(
            YGNode owner,
            YGNode[] c,
            int count)
        {
            var children = c.Take(count); // {c, c + count};
            YGNodeSetChildrenInternal(owner, children);
        }

        public static void YGNodeSetChildren(
            YGNode owner,
            IEnumerable<YGNode> children)
        {
            YGNodeSetChildrenInternal(owner, children);
        }

        [Obsolete("use node.Children[index]")]
        public static YGNode YGNodeGetChild(YGNode node, int index)
        {
            if (index < node.GetChildren().Count)
            {
                return node.Children[index];
            }

            return null;
        }

        public static int YGNodeGetChildCount(YGNode node)
        {
            return node.GetChildren().Count;
        }

        public static YGNode YGNodeGetOwner(YGNode node)
        {
            return node.GetOwner();
        }

        public static YGNode YGNodeGetParent(YGNode node)
        {
            return node.GetOwner();
        }

        /// <summary>
        /// Mark a node as dirty. Only valid for nodes with a custom measure function
        /// set.
        ///
        /// Yoga knows when to mark all other nodes as dirty but because nodes with
        /// measure functions depend on information not known to Yoga they must perform
        /// this dirty marking manually.
        /// </summary>
        public static void YGNodeMarkDirty(YGNode node)
        {
            YGAssertWithNode(
                node,
                node.HasMeasureFunc(),
                "Only leaf nodes with custom measure functions should manually mark themselves as dirty");

            node.MarkDirtyAndPropogate();
        }

        public static void YGNodeCopyStyle(YGNode dstNode, YGNode srcNode)
        {
            if (!(dstNode.GetStyle() == srcNode.GetStyle()))
            {
                dstNode.SetStyle(srcNode.GetStyle());
                dstNode.MarkDirtyAndPropogate();
            }
        }

        public static float YGNodeStyleGetFlexGrow(in YGNode node)
        {
            return node.GetStyle().FlexGrow.IsUndefined()
                ? DefaultFlexGrow
                : node.GetStyle().FlexGrow.Unwrap();
        }

        public static float YGNodeStyleGetFlexShrink(in YGNode node)
        {
            return node.GetStyle().FlexShrink.IsUndefined()
                ? DefaultFlexShrink
                : node.GetStyle().FlexShrink.Unwrap();
        }

        //namespace {

        //template <typename Ref, typename T>
        public static void updateStyle<TEntity, T>(
            YGNode node,
            Expression<Func<TEntity, T>> outExpr, //Ref (YogaStyle::*prop)(), 
            T value) where T : struct
        {
            var expr = (MemberExpression)outExpr.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = (T)prop.GetValue(node.GetStyle());

            if (!EqualityComparer<T>.Default.Equals(propValue, value))
            {
                prop.SetValue(node.GetStyle(), value);
                node.MarkDirtyAndPropogate();
            }
        }

        public static void updateStyleObject<TEntity, T>(
            YGNode node,
            Expression<Func<TEntity, T>> outExpr, //Ref (YogaStyle::*prop)(), 
            T value) where T : class
        {
            var expr = (MemberExpression)outExpr.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = (T)prop.GetValue(node.GetStyle());

            if (!EqualityComparer<T>.Default.Equals(propValue, value))
            {
                prop.SetValue(node.GetStyle(), value);
                node.MarkDirtyAndPropogate();
            }
        }

        //template <typename Ref, typename Idx>
        public static void updateIndexedStyleProp<T>(
            YGNode node,
            Values<T> values,
            int idx,
            CompactValue value) where T : struct, IConvertible
        {
            var propValue = values[idx];

            if (value != propValue)
            {
                values[idx] = value;
                node.MarkDirtyAndPropogate();
            }
        }

        //} // namespace

        // MSVC has trouble inferring the return type of pointer to member functions
        // with and non-overloads, instead of preferring the non-const
        // overload like clang and GCC. For the purposes of updateStyle(), we can help
        // MSVC by specifying that return type explicitely. In combination with
        // decltype, MSVC will prefer the non-version.
        //#define MSVC_HINT(PROP) decltype(YogaStyle{}.PROP())

        public static void YGNodeStyleSetDirection(YGNode node, YGDirection value)
        {
            updateStyle<Net.YogaStyle, Net.YGDirection>(node, s => s.Direction, value);
            //updateStyle<MSVC_HINT(direction)>(node, &Net.YogaStyle::direction, value);
        }

        public static YGDirection YGNodeStyleGetDirection(in YGNode node)
        {
            return node.GetStyle().Direction;
        }

        public static void YGNodeStyleSetFlexDirection(
            YGNode node,
            YGFlexDirection flexDirection)
        {
            updateStyle<Net.YogaStyle, Net.YGFlexDirection>(node, s => s.FlexDirection, flexDirection);
        }

        public static YGFlexDirection YGNodeStyleGetFlexDirection(in YGNode node)
        {
            return node.GetStyle().FlexDirection;
        }

        public static void YGNodeStyleSetJustifyContent(
            YGNode node,
            YGJustify justifyContent)
        {
            updateStyle<Net.YogaStyle, Net.YGJustify>(node, s => s.JustifyContent, justifyContent);
        }

        public static YGJustify YGNodeStyleGetJustifyContent(in YGNode node)
        {
            return node.GetStyle().JustifyContent;
        }

        public static void YGNodeStyleSetAlignContent(
            YGNode node,
            YGAlign alignContent)
        {
            updateStyle<Net.YogaStyle, Net.YGAlign>(node, s => s.AlignContent, alignContent);
        }

        public static YGAlign YGNodeStyleGetAlignContent(in YGNode node)
        {
            return node.GetStyle().AlignContent;
        }

        public static void YGNodeStyleSetAlignItems(YGNode node, YGAlign alignItems)
        {
            updateStyle<Net.YogaStyle, Net.YGAlign>(node, s => s.AlignItems, alignItems);
        }

        public static YGAlign YGNodeStyleGetAlignItems(in YGNode node)
        {
            return node.GetStyle().AlignItems;
        }

        public static void YGNodeStyleSetAlignSelf(YGNode node, YGAlign alignSelf)
        {
            updateStyle<Net.YogaStyle, Net.YGAlign>(node, s => s.AlignSelf, alignSelf);
        }

        public static YGAlign YGNodeStyleGetAlignSelf(in YGNode node)
        {
            return node.GetStyle().AlignSelf;
        }

        public static void YGNodeStyleSetPositionType(
            YGNode node,
            YGPositionType positionType)
        {
            updateStyle<Net.YogaStyle, Net.YGPositionType>(node, s => s.PositionType, positionType);
        }

        public static YGPositionType YGNodeStyleGetPositionType(in YGNode node)
        {
            return node.GetStyle().PositionType;
        }

        public static void YGNodeStyleSetFlexWrap(YGNode node, YGWrap flexWrap)
        {
            updateStyle<Net.YogaStyle, Net.YGWrap>(node, s => s.FlexWrap, flexWrap);
        }

        public static YGWrap YGNodeStyleGetFlexWrap(in YGNode node)
        {
            return node.GetStyle().FlexWrap;
        }

        public static void YGNodeStyleSetOverflow(YGNode node, YGOverflow overflow)
        {
            updateStyle<Net.YogaStyle, Net.YGOverflow>(node, s => s.Overflow, overflow);
        }

        public static YGOverflow YGNodeStyleGetOverflow(in YGNode node)
        {
            return node.GetStyle().Overflow;
        }

        public static void YGNodeStyleSetDisplay(YGNode node, YGDisplay display)
        {
            updateStyle<Net.YogaStyle, Net.YGDisplay>(node, s => s.Display, display);
        }

        public static YGDisplay YGNodeStyleGetDisplay(in YGNode node)
        {
            return node.GetStyle().Display;
        }

        // TODO(T26792433): Change the API to accept FloatOptional.
        public static void YGNodeStyleSetFlex(YGNode node, float flex)
        {
            updateStyleObject<Net.YogaStyle, FloatOptional>(node, s => s.Flex, new FloatOptional(flex));
        }

        // TODO(T26792433): Change the API to accept FloatOptional.
        public static float YGNodeStyleGetFlex(in YGNode node)
        {
            return node.GetStyle().Flex.IsUndefined()
                ? YogaValue.YGUndefined
                : node.GetStyle().Flex.Unwrap();
        }

        // TODO(T26792433): Change the API to accept FloatOptional.
        public static void YGNodeStyleSetFlexGrow(YGNode node, float flexGrow)
        {
            updateStyleObject<Net.YogaStyle, FloatOptional>(node, s => s.FlexGrow, new FloatOptional(flexGrow));
        }

        // TODO(T26792433): Change the API to accept FloatOptional.
        public static void YGNodeStyleSetFlexShrink(YGNode node, float flexShrink)
        {
            updateStyleObject<Net.YogaStyle, FloatOptional>(node, s => s.FlexShrink, new FloatOptional(flexShrink));
        }

        public static YogaValue YGNodeStyleGetFlexBasis(in YGNode node)
        {
            return node.GetStyle().FlexBasis;
            //YogaValue flexBasis = node.getStyle().flexBasis;
            //if (flexBasis.unit == YGUnit.Undefined || flexBasis.unit == YGUnit.Auto)
            //{
            //    // TODO(T26792433): Get rid off the use of YGUndefined at client side
            //    flexBasis.value = YogaValue.YGUndefined;
            //}
            //return flexBasis;
        }

        public static void YGNodeStyleSetFlexBasis(YGNode node, float flexBasis)
        {
            var value = CompactValue.OfMaybe(flexBasis, YGUnit.Point);
            updateStyleObject<Net.YogaStyle, CompactValue>(node, s => s.FlexBasis, value);
            //updateStyle<MSVC_HINT(flexBasis)>(node, &YogaStyle::flexBasis, value);
        }

        public static void YGNodeStyleSetFlexBasisPercent(
            YGNode node,
            float flexBasisPercent)
        {
            var value = CompactValue.OfMaybe(flexBasisPercent, YGUnit.Percent);
            updateStyleObject<Net.YogaStyle, CompactValue>(node, s => s.FlexBasis, value);
        }

        public static void YGNodeStyleSetFlexBasisAuto(YGNode node)
        {
            updateStyleObject<Net.YogaStyle, CompactValue>(node, s => s.FlexBasis, CompactValue.Auto);
        }

        public static void YGNodeStyleSetPosition(YGNode node, YGEdge edge, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().Position, (int)edge, value);

            //var value = CompactValue::ofMaybe<YGUnitPoint>(points);
            //updateIndexedStyleProp<MSVC_HINT(position)>(node, &YogaStyle::position, edge, value);
        }

        public static void YGNodeStyleSetPositionPercent(YGNode node, YGEdge edge, float percent)
        {
            var value = CompactValue.OfMaybe(percent, YGUnit.Percent);
            updateIndexedStyleProp(node, node.GetStyle().Position, (int)edge, value);
        }

        public static YogaValue YGNodeStyleGetPosition(in YGNode node, YGEdge edge)
        {
            return node.GetStyle().Position[edge];
        }

        public static void YGNodeStyleSetMargin(YGNode node, YGEdge edge, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().Margin, (int)edge, value);
        }

        public static void YGNodeStyleSetMarginPercent(YGNode node, YGEdge edge, float percent)
        {
            var value = CompactValue.OfMaybe(percent, YGUnit.Percent);
            updateIndexedStyleProp(node, node.GetStyle().Margin, (int)edge, value);
        }

        public static void YGNodeStyleSetMarginAuto(YGNode node, YGEdge edge)
        {
            updateIndexedStyleProp(node, node.GetStyle().Margin, (int)edge, CompactValue.Auto);
        }

        public static YogaValue YGNodeStyleGetMargin(in YGNode node, YGEdge edge)
        {
            return node.GetStyle().Margin[edge];
        }

        public static void YGNodeStyleSetPadding(YGNode node, YGEdge edge, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().Padding, (int)edge, value);
        }

        public static void YGNodeStyleSetPaddingPercent(YGNode node, YGEdge edge, float percent)
        {
            var value = CompactValue.OfMaybe(percent, YGUnit.Percent);
            updateIndexedStyleProp(node, node.GetStyle().Padding, (int)edge, value);
        }

        public static YogaValue YGNodeStyleGetPadding(in YGNode node, YGEdge edge)
        {
            return node.GetStyle().Padding[edge];
        }

        // TODO(T26792433): Change the API to accept FloatOptional.
        public static void YGNodeStyleSetBorder(YGNode node, YGEdge edge, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().Border, (int)edge, value);
        }

        public static float YGNodeStyleGetBorder(in YGNode node, YGEdge edge)
        {
            var border = node.GetStyle().Border[edge];
            if (border.IsUndefined || border.IsAuto)
            {
                // TODO(T26792433): Rather than returning YGUndefined, change the api to
                // return FloatOptional.
                return YogaValue.YGUndefined;
            }

            return border.Value;
        }

        // Yoga specific properties, not compatible with flexbox specification

        // TODO(T26792433): Change the API to accept FloatOptional.
        public static float YGNodeStyleGetAspectRatio(in YGNode node)
        {
            FloatOptional op = node.GetStyle().AspectRatio;
            return op.IsUndefined() ? YogaValue.YGUndefined : op.Unwrap();
        }

        // TODO(T26792433): Change the API to accept FloatOptional.
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
        public static void YGNodeStyleSetAspectRatio(YGNode node, float aspectRatio)
        {
            updateStyleObject<Net.YogaStyle, FloatOptional>(node, s => s.AspectRatio, new FloatOptional(aspectRatio));
        }

        public static void YGNodeStyleSetWidth(YGNode node, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().Dimensions, (int)YGDimension.Width, value);
        }

        public static void YGNodeStyleSetWidthPercent(YGNode node, float percent)
        {
            var value = CompactValue.OfMaybe(percent, YGUnit.Percent);
            updateIndexedStyleProp(node, node.GetStyle().Dimensions, (int)YGDimension.Width, value);
        }

        public static void YGNodeStyleSetWidthAuto(YGNode node)
        {
            updateIndexedStyleProp(node, node.GetStyle().Dimensions, (int)YGDimension.Width, CompactValue.Auto);
        }

        public static YogaValue YGNodeStyleGetWidth(in YGNode node)
        {
            return node.GetStyle().Dimensions[(int)YGDimension.Width];
        }

        public static void YGNodeStyleSetHeight(YGNode node, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().Dimensions, (int)YGDimension.Height, value);
        }

        public static void YGNodeStyleSetHeightPercent(YGNode node, float percent)
        {
            var value = CompactValue.OfMaybe(percent, YGUnit.Percent);
            updateIndexedStyleProp(node, node.GetStyle().Dimensions, (int)YGDimension.Height, value);
        }

        public static void YGNodeStyleSetHeightAuto(YGNode node)
        {
            updateIndexedStyleProp(node, node.GetStyle().Dimensions, (int)YGDimension.Height, CompactValue.Auto);
        }

        public static YogaValue YGNodeStyleGetHeight(in YGNode node)
        {
            return node.GetStyle().Dimensions[(int)YGDimension.Height];
        }

        public static void YGNodeStyleSetMinWidth(YGNode node, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().MinDimensions, (int)YGDimension.Width, value);
        }

        public static void YGNodeStyleSetMinWidthPercent(YGNode node, float percent)
        {
            var value = CompactValue.OfMaybe(percent, YGUnit.Percent);
            updateIndexedStyleProp(node, node.GetStyle().MinDimensions, (int)YGDimension.Width, value);
        }

        public static YogaValue YGNodeStyleGetMinWidth(in YGNode node)
        {
            return node.GetStyle().MinDimensions[(int)YGDimension.Width];
        }

        public static void YGNodeStyleSetMinHeight(YGNode node, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().MinDimensions, (int)YGDimension.Height, value);
        }

        public static void YGNodeStyleSetMinHeightPercent(YGNode node, float percent)
        {
            var value = CompactValue.OfMaybe(percent, YGUnit.Percent);
            updateIndexedStyleProp(node, node.GetStyle().MinDimensions, (int)YGDimension.Height, value);
        }

        public static YogaValue YGNodeStyleGetMinHeight(in YGNode node)
        {
            return node.GetStyle().MinDimensions[(int)YGDimension.Height];
        }

        public static void YGNodeStyleSetMaxWidth(YGNode node, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().MaxDimensions, (int)YGDimension.Width, value);
        }

        public static void YGNodeStyleSetMaxWidthPercent(YGNode node, float percent)
        {
            var value = CompactValue.OfMaybe(percent, YGUnit.Percent);
            updateIndexedStyleProp(node, node.GetStyle().MaxDimensions, (int)YGDimension.Width, value);
        }

        public static YogaValue YGNodeStyleGetMaxWidth(in YGNode node)
        {
            return node.GetStyle().MaxDimensions[(int)YGDimension.Width];
        }

        public static void YGNodeStyleSetMaxHeight(YGNode node, float points)
        {
            var value = CompactValue.OfMaybe(points, YGUnit.Point);
            updateIndexedStyleProp(node, node.GetStyle().MaxDimensions, (int)YGDimension.Height, value);
        }

        public static void YGNodeStyleSetMaxHeightPercent(YGNode node, float percent)
        {
            var value = CompactValue.OfMaybe(percent, YGUnit.Percent);
            updateIndexedStyleProp(node, node.GetStyle().MaxDimensions, (int)YGDimension.Height, value);
        }

        public static YogaValue YGNodeStyleGetMaxHeight(in YGNode node)
        {
            return node.GetStyle().MaxDimensions[(int)YGDimension.Height];
        }

        public static float YGNodeLayoutGetLeft(YGNode node) => node.GetLayout().Position[(int)YGEdge.Left];
        public static float YGNodeLayoutGetTop(YGNode node) => node.GetLayout().Position[(int)YGEdge.Top];
        public static float YGNodeLayoutGetRight(YGNode node) => node.GetLayout().Position[(int)YGEdge.Right];
        public static float YGNodeLayoutGetBottom(YGNode node) => node.GetLayout().Position[(int)YGEdge.Bottom];
        public static float YGNodeLayoutGetWidth(YGNode node) => node.GetLayout().Dimensions[(int)YGDimension.Width];
        public static float YGNodeLayoutGetHeight(YGNode node) => node.GetLayout().Dimensions[(int)YGDimension.Height];
        public static YGDirection YGNodeLayoutGetDirection(YGNode node) => node.GetLayout().Direction;
        public static bool YGNodeLayoutGetHadOverflow(YGNode node) => node.GetLayout().HadOverflow;

        // Get the computed values for these nodes after performing layout. If they were
        // set using point values then the returned value will be the same as
        // YGNodeStyleGetXXX. However if they were set using a percentage value then the
        // returned value is the computed value used during layout.
        public static float YGNodeLayoutGetMargin(YGNode node, YGEdge edge) => LayoutResolvedProperty(node, node.GetLayout().Margin, edge);
        public static float YGNodeLayoutGetBorder(YGNode node, YGEdge edge) => LayoutResolvedProperty(node, node.GetLayout().Border, edge);
        public static float YGNodeLayoutGetPadding(YGNode node, YGEdge edge) => LayoutResolvedProperty(node, node.GetLayout().Padding, edge);

        public static float Margin(YGNode node, YGEdge edge) => LayoutResolvedProperty(node, node.GetLayout().Margin, edge);
        public static float Border(YGNode node, YGEdge edge) => LayoutResolvedProperty(node, node.GetLayout().Border, edge);
        public static float Padding(YGNode node, YGEdge edge) => LayoutResolvedProperty(node, node.GetLayout().Padding, edge);

        public static float LayoutResolvedProperty(YGNode node, float[] instanceName, YGEdge edge)
        {
            YGAssertWithNode(
                node,
                edge <= YGEdge.End,
                "Cannot get layout properties of multi-edge shorthands");
            if (edge == YGEdge.Start)
            {
                if (node.GetLayout().Direction == YGDirection.RTL)
                    return instanceName[(int)YGEdge.Right];
                return instanceName[(int)YGEdge.Left];
            }

            if (edge == YGEdge.End)
            {
                if (node.GetLayout().Direction == YGDirection.RTL)
                    return instanceName[(int)YGEdge.Left];
                return instanceName[(int)YGEdge.Right];
            }

            return instanceName[(int)edge];
        }

        public static int gCurrentGenerationCount = 0;

#if DEBUG
        public static void YGNodePrintInternal(
            YGNode node,
            YGPrintOptions options)
        {
            var sb = new StringBuilder();

            var np = new YGNodePrint(sb);
            np.YGNodeToString(node, options, 0);
            Logger.Log(node, YGLogLevel.Debug, sb.ToString());
        }

        public static void YGNodePrint(YGNode node, YGPrintOptions options)
        {
            YGNodePrintInternal(node, options);
        }
#endif

        internal static readonly YGEdge[] leading = { YGEdge.Top, YGEdge.Bottom, YGEdge.Left, YGEdge.Right };
        internal static readonly YGEdge[] trailing = { YGEdge.Bottom, YGEdge.Top, YGEdge.Right, YGEdge.Left };
        internal static readonly YGEdge[] pos = { YGEdge.Top, YGEdge.Bottom, YGEdge.Left, YGEdge.Right };
        internal static YGDimension[] dim = {YGDimension.Height, YGDimension.Height, YGDimension.Width, YGDimension.Width};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YGNodePaddingAndBorderForAxis(in YGNode node, YGFlexDirection axis, float widthSize)
        {
            return (node.GetLeadingPaddingAndBorder(axis, widthSize) +
                    node.GetTrailingPaddingAndBorder(axis, widthSize))
               .Unwrap();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YGAlign YGNodeAlignItem(YGNode node, YGNode child)
        {
            YGAlign align = child.GetStyle().AlignSelf == YGAlign.Auto
                ? node.GetStyle().AlignItems
                : child.GetStyle().AlignSelf;
            if (align == YGAlign.Baseline && node.GetStyle().FlexDirection.IsColumn())
            {
                return YGAlign.FlexStart;
            }

            return align;
        }

        public static float YGBaseline(YGNode node, object layoutContext)
        {
            if (node.HasBaselineFunc())
            {
                Event.Hub.Publish(new NodeBaselineStartEventArgs(node));

                float layoutBaseline = node.Baseline(
                    node.GetLayout().MeasuredDimensions[(int)YGDimension.Width],
                    node.GetLayout().MeasuredDimensions[(int)YGDimension.Height],
                    layoutContext);

                Event.Hub.Publish(new NodeBaselineEndEventArgs(node));

                YGAssertWithNode(
                    node,
                    !YogaIsUndefined(layoutBaseline),
                    "Expect custom baseline function to not return NaN");
                return layoutBaseline;
            }

            YGNode baselineChild = null;
            int childCount = YGNodeGetChildCount(node);
            for (int i = 0; i < childCount; i++)
            {
                YGNode child = node.Children[i];
                if (child.GetLineIndex() > 0)
                {
                    break;
                }

                if (child.GetStyle().PositionType == YGPositionType.Absolute)
                {
                    continue;
                }

                if (YGNodeAlignItem(node, child) == YGAlign.Baseline ||
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
                return node.GetLayout().MeasuredDimensions[(int)YGDimension.Height];
            }

            float baseline = YGBaseline(baselineChild, layoutContext);
            return baseline + baselineChild.GetLayout().Position[(int)YGEdge.Top];
        }

        public static bool YGIsBaselineLayout(YGNode node)
        {
            if (node.GetStyle().FlexDirection.IsColumn())
            {
                return false;
            }

            if (node.GetStyle().AlignItems == YGAlign.Baseline)
            {
                return true;
            }

            int childCount = YGNodeGetChildCount(node);
            for (int i = 0; i < childCount; i++)
            {
                YGNode child = node.Children[i];
                if (child.GetStyle().PositionType == YGPositionType.Relative &&
                    child.GetStyle().AlignSelf == YGAlign.Baseline)
                {
                    return true;
                }
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YGNodeDimWithMargin(
            YGNode node,
            YGFlexDirection axis,
            float widthSize)
        {
            return node.GetLayout().MeasuredDimensions[(int)dim[(int)axis]] +
                (node.GetLeadingMargin(axis, widthSize) +
                    node.GetTrailingMargin(axis, widthSize))
               .Unwrap();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGNodeIsStyleDimDefined(
            YGNode node,
            YGFlexDirection axis,
            float ownerSize)
        {
            bool isUndefined = YogaIsUndefined(node.GetResolvedDimension(dim[(int)axis]).Value);
            return !(
                node.GetResolvedDimension(dim[(int)axis]).Unit == YGUnit.Auto ||
                node.GetResolvedDimension(dim[(int)axis]).Unit == YGUnit.Undefined ||
                (node.GetResolvedDimension(dim[(int)axis]).Unit == YGUnit.Point &&
                    !isUndefined && node.GetResolvedDimension(dim[(int)axis]).Value < 0.0f) ||
                (node.GetResolvedDimension(dim[(int)axis]).Unit == YGUnit.Percent &&
                    !isUndefined &&
                    (node.GetResolvedDimension(dim[(int)axis]).Value < 0.0f ||
                        YogaIsUndefined(ownerSize))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGNodeIsLayoutDimDefined(
            YGNode node,
            YGFlexDirection axis)
        {
            float value = node.GetLayout().MeasuredDimensions[(int)dim[(int)axis]];
            return !YogaIsUndefined(value) && value >= 0.0f;
        }

        public static FloatOptional YGNodeBoundAxisWithinMinAndMax(
            in YGNode node,
            YGFlexDirection axis,
            FloatOptional value,
            float axisSize)
        {
            FloatOptional min = new FloatOptional();
            FloatOptional max = new FloatOptional();

            if (axis.IsColumn())
            {
                min = node.GetStyle().MinDimensions[(int)YGDimension.Height].Resolve(axisSize);
                max = node.GetStyle().MaxDimensions[(int)YGDimension.Height].Resolve(axisSize);
            }
            else if (axis.IsRow())
            {
                min = node.GetStyle().MinDimensions[(int)YGDimension.Width].Resolve(axisSize);
                max = node.GetStyle().MaxDimensions[(int)YGDimension.Width].Resolve(axisSize);
            }

            if (max >= new FloatOptional(0) && value > max)
            {
                return max;
            }

            if (min >= new FloatOptional(0) && value < min)
            {
                return min;
            }

            return value;
        }

        // Like YGNodeBoundAxisWithinMinAndMax but also ensures that the value doesn't
        // go below the padding and border amount.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float YGNodeBoundAxis(
            YGNode node,
            YGFlexDirection axis,
            float value,
            float axisSize,
            float widthSize)
        {
            return FloatMax(
                YGNodeBoundAxisWithinMinAndMax(
                        node,
                        axis,
                        new FloatOptional(value),
                        axisSize)
                   .Unwrap(),
                YGNodePaddingAndBorderForAxis(node, axis, widthSize));
        }

        public static void YGNodeSetChildTrailingPosition(
            YGNode node,
            YGNode child,
            YGFlexDirection axis)
        {
            float size = child.GetLayout().MeasuredDimensions[(int)dim[(int)axis]];
            child.SetLayoutPosition(
                node.GetLayout().MeasuredDimensions[(int)dim[(int)axis]] - size -
                child.GetLayout().Position[(int)pos[(int)axis]],
                (int)trailing[(int)axis]);
        }

        public static void YGConstrainMaxSizeForMode(
            in YGNode node,
            YGFlexDirection axis,
            float ownerAxisSize,
            float ownerWidth,
            ref YGMeasureMode mode,
            ref float size)
        {
            FloatOptional maxSize =
                node.GetStyle().MaxDimensions[(int)dim[(int)axis]].Resolve(ownerAxisSize) + node.GetMarginForAxis(axis, ownerWidth);
            switch (mode)
            {
            case YGMeasureMode.Exactly:
            case YGMeasureMode.AtMost:
                size = (maxSize.IsUndefined() || size < maxSize.Unwrap())
                    ? size
                    : maxSize.Unwrap();
                break;
            case YGMeasureMode.Undefined:
                if (!maxSize.IsUndefined())
                {
                    mode = YGMeasureMode.AtMost;
                    size = maxSize.Unwrap();
                }

                break;
            }
        }

        public static void YGNodeComputeFlexBasisForChild(
            YGNode node,
            YGNode child,
            float width,
            YGMeasureMode widthMode,
            float height,
            float ownerWidth,
            float ownerHeight,
            YGMeasureMode heightMode,
            YGDirection direction,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            YGFlexDirection mainAxis = node.GetStyle().FlexDirection.Resolve(direction);
            bool isMainAxisRow = mainAxis.IsRow();
            float mainAxisSize = isMainAxisRow ? width : height;
            float mainAxisownerSize = isMainAxisRow ? ownerWidth : ownerHeight;

            float childWidth;
            float childHeight;
            YGMeasureMode childWidthMeasureMode;
            YGMeasureMode childHeightMeasureMode;

            FloatOptional resolvedFlexBasis = child.ResolveFlexBasisPtr().Resolve(mainAxisownerSize);
            bool isRowStyleDimDefined = YGNodeIsStyleDimDefined(child, YGFlexDirection.Row, ownerWidth);
            bool isColumnStyleDimDefined = YGNodeIsStyleDimDefined(child, YGFlexDirection.Column, ownerHeight);

            if (!resolvedFlexBasis.IsUndefined() && !YogaIsUndefined(mainAxisSize))
            {
                if (child.GetLayout().ComputedFlexBasis.IsUndefined() ||
                    (YGConfigIsExperimentalFeatureEnabled(child.GetConfig(),YGExperimentalFeature.WebFlexBasis) &&
                    child.GetLayout().ComputedFlexBasisGeneration != generationCount))
                {
                    FloatOptional paddingAndBorder = new FloatOptional(
                        YGNodePaddingAndBorderForAxis(child, mainAxis, ownerWidth));
                    child.SetLayoutComputedFlexBasis(FloatOptional.Max(resolvedFlexBasis, paddingAndBorder));
                }
            }
            else if (isMainAxisRow && isRowStyleDimDefined)
            {
                // The width is definite, so use that as the flex basis.
                FloatOptional paddingAndBorder = new FloatOptional(YGNodePaddingAndBorderForAxis(child, YGFlexDirection.Row, ownerWidth));

                child.SetLayoutComputedFlexBasis(FloatOptional.Max(child.GetResolvedDimensions()[(int)YGDimension.Width].Resolve(ownerWidth), paddingAndBorder));
            }
            else if (!isMainAxisRow && isColumnStyleDimDefined)
            {
                // The height is definite, so use that as the flex basis.
                FloatOptional paddingAndBorder =
                    new FloatOptional(YGNodePaddingAndBorderForAxis(child, YGFlexDirection.Column, ownerWidth));
                child.SetLayoutComputedFlexBasis(FloatOptional.Max(child.GetResolvedDimensions()[(int)YGDimension.Height].Resolve(ownerHeight), paddingAndBorder));
            }
            else
            {
                // Compute the flex basis and hypothetical main size (i.e. the clamped flex
                // basis).
                childWidth             = YogaValue.YGUndefined;
                childHeight            = YogaValue.YGUndefined;
                childWidthMeasureMode  = YGMeasureMode.Undefined;
                childHeightMeasureMode = YGMeasureMode.Undefined;

                var marginRow =
                    child.GetMarginForAxis(YGFlexDirection.Row, ownerWidth).Unwrap();
                var marginColumn =
                    child.GetMarginForAxis(YGFlexDirection.Column, ownerWidth).Unwrap();

                if (isRowStyleDimDefined)
                {
                    childWidth = child.GetResolvedDimensions()[(int)YGDimension.Width]
                                      .Resolve(ownerWidth)
                                      .Unwrap() + marginRow;
                    childWidthMeasureMode = YGMeasureMode.Exactly;
                }

                if (isColumnStyleDimDefined)
                {
                    childHeight = child.GetResolvedDimensions()[(int)YGDimension.Height]
                                       .Resolve(ownerHeight)
                                       .Unwrap() +
                        marginColumn;
                    childHeightMeasureMode = YGMeasureMode.Exactly;
                }

                // The W3C spec doesn't say anything about the 'overflow' property, but all
                // major browsers appear to implement the following logic.
                if ((!isMainAxisRow && node.GetStyle().Overflow == YGOverflow.Scroll) ||
                    node.GetStyle().Overflow != YGOverflow.Scroll)
                {
                    if (YogaIsUndefined(childWidth) && !YogaIsUndefined(width))
                    {
                        childWidth            = width;
                        childWidthMeasureMode = YGMeasureMode.AtMost;
                    }
                }

                if ((isMainAxisRow && node.GetStyle().Overflow == YGOverflow.Scroll) ||
                    node.GetStyle().Overflow != YGOverflow.Scroll)
                {
                    if (YogaIsUndefined(childHeight) && !YogaIsUndefined(height))
                    {
                        childHeight            = height;
                        childHeightMeasureMode = YGMeasureMode.AtMost;
                    }
                }

                var childStyle = child.GetStyle();
                if (!childStyle.AspectRatio.IsUndefined())
                {
                    if (!isMainAxisRow && childWidthMeasureMode == YGMeasureMode.Exactly)
                    {
                        childHeight = marginColumn +
                            (childWidth - marginRow) / childStyle.AspectRatio.Unwrap();
                        childHeightMeasureMode = YGMeasureMode.Exactly;
                    }
                    else if (
                        isMainAxisRow && childHeightMeasureMode == YGMeasureMode.Exactly)
                    {
                        childWidth = marginRow +
                            (childHeight - marginColumn) * childStyle.AspectRatio.Unwrap();
                        childWidthMeasureMode = YGMeasureMode.Exactly;
                    }
                }

                // If child has no defined size in the cross axis and is set to stretch, set
                // the cross axis to be measured exactly with the available inner width

                bool hasExactWidth =
                    !YogaIsUndefined(width) && widthMode == YGMeasureMode.Exactly;
                bool childWidthStretch =
                    YGNodeAlignItem(node, child) == YGAlign.Stretch &&
                    childWidthMeasureMode != YGMeasureMode.Exactly;
                if (!isMainAxisRow && !isRowStyleDimDefined && hasExactWidth &&
                    childWidthStretch)
                {
                    childWidth            = width;
                    childWidthMeasureMode = YGMeasureMode.Exactly;
                    if (!childStyle.AspectRatio.IsUndefined())
                    {
                        childHeight =
                            (childWidth - marginRow) / childStyle.AspectRatio.Unwrap();
                        childHeightMeasureMode = YGMeasureMode.Exactly;
                    }
                }

                bool hasExactHeight =
                    !YogaIsUndefined(height) && heightMode == YGMeasureMode.Exactly;
                bool childHeightStretch =
                    YGNodeAlignItem(node, child) == YGAlign.Stretch &&
                    childHeightMeasureMode != YGMeasureMode.Exactly;
                if (isMainAxisRow && !isColumnStyleDimDefined && hasExactHeight &&
                    childHeightStretch)
                {
                    childHeight            = height;
                    childHeightMeasureMode = YGMeasureMode.Exactly;

                    if (!childStyle.AspectRatio.IsUndefined())
                    {
                        childWidth            = (childHeight - marginColumn) * childStyle.AspectRatio.Unwrap();
                        childWidthMeasureMode = YGMeasureMode.Exactly;
                    }
                }

                YGConstrainMaxSizeForMode(
                    child,
                    YGFlexDirection.Row,
                    ownerWidth,
                    ownerWidth,
                    ref childWidthMeasureMode,
                    ref childWidth);
                YGConstrainMaxSizeForMode(
                    child,
                    YGFlexDirection.Column,
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
                    new FloatOptional(
                        FloatMax(
                            child.GetLayout().MeasuredDimensions[(int)dim[(int)mainAxis]],
                            YGNodePaddingAndBorderForAxis(child, mainAxis, ownerWidth))));
            }

            child.SetLayoutComputedFlexBasisGeneration(generationCount);
        }

        public static void YGNodeAbsoluteLayoutChild(
            YGNode node,
            YGNode child,
            float width,
            YGMeasureMode widthMode,
            float height,
            YGDirection direction,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            YGFlexDirection mainAxis = node.GetStyle().FlexDirection.Resolve(direction);
            YGFlexDirection crossAxis = mainAxis.CrossAxis(direction);
            bool isMainAxisRow = mainAxis.IsRow();

            float childWidth = YogaValue.YGUndefined;
            float childHeight = YogaValue.YGUndefined;
            YGMeasureMode childWidthMeasureMode = YGMeasureMode.Undefined;
            YGMeasureMode childHeightMeasureMode = YGMeasureMode.Undefined;

            var marginRow = child.GetMarginForAxis(YGFlexDirection.Row, width).Unwrap();
            var marginColumn =
                child.GetMarginForAxis(YGFlexDirection.Column, width).Unwrap();

            if (YGNodeIsStyleDimDefined(child, YGFlexDirection.Row, width))
            {
                childWidth =
                    child.GetResolvedDimensions()[(int)YGDimension.Width]
                         .Resolve(width)
                         .Unwrap() +
                    marginRow;
            }
            else
            {
                // If the child doesn't have a specified width, compute the width based on
                // the left/right offsets if they're defined.
                if (child.IsLeadingPositionDefined(YGFlexDirection.Row) &&
                    child.IsTrailingPosDefined(YGFlexDirection.Row))
                {
                    childWidth = node.GetLayout().MeasuredDimensions[(int)YGDimension.Width] -
                        (node.GetLeadingBorder(YGFlexDirection.Row) +
                            node.GetTrailingBorder(YGFlexDirection.Row)) -
                        (child.GetLeadingPosition(YGFlexDirection.Row, width) +
                            child.GetTrailingPosition(YGFlexDirection.Row, width))
                       .Unwrap();
                    childWidth =
                        YGNodeBoundAxis(child, YGFlexDirection.Row, childWidth, width, width);
                }
            }

            if (YGNodeIsStyleDimDefined(child, YGFlexDirection.Column, height))
            {
                childHeight = child.GetResolvedDimensions()[(int)YGDimension.Height]
                                   .Resolve(height)
                                   .Unwrap() + marginColumn;
            }
            else
            {
                // If the child doesn't have a specified height, compute the height based on
                // the top/bottom offsets if they're defined.
                if (child.IsLeadingPositionDefined(YGFlexDirection.Column) &&
                    child.IsTrailingPosDefined(YGFlexDirection.Column))
                {
                    childHeight = node.GetLayout().MeasuredDimensions[(int)YGDimension.Height] -
                        (node.GetLeadingBorder(YGFlexDirection.Column) +
                            node.GetTrailingBorder(YGFlexDirection.Column)) -
                        (child.GetLeadingPosition(YGFlexDirection.Column, height) +
                            child.GetTrailingPosition(YGFlexDirection.Column, height))
                       .Unwrap();
                    childHeight = YGNodeBoundAxis(
                        child,
                        YGFlexDirection.Column,
                        childHeight,
                        height,
                        width);
                }
            }

            // Exactly one dimension needs to be defined for us to be able to do aspect
            // ratio calculation. One dimension being the anchor and the other being
            // flexible.
            var childStyle = child.GetStyle();
            if (YogaIsUndefined(childWidth) ^ YogaIsUndefined(childHeight))
            {
                if (!childStyle.AspectRatio.IsUndefined())
                {
                    if (YogaIsUndefined(childWidth))
                    {
                        childWidth = marginRow +
                            (childHeight - marginColumn) * childStyle.AspectRatio.Unwrap();
                    }
                    else if (YogaIsUndefined(childHeight))
                    {
                        childHeight = marginColumn +
                            (childWidth - marginRow) / childStyle.AspectRatio.Unwrap();
                    }
                }
            }

            // If we're still missing one or the other dimension, measure the content.
            if (YogaIsUndefined(childWidth) || YogaIsUndefined(childHeight))
            {
                childWidthMeasureMode = YogaIsUndefined(childWidth)
                    ? YGMeasureMode.Undefined
                    : YGMeasureMode.Exactly;
                childHeightMeasureMode = YogaIsUndefined(childHeight)
                    ? YGMeasureMode.Undefined
                    : YGMeasureMode.Exactly;

                // If the size of the owner is defined then try to constrain the absolute
                // child to that size as well. This allows text within the absolute child to
                // wrap to the size of its owner. This is the same behavior as many browsers
                // implement.
                if (!isMainAxisRow && YogaIsUndefined(childWidth) &&
                    widthMode != YGMeasureMode.Undefined && !YogaIsUndefined(width) &&
                    width > 0)
                {
                    childWidth            = width;
                    childWidthMeasureMode = YGMeasureMode.AtMost;
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
                childWidth = child.GetLayout().MeasuredDimensions[(int)YGDimension.Width] +
                    child.GetMarginForAxis(YGFlexDirection.Row, width).Unwrap();
                childHeight = child.GetLayout().MeasuredDimensions[(int)YGDimension.Height] +
                    child.GetMarginForAxis(YGFlexDirection.Column, width).Unwrap();
            }

            YGLayoutNodeInternal(
                child,
                childWidth,
                childHeight,
                direction,
                YGMeasureMode.Exactly,
                YGMeasureMode.Exactly,
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
                    node.GetLayout().MeasuredDimensions[(int)dim[(int)mainAxis]] -
                    child.GetLayout().MeasuredDimensions[(int)dim[(int)mainAxis]] -
                    node.GetTrailingBorder(mainAxis) -
                    child.GetTrailingMargin(mainAxis, width).Unwrap() -
                    child.GetTrailingPosition(mainAxis, isMainAxisRow ? width : height)
                         .Unwrap(),
                    (int)leading[(int)mainAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(mainAxis) &&
                node.GetStyle().JustifyContent == YGJustify.Center)
            {
                child.SetLayoutPosition(
                    (node.GetLayout().MeasuredDimensions[(int)dim[(int)mainAxis]] -
                        child.GetLayout().MeasuredDimensions[(int)dim[(int)mainAxis]]) /
                    2.0f,
                    (int)leading[(int)mainAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(mainAxis) &&
                node.GetStyle().JustifyContent == YGJustify.FlexEnd)
            {
                child.SetLayoutPosition(
                    (node.GetLayout().MeasuredDimensions[(int)dim[(int)mainAxis]] -
                        child.GetLayout().MeasuredDimensions[(int)dim[(int)mainAxis]]),
                    (int)leading[(int)mainAxis]);
            }

            if (child.IsTrailingPosDefined(crossAxis) &&
                !child.IsLeadingPositionDefined(crossAxis))
            {
                child.SetLayoutPosition(
                    node.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]] -
                    child.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]] -
                    node.GetTrailingBorder(crossAxis) -
                    child.GetTrailingMargin(crossAxis, width).Unwrap() -
                    child
                       .GetTrailingPosition(crossAxis, isMainAxisRow ? height : width)
                       .Unwrap(),
                    (int)leading[(int)crossAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(crossAxis) &&
                YGNodeAlignItem(node, child) == YGAlign.Center)
            {
                child.SetLayoutPosition(
                    (node.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]] -
                        child.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]]) /
                    2.0f,
                    (int)leading[(int)crossAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(crossAxis) &&
                ((YGNodeAlignItem(node, child) == YGAlign.FlexEnd) ^
                    (node.GetStyle().FlexWrap == YGWrap.WrapReverse)))
            {
                child.SetLayoutPosition(
                    (node.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]] -
                        child.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]]),
                    (int)leading[(int)crossAxis]);
            }
        }

        public static void YGNodeWithMeasureFuncSetMeasuredDimensions(
            YGNode node,
            float availableWidth,
            float availableHeight,
            YGMeasureMode widthMeasureMode,
            YGMeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight,
            LayoutData layoutMarkerData,
            object layoutContext,
            LayoutPassReason reason)
        {
            YGAssertWithNode(
                node,
                node.HasMeasureFunc(),
                "Expected node to have custom measure function");

            float paddingAndBorderAxisRow =
                YGNodePaddingAndBorderForAxis(node, YGFlexDirection.Row, availableWidth);
            float paddingAndBorderAxisColumn = YGNodePaddingAndBorderForAxis(
                node,
                YGFlexDirection.Column,
                availableWidth);
            float marginAxisRow =
                node.GetMarginForAxis(YGFlexDirection.Row, availableWidth).Unwrap();
            float marginAxisColumn =
                node.GetMarginForAxis(YGFlexDirection.Column, availableWidth).Unwrap();

            // We want to make sure we don't call measure with negative size
            float innerWidth = YogaIsUndefined(availableWidth)
                ? availableWidth
                : FloatMax(0, availableWidth - marginAxisRow - paddingAndBorderAxisRow);
            float innerHeight = YogaIsUndefined(availableHeight)
                ? availableHeight
                : FloatMax(
                    0,
                    availableHeight - marginAxisColumn - paddingAndBorderAxisColumn);

            if (widthMeasureMode == YGMeasureMode.Exactly &&
                heightMeasureMode == YGMeasureMode.Exactly)
            {
                // Don't bother sizing the text if both dimensions are already defined.
                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        YGFlexDirection.Row,
                        availableWidth - marginAxisRow,
                        ownerWidth,
                        ownerWidth),
                    YGDimension.Width);
                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        YGFlexDirection.Column,
                        availableHeight - marginAxisColumn,
                        ownerHeight,
                        ownerWidth),
                    YGDimension.Height);
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

                Event.Hub.Publish( new MeasureCallbackEndEventArgs(
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
                        YGFlexDirection.Row,
                        (widthMeasureMode == YGMeasureMode.Undefined ||
                            widthMeasureMode == YGMeasureMode.AtMost)
                            ? measuredSize.Width + paddingAndBorderAxisRow
                            : availableWidth - marginAxisRow,
                        ownerWidth,
                        ownerWidth),
                    YGDimension.Width);

                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        YGFlexDirection.Column,
                        (heightMeasureMode == YGMeasureMode.Undefined ||
                            heightMeasureMode == YGMeasureMode.AtMost)
                            ? measuredSize.Height + paddingAndBorderAxisColumn
                            : availableHeight - marginAxisColumn,
                        ownerHeight,
                        ownerWidth),
                    YGDimension.Height);
            }
        }

        // For nodes with no children, use the available values if they were provided,
        // or the minimum size as indicated by the padding and border sizes.
        public static void YGNodeEmptyContainerSetMeasuredDimensions(
            YGNode node,
            float availableWidth,
            float availableHeight,
            YGMeasureMode widthMeasureMode,
            YGMeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight)
        {
            float paddingAndBorderAxisRow =
                YGNodePaddingAndBorderForAxis(node, YGFlexDirection.Row, ownerWidth);
            float paddingAndBorderAxisColumn =
                YGNodePaddingAndBorderForAxis(node, YGFlexDirection.Column, ownerWidth);
            float marginAxisRow =
                node.GetMarginForAxis(YGFlexDirection.Row, ownerWidth).Unwrap();
            float marginAxisColumn =
                node.GetMarginForAxis(YGFlexDirection.Column, ownerWidth).Unwrap();

            node.SetLayoutMeasuredDimension(
                YGNodeBoundAxis(
                    node,
                    YGFlexDirection.Row,
                    (widthMeasureMode == YGMeasureMode.Undefined ||
                        widthMeasureMode == YGMeasureMode.AtMost)
                        ? paddingAndBorderAxisRow
                        : availableWidth - marginAxisRow,
                    ownerWidth,
                    ownerWidth),
                YGDimension.Width);

            node.SetLayoutMeasuredDimension(
                YGNodeBoundAxis(
                    node,
                    YGFlexDirection.Column,
                    (heightMeasureMode == YGMeasureMode.Undefined ||
                        heightMeasureMode == YGMeasureMode.AtMost)
                        ? paddingAndBorderAxisColumn
                        : availableHeight - marginAxisColumn,
                    ownerHeight,
                    ownerWidth),
                YGDimension.Height);
        }

        public static bool YGNodeFixedSizeSetMeasuredDimensions(
            YGNode node,
            float availableWidth,
            float availableHeight,
            YGMeasureMode widthMeasureMode,
            YGMeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight)
        {
            if ((!YogaIsUndefined(availableWidth) &&
                    widthMeasureMode == YGMeasureMode.AtMost && availableWidth <= 0.0f) ||
                (!YogaIsUndefined(availableHeight) &&
                    heightMeasureMode == YGMeasureMode.AtMost && availableHeight <= 0.0f) ||
                (widthMeasureMode == YGMeasureMode.Exactly &&
                    heightMeasureMode == YGMeasureMode.Exactly))
            {
                var marginAxisColumn =
                    node.GetMarginForAxis(YGFlexDirection.Column, ownerWidth).Unwrap();
                var marginAxisRow =
                    node.GetMarginForAxis(YGFlexDirection.Row, ownerWidth).Unwrap();

                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        YGFlexDirection.Row,
                        YogaIsUndefined(availableWidth) ||
                        (widthMeasureMode == YGMeasureMode.AtMost &&
                            availableWidth < 0.0f)
                            ? 0.0f
                            : availableWidth - marginAxisRow,
                        ownerWidth,
                        ownerWidth),
                    YGDimension.Width);

                node.SetLayoutMeasuredDimension(
                    YGNodeBoundAxis(
                        node,
                        YGFlexDirection.Column,
                        YogaIsUndefined(availableHeight) ||
                        (heightMeasureMode == YGMeasureMode.AtMost &&
                            availableHeight < 0.0f)
                            ? 0.0f
                            : availableHeight - marginAxisColumn,
                        ownerHeight,
                        ownerWidth),
                    YGDimension.Height);
                return true;
            }

            return false;
        }

        public static void YGZeroOutLayoutRecursivly(
            YGNode node,
            object layoutContext)
        {
            node.SetLayout(new YogaLayout());
            node.SetLayoutDimension(0, 0);
            node.SetLayoutDimension(0, 1);
            node.SetHasNewLayout(true);

            node.IterChildrenAfterCloningIfNeeded(
                YGZeroOutLayoutRecursivly,
                layoutContext);
        }

        public static float YGNodeCalculateAvailableInnerDim(
            in YGNode node,
            YGFlexDirection axis,
            float availableDim,
            float ownerDim)
        {
            YGFlexDirection direction = axis.IsRow() ? YGFlexDirection.Row : YGFlexDirection.Column;
            YGDimension dimension = axis.IsRow() ? YGDimension.Width : YGDimension.Height;

            float margin = node.GetMarginForAxis(direction, ownerDim).Unwrap();
            float paddingAndBorder =
                YGNodePaddingAndBorderForAxis(node, direction, ownerDim);

            float availableInnerDim = availableDim - margin - paddingAndBorder;
            // Max dimension overrides predefined dimension value; Min dimension in turn
            // overrides both of the above
            if (!YogaIsUndefined(availableInnerDim))
            {
                // We want to make sure our available height does not violate min and max
                // constraints
                FloatOptional minDimensionOptional = node.GetStyle().MinDimensions[dimension].Resolve(ownerDim);
                float minInnerDim = minDimensionOptional.IsUndefined()
                    ? 0.0f
                    : minDimensionOptional.Unwrap() - paddingAndBorder;

                FloatOptional maxDimensionOptional = node.GetStyle().MaxDimensions[dimension].Resolve(ownerDim);

                float maxInnerDim = maxDimensionOptional.IsUndefined()
                    ? float.MaxValue
                    : maxDimensionOptional.Unwrap() - paddingAndBorder;
                availableInnerDim = FloatMax(FloatMin(availableInnerDim, maxInnerDim), minInnerDim);
            }

            return availableInnerDim;
        }

        public static float YGNodeComputeFlexBasisForChildren(
            YGNode node,
            float availableInnerWidth,
            float availableInnerHeight,
            YGMeasureMode widthMeasureMode,
            YGMeasureMode heightMeasureMode,
            YGDirection direction,
            YGFlexDirection mainAxis,
            YogaConfig config,
            bool performLayout,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            float totalOuterFlexBasis = 0.0f;
            YGNode singleFlexChild = null;
            YGVector children = node.GetChildren();
            YGMeasureMode measureModeMainDim =
                mainAxis.IsRow() ? widthMeasureMode : heightMeasureMode;
            // If there is only one child with flexGrow + flexShrink it means we can set
            // the computedFlexBasis to 0 instead of measuring and shrinking / flexing the
            // child to exactly match the remaining space
            if (measureModeMainDim == YGMeasureMode.Exactly)
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
                if (child.GetStyle().Display == YGDisplay.None)
                {
                    YGZeroOutLayoutRecursivly(child, layoutContext);
                    child.SetHasNewLayout(true);
                    child.SetDirty(false);
                    continue;
                }

                if (performLayout)
                {
                    // Set the initial position (relative to the owner).
                    YGDirection childDirection = child.ResolveDirection(direction);
                    float mainDim = mainAxis.IsRow() ? availableInnerWidth : availableInnerHeight;
                    float crossDim = mainAxis.IsRow() ? availableInnerHeight : availableInnerWidth;
                    child.SetPosition(
                        childDirection,
                        mainDim,
                        crossDim,
                        availableInnerWidth);
                }

                if (child.GetStyle().PositionType == YGPositionType.Absolute)
                {
                    continue;
                }

                if (child == singleFlexChild)
                {
                    child.SetLayoutComputedFlexBasisGeneration(generationCount);
                    child.SetLayoutComputedFlexBasis(new FloatOptional(0));
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
                    (child.GetLayout().ComputedFlexBasis +
                        child.GetMarginForAxis(mainAxis, availableInnerWidth))
                   .Unwrap();
            }

            return totalOuterFlexBasis;
        }

        // This function assumes that all the children of node have their
        // computedFlexBasis properly computed(To do this use
        // YGNodeComputeFlexBasisForChildren function). This function calculates
        // YGCollectFlexItemsRowMeasurement
        public static CollectFlexItemsRowValues YGCalculateCollectFlexItemsRowValues(
            YGNode node,
            YGDirection ownerDirection,
            float mainAxisownerSize,
            float availableInnerWidth,
            float availableInnerMainDim,
            int startOfLineIndex,
            int lineCount)
        {
            CollectFlexItemsRowValues flexAlgoRowMeasurement = new CollectFlexItemsRowValues();
            flexAlgoRowMeasurement.RelativeChildren = new List<YGNode>(node.GetChildren().Count);

            float sizeConsumedOnCurrentLineIncludingMinConstraint = 0;
            YGFlexDirection mainAxis = node.GetStyle().FlexDirection.Resolve(node.ResolveDirection(ownerDirection));
            bool isNodeFlexWrap = node.GetStyle().FlexWrap != YGWrap.NoWrap;

            // Add items to the current line until it's full or we run out of items.
            int endOfLineIndex = startOfLineIndex;
            for (; endOfLineIndex < node.GetChildren().Count; endOfLineIndex++)
            {
                YGNode child = node.Children[endOfLineIndex];
                if (child.GetStyle().Display == YGDisplay.None ||
                    child.GetStyle().PositionType == YGPositionType.Absolute)
                {
                    continue;
                }

                child.SetLineIndex(lineCount);
                float childMarginMainAxis =
                    child.GetMarginForAxis(mainAxis, availableInnerWidth).Unwrap();
                float flexBasisWithMinAndMaxConstraints =
                    YGNodeBoundAxisWithinMinAndMax(
                            child,
                            mainAxis,
                            child.GetLayout().ComputedFlexBasis,
                            mainAxisownerSize)
                       .Unwrap();

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
                        child.GetLayout().ComputedFlexBasis.Unwrap();
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
            YGNode node,
            YGFlexDirection mainAxis,
            YGFlexDirection crossAxis,
            float mainAxisownerSize,
            float availableInnerMainDim,
            float availableInnerCrossDim,
            float availableInnerWidth,
            float availableInnerHeight,
            bool flexBasisOverflows,
            YGMeasureMode measureModeCrossDim,
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
            bool isNodeFlexWrap = node.GetStyle().FlexWrap != YGWrap.NoWrap;

            foreach (var currentRelativeChild in collectedFlexItemsValues.RelativeChildren)
            {
                childFlexBasis = YGNodeBoundAxisWithinMinAndMax(
                        currentRelativeChild,
                        mainAxis,
                        currentRelativeChild.GetLayout().ComputedFlexBasis,
                        mainAxisownerSize)
                   .Unwrap();
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
                    if (!YogaIsUndefined(flexGrowFactor) && flexGrowFactor != 0)
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
                    currentRelativeChild.GetMarginForAxis(mainAxis, availableInnerWidth)
                                        .Unwrap();
                float marginCross =
                    currentRelativeChild.GetMarginForAxis(crossAxis, availableInnerWidth)
                                        .Unwrap();

                float childCrossSize;
                float childMainSize = updatedMainSize + marginMain;
                YGMeasureMode childCrossMeasureMode;
                YGMeasureMode childMainMeasureMode = YGMeasureMode.Exactly;

                var childStyle = currentRelativeChild.GetStyle();
                if (!childStyle.AspectRatio.IsUndefined())
                {
                    childCrossSize = isMainAxisRow
                        ? (childMainSize - marginMain) / childStyle.AspectRatio.Unwrap()
                        : (childMainSize - marginMain) * childStyle.AspectRatio.Unwrap();
                    childCrossMeasureMode = YGMeasureMode.Exactly;

                    childCrossSize += marginCross;
                }
                else if (
                    !YogaIsUndefined(availableInnerCrossDim) &&
                    !YGNodeIsStyleDimDefined(
                        currentRelativeChild,
                        crossAxis,
                        availableInnerCrossDim) &&
                    measureModeCrossDim == YGMeasureMode.Exactly &&
                    !(isNodeFlexWrap && flexBasisOverflows) &&
                    YGNodeAlignItem(node, currentRelativeChild) == YGAlign.Stretch &&
                    currentRelativeChild.MarginLeadingValue(crossAxis).Unit != YGUnit.Auto &&
                    currentRelativeChild.MarginTrailingValue(crossAxis).Unit != YGUnit.Auto)
                {
                    childCrossSize        = availableInnerCrossDim;
                    childCrossMeasureMode = YGMeasureMode.Exactly;
                }
                else if (!YGNodeIsStyleDimDefined(
                    currentRelativeChild,
                    crossAxis,
                    availableInnerCrossDim))
                {
                    childCrossSize = availableInnerCrossDim;
                    childCrossMeasureMode = YogaIsUndefined(childCrossSize)
                        ? YGMeasureMode.Undefined
                        : YGMeasureMode.AtMost;
                }
                else
                {
                    childCrossSize = currentRelativeChild.GetResolvedDimension(dim[(int)crossAxis])
                                                         .Resolve(availableInnerCrossDim)
                                                         .Unwrap() + marginCross;
                    bool isLoosePercentageMeasurement =
                        currentRelativeChild.GetResolvedDimension(dim[(int)crossAxis]).Unit == YGUnit.Percent &&
                        measureModeCrossDim != YGMeasureMode.Exactly;
                    childCrossMeasureMode =
                        YogaIsUndefined(childCrossSize) || isLoosePercentageMeasurement
                            ? YGMeasureMode.Undefined
                            : YGMeasureMode.Exactly;
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
                    YGNodeAlignItem(node, currentRelativeChild) == YGAlign.Stretch &&
                    currentRelativeChild.MarginLeadingValue(crossAxis).Unit !=
                    YGUnit.Auto &&
                    currentRelativeChild.MarginTrailingValue(crossAxis).Unit != YGUnit.Auto;

                float childWidth = isMainAxisRow ? childMainSize : childCrossSize;
                float childHeight = !isMainAxisRow ? childMainSize : childCrossSize;

                YGMeasureMode childWidthMeasureMode =
                    isMainAxisRow ? childMainMeasureMode : childCrossMeasureMode;
                YGMeasureMode childHeightMeasureMode =
                    !isMainAxisRow ? childMainMeasureMode : childCrossMeasureMode;

                bool isLayoutPass = performLayout && !requiresStretchLayout;
                // Recursively call the layout algorithm for this child with the updated
                // main size.
                YGLayoutNodeInternal(
                    currentRelativeChild,
                    childWidth,
                    childHeight,
                    node.GetLayout().Direction,
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
                    node.GetLayout().HadOverflow |
                    currentRelativeChild.GetLayout().HadOverflow);
            }

            return deltaFreeSpace;
        }

        // It distributes the free space to the flexible items.For those flexible items
        // whose min and max constraints are triggered, those flex item's clamped size
        // is removed from the remaingfreespace.
        public static void YGDistributeFreeSpaceFirstPass(
            CollectFlexItemsRowValues collectedFlexItemsValues,
            YGFlexDirection mainAxis,
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
                            currentRelativeChild.GetLayout().ComputedFlexBasis,
                            mainAxisownerSize)
                       .Unwrap();

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
            YGNode node,
            CollectFlexItemsRowValues collectedFlexItemsValues,
            YGFlexDirection mainAxis,
            YGFlexDirection crossAxis,
            float mainAxisownerSize,
            float availableInnerMainDim,
            float availableInnerCrossDim,
            float availableInnerWidth,
            float availableInnerHeight,
            bool flexBasisOverflows,
            YGMeasureMode measureModeCrossDim,
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
            YGNode node,
            CollectFlexItemsRowValues collectedFlexItemsValues,
            int startOfLineIndex,
            YGFlexDirection mainAxis,
            YGFlexDirection crossAxis,
            YGMeasureMode measureModeMainDim,
            YGMeasureMode measureModeCrossDim,
            float mainAxisownerSize,
            float ownerWidth,
            float availableInnerMainDim,
            float availableInnerCrossDim,
            float availableInnerWidth,
            bool performLayout,
            object layoutContext)
        {
            var style = node.GetStyle();
            float leadingPaddingAndBorderMain =
                node.GetLeadingPaddingAndBorder(mainAxis, ownerWidth).Unwrap();
            float trailingPaddingAndBorderMain =
                node.GetTrailingPaddingAndBorder(mainAxis, ownerWidth).Unwrap();
            // If we are using "at most" rules in the main axis, make sure that
            // remainingFreeSpace is 0 when min main dimension is not given
            if (measureModeMainDim == YGMeasureMode.AtMost &&
                collectedFlexItemsValues.RemainingFreeSpace > 0)
            {
                if (!style.MinDimensions[(int)dim[(int)mainAxis]].IsUndefined &&
                    !style.MinDimensions[(int)dim[(int)mainAxis]].Resolve(mainAxisownerSize).IsUndefined())
                {
                    // This condition makes sure that if the size of main dimension(after
                    // considering child nodes main dim, leading and trailing padding etc)
                    // falls below min dimension, then the remainingFreeSpace is reassigned
                    // considering the min dimension

                    // `minAvailableMainDim` denotes minimum available space in which child
                    // can be laid out, it will exclude space consumed by padding and border.
                    float minAvailableMainDim = style.MinDimensions[(int)dim[(int)mainAxis]]
                                                     .Resolve(mainAxisownerSize)
                                                     .Unwrap() - leadingPaddingAndBorderMain - trailingPaddingAndBorderMain;
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
                YGNode child = node.Children[i];
                if (child.GetStyle().PositionType == YGPositionType.Relative)
                {
                    if (child.MarginLeadingValue(mainAxis).Unit == YGUnit.Auto)
                    {
                        numberOfAutoMarginsOnCurrentLine++;
                    }

                    if (child.MarginTrailingValue(mainAxis).Unit == YGUnit.Auto)
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
            YGJustify justifyContent = node.GetStyle().JustifyContent;

            if (numberOfAutoMarginsOnCurrentLine == 0)
            {
                switch (justifyContent)
                {
                case YGJustify.Center:
                    leadingMainDim = collectedFlexItemsValues.RemainingFreeSpace / 2;
                    break;
                case YGJustify.FlexEnd:
                    leadingMainDim = collectedFlexItemsValues.RemainingFreeSpace;
                    break;
                case YGJustify.SpaceBetween:
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
                case YGJustify.SpaceEvenly:
                    // Space is distributed evenly across all elements
                    betweenMainDim = collectedFlexItemsValues.RemainingFreeSpace /
                        (collectedFlexItemsValues.ItemsOnLine + 1);
                    leadingMainDim = betweenMainDim;
                    break;
                case YGJustify.SpaceAround:
                    // Space on the edges is half of the space between elements
                    betweenMainDim = collectedFlexItemsValues.RemainingFreeSpace /
                        collectedFlexItemsValues.ItemsOnLine;
                    leadingMainDim = betweenMainDim / 2;
                    break;
                case YGJustify.FlexStart:
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
                YGNode child = node.Children[i];
                YogaStyle childStyle = child.GetStyle();
                YogaLayout childLayout = child.GetLayout();
                if (childStyle.Display == YGDisplay.None)
                {
                    continue;
                }

                if (childStyle.PositionType == YGPositionType.Absolute &&
                    child.IsLeadingPositionDefined(mainAxis))
                {
                    if (performLayout)
                    {
                        // In case the child is position absolute and has left/top being
                        // defined, we override the position to whatever the user said (and
                        // margin/border).
                        child.SetLayoutPosition(
                            child.GetLeadingPosition(mainAxis, availableInnerMainDim)
                                 .Unwrap() +
                            node.GetLeadingBorder(mainAxis) +
                            child.GetLeadingMargin(mainAxis, availableInnerWidth).Unwrap(),
                            (int)pos[(int)mainAxis]);
                    }
                }
                else
                {
                    // Now that we placed the element, we need to update the variables.
                    // We need to do that only for relative elements. Absolute elements do not
                    // take part in that phase.
                    if (childStyle.PositionType == YGPositionType.Relative)
                    {
                        if (child.MarginLeadingValue(mainAxis).Unit == YGUnit.Auto)
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

                        if (child.MarginTrailingValue(mainAxis).Unit == YGUnit.Auto)
                        {
                            collectedFlexItemsValues.MainDim +=
                                collectedFlexItemsValues.RemainingFreeSpace /
                                numberOfAutoMarginsOnCurrentLine;
                        }

                        bool canSkipFlex =
                            !performLayout && measureModeCrossDim == YGMeasureMode.Exactly;
                        if (canSkipFlex)
                        {
                            // If we skipped the flex step, then we can't rely on the measuredDims
                            // because they weren't computed. This means we can't call
                            // YGNodeDimWithMargin.
                            collectedFlexItemsValues.MainDim += betweenMainDim +
                                child.GetMarginForAxis(mainAxis, availableInnerWidth).Unwrap() +
                                childLayout.ComputedFlexBasis.Unwrap();
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
                                            YGFlexDirection.Column,
                                            availableInnerWidth)
                                       .Unwrap();
                                float descent =
                                    child.GetLayout().MeasuredDimensions[(int)YGDimension.Height] +
                                    child
                                       .GetMarginForAxis(
                                            YGFlexDirection.Column,
                                            availableInnerWidth)
                                       .Unwrap() -
                                    ascent;

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
        //      - YGMeasureMode.Undefined: max content
        //      - YGMeasureMode.Exactly: fill available
        //      - YGMeasureMode.AtMost: fit content
        //
        //    When calling YGNodelayoutImpl and YGLayoutNodeInternal, if the caller
        //    passes an available size of undefined then it must also pass a measure
        //    mode of YGMeasureMode.Undefined in that dimension.
        //
        public static void YGNodelayoutImpl(
            YGNode node,
            float availableWidth,
            float availableHeight,
            YGDirection ownerDirection,
            YGMeasureMode widthMeasureMode,
            YGMeasureMode heightMeasureMode,
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
                    ? widthMeasureMode == YGMeasureMode.Undefined
                    : true,
                "availableWidth is indefinite so widthMeasureMode must be YGMeasureMode.Undefined");
            YGAssertWithNode(
                node,
                YogaIsUndefined(availableHeight)
                    ? heightMeasureMode == YGMeasureMode.Undefined
                    : true,
                "availableHeight is indefinite so heightMeasureMode must be YGMeasureMode.Undefined");

            if (performLayout)
                layoutMarkerData.Layouts++;
            else
                layoutMarkerData.Measures++;

            // Set the resolved resolution in the node's layout.
            YGDirection direction = node.ResolveDirection(ownerDirection);
            node.SetLayoutDirection(direction);

            YGFlexDirection flexRowDirection = YGFlexDirection.Row.Resolve(direction);
            YGFlexDirection flexColumnDirection = YGFlexDirection.Column.Resolve(direction);

            YGEdge startEdge =
                direction == YGDirection.LTR ? YGEdge.Left : YGEdge.Right;
            YGEdge endEdge = direction == YGDirection.LTR ? YGEdge.Right : YGEdge.Left;
            node.SetLayoutMargin(
                node.GetLeadingMargin(flexRowDirection, ownerWidth).Unwrap(),
                startEdge);
            node.SetLayoutMargin(
                node.GetTrailingMargin(flexRowDirection, ownerWidth).Unwrap(),
                endEdge);
            node.SetLayoutMargin(
                node.GetLeadingMargin(flexColumnDirection, ownerWidth).Unwrap(),
                YGEdge.Top);
            node.SetLayoutMargin(
                node.GetTrailingMargin(flexColumnDirection, ownerWidth).Unwrap(),
                YGEdge.Bottom);

            node.SetLayoutBorder(node.GetLeadingBorder(flexRowDirection), startEdge);
            node.SetLayoutBorder(node.GetTrailingBorder(flexRowDirection), endEdge);
            node.SetLayoutBorder(node.GetLeadingBorder(flexColumnDirection), YGEdge.Top);
            node.SetLayoutBorder(
                node.GetTrailingBorder(flexColumnDirection),
                YGEdge.Bottom);

            node.SetLayoutPadding(
                node.GetLeadingPadding(flexRowDirection, ownerWidth).Unwrap(),
                startEdge);
            node.SetLayoutPadding(
                node.GetTrailingPadding(flexRowDirection, ownerWidth).Unwrap(),
                endEdge);
            node.SetLayoutPadding(
                node.GetLeadingPadding(flexColumnDirection, ownerWidth).Unwrap(),
                YGEdge.Top);
            node.SetLayoutPadding(
                node.GetTrailingPadding(flexColumnDirection, ownerWidth).Unwrap(),
                YGEdge.Bottom);

            if (node.HasMeasureFunc())
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
            YGFlexDirection mainAxis = node.GetStyle().FlexDirection.Resolve(direction);
            YGFlexDirection crossAxis = mainAxis.CrossAxis(direction);
            bool isMainAxisRow = mainAxis.IsRow();
            bool isNodeFlexWrap = node.GetStyle().FlexWrap != YGWrap.NoWrap;

            float mainAxisownerSize = isMainAxisRow ? ownerWidth : ownerHeight;
            float crossAxisownerSize = isMainAxisRow ? ownerHeight : ownerWidth;

            float leadingPaddingAndBorderCross =
                node.GetLeadingPaddingAndBorder(crossAxis, ownerWidth).Unwrap();
            float paddingAndBorderAxisMain =
                YGNodePaddingAndBorderForAxis(node, mainAxis, ownerWidth);
            float paddingAndBorderAxisCross =
                YGNodePaddingAndBorderForAxis(node, crossAxis, ownerWidth);

            YGMeasureMode measureModeMainDim =
                isMainAxisRow ? widthMeasureMode : heightMeasureMode;
            YGMeasureMode measureModeCrossDim =
                isMainAxisRow ? heightMeasureMode : widthMeasureMode;

            float paddingAndBorderAxisRow =
                isMainAxisRow ? paddingAndBorderAxisMain : paddingAndBorderAxisCross;
            float paddingAndBorderAxisColumn =
                isMainAxisRow ? paddingAndBorderAxisCross : paddingAndBorderAxisMain;

            float marginAxisRow =
                node.GetMarginForAxis(YGFlexDirection.Row, ownerWidth).Unwrap();
            float marginAxisColumn =
                node.GetMarginForAxis(YGFlexDirection.Column, ownerWidth).Unwrap();

            var minDimensions = node.GetStyle().MinDimensions;
            var maxDimensions = node.GetStyle().MaxDimensions;
            float minInnerWidth = minDimensions[(int)YGDimension.Width].Resolve(ownerWidth).Unwrap() - paddingAndBorderAxisRow;
            float maxInnerWidth = maxDimensions[(int)YGDimension.Width].Resolve(ownerWidth).Unwrap() - paddingAndBorderAxisRow;
            float minInnerHeight = minDimensions[(int)YGDimension.Height].Resolve(ownerHeight).Unwrap() - paddingAndBorderAxisColumn;
            float maxInnerHeight = maxDimensions[(int)YGDimension.Height].Resolve(ownerHeight).Unwrap() - paddingAndBorderAxisColumn;

            float minInnerMainDim = isMainAxisRow ? minInnerWidth : minInnerHeight;
            float maxInnerMainDim = isMainAxisRow ? maxInnerWidth : maxInnerHeight;

            // STEP 2: DETERMINE AVAILABLE SIZE IN MAIN AND CROSS DIRECTIONS

            float availableInnerWidth = YGNodeCalculateAvailableInnerDim(
                node,
                YGFlexDirection.Row,
                availableWidth,
                ownerWidth);
            float availableInnerHeight = YGNodeCalculateAvailableInnerDim(
                node,
                YGFlexDirection.Column,
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

            bool flexBasisOverflows = measureModeMainDim == YGMeasureMode.Undefined
                ? false
                : totalOuterFlexBasis > availableInnerMainDim;
            if (isNodeFlexWrap && flexBasisOverflows &&
                measureModeMainDim == YGMeasureMode.AtMost)
            {
                measureModeMainDim = YGMeasureMode.Exactly;
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
                    !performLayout && measureModeCrossDim == YGMeasureMode.Exactly;

                // STEP 5: RESOLVING FLEXIBLE LENGTHS ON MAIN AXIS
                // Calculate the remaining available space that needs to be allocated. If
                // the main dimension size isn't known, it is computed based on the line
                // length, so there's no more space left to distribute.

                bool sizeBasedOnContent = false;
                // If we don't measure with exact main dimension we want to ensure we don't
                // violate min and max
                if (measureModeMainDim != YGMeasureMode.Exactly)
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
                    node.GetLayout().HadOverflow | (collectedFlexItemsValues.RemainingFreeSpace < 0));

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
                if (measureModeCrossDim == YGMeasureMode.Undefined ||
                    measureModeCrossDim == YGMeasureMode.AtMost)
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
                if (!isNodeFlexWrap && measureModeCrossDim == YGMeasureMode.Exactly)
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
                        YGNode child = node.Children[i];
                        if (child.GetStyle().Display == YGDisplay.None)
                        {
                            continue;
                        }

                        if (child.GetStyle().PositionType == YGPositionType.Absolute)
                        {
                            // If the child is absolutely positioned and has a
                            // top/left/bottom/right set, override all the previously computed
                            // positions to set it correctly.
                            bool isChildLeadingPosDefined =
                                child.IsLeadingPositionDefined(crossAxis);
                            if (isChildLeadingPosDefined)
                            {
                                child.SetLayoutPosition(
                                    child.GetLeadingPosition(crossAxis, availableInnerCrossDim)
                                         .Unwrap() +
                                    node.GetLeadingBorder(crossAxis) +
                                    child.GetLeadingMargin(crossAxis, availableInnerWidth).Unwrap(),
                                    (int)pos[(int)crossAxis]);
                            }

                            // If leading position is not defined or calculations result in Nan,
                            // default to border + margin
                            if (!isChildLeadingPosDefined ||
                                YogaIsUndefined(child.GetLayout().Position[(int)pos[(int)crossAxis]]))
                            {
                                child.SetLayoutPosition(
                                    node.GetLeadingBorder(crossAxis) +
                                    child.GetLeadingMargin(crossAxis, availableInnerWidth).Unwrap(),
                                    (int)pos[(int)crossAxis]);
                            }
                        }
                        else
                        {
                            float leadingCrossDim = leadingPaddingAndBorderCross;

                            // For a relative children, we're either using alignItems (owner) or
                            // alignSelf (child) in order to determine the position in the cross
                            // axis
                            YGAlign alignItem = YGNodeAlignItem(node, child);

                            // If the child uses align stretch, we need to lay it out one more
                            // time, this time forcing the cross-axis size to be the computed
                            // cross size for the current line.
                            if (alignItem == YGAlign.Stretch &&
                                child.MarginLeadingValue(crossAxis).Unit != YGUnit.Auto &&
                                child.MarginTrailingValue(crossAxis).Unit != YGUnit.Auto)
                            {
                                // If the child defines a definite size for its cross axis, there's
                                // no need to stretch.
                                if (!YGNodeIsStyleDimDefined(
                                    child,
                                    crossAxis,
                                    availableInnerCrossDim))
                                {
                                    float childMainSize =
                                        child.GetLayout().MeasuredDimensions[(int)dim[(int)mainAxis]];
                                    var childStyle = child.GetStyle();
                                    float childCrossSize = !childStyle.AspectRatio.IsUndefined()
                                        ? child.GetMarginForAxis(crossAxis, availableInnerWidth)
                                               .Unwrap() +
                                        (isMainAxisRow
                                            ? childMainSize / childStyle.AspectRatio.Unwrap()
                                            : childMainSize * childStyle.AspectRatio.Unwrap())
                                        : collectedFlexItemsValues.CrossDim;

                                    childMainSize +=
                                        child.GetMarginForAxis(mainAxis, availableInnerWidth)
                                             .Unwrap();

                                    YGMeasureMode childMainMeasureMode = YGMeasureMode.Exactly;
                                    YGMeasureMode childCrossMeasureMode = YGMeasureMode.Exactly;
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

                                    var alignContent = node.GetStyle().AlignContent;
                                    var crossAxisDoesNotGrow =
                                        alignContent != YGAlign.Stretch && isNodeFlexWrap;
                                    YGMeasureMode childWidthMeasureMode =
                                        YogaIsUndefined(childWidth) ||
                                        (!isMainAxisRow && crossAxisDoesNotGrow)
                                            ? YGMeasureMode.Undefined
                                            : YGMeasureMode.Exactly;
                                    YGMeasureMode childHeightMeasureMode =
                                        YogaIsUndefined(childHeight) ||
                                        (isMainAxisRow && crossAxisDoesNotGrow)
                                            ? YGMeasureMode.Undefined
                                            : YGMeasureMode.Exactly;

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

                                if (child.MarginLeadingValue(crossAxis).Unit == YGUnit.Auto &&
                                    child.MarginTrailingValue(crossAxis).Unit == YGUnit.Auto)
                                {
                                    leadingCrossDim += FloatMax(0.0f, remainingCrossDim / 2);
                                }
                                else if (
                                    child.MarginTrailingValue(crossAxis).Unit == YGUnit.Auto)
                                {
                                    // No-Op
                                }
                                else if (
                                    child.MarginLeadingValue(crossAxis).Unit == YGUnit.Auto)
                                {
                                    leadingCrossDim += FloatMax(0.0f, remainingCrossDim);
                                }
                                else if (alignItem == YGAlign.FlexStart)
                                {
                                    // No-Op
                                }
                                else if (alignItem == YGAlign.Center)
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
                                child.GetLayout().Position[(int)pos[(int)crossAxis]] + totalLineCrossDim +
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
                    switch (node.GetStyle().AlignContent)
                    {
                    case YGAlign.FlexEnd:
                        currentLead += remainingAlignContentDim;
                        break;
                    case YGAlign.Center:
                        currentLead += remainingAlignContentDim / 2;
                        break;
                    case YGAlign.Stretch:
                        if (availableInnerCrossDim > totalLineCrossDim)
                        {
                            crossDimLead = remainingAlignContentDim / lineCount;
                        }

                        break;
                    case YGAlign.SpaceAround:
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
                    case YGAlign.SpaceBetween:
                        if (availableInnerCrossDim > totalLineCrossDim && lineCount > 1)
                        {
                            crossDimLead = remainingAlignContentDim / (lineCount - 1);
                        }

                        break;
                    case YGAlign.Auto:
                    case YGAlign.FlexStart:
                    case YGAlign.Baseline:
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
                        YGNode child = node.Children[ii];
                        if (child.GetStyle().Display == YGDisplay.None)
                        {
                            continue;
                        }

                        if (child.GetStyle().PositionType == YGPositionType.Relative)
                        {
                            if (child.GetLineIndex() != i)
                            {
                                break;
                            }

                            if (YGNodeIsLayoutDimDefined(child, crossAxis))
                            {
                                lineHeight = FloatMax(
                                    lineHeight,
                                    child.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]] +
                                    child.GetMarginForAxis(crossAxis, availableInnerWidth)
                                         .Unwrap());
                            }

                            if (YGNodeAlignItem(node, child) == YGAlign.Baseline)
                            {
                                float ascent = YGBaseline(child, layoutContext) +
                                    child
                                       .GetLeadingMargin(
                                            YGFlexDirection.Column,
                                            availableInnerWidth)
                                       .Unwrap();
                                float descent =
                                    child.GetLayout().MeasuredDimensions[(int)YGDimension.Height] +
                                    child
                                       .GetMarginForAxis(
                                            YGFlexDirection.Column,
                                            availableInnerWidth)
                                       .Unwrap() -
                                    ascent;
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
                            YGNode child = node.Children[ii];
                            if (child.GetStyle().Display == YGDisplay.None)
                            {
                                continue;
                            }

                            if (child.GetStyle().PositionType == YGPositionType.Relative)
                            {
                                switch (YGNodeAlignItem(node, child))
                                {
                                case YGAlign.FlexStart:
                                {
                                    child.SetLayoutPosition(
                                        currentLead +
                                        child.GetLeadingMargin(crossAxis, availableInnerWidth)
                                             .Unwrap(),
                                        (int)pos[(int)crossAxis]);
                                    break;
                                }
                                case YGAlign.FlexEnd:
                                {
                                    child.SetLayoutPosition(
                                        currentLead + lineHeight -
                                        child.GetTrailingMargin(crossAxis, availableInnerWidth)
                                             .Unwrap() -
                                        child.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]],
                                        (int)pos[(int)crossAxis]);
                                    break;
                                }
                                case YGAlign.Center:
                                {
                                    float childHeight =
                                        child.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]];

                                    child.SetLayoutPosition(
                                        currentLead + (lineHeight - childHeight) / 2,
                                        (int)pos[(int)crossAxis]);
                                    break;
                                }
                                case YGAlign.Stretch:
                                {
                                    child.SetLayoutPosition(
                                        currentLead +
                                        child.GetLeadingMargin(crossAxis, availableInnerWidth)
                                             .Unwrap(),
                                        (int)pos[(int)crossAxis]);

                                    // Remeasure child with the line height as it as been only
                                    // measured with the owners height yet.
                                    if (!YGNodeIsStyleDimDefined(
                                        child,
                                        crossAxis,
                                        availableInnerCrossDim))
                                    {
                                        float childWidth = isMainAxisRow
                                            ? (child.GetLayout()
                                                    .MeasuredDimensions[(int)YGDimension.Width] +
                                                child.GetMarginForAxis(mainAxis, availableInnerWidth)
                                                     .Unwrap())
                                            : lineHeight;

                                        float childHeight = !isMainAxisRow
                                            ? (child.GetLayout()
                                                    .MeasuredDimensions[(int)YGDimension.Height] +
                                                child.GetMarginForAxis(crossAxis, availableInnerWidth)
                                                     .Unwrap())
                                            : lineHeight;

                                        if (!(FloatsEqual(
                                                childWidth,
                                                child.GetLayout()
                                                     .MeasuredDimensions[(int)YGDimension.Width]) &&
                                            FloatsEqual(
                                                childHeight,
                                                child.GetLayout()
                                                     .MeasuredDimensions[(int)YGDimension.Height])))
                                        {
                                            YGLayoutNodeInternal(
                                                child,
                                                childWidth,
                                                childHeight,
                                                direction,
                                                YGMeasureMode.Exactly,
                                                YGMeasureMode.Exactly,
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
                                case YGAlign.Baseline:
                                {
                                    child.SetLayoutPosition(
                                        currentLead + maxAscentForCurrentLine -
                                        YGBaseline(child, layoutContext) +
                                        child
                                           .GetLeadingPosition(
                                                YGFlexDirection.Column,
                                                availableInnerCrossDim)
                                           .Unwrap(),
                                        (int)YGEdge.Top);

                                    break;
                                }
                                case YGAlign.Auto:
                                case YGAlign.SpaceBetween:
                                case YGAlign.SpaceAround:
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
                    YGFlexDirection.Row,
                    availableWidth - marginAxisRow,
                    ownerWidth,
                    ownerWidth),
                (int)YGDimension.Width);

            node.SetLayoutMeasuredDimension(
                YGNodeBoundAxis(
                    node,
                    YGFlexDirection.Column,
                    availableHeight - marginAxisColumn,
                    ownerHeight,
                    ownerWidth),
                (int)YGDimension.Height);

            // If the user didn't specify a width or height for the node, set the
            // dimensions based on the children.
            if (measureModeMainDim == YGMeasureMode.Undefined ||
                (node.GetStyle().Overflow != YGOverflow.Scroll &&
                    measureModeMainDim == YGMeasureMode.AtMost))
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
                measureModeMainDim == YGMeasureMode.AtMost &&
                node.GetStyle().Overflow == YGOverflow.Scroll)
            {
                node.SetLayoutMeasuredDimension(
                    FloatMax(
                        FloatMin(
                            availableInnerMainDim + paddingAndBorderAxisMain,
                            YGNodeBoundAxisWithinMinAndMax(
                                    node,
                                    mainAxis,
                                    new FloatOptional(maxLineMainDim),
                                    mainAxisownerSize)
                               .Unwrap()),
                        paddingAndBorderAxisMain),
                    (int)dim[(int)mainAxis]);
            }

            if (measureModeCrossDim == YGMeasureMode.Undefined ||
                (node.GetStyle().Overflow != YGOverflow.Scroll &&
                    measureModeCrossDim == YGMeasureMode.AtMost))
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
                measureModeCrossDim == YGMeasureMode.AtMost &&
                node.GetStyle().Overflow == YGOverflow.Scroll)
            {
                node.SetLayoutMeasuredDimension(
                    FloatMax(
                        FloatMin(
                            availableInnerCrossDim + paddingAndBorderAxisCross,
                            YGNodeBoundAxisWithinMinAndMax(
                                    node,
                                    crossAxis,
                                    new FloatOptional(totalLineCrossDim + paddingAndBorderAxisCross),
                                    crossAxisownerSize)
                               .Unwrap()),
                        paddingAndBorderAxisCross),
                    (int)dim[(int)crossAxis]);
            }

            // As we only wrapped in normal direction yet, we need to reverse the
            // positions on wrap-reverse.
            if (performLayout && node.GetStyle().FlexWrap == YGWrap.WrapReverse)
            {
                for (var i = 0; i < childCount; i++)
                {
                    YGNode child = node.Children[i];
                    if (child.GetStyle().PositionType == YGPositionType.Relative)
                    {
                        child.SetLayoutPosition(
                            node.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]] -
                            child.GetLayout().Position[(int)pos[(int)crossAxis]] -
                            child.GetLayout().MeasuredDimensions[(int)dim[(int)crossAxis]],
                            (int)pos[(int)crossAxis]);
                    }
                }
            }

            if (performLayout)
            {
                // STEP 10: SIZING AND POSITIONING ABSOLUTE CHILDREN
                foreach (var child in node.GetChildren())
                {
                    if (child.GetStyle().PositionType != YGPositionType.Absolute)
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
                bool needsMainTrailingPos = mainAxis == YGFlexDirection.RowReverse ||
                    mainAxis == YGFlexDirection.ColumnReverse;
                bool needsCrossTrailingPos = crossAxis == YGFlexDirection.RowReverse ||
                    crossAxis == YGFlexDirection.ColumnReverse;

                // Set trailing position if necessary.
                if (needsMainTrailingPos || needsCrossTrailingPos)
                {
                    for (int i = 0; i < childCount; i++)
                    {
                        YGNode child = node.Children[i];
                        if (child.GetStyle().Display == YGDisplay.None)
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
            YGMeasureMode mode,
            bool performLayout)
        {
            var kMeasureModeNames = new Dictionary<YGMeasureMode, string>{
                {YGMeasureMode.Undefined, "UNDEFINED" },
                {YGMeasureMode.Exactly, "EXACTLY" },
                {YGMeasureMode.AtMost, "AT_MOST" } };
            var kLayoutModeNames = new Dictionary<YGMeasureMode, string> {
                {YGMeasureMode.Undefined, "LAY_UNDEFINED" },
                {YGMeasureMode.Exactly, "LAY_EXACTLY" },
                {YGMeasureMode.AtMost, "LAY_AT_MOST" } };

            if (mode >= YGMeasureMode.AtMost)
                return "";

            return performLayout ? kLayoutModeNames[mode] : kMeasureModeNames[mode];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGMeasureModeSizeIsExactAndMatchesOldMeasuredSize(
            YGMeasureMode sizeMode,
            float size,
            float lastComputedSize)
        {
            return sizeMode == YGMeasureMode.Exactly &&
                FloatsEqual(size, lastComputedSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGMeasureModeOldSizeIsUnspecifiedAndStillFits(
            YGMeasureMode sizeMode,
            float size,
            YGMeasureMode lastSizeMode,
            float lastComputedSize)
        {
            return sizeMode == YGMeasureMode.AtMost &&
                lastSizeMode == YGMeasureMode.Undefined &&
                (size >= lastComputedSize || FloatsEqual(size, lastComputedSize));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGMeasureModeNewMeasureSizeIsStricterAndStillValid(
            YGMeasureMode sizeMode,
            float size,
            YGMeasureMode lastSizeMode,
            float lastSize,
            float lastComputedSize)
        {
            return lastSizeMode == YGMeasureMode.AtMost &&
                sizeMode == YGMeasureMode.AtMost && !YogaIsUndefined(lastSize) &&
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
            float f = 0.0000019f;
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
            YGMeasureMode widthMode,
            float width,
            YGMeasureMode heightMode,
            float height,
            YGMeasureMode lastWidthMode,
            float lastWidth,
            YGMeasureMode lastHeightMode,
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
            YGNode node,
            float availableWidth,
            float availableHeight,
            YGDirection ownerDirection,
            YGMeasureMode widthMeasureMode,
            YGMeasureMode heightMeasureMode,
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
            YogaLayout layout = node.GetLayout();

            depth++;

            bool needToVisitNode =
                (node.IsDirty && layout.GenerationCount != generationCount) ||
                layout.LastOwnerDirection != ownerDirection;

            if (needToVisitNode)
            {
                // Invalidate the cached results.
                layout.NextCachedMeasurementsIndex    = 0;
                layout.CachedLayout.widthMeasureMode  = YGMeasureMode.Undefined;
                layout.CachedLayout.heightMeasureMode = YGMeasureMode.Undefined;
                layout.CachedLayout.computedWidth     = -1;
                layout.CachedLayout.computedHeight    = -1;
            }

            YGCachedMeasurement cachedResults = null;

            // Determine whether the results are already cached. We maintain a separate
            // cache for layouts and measurements. A layout operation modifies the
            // positions and dimensions for nodes in the subtree. The algorithm assumes
            // that each node gets laid out a maximum of one time per tree layout, but
            // multiple measurements may be required to resolve all of the flex
            // dimensions. We handle nodes with measure functions specially here because
            // they are the most expensive to measure, so it's worth avoiding redundant
            // measurements if at all possible.
            if (node.HasMeasureFunc())
            {
                float marginAxisRow =
                    node.GetMarginForAxis(YGFlexDirection.Row, ownerWidth).Unwrap();
                float marginAxisColumn =
                    node.GetMarginForAxis(YGFlexDirection.Column, ownerWidth).Unwrap();

                // First, try to use the layout cache.
                if (YGNodeCanUseCachedMeasurement(
                    widthMeasureMode,
                    availableWidth,
                    heightMeasureMode,
                    availableHeight,
                    layout.CachedLayout.widthMeasureMode,
                    layout.CachedLayout.availableWidth,
                    layout.CachedLayout.heightMeasureMode,
                    layout.CachedLayout.availableHeight,
                    layout.CachedLayout.computedWidth,
                    layout.CachedLayout.computedHeight,
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
                            layout.CachedMeasurements[i].widthMeasureMode,
                            layout.CachedMeasurements[i].availableWidth,
                            layout.CachedMeasurements[i].heightMeasureMode,
                            layout.CachedMeasurements[i].availableHeight,
                            layout.CachedMeasurements[i].computedWidth,
                            layout.CachedMeasurements[i].computedHeight,
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
                if (FloatsEqual(layout.CachedLayout.availableWidth, availableWidth) &&
                    FloatsEqual(layout.CachedLayout.availableHeight, availableHeight) &&
                    layout.CachedLayout.widthMeasureMode == widthMeasureMode &&
                    layout.CachedLayout.heightMeasureMode == heightMeasureMode)
                {
                    cachedResults = layout.CachedLayout;
                }
            }
            else
            {
                for (var i = 0; i < layout.NextCachedMeasurementsIndex; i++)
                {
                    if (FloatsEqual(
                            layout.CachedMeasurements[i].availableWidth,
                            availableWidth) &&
                        FloatsEqual(
                            layout.CachedMeasurements[i].availableHeight,
                            availableHeight) &&
                        layout.CachedMeasurements[i].widthMeasureMode == widthMeasureMode &&
                        layout.CachedMeasurements[i].heightMeasureMode ==
                        heightMeasureMode)
                    {
                        cachedResults = layout.CachedMeasurements[i];
                        break;
                    }
                }
            }

            if (!needToVisitNode && cachedResults != null)
            {
                layout.MeasuredDimensions[(int)YGDimension.Width]  = cachedResults.computedWidth;
                layout.MeasuredDimensions[(int)YGDimension.Height] = cachedResults.computedHeight;
                if (performLayout)
                    layoutMarkerData.CachedLayouts++;
                else
                    layoutMarkerData.CachedMeasures++;

                if (gPrintChanges && gPrintSkips)
                {
                    Logger.Log(
                        node,
                        YGLogLevel.Verbose,
                        $"{YGSpacer(depth)}{depth}.([skipped] ");
                    node.Print(layoutContext);
                    Logger.Log(
                        node,
                        YGLogLevel.Verbose,
                        $"wm: {YGMeasureModeName(widthMeasureMode, performLayout)}, hm: {YGMeasureModeName(heightMeasureMode, performLayout)}, aw: {availableWidth} ah: {availableHeight} => d: ({cachedResults.computedWidth}, {cachedResults.computedHeight}) {reason.ToString()}\n");
                }
            }
            else
            {
                if (gPrintChanges)
                {
                    Logger.Log(
                        node,
                        YGLogLevel.Verbose,
                        $"{YGSpacer(depth)}{depth}.({(needToVisitNode ? "*" : "")}");
                    node.Print(layoutContext);
                    Logger.Log(
                        node,
                        YGLogLevel.Verbose,
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
                        YGLogLevel.Verbose,
                        $"{YGSpacer(depth)}{depth}.){(needToVisitNode ? "*" : "")}");
                    node.Print(layoutContext);
                    Logger.Log(
                        node,
                        YGLogLevel.Verbose,
                        $"wm: {YGMeasureModeName(widthMeasureMode, performLayout)}, hm: {YGMeasureModeName(heightMeasureMode, performLayout)}, d: ({layout.MeasuredDimensions[(int)YGDimension.Width]}, {layout.MeasuredDimensions[(int)YGDimension.Height]}) {reason.ToString()}\n");
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
                            Logger.Log(node, YGLogLevel.Verbose, "Out of cache entries!\n");
                        }

                        layout.NextCachedMeasurementsIndex = 0;
                    }

                    YGCachedMeasurement newCacheEntry;
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

                    newCacheEntry.availableWidth    = availableWidth;
                    newCacheEntry.availableHeight   = availableHeight;
                    newCacheEntry.widthMeasureMode  = widthMeasureMode;
                    newCacheEntry.heightMeasureMode = heightMeasureMode;
                    newCacheEntry.computedWidth     = layout.MeasuredDimensions[(int)YGDimension.Width];
                    newCacheEntry.computedHeight    = layout.MeasuredDimensions[(int)YGDimension.Height];
                }
            }

            if (performLayout)
            {
                node.SetLayoutDimension(node.GetLayout().MeasuredDimensions[(int)YGDimension.Width], (int)YGDimension.Width);
                node.SetLayoutDimension(node.GetLayout().MeasuredDimensions[(int)YGDimension.Height], (int)YGDimension.Height);

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
            YGNode node,
            float pointScaleFactor,
            float absoluteLeft,
            float absoluteTop)
        {
            if (pointScaleFactor == 0.0f)
            {
                return;
            }

            float nodeLeft = node.GetLayout().Position[(int)YGEdge.Left];
            float nodeTop = node.GetLayout().Position[(int)YGEdge.Top];

            float nodeWidth = node.GetLayout().Dimensions[(int)YGDimension.Width];
            float nodeHeight = node.GetLayout().Dimensions[(int)YGDimension.Height];

            float absoluteNodeLeft = absoluteLeft + nodeLeft;
            float absoluteNodeTop = absoluteTop + nodeTop;

            float absoluteNodeRight = absoluteNodeLeft + nodeWidth;
            float absoluteNodeBottom = absoluteNodeTop + nodeHeight;

            // If a node has a custom measure function we never want to round down its
            // size as this could lead to unwanted text truncation.
            bool textRounding = node.GetNodeType() == YGNodeType.Text;

            node.SetLayoutPosition(
                YGRoundValueToPixelGrid(nodeLeft, pointScaleFactor, false, textRounding),
                (int)YGEdge.Left);

            node.SetLayoutPosition(
                YGRoundValueToPixelGrid(nodeTop, pointScaleFactor, false, textRounding),
                (int)YGEdge.Top);

            // We multiply dimension by scale factor and if the result is close to the
            // whole number, we don't have any fraction To verify if the result is close
            // to whole number we want to check both floor and ceil numbers
            bool hasFractionalWidth =
                !FloatsEqual(FloatMod(nodeWidth * pointScaleFactor, 1.0f), 0f) &&
                !FloatsEqual(FloatMod(nodeWidth * pointScaleFactor, 1.0f), 1f);
            bool hasFractionalHeight =
                !FloatsEqual(FloatMod(nodeHeight * pointScaleFactor, 1.0f), 0f) &&
                !FloatsEqual(FloatMod(nodeHeight * pointScaleFactor, 1.0f), 1f);

            node.SetLayoutDimension(
                YGRoundValueToPixelGrid(
                    absoluteNodeRight,
                    pointScaleFactor,
                    (textRounding && hasFractionalWidth),
                    (textRounding && !hasFractionalWidth)) -
                YGRoundValueToPixelGrid(
                    absoluteNodeLeft,
                    pointScaleFactor,
                    false,
                    textRounding),
                (int)YGDimension.Width);

            node.SetLayoutDimension(
                YGRoundValueToPixelGrid(
                    absoluteNodeBottom,
                    pointScaleFactor,
                    (textRounding && hasFractionalHeight),
                    (textRounding && !hasFractionalHeight)) -
                YGRoundValueToPixelGrid(
                    absoluteNodeTop,
                    pointScaleFactor,
                    false,
                    textRounding),
                (int)YGDimension.Height);

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
            YGNode node,
            float ownerWidth,
            float ownerHeight,
            YGDirection ownerDirection,
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
            YGMeasureMode widthMeasureMode = YGMeasureMode.Undefined;
            var maxDimensions = node.GetStyle().MaxDimensions;
            if (YGNodeIsStyleDimDefined(node, YGFlexDirection.Row, ownerWidth))
            {
                width =
                    (node.GetResolvedDimension(dim[(int)YGFlexDirection.Row]).Resolve(ownerWidth) +
                        node.GetMarginForAxis(YGFlexDirection.Row, ownerWidth))
                   .Unwrap();
                widthMeasureMode = YGMeasureMode.Exactly;
            }
            else if (!maxDimensions[(int)YGDimension.Width].Resolve(ownerWidth).IsUndefined())
            {
                width = maxDimensions[(int)YGDimension.Width].Resolve(ownerWidth).Unwrap();
                widthMeasureMode = YGMeasureMode.AtMost;
            }
            else
            {
                width = ownerWidth;
                widthMeasureMode = YogaIsUndefined(width)
                    ? YGMeasureMode.Undefined
                    : YGMeasureMode.Exactly;
            }

            float height = YogaValue.YGUndefined;
            YGMeasureMode heightMeasureMode = YGMeasureMode.Undefined;
            if (YGNodeIsStyleDimDefined(node, YGFlexDirection.Column, ownerHeight))
            {
                height = (node.GetResolvedDimension(dim[(int)YGFlexDirection.Column])
                              .Resolve(ownerHeight) 
                        + node.GetMarginForAxis(YGFlexDirection.Column, ownerWidth))
                              .Unwrap();
                heightMeasureMode = YGMeasureMode.Exactly;
            }
            else if (!maxDimensions[(int)YGDimension.Height].Resolve(ownerHeight).IsUndefined())
            {
                height = maxDimensions[(int)YGDimension.Height].Resolve(ownerHeight).Unwrap();
                heightMeasureMode = YGMeasureMode.AtMost;
            }
            else
            {
                height = ownerHeight;
                heightMeasureMode = YogaIsUndefined(height)
                    ? YGMeasureMode.Undefined
                    : YGMeasureMode.Exactly;
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
                node.GetConfig(),
                markerData,
                layoutContext,
                0, // tree root
                gCurrentGenerationCount))
            {
                node.SetPosition(
                    node.GetLayout().Direction,
                    ownerWidth,
                    ownerHeight,
                    ownerWidth);
                YGRoundToPixelGrid(node, node.GetConfig().PointScaleFactor, 0.0f, 0.0f);

#if DEBUG
                if (node.GetConfig().PrintTree)
                {
                    YGNodePrint(node, YGPrintOptions.Layout | YGPrintOptions.Children | YGPrintOptions.Style);
                }
#endif
            }

            Event.Hub.Publish(new LayoutPassEndEventArgs(node, layoutContext, markerData));
        }

        public static void YGNodeCalculateLayout(
            YGNode node,
            float ownerWidth,
            float ownerHeight,
            YGDirection ownerDirection)
        {
            YGNodeCalculateLayoutWithContext(
                node,
                ownerWidth,
                ownerHeight,
                ownerDirection,
                null);
        }

        public static void YGConfigSetLogger(YogaConfig config, LoggerFunc logger)
        {
            config.LoggerFunc = logger ?? DefaultLogger;
        }

        public static void YGAssert(bool condition, string message)
        {
            if (!condition)
            {
                Logger.Log(YGLogLevel.Fatal, $"{message}\n");
            }
        }

        public static void YGAssertWithNode(
            in YGNode node,
            bool condition,
            string message)
        {
            if (!condition)
            {
                Logger.Log(node, YGLogLevel.Fatal, $"{message}\n");
            }
        }

        public static void YGAssertWithConfig(
            in YogaConfig config,
            bool condition,
            string message)
        {
            if (!condition)
            {
                Logger.Log(config, YGLogLevel.Fatal, $"{message}\n");
            }
        }

        public static void YGConfigSetExperimentalFeatureEnabled(
            YogaConfig config,
            YGExperimentalFeature feature,
            bool enabled)
        {
            config.ExperimentalFeatures[(int)feature] = enabled;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool YGConfigIsExperimentalFeatureEnabled(
            YogaConfig config,
            YGExperimentalFeature feature)
        {
            return config.ExperimentalFeatures[(int)feature];
        }

        public static void YGConfigSetCloneNodeFunc(
            YogaConfig config,
            YogaCloneNodeFunc cloneNodeFunc)
        {
            config.CloneNodeFunc = cloneNodeFunc;
        }

        public static void YGTraverseChildrenPreOrder(
            YGVector children,
            Action<YGNode> f)
        {
            foreach (YGNode node in children)
            {
                f(node);
                YGTraverseChildrenPreOrder(node.GetChildren(), f);
            }
        }

        public static void YGTraversePreOrder(
            YGNode node,
            Action<YGNode> f)
        {
            if (node == null)
            {
                return;
            }

            f(node);
            YGTraverseChildrenPreOrder(node.GetChildren(), f);
        }
    }
}
