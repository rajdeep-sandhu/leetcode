// Time complexity: O(n^2)
// Space complexity: O(1)

use itertools::Itertools;

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        for pair in (0..nums.len()).combinations(2) {
            let [i, j]: [usize; 2] = pair.try_into().unwrap();
            if nums[i] + nums[j] == target {
                return vec![i as i32, j as i32];
            }
        }
        unreachable!("This should be unreachable with valid input.")
    }
}
