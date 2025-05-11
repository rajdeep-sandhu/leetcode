// Time complexity: O(n)
// Space complexity: O(1)

pub struct Solution;

impl Solution {
    pub fn is_anagram(s: String, t: String) -> bool {
        if s.len() != t.len() {
            return false;
        }

        let mut freq_table: [i32; 26] = [0; 26];

        // Index represents letter, value represents count
        for (s_char, t_char) in s.chars().zip(t.chars()) {
            let s_index = (s_char as u8 - b'a') as usize;
            let t_index = (t_char as u8 - b'a') as usize;

            freq_table[s_index] += 1;
            freq_table[t_index] -= 1;
        }

        // For an anagram, the balance of frequencies is 0 for each character
        freq_table.iter().all(|&freq| freq == 0)
    }
}
