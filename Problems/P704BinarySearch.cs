using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public class P704BinarySearch
    {
        public static int Search(int[] nums, int target)
        {
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            var left = 0;
            var right = nums.Length - 1;
            while (left <= right)
            {
                var ptr = left + (right - left) / 2;
                if (nums[ptr] == target) return ptr;
                if (nums[ptr] < target) left = ptr + 1;
                else right = ptr - 1;
            }

            return -1;
        }

        private static readonly ((int[], int), int)[] TestPairs =
        {
            ((new[] {-1, 0, 3, 5, 9, 12}, 9), 4),
            ((new[] {-1, 0, 3, 5, 9, 12}, 2), -1),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((nums, target), expected) = TestPairs[i];

                var result = Search(nums, target);
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