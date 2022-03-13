using System;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public static class P6ReturnTheIntegerAsTheFinalResult
    {
        public static int MyAtoi(string s)
        {
            int sign = 1, res = 0, i = 0;
            while (i < s.Length && s[i] == ' ') { i++; }
            if (i < s.Length && (s[i] == '-' || s[i] == '+')) {
                sign = 1 - (s[i++] == '-'?2:0); 
            }
            while (i < s.Length && s[i] >= '0' && s[i] <= '9') {
                if (res >  int.MaxValue / 10 || res == int.MaxValue / 10 && s[i] - '0' > 7)
                    return sign == 1 ? int.MaxValue : int.MinValue;
                res  = 10 * res + (s[i++] - '0');
            }
            return res * sign;
        }

        private static readonly (string, int)[] TestPairs =
        {
            ("42", 42),
            ("   -42", -42),
            ("4193 with words", 4193),
            ("words and 987", 0),
            ("-91283472332", int.MinValue),
            ("", 0),
            (" ", 0),
            ("9223372036854775808", 2147483647),
            ("-9223372036854775809", -2147483648),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var (s, expected) = TestPairs[i];

                var result = MyAtoi(s);
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