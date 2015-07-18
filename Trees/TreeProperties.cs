using System;
using System.Collections.Generic;
using System.Linq;

namespace TryingOut.Trees
{
    public class TreeProperties
    {
        public static int CountLeaves(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.Left == null && node.Right == null)
            {
                return 1;
            }

            return CountLeaves(node.Left) + CountLeaves(node.Right);
        }

        public static int FindHeight(Node node)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.Left == null && node.Right == null)
            {
                return 0;
            }

            return 1 + System.Math.Max(FindHeight(node.Left), FindHeight(node.Right));
        }

        public static int FindWidth(Node node)
        {
            if (node == null)
            {
                return -1;
            }

            var width = 1;
            
            for (uint i = 0; i <= FindHeight(node); i++)
            {
                var nodesAtDepth = FindNumberOfNodesAtDepth(node, i);
                
                if (width < nodesAtDepth)
                {
                    width = nodesAtDepth;
                }
            }

            return width;
        }

        public static List<int> FindNodesAtDepth(Node node, uint depth)
        {
            if (node == null)
            {
                return null;
            }

            if (depth == 0)
            {
                return new List<int>{ node.Data };
            }

            var left = FindNodesAtDepth(node.Left, depth - 1);
            var right = FindNodesAtDepth(node.Right, depth - 1);

            if (left == null)
            {
                return right;
            }

            return right == null ? left : left.Concat(right).ToList();
        }

        public static int FindNumberOfNodesAtDepth(Node node, uint depth)
        {
            if (node == null)
            {
                return 0;
            }

            if (depth == 0)
            {
                return 1;
            }

            return FindNumberOfNodesAtDepth(node.Left, depth - 1) + FindNumberOfNodesAtDepth(node.Right, depth - 1);
        }

        public static int FindDepth(Node node, int key)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.Data == key)
            {
                return 0;
            }

            if (node.Left == null && node.Right == null)
            {
                return -1;
            }

            var leftDepth = FindDepth(node.Left, key);

            if (leftDepth >= 0)
            {
                return 1 + leftDepth;
            }

            var rightDepth = FindDepth(node.Right, key);
            return rightDepth < 0 ? - 1:  1 + rightDepth;
        }
    }
}
