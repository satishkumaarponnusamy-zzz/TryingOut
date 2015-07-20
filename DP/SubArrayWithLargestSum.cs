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

            foreach (var item in array)
            {
                if (sum < sum + item)
                {
                    sum += item;
                    tempSubArray.Add(item);
                }
                else
                {
                    sum = 0;
                    tempSubArray = new List<int>();
                }

                if (maxSum <= sum) //remove = to get previous elements making the same max sum, with = you get latest one
                {
                    maxSum = sum;
                    subArray = tempSubArray;
                }
            }

            return subArray;
        }
    }
}
