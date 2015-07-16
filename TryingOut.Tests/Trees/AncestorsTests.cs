using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.Trees;

namespace TryingOut.Tests.Trees
{
    [TestFixture]
    class AncestorsTests
    {
        [Test]
        public void ShouldReturnNullForEmptyTree()
        {
            Ancestors.FindAncestorsUsingRecursion(null, 0).Should().BeNull();
        }

        [Test]
        public void ShouldReturnNullForWhenKeyIsNotInTree()
        {
            Ancestors.FindAncestorsUsingRecursion(new Node(5), 0).Should().BeNull();
        }

        private readonly object[] _testData =
        {
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                3,
                new List<int> {1}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), null), null),
                3,
                new List<int> {2, 1}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), null), null),
                2,
                new List<int> {1}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), new Node(4)), null),
                3,
                new List<int> {2, 1}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), new Node(4)), null),
                4,
                new List<int> {2, 1}
            },
            new object[]
            {
                new Node(1, null, new Node(2, null, new Node(3))),
                2,
                new List<int> {1}
            },
            new object[]
            {
                new Node(1, null, new Node(2, null, new Node(3))),
                3,
                new List<int> {2, 1}
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), null)),
                2,
                new List<int> {1}
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), null)),
                3,
                new List<int> {2, 1}
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                4,
                new List<int> {2, 1}
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                3,
                new List<int> {2, 1}
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                2,
                new List<int> {1}
            }
        };

        [TestCaseSource("_testData")]
        public void ShouldReturnAncestorsForKey(Node node, int key, List<int> expectedAncestors)
        {
            Ancestors.FindAncestorsUsingRecursion(node, key).Should().ContainInOrder(expectedAncestors);
        }

        private readonly object[] _testData1 =
        {
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                5
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), null), null),
                5
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), null), null),
                5
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), new Node(4)), null),
                5
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), new Node(4)), null),
                5
            },
            new object[]
            {
                new Node(1, null, new Node(2, null, new Node(3))),
                5
            },
            new object[]
            {
                new Node(1, null, new Node(2, null, new Node(3))),
                5
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), null)),
                5
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), null)),
                5
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                5
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                5
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                5
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                5
            },
        };

        [TestCaseSource("_testData1")]
        public void ShouldReturnNullWhenKeyNotFound(Node node, int key)
        {
            Ancestors.FindAncestorsUsingRecursion(node, key).Should().BeNull();
        }

        private readonly object[] _testData2 =
        {
            new object[]
            {
                new Node(1, new Node(2), new Node(3)),
                1
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), null), null),
                1
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), null), null),
                1
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), new Node(4)), null),
                1
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(3), new Node(4)), null),
                1
            },
            new object[]
            {
                new Node(1, null, new Node(2, null, new Node(3))),
                1
            },
            new object[]
            {
                new Node(1, null, new Node(2, null, new Node(3))),
                1
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), null)),
                1
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), null)),
                1
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                1
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                1
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                1
            },
            new object[]
            {
                new Node(1, null, new Node(2, new Node(3), new Node(4))),
                1
            },
        };

        [TestCaseSource("_testData2")]
        public void ShouldReturnNoAncestorsForWhenKeyIsRootNode(Node node, int key)
        {
            Ancestors.FindAncestorsUsingRecursion(node, key).Should().BeEmpty();
        }
    }
}
