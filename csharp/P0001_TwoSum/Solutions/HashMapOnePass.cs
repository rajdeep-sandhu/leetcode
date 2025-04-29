// Time complexity: O(n)
// Space complexity: O(n)

namespace P0001_TwoSum.Solutions.HashMapOnePass;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> seen = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (seen.ContainsKey(complement))
                return [seen[complement], i];

            seen[nums[i]] = i; 
        }

        // This should be unreachable
        return [-1];
    }
}
