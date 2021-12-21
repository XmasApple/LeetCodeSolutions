using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P1TwoSum
    {
        public static int[] TwoSum1(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                var t = target - nums[i];
                for (var j = i + 1; j < nums.Length; j++)
                    if (nums[j] == t)
                        return new[] { i, j };
            }

            return new int[2];
        }

        public static int[] TwoSum2(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    return new[] { dict[nums[i]], i };
                if (!dict.ContainsKey(target - nums[i])) dict.Add(target - nums[i], i);
            }

            return new int[2];
        }

        private static readonly ((int[], int), int[])[] TestPairs = {
            ((new[] { 2, 7, 11, 15 }, 9), new[] { 0, 1 }),
            ((new[] { 3, 2, 4 }, 6), new[] { 1, 2 }),
            ((new[] { 3, 3 }, 6), new[] { 0, 1 }),
        };

        public static void Test1()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((item1, item2), expected) = TestPairs[i];

                var result = TwoSum1(item1, item2);
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

        public static void Test2()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType;
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((item1, item2), expected) = TestPairs[i];

                var result = TwoSum2(item1, item2);
                if (result.SequenceEqual(expected))
                    Console.WriteLine($"Test {name}2 #{i + 1} passed");
                else
                {
                    Console.WriteLine($"Test {name}2 #{i + 1} failed");
                    Console.WriteLine("Expected:");
                    Console.WriteLine($"[{string.Join(", ", expected)}");
                    Console.WriteLine("Given:");
                    Console.WriteLine($"[{string.Join(", ", result)}");
                }
            }
        }
    }
}