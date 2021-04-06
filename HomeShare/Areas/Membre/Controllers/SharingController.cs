﻿using HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Areas.Membre.Controllers
{
    public class SharingController : Controller
    {
        // GET: Membre/Sharing
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjouterBien()
        {
            AjouterBienViewModel abvm = new AjouterBienViewModel();
            return View(abvm);
        }

        [HttpPost]
        public ActionResult AjouterBien(BienModel bm)
        {
            return View();
        }
    }
}