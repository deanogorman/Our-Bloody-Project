using MupadoodleAPI.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using MupadoodleAPI.Models;
using System.Collections.Generic;

namespace MupadoodleAPI.Tests
{
    
    
    /// <summary>
    ///This is a test class for MuseumDALTest and is intended
    ///to contain all MuseumDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MuseumDALTest
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
        ///A test for MuseumDAL Constructor
        ///</summary>
        [TestMethod()]
        public void MuseumDALConstructorTest()
        {
            MuseumDAL target = new MuseumDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for addMuseumToDb
        ///</summary>
        [TestMethod()]
        public void addMuseumToDbTest()
        {
            MuseumDAL target = new MuseumDAL();

            double lat = 40.7669569450;
            double lng = -73.937655144;
            string theName = "Test Museum",theUrl = "www.testmuseum.com", add1 = "Bronx", add2 = null, theZip = "008", phone = "007007";
            string cityStr = "New York";

            Museum mTest = new Museum(lat, lng, theName, phone, theUrl, add1, add2, theZip, cityStr);

            bool expected = true; 
            bool actual;
            actual = target.addMuseumToDb(mTest);

            // ** Check it was added **/
            Assert.AreEqual(expected, actual);
       
        }

       

        
        /// <summary>
        ///A test for getAllMuseumsFromDb
        ///</summary>
        [TestMethod()]
        public void getAllMuseumsFromDbTest()
        {
            MuseumDAL target = new MuseumDAL(); 
            bool forVisual = false; 
            
            List<Museum> actual;
 
           // IEnumerable<Museum> actual;
            actual = target.getAllMuseumsFromDb(forVisual);

            //** Assert List of Museums is returned **//
            Assert.IsInstanceOfType(actual, typeof(List<Museum>));
        }

        
    }
}
