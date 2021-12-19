using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class P830PositionsOfLargeGroups
    {
        public IList<IList<int>> LargeGroupPositions(string s)
        {
            var res = new List<IList<int>>();
            var start = 0;
            var t = '_';
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c != t)
                {
                    if (i - start >= 3)
                        res.Add(new List<int> { start, i - 1 });
                    t = c;
                    start = i;
                }
            }

            if (s.Length - start >= 3)
                res.Add(new List<int> { start, s.Length - 1 });

            return res;
        }
    }
}