using System;
using System.Collections.Generic;

namespace TryingOut.Trees
{
    public class Traversal
    {
        public static Node ConstructBinaryTreeFromPreAndInorder(List<int> preOrder, List<int> inOrder)
        {
            if (inOrder == null || preOrder == null || inOrder.Count == 0 || preOrder.Count == 0 || inOrder.Count != preOrder.Count)
            {
                throw new ArgumentException("Null or empty or number of nodes not matching");
            }

            var mapInOrderDataToIndex = new Dictionary<int, int>();
            for (var i = 0; i < inOrder.Count; i++)
            {
                mapInOrderDataToIndex.Add(inOrder[i], i);
            }

            //return ConstructTreeFromPreAndInorder(preOrder, 0, preOrder.Count - 1, inOrder, 0, inOrder.Count - 1, mapInOrderDataToIndex);
            return ConstructBinaryTreeFromPreAndInorder(preOrder, 0, 0, inOrder.Count - 1, mapInOrderDataToIndex);
        }

        //private static Node ConstructTreeFromPreAndInorder(List<int> preOrder, int preOrderStartIndex, int preOrderEndIndex, List<int> inOrder, int inOrderStartIndex, int inOrderEndIndex, Dictionary<int, int> mapOfInOrderDataToIndex)
        //{
        //    if (inOrderStartIndex > inOrderEndIndex)
        //    {
        //        return null;
        //    }

        //    var node = new Node(preOrder[preOrderStartIndex++]);

        //    var inOrderRootIndex = mapOfInOrderDataToIndex[node.Data];

        //    node.Left = ConstructTreeFromPreAndInorder(preOrder, preOrderStartIndex, preOrderStartIndex + inOrderRootIndex - 1 - inOrderStartIndex,
        //                                               inOrder, inOrderStartIndex, inOrderRootIndex - 1, mapOfInOrderDataToIndex);

        //    node.Right = ConstructTreeFromPreAndInorder(preOrder, preOrderStartIndex + inOrderRootIndex - 1 - inOrderStartIndex + 1, preOrderEndIndex, 
        //                                                inOrder, inOrderRootIndex + 1, inOrderEndIndex, mapOfInOrderDataToIndex);

        //    return node;
        //}

        private static Node ConstructBinaryTreeFromPreAndInorder(List<int> preOrder, int preOrderStartIndex, int inOrderStartIndex, int inOrderEndIndex, Dictionary<int, int> mapOfInOrderDataToIndex)
        {
            if (inOrderStartIndex > inOrderEndIndex)
            {
                return null;
            }

            var node = new Node(preOrder[preOrderStartIndex++]);

            var inOrderRootIndex = mapOfInOrderDataToIndex[node.Data];

            node.Left = ConstructBinaryTreeFromPreAndInorder(preOrder, preOrderStartIndex, inOrderStartIndex, inOrderRootIndex - 1, mapOfInOrderDataToIndex);

            node.Right = ConstructBinaryTreeFromPreAndInorder(preOrder, preOrderStartIndex + inOrderRootIndex - inOrderStartIndex, inOrderRootIndex + 1, inOrderEndIndex, mapOfInOrderDataToIndex);

            return node;
        }

        public static Node ConstructBinaryTreeFromInOrderAndPostOrder(List<int> inOrder, List<int> postOrder)
        {
            if (inOrder == null || postOrder == null || inOrder.Count == 0 || postOrder.Count == 0 || inOrder.Count != postOrder.Count)
            {
                throw new ArgumentException("Null or empty or number of nodes not matching");
            }

            var mapInOrderDataToIndex = new Dictionary<int, int>();
            for (var i = 0; i < inOrder.Count; i++)
            {
                mapInOrderDataToIndex.Add(inOrder[i], i);
            }

            return ConstructBinaryTreeFromInorderAndPostOrder(postOrder, postOrder.Count - 1, 0, inOrder.Count - 1, mapInOrderDataToIndex);
        }

        private static Node ConstructBinaryTreeFromInorderAndPostOrder(List<int> postOrder, int postOrderEndIndex, int inOrderStartIndex, int inOrderEndIndex, Dictionary<int, int> mapInOrderDataToIndex)
        {
            if (inOrderStartIndex > inOrderEndIndex)
            {
                return null;
            }

            var node = new Node(postOrder[postOrderEndIndex--]);
            var inOrderRootIndex = mapInOrderDataToIndex[node.Data];

            node.Left = ConstructBinaryTreeFromInorderAndPostOrder(postOrder, postOrderEndIndex - (inOrderEndIndex - inOrderRootIndex), inOrderStartIndex, inOrderRootIndex - 1, mapInOrderDataToIndex);
            node.Right = ConstructBinaryTreeFromInorderAndPostOrder(postOrder, postOrderEndIndex, inOrderRootIndex + 1, inOrderEndIndex, mapInOrderDataToIndex);

            return node;
        }

        public static List<int> PreOrderWithoutRecursion(Node node)
        {
            if (node == null)
            {
                return null;
            }

            var stack = new Stack<Node>();
            var preOrder = new List<int>();

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    preOrder.Add(node.Data);

                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                }
            }
            return preOrder;
        }

        public static List<int> InOrderWithoutRecursion(Node node)
        {
            if (node == null)
            {
                return null;
            }

            var stack = new Stack<Node>();
            var inOrder = new List<int>();

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    inOrder.Add(node.Data);
                    node = node.Right;
                }
            }
            return inOrder;
        }

        public static List<int> PostOrderWithoutRecursion(Node node)
        {
            if (node == null)
            {
                return null;
            }

            var stack = new Stack<Node>();
            var postOrder = new List<int>();
            var lastNodeVisited = new Node(int.MinValue);

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    var peekNode = stack.Peek();

                    if (peekNode.Right != null && peekNode.Right.Data != lastNodeVisited.Data)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        postOrder.Add(peekNode.Data);
                        lastNodeVisited = stack.Pop();
                        node = null;
                    }

                }
            }
            return postOrder;
        }
    }
}
