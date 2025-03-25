using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P0287_FindDuplicateNumber.Tests
{
    [TestFixture]
    public class Tests
    {
        private static readonly List<(int[] nums, int expected)> testCases = new()
        {
            // LeetCode cases
            (new int[] { 1, 3, 4, 2, 2 }, 2),
            (new int[] { 3, 1, 3, 4, 2 }, 3),
            (new int[] { 3, 3, 3, 3, 3 }, 3),
            // Minimal case
            (new int[] { 1, 1, 2 }, 1),
        };

        private List<dynamic?> _solutions = new();
        
        [OneTimeSetUp]
        public void Setup()
        {
            // Dynamically find all classes names=d Solution in the solutions folder.
            var assembly = Assembly.GetExecutingAssembly()
                ?? throw new InvalidOperationException("Could not get executing assembly");;
            var solutionTypes = assembly.GetTypes()
                .Where(t => t.Name == "Solution" && t.IsClass && !t.IsAbstract && t.Namespace != null
                        && t.GetMethod("FindDuplicate") != null)
                .ToList();
            
            if (!solutionTypes.Any())
                throw new InvalidOperationException("No Solution classes found");

            _solutions = solutionTypes
                .Select(t => (dynamic?)Activator.CreateInstance(t))
                .ToList();
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void TestFindDuplicateNumber((int[] nums, int expected) testCase)
        {
            foreach (var solution in _solutions)
            {
                Assert.That(solution, Is.Not.Null, "Solution instance should not be null");
                // string solutionName = solution.GetType().Namespace?.Split('.').Last();                
                TestContext.Out.WriteLine($"Testing {solution}");
                TestContext.Out.WriteLine($"Input: [{string.Join(", ", testCase.nums)}], Expected: {testCase.expected}, Actual: {solution.FindDuplicate(testCase.nums)}");
                int result = solution!.FindDuplicate(testCase.nums);
                Assert.That(result, Is.EqualTo(testCase.expected),
                    $"Solution {solution.GetType().Name}: failed for input [{string.Join(", ", testCase.nums)}], Expected = {testCase.expected}, Actual = {result}");
            }
        }
    }
}
