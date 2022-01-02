using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P227BasicCalculatorII
    {
        public static int Calculate(string s)
        {
            if (s.Length < 1) return 0;

            var stack = new Stack<int>();
            var current = 0;
            var op = '+';
            
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (char.IsDigit(c))
                    current = current * 10 + (c - '0');
                if ((char.IsDigit(c) || char.IsWhiteSpace(c)) && i != s.Length - 1) continue;
                switch (op)
                {
                    case '+':
                        stack.Push(current);
                        break;
                    case '-':
                        stack.Push(-current);
                        break;
                    case '/':
                        stack.Push(stack.Pop() / current);
                        break;
                    case '*':
                        stack.Push(stack.Pop() * current);
                        break;
                }

                op = c;
                current = 0;
            }

            var res = 0;
            while (stack.Count > 0)
                res += stack.Pop();

            return res;
        }


        private static readonly (string, int)[] TestPairs =
        {
            ("3+2*2", 7),
            ("3/2 ", 1),
            ("3+5 / 2", 5),
            ("22-3*5", 7),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (s, expected) = TestPairs[i];

                var result = Calculate(s);
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