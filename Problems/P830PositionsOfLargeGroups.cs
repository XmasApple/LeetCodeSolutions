using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P830PositionsOfLargeGroups
    {
        public static IList<IList<int>> LargeGroupPositions(string s)
        {
            var res = new List<IList<int>>();
            var start = 0;
            var t = '_';
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c != t)
                {
                    if (i - start >= 3)
                        res.Add(new List<int> { start, i - 1 });
                    t = c;
                    start = i;
                }
            }

            if (s.Length - start >= 3)
                res.Add(new List<int> { start, s.Length - 1 });

            return res;
        }

        private static readonly (string, IList<IList<int>>)[] TestPairs =
        {
            ("abbxxxxzzy", new IList<int>[] { new[] { 3, 6 } }),
            ("abc", new IList<int>[] { }),
            ("abcdddeeeeaabbbcd", new IList<int>[] { new[] { 3, 5 }, new[] { 6, 9 }, new[] { 12, 14 } }),
            ("aba", new IList<int>[] { }),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (s, expected) = TestPairs[i];

                var result = LargeGroupPositions(s);
                var equal = result.Count == 0 || result.Count == expected.Count && result[0].Count == expected[0].Count;
                if (equal)
                    for (var index = 0; index < result.Count; index++)
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
                    Console.WriteLine(expected);
                    Console.WriteLine("Given:");
                    Console.WriteLine(result);
                }
            }
        }
    }
}