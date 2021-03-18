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
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(MembreModel mm)
        {            
            
            if (ModelState.IsValid)
            {
                UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

                if (uow.CreateMember(mm))
                {

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return RedirectToAction("Register", "Account");
                }
            }
            else
            {
                ViewBag.Error = "Erreur Login/Password";
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }


    }
}