using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    [TestClass]
    public class CommonDBTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            // ARRANGE
            string connectionString = @"";

            // ACT
            CommonDB dB = new CommonDB(connectionString);

            // ASSERT
            Assert.IsNotNull(dB, "db is null");
        }
    }
}
