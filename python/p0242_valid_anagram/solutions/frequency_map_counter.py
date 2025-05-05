# Time complexity: O(n)
# Space complexity: O(n)

from collections import Counter


class Solution:
    def isAnagram(self, s: str, t: str) -> bool:

        if len(s) != len(t):
            return False

        return Counter(s) == Counter(t)
