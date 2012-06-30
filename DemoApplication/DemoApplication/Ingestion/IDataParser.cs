using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoApplication.Models;
using System.IO;

namespace DemoApplication.Ingestion
{
    interface IDataParser
    {
        // returns a List of ExchangeRate objects
        List<ExchangeRate> parseExchangeRates();
        void setStreamSource(StreamReader reader);
        Boolean supportsType(String format);
    }
}
