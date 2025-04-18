namespace P0287_FindDuplicateNumber.BinarySearch;

public class Solution
{
    // Binary search implementation
    public int FindDuplicate(int[] nums)
    {
        int left = 1, right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;  // Avoid integer overflow
            // Count numbers <= mid. If count > mid, then the duplicate number is in [1, mid]
            int count = nums.Count(num => num <= mid);
            if (count > mid)
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }
}
