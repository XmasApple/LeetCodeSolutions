using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P2078TwoFurthestHousesWithDifferentColors
    {
        public static int MaxDistance(int[] colors)
        {
            var max = 0;
            for (var i = 0; i < colors.Length - 1; i++)
            for (var j = i + 1; j < colors.Length; j++)
                if (colors[i] != colors[j] && j - i > max)
                    max = j - i;
            return max;
        }

        private static readonly (int[], int)[] TestPairs =
        {
            (new[] { 1, 1, 1, 6, 1, 1, 1 }, 3),
            (new[] { 1, 8, 3, 8, 3 }, 4),
            (new[] { 0, 1 }, 1),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (s, expected) = TestPairs[i];

                var result = MaxDistance(s);
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