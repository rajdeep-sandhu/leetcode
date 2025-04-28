use serde::Deserialize;

#[derive(Deserialize, Debug)]
pub struct InputModel {
    pub nums: Vec<i32>,
    pub target: i32,
}

#[allow(dead_code)]
pub fn decode_input(raw_input: &str) -> InputModel {
    let parsed: InputModel = serde_json::from_str(raw_input).unwrap();

    parsed
}
