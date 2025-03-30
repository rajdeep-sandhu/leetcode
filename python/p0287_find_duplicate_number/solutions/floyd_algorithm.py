from typing import List

class Solution:
    def findDuplicate(self, nums: List[int]) -> int:
        # Phase 1: Find intersection point inside the cycle
        slow, fast = nums[0], nums[nums[0]]
        while slow != fast:
            slow = nums[slow]
            fast = nums[nums[fast]]
        
        # Phase 2: Find cycle entrance (the duplicate number)
        slow = 0
        while slow != fast:
            slow = nums[slow]
            fast = nums[fast]

        return slow
