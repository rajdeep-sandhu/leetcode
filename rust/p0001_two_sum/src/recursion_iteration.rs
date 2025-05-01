// Time complexity: O(n^2)
// Space complexity: O(n)

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        fn find_indices(nums: &[i32], target: i32, i: usize) -> Vec<i32> {
            // Base case
            if i >= nums.len() {
                return vec![-1];
            }

            // Recursive case
            for j in i + 1..nums.len() {
                if nums[i] + nums[j] == target {
                    return vec![i as i32, j as i32];
                }
            }

            find_indices(&nums, target, i + 1)
        }

        find_indices(&nums, target, 0)
    }
}
