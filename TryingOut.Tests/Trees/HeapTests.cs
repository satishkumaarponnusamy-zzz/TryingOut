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
            
            heap.GetCount().Should().Be(3 + 1);
        }

        [Test]
        public void ShouldStoreDataAsMinHeap()
        {
            var heap = new Heap<Movie>(MovieComparer.InverseRating);

            heap.Insert(new Movie("A", 1.2));
            heap.Insert(new Movie("B", 2));
            heap.Insert(new Movie("C", 1));

            heap.GetData(0).Name.Should().Be("C");
            heap.GetData(1).Name.Should().Be("B");
            heap.GetData(2).Name.Should().Be("A");
        }

        [Test]
        public void ShouldStoreDataAsMaxHeap()
        {
            var heap = new Heap<int>((x,y) => x > y);

            heap.Insert(2);
            heap.Insert(1);
            heap.Insert(3);

            heap.GetData(0).Should().Be(3);
            heap.GetData(1).Should().Be(1);
            heap.GetData(2).Should().Be(2);
        }
    }
}
