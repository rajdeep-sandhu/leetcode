using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// Amend per problem.
namespace P0242_ValidAnagram.Tests;


public static class Helper
{
    /// Decodes the json input string into a typed InputModel.
    public static Dictionary<string, object> DecodeInput(JObject rawInput)
    {
        return new Dictionary<string, object>
        {
            ["s"] = rawInput["s"]?.ToObject<string>()
                ?? throw new InvalidOperationException("'s' field is missing or null."),
            ["t"] = rawInput["t"]?.ToObject<string>()
                ?? throw new InvalidOperationException("'t' field is missing or null.")
        };
    }
}