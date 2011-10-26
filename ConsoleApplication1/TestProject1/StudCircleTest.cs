using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for StudCircleTest and is intended
    ///to contain all StudCircleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StudCircleTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for StudCircle Constructor
        ///</summary>
        [TestMethod()]
        public void StudCircleConstructorTest()
        {
            float xStep = 0F; // TODO: Initialize to an appropriate value
            bool isSolid = false; // TODO: Initialize to an appropriate value
            char backChar = '\0'; // TODO: Initialize to an appropriate value
            StudCircle target = new StudCircle(xStep, isSolid, backChar);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
