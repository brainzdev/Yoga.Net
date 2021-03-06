using NUnit.Framework;
using static Yoga.Net.YGGlobal;


using System.Text;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGLoggerTest
    {
        StringBuilder writeBuffer;

        [SetUp]
        public void Init()
        {
            writeBuffer = new StringBuilder();
        }

        int _unmanagedLogger(YGConfig config,
                             YGNode node,
                             YGLogLevel level,
                             object context,
                             string message)
        {
            writeBuffer.Append(message);
            return writeBuffer.Length;
        }

        [Test]
        public void config_print_tree_enabled()
        {
            YGConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNode root = YGNodeNewWithConfig(config);
            YGNode child0 = YGNodeNewWithConfig(config);
            YGNode child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGConfigSetLogger(config, null);
            

            string expected =
                "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }

        [Test]
        public void config_print_tree_disabled()
        {
            YGConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, false);
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNode root = YGNodeNewWithConfig(config);
            YGNode child0 = YGNodeNewWithConfig(config);
            YGNode child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGConfigSetLogger(config, null);
            

            string expected = "";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }

        [Test]
        public void logger_default_node_should_print_no_style_info()
        {
            YGConfig config = YGConfigNew();
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNode root = YGNodeNewWithConfig(config);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGNodePrint(root, (YGPrintOptions.Layout | YGPrintOptions.Children | YGPrintOptions.Style));
            YGConfigSetLogger(config, null);
            

            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }

        [Test]
        public void logger_node_with_percentage_absolute_position_and_margin()
        {
            YGConfig config = YGConfigNew();
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root, YGPositionType.Absolute);
            YGNodeStyleSetWidthPercent(root, 50);
            YGNodeStyleSetHeightPercent(root, 75);
            YGNodeStyleSetFlex(root, 1);
            YGNodeStyleSetMargin(root, YGEdge.Right, 10);
            YGNodeStyleSetMarginAuto(root, YGEdge.Left);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGNodePrint(root, (YGPrintOptions.Layout | YGPrintOptions.Children | YGPrintOptions.Style));
            YGConfigSetLogger(config, null);
            

            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"flex: 1; margin-left: auto; margin-right: 10px; width: 50%; height: 75%; position: absolute; \" ></div>";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }

        [Test]
        public void logger_node_with_children_should_print_indented()
        {
            YGConfig config = YGConfigNew();
            YGConfigSetLogger(config, _unmanagedLogger);
            YGNode root = YGNodeNewWithConfig(config);
            YGNode child0 = YGNodeNewWithConfig(config);
            YGNode child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YGNodeCalculateLayout(root, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);
            YGNodePrint(root, (YGPrintOptions.Layout | YGPrintOptions.Children | YGPrintOptions.Style));
            YGConfigSetLogger(config, null);
            

            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }
    }
}
