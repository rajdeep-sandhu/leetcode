# Time complexity: O(n)
# Space complexity: O(n)

from collections import defaultdict
from typing import List


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        seen = defaultdict(list)

        for i, num in enumerate(nums):
            seen[num].append(i)

        for i, num in enumerate(nums):
            complement = target - num
            if complement in seen:
                for j in seen[complement]:
                    if j != i:
                        return [i, j]
