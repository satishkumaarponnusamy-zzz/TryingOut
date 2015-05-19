using System.Collections.Generic;

namespace TryingOut.DP
{
    public class SubArrayWithLargestSum
    {
        public List<int> Find(List<int> array)
        {
            if (array == null || array.Count == 0)
            {
                return null;
            }

            var maxSum = int.MinValue;
            var sum = 0;
            var subArray = new List<int>();
            var tempSubArray = new List<int>();
            bool checkMax = false;

            for (var i = 0; i < array.Count; i++)
            {
                if (sum < sum + array[i])
                {
                    sum += array[i];
                    tempSubArray.Add(array[i]);
                }
                else
                {
                    sum = 0;
                    tempSubArray.Clear();
                }

                if (maxSum < sum)
                {
                    maxSum = sum;
                    subArray = tempSubArray;
                }
            }

            return subArray;
        }
    }
}
