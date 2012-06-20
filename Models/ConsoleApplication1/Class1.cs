using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    //[Table(Name = "SCHOOLS")]
    public class School : Location
    {
        public City city; // the city in which the School is located school.City
        //double longitude inhereted;
        //double latitude inhereted;
        //string Name inhereted;
        string level;       //primary, secondary, both
        string gender;      //male, female, mixed
        string principal;   //principal name
        int studentSize;    //number of students
        int facultySize;    //number of teachers
        bool religion;   //religious based school?
        string sports;      //list of sports. Perhaps an array?

        public School(double Lat, double Long, string tsName)
            : base(Lat, Long, tsName)
        {
            this.level = "";
            this.gender = "";
            this.principal = "";
            this.studentSize = 0;
            this.facultySize = 0;
            this.religion = false;
            this.sports = "";
        }
    }
}