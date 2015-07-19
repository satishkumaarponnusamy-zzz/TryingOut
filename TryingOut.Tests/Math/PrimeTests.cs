using FluentAssertions;
using NUnit.Framework;
using TryingOut.Math;

namespace TryingOut.Tests.Math
{
    [TestFixture]
    class PrimeTests
    {
        [Test]
        public void ShouldReturnTrueForPrimeNumbers()
        {
            int[] primes =
            {
                3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
                1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
                17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431
            };

            foreach (var prime in primes)
            {
                PrimeNumber.IsPrimeNumber((uint) prime).Should().BeTrue();
            }
        }

        [Test]
        public void ShouldReturnFalseForCompositeNumbers()
        {
            int[] composites =
            {
                10, 9, 15, 27, 111
            };

            foreach (var composite in composites)
            {
                PrimeNumber.IsPrimeNumber((uint)composite).Should().BeFalse();
            }
        }
    }
}
