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
        
        public ActionResult AjouterBien(FormCollection form, AjouterBienViewModel abvm)
        {
            AjoutBienModel abm = new AjoutBienModel();
            abm.Titre = form["NewBien.Titre"].ToString();
            abm.DescCourte = form["NewBien.DescCourte"].ToString();
            abm.DescLong = form["NewBien.DescLong"].ToString();
            abm.Pays = int.Parse(form["Pays"].ToString());
            abm.Ville = form["NewBien.Ville"].ToString();
            abm.Rue = form["NewBien.Rue"].ToString();
            abm.Numero = form["NewBien.Numero"].ToString();
            abm.CodePostal = form["NewBien.CodePostal"].ToString();
            abm.Photo = form["NewBien.Photo"].ToString();
            abm.NombrePerson = int.Parse(form["NewBien.NombrePerson"].ToString());
            abm.NbrSBD = int.Parse(form["NewBien.NbrSBD"].ToString());
            abm.NbrWC = int.Parse(form["NewBien.NbrWC"].ToString());


            string assuranceObligatoire = form["NewBien.AssuranceObligatoire"];
            if (assuranceObligatoire == "true,false")
            {
                abm.AssuranceObligatoire = true;
            }
            else { abm.AssuranceObligatoire = false; }

            abm.ListeIdOption = new List<OptionModel>();

            foreach (OptionModel item in abvm.ListeOption)
            {
                if (form.AllKeys.Contains(item.Libelle))
                {
                    OptionModel option = new OptionModel();
                    option.IdOption = item.IdOption;
                    option.Libelle = item.Libelle;
                    abm.ListeIdOption.Add(option);
                }
            }

            

            UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

            if (uow.AddBien(abm))
            {

                return RedirectToAction("Index", "Home", new { area = "Membre" });

            }
            else
            {
                return RedirectToAction("AjouterBien", "Sharing", new { area = "Membre" });
            }
        }
    }
}