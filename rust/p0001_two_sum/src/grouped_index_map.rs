// Time complexity: O(n)
// Space complexity: O(n)

use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        // Build grouped index map.
        let mut seen: HashMap<i32, Vec<usize>> = HashMap::new();

        for (i, num) in nums.iter().enumerate() {
            seen.entry(*num).or_insert_with(Vec::new).push(i);
        }

        // Locate complement in grouped index map
        for (i, num) in nums.iter().enumerate() {
            let complement = target - num;

            if let Some(indices) = seen.get(&complement) {
                for &j in indices {
                    if j != i {
                        return vec![i as i32, j as i32];
                    }
                }
            }
        }

        unreachable!("This should be unreachable");
    }
}
