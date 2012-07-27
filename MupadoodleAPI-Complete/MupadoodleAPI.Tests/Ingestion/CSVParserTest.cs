using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MupadoodleAPI.Ingestion;
using MupadoodleAPI.Models;
using System.IO;


namespace MupadoodleAPI.Tests
{
    [TestClass]
    public class CSVParserTest
    {
        /// <summary>
        ///A test for Mupadoodle.Ingestion.IDataParser.supportsType
        ///</summary>
        [TestMethod()]
        public void supportsTypeTest()
        {
            IDataParser target = new CSVParser();

            string format1 = "csv";
            bool expected1 = true;
            bool actual1;
            actual1 = target.supportsType(format1);
            Assert.AreEqual(expected1, actual1);
            
            string format2 = "json";
            bool expected2 = false;
            bool actual2;
            actual2 = target.supportsType(format2);
            Assert.AreEqual(expected2, actual2);
        
        }

        /// <summary>
        ///A test for MupadoodleAPI.Ingestion.IDataParser.parseMuseums
        ///</summary>
        [TestMethod()]
        public void parseMuseumsTest()
        {
            //** Actual Museum Object **//
            string fnameMuseums = "C:\\Louise\\Semester3\\EnterpriseFrameworks\\GroupProj\\MupadoodleAPI-Complete\\Museums_ParserTest.csv";
            StreamReader myReader = new StreamReader(fnameMuseums);
            CSVParser target = new CSVParser();
            target.setStreamSource(myReader);


            //**Test Museum Oject **//
            string cityStr = "New York";
            double lat = 40.7, lng = -74.01;
            string theName = "Alexander Hamilton U.S. Custom House", theUrl = "http://www.oldnycustomhouse.gov/", add1 = "1 Bowling Grn", add2 = null, theZip = "10004", phone = " 514-3700";
            Museum mTest = new Museum(lat, lng, theName, phone, theUrl, add1, add2, theZip, cityStr);

            //** Expected **//
            List<Museum> expected = new List<Museum>();
            expected.Add(mTest);

            //** Actual **//
            List<Museum> actual;
            actual = target.parseMuseums();

            //** First Test **//
            Assert.AreEqual(expected.Count, actual.Count);

            //** Second Test **//
            Museum museumCity = actual.Find(item => item.cityStr == "New York");
            Assert.IsNotNull(museumCity);

            //** Third Test - Test parseShape **//
            Museum museumLat = actual.Find(item => item.latitude == 40.7);
            Assert.IsNotNull(museumLat);
        }


        /// <summary>
        ///A test for MupadoodleAPI.Ingestion.IDataParser.parseShape
        ///</summary>
        [TestMethod()]
        public void parseShapeTest()
        {
            //** Actual Museum Object **//
            String testShape = "(40.7, -74.01)";
            double actualLat = 0, actualLong = 0;

            CSVParser target = new CSVParser();
            target.parseShape(testShape, ref actualLat, ref actualLong);

            //**Expected Lat and Long **//
            double lat = 40.7, lng = -74.01;

            //** First Test **//
            Assert.AreEqual(actualLat, lat);
            Assert.AreEqual(actualLong, lng);
        }
    }
}
