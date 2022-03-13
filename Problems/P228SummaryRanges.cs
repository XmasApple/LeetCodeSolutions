using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P228SummaryRanges
    {
        public static IList<string> SummaryRanges(int[] nums)
        {
            var res = new List<string>();
            for (var i = 0; i < nums.Length; i++)
            {
                var ptr = i;
                while (i < nums.Length - 1 && nums[i] + 1 == nums[i + 1])
                    i++;
                res.Add(i != ptr ? $"{nums[ptr]}->{nums[i]}" : $"{nums[i]}");
            }

            return res;
        }

        private static readonly (int[], string[])[] TestPairs =
        {
            (new[] {0, 1, 2, 4, 5, 7}, new[] {"0->2", "4->5", "7"}),
            (new[] {0, 2, 3, 4, 6, 8, 9}, new[] {"0", "2->4", "6", "8->9"}),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (nums, expected) = TestPairs[i];

                var result = SummaryRanges(nums).ToList();
                if (result.SequenceEqual(expected))
                    Console.WriteLine($"Test {name} #{i + 1} passed");
                else
                {
                    Console.WriteLine($"Test {name} #{i + 1} failed");
                    Console.WriteLine("Expected:");
                    Console.WriteLine($"[{string.Join(", ", expected)}]");
                    Console.WriteLine("Given:");
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                }
            }
        }
    }
}