from typing import Dict, List


def decode_input(raw_input: Dict) -> Dict:
    """Decode json input. Amend per problem."""
    return {
        "strs": raw_input["strs"],
    }

def normalize_list(data: List[List[str]]) -> List[List[str]]:
    """Sort groups and elements within groups for comparison."""
    return sorted([sorted(group) for group in data])
