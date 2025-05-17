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
            // Sort the letters in word
            char[] sChars = word.ToCharArray();
            Array.Sort(sChars);
            String wordSorted = new String(sChars);

            if (!anagramMap.ContainsKey(wordSorted))
                anagramMap[wordSorted] = new List<String>();

            anagramMap[wordSorted].Add(word);
        }

        // Build grouped list
        List<List<String>> anagramsGrouped = new();

        foreach (var group in anagramMap.Values)
        {
            anagramsGrouped.Add(group);
        }

        return anagramsGrouped.Cast<IList<String>>().ToList();
    }
}