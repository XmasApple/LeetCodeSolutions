using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P1010PairsOfSongsWithTotalDurationsDivisibleBy60
    {
        public static int NumPairsDivisibleBy60(int[] time)
        {
            var res = 0;
            var cnt = new int[60];
            foreach (var t in time) cnt[t % 60]++;
            for (var i = 1; i < 30; i++) res += cnt[i] * cnt[60 - i];
            return res + cnt[0] * (cnt[0] - 1) / 2 + cnt[30] * (cnt[30] - 1) / 2;
        }

        private static readonly (int[], int)[] TestPairs =
        {
            (new[] {30, 20, 150, 100, 40}, 3),
            (new[] {60, 60, 60}, 3),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (nums, expected) = TestPairs[i];

                var result = NumPairsDivisibleBy60(nums);
                if (result == expected)
                    Console.WriteLine($"Test {name}1 #{i + 1} passed");
                else
                {
                    Console.WriteLine($"Test {name}1 #{i + 1} failed");
                    Console.WriteLine("Expected:");
                    Console.WriteLine(expected);
                    Console.WriteLine("Given:");
                    Console.WriteLine(result);
                }
            }
        }
    }
}