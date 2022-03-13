using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P1832CheckIfTheSentenceIsPangram
    {
        public static bool CheckIfPangram(string sentence)
        {
            var flags = new bool[26];
            foreach (var c in sentence) flags[c - 'a'] = true;
            return flags.All(_ => _);
        }

        private static readonly (string, bool)[] TestPairs =
        {
            ("thequickbrownfoxjumpsoverthelazydog", true),
            ("leetcode", false),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (sentence, expected) = TestPairs[i];

                var result = CheckIfPangram(sentence);
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