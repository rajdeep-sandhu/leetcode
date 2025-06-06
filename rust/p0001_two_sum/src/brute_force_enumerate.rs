// Time complexity: O(n^2)
// Space complexity: O(n)

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        for (i, &num) in nums.iter().enumerate() {
            let complement: i32 = target - num;

            for j in i + 1..nums.len() {
                if nums[j] == complement {
                    return vec![i as i32, j as i32];
                }
            }
        }

        unreachable!("This should not happen with valid input");
    }
}
