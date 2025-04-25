from typing import Dict

def decode_input(raw_input: Dict) -> Dict:
    """Decode json input. Amend per problem."""
    return {
        "nums": raw_input["nums"],
        "target": raw_input["target"],
    }