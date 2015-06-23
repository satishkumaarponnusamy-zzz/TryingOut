using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.Math;

namespace TryingOut.Tests.Math
{
    class MedianOfSortedArraysTests
    {
        private readonly object[] _testCases = {
            new object[]
            {
                null,
                new List<int> {1,2,3},
                2
            },
            new object[]
            {
                new List<int> {1,2,3},
                null,
                2
            },
            new object[]
            {
                new List<int> {1,1,1},
                new List<int> {1,2,3},
                1
            },
            new object[]
            {
                new List<int> {1},
                new List<int> {1,2},
                1
            },
            new object[]
            {
                new List<int> {3},
                new List<int> {1,2},
                2
            },
            new object[]
            {
                new List<int> {9},
                new List<int> {1,2,3,4,5,6,7,8},
                5
            },
            new object[]
            {
                new List<int> {9},
                new List<int> {1,2,3,4,5,6,7},
                4
            },
            new object[]
            {
                new List<int> {1},
                new List<int> {1},
                1
            },
            new object[]
            {
                new List<int> {3,4},
                new List<int> {1,2},
                2
            },
            new object[]
            {
                new List<int> {3,4},
                new List<int> {1,2,5,6},
                3
            },
            new object[]
            {
                new List<int> {3,4},
                new List<int> {1,2,5,6,7},
                4
            },
            new object[]
            {
                new List<int>{3, 7, 12, 15, 18},
                new List<int>{1, 2, 5, 10, 11, 12, 13, 19},
                11
            },
            new object[]
            {
                new List<int> {9,10,11,12,13},
                new List<int> {1,2,3,4,5,6,7,8},
                7
            }
        };

        [Test]
        public void ShouldThrowExceptionWhenBothArraysAreNull()
        {
            Action a = () => new MedianOfSortedArray().Get(null, null);
            a.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ShouldThrowExceptionWhenOneArrayIsNullAndOtherArrayIsEmpty()
        {
            Action a = () => new MedianOfSortedArray().Get(null, new List<int>());
            a.ShouldThrow<ArgumentException>().WithMessage("Empty array");

            a = () => new MedianOfSortedArray().Get(null, new List<int>());
            a.ShouldThrow<ArgumentException>().WithMessage("Empty array");
        }

        [Test]
        public void ShouldReturnFirstElementAsMedianWhenOneArrayIsNullThereIsOnlyOneElementInBothArray()
        {
            new MedianOfSortedArray().Get(null, new List<int>{1}).Should().Be(1);
            new MedianOfSortedArray().Get(new List<int>(), new List<int> { 1 }).Should().Be(1);
            new MedianOfSortedArray().Get(new List<int> { 2 }, null).Should().Be(2);
            new MedianOfSortedArray().Get(new List<int> { 2 }, new List<int>()).Should().Be(2);
        }

        [TestCaseSource("_testCases")]
        public void ShouldGetMedian(List<int> array1, List<int> array2, int expectedMedian)
        {
            Console.WriteLine();
            if (array1 != null)
            {
                Console.WriteLine("Array1: ");
                foreach (var i in array1)
                {
                    Console.Write(i);
                    Console.Write(',');
                }
            }
            else
            {
                Console.WriteLine("Array1 is null");
            }

            Console.WriteLine();
            if (array2 != null)
            {
                Console.WriteLine("Array2: ");
                foreach (var i in array2)
                {
                    Console.Write(i);
                    Console.Write(',');
                }
            }
            else
            {
                Console.WriteLine("Array2 is null");
            }

            new MedianOfSortedArray().Get(array1, array2).Should().Be(expectedMedian);
        }
    }
}
