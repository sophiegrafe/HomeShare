using HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            return View(hvm);
        }

        public ActionResult About()
        {           

            return View();
        }

        public ActionResult Owners()
        {

            return View();
        }
        public ActionResult Echanges()
        {

            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
    }
}