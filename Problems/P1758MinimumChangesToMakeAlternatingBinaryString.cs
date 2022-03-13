using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P1758MinimumChangesToMakeAlternatingBinaryString
    {
        public static int MinOperations(string s)
        {
            var c0 = 0;
            var c1 = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == (i % 2 == 0 ? '0' : '1'))
                    c0 += 1;
                else
                    c1 += 1;
            }

            return c0 < c1 ? c0 : c1;
        }

        private static readonly (string, int)[] TestPairs =
        {
            ("0100", 1),
            ("10", 0),
            ("1111", 2),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (s, expected) = TestPairs[i];

                var result = MinOperations(s);
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