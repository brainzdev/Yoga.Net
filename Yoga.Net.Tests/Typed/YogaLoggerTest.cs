using NUnit.Framework;
using System.Text;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaLoggerTest
    {
        StringBuilder writeBuffer;

        [SetUp]
        public void Init()
        {
            writeBuffer = new StringBuilder();
        }

        int _unmanagedLogger(
            LogLevel level,
            string message)
        {
            writeBuffer.Append(message);
            return writeBuffer.Length;
        }

        [Test]
        public void config_print_tree_enabled()
        {
            YogaConfig config = new YogaConfig();
            YGConfigSetPrintTreeFlag(config, true);
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = new YogaNode(config);
            YogaNode child0 = new YogaNode(config);
            YogaNode child1 = new YogaNode(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGConfigSetLogger(config, null);


            string expected =
                "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }

        [Test]
        public void config_print_tree_disabled()
        {
            YogaConfig config = new YogaConfig();
            YGConfigSetPrintTreeFlag(config, false);
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = new YogaNode(config);
            YogaNode child0 = new YogaNode(config);
            YogaNode child1 = new YogaNode(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGConfigSetLogger(config, null);


            string expected = "";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }

        [Test]
        public void logger_default_node_should_print_no_style_info()
        {
            YogaConfig config = new YogaConfig();
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = new YogaNode(config);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGNodePrint(root, (PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style));
            YGConfigSetLogger(config, null);


            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }

        [Test]
        public void logger_node_with_percentage_absolute_position_and_margin()
        {
            YogaConfig config = new YogaConfig();
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = new YogaNode(config);
            YGNodeStyleSetPositionType(root, PositionType.Absolute);
            YGNodeStyleSetWidthPercent(root, 50);
            YGNodeStyleSetHeightPercent(root, 75);
            YGNodeStyleSetFlex(root, 1);
            YGNodeStyleSetMargin(root, Edge.Right, 10);
            YGNodeStyleSetMarginAuto(root, Edge.Left);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGNodePrint(root, (PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style));
            YGConfigSetLogger(config, null);


            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"flex: 1; margin-left: auto; margin-right: 10px; width: 50%; height: 75%; position: absolute; \" ></div>";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }

        [Test]
        public void logger_node_with_children_should_print_indented()
        {
            YogaConfig config = new YogaConfig();
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = new YogaNode(config);
            YogaNode child0 = new YogaNode(config);
            YogaNode child1 = new YogaNode(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGNodePrint(root, (PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style));
            YGConfigSetLogger(config, null);


            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, writeBuffer.ToString());
        }
    }
}
