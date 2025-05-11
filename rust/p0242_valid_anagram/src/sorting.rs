// Time complexity: O(n log n)
// Space complexity: O(n)

pub struct Solution;

impl Solution {
    pub fn is_anagram(s: String, t: String) -> bool {
        if s.len() != t.len() {
            return false;
        }

        let mut s_chars: Vec<char> = s.chars().collect();
        let mut t_chars: Vec<char> = t.chars().collect();

        s_chars.sort_unstable();
        t_chars.sort_unstable();

        s_chars == t_chars
    }
}
