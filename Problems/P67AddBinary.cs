namespace LeetCode.Problems
{
    public class P67AddBinary
    {
        public string AddBinary(string a, string b)
        {
            var al = a.Length;
            var bl = b.Length;
            var l = (al > bl ? al : bl) + 1;
            var r = new char[l];

            var s = 0;
            for (var i = 1; i <= l; i++)
            {
                if (i <= al)
                    s += a[al - i] - '0';

                if (i <= bl)
                    s += b[bl - i] - '0';

                r[l - i] = (char)('0' + s % 2);
                s /= 2;
            }

            var t = r[0] == '0' ? 1 : 0;
            return new string(r, t, l - t);
        }
    }
}