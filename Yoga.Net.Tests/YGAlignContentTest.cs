using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;

namespace Yoga.Net.Tests
{

    [TestFixture]
    public class YGAlignContentTest
    {
        [Test] public void align_content_flex_start()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 130);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeStyleSetHeight(root_child4, 10);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(130, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(130, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_flex_start_without_height_on_children()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_flex_start_with_flex() 
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 120);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0, 0);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child3, 1);
            YGNodeStyleSetFlexShrink(root_child3, 1);
            YGNodeStyleSetFlexBasisPercent(root_child3, 0);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(120, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(120, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Ignore("Exactly the same results as the C++ library")]
        [Test] public void align_content_flex_end()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YGAlign.FlexEnd);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeStyleSetHeight(root_child4, 10);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_spacebetween()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.SpaceBetween);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 130);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeStyleSetHeight(root_child4, 10);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(130, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(45, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(45, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(90, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(130, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(45, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(45, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(90, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_spacearound() {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.SpaceAround);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 140);
            YGNodeStyleSetHeight(root, 120);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeStyleSetHeight(root_child0, 10);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 10);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeStyleSetHeight(root_child2, 10);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeStyleSetHeight(root_child3, 10);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeStyleSetHeight(root_child4, 10);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(140, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(15, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(15, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(55, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(55, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(95, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(140, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(15, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(15, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(55, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(55, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(95, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_row()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_row_with_children() {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0_child0, 0);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_row_with_flex()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child3, 1);
            YGNodeStyleSetFlexShrink(root_child3, 1);
            YGNodeStyleSetFlexBasisPercent(root_child3, 0);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_row_with_flex_no_shrink()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child3, 1);
            YGNodeStyleSetFlexBasisPercent(root_child3, 0);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_row_with_margin()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root_child1, YGEdge.Left, 10);
            YGNodeStyleSetMargin(root_child1, YGEdge.Top, 10);
            YGNodeStyleSetMargin(root_child1, YGEdge.Right, 10);
            YGNodeStyleSetMargin(root_child1, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root_child3, YGEdge.Left, 10);
            YGNodeStyleSetMargin(root_child3, YGEdge.Top, 10);
            YGNodeStyleSetMargin(root_child3, YGEdge.Right, 10);
            YGNodeStyleSetMargin(root_child3, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(40, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_row_with_padding()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(root_child1, YGEdge.Left, 10);
            YGNodeStyleSetPadding(root_child1, YGEdge.Top, 10);
            YGNodeStyleSetPadding(root_child1, YGEdge.Right, 10);
            YGNodeStyleSetPadding(root_child1, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(root_child3, YGEdge.Left, 10);
            YGNodeStyleSetPadding(root_child3, YGEdge.Top, 10);
            YGNodeStyleSetPadding(root_child3, YGEdge.Right, 10);
            YGNodeStyleSetPadding(root_child3, YGEdge.Bottom, 10);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_row_with_single_row() 
            {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child1));

            

            
        }

        [Test] public void align_content_stretch_row_with_fixed_height()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetHeight(root_child1, 60);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(80, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_row_with_max_height()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetMaxHeight(root_child1, 20);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_row_with_min_height()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child1, 50);
            YGNodeStyleSetMinHeight(root_child1, 80);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(90, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(90, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(90, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(90, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_column()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, YGWrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 150);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child0, 50);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root_child0_child0, 1);
            YGNodeStyleSetFlexBasisPercent(root_child0_child0, 0);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeRef root_child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root_child1, 1);
            YGNodeStyleSetFlexShrink(root_child1, 1);
            YGNodeStyleSetFlexBasisPercent(root_child1, 0);
            YGNodeStyleSetHeight(root_child1, 50);
            YGNodeInsertChild(root, root_child1, 1);

            YGNodeRef root_child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child2, 50);
            YGNodeInsertChild(root, root_child2, 2);

            YGNodeRef root_child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child3, 50);
            YGNodeInsertChild(root, root_child3, 3);

            YGNodeRef root_child4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root_child4, 50);
            YGNodeInsertChild(root, root_child4, 4);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(150, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(150, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0_child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root_child1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(root_child3));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root_child4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child4));

            

            
        }

        [Test] public void align_content_stretch_is_not_overriding_align_items()
        {
            YGConfigRef config = YGConfigNew();

            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YGAlign.Stretch);

            YGNodeRef root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, YGFlexDirection.Row);
            YGNodeStyleSetAlignContent(root_child0, YGAlign.Stretch);
            YGNodeStyleSetAlignItems(root_child0, YGAlign.Center);
            YGNodeStyleSetWidth(root_child0, 100);
            YGNodeStyleSetHeight(root_child0, 100);
            YGNodeInsertChild(root, root_child0, 0);

            YGNodeRef root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root_child0_child0, YGAlign.Stretch);
            YGNodeStyleSetWidth(root_child0_child0, 10);
            YGNodeStyleSetHeight(root_child0_child0, 10);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(45, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0_child0));

            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root_child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(root_child0_child0));
            Assert.AreEqual(45, YGNodeLayoutGetTop(root_child0_child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root_child0_child0));

            

            
        }
    }
}
