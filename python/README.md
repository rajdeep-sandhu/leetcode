# LeetCode Python Solutions

## Project Structure

- The project is created using the `uv` package manager.
- Each problem has a separate folder. For each problem:
  - The `solutions` folder contains the different solutions.
  - The `test` folder contains a unit test for the solutions.

## Tests

Run in the `tests` directory.

```shell
pytest test.py -v  # Verbose
pytest test.py -v -s  # Verbose with print output displayed
pytest test.py -v --capture=no  # Verbose with print output displayed

# Using uv, the test can be run without manually activating the environment
uv run pytest test.py -v --capture=no

pytest test.py -v --capture=no --cov=..\solutions  # With coverage report
pytest test.py -v --capture=no --cov=..\solutions --cov-report=term-missing
pytest test.py -v --capture=no --cov=..\solutions --cov-report=html  # With HTML coverage report
```
