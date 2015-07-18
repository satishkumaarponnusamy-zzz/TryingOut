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
            return -1;
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
