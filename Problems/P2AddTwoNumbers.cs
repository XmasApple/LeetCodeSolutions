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
    }

    public class P2AddTwoNumbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
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
    }
}