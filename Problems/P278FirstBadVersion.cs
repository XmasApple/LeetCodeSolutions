using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public class P278FirstBadVersion
    {
        private static int _bad;
        private static bool IsBadVersion(int version) => version >= _bad;

        public static int FirstBadVersion(int n)
        {
            var left = 1;
            var right = n;
            while (left < right)
            {
                var ptr = left + (right - left) / 2;
                if (IsBadVersion(ptr)) right = ptr;
                else left = ptr + 1;
            }

            return right;
        }

        private static readonly ((int, int), int)[] TestPairs =
        {
            ((5, 4), 4),
            ((5, 1), 1),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((n, bad), expected) = TestPairs[i];
                _bad = bad;
                var result = FirstBadVersion(n);
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