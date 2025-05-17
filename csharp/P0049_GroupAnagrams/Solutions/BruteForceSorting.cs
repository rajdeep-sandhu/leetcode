// Time complexity: 
// Space complexity: 

using System.Text.RegularExpressions;

namespace P0049_GroupAnagrams.Solutions.BruteForceSorting;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        // Build anagram map
        Dictionary<String, List<String>> anagramMap = new();

        foreach (String word in strs)
        {
            String wordSorted = new String(word.OrderBy(letter => letter).ToArray());

            if (!anagramMap.ContainsKey(wordSorted))
                anagramMap[wordSorted] = new List<String>();

            anagramMap[wordSorted].Add(word);
        }

        return anagramMap.Values.Cast<IList<String>>().ToList();
    }
}