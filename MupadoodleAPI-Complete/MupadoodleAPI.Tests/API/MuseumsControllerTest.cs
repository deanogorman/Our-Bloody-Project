using MupadoodleAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using MupadoodleAPI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MupadoodleAPI.Tests
{
    
    
    /// <summary>
    ///This is a test class for MuseumsControllerTest and is intended
    ///to contain all MuseumsControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MuseumsControllerTest
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
        ///A test for MuseumsController Constructor
        ///</summary>
        [TestMethod()]
        public void MuseumsControllerConstructorTest()
        {
            MuseumsController target = new MuseumsController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetAllMuseums
        ///</summary>
        [TestMethod()]
        public void GetAllMuseumsTest()
        {
            var controller = new MuseumsController();
            var result = controller.GetAllMuseums();

            // ** Assert view ain't null **//
            Assert.IsNotNull(result, "Should have returned a ViewResult");

            //** Assert Cities are passed as IEnumerable **//
            Assert.IsInstanceOfType(result, typeof(List<Museum>));
        }

        /// <summary>
        ///A test for GetMuseumById
        ///</summary>
       // [TestMethod()]
        public void GetMuseumByIdTest()
        {
            var controller = new MuseumsController();
            int id = 4;
            
            Museum actual;
           actual = controller.GetMuseumById(id);

            // ** Assert result ain't null **//
           Assert.IsNotNull(actual, "Should have returned a ViewResult");

            //** Assert a Museum is returned **//
            Assert.IsInstanceOfType(actual, typeof(Museum));

        }

        /// <summary>
        ///A test for GetMuseumsInCity
        ///</summary>
        [TestMethod()]
        public void GetMuseumsInCityTest()
        {
            var target = new MuseumsController();
            string city = "New York";
            
            IEnumerable<Museum> actual;
            actual = target.GetMuseumsInCity(city);

            //** Assert List of Museums is returned **//
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Museum>));
        }

        /// <summary>
        ///A test for GetMuseumsWithName
        ///</summary>
        [TestMethod()]
        public void GetMuseumsWithNameTest()
        {
            var target = new MuseumsController();
            string name = "History";

            IEnumerable<Museum> actual;
            actual = target.GetMuseumsWithName(name);

            //** Assert List of Museums is returned **//
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Museum>));
        }
    }
}
