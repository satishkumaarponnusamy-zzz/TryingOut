using System.Collections.Generic;
using System.Linq;

namespace TryingOut.Trees
{
    public class Ancestors
    {
        public static List<int> FindAncestorsUsingRecursion(Node node, int key)
        {
            if (node == null)
            {
                return null;
            }

            List<int> result;

            FindAncestorsUsingRecursionHelper(node, key, out result);

            return result;
        }

        private static bool FindAncestorsUsingRecursionHelper(Node node, int key, out List<int> result)
        {
            result = null;

            if (node == null)
            {
                return false;
            }

            if (node.Data == key)
            {
                result = new List<int>();
                return true;
            }

            if (FindAncestorsUsingRecursionHelper(node.Left, key, out result)
                || FindAncestorsUsingRecursionHelper(node.Right, key, out result))
            {
                result.Add(node.Data);
                return true;
            }

            return false;
        }

        public static List<int> FindAncestorsWithoutRecursion(Node node, int key)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data == key)
            {
                return new List<int>();
            }

            var stack = new Stack<Node>();
            var found = false;

            while (true)
            {
                while (node != null && node.Data != key)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                if (node != null && node.Data == key)
                {
                    found = true;
                    break;
                }

                if (stack.Count == 0 && node == null)
                {
                    break;
                }

                if (stack.Peek().Right == null)
                {
                    node = stack.Pop();

                    while (stack.Count != 0 && stack.Peek().Right != null && stack.Peek().Right.Data == node.Data)
                    {
                        node = stack.Pop();
                    }
                }
                node = stack.Count == 0 ? null : stack.Peek().Right;
            }

            if (found)
            {
                return stack.Select(x => x.Data).ToList();
            }
            return null;
        }
    }
}
