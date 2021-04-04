using HomeShare.Entities;
using HomeShare.Models;
using HomeShare.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class UnitOfWork
    {
        IConcreteRepository<MembreEntity> _membreRepo;
        IConcreteRepository<BienEntity> _bienRepo;

        public UnitOfWork(string connectionString)
        {
            _membreRepo = new MembreRepository(connectionString);
            _bienRepo = new BienRepository(connectionString);
        }

        #region Account
        public bool CreateMember(MembreModel mm)
        {
            MembreEntity membreEntity = new MembreEntity()
            {
                Nom = mm.Nom,
                Prenom = mm.Prenom,
                Login = mm.Login,
                Password = mm.Password,
                Email = mm.Email,
                Telephone = mm.Telephone,
                Pays = mm.Pays,
            };
            return _membreRepo.Insert(membreEntity);


        }


        public MembreModel UserAuth(LoginModel lm)
        {
            MembreEntity me = ((MembreRepository)_membreRepo).GetFromLogin(lm.Login, lm.Password);
            if (me == null) return null;
            if (me != null)
            {   

                return new MembreModel()
                {
                    IdMembre = me.IdMembre,
                    Nom = me.Nom,
                    Prenom = me.Prenom,
                    Login = me.Login,
                    Password = me.Password,
                    Email = me.Email,
                    Telephone = me.Telephone,
                    Pays = me.Pays

                };
            }
            else
            {
                return null;
            }
        }
        #endregion

        public List<BienModel> GetAllBien()
        {   
            // est ce que faire ça revient à faire un foreach + NomdelaListe.Add(bm) comme pour GetLast5?

            return _bienRepo.Get()
                .Select(m =>
                new BienModel()
                {
                    IdBien = m.IdBien,
                    IdMembre = m.IdMembre,
                    NombrePerson = m.NombrePerson,
                    Pays = m.Pays,
                    Titre = m.Titre,
                    DescCourte = m.DescCourte,
                    DescLong = m.DescLong,
                    Ville = m.Ville,
                    Rue = m.Rue,
                    Numero = m.Numero,
                    CodePostal = m.CodePostal,
                    Photo = m.Photo,
                    Latitude = m.Latitude,
                    Longitude = m.Longitude,
                    AssuranceObligatoire = m.AssuranceObligatoire,
                    IsEnabled = m.IsEnabled,
                    DisabledDate = m.DisabledDate, 
                    DateCreation = m.DateCreation
                }
                ).ToList();

        }

        public BienModel GetBienDetails()
        {

            BienEntity bienFromDB = _bienRepo.GetOne((int)HttpContext.Current.Session["IdBienDetails"]);
            BienModel bienForController = new BienModel();

            bienForController.IdBien = bienFromDB.IdBien;
            bienForController.IdMembre = bienFromDB.IdMembre;
            bienForController.NombrePerson = bienFromDB.NombrePerson;
            bienForController.Pays = bienFromDB.Pays;
            bienForController.Titre = bienFromDB.Titre;
            bienForController.DescCourte = bienFromDB.DescCourte;
            bienForController.DescLong = bienFromDB.DescLong;
            bienForController.Ville = bienFromDB.Ville;
            bienForController.Rue = bienFromDB.Rue;
            bienForController.Numero = bienFromDB.Numero;
            bienForController.CodePostal = bienFromDB.CodePostal;
            bienForController.Photo = bienFromDB.Photo;
            bienForController.Latitude = bienFromDB.Latitude;
            bienForController.Longitude = bienFromDB.Longitude;
            bienForController.AssuranceObligatoire = bienFromDB.AssuranceObligatoire;
            bienForController.IsEnabled = bienFromDB.IsEnabled;
            bienForController.DisabledDate = bienFromDB.DisabledDate;
            bienForController.DateCreation = bienFromDB.DateCreation;

            return bienForController;
        }

        //_________________________________

        /*prob pendant l'épreuve : impossible d'utiliser la vue sql top 5 de "GetLast5()"
          renvoi à l'absence de la methode dans baseRepository
          erreur --> oublié de caster le _bienRepo : _bienRepo.GetLast5()
          solution --> !!! ((BienRepository)_bienRepo).GetLast5() !!! */
        //_________________________________

        public List<BienModel> GetLast5ForCtrl()

        {   
            // aller chercher la liste de bien de la vue sql
            List<BienEntity> Last5FromDB = ((BienRepository)_bienRepo).GetLast5();
            List<BienModel> Last5ForCtrl = new List<BienModel>();
            // mapping pour chaque bien de la liste
            foreach (BienEntity be in Last5FromDB)
            {
                //instanciation du BienModel
                BienModel bm = new BienModel();

                //mapping
                bm.IdBien = be.IdBien;
                bm.Titre = be.Titre;
                bm.Ville = be.Ville;
                bm.DescCourte = be.DescCourte;
                bm.NombrePerson = be.NombrePerson;
                bm.IsEnabled = be.IsEnabled;
                bm.Photo = be.Photo;

                //ajout à la liste de biens à renvoyer au controller
                Last5ForCtrl.Add(bm);
            }
            return Last5ForCtrl;
        }
        

    }
}
