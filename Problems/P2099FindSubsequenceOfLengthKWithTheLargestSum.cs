using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P2099FindSubsequenceOfLengthKWithTheLargestSum
    {
        public static int[] MaxSubsequence(int[] nums, int k)
        {
            return nums
                .Select((n, i) => (n,i))
                .ToList()
                .OrderByDescending(n => n.n)
                .Take(k)
                .OrderBy(n => n.i)
                .Select(n => n.n)
                .ToArray();
        }

        private static readonly ((int[], int), int[])[] TestPairs =
        {
            ((new[] {2, 1, 3, 3}, 2), new[] {3, 3}),
            ((new[] {-1, -2, 3, 4}, 3), new[] {-1, 3, 4}),
            ((new[] {3, 4, 3, 3}, 2), new[] {3, 4}),
            ((new[] {50, -75}, 2), new[] {50, -75}),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((nums, k), expected) = TestPairs[i];

                var result = MaxSubsequence(nums, k);
                if (result.SequenceEqual(expected))
                    Console.WriteLine($"Test {name}1 #{i + 1} passed");
                else
                {
                    Console.WriteLine($"Test {name}1 #{i + 1} failed");
                    Console.WriteLine("Expected:");
                    Console.WriteLine($"[{string.Join(", ", expected)}]");
                    Console.WriteLine("Given:");
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                }
            }
        }
    }
}