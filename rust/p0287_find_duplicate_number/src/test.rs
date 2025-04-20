use rstest::rstest;
use serde::Deserialize;
use std::fs;
use std::path::Path;

// Define a TestCase struct to match the JSON schema.
#[derive(Deserialize)]
struct TestCase {
    case_name: String,
    input: Vec<i32>,
    expected: i32,
}

// Load test cases from the JSON file.
fn load_test_cases() -> Vec<TestCase> {
    // Adjust the path as needed.
    let path = Path::new("src/test_cases.json");
    let data = fs::read_to_string(path).expect("Unable to read test cases file.");
    serde_json::from_str(&data).expect("JSON was not well formatted.")
}

fn get_solutions() -> Vec<(fn(Vec<i32>) -> i32, &'static str)> {
    include!(concat!(env!("OUT_DIR"), "/solutions_registry.rs"))
}

#[rstest]
fn test_find_duplicate() {
    let test_cases = load_test_cases();
    let solutions = get_solutions();

    for (solution, solution_name) in solutions {
        println!("\nTesting solution: {}", solution_name);

        for test_case in &test_cases {
            let result = solution(test_case.input.clone());
            println!(
                "  [Case: {:?}] Input: {:?}, Expected: {}, Actual: {}",
                test_case.case_name, test_case.input, test_case.expected, result
            );
            assert_eq!(result, test_case.expected, "Solution '{}' failed", solution_name);
        }
    }
}
