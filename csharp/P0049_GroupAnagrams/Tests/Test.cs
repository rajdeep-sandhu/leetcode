using NUnit.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
// Amend per problem.
using P0049_GroupAnagrams.Tests;

namespace P0049_GroupAnagrams.Tests;

// Amend per problem.
public class TestCase
{
    [JsonProperty("case_name")]
    public string caseName { get; set; } = "Unnamed case";

    [JsonProperty("input")]
    public JObject input { get; set; } = new();

    [JsonProperty("expected")]
    public List<List<String>> expected { get; set; } = new();

    // Override ToString() to display caseName in test runner output
    public override string ToString() => caseName;
}

[TestFixture]
public class Tests
{
    private static readonly string TestCasesFile = Path.Combine(
        Path.GetDirectoryName(typeof(Tests).Assembly.Location) ?? "",
        "Tests",
        "test_cases.json"
        );

    private static List<TestCase> LoadTestCases()
    {
        if (!File.Exists(TestCasesFile))
            throw new FileNotFoundException($"Test cases file not found: {TestCasesFile}");

        string json = File.ReadAllText(TestCasesFile);
        return JsonConvert.DeserializeObject<List<TestCase>>(json) ?? new List<TestCase>();
    }

    private static readonly IEnumerable<TestCase> testCases = LoadTestCases();

    private List<dynamic?> _solutions = new();

    [OneTimeSetUp]
    public void Setup()
    {
        // Dynamically find all classes named Solution in the solutions folder.
        var assembly = Assembly.GetExecutingAssembly()
            ?? throw new InvalidOperationException("Could not get executing assembly");

        // Get root namespace
        var testNs = typeof(Tests).Namespace!;
        var rootNs = testNs.Substring(0, testNs.LastIndexOf("."));

        var solutionTypes = assembly.GetTypes()
            .Where(t =>
                t.Name == "Solution"
                && t.IsClass
                && !t.IsAbstract
                && t.Namespace != null
                && t.Namespace.StartsWith(rootNs + ".Solutions")
                && t.GetMethods(BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.DeclaredOnly)
                    .Length == 1
            ).ToList();

        if (!solutionTypes.Any())
            throw new InvalidOperationException($"No Solution classes found under {rootNs}.Solutions");

        _solutions = solutionTypes
            .Select(t => (dynamic?)Activator.CreateInstance(t))
            .ToList();
    }

    [Test]
    [TestCaseSource(nameof(testCases))]
    // Amend per problem
    public void TestGroupAnagrams(TestCase testCase)
    {
        foreach (var solution in _solutions)
        {
            Assert.That(solution, Is.Not.Null, "Solution instance should not be null");

            // Amend per problem.
            var inputDecoded = Helper.DecodeInput(testCase.input);
            var strs = (string[])inputDecoded["strs"];

            // Amend per problem.
            var rawResult = solution!.GroupAnagrams(strs);

            // Explicit conversion of dynamic result to List<List<String>>
            var result = ((IEnumerable<IEnumerable<String>>)rawResult)
                .Select(inner => inner.ToList())
                .ToList();

            var expectedSorted = Helper.NormalizeList(testCase.expected);
            var resultSorted = Helper.NormalizeList(result);


            // Amend per problem.
            string outputMessage = $"Input: strs = [{string.Join(", ",strs)}]. " +
                $"Expected: {Helper.FormatListOfLists(testCase.expected)}. " +
                $"Actual: {Helper.FormatListOfLists(result)}.";

            TestContext.Out.WriteLine($"Testing {solution} [Case: {testCase.caseName}]");
            TestContext.Out.WriteLine(outputMessage);

            Assert.That(resultSorted, Is.EqualTo(expectedSorted),
                $"Solution {solution.GetType().Name}: failed for {outputMessage}");
        }
    }
}

