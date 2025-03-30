# LeetCode Python Solutions

Project created using `uv` package manager.

## Tests

Run in the `tests` directory.

```shell
pytest test.py -v  # Verbose
pytest test.py -v -s  # Verbose with print output displayed
pytest test.py -v --capture=no  # Verbose with print output displayed

pytest test.py -v --capture=no --cov=..\solutions  # With coverage report
pytest test.py -v --capture=no --cov=..\solutions --cov-report=term-missing
pytest test.py -v --capture=no --cov=..\solutions --cov-report=html  # With HTML coverage report
```
