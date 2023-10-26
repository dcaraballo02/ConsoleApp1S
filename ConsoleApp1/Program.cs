using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class TestResult
{
    public string TestCaseName { get; set; }
    public string Status { get; set; }
    public double ExecutionTime { get; set; }
    public DateTime TimeStamp { get; set; }
}

public class Program
{
    public static void Main()
    {
        string jsonFileName = "../../../testResults.json";
        string csvFilePath = "../../../export.csv";
        string projectDirectory = System.IO.Directory.GetCurrentDirectory();
        string jsonFile = System.IO.Path.Combine(projectDirectory, jsonFileName);

        // Read JSON File
        var jsonData = File.ReadAllText(jsonFile);

        var testResults = JsonConvert.DeserializeObject<List<TestResult>>(jsonData);

        using (var writer = new StreamWriter(csvFilePath))
        {
            writer.WriteLine("TestCaseName,Status,ExecutionTime,TimeStamp");
            foreach (var result in testResults)
            {
                writer.WriteLine($"{result.TestCaseName},{result.Status},{result.ExecutionTime},{result.TimeStamp}");
            }
        }

        // Calculate and display metrics
        Console.WriteLine($"Total number of test cases executed: {testResults.Count}");
        Console.WriteLine($"Number of test cases passed: {testResults.Count(r => r.Status == "Pass")}");
        Console.WriteLine($"Number of test cases failed: {testResults.Count(r => r.Status == "Fail")}");
        Console.WriteLine($"Average execution time for all test cases: {testResults.Average(r => r.ExecutionTime)}");
        Console.WriteLine($"Minimum execution time among all test cases: {testResults.Min(r => r.ExecutionTime)}");
        Console.WriteLine($"Maximum execution time among all test cases: {testResults.Max(r => r.ExecutionTime)}");
    }
}
