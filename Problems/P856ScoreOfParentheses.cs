using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P856ScoreOfParentheses
    {
        public static int ScoreOfParentheses(string s)
        {
            var stack = new Stack<int>(new[] {0});
            foreach (var x in s)
            {
                if (x == '(')
                    stack.Push(0);
                else
                {
                    var v = stack.Pop();
                    stack.Push(stack.Pop() + (2 * v > 1 ? 2 * v : 1));
                }
            }

            return stack.Pop();
        }


        private static readonly (string, int)[] TestPairs =
        {
            ("()", 1),
            ("(())", 2),
            ("()()", 2),
            ("(()(()))", 6),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (sentence, expected) = TestPairs[i];

                var result = ScoreOfParentheses(sentence);
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