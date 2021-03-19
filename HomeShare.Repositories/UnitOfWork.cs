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

    }
}
