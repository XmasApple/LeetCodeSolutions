using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P10RegularExpressionMatching
    {
        public static readonly Dictionary<(int, int), bool> Matches = new();

        public static bool IsMatch(string s, string p, int si = 0, int pi = 0)
        {
            if (Matches.ContainsKey((si, pi)))
                return Matches[(si, pi)];
            if (p.Length == pi) return s.Length == si;
            var firstMatch = s.Length > si && (p[pi] == s[si] || p[pi] == '.');

            bool r;
            if (p.Length > pi + 1 && p[pi + 1] == '*')
                r = IsMatch(s, p, si, pi + 2) ||
                    firstMatch && IsMatch(s, p, si + 1, pi);
            else
                r = firstMatch && IsMatch(s, p, si + 1, pi + 1);
            Matches[(si, pi)] = r;
            return r;
        }

        private static readonly ((string, string), bool)[] TestPairs =
        {
            (("aa", "a"), false),
            (("aa", "a*"), true),
            (("ab", ".*"), true),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                Matches.Clear();
                var ((s, p), expected) = TestPairs[i];

                var result = IsMatch(s, p);
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