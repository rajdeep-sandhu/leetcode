# Time complexity: O(m + n)
# Space complexity: O(m + n)
# where m = len(s), n = len(t)


class Solution:
    def isAnagram(self, s: str, t: str) -> bool:

        def build_hashmap(word: str) -> dict:
            freq_map = {}

            for letter in word:
                if letter in freq_map.keys():
                    freq_map[letter] += 1
                else:
                    freq_map[letter] = 1

            return freq_map

        s_freq_map = build_hashmap(s)
        t_freq_map = build_hashmap(t)

        for letter, freq in s_freq_map.items():
            if letter not in t_freq_map:
                return False
            else:
                if t_freq_map[letter] != freq:
                    return False

        return True
