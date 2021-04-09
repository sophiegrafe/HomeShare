using HomeShare.Models;
using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public ActionResult AjouterBien(AjoutBienModel abm)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

                if (uow.AddBien(abm))
                {

                    return RedirectToAction("Index", "Home", new { area = "Membre" });

                }
                else
                {
                    return RedirectToAction("AjouterBien", "Home", new { area = "Membre" });
                }
            }
            else
            {
                ViewBag.Error = "Quelque chose n'a pas fonctionné ...";
                return View();
            }
            
        }
    }
}