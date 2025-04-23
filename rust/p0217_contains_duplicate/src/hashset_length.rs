use std::collections::HashSet;

pub struct Solution;

impl Solution {
    pub fn contains_duplicate(nums: Vec<i32>) -> bool {
        nums.iter().cloned().collect::<HashSet<i32>>().len() < nums.len()
    }
}
