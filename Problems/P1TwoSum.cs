using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class P1TwoSum
    {
        public int[] TwoSum1(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                var t = target - nums[i];
                for (var j = i + 1; j < nums.Length; j++)
                    if (nums[j] == t)
                        return new[] { i, j };
            }

            return new int[2];
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    return new[] { dict[nums[i]], i };
                if (!dict.ContainsKey(target - nums[i])) dict.Add(target - nums[i], i);
            }

            return new int[2];
        }
    }
}