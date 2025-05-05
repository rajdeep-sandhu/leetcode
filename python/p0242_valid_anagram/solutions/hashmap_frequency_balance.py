# Time complexity: O(n)
# Space complexity: O(n)


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
