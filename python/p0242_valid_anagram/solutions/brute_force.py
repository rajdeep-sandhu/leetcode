# Time complexity: O(n^2)
# Space complexity: O(1)


class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        if len(s) != len(t):
            return False

        for letter in s:
            if s.count(letter) != t.count(letter):
                return False

        return True
