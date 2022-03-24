using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P2022Convert1DArrayInto2DArray
    {
        public static int[][] Construct2DArray(int[] original, int m, int n)
        {
            if (m * n != original.Length)
                return new int[][]{};
            var res = new List<int[]>();
            for (var i = 0; i < m; i++)
            {
                var row = new int[n];
                for (var j = 0; j < n; j++) row[j] = original[i * n + j];
                res.Add(row);
            }
            return res.ToArray();
        }

        private static readonly ((int[], int, int), int[][])[] TestPairs =
        {
            ((new[] {1, 2, 3, 4}, 2, 2), new[] {new[] {1, 2}, new[] {3, 4},}),
            ((new[] {1, 2, 3}, 1, 3), new[] {new[] {1, 2, 3}}),
            ((new[] {1, 2}, 1, 1), new int[][]{}),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((original, m, n), expected) = TestPairs[i];
                var result = Construct2DArray(original, m, n);
                var equal = result.Length == 0 ||
                            result.Length == expected.Length && result[0].Length == expected[0].Length;
                if (equal)
                    for (var index = 0; index < result.Length; index++)
                    {
                        var rRow = result[index];
                        var eRow = expected[index];
                        if (rRow.SequenceEqual(eRow)) continue;
                        equal = false;
                        break;
                    }

                if (equal)
                    Console.WriteLine($"Test {name} #{i + 1} passed");
                else
                {
                    Console.WriteLine($"Test {name} #{i + 1} failed");
                    Console.WriteLine("Expected:");
                    Console.WriteLine(string.Join(", ", expected.Select(t => $"[{string.Join(", ", t)}]").ToArray()));
                    Console.WriteLine("Given:");
                    Console.WriteLine(string.Join(", ", result.Select(t => $"[{string.Join(", ", t)}]").ToArray()));
                }
            }
        }
    }
}