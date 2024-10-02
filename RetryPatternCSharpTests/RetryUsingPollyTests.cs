using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetryPatternCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryPatternCSharp.Tests;

[TestClass]
public class RetryUsingPollyTests
{
    [TestMethod]
    public void ExecuteTest()
    {
        // Arrange
        RetryUsingPolly rp = new RetryUsingPolly(3, 1);

        // Act
        for (int i = 0; i < 10; i++)
            rp.Execute();

        // Assert
        Assert.IsTrue(rp.LogMessages.Count > 0);
    }
}