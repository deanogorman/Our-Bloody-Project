using MupadoodleAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using MupadoodleAPI.Models;
using System.Collections.Generic;

namespace MupadoodleAPI.Tests
{
    
    
    /// <summary>
    ///This is a test class for HomeControllerTest and is intended
    ///to contain all HomeControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HomeControllerTest
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
        ///A test for ShowCitiesGraphically
        ///</summary>
        public void ShowCitiesGraphicallyTest()
        {
            var controller = new HomeController(); 
            var result = controller.ShowCitiesGraphically() as ViewResult;

            // ** Assert view ain't null **//
            Assert.IsNotNull(result, "Should have returned a ViewResult");

            //** Assert Cities are passed as IEnumerable **//
            var model = result.ViewData.Model as IEnumerable<City>;
            Assert.IsNotNull(model, "Model should have been type of IEnumerable<City>");
        }

        
        /// <summary>
        ///A test for QueryMuseumDB
        ///</summary>
        public void QueryMuseumDBTest()
        {
            var controller = new HomeController(); 
            var result = controller.QueryMuseumDB() as ViewResult;

            // ** Assert view ain't null **//
            Assert.IsNotNull(result, "Should have returned a ViewResult");

            //** Assert Museums are passed as IEnumerable **//
            var model = result.ViewData.Model as IEnumerable<Museum>;
            Assert.IsNotNull(model, "Model should have been type of IEnumerable<Museum>");
        }

 

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new HomeController(); 
            var result = controller.Index() as ViewResult;
            
            // ** Assert view ain't null **//
            Assert.IsNotNull(result, "Should have returned a ViewResult");

            //** Assert Cities are passed as IEnumerable **//
            var model = result.ViewData.Model as IEnumerable<City>;
            Assert.IsNotNull(model, "Model should have been type of IEnumerable<City>");

        }

        /// <summary>
        ///A test for Developer
        ///</summary>
        [TestMethod()]
        public void DeveloperTest()
        {
            var controller = new HomeController();
            var result = controller.Developer() as ViewResult;

            Assert.IsNotNull(result, "Should have returned a ViewResult");

            Assert.AreEqual("Developer", result.ViewName);
        }

        

        /// <summary>
        ///A test for BuildCities
        ///</summary>
        public void BuildCitiesTest()
        {
            var controller = new HomeController(); 
            var result = controller.BuildCities() as ViewResult;

            // ** Assert view ain't null **//
            Assert.IsNotNull(result, "Should have returned a ViewResult");

            //** Assert Cities are passed as IEnumerable **//
            var model = result.ViewData.Model as IEnumerable<City>;
            Assert.IsNotNull(model, "Model should have been type of IEnumerable<City>");
        }

        /// <summary>
        ///A test for Admin
        ///</summary>
        public void AdminTest()
        {
            var controller = new HomeController();
            var result = controller.Admin() as ViewResult;

            Assert.IsNotNull(result, "Should have returned a ViewResult");
            Assert.AreEqual("Admin", result.ViewName);
        }

        /// <summary>
        ///A test for About
        ///</summary>
        public void AboutTest()
        {
            var controller = new HomeController();
            var result = controller.About() as ViewResult;
            Assert.IsNotNull(result, "Should have returned a ViewResult");
            Assert.AreEqual("About", result.ViewName);
        }

        /// <summary>
        ///A test for HomeController Constructor
        ///</summary>
        public void HomeControllerConstructorTest()
        {
            HomeController target = new HomeController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
