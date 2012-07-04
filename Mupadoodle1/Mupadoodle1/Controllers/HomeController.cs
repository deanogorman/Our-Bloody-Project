using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mupadoodle1.Models;
using Mupadoodle1.Ingestion;

namespace Mupadoodle1.Controllers
{
    public class HomeController : Controller
    {
        private CSVReader csvr = new CSVReader();

        public ActionResult ReadSampleFile()
        {
            return View(csvr.getCSVFileData());
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
