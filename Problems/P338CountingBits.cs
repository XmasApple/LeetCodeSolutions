using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P338CountingBits
    {
        public static int[] CountBits(int n)
        {
            var r = new int[n + 1];
            // for (var i = 0; i <= n; i++)
            // {
            //     var current = i;
            //     for (var j = 0; j < 32; j++)
            //     {
            //         if ((current & 1) == 1) r[i] += 1;
            //         current >>= 1;
            //     }
            // }
            for (var i = 1; i <= n; i++)
                r[i] = r[i >> 1] + (i & 1);
            
            return r;
        }

        private static readonly (int, int[])[] TestPairs =
        {
            (2, new[] { 0, 1, 1 }),
            (5, new[] { 0, 1, 1, 2, 1, 2 }),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (n, expected) = TestPairs[i];

                var result = CountBits(n);
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