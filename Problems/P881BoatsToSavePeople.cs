using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P881BoatsToSavePeople
    {
        public static int NumRescueBoats(int[] people, int limit)
        {
            var pip = people.ToList();
            pip.Sort();

            var r = 0;
            for (int i = 0, j = pip.Count - 1; i <= j; j -= 1, r++)
            {
                if (pip[i] + pip[j] <= limit)
                    i += 1;
            }

            return r;
        }

        private static readonly ((int[], int), int)[] TestPairs =
        {
            ((new[] {1, 2}, 3), 1),
            ((new[] {3, 2, 2, 1}, 3), 3),
            ((new[] {3, 5, 3, 4}, 5), 4),
            ((new[] {2, 2}, 6), 1),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((nums, target), expected) = TestPairs[i];

                var result = NumRescueBoats(nums, target);
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