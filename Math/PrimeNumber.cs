using System.Collections.Generic;

namespace TryingOut.Math
{
    public class PrimeNumber
    {
        private static readonly HashSet<uint> PrimeNumbers = new HashSet<uint>
        {
            3, 5, 7, 11, 13, 17, 23, 29
        };

        public static bool IsPrimeNumber(uint number)
        {
            if (PrimeNumbers.Contains(number))
            {
                return true;
            }

            if ((number & 1) != 0) //check whether it is divisible by 2
            {
                //if not check whether divisible by odd number
                var limit = (int)System.Math.Sqrt(number);
                for (var divisor = 3; divisor <= limit; divisor += 2)
                {
                    if (number % divisor == 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            return number == 2;
        }
    }
}
