use serde::Deserialize;

#[derive(Deserialize, Debug)]
pub struct InputModel {
    pub nums: Vec<i32>,
    pub target: i32,
}

