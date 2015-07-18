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
                0
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
    }
}
