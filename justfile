alias b := build-and-test
test_results := "./test-results"
coverage_results := "./coverage-results"
artifacts := "./artifacts"
configuration := "Release"

restore:
  dotnet restore

build:
  dotnet build --no-restore -c "{{configuration}}"

test:
  dotnet test -c "{{configuration}}" --no-build --logger trx --results-directory "{{test_results}}" /p:CollectCoverage=true /p:CoverletOutput="{{coverage_results}}" /p:CoverletOutputFormat=opencover

package:
  dotnet pack --no-build -c "{{configuration}}" -o "{{artifacts}}"

build-and-test: restore build test
  @echo "Done."
