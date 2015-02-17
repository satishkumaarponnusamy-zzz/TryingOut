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
            return _store.Count;
        }

        public T GetData(int index)
        {
            return _store[index + 1];
        }
    }
}
