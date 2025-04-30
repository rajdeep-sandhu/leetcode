// Time complexity: O(n^2)
// Space complexity: O(n)

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        fn find_indices(nums: &[i32], target: i32, i: usize, j: usize) -> Vec<i32> {
            // Base case
            if i >= nums.len() {
                return vec![-1];
            }

            // Recursive case
            if j >= nums.len() {
                // Get next i, set j to the following index.
                return find_indices(&nums, target, i + 1, i + 2);
            }

            if nums[i] + nums[j] == target {
                return vec![i as i32, j as i32];
            } else {
                // Get next j for the same i
                find_indices(&nums, target, i, j + 1)
            }
        }

        return find_indices(&nums, target, 0, 1);
    }
}
