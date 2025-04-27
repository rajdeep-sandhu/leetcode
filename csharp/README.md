# LeetCode Problems: C-Sharp

## Project Setup

```shell
dotnet new sln -n LeetCode
```

- `Directory.Packages.Props` allows centralised dependency management, to prevent the testing framework libraries to be set up for each problem.

### Set up a new problem

```shell
# From within the root folder csharp
dotnet new classlib -n P0217_ContainsDuplicate

# Add the project to the .sln file
dotnet sln ..\LeetCode.sln add P0217_ContainsDuplicate.csproj
```

- Update the `.csproj` file to include centralised dependencies.

- Create the `Solutions` and `Test` folders.

### Set up tests for a problem

### Run tests for a problem

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
