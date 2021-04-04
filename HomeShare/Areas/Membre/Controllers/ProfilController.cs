using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeShare.Models;

namespace HomeShare.Areas.Membre.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Membre/Profil
        public ActionResult MyInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyInfo(MembreModel mm)
        {   

            return View();
        }
    }
}