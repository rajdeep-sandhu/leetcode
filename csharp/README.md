# LeetCode Problems: C-Sharp

dotnet new sln -n LeetCode
dotnet add package NUnit

dotnet new nunit -n LeetCode
dotnet sln LeetCode.sln add LeetCode/LeetCode.csproj

dotnet restore

// create the problem, solution and test folders and files
dotnet build
dotnet test
dotnet test --logger "console;verbosity=detailed"
