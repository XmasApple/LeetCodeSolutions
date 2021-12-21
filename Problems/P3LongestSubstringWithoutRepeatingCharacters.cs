using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P3LongestSubstringWithoutRepeatingCharacters
    {
        public static int LengthOfLongestSubstring(string s)
        {
            var max = 0;
            var cache = new int[256];
            for (int i = 0, last = 0; i < s.Length; i++)
            {
                var c = s[i];
                last = cache[c] == 0 ? last : last > cache[c] ? last : cache[c];
                cache[c] = i + 1;
                max = max > i - last + 1 ? max : i - last + 1;
            }

            return max;
        }

        private static readonly (string, int)[] TestPairs =
        {
            ("abcabcbb", 3),
            ("bbbbb", 1),
            ("pwwkew", 3),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (input, expected) = TestPairs[i];

                var result = LengthOfLongestSubstring(input);
                if (result==expected)
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