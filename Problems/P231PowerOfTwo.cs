using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P231PowerOfTwo
    {
        public static bool IsPowerOfTwo(int n) => n > 0 && (n & (n - 1)) == 0;


        private static readonly (int, bool)[] TestPairs =
        {
            (1, true),
            (16, true),
            (3, false),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (n, expected) = TestPairs[i];

                var result = IsPowerOfTwo(n);
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