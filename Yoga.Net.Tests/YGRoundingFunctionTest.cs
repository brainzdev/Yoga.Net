using NUnit.Framework;
using static Yoga.Net.YGGlobal;
using YGNodeRef = Yoga.Net.YGNode;
using YGConfigRef = Yoga.Net.YGConfig;

namespace Yoga.Net
{
    [TestFixture]
    public class YGRoundingFunctionTest
    {

        [Test] public void rounding_value() {
            // Test that whole numbers are rounded to whole despite ceil/floor flags
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(6.000001f, 2.0f, false, false));
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(6.000001f, 2.0f, true, false));
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(6.000001f, 2.0f, false, true));
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(5.999999f, 2.0f, false, false));
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(5.999999f, 2.0f, true, false));
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(5.999999f, 2.0f, false, true));

            // Test that numbers with fraction are rounded correctly accounting for ceil/floor flags
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(6.01f, 2.0f, false, false));
            Assert.AreEqual(6.5, YGRoundValueToPixelGrid(6.01f, 2.0f, true, false));
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(6.01f, 2.0f, false, true));
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(5.99f, 2.0f, false, false));
            Assert.AreEqual(6.0, YGRoundValueToPixelGrid(5.99f, 2.0f, true, false));
            Assert.AreEqual(5.5, YGRoundValueToPixelGrid(5.99f, 2.0f, false, true));
        }
    }
}
