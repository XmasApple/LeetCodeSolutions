using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public ListNode(int[] arr, int ind = 0)
        {
            val = arr[0];
            if (ind < arr.Length - 1)
                next = new ListNode(arr, ind + 1);
        }


        public List<int> ToList()
        {
            if (next == null) return new List<int> { val };
            var res = next.ToList();
            res.Insert(0, val);
            return res;
        }
    }

    public static class P2AddTwoNumbers
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var c = 0;
            var r = new ListNode(0);
            var n = r;
            while (l1 != null || l2 != null || c == 1)
            {
                if (l1 != null)
                {
                    c += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    c += l2.val;
                    l2 = l2.next;
                }

                n.next = new ListNode(c % 10);
                n = n.next;
                c /= 10;
            }

            return r.next;
        }


        private static readonly ((int[], int[]), int[])[] TestPairs =
        {
            ((new[] { 2, 4, 3 }, new[] { 5, 6, 4 }), new[] { 7, 0, 8 }),
            ((new[] { 0 }, new[] { 0 }), new[] { 0 }),
            ((new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }), new[] { 8, 9, 9, 9, 0, 0, 0, 1 }),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType;
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((item1, item2), expected) = TestPairs[i];

                var result = AddTwoNumbers(new ListNode(item1), new ListNode(item2)).ToList();
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