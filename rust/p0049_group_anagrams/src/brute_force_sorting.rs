// Time complexity: O(n * k log k)
// Space complexity: O(n)
// where n = number of words, k = length of the longest word

use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn group_anagrams(strs: Vec<String>) -> Vec<Vec<String>> {

        let mut anagram_map: HashMap<String, Vec<String>> = HashMap::new();

        // Build anagram map
        for word in strs {
            let mut word_chars: Vec<char> = word.chars().collect();
            word_chars.sort_unstable();
            let word_sorted: String = word_chars.into_iter().collect();

            anagram_map.entry(word_sorted).or_insert_with(Vec::new).push(word);
        }
        
        anagram_map.into_values().collect()
    }
}