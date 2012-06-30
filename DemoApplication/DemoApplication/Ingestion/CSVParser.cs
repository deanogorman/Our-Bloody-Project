using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using DemoApplication.Models;

namespace DemoApplication.Ingestion
{
    public class CSVParser : IDataParser
    {
        private String supportedFormat = "csv";
        private StreamReader reader;

        public List<Models.ExchangeRate> parseExchangeRates()
        {
            CsvReader csv = new CsvReader(reader, true);
            int fieldCount = csv.FieldCount;
            List<ExchangeRate> exList = new List<ExchangeRate>();
            ExchangeRate exObj = null;

            String[] headers = csv.GetFieldHeaders();

            while (csv.ReadNextRecord())
            {
                exObj = new ExchangeRate();
                for (int i = 0; i < fieldCount; i++)
                {
                    // this is where you actually create your dB object
                    if (headers[i].Equals("fromCurrency"))
                    {
                        exObj.fromCurrency = csv[i];
                    }
                    else if (headers[i].Equals("toCurrency"))
                    {
                        exObj.toCurrency = csv[i];
                    }
                    else if (headers[i].Equals("rate"))
                    {
                        exObj.rate = Convert.ToDouble(csv[i]);
                    }
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
            if (format.Equals(supportedFormat)) {
                return true;
            }
            return false;

            // we need to remove the exceptions that were automatically created when we automatically 
            // implemented the interface
            //throw new NotImplementedException();
        }
    }
}