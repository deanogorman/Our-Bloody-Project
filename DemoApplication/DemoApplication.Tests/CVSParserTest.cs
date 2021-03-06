﻿using DemoApplication.Ingestion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.IO;
using DemoApplication.Models;
using System.Collections.Generic;

namespace DemoApplication.Tests
{
    
    
    /// <summary>
    ///This is a test class for CVSParserTest and is intended
    ///to contain all CVSParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CVSParserTest
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
        ///A test for CVSParser Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Tony\\Documents\\NCIRL\\Semester 3\\H9TECENT - Enterprise Frameworks\\Lecture 6\\DemoApplication\\DemoApplication", "/")]
        [UrlToTest("http://localhost:56662/")]
        public void CVSParserConstructorTest()
        {
            CSVParser target = new CSVParser();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DemoApplication.Ingestion.IDataParser.setStreamSource
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Tony\\Documents\\NCIRL\\Semester 3\\H9TECENT - Enterprise Frameworks\\Lecture 6\\DemoApplication\\DemoApplication", "/")]
        [UrlToTest("http://localhost:56662/")]
        [DeploymentItem("DemoApplication.dll")]
        public void setStreamSourceTest()
        {
            IDataParser target = new CSVParser(); // TODO: Initialize to an appropriate value
            StreamReader reader = null; // TODO: Initialize to an appropriate value
            target.setStreamSource(reader);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for parseExhangeRates
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Tony\\Documents\\NCIRL\\Semester 3\\H9TECENT - Enterprise Frameworks\\Lecture 6\\DemoApplication\\DemoApplication", "/")]
        [UrlToTest("http://localhost:56662/")]
        public void parseExhangeRatesTest()
        {
            CSVParser target = new CSVParser(); // TODO: Initialize to an appropriate value
            List<ExchangeRate> expected = null; // TODO: Initialize to an appropriate value
            List<ExchangeRate> actual;
            actual = target.parseExchangeRates();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for supportsType
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Tony\\Documents\\NCIRL\\Semester 3\\H9TECENT - Enterprise Frameworks\\Lecture 6\\DemoApplication\\DemoApplication", "/")]
        [UrlToTest("http://localhost:56662/")]
        public void supportsTypeTest()
        {
            CSVParser target = new CSVParser(); // TODO: Initialize to an appropriate value
            string format = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.supportsType(format);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
