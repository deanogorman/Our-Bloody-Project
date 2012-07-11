using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mupadoodle1.Models;
using Mupadoodle1.Ingestion;
using System.Runtime.Serialization.Json;
using System.IO;
using Mupadoodle1.DataAccess;

namespace Mupadoodle1.Controllers
{
    public class HomeController : Controller
    {
        public static List<Museum> MakeRequest(string requestUrl)
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
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Museum>));
                    Stream streamy = response.GetResponseStream();
                    object objResponse = jsonSerializer.ReadObject(streamy);
                    List<Museum> jsonResponse = objResponse as List<Museum>;
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
            List<Museum> mList = csvr.getCSVFileDataMuseums();
            MuseumDAL mDAL = new MuseumDAL();

            // stick it in the dB
            // ???
            foreach (Museum m in mList)
            {
                mDAL.addMuseumToDb(m);
            }

            return View(mList);
        }

        // ** Add Museum to DB ** //
        public ActionResult addMuseumFiletoDB()
        {
            List<Museum> mList = csvr.getCSVFileDataMuseums();
            MuseumDAL mDAL = new MuseumDAL();

            // stick it in the dB
            foreach (Museum m in mList)
            {
                mDAL.addMuseumToDb(m);
            }

            return View();
        }

        // ** Query Museum DB **
        public ActionResult QueryMuseumDB()
        {
            string searchFor = "history";

            //ad to db
            List<Museum> mList = csvr.getCSVFileDataMuseums();
            MuseumDAL mDAL = new MuseumDAL();

            foreach (Museum m in mList)
            {
                mDAL.addMuseumToDb(m);
            }

            List<Museum> musList = mDAL.findMuseumFromUserInput();        //two different search methods
            //List<Museum> musList = mDAL.findMuseumFromdB(searchFor);

            return View(musList);
        }

        // ** Serialissation ** //
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
