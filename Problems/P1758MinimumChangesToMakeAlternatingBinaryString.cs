namespace LeetCode.Problems
{
    public class P1758MinimumChangesToMakeAlternatingBinaryString
    {
        public int MinOperations(string s)
        {
            var c0 = 0;
            var c1 = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == (i % 2 == 0 ? '0' : '1'))
                    c0 += 1;
                else
                    c1 += 1;
            }

            return c0 < c1 ? c0 : c1;
        }
    }
}