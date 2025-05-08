// Time complexity: O(n log n)
// Space complexity: O(n)

namespace P0242_ValidAnagram.Solutions.SortingOrderBy;

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var sortedS = string.Join("", s.OrderBy(x => x));
        var sortedT = string.Join("", t.OrderBy(x => x));

        return sortedS == sortedT;
    }
}