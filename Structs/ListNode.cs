using System.Collections.Generic;

namespace LeetCodeSolutions.Structs
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
            val = arr[ind];
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
}