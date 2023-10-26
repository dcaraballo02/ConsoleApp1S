using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ProgramTest
{
    // TestInitialize attribute to execute code before each test
    [TestInitialize]
    public void Init()
    {
        //Some test data in Json format
        var testResults = new List<TestResult>()
        {
            new TestResult() { TestCaseName = "Test1", Status = "Pass", ExecutionTime = 0.5, TimeStamp = DateTime.Now },
            new TestResult() { TestCaseName = "Test2", Status = "Fail", ExecutionTime = 1.2, TimeStamp = DateTime.Now },
            new TestResult() { TestCaseName = "Test3", Status = "Pass", ExecutionTime = 0.8, TimeStamp = DateTime.Now }
        };

        // Serialize the test data to JSON and save it to a file
        var jsonData = JsonConvert.SerializeObject(testResults);
        File.WriteAllText("../../../testResults.json", jsonData);
    }

    // TestCleanup attribute to execute code after each test
    [TestCleanup]
    public void CleanUp()
    {
        string assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string directory = System.IO.Path.GetDirectoryName(assemblyLocation);

        string jsonFilePath = Path.Combine(directory, "testResults.json");
        string csvFilePath = Path.Combine(directory, "export.csv");

        File.Delete(jsonFilePath);
        File.Delete(csvFilePath);

    }

    [TestMethod]
    public void TestMain()
    {
        Program.Main();

        string assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string directory = System.IO.Path.GetDirectoryName(assemblyLocation);

        string csvFilePath = Path.Combine(directory, "export.csv");
        var csvData = File.ReadAllLines(csvFilePath);


        // Verify the format
        Assert.AreEqual("TestCaseName,Status,ExecutionTime,TimeStamp", csvData[0]);
        Assert.IsTrue(csvData[1].StartsWith("Test1,Pass,"));
        Assert.IsTrue(csvData[2].StartsWith("Test2,Fail,"));
        Assert.IsTrue(csvData[3].StartsWith("Test3,Pass,"));

        // Read the output console data
        var output = Console.Out.ToString();

        Assert.IsTrue(output.Contains("Total number of test cases executed: 3"));
        Assert.IsTrue(output.Contains("Number of test cases passed: 2"));
        Assert.IsTrue(output.Contains("Number of test cases failed: 1"));
        Assert.IsTrue(output.Contains("Average execution time for all test cases: 0.833333333333333"));
        Assert.IsTrue(output.Contains("Minimum execution time among all test cases: 0.5"));
        Assert.IsTrue(output.Contains("Maximum execution time among all test cases: 1.2"));
    }
}
