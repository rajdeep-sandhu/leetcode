use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn contains_duplicate(nums: Vec<i32>) -> bool {
        let mut freq = HashMap::new();

        for num in nums {
            // get the current count or insert 0, then increment
            *freq.entry(num).or_insert(0) += 1;
        }

        freq.values().any(|&x| x > 1)
    }
}
