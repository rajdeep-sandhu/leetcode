// Time complexity: O(n log n)
// Space complexity: O(n)

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        // Sort the numbers as (number, index) tuples to preserve original indices
        let mut sorted_map: Vec<(i32, usize)> =
            nums.iter().enumerate().map(|(i, &num)| (num, i)).collect();

        sorted_map.sort_by_key(|&(num, _)| num);

        // Return index of search_val in sorted_map
        fn binary_search(
            sorted_map: &[(i32, usize)], mut left: usize, mut right: usize, search_val: i32,
        ) -> Option<usize> {
            while left <= right {
                let mid = left + (right - left) / 2;

                if sorted_map[mid].0 == search_val {
                    return Some(mid);
                } else if sorted_map[mid].0 < search_val {
                    left = mid + 1
                } else {
                    right = mid - 1
                }
            }
            None
        }

        // Locate the complement
        for (i, &(num, index)) in sorted_map.iter().enumerate() {
            let complement = target - num;

            // Search only in the remaining vector slice
            if let Some(j) = binary_search(&sorted_map, i + 1, sorted_map.len() - 1, complement) {
                return vec![index as i32, sorted_map[j].1 as i32];
            }
        }

        unreachable!("This should be unreachable.");
    }
}
