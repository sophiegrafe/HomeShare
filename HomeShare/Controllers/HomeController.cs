using HomeShare.infra;
using HomeShare.Models;
using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Home = "active";
            HomeViewModel hvm = new HomeViewModel();
            return View(hvm);
        }

        public ActionResult About()
        {
            ViewBag.About = "active";
            return View();
        }

        public ActionResult Owners()
        {
            ViewBag.Owners = "active";
            return View();
        }

        public ActionResult Echanges()
        {
            ViewBag.Echanges = "active";
            return View();
        }

        [HttpGet]
        public ActionResult BienDetails()
        {
            ViewBag.BienDetails = "active";
            return View();
        }

        [HttpPost]
        public ActionResult BienDetails(FormCollection form)
        {
            string strIdBien = form["IdBien"].ToString();
            int idBien = int.Parse(strIdBien);
            SessionUtils.IdBienDetails = idBien;

            DetailsViewModel dvm = new DetailsViewModel();
            return View(dvm);
        }

        public ActionResult Contact()
        {
            ViewBag.Contact = "active";
            return View();
        }
    }
}