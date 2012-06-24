using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoApplication.Dataaccess;
using DemoApplication.Models;

namespace DemoApplication.logic
{
    public class ExchangeCalculator
    {
        public double calculateExchangeRate(String fromCurrency, String toCurrency, double amount)
        {
            ExchangeRateDAL dal = new ExchangeRateDAL();
            ExchangeRate rate = dal.findExchangeRateForConverstion(fromCurrency, toCurrency);
            return rate.Rate * amount;
        }
    }
}