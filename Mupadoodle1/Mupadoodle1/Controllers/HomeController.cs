using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mupadoodle1.Models;
using Mupadoodle1.Ingestion;
using System.Runtime.Serialization.Json;

namespace Mupadoodle1.Controllers
{
    public class HomeController : Controller
    {
        public static Museum MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Museum));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Museum jsonResponse = objResponse as Museum;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private CSVReader csvr = new CSVReader();

        public ActionResult ReadSampleFile()
        {
            return View(csvr.getCSVFileData());
        }

        public ActionResult ReadMuseumFile()
        {
            return View(csvr.getCSVFileDataMuseums());
        }

        public ActionResult ReadMuseumStreum()
        {
            return View(MakeRequest("https://nycopendata.socrata.com/api/views/sat5-adpb/rows.json"));
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
