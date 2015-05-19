using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.DP;

namespace TryingOut.Tests.DP
{
    class SubArrayWithLargestSumTests
    {
        private object[] _testCases = new[]
        {
            new object[]
            {
                new List<int>{1, 2, 3, 0, 7, 2},
                new List<int>{7, 2}
            },
            new object[]
            {
                new List<int>{10, 0, 7, 4, 0, 11},
                new List<int>{11}
            }
        };

        private readonly SubArrayWithLargestSum _subArrayWithLargestSum = new SubArrayWithLargestSum();

        [TestCaseSource("_testCases")]
        public void ShouldReturnSubArrayWithLargestSum(List<int> array, List<int> subArray)
        {
            Console.WriteLine("Array: ");
            array.ForEach(x => Console.Write(x + ","));

            var result = _subArrayWithLargestSum.Find(array);

            Console.WriteLine("\nSubArray: ");
            result.ForEach(x => Console.Write(x + ","));
            
            result.ShouldBeEquivalentTo(subArray);
        }
    }
}
