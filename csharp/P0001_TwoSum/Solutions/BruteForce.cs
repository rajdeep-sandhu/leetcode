// Time complexity: O(n^2)
// Space complexity: O(n)

namespace P0001_TwoSum.Solutions.BruteForce;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // Iterate to the penultimate index. The last index will be j
        for (int i = 0; i < nums.Length - 1; i++)
        {
            int complement = target - nums[i];

            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] == complement)
                    return [i, j];
            }
        }

        // This should be unreachable
        return [-1];
    }
}
