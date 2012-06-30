using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DemoApplication.Models;

namespace DemoApplication.Ingestion
{
    public class CSVReader
    {
        private string fname = "C:\\Users\\Tony\\Documents\\NCIRL\\Semester 3\\H9TECENT - Enterprise Frameworks\\Lecture 6\\DemoApplication\\DemoApplication\\myfile.csv";
        private StreamReader myReader;

        public List<ExchangeRate> getCSVFileData()
        {
            if (!File.Exists(fname))
            {
                return null;
            }

            myReader = new StreamReader(fname);
            CSVParser parser = new CSVParser();
            parser.setStreamSource(myReader);
            return (parser.parseExchangeRates());
        }
    }
}