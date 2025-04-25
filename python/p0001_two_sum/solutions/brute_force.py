# Time complexity: O(n^2)
# Space complexity: O(n)

from typing import List


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        for i, num in enumerate(nums):
            complement = target - num
            for j in range(i + 1, len(nums)):
                if nums[j] == complement:
                    return [i, j]
