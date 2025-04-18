using System.Numerics;

namespace P0287_FindDuplicateNumber.Solutions.BitManipulation;

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        int n = nums.Length - 1;
        int maxBits = sizeof(int) * 8 - BitOperations.LeadingZeroCount((uint)n);
        int duplicate = 0;

        for (int i = 0; i < maxBits; i++)
        {
            int bitMask = 1 << i;
            int countNums = 0;
            int countRange = 0;

            foreach (int num in nums)
            {
                if ((num & bitMask) != 0)
                    countNums++;
            }

            for (int num = 1; num <= n; num++)
            {
                if ((num & bitMask) != 0)
                    countRange++;
            }

            if (countNums > countRange)
                duplicate |= bitMask;
        }
        return duplicate;
    }
}