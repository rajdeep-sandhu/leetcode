namespace P0217_ContainsDuplicate.Solutions.FrequencyMapGroupBy;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        return nums
            .GroupBy(num => num)  // group duplicates
            .Any(numGroup => numGroup.Count() > 1);  // true if a group has more than 1 element
    }
}