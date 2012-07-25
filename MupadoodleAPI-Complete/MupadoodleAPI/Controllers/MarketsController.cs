using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MupadoodleAPI.Models;
using MupadoodleAPI.DataAccess;
using MupadoodleAPI.Ingestion;
using NLog;

namespace MupadoodleAPI.Controllers
{
    // [Authorize]
    public class MarketsController : ApiController
    {
        List<Market> markets = new List<Market>();
        MarketDAL mkDAL = new MarketDAL();
       
        //[AllowAnonymous]
        public IEnumerable<Market> GetAllMarkets()
        {
            markets = mkDAL.getAllMarketsFromDb(true);
            return markets;
        }

        public Market GetMarketById(int id)
        {
            markets = mkDAL.getAllMarketsFromDb(true);
            var market = markets.FirstOrDefault((mk => mk.LocationID == id));
            if (market == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return market;
        }

        public IEnumerable<Market> GetMarketsInCity(string city)
        {
            markets = mkDAL.getAllMarketsFromDb(true);
            return markets.Where(
                (m) => string.Equals(m.cityStr, city,
                    StringComparison.OrdinalIgnoreCase));
        }

        /** Return all museums with search word in its name **/
        public IEnumerable<Market> GetMarketsWithName(string marketName)
        {
            markets = mkDAL.getAllMarketsFromDb(true);
            string name = marketName.ToLower();
            return markets.Where(
                (m) => (m.lname.ToLower().Contains(name)));
        }

    }
}
