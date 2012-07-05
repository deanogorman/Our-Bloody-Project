using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using Mupadoodle1.Models;
using Mupadoodle1.Ingestion;

namespace Mupadoodle1.Ingestion
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