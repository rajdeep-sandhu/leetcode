namespace P0287_FindDuplicateNumber.FloydsAlgorithm;

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        // Phase 1: Find intersection point inside the cycle
        int slow = nums[0];
        int fast = nums[nums[0]];
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }

        // Phase 2: Find cycle entrance (the duplicate number)
        slow = 0;
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}