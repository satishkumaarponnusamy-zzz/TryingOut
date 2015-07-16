using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.Trees;

namespace TryingOut.Tests.Trees
{
    [TestFixture]
    class TreeWithLinksTests
    {
        [Test]
        public void ShouldReturnNullForEmptyTree()
        {
            TreeWithLinks.FillMissingLinksUsingExtraSpace(null).Should().BeNull();
        }

        [Test]
        public void ShouldReturnRootNodeForTreeWithJustRootAndNoChildrens()
        {
            var root = new Node();
            TreeWithLinks.FillMissingLinksUsingExtraSpace(root).Should().Be(root);
        }

        [Test]
        public void ShouldLinkLeftNodeToRightNodeForTreeWithRootThatHasTwoChildrens()
        {
            var root = new Node(1, new Node(), new Node());
            
            TreeWithLinks.FillMissingLinksUsingExtraSpace(root).Should().Be(root);
            
            root.ToTheRight.Should().BeNull();
            root.Left.ToTheRight.Should().Be(root.Right);
            root.Right.ToTheRight.Should().BeNull();
        }

        [Test]
        public void ShouldNotLinkForTreeWithRootAndLeftNode()
        {
            var root = new Node(1, new Node(), null);

            TreeWithLinks.FillMissingLinksUsingExtraSpace(root).Should().Be(root);

            root.ToTheRight.Should().BeNull();
            root.Left.ToTheRight.Should().BeNull();
        }

        [Test]
        public void ShouldNotLinkForTreeWithRootAndRightNode()
        {
            var root = new Node(1, null, new Node());

            TreeWithLinks.FillMissingLinksUsingExtraSpace(root).Should().Be(root);

            root.ToTheRight.Should().BeNull();
            root.Right.ToTheRight.Should().BeNull();
        }

        private readonly object[] _testData =
        {
            new object[]
            {
                new Node(1, new Node(2, new Node(4), null), new Node(3, null, new Node(5))),
                new Dictionary<int, Node>
                {
                    {1, null},
                    {2, new Node(3)},
                    {3, null},
                    {4, new Node(5)},
                    {5, null}
                }
            },
            new object[]
            {
                new Node(1, new Node(2, new Node(4), null), new Node(3, null, null)),
                new Dictionary<int, Node>
                {
                    {1, null},
                    {2, new Node(3)},
                    {3, null},
                    {4, null}
                }
            }
        };

        [TestCaseSource("_testData")]
        public void ShouldFillMissingLinks(Node root, Dictionary<int, Node> expectedToTheRight)
        {
            TreeWithLinks.FillMissingLinksUsingExtraSpace(root);
            ThenMissingLinksAreFilled(root, expectedToTheRight);
        }

        private void ThenMissingLinksAreFilled(Node node, Dictionary<int, Node> expectedToTheRight)
        {
            if (node != null)
            {
                var toTheRight = expectedToTheRight[node.Data];
                if (toTheRight != null)
                {
                    node.ToTheRight.Should().NotBeNull();
                    node.ToTheRight.Data.Should().Be(toTheRight.Data);
                }
                else
                {
                    node.ToTheRight.Should().BeNull();
                }
                ThenMissingLinksAreFilled(node.Left, expectedToTheRight);
                ThenMissingLinksAreFilled(node.Right, expectedToTheRight);
            }
        }
    }
}
