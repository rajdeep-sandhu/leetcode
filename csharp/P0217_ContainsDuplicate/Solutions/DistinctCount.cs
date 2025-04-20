namespace P0217_ContainsDuplicate.Solutions.DistinctCount;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        return nums.Length != nums.Distinct().Count();
    }
}