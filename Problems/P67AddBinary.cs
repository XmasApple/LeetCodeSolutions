using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P67AddBinary
    {
        public static string AddBinary(string a, string b)
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

        private static readonly ((string, string), string)[] TestPairs =
        {
            (("11", "1"),"100"),
            (("1010", "1011"),"10101"),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((a,b), expected) = TestPairs[i];

                var result = AddBinary(a, b);
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