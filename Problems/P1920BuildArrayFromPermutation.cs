using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P1920BuildArrayFromPermutation
    {
        public static int[] BuildArray(int[] nums)
        {
            var res = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++) res[i] = nums[nums[i]];
            return res;
        }

        private static readonly (int[], int[])[] TestPairs = {
            (new[] { 0,2,1,5,3,4 }, new[] {0,1,2,4,5,3 }),
            (new[] { 5,0,1,2,3,4}, new[] { 4,5,0,1,2,3 }),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (nums, expected) = TestPairs[i];

                var result = BuildArray(nums);
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