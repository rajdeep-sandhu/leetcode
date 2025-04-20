using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace P0217_ContainsDuplicate.Tests
{
    public class TestCase
    {
        public int[] input { get; set; } = Array.Empty<int>();
        public bool expected { get; set; }
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

        private static readonly List<TestCase> testCases = LoadTestCases();

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
        public void TestContainsDuplicate(TestCase testCase)
        {
            foreach (var solution in _solutions)
            {
                Assert.That(solution, Is.Not.Null, "Solution instance should not be null");

                bool result = solution!.ContainsDuplicate(testCase.input);
                string outputMessage = $"Input: [{string.Join(", ", testCase.input)}], Expected: {testCase.expected}, Actual: {result}";

                TestContext.Out.WriteLine($"Testing {solution}");
                TestContext.Out.WriteLine(outputMessage);
                
                Assert.That(result, Is.EqualTo(testCase.expected),
                    $"Solution {solution.GetType().Name}: failed for {outputMessage}");
            }
        }
    }
}
