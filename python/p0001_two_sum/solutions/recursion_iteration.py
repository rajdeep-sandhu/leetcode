# Time complexity: O(n^2)
# Space complexity: O(n)

from typing import List


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        
        def find_indices(i: int) -> List[int]:
            
            # Base case
            if i >= len(nums):
                return [-1]
            
            # Recursive case
            for j in range(i + 1, len(nums)):
                if nums[i] + nums[j] == target:
                    return [i, j]
            
            return find_indices(i + 1)
        
        return find_indices(0)
