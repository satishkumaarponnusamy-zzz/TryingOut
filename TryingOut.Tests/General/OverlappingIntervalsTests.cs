using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.General;

namespace TryingOut.Tests.General
{
    class OverlappingIntervalsTests
    {
        private readonly OverlappingIntervals _overlappingIntervals = new OverlappingIntervals();

        private readonly object[] _testCases = 
        {
            new object[]
            {
                new List<Interval>
                {
                    new Interval(1, 2),
                    new Interval(5, 6),
                    new Interval(1, 5),
                    new Interval(7, 8),
                    new Interval(1, 6)
                }, 
                new List<int>
                {
                    0, 1, 2, 4
                }
            },
            new object[]
            {
                new List<Interval>
                {
                    new Interval(1, 3),
                    new Interval(2, 4),
                    new Interval(4, 5),
                }, 
                new List<int>
                {
                    0, 1
                }
            },
            new object[]
            {
                new List<Interval>
                {
                    new Interval(1, 3),
                    new Interval(2, 4),
                    new Interval(3, 5),
                }, 
                new List<int>
                {
                    0, 1, 2
                }
            },
            new object[]
            {
                new List<Interval>
                {
                    new Interval(1, 3),
                    new Interval(3, 4),
                }, 
                new List<int>
                {
                    
                }
            }
        };

        [TestCaseSource("_testCases")]
        public void ShouldFindOverlappingIntervalsIndices(List<Interval> intervals, List<int> overlappingIndices)
        {
            intervals.ForEach(x => Console.Write("[{0},{1}], ", x.Start, x.End));

            var result = _overlappingIntervals.FindIndices(intervals);

            Console.WriteLine();
            result.ForEach(x => Console.Write("[{0},{1}], ", intervals[x].Start, intervals[x].End));

            result.ShouldBeEquivalentTo(overlappingIndices);
        }
    }
}
