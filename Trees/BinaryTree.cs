using System;

namespace TryingOut.Trees
{
    public class BinaryTree<T>
    {
        private Node<T> _root;
        private readonly Func<T, T, bool> _comparer;

        public BinaryTree(Func<T, T, bool> comparer)
        {
            _comparer = comparer;
        }

        public Node<T> GetRoot()
        {
            return _root;
        }

        public Node<T> Insert(T data)
        {
            _root = InsertHelper(_root, data);

            return _root;
        }

        public void Print()
        {
            PrintHelper(_root);
        }

        private static void PrintHelper(Node<T> node)
        {
            if(node == null)
                return;

            Console.WriteLine(node.Data);
            PrintHelper(node.Left);
            PrintHelper(node.Right);
        }

        private Node<T> InsertHelper(Node<T> node, T data)
        {
            if (node == null)
            {
                node = new Node<T> {Data = data};
            }
            else
            {
                if (_comparer(data, node.Data))
                {
                    node.Left = InsertHelper(node.Left, data);
                }
                else
                {
                    node.Right = InsertHelper(node.Right, data);
                }
            }
            return node;
        }
    }
}