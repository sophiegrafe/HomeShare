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



        [HttpGet]
        public ActionResult BienDetails()
        {

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
            

            return View();
        }


    }
}