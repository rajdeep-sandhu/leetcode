# LeetCode Solutions

## Tests

- In Rust, unit tests reside in the `src` folder with the modules they are testing.
- These should be run from the problem folder
- `cargo test`
- `cargo test --lib`  # Run tests only for the library, without main.rs
- `cargo test --lib -- --nocapture`  # Allows println! statements in the test to display
- `cargo test -p p0287_find_duplicate_number --lib -- --nocapture`  # From project root

### Test code modification for different problems

1. Function Signature in test.rs
   - Change `fn(Vec<i32>) -> i32` to match the problem's function signature.
   - Example for `two_sum(nums: Vec<i32>, target: i32) -> Vec<i32>`:

        ```rust
        fn get_solutions() -> Vec<(fn(Vec<i32>, i32) -> Vec<i32>, &'static str)>

        ```

2. Test Struct in `test.rs`
    - Update `TestCase` struct to match the problem's input/output format.
    - Example for `Two Sum`:

        ```rust
        #[derive(Deserialize)]
        struct TestCase {
            input: (Vec<i32>, i32),
            expected: Vec<i32>,
        }
        ```

3. Calling the Solution in `test.rs`
   - Update the test loop to call the function with the correct parameters.

        ```rust
        let result = solution(test_case.input.0.clone(), test_case.input.1);
        ```

4. Function References in `build.rs`
   - Update the method reference in `build.rs`:

        ```rust
        write!(
            file,
            "    (crate::{0}::Solution::two_sum, \"{1}\")",
            file_stem,
            file_stem.replace('_', " ")
        ).unwrap();
        ```

5. Update `test_cases.json`

    ```json
    [
        {
            "input": {
                "nums": [2, 7, 11, 15],
                "target": 9
            },
            "expected": [0, 1]
        },
        {
            "input": {
                "nums": [3, 2, 4],
                "target": 6
            },
            "expected": [1, 2]
        },
        {
            "input": {
                "nums": [3, 3],
                "target": 6
            },
            "expected": [0, 1]
        }
    ]
    ```
