using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeShare.infra;
using HomeShare.Models;
using HomeShare.Repositories;

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
        [ValidateAntiForgeryToken]
        public ActionResult MyInfo(MembreInfosModel mim)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

                if (uow.UpdateMembre(mim))
                {

                    return RedirectToAction("Index", "Home", new { area = "Membre" });

                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Une erreur s'est produite, veuillez réessayer";
                return View();
            }

        }

        
    }
}