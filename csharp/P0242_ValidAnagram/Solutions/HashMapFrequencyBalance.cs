// Time complexity: O(n + k log k), practically O(n) if k is small
// Space complexity: O(k)
// where k = number of unique characters

namespace P0242_ValidAnagram.Solutions.HashMapFrequencyBalance;

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> freqMap = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            freqMap[s[i]] = freqMap.GetValueOrDefault(s[i], 0) + 1;
            freqMap[t[i]] = freqMap.GetValueOrDefault(t[i], 0) - 1;
        }

        return freqMap.All(kv => kv.Value == 0);
    }
}