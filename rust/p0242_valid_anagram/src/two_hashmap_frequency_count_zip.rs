// Time complexity: O(n)
// Space complexity: O(n)

use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn is_anagram(s: String, t: String) -> bool {
        if s.len() != t.len() {
            return false;
        }

        let mut s_freq_map: HashMap<char, i32> = HashMap::new();
        let mut t_freq_map: HashMap<char, i32> = HashMap::new();

        for (s_char, t_char) in s.chars().zip(t.chars()) {
            *s_freq_map.entry(s_char).or_insert(0) += 1;
            *t_freq_map.entry(t_char).or_insert(0) += 1;
        }

        s_freq_map == t_freq_map
    }
}
