pub struct Solution;

impl Solution {
    pub fn find_duplicate(nums: Vec<i32>) -> i32 {
        let n = nums.len() - 1;
        let max_bits: u32 = u32::BITS - (n as u32).leading_zeros();
        let mut duplicate: u32 = 0;

        for i in 0..max_bits {
            let bit_mask: u32 = 1 << i;
            let mut count_nums: i32 = 0;
            let mut count_range: i32 = 0;

            for &num in &nums {
                if (num as u32 & bit_mask) != 0 {
                    count_nums += 1;
                }
            }
            
            for num in 1..=n {
                if (num as u32 & bit_mask) != 0 {
                    count_range += 1;
                }
            }

            if count_nums > count_range {
                duplicate |= bit_mask;
            }
        }

        duplicate as i32
    }
}