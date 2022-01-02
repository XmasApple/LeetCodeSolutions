using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P190ReverseBits
    {
        public static uint reverseBits(uint n)
        {
            uint r = 0;
            for (var i = 0; i < 32; i++)
            {
                r <<= 1;
                if ((n & 1) == 1) r += 1;
                n >>= 1;
            }

            return r;
        }

        private static readonly (uint, uint)[] TestPairs =
        {
            (0b00000010100101000001111010011100, 0b00111001011110000010100101000000),
            (0b11111111111111111111111111111101, 0b10111111111111111111111111111111),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (n, expected) = TestPairs[i];

                var result = reverseBits(n);
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