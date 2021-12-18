using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class P10RegularExpressionMatching
    {
        public readonly Dictionary<(int, int), bool> Matches = new();

        public bool IsMatch(string s, string p, int si = 0, int pi = 0)
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
    }
}