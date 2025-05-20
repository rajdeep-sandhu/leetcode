# LeetCode Solutions

## Add a problem

- Initialise a new `cargo` library for the problem in the root folder.
  - This creates the problem folder with a `Cargo.toml` file.
  - A `src` subfolder is created with a `lib.rs` file.
  
  ```shell
  cargo init --lib p0217_contains_duplicate
  ```

- Add the problem folder to `members` in the `Cargo.toml` in the project root, which is `rust`.
- Add the required dependencies and dev dependencies to the problem's `Cargo.toml`.
- Add `build.rs` to the problem folder.

- In the `src` folder
  - Add `test_cases.json`.
  - Add `test.rs`.
    - Change `Struct TestCase` to match the cases in `test_cases.json`.
    - Change `fn get_solutions() -> Vec<(fn(Vec<i32>) -> bool, &'static str)>` to match the target function's input and output types.
  - Add `helper.rs`.
    - This contains an input model, which should match the test case input in `test_cases.json`.
  - Add the solution to the `src` folder.

### `lib.rs`

This is generated when the library is created. Delete the default code, which runs an example test.

- Change the default code to the following:

    ```rust
    #[cfg(test)]
    mod test;
    ```

- - Add each solution as a module to `lib.rs`.

### `build.rs`

This builds a `solutions.registry` file containing a list of solution files allowing dynamic discovery of solutions.

- Change the method reference to the solution function name under `if content.contains("struct Solution")` to the function to be tested.
  
    ```rust
    write!(
        file,
        "    (crate::{0}::Solution::two_sum, \"{1}\")",
        file_stem,
        file_stem.replace('_', " ")
    ).unwrap();
        ```

### `test_cases.json`

This contains the test cases for each problem.

- Each case has `input` and `expected` fields.
  
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

### `test.rs`

This contains the unit test code for each problem.

1. Amend `struct TestCase` to match the problem's input/output format. It may be more complex than this example, e.g. using the `InputModel` in `helper.rs`.
    - Example for `Two Sum`:

        ```rust
        #[derive(Deserialize)]
        struct TestCase {
            input: (Vec<i32>, i32),
            expected: Vec<i32>,
        }
        ```

2. Define the `Vec` returned by `get_solutions()` to match the solution function signature.
   - Change `fn(Vec<i32>) -> i32` to match the problem's function signature.
   - Example for `two_sum(nums: Vec<i32>, target: i32) -> Vec<i32>`:

        ```rust
        fn get_solutions() -> Vec<(fn(Vec<i32>, i32) -> Vec<i32>, &'static str)>

        ```

3. Calling the Solution in `test.rs`
   - Update the test loop to call the function with the correct parameters.

        ```rust
        let result = solution(test_case.input.0.clone(), test_case.input.1);
        ```

## Tests

- In Rust, unit tests reside in the `src` folder with the modules they are testing.
- The default **_fail fast_** approach is used, where a failed asserion causes the test to panic and the test suite stops.
- These should be run from the problem folder
- `cargo test`
- `cargo test --lib`  # Run tests only for the library, without main.rs
- `cargo test --lib -- --nocapture`  # Allows println! statements in the test to display
- `cargo test -p p0287_find_duplicate_number --lib -- --nocapture`  # From project root

## Coverage

```shell
cargo install cargo-llvm-cov

# Run coverage in the problem folder
cargo llvm-cov --lcov --output-path lcov.info

# Terminal summary
cargo llvm-cov

# Detailed html report
cargo llvm-cov --open
```
