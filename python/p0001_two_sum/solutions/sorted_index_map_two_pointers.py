# Time complexity: O(n log n)
# Space complexity: O(n)

from typing import List


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        # Sort the numbers as (number, index) tuples to preserve original indices
        sorted_map = sorted((num, i) for i, num in enumerate(nums))

        left, right = 0, len(nums) - 1

        while left < right:
            curr_sum = sorted_map[left][0] + sorted_map[right][0]

            if curr_sum < target:
                left += 1
            elif curr_sum > target:
                right -= 1
            else:
                # Return mapped indices
                return [sorted_map[left][1], sorted_map[right][1]]
