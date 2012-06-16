using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;



namespace ConsoleApplication1
{
    [Table(Name = "TRAINSTATIONS")]
    public class TrainStation
    {
        City city; // the city in which the park is located park.City
        float longitude;
        float latitude;
        string Name;
        
    }
}
