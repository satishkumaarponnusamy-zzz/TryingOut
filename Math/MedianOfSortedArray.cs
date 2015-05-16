using System;
using System.Collections.Generic;

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

            if (array1.Count > array2.Count)
            {
                return GetMedian(array2, 0, array2.Count - 1, array1, 0, array1.Count - 1); ;
            }

            return GetMedian(array1, 0, array1.Count - 1, array2, 0, array2.Count - 1); ;
        }

        private static int GetMedian(IReadOnlyList<int> array1, int startIndex1, int endIndex1, IReadOnlyList<int> array2, int startIndex2, int endIndex2)
        {
            var len1 = endIndex1 - startIndex1 + 1;
            var len2 = endIndex2 - startIndex2 + 1;
            var mid2 = len2/2 + startIndex2;

            Console.WriteLine("\nStep");
            for(int i = startIndex1; i <= endIndex1; i++)
                Console.Write(array1[i] + ",");
            Console.WriteLine();
            for (int i = startIndex2; i <= endIndex2; i++)
                Console.Write(array2[i] + ",");
            Console.WriteLine();

            if (len1 == 1)
            {
                if (len2 == 1)
                {
                    return (array1[startIndex1] + array2[startIndex2])/2;
                }
                if (len2 % 2 != 0)
                {
                    if (array1[startIndex1] < array2[mid2 - 1])
                    {
                        return (array2[mid2 - 1] + array2[mid2]) / 2;
                    }
                    if (array1[startIndex1] > array2[mid2 + 1])
                    {
                        return (array2[mid2] + array2[mid2 + 1]) / 2;
                    }
                    return (array2[mid2] + array1[startIndex1]) / 2;
                }

                if (array1[startIndex1] < array2[mid2 - 1])
                {
                    return array2[mid2 - 1];
                }
                return array1[startIndex1] > array2[mid2] ? array2[mid2] : array1[startIndex1];
            }
            
            if (len1 == 2)
            {
                if (len2 == 2)
                {
                    return (System.Math.Max(array1[startIndex1], array2[startIndex2]) + System.Math.Min(array1[endIndex1], array2[endIndex2]))/2;
                }
                if (len2%2 == 0)
                {
                    return (System.Math.Max(array1[startIndex1], array2[mid2 - 1]) + System.Math.Min(array1[endIndex1], array2[mid2]))/2;
                }

                if (array1[endIndex1] < array2[mid2])
                {
                    return System.Math.Max(array1[endIndex1], array2[mid2 - 1]);
                }
                return array1[startIndex1] > array2[mid2] ? System.Math.Min(array1[startIndex1], array2[mid2 + 1]) : array2[mid2];
            }

            int mid1, extraLength1, extraLength2;
            var median1 = GetMedian(array1, startIndex1, endIndex1, out mid1, out extraLength1);
            var median2 = GetMedian(array2, startIndex2, endIndex2, out mid2, out extraLength2);

            return median1 > median2
                ? GetMedian(array1, startIndex1, mid1 + extraLength1, array2, mid2, mid2 + (mid1 - startIndex1) + extraLength2)
                : GetMedian(array1, mid1, endIndex1, array2, mid2 - (endIndex1 - mid1), mid2 + extraLength2);
        }

        private static int GetMedian(IReadOnlyList<int> array, int startIndex, int endIndex)
        {
            int mid;
            int extraLength;
            return GetMedian(array, startIndex, endIndex, out mid, out extraLength);
        }

        private static int GetMedian(IReadOnlyList<int> array, int startIndex, int endIndex, out int mid, out int extraLength)
        {
            extraLength = 0;
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

            var val = (array[mid - 1] + array[mid])/2;
            mid--;
            extraLength = 1;
            return val;
        }
    }
}
