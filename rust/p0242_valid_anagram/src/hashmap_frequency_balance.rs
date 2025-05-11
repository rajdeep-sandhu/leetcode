// Time complexity: O(n + k), practically O(n) if k is small
// Space complexity: O(k)
// where k = number of unique characters

use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn is_anagram(s: String, t: String) -> bool {
        if s.len() != t.len() {
            return false;
        }

        let mut freq_map: HashMap<char, i32> = HashMap::new();

        for (s_char, t_char) in s.chars().zip(t.chars()) {
            *freq_map.entry(s_char).or_insert(0) += 1;
            *freq_map.entry(t_char).or_insert(0) -= 1;
        }

        // For an anagram, the balance of frequencies is 0 for each character
        for &freq in freq_map.values() {
            if freq != 0 {
                return false;
            }
        }

        true
    }
}
