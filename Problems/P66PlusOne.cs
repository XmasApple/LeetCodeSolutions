using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P66PlusOne
    {
        public static int[] PlusOne(int[] digits)
        {
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                    digits[i] = 0;
                else
                {
                    digits[i] += 1;
                    return digits;
                }
            }

            var r = new int[digits.Length + 1];
            r[0] = 1;
            for (var j = 0; j < digits.Length; j++)
                r[j + 1] = digits[j];
            return r;
        }

        private static readonly (int[], int[])[] TestPairs =
        {
            (new[] { 1, 2, 3 }, new[] { 1, 2, 4 }),
            (new[] { 4, 3, 2, 1 }, new[] { 4, 3, 2, 2 }),
            (new[] { 0 }, new[] { 1 }),
            (new[] { 9 }, new[] { 1, 0 }),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (digits, expected) = TestPairs[i];

                var result = PlusOne(digits);
                if (result.SequenceEqual(expected))
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