using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TryingOut.Math
{
    public class MedianOfSortedArray
    {
        public int Get(List<int> array1, List<int> array2)
        {
            if (array1 == null && array2 == null)
            {
                throw new ArgumentNullException();
            }

            if (array1 == null || array1.Count == 0)
            {
                return GetMedian(array2, 0, array2.Count - 1);
            }

            if (array2 == null || array2.Count == 0)
            {
                return GetMedian(array1, 0, array1.Count - 1);
            }

            return GetMedian(array1, 0, array1.Count - 1, array2, 0, array2.Count - 1); ;
        }

        private static int GetMedian(IReadOnlyList<int> array1, int startIndex1, int endIndex1, IReadOnlyList<int> array2, int startIndex2, int endIndex2)
        {
            int mid1, mid2;
            var median1 = GetMedian(array1, startIndex1, endIndex1, out mid1);

            Print(array1, startIndex1, endIndex1, mid1);

            var median2 = GetMedian(array2, startIndex2, endIndex2, out mid2);

            Print(array2, startIndex2, endIndex2, mid2);

            if (median1 == median2)
            {
                return median1;
            }

            switch ((endIndex1 - startIndex1 + 1) + (endIndex2 - startIndex2 + 1))
            {
                case 2:
                    return (array1[startIndex1] + array2[startIndex2]) / 2;
                case 3:
                    if (startIndex1 == endIndex1)
                    {
                        return median1 > median2 ? array2[endIndex2] : array2[startIndex2];
                    }
                    return median1 > median2 ? array1[endIndex1] : array1[startIndex1];
                case 4:
                    return median1 > median2
                        ? (array1[startIndex1] + array2[endIndex2])/2
                        : (array1[endIndex1] + array2[startIndex2])/2;
                default:
                    return median1 > median2 
                        ? GetMedian(array1, startIndex1, mid1, array2, mid2, endIndex2) 
                        : GetMedian(array1, mid1, endIndex1, array2, startIndex1, mid2);
            }
        }

        private static void Print(IReadOnlyList<int> array, int startIndex, int endIndex, int mid)
        {
            Console.WriteLine();
            for (var i = startIndex; i <= endIndex; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine("\nMiddle: " + array[mid]);
        }

        private static int GetMedian(IReadOnlyList<int> array, int startIndex, int endIndex)
        {
            int mid;
            return GetMedian(array, startIndex, endIndex, out mid);
        }

        private static int GetMedian(IReadOnlyList<int> array, int startIndex, int endIndex, out int mid)
        {
            var count = endIndex - startIndex + 1;
            mid = (count / 2) + startIndex;

            switch (count)
            {
                case 0:
                    throw new ArgumentException("Empty array");
                case 1:
                    return array[startIndex];
            }

            if (count % 2 != 0)
            {
                return array[mid];
            }

            mid--;
            var val = (array[mid] + array[mid + 1])/2;
            return val;
        }
    }
}
