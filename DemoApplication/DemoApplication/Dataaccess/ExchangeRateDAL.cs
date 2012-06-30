using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoApplication.Models;

namespace DemoApplication.Dataaccess
{
    public class ExchangeRateDAL
    {
        public ExchangeRate findExchangeRateForConverstion(String fromCurrency, String toCurrency)
        {
            // Normally we will do a lookup on the database, but not tonight!
            return new ExchangeRate("USD", "EUR", 1.2333);
        }

        public ExchangeRate addNewExchangeRate(String fromCurrency, string toCurrency, double rate)
        {
            // This is where we typically new the class and add it to the database
            return null;
        }
        public ExchangeRate deleteExchangeRate()
        {
            return null;
        }
    }
}