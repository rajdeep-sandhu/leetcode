// Time complexity: O(n)
// Space complexity: O(1)

namespace P0242_ValidAnagram.Solutions.ArrayBasedHashTableFrequencyBalance;

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        char[] freqTable = new char[26];

        for (int i = 0; i < s.Length; i++)
        {
            freqTable[s[i] - 'a']++;
            freqTable[t[i] - 'a']--;
        }

        foreach (int freq in freqTable)
            if (freq != 0)
                return false;
        
        return true;
    }
}