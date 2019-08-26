using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;
using System.Text;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGLoggerTest
    {
        StringBuilder writeBuffer = new StringBuilder();
        int _unmanagedLogger(YGConfigRef config,
                             YGNodeRef node,
                             YGLogLevel level,
                             string format,
                             params object[] args)
        {
            writeBuffer.Append(string.Format(format, args));
            return writeBuffer.Length;
        }

        [Test]
        public void config_print_tree_enabled()
        {
            writeBuffer[0] = '\0';
            YGConfigRef config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeRef child0 = YGNodeNewWithConfig(config);
            YGNodeRef child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGConfigSetLogger(config, null);
            YGNodeFreeRecursive(root);

            string expected =
                "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, writeBuffer);
        }

        [Test]
        public void config_print_tree_disabled()
        {
            writeBuffer[0] = '\0';
            YGConfigRef config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, false);
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeRef child0 = YGNodeNewWithConfig(config);
            YGNodeRef child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGConfigSetLogger(config, null);
            YGNodeFreeRecursive(root);

            string expected = "";
            Assert.AreEqual(expected, writeBuffer);
        }

        [Test]
        public void logger_default_node_should_print_no_style_info()
        {
            writeBuffer[0] = '\0';
            YGConfigRef config = YGConfigNew();
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGNodePrint(root, (YGPrintOptions.Layout | YGPrintOptions.Children | YGPrintOptions.Style));
            YGConfigSetLogger(config, null);
            YGNodeFree(root);

            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>";
            Assert.AreEqual(expected, writeBuffer);
        }

        [Test]
        public void logger_node_with_percentage_absolute_position_and_margin()
        {
            writeBuffer[0] = '\0';
            YGConfigRef config = YGConfigNew();
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root, YGPositionType.Absolute);
            YGNodeStyleSetWidthPercent(root, 50);
            YGNodeStyleSetHeightPercent(root, 75);
            YGNodeStyleSetFlex(root, 1);
            YGNodeStyleSetMargin(root, YGEdge.Right, 10);
            YGNodeStyleSetMarginAuto(root, YGEdge.Left);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGNodePrint(root, (YGPrintOptions.Layout | YGPrintOptions.Children | YGPrintOptions.Style));
            YGConfigSetLogger(config, null);
            YGNodeFree(root);

            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"flex: 1; margin-left: auto; margin-right: 10px; width: 50%; height: 75%; position: absolute; \" ></div>";
            Assert.AreEqual(expected, writeBuffer);
        }

        [Test]
        public void logger_node_with_children_should_print_indented()
        {
            writeBuffer[0] = '\0';
            YGConfigRef config = YGConfigNew();
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNodeRef root = YGNodeNewWithConfig(config);
            YGNodeRef child0 = YGNodeNewWithConfig(config);
            YGNodeRef child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGNodePrint(root, (YGPrintOptions.Layout | YGPrintOptions.Children | YGPrintOptions.Style));
            YGConfigSetLogger(config, null);
            YGNodeFreeRecursive(root);

            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, writeBuffer);
        }
    }
}
