// Time complexity: O(n)
// Space complexity: O(n)

use itertools::Itertools;
use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn is_anagram(s: String, t: String) -> bool {
        if s.len() != t.len() {
            return false;
        }

        let s_freq_map: HashMap<char, usize> = s.chars().counts();
        let t_freq_map: HashMap<char, usize> = t.chars().counts();

        s_freq_map == t_freq_map
    }
}
