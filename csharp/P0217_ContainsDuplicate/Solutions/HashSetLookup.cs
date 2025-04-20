namespace P0217_ContainsDuplicate.Solutions.HashSetLookup;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var seen = new HashSet<int>();

        foreach (var num in nums)
            if (!seen.Add(num))  //.Add() returns false if the item exists
                return true;
        
        return false;
    }
}