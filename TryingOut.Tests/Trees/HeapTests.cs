using FluentAssertions;
using NUnit.Framework;
using TryingOut.Trees;

namespace TryingOut.Tests.Trees
{
    [TestFixture]
    class HeapTests
    {
        [Test]
        public void ShouldInsertDataIntoHeap()
        {
            var heap = new Heap<Movie>(MovieComparer.Name);
            
            heap.Insert(new Movie("A", 1.2));
            heap.Insert(new Movie("B", 2));
            heap.Insert(new Movie("C", 1));
            
            heap.GetCount().Should().Be(3);
        }

        [Test]
        public void ShouldStoreDataAsMinHeap()
        {
            var heap = new Heap<Movie>(MovieComparer.InverseRating);

            heap.Insert(new Movie("A", 1.2));
            heap.Insert(new Movie("B", 2));
            heap.Insert(new Movie("C", 1));

            var result = new[] {"C", "B", "A"};

            for (var i = 0; i < heap.GetCount(); i++)
            {
                heap.GetData(i).Name.Should().Be(result[i]);
            }
        }

        [Test]
        public void ShouldStoreNullableTypes()
        {
            var heap = new Heap<int?>((x, y) => x > y);

            heap.Insert(2);
            heap.Insert(1);

            heap.GetCount().Should().Be(2);
        }

        [Test]
        public void ShouldStoreDataAsMaxHeap()
        {
            var heap = new Heap<int>((x,y) => x > y);

            InsertDataIntoHeap(heap);

            var result = new[] {20, 10, 15, 9, 10, 12, 5, 1, 4, 3, 6, 2, 8};

            for (var i = 0; i < heap.GetCount(); i++)
            {
                heap.GetData(i).Should().Be(result[i]);
            }
        }

        private static void InsertDataIntoHeap(Heap<int> heap)
        {
            heap.Insert(2);
            heap.Insert(1);
            heap.Insert(3);
            heap.Insert(5);
            heap.Insert(4);
            heap.Insert(10);
            heap.Insert(8);
            heap.Insert(9);
            heap.Insert(10);
            heap.Insert(15);
            heap.Insert(6);
            heap.Insert(12);
            heap.Insert(20);
        }

        [Test]
        public void ShouldGetRootItemAndStillHaveHeapProperty()
        {
            var heap = new Heap<int>((x, y) => x > y);

            InsertDataIntoHeap(heap);

            var item = heap.GetRootItem();
            item.Should().Be(20);

            var result = new[] { 15, 10, 12, 9, 10, 8, 5, 1, 4, 3, 6, 2 };
            
            for (var i = 0; i < heap.GetCount(); i++)
            {
                heap.GetData(i).Should().Be(result[i]);
            }

            item = heap.GetRootItem();
            item.Should().Be(15);

            result = new[] { 12, 10, 8, 9, 10, 2, 5, 1, 4, 3, 6 };

            for (var i = 0; i < heap.GetCount(); i++)
            {
                heap.GetData(i).Should().Be(result[i]);
            }

            item = heap.GetRootItem();
            item.Should().Be(12);

            result = new[] { 10, 10, 8, 9, 6, 2, 5, 1, 4, 3 };

            for (var i = 0; i < heap.GetCount(); i++)
            {
                heap.GetData(i).Should().Be(result[i]);
            }
        }
    }
}
