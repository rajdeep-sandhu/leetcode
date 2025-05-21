// Time complexity: O(n * k)
// Space complexity: O(n * k)
// where n = number of words, k = length of the longest word

use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn group_anagrams(strs: Vec<String>) -> Vec<Vec<String>> {
        let mut anagram_map: HashMap<String, Vec<String>> = HashMap::new();

        // Build anagram map
        for word in strs {
            let mut freq_map: [i32; 26] = [0; 26];

            for letter in word.chars() {
                let letter_index = (letter as u8 - b'a') as usize;
                freq_map[letter_index] += 1;
            }

            let key = freq_map
                .iter()
                .map(|freq| freq.to_string())
                .collect::<Vec<_>>()
                .join(",");

            anagram_map.entry(key).or_insert_with(Vec::new).push(word);
        }

        anagram_map.into_values().collect()
    }
}
