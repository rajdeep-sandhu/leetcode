// Time complexity: O(n log n)
// Space complexity: O(n)

namespace P0001_TwoSum.Solutions.SortedIndexMapBinarySearch;

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


        // Return index of searchVal in sorted map
        int BinarySearch(int left, int right, int searchVal)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedMap[mid].num == searchVal)
                    return mid;
                else if (sortedMap[mid].num < searchVal)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            // This should be unreachable
            return -1;
        }


        // Locate correct indices
        for (int i = 0; i < sortedMap.Length; i++)
        {
            int num = sortedMap[i].num;
            int index = sortedMap[i].index;
            int complement = target - num;

            int j = BinarySearch(i + 1, sortedMap.Length - 1, complement);

            if (j != -1)
                return [index, sortedMap[j].index];
        }

        // This should be unreachable
        return [-1];
    }
}
