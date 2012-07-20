using System;
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
    public class MuseumsController : ApiController
    {
        List<Museum> museums = new List<Museum>();
        MuseumDAL mDAL = new MuseumDAL();

        //Api logginh
       // private readonly IUrlRepository _repo;
       // private readonly ITraceWriter _tracer;

        public IEnumerable<Museum> GetAllMuseums()
        {
            museums = mDAL.getAllMuseumsFromDb(true);
            return museums;
        }

        public Museum GetMuseumById(int id)
        {
            museums = mDAL.getAllMuseumsFromDb(true);
            var museum = museums.FirstOrDefault((m) => m.LocationID == id);
            if (museum == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return museum;
        }

        public IEnumerable<Museum> GetMuseumsInCity(string city)
        {
            museums = mDAL.getAllMuseumsFromDb(true);
            return museums.Where(
                (m) => string.Equals(m.cityStr, city,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
