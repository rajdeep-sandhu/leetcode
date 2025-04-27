# Time complexity: O(n log n)
# Space complexity: O(n)

from typing import List, Tuple


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        sorted_map = sorted((num, i) for i, num in enumerate(nums))

        def binary_search(left: int, right: int, search_val: int) -> int:
            # Return index of search_val in sorted_map
            while left <= right:
                mid = left + (right - left) // 2

                if sorted_map[mid][0] == search_val:
                    return mid
                elif sorted_map[mid][0] < search_val:
                    left = mid + 1
                else:
                    right = mid - 1
            
            return -1


        for i, (num, index) in enumerate(sorted_map):
            complement = target - num

            # Search only in the remaining list
            j = binary_search(i + 1, len(sorted_map) - 1, complement)

            if j != -1:
                return [index, sorted_map[j][1]]
