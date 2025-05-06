// Time complexity: O(n^2)
// Space complexity: O(1)

using System.Linq;

namespace P0242_ValidAnagram.Solutions.BruteForce;

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        foreach (char letter in s)
            if (s.Count(c => c == letter) != t.Count(c => c == letter))
                return false;

        return true;
    }
}