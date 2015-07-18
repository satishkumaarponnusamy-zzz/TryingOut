using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.Trees;

namespace TryingOut.Tests.Trees
{
    [TestFixture]
    class TreePropertiesTests
    {
        private readonly object[] _leaves =
        {
            new object[]
            {
                null,
                0
            },
            new object[]
            {
                new Node(1),
                1
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                3
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5))),
                3
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                4
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4, new Node(6), new Node(7)), new Node(5)), new Node(3)),
                4
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5, new Node(6), new Node(7)))),
                4
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                4
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6), new Node(7)), new Node(5))),
                4
            },
        };

        [TestCaseSource("_leaves")]
        public void ShouldCountLeavesOfTree(Node node, int expectedNumberOfLeaves)
        {
            TreeProperties.CountLeaves(node).Should().Be(expectedNumberOfLeaves);
        }

        private readonly object[] _height =
        {
            new object[]
            {
                null,
                -1
            },
            new object[]
            {
                new Node(1),
                0
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                1
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                2
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5))),
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4, new Node(6), new Node(7)), new Node(5)), new Node(3)),
                3
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5, new Node(6), new Node(7)))),
                3
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                3
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6), new Node(7)), new Node(5))),
                3
            },
        };

        [TestCaseSource("_height")]
        public void ShouldFindHeigthOfTree(Node node, int expectedHeight)
        {
            TreeProperties.FindHeight(node).Should().Be(expectedHeight);
        }

        private readonly object[] _width =
        {
            new object[]
            {
                null,
                -1
            },
            new object[]
            {
                new Node(1),
                1
            },
            new object[]
            {
                new Node(1, new Node(2), null),
                1
            },
            new object[]
            {
                new Node(1, null, new Node(3)),
                1
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                2
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5))),
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                4
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4, new Node(6), new Node(7)), new Node(5)), new Node(3)),
                2
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5, new Node(6), new Node(7)))),
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                2
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6), new Node(7)), new Node(5))),
                2
            },
        };

        [TestCaseSource("_width")]
        public void ShouldFindWidthOfTree(Node node, int expectedWidth)
        {
            TreeProperties.FindWidth(node).Should().Be(expectedWidth);
        }

        private readonly object[] _depth =
        {
            new object[]
            {
                null,
                1,
                -1
            },
            new object[]
            {
                new Node(1),
                1,
                0
            },
            new object[]
            {
                new Node(1),
                2,
                -1
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                1,
                0
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                2,
                1
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                3,
                1
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                3,
                1
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                4,
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                5,
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                6,
                -1
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5))),
                2,
                1
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5))),
                5,
                2
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5))),
                4,
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                4,
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                5,
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                6,
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                7,
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                3,
                1
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                2,
                1
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                1,
                0
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4, new Node(6), new Node(7)), new Node(5)), new Node(3)),
                5,
                2
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5, new Node(6), new Node(7)))),
                2,
                1
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5, new Node(6), new Node(7)))),
                5,
                2
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5, new Node(6), new Node(7)))),
                7,
                3
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                6,
                3
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                7,
                3
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                4,
                2
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                3,
                1
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6), new Node(7)), new Node(5))),
                7,
                3
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6), new Node(7)), new Node(5))),
                5,
                2
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6), new Node(7)), new Node(5))),
                4,
                2
            },
        };

        [TestCaseSource("_depth")]
        public void ShouldReturnDepthOfNodeInTree(Node node, int key, int depth)
        {
            TreeProperties.FindDepth(node, key).Should().Be(depth);
        }

        private readonly object[] _nodesAtDepth =
        {
            new object[]
            {
                null,
                0,
                null
            },
            new object[]
            {
                new Node(1),
                0,
                new List<int>{1}
            },
            new object[]
            {
                new Node(1),
                2,
                null
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                0,
                new List<int>{1}
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                1,
                new List<int>{2, 3}
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                2,
                null
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                2,
                new List<int>{4, 5}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                3,
                null
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                1,
                new List<int>{2, 3}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3)),
                0,
                new List<int>{1}
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5))),
                3,
                null
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5))),
                2,
                new List<int>{4, 5}
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5))),
                1,
                new List<int>{2, 3}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                3,
                null
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                2,
                new List<int>{4, 5, 6, 7}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                1,
                new List<int>{2, 3}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                0,
                new List<int>{1}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4, new Node(6), new Node(7)), new Node(5)), new Node(3)),
                3,
                new List<int>{6, 7}
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5, new Node(6), new Node(7)))),
                3,
                new List<int>{6, 7}
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5, new Node(6), new Node(7)))),
                2,
                new List<int>{4, 5}
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4), new Node(5, new Node(6), new Node(7)))),
                1,
                new List<int>{2, 3}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                6,
                null
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                3,
                new List<int>{6, 7}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                2,
                new List<int>{4, 5}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5, new Node(6), new Node(7))), new Node(3)),
                1,
                new List<int>{2, 3}
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6), new Node(7)), new Node(5))),
                3,
                new List<int>{6, 7}
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6), new Node(7)), new Node(5))),
                5,
                null
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6), null), new Node(5))),
                3,
                new List<int>{6}
            },
        };

        [TestCaseSource("_nodesAtDepth")]
        public void ShouldReturnNumberOfNodesAtDepth(Node node, int depth, List<int> nodesAtDepth)
        {
            TreeProperties.FindNumberOfNodesAtDepth(node, (uint)depth).Should().Be(nodesAtDepth == null ? 0 : nodesAtDepth.Count);
        }

        [TestCaseSource("_nodesAtDepth")]
        public void ShouldReturnNodesAtDepth(Node node, int depth, List<int> expectedNodesAtDepth)
        {
            var nodesAtDepth = TreeProperties.FindNodesAtDepth(node, (uint)depth);
            if (expectedNodesAtDepth == null)
            {
                nodesAtDepth.Should().BeNull();
            }
            else
            {
                nodesAtDepth.Should().ContainInOrder(nodesAtDepth);
            }
        }

        private readonly object[] _diameter =
        {
            new object[]
            {
                new Node(1, new Node(2), new Node(3, new Node(4, new Node(6, new Node(8), null), new Node(7)), new Node(5, null, new Node(9)))),
                6
            },
            new object[]
            {
                new Node(1, null, new Node(3, new Node(4, null, new Node(6)), new Node(5))),
                4
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), new Node(4, new Node(5), null)), null),
                4
            },
            new object[]
            {
                new Node(1, new Node(2, null, new Node(4, new Node(5), null)), new Node(3, new Node(6), new Node(7))),
                6
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4, null, new Node(8)), new Node(5)), new Node(3, new Node(6, new Node(9), null), new Node(7))),
                7
            },
            new object[]
            {
                null,
                -1
            },
            new object[]
            {
                new Node(1),
                1
            },
            new object[]
            {
                new Node(1, new Node(2), null),
                2
            },
            new object[]
            {
                new Node(1, null, new Node(2)),
                2
            },
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                3
            },
        };

        [TestCaseSource("_diameter")]
        public void ShouldFindDiameterOfTree(Node node, int diameter)
        {
            TreeProperties.FindDiameterOfTree(node).Should().Be(diameter);
        }
    }
}
