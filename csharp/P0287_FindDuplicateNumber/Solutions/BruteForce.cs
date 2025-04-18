namespace P0287_FindDuplicateNumber.BruteForce;

// LeetCode convention: the class is named "Solution"
public class Solution
{
    // Brute force implementation
    public int FindDuplicate(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                    return nums[i];
            }
        }

        // This should never happen
        throw new ArgumentException("Input array must contain at least one duplicate");
    }
}
