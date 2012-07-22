using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MupadoodleAPI.Models;
using System.IO;

namespace MupadoodleAPI.Ingestion
{
    interface IDataParser
    {
        // returns a List of ExchangeRate objects
        List<Location> parseLocations();
        void setStreamSource(StreamReader reader);
        Boolean supportsType(String format);
    }
}
