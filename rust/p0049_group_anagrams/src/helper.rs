use serde::Deserialize;

#[derive(Deserialize, Debug)]
pub struct InputModel {
    pub strs: Vec<String>,
}

/// Normalizes a String Vector by sorting the inner and outer vectors
pub fn normalize(mut data: Vec<Vec<String>>) -> Vec<Vec<String>> {
    for group in &mut data {
        group.sort();
    }

    data.sort_by(|a, b| a.cmp(b));
    data
}
