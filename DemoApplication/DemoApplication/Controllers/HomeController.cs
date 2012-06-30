using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoApplication.Models;
using DemoApplication.Ingestion;

namespace DemoApplication.Controllers
{
    public class HomeController : Controller
    {
        private ExchangeDb db = new ExchangeDb();
        private CSVReader csvr = new CSVReader();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.exchangeRates.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            ExchangeRate exchangerate = db.exchangeRates.Find(id);
            if (exchangerate == null)
            {
                return HttpNotFound();
            }
            return View(exchangerate);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        
        public ActionResult ReadSampleFile()
        {
            return View(csvr.getCSVFileData());
        }
        
        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(ExchangeRate exchangerate)
        {
            if (ModelState.IsValid)
            {
                db.exchangeRates.Add(exchangerate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exchangerate);
        }

        /*
        public ActionResult ReadSampleFile(ExchangeRate exchangerate)
        {
            if (ModelState.IsValid)
            {
                csvr.getCSVFileData();
                //db.exchangeRates.Add(exchangerate);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View();
        }
        */

        //
        // POST: /Home/Calculate

        //[HttpPost, ActionName("Calculate")]
        public ActionResult Calculate(double amount)
        {
            if (ModelState.IsValid)
            {   
                return RedirectToAction("Index");
            }

            return View(amount);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExchangeRate exchangerate = db.exchangeRates.Find(id);
            if (exchangerate == null)
            {
                return HttpNotFound();
            }
            return View(exchangerate);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(ExchangeRate exchangerate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exchangerate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exchangerate);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ExchangeRate exchangerate = db.exchangeRates.Find(id);
            if (exchangerate == null)
            {
                return HttpNotFound();
            }
            return View(exchangerate);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ExchangeRate exchangerate = db.exchangeRates.Find(id);
            db.exchangeRates.Remove(exchangerate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}