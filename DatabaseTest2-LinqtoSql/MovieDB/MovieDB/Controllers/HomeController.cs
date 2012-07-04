//Tutorial..
//http://www.asp.net/mvc/tutorials/older-versions/models-(data)/creating-model-classes-with-linq-to-sql-cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieDB.Models;

namespace MovieDB.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dataContext = new BookDataContext();
            var books = from b in dataContext.Books
                         select b;
            return View(books);
        }
    }
}
