# Test Results Analysis Project

This project contains a C# script that processes test results stored in a JSON file, converts them to CSV format, exports them, and generates various metrics based on the test results.

## Requirements

- .NET Core 3.1 or higher
- Newtonsoft.Json
- MSTest.TestFrameWork

## Usage

1. Ensure you have .NET Core 3.1 or higher installed.
2. Install the `Newtonsoft.Json`  and `MSTest.TestFrameWork` package via NuGet Package Manager in Visual Studio.
3. Open the project in Visual Studio.
4. Run the script by pressing F5 or clicking the "Start" button on the Visual Studio toolbar.

The script assumes that the `testResults.json` file is in the same folder as the script and will export the CSV file to the same folder with the name `export.csv`.

## JSON Format

The script assumes that the JSON file is a list of objects, where each object has the properties `TestCaseName`, `Status`, `ExecutionTime`, and `TimeStamp`. For example:

    ```json
    [
        {
            "TestCaseName": "Test1",
            "Status": "Pass",
            "ExecutionTime": 1.23,
            "TimeStamp": "2023-10-24T22:21:28Z"
        },
        {
            "TestCaseName": "Test2",
            "Status": "Fail",
            "ExecutionTime": 2.34,
            "TimeStamp": "2023-10-24T22:21:29Z"
        }
    ]

## Metrics

The script calculates and displays the following metrics based on the test results:

1. Total number of test cases executed.
2. Number of test cases passed.
3. Number of test cases failed.
4. Average execution time for all test cases.
5. Minimum execution time among all test cases.
6. Maximum execution time among all test cases.

## Unit Testing

This project uses the MSTest framework to write and run unit tests for the script. MSTest is a unit testing framework integrated in Visual Studio that allows you to create, organize and run tests quickly and easily.

To run the unit tests, you can follow these steps:

1. Open the project in Visual Studio.
2. In the top menu, select Test > Windows > Test Explorer. A window will open that shows all the unit tests that you have defined in your project.
3. In the Test Explorer, you can select the tests that you want to run, or run all the available tests. You can right-click on a test or a group of tests and select Run Selected Tests, or click on the Run All button on the toolbar.
4. Once the tests are run, you can see the results in the Test Explorer. The tests that have passed are shown in green, and the ones that have failed are shown in red. You can click on a test to see more details, such as the error message, the stack trace and the standard output.
5. If you want to debug a test that has failed, you can right-click on it and select Debug Selected Test. This will start the Visual Studio debugger and allow you to inspect the code and the values of the variables during the test execution.

This README file provides an overview of the project, explains how to use it, 
describes the assumed JSON format, and lists the metrics that the script calculates. 
I hope this helps!