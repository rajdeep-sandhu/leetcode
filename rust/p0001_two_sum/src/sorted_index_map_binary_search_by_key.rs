// Time complexity: O(n log n)
// Space complexity: O(n)

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        // Sort the numbers as (number, index) tuples to preserve original indices
        let mut sorted_map: Vec<(i32, usize)> =
            nums.iter().enumerate().map(|(i, &num)| (num, i)).collect();

        sorted_map.sort_by_key(|&(num, _)| num);

        // Locate the complement
        for (i, &(num, index)) in sorted_map.iter().enumerate() {
            let complement = target - num;

            // Search only in the remaining vector slice
            let sorted_map_slice = &sorted_map[i + 1..];

            if let Ok(j) = sorted_map_slice.binary_search_by_key(&complement, |&(x, _)| x) {
                // j is relative to sorted_map_slice, which starts from i + 1.
                // Add i + 1 for the absolute position in sorted_map.
                return vec![index as i32, sorted_map[i + 1 + j].1 as i32];
            }
        }

        unreachable!("This should be unreachable.");
    }
}
