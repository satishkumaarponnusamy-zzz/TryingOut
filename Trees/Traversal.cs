using System.Collections.Generic;

namespace TryingOut.Trees
{
    public class Traversal
    {
        public static Node ConstructTreeFrom(List<int> inOrder, List<int> postOrder)
        {
            return null;
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
