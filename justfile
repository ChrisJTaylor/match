alias b := build-and-test

restore:
  dotnet restore

build:
  dotnet build --no-restore

test:
  dotnet test --no-build --collect:"XPlat Code Coverage"

build-and-test:
  dotnet test
