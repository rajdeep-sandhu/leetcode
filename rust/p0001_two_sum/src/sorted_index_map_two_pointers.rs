// Time complexity: O(n log n)
// Space complexity: O(n)

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        // Sort the numbers as (number, index) tuples to preserve original indices
        let mut sorted_map: Vec<(i32, usize)> =
            nums.iter().enumerate().map(|(i, &num)| (num, i)).collect();

        sorted_map.sort_by_key(|&(num, _)| num);

        let mut left: usize = 0;
        let mut right = nums.len() - 1;

        while left < right {
            let curr_sum = sorted_map[left].0 + sorted_map[right].0;

            if curr_sum == target {
                return vec![sorted_map[left].1 as i32, sorted_map[right].1 as i32];
            } else if curr_sum < target {
                left += 1;
            } else {
                right -= 1;
            }
        }

        unreachable!("This should be unreachable.")
    }
}
