using System;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.Trees;

namespace TryingOut.Tests.Trees
{
    class BinaryTreeTests
    {
        [Test]
        public void ShouldCreateBinaryTree()
        {
            var binaryTree = new BinaryTree<int>((x, y) => x < y);
            binaryTree.Should().NotBeNull();
        }

        [Test]
        public void ShouldInsertIntoBinaryTree()
        {
            var binaryTree = new BinaryTree<int>((x, y) => x < y);
            binaryTree.Insert(3);
            binaryTree.Insert(2);
            binaryTree.Insert(1);

            binaryTree.Should().NotBeNull();
        }

        [Test]
        public void ShouldPrintBinaryTree()
        {
            var binaryTree = new BinaryTree<int>((x, y) => x < y);
            binaryTree.Insert(3);
            binaryTree.Insert(2);
            binaryTree.Insert(1);

            binaryTree.Should().NotBeNull();
            Action a = () => binaryTree.Print();
            a.ShouldNotThrow<Exception>();
        }
    }
}
