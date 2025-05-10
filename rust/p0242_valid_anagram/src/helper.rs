use serde::Deserialize;

#[derive(Deserialize, Debug)]
pub struct InputModel {
    pub s: String,
    pub t: String,
}
