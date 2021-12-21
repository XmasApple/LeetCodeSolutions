namespace LeetCode.Problems
{
    public class P66PlusOne
    {
        public int[] PlusOne(int[] digits)
        {
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                    digits[i] = 0;
                else
                {
                    digits[i] += 1;
                    return digits;
                }
            }

            var r = new int[digits.Length + 1];
            r[0] = 1;
            for (var j = 0; j < digits.Length; j++)
                r[j + 1] = digits[j];
            return r;
        }
    }
}