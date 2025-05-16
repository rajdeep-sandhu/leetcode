# Time complexity: O(n * k log k)
# Space complexity: O(n)
# where n = number of words, k = length of the longest word

from collections import defaultdict
from typing import List


class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:

        anagram_map: defaultdict = defaultdict(list)

        for word in strs:
            word_sorted: List = "".join(sorted(word))
            anagram_map[word_sorted].append(word)

        return list(anagram_map.values())
