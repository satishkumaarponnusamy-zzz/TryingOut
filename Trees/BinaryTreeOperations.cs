using System;

namespace TryingOut.Trees
{
    public class BinaryTreeOperations<T>
    {
        private readonly T _minValue;
        private readonly T _maxValue;
        private readonly Func<T, T, bool> _comparer;
        private Func<T, T> _incrementer;
        private Func<T, T, T> _decrementer;

        BinaryTreeOperations(T minValue, T maxValue, Func<T, T, bool> comparer)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _comparer = comparer;
        }

        public bool IsBinarySearchTree(BinaryTree<T> tree, Func<T, T> incrementer)
        {
            _incrementer = incrementer;
            return IsBinarySearchTreeUtil(tree.GetRoot(), _minValue, _maxValue);
        }

        public bool IsTherePathToLeafWithSum(BinaryTree<T> tree, T sum, Func<T, T, T> decrementer)
        {
            _decrementer = decrementer;
            return IsTherePathToLeafWithSumUtil(tree.GetRoot(), sum);
        }

        private bool IsTherePathToLeafWithSumUtil(Node<T> node, T sum)
        {
            if (node == null)
            {
                return _comparer(sum, default(T));
            }

            var decrementedValue = _decrementer(node.Data, sum);

            return IsTherePathToLeafWithSumUtil(node.Left, decrementedValue) || IsTherePathToLeafWithSumUtil(node.Right, decrementedValue);
        }

        private bool IsBinarySearchTreeUtil(Node<T> node, T minValue, T maxValue)
        {
            if (node == null)
            {
                return true;
            }

            if (_comparer(node.Data, minValue) || _comparer(maxValue, node.Data))
            {
                return false;
            }

            return IsBinarySearchTreeUtil(node.Left, minValue, node.Data) && IsBinarySearchTreeUtil(node.Right, _incrementer(node.Data), maxValue);
        }
    }
}