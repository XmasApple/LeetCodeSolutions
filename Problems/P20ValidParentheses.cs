using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P20ValidParentheses
    {
        public static bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                switch (c)
                {
                    case '(':
                        stack.Push(c);
                        break;
                    case '[':
                        stack.Push(c);
                        break;
                    case '{':
                        stack.Push(c);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                            return false;
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                            return false;
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                            return false;
                        break;
                }
            }

            return stack.Count == 0;
        }

        private static readonly (string, bool)[] TestPairs =
        {
            ("()", true),
            ("()[]{}", true),
            ("(]", false),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (sentence, expected) = TestPairs[i];

                var result = IsValid(sentence);
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