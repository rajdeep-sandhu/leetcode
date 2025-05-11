// Time complexity: O(n)
// Space complexity: O(n)

use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn is_anagram(s: String, t: String) -> bool {
        if s.len() != t.len() {
            return false;
        }

        let s_chars: Vec<char> = s.chars().collect();
        let t_chars: Vec<char> = t.chars().collect();

        let mut s_freq_map: HashMap<char, i32> = HashMap::new();
        let mut t_freq_map: HashMap<char, i32> = HashMap::new();

        for i in 0..s_chars.len() {
            *s_freq_map.entry(s_chars[i]).or_insert(0) += 1;
            *t_freq_map.entry(t_chars[i]).or_insert(0) += 1;
        }

        s_freq_map == t_freq_map
    }
}
