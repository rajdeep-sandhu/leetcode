pub struct Solution;

impl Solution {
    pub fn find_duplicate(nums: Vec<i32>) -> i32 {
        let (mut left, mut right) = (1, nums.len() as i32 - 1);
        while left < right {
            let mid = left + (right - left) / 2;
            let count = nums.iter().filter(|&&x| x <= mid).count();

            if count > mid as usize {
                right = mid
            } else {
                left = mid + 1
            }
        }
        left
    }
}