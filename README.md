# Wiki Login Demo

Project shows simple system testing setup for Wikipedia login functionality. 

## Running the tests

1.  Clone repository
2.	Open `WikiLoginTests.sln` file using Visual Studio
3.  Set `ALLURE_CONFIG` environment variable ([see here](https://github.com/allure-framework/allure-csharp#configuration))
4.	Use _Test Explorer_ tool to run tests

## Generating the reports

1. Run the tests
2. Open command prompt
3. Navigate to solution folder
4. Type `allure serve WikiLoginDemo/bin/Debug/TestResults/` and hit enter 

### Prerequisites

* Visual Studio (ideally 2019)
* NuGet package manager
* Allure

### Installing

There is nothing to be installed except NuGet packages which will be restore automatically by the IDE.

## Deployment

There is no environment for the project, so there is no need for deployment :)

## Built with

* xUnit
* SpecFlow
* Allure

## Contributing

There are no contribution rules established.

## Versioning

No versioning is applied to the project.

## Authors

* **Bartlomiej Roszczypala** - [Gucu112](https://github.com/Gucu112)

See also the list of [contributors](https://github.com/gucu112/WikiLoginDemo/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
