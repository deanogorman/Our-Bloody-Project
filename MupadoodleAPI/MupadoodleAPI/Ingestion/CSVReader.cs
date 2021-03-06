﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MupadoodleAPI.Models;

namespace MupadoodleAPI.Ingestion
{
    public class CSVReader
    {
        private string fnameMuseums = "C:\\Louise\\Semester3\\EnterpriseFrameworks\\GroupProj\\Mup6\\Mupadoodle1\\Museums_Small.csv";
        private string fname = "C:\\Louise\\Semester3\\EnterpriseFrameworks\\GroupProj\\Mup6\\Mupadoodle1\\myfile.csv";
        private string fnameParks = "C:\\Louise\\Semester3\\EnterpriseFrameworks\\GroupProj\\Mup6\\Mupadoodle1\\NYC_Parks_Small.csv";

       //private string fname = "C:\\Users\\Tony\\Documents\\NCIRL\\Semester 3\\H9TECENT - Enterprise Frameworks\\Our-Bloody-Project\\Mupadoodle1\\myfile.csv";
       //private string fnameMuseums = "C:\\Users\\Tony\\Documents\\NCIRL\\Semester 3\\H9TECENT - Enterprise Frameworks\\Our-Bloody-Project\\Mupadoodle1\\Museums_and_Galleries.csv";
       //private string fnameParks = "C:\\Users\\Tony\\Documents\\NCIRL\\Semester 3\\H9TECENT - Enterprise Frameworks\\Our-Bloody-Project\\Mupadoodle1\\NYC_Parks.csv";
        private StreamReader myReader;

        public List<Location> getCSVFileData()
        {
            if (!File.Exists(fname))
            {
                return null;
            }

            myReader = new StreamReader(fname);
            CSVParser parser = new CSVParser();
            parser.setStreamSource(myReader);
            return (parser.parseLocations());
        }

        public List<Museum> getCSVFileDataMuseums()
        {
            if (!File.Exists(fnameMuseums))
            {
                return null;
            }

            myReader = new StreamReader(fnameMuseums);
            CSVParser parser = new CSVParser();
            parser.setStreamSource(myReader);
            return (parser.parseMuseums());
        }

        public List<Park> getCSVFileDataParks()
        {
            if (!File.Exists(fnameParks))
            {
                return null;
            }

            myReader = new StreamReader(fnameParks);
            CSVParser parser = new CSVParser();
            parser.setStreamSource(myReader);
            return (parser.parseParks());
        }
    }
}