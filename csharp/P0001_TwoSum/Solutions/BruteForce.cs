namespace P0001_TwoSum.Solutions.BruteForce;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // Iterate to the penultimate index. The last will be j
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }

        // This should be unreachable
        return [-1];
    }
}