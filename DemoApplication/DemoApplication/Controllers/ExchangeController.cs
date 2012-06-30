using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoApplication.Models.UI;
using DemoApplication.Models;

namespace DemoApplication.Controllers
{
    public class ExchangeController : Controller
    {
        private ExchangeDb db = new ExchangeDb();

        //
        // GET: /Exchange/

        public ActionResult Index()
        {
            return View(db.ExchangeUIs.ToList());
        }

        //
        // GET: /Exchange/Details/5

        public ActionResult Details(int id = 0)
        {
            ExchangeUI exchangeui = db.ExchangeUIs.Find(id);
            if (exchangeui == null)
            {
                return HttpNotFound();
            }
            return View(exchangeui);
        }

        //
        // GET: /Exchange/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Exchange/Create

        [HttpPost]
        public ActionResult Create(ExchangeUI exchangeui)
        {
            if (ModelState.IsValid)
            {
                db.ExchangeUIs.Add(exchangeui);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exchangeui);
        }

        //
        // GET: /Exchange/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExchangeUI exchangeui = db.ExchangeUIs.Find(id);
            if (exchangeui == null)
            {
                return HttpNotFound();
            }
            return View(exchangeui);
        }

        //
        // POST: /Exchange/Edit/5

        [HttpPost]
        public ActionResult Edit(ExchangeUI exchangeui)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exchangeui).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exchangeui);
        }

        //
        // GET: /Exchange/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ExchangeUI exchangeui = db.ExchangeUIs.Find(id);
            if (exchangeui == null)
            {
                return HttpNotFound();
            }
            return View(exchangeui);
        }

        //
        // POST: /Exchange/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ExchangeUI exchangeui = db.ExchangeUIs.Find(id);
            db.ExchangeUIs.Remove(exchangeui);
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