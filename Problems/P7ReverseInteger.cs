using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P7ReverseInteger
    {
        public static int Reverse(int x)
        {
            long r = 0;
            var sign = x < 0;
            x = sign ? -x : x;
            while (x > 0)
            {
                r *= 10;
                r += x % 10;
                x /= 10;
            }

            r = sign ? -r : r;
            return r is > int.MaxValue or < int.MinValue ? 0 : (int)r;
        }

        private static readonly (int, int)[] TestPairs =
        {
            (123, 321),
            (-123, -321),
            (120, 21),
            (1534236469, 0),
            (-2147483412, -2143847412)
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (x, expected) = TestPairs[i];

                var result = Reverse(x);
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