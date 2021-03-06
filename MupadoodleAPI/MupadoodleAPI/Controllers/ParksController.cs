﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MupadoodleAPI.Models;
using MupadoodleAPI.DataAccess;
using MupadoodleAPI.Ingestion;

namespace MupadoodleAPI.Controllers
{
    public class ParksController : ApiController
    {
        List<Park> parks = new List<Park>();
        ParkDAL pDAL = new ParkDAL();

        public IEnumerable<Park> GetAllMuseums()
        {
            parks = pDAL.getAllParksFromDb(true);
            return parks;
        }

        public Park GetParkById(int id)
        {
            parks = pDAL.getAllParksFromDb(true);
            var park = parks.FirstOrDefault((p) => p.LocationID == id);
            if (park == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return park;
        }

        public IEnumerable<Park> GetParksInCity(string city)
        {
            parks = pDAL.getAllParksFromDb(true);
            return parks.Where(
                (p) => string.Equals(p.cityStr, city,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
