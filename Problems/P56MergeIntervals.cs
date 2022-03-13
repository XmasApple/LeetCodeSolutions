using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P56MergeIntervals
    {
        public static int[][] Merge(int[][] intervals)
        {
            var tmp = intervals.ToList();
            tmp.Sort((x,y) => x[0].CompareTo(y[0]));
            intervals = tmp.ToArray();
            
            var res = new List<int[]> { intervals[0] };
            foreach (var interval in intervals)
            {
                if (interval[0] <= res[^1][1])
                    res[^1][1] = res.Last()[1] > interval[1] ? res.Last()[1] : interval[1];
                else
                    res.Add(interval);
            }

            return res.ToArray();
        }

        private static readonly (int[][], int[][])[] TestPairs =
        {
            (new[] { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } },
                new[] { new[] { 1, 6 }, new[] { 8, 10 }, new[] { 15, 18 } }),
            (new[] { new[] { 1, 4 }, new[] { 4, 5 } }, new[] { new[] { 1, 5 } }),
            (new[] { new[] { 1, 4 }, new[] { 5, 6 } }, new[] { new[] { 1, 4 }, new[] { 5, 6 } }),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (intervals, expected) = TestPairs[i];
                var result = Merge(intervals);
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