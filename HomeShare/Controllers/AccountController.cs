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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        /***Recuperation du Login de l'utilisateur enregistré ***/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                if (lm.Login != "Chou" && lm.Password != "test1234")
                {
                    ViewBag.Error = "Votre login ou votre mot de passe ne correspondent pas, veuillez réessayer.";
                    return View();
                }
                else
                {
                    SessionUtils.IsLogged = true;
                    return RedirectToAction("Index", "Home", new { area = "Membre" });
                }
            }
            else
            {
                return View();
            }
        }

        /*------- OUT ------*/

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


    }
}