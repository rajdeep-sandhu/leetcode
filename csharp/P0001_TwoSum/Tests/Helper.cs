using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace P0001_TwoSum.Tests;


public static class Helper
{
    /// Decodes the json input string into a typed InputModel.
    public static Dictionary<string, object> DecodeInput(JObject input)
    {
        return new Dictionary<string, object>
        {
            ["nums"] = input["nums"]?.ToObject<int[]>()
                ?? throw new InvalidOperationException("'nums' field is missing or null."),
            ["target"] = input["target"]?.ToObject<int>()
                ?? throw new InvalidOperationException("'target' field is missing or null.")
        };
    }
}