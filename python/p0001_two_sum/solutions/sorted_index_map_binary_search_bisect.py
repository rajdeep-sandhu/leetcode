# Time complexity: O(n log n)
# Space complexity: O(n)

import bisect
from typing import List


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        sorted_map = sorted((num, i) for i, num in enumerate(nums))

        for i, (num, index) in enumerate(sorted_map):
            complement = target - num

            j = bisect.bisect_left(sorted_map, (complement, -1), lo = i + 1)

            if j < len(sorted_map) and sorted_map[j][0] == complement:
                return [index, sorted_map[j][1]]
