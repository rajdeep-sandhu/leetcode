using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// Amend per problem.
namespace P0049_GroupAnagrams.Tests;


public static class Helper
{
    /// Decodes the json input string into a typed InputModel.
    public static Dictionary<string, object> DecodeInput(JObject rawInput)
    {
        return new Dictionary<string, object>
        {
            ["strs"] = rawInput["strs"]?.ToObject<string[]>()
                ?? throw new InvalidOperationException("'strs' field is missing or null.")
        };
    }

    /// Normalizes a List<List<String>> by sorting the inner and outer lists
    public static List<List<String>> NormalizeList(List<List<String>> data)
    {
        return data
            .Select(group => group.OrderBy(word => word).ToList())
            .OrderBy(group => String.Join(",", group))
            .ToList();
    }

    public static String FormatListOfLists(List<List<String>> data)
    {
        return "[" + String.Join(", ", data
            .Select(group => "[" + String.Join(", ", group) + "]")
            ) + "]";
    }
}