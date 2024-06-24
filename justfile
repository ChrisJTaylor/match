alias b := build-and-test
alias t := test
alias c := coverage
alias pre-test := clear-previous-results

test_results := "./test-results"
coverage_results := "./coverage-results"
artifacts := "./artifacts"
configuration := "Release"
project_test_result_name := "coverage.cobertura.xml"
test_filter := "FullyQualifiedName!~IntegrationTests&FullyQualifiedName!~StagingTests&FullyQualifiedName!~ContractTests"
solution_file := "*.sln"

clean: 
  dotnet clean
  dotnet nuget locals all --clear

restore:
  dotnet restore
  dotnet tool restore

build:
  dotnet build --no-restore -c "{{configuration}}"

clear-previous-results:
  find . -type f -name "{{project_test_result_name}}" -exec sh -c 'rm -r "$(dirname "{}")"' \;  

test: clear-previous-results
  -dotnet test --filter "{{test_filter}}" --configuration "{{configuration}}" --collect "XPlat Code Coverage" --results-directory "{{test_results}}" 

test-no-build: clear-previous-results
  -dotnet test --no-build --filter "{{test_filter}}" --configuration "{{configuration}}" --collect "XPlat Code Coverage" --results-directory "{{test_results}}" 

coverage: 
  #!/usr/bin/env bash
  dotnet reportgenerator -reports:**/{{test_results}}/*/coverage.cobertura.xml -reporttypes:lcov -targetdir:{{test_results}} 

package:
  dotnet pack --no-build --configuration "{{configuration}}" -o "{{artifacts}}"

watch:
  dotnet watch test --filter "{{test_filter}}" --configuration "{{configuration}}" --collect "XPlat Code Coverage" --results-directory "{{test_results}}" --project {{solution_file}} --verbose

sloc:
  @echo "`wc -l **/*.cs` lines of code"

build-and-test: clean restore build test 
  just coverage
  @echo "Done."
