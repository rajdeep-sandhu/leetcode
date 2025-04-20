using System.Reflection.Metadata.Ecma335;

namespace P0217_ContainsDuplicate.Solutions.FrequencyMapCounter;

// Manual implementation similar to Python collections.Counter
public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var freq = new Dictionary<int, int>();

        foreach (var num in nums)
            freq[num] = freq.GetValueOrDefault(num) + 1;
        
        return freq.Values.Any(x => x > 1);
    }
}