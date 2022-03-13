using System;
using System.Linq;
using System.Reflection;
using LeetCode.Structs;

namespace LeetCode.Problems
{
    public static class P876MiddleOfTheLinkedList
    {
        public static ListNode MiddleNode(ListNode head)
        {
            var count = 1;
            var current = head;
            while (current.next != null)
            {
                count++;
                current = current.next;
            }

            current = head;
            for (var i = 0; i < count/2; i++)
            {
                current = current.next;
            }
            return current;
        }


        private static readonly (int[], int[])[] TestPairs =
        {
            (new []{1,2,3,4,5}, new []{3,4,5}),
            (new []{1,2,3,4,5,6}, new []{4,5,6}),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (head, expected) = TestPairs[i];

                var result = MiddleNode(new ListNode(head)).ToList();
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