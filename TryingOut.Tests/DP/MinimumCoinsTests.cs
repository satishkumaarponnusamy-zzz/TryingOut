using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TryingOut.DP;

namespace TryingOut.Tests.DP
{
    [TestFixture]
    class MinimumCoinsTests
    {
        private readonly object[] _minimumCoins =
        {
            new object[]
            {
                new List<int>{1, 3, 5},
                1,
                1,
                new List<string> {"1"}
            },
            new object[]
            {
                new List<int>{1, 3, 5},
                2,
                2,
                new List<string> {"1, 1"}
            },
            new object[]
            {
                new List<int>{1, 3, 5},
                3,
                1,
                new List<string> {"3"}
            },
            new object[]
            {
                new List<int>{1, 3, 5},
                4,
                2,
                new List<string> {"1, 3", "3, 1"}
            },
            new object[]
            {
                new List<int>{1, 3, 5},
                5,
                1,
                new List<string> {"5"}
            },
            new object[]
            {
                new List<int>{1, 3, 5},
                6,
                2,
                new List<string> {"1, 5", "3, 3", "5, 1"}
            },
            new object[]
            {
                new List<int>{1, 3, 5},
                7,
                3,
                new List<string> {"1, 1, 5", "1, 3, 3", "1, 5, 1", "3, 1, 3", "3, 3, 1", "5, 1, 1"}
            },
            new object[]
            {
                new List<int>{1, 3, 5},
                8,
                2,
                new List<string> {"1, 1, 1, 5", "1, 1, 3, 3", "1, 1, 5, 1", "1, 3, 1, 3", "1, 3, 3, 1", "1, 5, 1, 1", "3, 5", "5, 3"}
            },
            new object[]
            {
                new List<int>{1, 3, 5},
                9,
                3,
                new List<string> {"1, 1, 1, 1, 5", "1, 1, 1, 3, 3", "1, 1, 1, 5, 1", "1, 1, 3, 1, 3", "1, 1, 3, 3, 1", "1, 1, 5, 1, 1", "1, 3, 5", "1, 5, 3", "3, 1, 5", "3, 3, 3", "3, 5, 1", "5, 1, 3", "5, 3, 1"}
            },
            //new object[]
            //{
            //    new List<int>{1, 3, 5},
            //    10,
            //    2
            //},
            //new object[]
            //{
            //    new List<int>{1, 3, 5},
            //    11,
            //    3
            //},
        };

        [TestCaseSource("_minimumCoins")]
        public void ShouldReturnMiniumCoinsRequiredToMakeSumUsingGivenCoins(List<int> coins, int sum, int expectedNumberOfCoins, List<string> expectedCoinPossibilities)
        {
            List<string> madeUsingCoins;
            MinimumCoins.FindForSum(coins, sum, out madeUsingCoins).Should().Be(expectedNumberOfCoins);
            madeUsingCoins.Should().BeEquivalentTo(expectedCoinPossibilities);
        }
    }
}
