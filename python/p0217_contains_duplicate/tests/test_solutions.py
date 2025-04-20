import importlib
import json
import pytest

from pathlib import Path

TESTS_DIR = Path(__file__).parent
SOLUTIONS_DIR = TESTS_DIR.parent / "solutions"
TEST_CASES_FILE = TESTS_DIR / "test_cases.json"


SOLUTION_MODULES = [
    f"{TESTS_DIR.parent.name}.solutions.{file.stem}"
    for file in SOLUTIONS_DIR.glob("*.py")
    if not file.stem.startswith("__")
]

def load_test_cases():
    """Load test cases from json"""
    with open(TEST_CASES_FILE, "r") as file:
        return json.load(file)

TEST_CASES = load_test_cases()


@pytest.mark.parametrize("module_name", SOLUTION_MODULES)
@pytest.mark.parametrize("test_case", TEST_CASES)
def test_contains_duplicate(module_name, test_case):
    module = importlib.import_module(module_name)
    solution = module.Solution()

    case_name = test_case.get("case_name", "Unnamed Case")
    nums = test_case["input"]
    expected = test_case["expected"]
    result = solution.containsDuplicate(nums)

    print(f"[Case: {case_name}]")
    print(f"Input: {nums}, Expected: {expected}, Actual: {result}")
    assert (
        result == expected
    ), f"{module_name} [{case_name}] failed. Input: {nums}, Expected: {expected}, Actual: {result}"


if __name__ == '__main__':
    pytest.main(["-v"])  # verbose
