// Time complexity: O(n^2)
// Space complexity: O(n)

pub struct Solution;

impl Solution {
    pub fn is_anagram(s: String, t: String) -> bool {
        if s.len() != t.len() {
            return false;
        }

        for letter in s.chars() {
            if s.matches(letter).count() != t.matches(letter).count() {
                return false;
            }
        }

        true
    }
}
