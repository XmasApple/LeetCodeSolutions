using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P1610MaximumNumberOfVisiblePoints
    {
        public static int VisiblePoints(IList<IList<int>> points, int angle, IList<int> location)
        {
            var max = 0;
            var angles = new List<float>();
            var count = 0;
            foreach(var p in points) {
                var dx = p[0] - location[0];
                var dy = p[1] - location[1];
                if (dx == 0 && dy == 0) { 
                    count++;
                    continue;
                } 
                var degrees = MathF.Atan2(dx, dy) * (180.0f / MathF.PI);
                angles.Add(degrees);
                angles.Add(degrees + 360);
            }
            angles.Sort();
            var size = angles.Count;
            
            for (int slow = 0, fast = 0; fast < size && slow < size / 2;)
                if (angles[fast] - angles[slow] <= angle)
                {
                    max = Math.Max(max, fast - slow + 1);
                    if (max >= size / 2)
                        break;
                    fast++;
                }
                else
                    slow++;

            return count + max;
        }

        private static readonly ((IList<IList<int>>, int, IList<int>), int)[] TestPairs =
        {
            ((new IList<int>[] {new[] {2, 1}, new[] {2, 2}, new[] {3, 3}}, 90, new[] {1, 1}), 3),
            ((new IList<int>[] {new[] {2, 1}, new[] {2, 2}, new[] {3, 4}, new[] {1, 1}}, 90, new[] {1, 1}), 4),
            ((new IList<int>[] {new[] {1, 0}, new[] {2, 1}}, 13, new[] {1, 1}), 1),
            ((new IList<int>[] {new[] {0, 0}, new[] {0, 2}}, 90, new[] {1, 1}), 2),
        };


        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((points, angle, location), expected) = TestPairs[i];

                var result = VisiblePoints(points, angle, location);
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