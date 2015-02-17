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
            var heap = new Heap<Movie>(new MaxMovieRatingComparer());
            
            heap.Insert(new Movie("A", 1.2));
            heap.Insert(new Movie("B", 2));
            heap.Insert(new Movie("C", 1));
            
            heap.GetCount().Should().Be(3 + 1);
        }

        [Test]
        public void ShouldStoreDataAsMinHeap()
        {
            var heap = new Heap<Movie>(new MinMovieRatingComparer());

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
            var heap = new Heap<Movie>(new MaxMovieRatingComparer());

            heap.Insert(new Movie("A", 1.2));
            heap.Insert(new Movie("B", 2));
            heap.Insert(new Movie("C", 1));

            heap.GetData(0).Name.Should().Be("B");
            heap.GetData(1).Name.Should().Be("A");
            heap.GetData(2).Name.Should().Be("C");
        }
    }
}
