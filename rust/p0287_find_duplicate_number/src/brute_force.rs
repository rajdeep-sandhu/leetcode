pub struct Solution;

impl Solution {
    pub fn find_duplicate(nums: Vec<i32>) -> i32 {
        for i in 0..nums.len() {
            for j in i + 1..nums.len() {
                if nums[i] == nums[j] {
                    return nums[i];
                }
            }
        }
        unreachable!("Problem guarantees 1 duplicate and nums.length > 1")
    }
}