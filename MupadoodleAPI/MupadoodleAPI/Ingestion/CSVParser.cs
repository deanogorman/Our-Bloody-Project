using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using MupadoodleAPI.Models;
using MupadoodleAPI.Ingestion;

namespace MupadoodleAPI.Ingestion
{
    public class CSVParser : IDataParser
    {
        private String supportedFormat = "csv";
        private StreamReader reader;

        public List<Models.Location> parseLocations()
        {
            CsvReader csv = new CsvReader(reader, true);
            int fieldCount = csv.FieldCount;
            List<Location> exList = new List<Location>();
            Location exObj = null;

            String[] headers = csv.GetFieldHeaders();

            while (csv.ReadNextRecord())
            {
                double lat = 0, lng = 0;
                string theName = null;
                for (int i = 0; i < fieldCount; i++)
                {
                    // this is where you actually create your dB object
                    if (headers[i].Equals("longitude"))
                    {
                        lng = Convert.ToDouble(csv[i]);
                    }
                    else if (headers[i].Equals("latitute"))
                    {
                        lat = Convert.ToDouble(csv[i]);
                    }
                    else if (headers[i].Equals("name"))
                    {
                        theName = csv[i];
                    }
                    exObj = new Location(lat, lng, theName);
                }
                exList.Add(exObj);
            }

            return exList;

            //throw new NotImplementedException();
        }

        private void parseShape(string shape, double lat, double lng)
        {
            // strip off the first a last characters in the string as these are braces
            string shape2 = shape.Substring(1, shape.Length - 2);
            // split the string into 2 strings
            string[] split = shape2.Split(new Char[] { ',' });
            lat = Convert.ToDouble(split[0]);
            lng = Convert.ToDouble(split[1]);
        }

        public List<Models.Museum> parseMuseums()
        {
            CsvReader csv = new CsvReader(reader, true);
            int fieldCount = csv.FieldCount;
            List<Museum> exList = new List<Museum>();
            Museum exObj = null;

            String[] headers = csv.GetFieldHeaders();

            while (csv.ReadNextRecord())
            {
                string cityStr = null;
                double lat = 0, lng = 0;
                string theName = null, theUrl = null, add1 = null, add2 = null, theZip = null, phone = null;

                for (int i = 0; i < fieldCount; i++)
                {
                    // this is where you actually create your dB object
                    if (headers[i].Equals("Shape"))
                    {
                        parseShape(csv[i], lat, lng);
                    }
                    else if (headers[i].Equals("NAME"))
                    {
                        theName = csv[i];
                    }
                    else if (headers[i].Equals("TEL"))
                    {
                        phone = csv[i];
                    }
                    else if (headers[i].Equals("URL"))
                    {
                        theUrl = csv[i];
                    }
                    else if (headers[i].Equals("ADRESS1")) // intentionally misspelt
                    {
                        add1 = csv[i];
                    }
                    else if (headers[i].Equals("ADDRESS2"))
                    {
                        add2 = csv[i];
                    }
                    else if (headers[i].Equals("ZIP"))
                    {
                        theZip = csv[i];
                    }
                    else if (headers[i].Equals("CITY"))
                    {
                        cityStr = csv[i];
                    }
                }

                exObj = new Museum(lat, lng, theName, phone, theUrl, add1, add2, theZip, cityStr);
                exList.Add(exObj);
            }

            return exList;

            //throw new NotImplementedException();
        }

        public List<Models.Park> parseParks()
        {
            CsvReader csv = new CsvReader(reader, true);
            int fieldCount = csv.FieldCount;
            List<Park> exList = new List<Park>();
            Park exObj = null;

            String[] headers = csv.GetFieldHeaders();

            while (csv.ReadNextRecord())
            {
                double lat = 0, lng = 0, theAcres = 0;
                string thePlace = null, theName = null;

                for (int i = 0; i < fieldCount; i++)
                {
                    // this is where you actually create your dB object
                    if (headers[i].Equals("Shape"))
                    {
                        parseShape(csv[i], lat, lng);
                    }
                    else if (headers[i].Equals("LOCATION"))
                    {
                        thePlace = csv[i];
                    }
                    else if (headers[i].Equals("SIGNNAME"))
                    {
                        theName = csv[i];
                    }
                    else if (headers[i].Equals("ACRES"))
                    {
                        theAcres = Convert.ToDouble(csv[i]);
                    }
                }

                exObj = new Park(lat, lng, theName, "New York", theAcres, thePlace);
                exList.Add(exObj);
            }

            return exList;

            //throw new NotImplementedException();
        }

        public void setStreamSource(StreamReader reader)
        {
            this.reader = reader;
            //throw new NotImplementedException();
        }

        public bool supportsType(string format)
        {
            if (format.Equals(supportedFormat))
            {
                return true;
            }
            return false;

            // we need to remove the exceptions that were automatically created when we automatically 
            // implemented the interface
            //throw new NotImplementedException();
        }
    }
}