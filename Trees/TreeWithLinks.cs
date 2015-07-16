using System.Collections.Generic;

namespace TryingOut.Trees
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node ToTheRight { get; set; }

        public Node()
        {
            Data = int.MinValue;
            Left = null;
            Right = null;
            ToTheRight = null;
        }

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
            ToTheRight = null;
        }

        public Node(int data, Node left, Node right)
        {
            Data = data;
            Left = left;
            Right = right;
            ToTheRight = null;
        }

        public Node(int data, Node left, Node right, Node toTheRight)
        {
            Data = data;
            Left = left;
            Right = right;
            ToTheRight = null;
        }
    }

    public class TreeWithLinks
    {
        public Node FillMissingLinksUsingConstantSpace(Node root)
        {
            //traverse the tree
            //for each node find the depth
            //find the ancestor of that node
            //find an element to the right of ancestor at given depth
            
            for (var i = 0; i <= Height(root); i++)
            {
                var depth = i;
                //findAncestor()
            }
            
            return root;
        }

        public int Height(Node node)
        {
            if (node == null)
            {
                return -1;
            }

            return 1 + System.Math.Max(Height(node.Left), Height(node.Right));
        }

        public static Node FillMissingLinksUsingExtraSpace(Node root)
        {
            if (root == null)
            {
                return null;
            }

            var parent = new Queue<Node>();
            var children = new Queue<Node>();

            parent.Enqueue(root);
            while (parent.Count > 0)
            {
                var node = parent.Dequeue();

                if (node.Left != null)
                {
                    children.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    children.Enqueue(node.Right);
                }

                if (node.ToTheRight == null && parent.Count > 0)
                {
                    var toTheRight = parent.Peek();
                    node.ToTheRight = toTheRight;
                }

                if (parent.Count == 0)
                {
                    parent = children;
                    children = new Queue<Node>();
                }
            }

            return root;
        }
    }
}
