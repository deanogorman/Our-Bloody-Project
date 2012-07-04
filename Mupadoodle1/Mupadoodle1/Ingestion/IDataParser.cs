using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mupadoodle1.Models;
using System.IO;

namespace Mupadoodle1.Ingestion
{
    interface IDataParser
    {
        // returns a List of ExchangeRate objects
        List<Location> parseLocations();
        void setStreamSource(StreamReader reader);
        Boolean supportsType(String format);
    }
}
