# Time complexity: O(n)
# Space complexity: O(1)


class Solution:
    def isAnagram(self, s: str, t: str) -> bool:

        if len(s) != len(t):
            return False

        # Index represents letter, value represents count
        freq_table = [0] * 26

        # Get frequency balance between strings
        for i in range(len(s)):
            freq_table[ord(s[i]) - ord("a")] += 1
            freq_table[ord(t[i]) - ord("a")] -= 1

        # For an anagram, the balance of frequencies is 0 for each character
        return all(x == 0 for x in freq_table)
