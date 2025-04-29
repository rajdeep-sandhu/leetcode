// Time complexity: O(n)
// Space complexity: O(n)

namespace P0001_TwoSum.Solutions.HashMapTwoPass;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> seen = new Dictionary<int, int>();

        // Populate hashmap
        for (int i = 0; i < nums.Length; i++)
            seen[nums[i]] = i;

        // Locate complement in hashmap
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (seen.ContainsKey(complement) && seen[complement] != i)
                return [i, seen[complement]];
        }

            // This should be unreachable
            return [-1];
    }
}
