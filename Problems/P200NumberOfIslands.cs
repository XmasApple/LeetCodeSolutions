using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P200NumberOfIslands
    {
        public static int NumIslands(char[][] grid)
        {
            var n = 0;
            for (var y = 0; y < grid.Length; y++)
            for (var x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] == '1')
                {
                    Visit(ref grid, x, y);
                    n++;
                }
            }

            return n;
        }

        public static void Visit(ref char[][] grid, int x, int y)
        {
            var height = grid.Length;
            var width = grid[0].Length;
            if (y < 0 || y >= height || x < 0 || x >= width || grid[y][x] != '1') return;
            grid[y][x] = '2';
            Visit(ref grid, x + 1, y);
            Visit(ref grid, x - 1, y);
            Visit(ref grid, x, y + 1);
            Visit(ref grid, x, y - 1);
        }


        private static readonly (char[][], int)[] TestPairs =
        {
            (new[]
            {
                new[] {'1', '1', '1', '1', '0'},
                new[] {'1', '1', '0', '1', '0'},
                new[] {'1', '1', '0', '0', '0'},
                new[] {'0', '0', '0', '0', '0'},
            }, 1),
            (new[]
            {
                new[] {'1', '1', '0', '0', '0'},
                new[] {'1', '1', '0', '0', '0'},
                new[] {'0', '0', '1', '0', '0'},
                new[] {'0', '0', '0', '1', '1'},
            }, 3),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (grid, expected) = TestPairs[i];
                var result = NumIslands(grid);
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