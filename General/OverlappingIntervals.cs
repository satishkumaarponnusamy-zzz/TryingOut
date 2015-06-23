using System;
using System.Collections.Generic;
using System.Linq;

namespace TryingOut.General
{
    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }
    }

    public class OverlappingIntervals
    {
        public List<int> FindIndices(List<Interval> intervals)
        {
            var rangeMap = new Dictionary<int, int>();
            var overlappingIntervals = new HashSet<int>();

            for (var index = 0; index < intervals.Count; index++)
            {
                int rangeIndex;
                var addRange = false;
                if (rangeMap.TryGetValue(intervals[index].Start, out rangeIndex))
                {
                    overlappingIntervals.Add(rangeIndex);
                    overlappingIntervals.Add(index);
                }
                else
                {
                    addRange = true;
                }

                if (rangeMap.TryGetValue(intervals[index].End, out rangeIndex))
                {
                    overlappingIntervals.Add(rangeIndex);
                    overlappingIntervals.Add(index);
                }
                else
                {
                    addRange = true;
                }

                if (addRange)
                {
                    AddRangeAndIndex(intervals[index], rangeMap, index);
                }
            }

            return overlappingIntervals.ToList();
        }

        private static void AddRangeAndIndex(Interval interval, IDictionary<int, int> rangeMap, int index)
        {
            for (var i = interval.Start; i < interval.End; i++)
            {
                if (!rangeMap.ContainsKey(i))
                {
                    rangeMap.Add(i, index);
                }
            }
        }
    }
}
