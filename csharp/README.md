# LeetCode Problems: C-Sharp

## Project Setup

```shell
dotnet new sln -n LeetCode
dotnet add package NUnit

dotnet new nunit -n LeetCode
dotnet sln LeetCode.sln add LeetCode/LeetCode.csproj
dotnet restore
```

- Create the problem, solution and test folders and files
- Run in the LeetCode folder

```shell
dotnet build
```

## Running Tests

### Run all tests

```shell
dotnet test
dotnet test -v d
dotnet test --logger "console;verbosity=detailed"
```

### Run specific problem tests

```shell
# By namespace (recommended)
dotnet test --filter "FullyQualifiedName~P0287_FindDuplicateNumber"

# List available tests
dotnet test -v n --list-tests
```

Note: The namespace filter (`~`) is more flexible as it matches partial names, while the class name filter requires the exact fully qualified name.
