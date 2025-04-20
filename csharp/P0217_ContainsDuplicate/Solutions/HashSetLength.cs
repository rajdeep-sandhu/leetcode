namespace P0217_ContainsDuplicate.Solutions.HashSetLength;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        return new HashSet<int>(nums).Count < nums.Length;
    }
}