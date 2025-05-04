from typing import Dict


def decode_input(raw_input: Dict) -> Dict:
    """Decode json input. Amend per problem."""
    return {
        "s": raw_input["s"],
        "t": raw_input["t"],
    }
