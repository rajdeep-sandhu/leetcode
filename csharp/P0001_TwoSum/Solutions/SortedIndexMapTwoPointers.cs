// Time complexity: O(n log n)
// Space complexity: O(n)

namespace P0001_TwoSum.Solutions.SortedIndexMapTwoPointers;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // Create sorted index map
        var sortedMap = new (int num, int index)[nums.Length];

        for (int i = 0; i < nums.Length; i++)
            sortedMap[i] = (nums[i], i);

        Array.Sort(sortedMap, (a, b) =>
            a.num.CompareTo(b.num));
        
        // Locate correct indices
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            int currSum = sortedMap[left].num + sortedMap[right].num;

            if (currSum < target)
                left++;
            else if (currSum > target)
                right--;
            else
                return [sortedMap[left].index, sortedMap[right].index];
        }

        return [-1];
    }
}
