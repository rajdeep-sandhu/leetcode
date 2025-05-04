# Time complexity: O(m + n), O(n) simplified
# Space complexity: O(m + n), O(n) simplified
# where m = len(s), n = len(t)


class Solution:
    def isAnagram(self, s: str, t: str) -> bool:

        if len(s) != len(t):
            return False

        s_freq_map, t_freq_map = {}, {}

        for i in range(len(s)):
            s_freq_map[s[i]] = s_freq_map.get(s[i], 0) + 1
            t_freq_map[t[i]] = t_freq_map.get(t[i], 0) + 1

        return s_freq_map == t_freq_map
