# Time complexity: O(n + k), practically O(n) if k is small
# Space complexity: O(k)
# where k = number of unique characters


class Solution:
    def isAnagram(self, s: str, t: str) -> bool:

        if len(s) != len(t):
            return False

        freq_map = {}

        for i in range(len(s)):
            freq_map[s[i]] = freq_map.get(s[i], 0) + 1
            freq_map[t[i]] = freq_map.get(t[i], 0) - 1

        # For an anagram, the balance of frequencies is 0 for each character
        return all(count == 0 for count in freq_map.values())
