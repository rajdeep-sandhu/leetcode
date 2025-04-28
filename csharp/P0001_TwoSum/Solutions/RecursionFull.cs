// Time complexity: O(n^2)
// Space complexity: O(n)

namespace P0001_TwoSum.Solutions.RecursionFull;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] FindIndices(int i, int j)
        {
            // Base case
            if (i >= nums.Length)
                return [-1];  // No solution found

            // Recursive case
            if (j >= nums.Length)
                // Get next i, set j to the following index
                return FindIndices(i + 1, i + 2);
            
            if (nums[i] + nums[j] == target)
                return [i, j];
            
            // Get next j for the same i
            return FindIndices(i, j + 1);
        }

        return FindIndices(0, 1);
    }
}