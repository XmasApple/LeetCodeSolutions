using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeetCode.Problems
{
    public class P1807EvaluateTheBracketPairsOfAString
    {
        public static string Evaluate(string s, IList<IList<string>> knowledge)
        {
            var dict = knowledge.ToDictionary(pair => pair[0], pair => pair[1]);
            var r = new List<string>();
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != '(')
                    r.Add(s[i].ToString());
                else
                {
                    var j = i + 1;
                    while (s[j] != ')') j++;
                    var key = s[(i+1)..j];
                    i = j;
                    r.Add(dict.GetValueOrDefault(key, "?"));
                }
            }

            return string.Join("", r);
        }

        private static readonly ((string, IList<IList<string>>), string)[] TestPairs =
        {
            (("(name)is(age)yearsold", new IList<string>[] {new[] {"name", "bob"}, new[] {"age", "two"}}),
                "bobistwoyearsold"),
            (("hi(name)", new IList<string>[] {new[] {"a", "b"}}), "hi?"),
        };

        public static void Test()
        {
            var name = MethodBase.GetCurrentMethod()?.DeclaringType?.Name.Split('.').Last();
            for (var i = 0; i < TestPairs.Length; i++)
            {
                var ((s, knowledge), expected) = TestPairs[i];

                var result = Evaluate(s, knowledge);
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