using System;
using System.Collections.Generic;

namespace TryingOut.Trees
{
    public class Heap<T>
    {
        private readonly List<T> _store;
        private readonly Func<T, T, bool> _comparer;

        public Heap(Func<T, T, bool> comparer)
        {
            _store = new List<T> { default(T) };
            _comparer = comparer;
        }

        public void Insert(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Cannot store null values in heap");
            }

            _store.Add(data);

            for (var i = _store.Count - 1; i/2 >= 1; i = i/2)
            {
                if (_comparer(_store[i], _store[i/2]))
                {
                    Swap(i, i/2);
                }
            }
        }

        private void Swap(int childIndex, int parentIndex)
        {
            var temp = _store[childIndex];
            _store[childIndex] = _store[parentIndex];
            _store[parentIndex] = temp;
        }

        public int GetCount()
        {
            return _store.Count - 1;
        }

        public T GetData(int index)
        {
            return _store[index + 1];
        }

        public T GetRootItem()
        {
            if(_store.Count <= 1)
                throw new ArgumentNullException("No Items in Heap");

            var rootItem = GetData(0);

            var parentIndex = 1;
            var lastItemIndex = _store.Count - 1;

            if (lastItemIndex > parentIndex)
            {
                _store[parentIndex] = _store[lastItemIndex];
            }

            _store.RemoveAt(lastItemIndex);
            lastItemIndex = _store.Count - 1;

            for (; lastItemIndex >= 2 * parentIndex; )
            {
                var leftChildIndex = 2 * parentIndex;
                var rightChildIndex = 2 * parentIndex + 1;

                var itemToCompare = _store[parentIndex];
                var swapIndex = parentIndex;

                var leftChild = _store[leftChildIndex];
                if (_comparer(leftChild, itemToCompare))
                {
                    swapIndex = leftChildIndex;
                    itemToCompare = leftChild;
                }

                if (rightChildIndex <= lastItemIndex)
                {
                    var rightChild = _store[rightChildIndex];
                    if (_comparer(rightChild, itemToCompare))
                    {
                        swapIndex = rightChildIndex;
                    }
                }   
                
                if (swapIndex == parentIndex)
                {
                    break;
                }

                Swap(swapIndex, parentIndex);
                parentIndex = swapIndex;
            }
            
            return rootItem;
        }
    }
}
