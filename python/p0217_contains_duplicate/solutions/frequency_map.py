from collections import Counter
from typing import List


class Solution:
    def containsDuplicate(self, nums: List[int]) -> bool:
        freq = Counter(nums) 
        
        for freq in freq.values():
            if freq > 1:
                return True
        return False
