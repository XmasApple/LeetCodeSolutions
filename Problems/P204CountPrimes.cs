using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P204CountPrimes
    {
        public static int CountPrimes(int n)
        {
            var primes = 0;
            var sieve = Enumerable.Repeat(true, n + 1).ToArray();
            for (var i = 2; i < n; i++)
            {
                if (!sieve[i]) continue;
                primes += 1;
                for (var j = i + i; j < n; j += i)
                {
                    sieve[j] = false;
                }
            }
            return primes;
        }

        private static readonly (int, int)[] TestPairs =
        {
            (10, 4),
            (0, 0),
            (1, 0),
            (2, 0),
            (5, 2),
            (3, 1),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (n, expected) = TestPairs[i];

                var result = CountPrimes(n);
                if (result == expected)
                    Console.WriteLine($"Test {name} #{i + 1} passed");
                else
                {
                    Console.WriteLine($"Test {name} #{i + 1} failed");
                    Console.WriteLine("Expected:");
                    Console.WriteLine(expected);
                    Console.WriteLine("Given:");
                    Console.WriteLine(result);
                }
            }
        }
    }
}