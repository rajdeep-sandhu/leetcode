// Time complexity: O(n^2)
// Space complexity: O(n)

namespace P0001_TwoSum.Solutions.RecursionIteration;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] FindIndices(int i)
        {
            // Base case
            if (i >= nums.Length)
                return [-1];  // No solution found

            // Recursive case
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }

            return FindIndices(i + 1);
        }

        return FindIndices(0);
    }
}
