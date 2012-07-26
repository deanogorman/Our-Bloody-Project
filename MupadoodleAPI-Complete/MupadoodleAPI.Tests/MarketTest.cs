using MupadoodleAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace MupadoodleAPI.Tests
{
    
    
    /// <summary>
    ///This is a test class for MarketTest and is intended
    ///to contain all MarketTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MarketTest
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
        ///A test for Market Constructor
        ///</summary>
        public void MarketConstructorTest()
        {
            double Lat = 2.0;
            double Long = 79.0;
            string marketName = "Times Market";
            string city = "New York";
            string location = "Broadway";
            Market target = new Market(Lat, Long, marketName, city, location);

            //** First Test **//
            Assert.AreEqual(target.location, location);

            //** Second Test **//
            string marketCity = target.cityStr;
            Assert.IsNotNull(marketCity);


            //** Third Test **//
            bool actual = false;

            if(target is Market)
            {
                 actual = true;
            }
            
            bool expected = true;
       
            Assert.AreEqual(expected, actual);
        
        }

      
        /// <summary>
        ///A test for MarketID
        ///</summary>
        public void MarketIDTest()
        {
            Market target = new Market(); 
            int expected = 0;
            int actual;
            target.MarketID = expected;
            actual = target.MarketID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cityStr
        ///</summary>
        public void cityStrTest()
        {
            double Lat = 2.0;
            double Long = 79.0;
            string marketName = "Times Market";
            string city = "New York";
            string location = "Broadway";
            Market target = new Market(Lat, Long, marketName, city, location);


            //** First Test **//
            string marketCity = target.cityStr;
            Assert.IsNotNull(marketCity);


            //** Second Test **//
            Assert.AreEqual(target.cityStr, city);
        }

        /// <summary>
        ///A test for location
        ///</summary>
        public void locationTest()
        {
            double Lat = 2.0;
            double Long = 79.0;
            string marketName = "Times Market";
            string city = "New York";
            string location = "Broadway";
            Market target = new Market(Lat, Long, marketName, city, location);


            //** First Test **//
            string marketLoc = target.location;
            Assert.IsNotNull(marketLoc);


            //** Second Test **//
            Assert.AreEqual(target.location, location);
        }

        /// <summary>
        ///A test for name
        ///</summary>
        public void nameTest()
        {
            Market target = new Market(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.name = expected;
            actual = target.name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for shape
        ///</summary>
        public void shapeTest()
        {
            Market target = new Market(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.shape = expected;
            actual = target.shape;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
