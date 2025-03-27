import pytest
import importlib
from pathlib import Path

TESTS_DIR = Path(__file__).parent
SOLUTIONS_DIR = TESTS_DIR.parent / "solutions"


SOLUTION_MODULES = [
    f"{TESTS_DIR.parent.name}.solutions.{file.stem}"
    for file in SOLUTIONS_DIR.glob("*.py")
    if not file.stem.startswith("__")
]


TEST_CASES = [
    # LeetCode cases
    ([1, 3, 4, 2, 2], 2),
    ([3, 1, 3, 4, 2], 3),
    ([3, 3, 3, 3, 3], 3),
    # Minimal case
    ([1, 1], 1)
]


@pytest.mark.parametrize("module_name", SOLUTION_MODULES)
@pytest.mark.parametrize("nums, expected", TEST_CASES)
def test_find_duplicate(module_name, nums, expected):
    module = importlib.import_module(module_name)
    solution = module.Solution()
    assert solution.findDuplicate(nums) == expected


if __name__ == '__main__':
    pytest.main(["-v"])  # verbose
