using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MupadoodleAPI.Models;
using MupadoodleAPI.Ingestion;
using System.Runtime.Serialization.Json;
using System.IO;
using MupadoodleAPI.DataAccess;
using MupadoodleAPI.Logic;
using Newtonsoft.Json;

namespace MupadoodleAPI.Controllers
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
            return View(csvr.getCSVFileDataMuseums());
        }

        // ** Add Museum to DB ** //
        public ActionResult addMuseumFiletoDB()
        {
            BuildVenues bv = new BuildVenues();

            return View();
        }


        // ** Query Museum DB **
        public ActionResult QueryMuseumDB()
        {
            string searchFor = "history";

            MuseumDAL mDAL = new MuseumDAL();

            List<Museum> musList = mDAL.findMuseumFromUserInput();        //two different search methods
            //List<Museum> musList = mDAL.findMuseumFromdB(searchFor);

            return View(musList);
        }

        public ActionResult ShowCitiesGraphically()
        {
            List<City> cList = new List<City>();
            CitiesDAL cDal = new CitiesDAL();
            List<Museum> mList = new List<Museum>();
            MuseumDAL mDal = new MuseumDAL();
            List<Park> pList = new List<Park>();
            ParkDAL pDal = new ParkDAL();
            List<Market> mkList = new List<Market>();
            MarketDAL mkDal = new MarketDAL();

            cList = cDal.getAllCitiesFromDb(true);
            mList = mDal.getAllMuseumsFromDb(true);
            pList = pDal.getAllParksFromDb(true);
            mkList = mkDal.getAllMarketsFromDb(true);


            //System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
         //new System.Web.Script.Serialization.JavaScriptSerializer();
            //string sJSON = oSerializer.Serialize(cList);
         var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
         string cjson = JsonConvert.SerializeObject(cList, Formatting.Indented, serializerSettings);
         string mjson = JsonConvert.SerializeObject(mList, Formatting.Indented, serializerSettings);
         string pjson = JsonConvert.SerializeObject(pList, Formatting.Indented, serializerSettings);
         string majson = JsonConvert.SerializeObject(mkList, Formatting.Indented, serializerSettings);
         //string sjson2 = JsonConvert.ToString(cList[0]);
            ViewData["Cities"] = cjson;
            ViewData["Museums"] = mjson;
            ViewData["Parks"] = pjson;
            ViewData["Markets"] = majson;

            return View(cList);
        }
        

        public ActionResult BuildCities()
        {

            BuildCities bCities = new BuildCities();
            List<City> cList = new List<City>();
            CitiesDAL cDal = new CitiesDAL();

            cList = cDal.getAllCitiesFromDb();

            return View(cList);
        }

        // ** Serialissation ** //
        public ActionResult ReadMuseumStreum()
        {
            return View(MakeRequest("https://nycopendata.socrata.com/api/views/sat5-adpb/rows.json"));
        }

        public ActionResult Index()
        {
            List<City> cList = new List<City>();
            CitiesDAL cDal = new CitiesDAL();
            List<Museum> mList = new List<Museum>();
            MuseumDAL mDal = new MuseumDAL();
            List<Park> pList = new List<Park>();
            ParkDAL pDal = new ParkDAL();
            List<Market> mkList = new List<Market>();
            MarketDAL mkDal = new MarketDAL();

            cList = cDal.getAllCitiesFromDb(true);
            mList = mDal.getAllMuseumsFromDb(true);
            pList = pDal.getAllParksFromDb(true);
            mkList = mkDal.getAllMarketsFromDb(true);


            //System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
            //new System.Web.Script.Serialization.JavaScriptSerializer();
            //string sJSON = oSerializer.Serialize(cList);
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string cjson = JsonConvert.SerializeObject(cList, Formatting.Indented, serializerSettings);
            string mjson = JsonConvert.SerializeObject(mList, Formatting.Indented, serializerSettings);
            string pjson = JsonConvert.SerializeObject(pList, Formatting.Indented, serializerSettings);
            string mkjson = JsonConvert.SerializeObject(mkList, Formatting.Indented, serializerSettings);
            //string sjson2 = JsonConvert.ToString(cList[0]);
            ViewData["Cities"] = cjson;
            ViewData["Museums"] = mjson;
            ViewData["Parks"] = pjson;
            ViewData["Markets"] = mkjson;

            return View(cList);
        }

        /** Admin **/
        public ActionResult Admin()
        {
            return View();
        }

        /** API **/
        public ActionResult Developer()
        {
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
