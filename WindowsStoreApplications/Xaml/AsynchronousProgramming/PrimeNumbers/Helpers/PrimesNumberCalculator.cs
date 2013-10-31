namespace PrimeNumbers.Helpers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PrimesNumberCalculator
    {
        public static async Task<List<int>> GetPrimesInRangeAsync(int start, int end)
        {
            var primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        public static async Task<List<int>> GetNonPrimesInRangeAsync(int start, int end)
        {
            var nonPrimes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (!IsPrime(i))
                {
                    nonPrimes.Add(i);
                }
            }

            return nonPrimes;
        }

        private static bool IsPrime(int number)
        {
            for (long i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}