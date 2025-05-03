use std::{env, fs, io::Write, path::Path};

fn main() {
    // Look for solution files in the "src" folder.
    let solutions_dir = Path::new("src");
    let out_dir = env::var("OUT_DIR").unwrap();
    let dest_path = Path::new(&out_dir).join("solutions_registry.rs");

    let mut file = fs::File::create(dest_path).unwrap();

    // Write a header comment.
    writeln!(
        file,
        "// Note: IDE may suggest adding semicolons, but don't add them."
    )
    .unwrap();
    writeln!(
        file,
        "// This file is included as an expression via include! macro."
    )
    .unwrap();
    writeln!(file, "vec![\n").unwrap();

    // Iterate over all .rs files in src/
    let mut first = true;
    for entry in fs::read_dir(solutions_dir).unwrap() {
        let entry = entry.unwrap();
        let path = entry.path();

        // Process only .rs files.
        if path.extension().map_or(false, |ext| ext == "rs") {
            if let Ok(content) = fs::read_to_string(&path) {
                if content.contains("struct Solution") {
                    if let Some(file_stem) = path.file_stem().and_then(|s| s.to_str()) {
                        if !first {
                            write!(file, ",\n").unwrap();
                        }
                        write!(
                            file,
                            "    (crate::{0}::Solution::two_sum, \"{0}\")", // Amend for each problem
                            file_stem
                        )
                        .unwrap();
                        first = false;
                    }
                }
            }
        }
    }

    // Close the vector expression
    writeln!(file, "\n]").unwrap();
    println!("cargo:rerun-if-changed=src");
}
