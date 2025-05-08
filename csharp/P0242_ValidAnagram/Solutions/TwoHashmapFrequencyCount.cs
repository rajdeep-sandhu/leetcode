// Time complexity: O(n + k log k), practically O(n) if k is small
// Space complexity: O(k)
// where k = number of unique characters

namespace P0242_ValidAnagram.Solutions.TwoHashmapFrequencyCount;

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> sFreqMap = new Dictionary<char, int>();
        Dictionary<char, int> tFreqMap = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            sFreqMap[s[i]] = sFreqMap.GetValueOrDefault(s[i], 0) + 1;
            tFreqMap[t[i]] = tFreqMap.GetValueOrDefault(t[i], 0) + 1;
        }

        return sFreqMap.Count == tFreqMap.Count && sFreqMap.OrderBy(kv => kv.Key).SequenceEqual(tFreqMap.OrderBy(kv => kv.Key));
    }
}