use std::collections::HashSet;

pub struct Solution;

impl Solution {
    pub fn contains_duplicate(nums: Vec<i32>) -> bool {
        let mut seen: HashSet<i32> = HashSet::new();

        for num in nums {
            if seen.contains(&num) {
                return true;
            }
            seen.insert(num);
        }
        false
    }
}
