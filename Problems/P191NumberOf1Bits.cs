using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P191NumberOf1Bits
    {
        
        public static int HammingWeight(uint n)
        {
            var r = 0;
            for (var i = 0; i < 32; i++)
            {
                if ((n & 1) == 1) r += 1;
                n >>= 1;
            }

            return r;
        }

        private static readonly (uint, int)[] TestPairs =
        {
            (0b00000000000000000000000000001011, 3),
            (0b00000000000000000000000010000000, 1),
            (0b11111111111111111111111111111101, 31),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (s, expected) = TestPairs[i];

                var result = HammingWeight(s);
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