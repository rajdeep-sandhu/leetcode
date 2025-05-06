// Time complexity: O(n)
// Space complexity: O(n)

using System.Linq;

namespace P0242_ValidAnagram.Solutions.HashMapFrequencyCountFunction;

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        Dictionary<char, int> BuildHashMap(string word)
        {
            Dictionary<char, int> freqMap = new Dictionary<char, int>();

            foreach (char letter in word)
            {
                if (freqMap.ContainsKey(letter))
                    freqMap[letter]++;
                else
                    freqMap[letter] = 1;
            }

            return freqMap;
        }

        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> sFreqMap = BuildHashMap(s);
        Dictionary<char, int> tFreqMap = BuildHashMap(t);

        foreach (var (letter, freq) in sFreqMap)
        {
            if (!tFreqMap.ContainsKey(letter))
                return false;
            else if (tFreqMap[letter] != freq)
                return false;
        }

        return true;
    }
}