// Time complexity: O(n * k)
// Space complexity: O(n * k)
// where n = number of words, k = length of the longest word

namespace P0049_GroupAnagrams.Solutions.ArrayHashTable;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        // Build anagram map
        Dictionary<String, List<String>> anagramMap = new();

        foreach (var word in strs)
        {
            // Build frequency map for each word
            int[] frequencyMap = new int[26];

            foreach (char letter in word)
                frequencyMap[letter - 'a']++;

            // Key needs to be a string
            String key = String.Join(",", frequencyMap);

            if (!anagramMap.ContainsKey(key))
                anagramMap[key] = new List<String>();

            anagramMap[key].Add(word);
        }

        return anagramMap.Values.Cast<IList<String>>().ToList();
    }
}