namespace RetryPatternCSharp.Tests;

[TestClass]
public class SimpleRetryPatternTests
{
    [TestMethod]
    public void ExecuteTest()
    {
        // Arrange
        SimpleRetryPattern rp = new SimpleRetryPattern();

        // Act
        for (int i = 0; i < 10; i++)
            rp.Execute();

        // Assert
        Assert.IsTrue(rp.LogMessages.Count > 0);
    }
}