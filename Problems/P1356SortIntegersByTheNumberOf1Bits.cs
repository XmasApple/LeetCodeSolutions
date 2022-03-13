using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P1356SortIntegersByTheNumberOf1Bits
    {
        public static int[] SortByBits(int[] arr)
        {
            var r = arr.ToList();
            r.Sort((x, y) =>
            {
                var a = x;
                var b = y;
                var xo = 0;
                var yo = 0; 
                while (a>0) {
                    xo++; 
                    a &= a - 1; 
                }
                while (b>0) {
                    yo++; 
                    b &= b - 1; 
                }
                
                return xo == yo ? x.CompareTo(y) : xo.CompareTo(yo);
            }
            );
            return r.ToArray();
        }

        private static readonly (int[], int[])[] TestPairs =
        {
            (new[] {0, 1, 2, 3, 4, 5, 6, 7, 8}, new[] {0, 1, 2, 4, 8, 3, 5, 6, 7}),
            (new[] {1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1}, new[] {1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024}),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (n, expected) = TestPairs[i];

                var result = SortByBits(n);
                if (result.SequenceEqual(expected))
                    Console.WriteLine($"Test {name} #{i + 1} passed");
                else
                {
                    Console.WriteLine($"Test {name} #{i + 1} failed");
                    Console.WriteLine("Expected:");
                    Console.WriteLine($"[{string.Join(", ", expected)}]");
                    Console.WriteLine("Given:");
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                }
            }
        }
    }
}