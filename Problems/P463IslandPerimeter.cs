using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P463IslandPerimeter
    {
        private static int _perimetr;

        public static int IslandPerimeter(int[][] grid)
        {
            _perimetr = 0;
            var (x, y) = (0, 0);
            var flag = false;
            for (var i = 0; i < grid.Length; i++)
            {
                if (flag) break;
                for (var j = 0; j < grid[i].Length; j++)
                    if (grid[i][j] == 1)
                    {
                        (x, y) = (j, i);
                        flag = true;
                        break;
                    }
            }
            Visit(ref grid, x, y);
            return _perimetr;
        }

        public static void Visit(ref int[][] grid, int x, int y)
        {
            var height = grid.Length;
            var width = grid[0].Length;
            if (y >= 0 && y < height && x >= 0 && x < width)
            {
                if (grid[y][x] == 1)
                {
                    grid[y][x] = 2;
                    Visit(ref grid, x + 1, y);
                    Visit(ref grid, x - 1, y);
                    Visit(ref grid, x, y + 1);
                    Visit(ref grid, x, y - 1);
                }
                else if (grid[y][x] == 0)
                    _perimetr++;
            }
            else
                _perimetr++;
        }


        private static readonly (int[][], int)[] TestPairs =
        {
            (new[]
            {
                new[] {0, 1, 0, 0},
                new[] {1, 1, 1, 0},
                new[] {0, 1, 0, 0},
                new[] {1, 1, 0, 0},
            }, 16),
            (new[]
            {
                new[] {1,0},
            }, 4),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (grid, expected) = TestPairs[i];
                var result = IslandPerimeter(grid);
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