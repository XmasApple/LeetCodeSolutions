using System;
using System.Linq;
using System.Reflection;
using LeetCodeSolutions.Structs;

namespace LeetCodeSolutions.Problems
{
    public static class P773FloodFill
    {
        public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            var oldColor = image[sr][sc];
            if (oldColor != newColor)
                Fill(ref image, sr, sc, newColor, oldColor);
            return image;
        }

        public static void Fill(ref int[][] image, int sr, int sc, int newColor, int oldColor)
        {
            // Console.WriteLine(string.Join(", ", image.Select(t => $"[{string.Join(", ", t)}]").ToArray()));
            var height = image.Length;
            var width = image[0].Length;
            // Console.WriteLine($"{sr}, {sc}, {height}, {width}");
            if (sr >= 0 && sr < height && sc >= 0 && sc < width && image[sr][sc] == oldColor)
            {
                image[sr][sc] = newColor;
                Fill(ref image, sr + 1, sc, newColor, oldColor);
                Fill(ref image, sr - 1, sc, newColor, oldColor);
                Fill(ref image, sr, sc + 1, newColor, oldColor);
                Fill(ref image, sr, sc - 1, newColor, oldColor);
            }
        }


        private static readonly ((int[][], int, int, int), int[][])[] TestPairs =
        {
            ((new[]
                {
                    new[] {1, 1, 1},
                    new[] {1, 1, 0},
                    new[] {1, 0, 1}
                }, 1, 1, 2),
                new[]
                {
                    new[] {2, 2, 2},
                    new[] {2, 2, 0},
                    new[] {2, 0, 1}
                }),
            ((new[]
                {
                    new[] {0, 0, 0},
                    new[] {0, 0, 0},
                }, 0, 0, 2),
                new[]
                {
                    new[] {2, 2, 2},
                    new[] {2, 2, 2},
                }),
            ((new[]
                {
                    new[] {0, 0, 0},
                    new[] {0, 1, 1},
                }, 1, 1, 1),
                new[]
                {
                    new[] {0, 0, 0},
                    new[] {0, 1, 1},
                }),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((image, sr, sc, newColor), expected) = TestPairs[i];
                var result = FloodFill(image, sr, sc, newColor);
                var equal = result.Length == expected.Length && result[0].Length == expected[0].Length;
                if (equal)
                    for (var index = 0; index < result.Length; index++)
                    {
                        var rRow = result[index];
                        var eRow = expected[index];
                        if (rRow.SequenceEqual(eRow)) continue;
                        equal = false;
                        break;
                    }

                if (equal)
                    Console.WriteLine($"Test {name} #{i + 1} passed");
                else
                {
                    Console.WriteLine($"Test {name} #{i + 1} failed");
                    Console.WriteLine("Expected:");
                    Console.WriteLine(string.Join(", ", expected.Select(t => $"[{string.Join(", ", t)}]").ToArray()));
                    Console.WriteLine("Given:");
                    Console.WriteLine(string.Join(", ", result.Select(t => $"[{string.Join(", ", t)}]").ToArray()));
                }
            }
        }
    }
}