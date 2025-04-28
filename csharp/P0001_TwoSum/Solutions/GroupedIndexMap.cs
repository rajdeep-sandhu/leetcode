// Time complexity: O(n)
// Space complexity: O(n)

namespace P0001_TwoSum.Solutions.GroupedIndexMap;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // Build grouped index map
        var seen = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!seen.ContainsKey(nums[i]))
                seen[nums[i]] = new List<int>();
            
            seen[nums[i]].Add(i);
        }

        // Locate complement in index map
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (seen.ContainsKey(complement))
            {
                foreach (int j in seen[complement])
                    if (j != i)
                        return [i, j];
            }
        }
        
        // This should be unreachable
        return [-1];
    }
}
