from typing import List


class Solution:
    def findDuplicate(self, nums: List[int]) -> int:
        n = len(nums) - 1
        max_bits = n.bit_length()
        duplicate = 0

        for i in range(max_bits):
            bit_mask = 1 << i  # set the bit in position i.

            # Count the number of list elements with the bit set.
            count_nums = sum(1 for num in nums if num & bit_mask)
            # Count the number of elements in range with the bit set
            count_range = sum(1 for num in range(1, n + 1) if num & bit_mask)

            # If more numbers in the list have the bit set than expected, it is a duplicate.
            # Add the bit to the duplicate.
            if count_nums > count_range:
                duplicate |= bit_mask

        return duplicate
