using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P1855MaximumDistanceBetweenAPairOfValues
    {
        public static int MaxDistance(int[] nums1, int[] nums2)
        {
            var max = 0;
            var i = 0;
            var j = 0;
            while (i < nums1.Length && j < nums2.Length)
                if (nums1[i] > nums2[j])
                    i++;
                else
                    max = Math.Max(max, j++ - i);
            return max;
        }

        private static readonly ((int[], int[]), int)[] TestPairs =
        {
            ((new[] { 55, 30, 5, 4, 2 }, new[] { 100, 20, 10, 10, 5 }), 2),
            ((new[] { 2, 2, 2 }, new[] { 10, 10, 1 }), 1),
            ((new[] { 30, 29, 19, 5 }, new[] { 25, 25, 25, 25, 25 }), 2),
        };


        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((nums1, nums2), expected) = TestPairs[i];

                var result = MaxDistance(nums1, nums2);
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