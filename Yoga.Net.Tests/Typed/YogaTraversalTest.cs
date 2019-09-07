using System.Collections.Generic;
using NUnit.Framework;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaTraversalTest
    {
        [Test]
        public void pre_order_traversal()
        {
            YogaNode rootChild0; 
            YogaNode rootChild1; 
            YogaNode rootChild0Child0;
            var root = new YogaNode
            {
                Children =
                {
                    (rootChild0 = new YogaNode
                    {
                        Children =
                        {
                            (rootChild0Child0 = new YogaNode())
                        }
                    }),
                    (rootChild1 = new YogaNode())
                }
            };

            List<YogaNode> visited = new List<YogaNode>();
            root.TraversePreOrder(node => visited.Add(node));

            YogaNode[] expected = 
            {
                root,
                rootChild0,
                rootChild0Child0,
                rootChild1
            };
            Assert.AreEqual(visited, expected);
        }
    }
}
