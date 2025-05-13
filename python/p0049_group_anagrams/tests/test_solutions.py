import importlib
import json
import pytest

from pathlib import Path
from .helper import decode_input, normalize_list

# Paths
TESTS_DIR = Path(__file__).parent
SOLUTIONS_DIR = TESTS_DIR.parent / "solutions"
TEST_CASES_FILE = TESTS_DIR / "test_cases.json"

# Get solution modules
SOLUTION_MODULES = [
    f"{TESTS_DIR.parent.name}.solutions.{file.stem}"
    for file in SOLUTIONS_DIR.glob("*.py")
    if not file.stem.startswith("__")
]


# Load test cases
def load_test_cases():
    """Load test cases from json"""
    with open(TEST_CASES_FILE, "r") as file:
        return json.load(file)


TEST_CASES = load_test_cases()


@pytest.mark.parametrize("module_name", SOLUTION_MODULES)
@pytest.mark.parametrize("test_case", TEST_CASES)
# Amend test name per problem
def test_groupAnagrams(module_name, test_case):
    module = importlib.import_module(module_name)
    solution = module.Solution()

    # Get test cases.
    case_name = test_case.get("case_name", "Unnamed Case")
    raw_input = test_case["input"]
    expected = test_case["expected"]

    # Decode test cases. Amend per problem.
    inputs = decode_input(raw_input)
    strs = inputs["strs"]

    # Run function to be tested. Amend per problem.
    result = solution.groupAnagrams(strs)

    # The problem allows results to be returned in any order.
    # Sort to enable comparison
    expected_sorted = normalize_list(expected)
    result_sorted = normalize_list(result)

    # Logging. Amend per problem
    log_output = f"Input: strs={strs}. Output: Expected={expected}, Actual={result}"
    print(f"\n\n[Module: {module_name}, Case: {case_name}]")
    print(log_output)

    # Assertion: Amend per problem
    assert result_sorted == expected_sorted, f"{module_name} [{case_name}] failed.\n{log_output}"


if __name__ == "__main__":
    pytest.main(["-v"])  # verbose
