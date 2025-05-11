// Time complexity: 
// Space complexity: 

use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn is_anagram(s: String, t: String) -> bool {
        if s.len() != t.len() {
            return false;
        }

        fn build_hashmap(word: &str) -> HashMap<char, i32> {
            let mut freq_map: HashMap<char, i32> = HashMap::new();

            for letter in word.chars() {
                *freq_map.entry(letter).or_insert(0) += 1;
            }

            freq_map
        }

        let s_freq_map = build_hashmap(&s);
        let t_freq_map = build_hashmap(&t);

        for (letter, freq) in s_freq_map {
            // .get() returns None if key does not exist, Some(&value) if it does
            if t_freq_map.get(&letter) != Some(&freq) {
                return false;
            }
        }

        true
    }
}
