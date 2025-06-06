// Time complexity: O(n)
// Space complexity: O(n)

use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        let mut seen: HashMap<i32, usize> = HashMap::new();

        for (i, num) in nums.iter().enumerate() {
            let complement = target - num;

            if let Some(&j) = seen.get(&complement) {
                return vec![j as i32, i as i32];
            }

            seen.insert(*num, i);
        }

        unreachable!("This should not be reachable with valid input");
    }
}
