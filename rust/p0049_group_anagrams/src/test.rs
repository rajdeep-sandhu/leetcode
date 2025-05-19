#[path = "helper.rs"]
mod helper;

use helper::InputModel;
use rstest::rstest;
use serde::Deserialize;
use std::fs;
use std::path::Path;

// Define a TestCase struct to match the JSON schema.
// Amend per problem.
#[derive(Deserialize)]
struct TestCase {
    case_name: String,
    input: InputModel,
    expected: Vec<Vec<String>>,
}

// Load test cases from the JSON file.
fn get_test_cases() -> Vec<TestCase> {
    // Adjust the path as needed.
    let path = Path::new("src/test_cases.json");
    let data = fs::read_to_string(path).expect("Unable to read test cases file.");
    serde_json::from_str(&data).expect("JSON was not well formatted.")
}

// Amend to suit the function to be tested.
fn get_solutions() -> Vec<(fn(Vec<String>) -> Vec<Vec<String>>, &'static str)> {
    include!(concat!(env!("OUT_DIR"), "/solutions_registry.rs"))
}

// Amend to suit the function to be tested.
#[rstest]
fn test_group_anagrams() {
    let test_cases = get_test_cases();
    let solutions = get_solutions();

    // Fail early if no solutions found.
    assert!(!solutions.is_empty(), "No solutions registered.");

    for (solution, solution_name) in solutions {
        println!("\nTesting solution: {}", solution_name);

        for test_case in &test_cases {
            // Get input data from test_case.
            // Amend per problem.
            let strs = test_case.input.strs.clone();

            // Call the solution function. Amend per problem.
            let result = solution(strs);

            println!(
                "  [Case: {:?}] Input: {:?}, Expected: {:?}, Actual: {:?}",
                test_case.case_name, test_case.input, test_case.expected, result
            );
            assert_eq!(
                result, test_case.expected,
                "Solution '{}' failed",
                solution_name
            );
        }
    }
}
