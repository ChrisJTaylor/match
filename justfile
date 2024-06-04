alias b := build-and-test
test_results := "./test-results"
coverage_results := "./coverage-results"

restore:
  dotnet restore

build:
  dotnet build --no-restore -c Release

test:
  dotnet test -c Release --no-build --logger trx --results-directory "{{test_results}}" /p:CollectCoverage=true /p:CoverletOutput="{{coverage_results}}" /p:CoverletOutputFormat=opencover

build-and-test: restore build test
  @echo "Done."
