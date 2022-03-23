using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P1663SmallestStringWithAGivenNumericValue
    {
        public static string GetSmallestString(int n, int k)
        {
            var r = new List<char>();
            for (var i = n - 1; i >= 0; i--)
            {
                var t = k - n > 25 ? 25 : k - n;
                r.Add(Convert.ToChar('a' + t));
                k -= t;
            }

            r.Reverse();
            return string.Join("", r);
        }

        private static readonly ((int, int), string)[] TestPairs =
        {
            ((3, 27), "aay"),
            ((5, 73), "aaszz"),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((n, k), expected) = TestPairs[i];

                var result = GetSmallestString(n, k);
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