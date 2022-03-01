using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public class P9PalindromeNumber
    {
        public static bool IsPalindrome(int x)
        {
            if (x < 0 || x % 10 == 0 && x != 0)
                return false;

            var revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            return x == revertedNumber || x == revertedNumber / 10;
        }

        private static readonly (int, bool)[] TestPairs =
        {
            (121, true),
            (-121, false),
            (10, false),
            (1000021, false),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (x, expected) = TestPairs[i];

                var result = IsPalindrome(x);
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