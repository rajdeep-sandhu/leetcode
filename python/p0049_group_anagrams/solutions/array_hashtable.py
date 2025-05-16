# Time complexity: O(n * k)
# Space complexity: O(n * k)
# where n = number of words, k = length of the longest word

from collections import defaultdict
from typing import List


class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:

        anagram_map: defaultdict = defaultdict(list)

        for word in strs:
            freq_map = [0] * 26

            for letter in word:
                freq_map[ord(letter) - ord("a")] += 1

            anagram_map[tuple(freq_map)].append(word)

        return list(anagram_map.values())
