using DrawASCIShapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace DrawASCITestProject
{
    
    
    /// <summary>
    ///This is a test class for _DefaultTest and is intended
    ///to contain all _DefaultTest Unit Tests
    ///</summary>
    [TestClass()]
    public class _DefaultTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        ///A test for GenerateShape
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Swapna\\SwapnaC", "/")]
        [UrlToTest("http://localhost:2469/")]
        [DeploymentItem("DrawASCIShapes.dll")]
        public void GenerateShapeTest()
        {
            _Default_Accessor target = new _Default_Accessor(); // TODO: Initialize to an appropriate value
            string ShapeToDraw = string.Empty; // TODO: Initialize to an appropriate value
            target.GenerateShape(ShapeToDraw);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateHistory
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Swapna\\SwapnaC", "/")]
        [UrlToTest("http://localhost:2469/")]
        [DeploymentItem("DrawASCIShapes.dll")]
        public void UpdateHistoryTest()
        {
            _Default_Accessor target = new _Default_Accessor(); // TODO: Initialize to an appropriate value
            target.UpdateHistory();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveHistoryToFile
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Swapna\\SwapnaC", "/")]
        [UrlToTest("http://localhost:2469/")]
        [DeploymentItem("DrawASCIShapes.dll")]
        public void SaveHistoryToFileTest()
        {
            _Default_Accessor target = new _Default_Accessor(); // TODO: Initialize to an appropriate value
            target.SaveHistoryToFile();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
