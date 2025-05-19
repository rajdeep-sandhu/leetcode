use serde::Deserialize;

#[derive(Deserialize, Debug)]
pub struct InputModel {
    pub strs: Vec<String>,
}
