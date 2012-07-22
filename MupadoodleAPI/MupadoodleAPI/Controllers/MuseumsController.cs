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
    public class MuseumsController : ApiController
    {
        List<Museum> museums = new List<Museum>();
        MuseumDAL mDAL = new MuseumDAL();

      //  [AllowAnonymous]
        public IEnumerable<Museum> GetAllMuseums()
        {
            museums = mDAL.getAllMuseumsFromDb(true);
            return museums;

            
            /*** NLog Stuf **/
            //Api logginh  System.Web.Http.AuthorizeAttribute
            //   private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            //logger.Trace("Sample trace message");
          //  logger.Debug("Sample debug message");
          //  logger.Info("Sample informational message");
           // logger.Warn("Sample warning message");
           // logger.Error("Sample error message");
           // logger.Fatal("Sample fatal error message");

            // alternatively - you can call the Log() method 
            // and pass log level as the parameter.
          //  logger.Log(LogLevel.Info, "Sample fatal error message");
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
