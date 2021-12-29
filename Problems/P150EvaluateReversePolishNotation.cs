using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P150EvaluateReversePolishNotation
    {
        public static int EvalRPN(string[] tokens)
        {
            var stack = new Stack<string>(tokens);
            return Eval(stack);
        }

        public static int Eval(Stack<string> stack)
        {
            var token = stack.Pop();
            if(token.Length == 1 && "+-*/".Contains(token))
            {
                var a = Eval(stack);
                var b = Eval(stack);
                var res = 0;
                if (token == "+")
                    res = b + a;
                if (token == "-")
                    res = b - a;
                if (token == "*")
                    res = b * a;
                if (token == "/")
                    res = b / a;
                return res;
            }
            return int.Parse(token);
        }
        private static readonly (string[], int)[] TestPairs =
        {
            (new[] { "2", "1", "+", "3", "*" }, 9),
            (new[] { "4", "13", "5", "/", "+" }, 6),
            (new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }, 22),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (s, expected) = TestPairs[i];

                var result = EvalRPN(s);
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