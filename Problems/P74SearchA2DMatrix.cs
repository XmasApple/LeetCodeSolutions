using System;
using System.Linq;
using System.Reflection;

namespace LeetCodeSolutions.Problems
{
    public static class P74SearchA2DMatrix
    {
        public static bool SearchMatrix(int[][] matrix, int target) =>
            matrix.SelectMany(t => t).Any(t1 => t1 == target);

        public static bool SearchMatrixBinary(int[][] matrix, int target)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var potentialRow = -1;

            for (var i = 0; i < m; i++)
                if (target >= matrix[i][0])
                    potentialRow = i;

            if (potentialRow == -1)
                return false;

            for (var j = 0; j < n; j++)
                if (matrix[potentialRow][j] == target)
                    return true;

            return false;
        }


        private static readonly ((int[][], int), bool)[] TestPairs =
        {
            ((new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } }, 3), true),
            ((new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } }, 13), false),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((matrix, target), expected) = TestPairs[i];

                var result = SearchMatrix(matrix, target);
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

        public static void TestBinary()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((matrix, target), expected) = TestPairs[i];

                var result = SearchMatrixBinary(matrix, target);
                if (result == expected)
                    Console.WriteLine($"TestBinary {name} #{i + 1} passed");
                else
                {
                    Console.WriteLine($"TestBinary {name} #{i + 1} failed");
                    Console.WriteLine("Expected:");
                    Console.WriteLine(expected);
                    Console.WriteLine("Given:");
                    Console.WriteLine(result);
                }
            }
        }
    }
}