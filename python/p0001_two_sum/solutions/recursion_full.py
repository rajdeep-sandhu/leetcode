# Time complexity: O(n^2)
# Space complexity: O(n)

from typing import List


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        
        def find_indices(i: int, j: int) -> List[int]:
            
            # Base case
            if i >= len(nums):
                return None
            
            # Recursive case
            if j >= len(nums):
                # Get next i, set j to the following index
                return find_indices(i + 1, i + 2)
            
            if nums[i] + nums[j] == target:
                return [i, j]
            
            # Get next j for the same i
            return find_indices(i, j + 1)
        
        return find_indices(0, 1)
