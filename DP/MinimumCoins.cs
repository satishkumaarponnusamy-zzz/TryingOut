using System;
using System.Collections.Generic;

namespace TryingOut.DP
{
    public class MinimumCoins
    {
        public static int FindForSum(List<int> coins, int value, out List<string> madeUsingCoins)
        {
            if (coins == null || coins.Count < 0 || value <= 0)
            {
                throw new ArgumentException();
            }

            var coinSet = new HashSet<int>(coins);
            var valueMadeUsingCoins = new Dictionary<int, List<string>>();
            
            var minimumNumberOfCoins = new List<int> { 0 };
            valueMadeUsingCoins.Add(0, null);

            for (var i = 1; i <= value; i++)
            {
                minimumNumberOfCoins.Add(int.MaxValue);
            }

            for (var sum = 1; sum <= value; sum++)
            {
                if (coinSet.Contains(sum))
                {
                    minimumNumberOfCoins[sum] = 1;
                    valueMadeUsingCoins.Add(sum, new List<string>{ sum.ToString() });
                    continue;
                }

                for (var coinIndex = 0; coinIndex < coins.Count && sum > coins[coinIndex]; coinIndex++)
                {
                    var coin = coins[coinIndex];
                    var remainingValue = sum - coin;
                    
                    var minimumNumberOfCoinsUsingCurrentCoin = minimumNumberOfCoins[remainingValue] + 1;
  
                    if (minimumNumberOfCoins[sum] > minimumNumberOfCoinsUsingCurrentCoin)
                    {
                        minimumNumberOfCoins[sum] = minimumNumberOfCoinsUsingCurrentCoin;
                        BuildValueMadeUsingCoinsList(valueMadeUsingCoins, remainingValue, sum, coin);
                    }
                    else if (minimumNumberOfCoins[sum] == minimumNumberOfCoinsUsingCurrentCoin)
                    {
                        BuildValueMadeUsingCoinsList(valueMadeUsingCoins, remainingValue, sum, coin);
                    }
                }
            }

            madeUsingCoins = valueMadeUsingCoins[value];
            return minimumNumberOfCoins[value];
        }

        private static void BuildValueMadeUsingCoinsList(Dictionary<int, List<string>> valueMadeUsingCoins, int remainingValue, int sum, int coin)
        {
            foreach (var valueMadeUsingCoin in valueMadeUsingCoins[remainingValue])
            {
                if (valueMadeUsingCoins.ContainsKey(sum))
                {
                    valueMadeUsingCoins[sum].Add(coin + ", " + valueMadeUsingCoin);
                }
                else
                {
                    valueMadeUsingCoins.Add(sum, new List<string> {coin + ", " + valueMadeUsingCoin});
                }
            }
        }
    }
}
