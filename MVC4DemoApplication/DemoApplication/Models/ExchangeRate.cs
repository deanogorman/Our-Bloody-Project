using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace DemoApplication.Models
{
    [Table (Name="EXCHANGERATES")] 
    public class ExchangeRate
    {
        [Column(IsPrimaryKey = true)]
        int id;
        [Column(Name = "FROMCURRENCY")]
        String fromCurrency;
        [Column(Name = "TOCURRENCY")]
        String toCurrency;
        [Column(Name = "RATE")]
        double rate;

        public double Rate
        {
            get { return rate; }
        }

        public ExchangeRate(String _fromCurrency, String _toCurrency, double _rate)
        {
            this.fromCurrency = _fromCurrency;
            this.toCurrency = _toCurrency;
            this.rate = _rate;
        }






    }
}