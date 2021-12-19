using System.Linq;

namespace LeetCode.Problems
{
    public class P1832CheckIfTheSentenceIsPangram
    {
        public bool CheckIfPangram(string sentence)
        {
            var flags = new bool[26];

            foreach (var c in sentence)
            {
                flags[c - 'a'] = true;
            }

            return flags.All(_ => _);
        }
    }
}