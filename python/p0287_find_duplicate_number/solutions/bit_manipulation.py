from typing import List


class Solution:
    def findDuplicate(self, nums: List[int]) -> int:
        n = len(nums) - 1
        max_bits = n.bit_length()
        duplicate = 0

        for i in range(max_bits):
            bit_mask = 1 << i  # set the bit in position i.
            count_nums = 0
            count_range = 0
            
            # Count the number of list elements with the bit set.
            for num in nums:
                if num & bit_mask:
                    count_nums += 1
            
            # Count the number of elements in range with the bit set
            for num in range(1, n + 1):
                if num & bit_mask:
                    count_range += 1

            # If more numbers in the list have the bit set than expected, it is a duplicate.
            # Add the bit to the duplicate.
            if count_nums > count_range:
                duplicate |= bit_mask

        return duplicate
