using System;
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

        private readonly object[] _testData1 =
        {
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                new List<int> {1, 2, 4, 5, 3, 6, 7},
                new List<int> {4, 2, 5, 1, 6, 3, 7}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), null), null),
                new List<int> {1, 2, 4},
                new List<int> {4, 2, 1},
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), null),
                new List<int> {1, 2, 4, 5},
                new List<int> {4, 2, 5, 1},
            },
            new object[]
            {
                new Node(1, null, new Node(3, null, new Node(7))),
                new List<int> {1, 3, 7},
                new List<int> {1, 3, 7},
            },
            new object[]
            {
                new Node(1, null, new Node(3, new Node(6), new Node(7))),
                new List<int> {1, 3, 6, 7},
                new List<int> {1, 6, 3, 7},
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), null), new Node(3, null, new Node(7))),
                new List<int> {1, 2, 4, 3, 7},
                new List<int> {4, 2, 1, 3, 7},
            },
            new object[]
            {
                new Node(1, new Node(2, null, new Node(5)), new Node(3, new Node(6), null)),
                new List<int> {1, 2, 5, 3, 6},
                new List<int> {2, 5, 1, 6, 3},
            }
        };

        [TestCaseSource("_testData1")]
        public void ShouldConstructGivenTreeFromPreOrderAndInorderTraversal(Node root, List<int> preOrder, List<int> inOrder)
        {
            var node = Traversal.ConstructBinaryTreeFromPreAndInorder(preOrder, inOrder);
            ThenVerifyTreeMatches(root, node).Should().BeTrue();
        }

        private readonly object[] _testData2 =
        {
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), new Node(3, new Node(6), new Node(7))),
                new List<int> {4, 2, 5, 1, 6, 3, 7},
                new List<int> {4, 5, 2, 6, 7, 3, 1}
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), null), null),
                new List<int> {4, 2, 1},
                new List<int> {4, 2, 1},
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), new Node(5)), null),
                new List<int> {4, 2, 5, 1},
                new List<int> {4, 5, 2, 1},
            },
            new object[]
            {
                new Node(1, null, new Node(3, null, new Node(7))),
                new List<int> {1, 3, 7},
                new List<int> {7, 3, 1},
            },
            new object[]
            {
                new Node(1, null, new Node(3, new Node(6), new Node(7))),
                new List<int> {1, 6, 3, 7},
                new List<int> {6, 7, 3, 1},
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), null), new Node(3, null, new Node(7))),
                new List<int> {4, 2, 1, 3, 7},
                new List<int> {4, 2, 7, 3, 1},
            },
            new object[]
            {
                new Node(1, new Node(2, null, new Node(5)), new Node(3, new Node(6), null)),
                new List<int> {2, 5, 1, 6, 3},
                new List<int> {5, 2, 6, 3, 1},
            }
        };

        [TestCaseSource("_testData2")]
        public void ShouldConstructGivenTreeFromInOrderAndPostorderTraversal(Node root, List<int> inOrder, List<int> postOrder)
        {
            var node = Traversal.ConstructBinaryTreeFromInOrderAndPostOrder(inOrder, postOrder);
            ThenVerifyTreeMatches(root, node).Should().BeTrue();
        }

        private bool ThenVerifyTreeMatches(Node node1, Node node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }

            if (node1 != null && node2 != null && node1.Data == node2.Data)
            {
                Console.WriteLine("A" + node1.Data + " E "+ node2.Data);
                return ThenVerifyTreeMatches(node1.Left, node2.Left) && ThenVerifyTreeMatches(node1.Right, node2.Right);
            }

            return false;
        }
    }
}
