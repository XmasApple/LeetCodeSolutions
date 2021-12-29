using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P224BasicCalculator
    {
        public static int Calculate(string s)
        {
            var stack = new Stack<int>();
            var result = 0;
            var number = 0;
            var sign = 1;

            foreach (var c in s)
            {
                if (char.IsDigit(c))
                {
                    number = 10 * number + (c - '0');
                }
                else
                    switch (c)
                    {
                        case '+':
                            result += sign * number;
                            number = 0;
                            sign = 1;
                            break;
                        case '-':
                            result += sign * number;
                            number = 0;
                            sign = -1;
                            break;
                        case '(':
                            stack.Push(result);
                            stack.Push(sign);

                            sign = 1;
                            result = 0;
                            break;
                        case ')':
                            result += sign * number;
                            number = 0;
                            result *= stack.Pop();
                            result += stack.Pop();
                            break;
                    }
            }

            if (number != 0) result += sign * number;
            return result;
        }


        private static readonly (string, int)[] TestPairs =
        {
            ("1 + 1", 2),
            (" 2-1 + 2 ", 3),
            ("(1+(4+5+2)-3)+(6+8)", 23),
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