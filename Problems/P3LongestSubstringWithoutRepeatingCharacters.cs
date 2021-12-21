namespace LeetCode.Problems
{
    public class P3LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            var max = 0;
            var cache = new int[256];
            for (int i = 0, last = 0; i < s.Length; i++)
            {
                var c = s[i];
                last = cache[c] == 0 ? last : last > cache[c] ? last : cache[c];
                cache[c] = i + 1;
                max = max > i - last + 1 ? max : i - last + 1;
            }

            return max;
        }
    }
}