# Time complexity: O(n * k log k)
# Space complexity: O(n)
# where n = number of words, k = average length of a word

from typing import List


class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:

        anagram_map: dict = {}

        for word in strs:
            word_sorted = "".join(sorted(word))

            if word_sorted in anagram_map:
                anagram_map[word_sorted].append(word)
            else:
                anagram_map[word_sorted] = [word]

        anagrams_grouped = [group for group in anagram_map.values()]

        return anagrams_grouped
