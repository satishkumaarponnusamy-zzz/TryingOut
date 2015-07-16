using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.Trees;

namespace TryingOut.Tests.Trees
{
    [TestFixture]
    class TraversalTests
    {
        [Test]
        public void ShouldReturnNullWhenTreeIsEmpty()
        {
            Traversal.PreOrderWithoutRecursion(null).Should().BeNull();
            Traversal.InOrderWithoutRecursion(null).Should().BeNull();
            Traversal.PostOrderWithoutRecursion(null).Should().BeNull();
        }

        private readonly object[] _testData =
        {
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                new List<int> {1, 2, 4, 5, 3, 6, 7},
                new List<int> {4, 2, 5, 1, 6, 3, 7},
                new List<int> {4, 5, 2, 6, 7, 3, 1}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), null), null),
                new List<int> {1, 2, 4},
                new List<int> {4, 2, 1},
                new List<int> {4, 2, 1},
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), null),
                new List<int> {1, 2, 4, 5},
                new List<int> {4, 2, 5, 1},
                new List<int> {4, 5, 2, 1},
            },
            new object[]
            {
                new Node(1, null, new Node(3, null, new Node(7))),
                new List<int> {1, 3, 7},
                new List<int> {1, 3, 7},
                new List<int> {7, 3, 1},
            },
            new object[]
            {
                new Node(1, null, new Node(3, new Node(6), new Node(7))),
                new List<int> {1, 3, 6, 7},
                new List<int> {1, 6, 3, 7},
                new List<int> {6, 7, 3, 1},
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), null), new Node(3, null, new Node(7))),
                new List<int> {1, 2, 4, 3, 7},
                new List<int> {4, 2, 1, 3, 7},
                new List<int> {4, 2, 7, 3, 1},
            },
            new object[]
            {
                new Node(1, new Node(2, null, new Node(5)), new Node(3, new Node(6), null)),
                new List<int> {1, 2, 5, 3, 6},
                new List<int> {2, 5, 1, 6, 3},
                new List<int> {5, 2, 6, 3, 1},
            }
        };

        [TestCaseSource("_testData")]
        public void ShouldReturnTraversals(Node root, List<int> preOrder, List<int> inOrder, List<int> postOrder)
        {
            Traversal.PreOrderWithoutRecursion(root).Should().ContainInOrder(preOrder);
            Traversal.InOrderWithoutRecursion(root).Should().ContainInOrder(inOrder);
            Traversal.PostOrderWithoutRecursion(root).Should().ContainInOrder(postOrder);
        }
    }
}
