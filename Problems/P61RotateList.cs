using System;
using System.Linq;
using System.Reflection;
using LeetCodeSolutions.Structs;

namespace LeetCode.Problems
{
    public class P61RotateList
    {
        public static ListNode RotateRight(ListNode head, int k)
        {
            var curr = head;
            var len = 1;
            while (curr.next != null)
            {
                curr = curr.next;
                len += 1;
            }

            curr.next = head;
            k %= len;
            for (var i = 0; i < len - k; i++) curr = curr.next;
            head = curr.next;
            curr.next = null;

            return head;
        }


        private static readonly ((int[], int), int[])[] TestPairs =
        {
            ((new[] {1, 2, 3, 4, 5}, 2), new[] {4, 5, 1, 2, 3}),
            ((new[] {0, 1, 2}, 4), new[] {2, 0, 1}),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((head, k), expected) = TestPairs[i];

                var result = RotateRight(new ListNode(head), k).ToList();
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