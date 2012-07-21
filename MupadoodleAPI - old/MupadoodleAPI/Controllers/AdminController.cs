using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MupadoodleAPI.Models;

namespace MupadoodleAPI.Controllers
{
    public class AdminController : ApiController
    {
        private AccessDB db = new AccessDB();

        // GET api/Admin
        public IEnumerable<Museum> GetMuseums()
        {
            return db.museums.AsEnumerable();
        }

        // GET api/Admin/5
        public Museum GetMuseum(int id)
        {
            Museum museum = db.museums.Find(id);
            if (museum == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return museum;
        }

        // PUT api/Admin/5
        public HttpResponseMessage PutMuseum(int id, Museum museum)
        {
            if (ModelState.IsValid && id == museum.LocationID)
            {
                db.Entry(museum).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, museum);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Admin
        public HttpResponseMessage PostMuseum(Museum museum)
        {
            if (ModelState.IsValid)
            {
                db.museums.Add(museum);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, museum);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = museum.LocationID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Admin/5
        public HttpResponseMessage DeleteMuseum(int id)
        {
            Museum museum = db.museums.Find(id);
            if (museum == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.museums.Remove(museum);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, museum);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}