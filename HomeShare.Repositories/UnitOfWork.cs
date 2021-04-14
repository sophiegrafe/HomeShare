using HomeShare.Entities;
using HomeShare.Models;
using HomeShare.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Reflection;

namespace HomeShare.Repositories
{
    public class UnitOfWork
    {
        IConcreteRepository<MembreEntity> _membreRepo;
        IConcreteRepository<BienEntity> _bienRepo;
        IConcreteRepository<AjoutBienEntity> _ajoutBienRepo;
        IConcreteRepository<PaysEntity> _paysRepo;
        IConcreteRepository<OptionEntity> _optionRepo;

        public UnitOfWork(string connectionString)
        {
            _membreRepo = new MembreRepository(connectionString);
            _bienRepo = new BienRepository(connectionString);
            _ajoutBienRepo = new AjoutBienRepository(connectionString);
            _paysRepo = new PaysRepository(connectionString);
            _optionRepo = new OptionRepository(connectionString);
        }

        #region Account
        public bool CreateMember(MembreModel mm)
        {
            MembreEntity me = new MembreEntity()
            {
                Nom = mm.Nom,
                Prenom = mm.Prenom,
                Login = mm.Login,
                Password = mm.Password,
                Email = mm.Email,
                Telephone = mm.Telephone,
                Pays = mm.Pays,
            };
            return _membreRepo.Insert(me);
        }


        public MembreModel MembreAuth(LoginModel lm)
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
                    Pays = me.Pays,
                };
            }
            else
            {
                return null;
            }
        }


        public bool UpdateMembre(MembreInfosModel mim)
        {
            // transmettre l'id du membre connecté
            MembreModel membreToUpdate = (MembreModel)HttpContext.Current.Session["ConnectedUser"];
            MembreEntity me = new MembreEntity();

            if (mim.Nom == null)
                {
                    me.Nom = membreToUpdate.Nom;
                }
                else { me.Nom = mim.Nom; }

                if (mim.Prenom == null)
                {
                    me.Prenom = membreToUpdate.Prenom;
                }
                else { me.Prenom = mim.Prenom; }

                if (mim.Email == null)
                {
                    me.Email = membreToUpdate.Email;
                }
                else { me.Email = mim.Email; }

                if (mim.Telephone == null)
                {
                    me.Telephone = membreToUpdate.Telephone;
                }
                else { me.Telephone = mim.Telephone; }           
                
                me.Pays = mim.Pays;

                me.IdMembre = membreToUpdate.IdMembre;

            return _membreRepo.Update(me);
        }
        /* je voulais remplacer les if par un
           foreach (PropertyInfo prop in mm.GetType().GetProperties())
           {
               if (prop.GetValue(mim) != null)
                { 
                    me.GetType().GetProperties(????) = prop.GetValue(mim);
                }
                else
                {
                    me.GetType().GetProperties(?????) = membreToUpdate.GetValue(mim);
                }
           }
           mais ca ne marche pas ... */

        /*NB --> Je voudrais affiner l'Update avec un foreach mais je n'y arrive pas.
          Essai 1 :    dire : if la prop == null --> affecte membreToUpdate.propCorrespondante à me.propCorrespondante
                              else --> affecte mim.thisProp à me.propCorrespondante
          Essai 2 :    n'affecte à me que les props correspondantes et non null de mim
                       et modifier la methode update dans membrerepository pour qu'elle ne set que les props de me reçues.*/
        #endregion

        #region Biens
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

        // obtenir les détails du bien cliqué dans les sliders de la homepage pour alimenter la page détail du bien.
        public BienModel GetBienDetails()
        {

            BienEntity bienFromDB = _bienRepo.GetOne((int)HttpContext.Current.Session["IdBienDetails"]);
            BienModel bienForController = new BienModel
            {
                IdBien = bienFromDB.IdBien,
                IdMembre = bienFromDB.IdMembre,
                NombrePerson = bienFromDB.NombrePerson,
                Pays = bienFromDB.Pays,
                Titre = bienFromDB.Titre,
                DescCourte = bienFromDB.DescCourte,
                DescLong = bienFromDB.DescLong,
                Ville = bienFromDB.Ville,
                Rue = bienFromDB.Rue,
                Numero = bienFromDB.Numero,
                CodePostal = bienFromDB.CodePostal,
                Photo = bienFromDB.Photo,
                Latitude = bienFromDB.Latitude,
                Longitude = bienFromDB.Longitude,
                AssuranceObligatoire = bienFromDB.AssuranceObligatoire,
                IsEnabled = bienFromDB.IsEnabled,
                DisabledDate = bienFromDB.DisabledDate,
                DateCreation = bienFromDB.DateCreation
            };

            return bienForController;
        }

        //_________________________________

        /*prob pendant l'épreuve : impossible d'utiliser la vue sql top 5 de "GetLast5()"
          renvoi à l'absence de la methode dans baseRepository
          ERREUR --> oublié de caster le _bienRepo : _bienRepo.GetLast5()
          au lieu de --> !!! ((BienRepository)_bienRepo).GetLast5() !!! */
        //_________________________________

        public List<BienModel> GetLast5ForCtrl()
        {
            //version avec lambda
            return ((BienRepository)_bienRepo).GetLast5()
                .Select(bm =>
                new BienModel()
                {
                    IdBien = bm.IdBien,
                    Titre = bm.Titre,
                    Ville = bm.Ville,
                    DescCourte = bm.DescCourte,
                    NombrePerson = bm.NombrePerson,
                    IsEnabled = bm.IsEnabled,
                    Photo = bm.Photo,
                }
                ).ToList();
        }
            // version foreach
            /*List<BienEntity> Last5FromDB = ((BienRepository)_bienRepo).GetLast5();
              List<BienModel> Last5ForCtrl = new List<BienModel>();

              //mapping pour chaque bien de la liste

              foreach (BienEntity be in Last5FromDB)
              {
              BienModel bm = new BienModel();

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
              return Last5ForCtrl;*/
        

        

        // envoyer la liste de pays pour le select du fomrulaire Ajouter un Bien
        public List<PaysModel> GetAllPays()
        {
            //version lambda
            return _paysRepo.Get()
                .Select(pm =>
                new PaysModel()
                {
                    IdPays = pm.IdPays,
                    Libelle = pm.Libelle,
                }
                ).ToList();
        }

        //version foreach
        /*List<PaysEntity> ListePaysFromDB = _paysRepo.Get();
            List<PaysModel> ListePaysForCtrl = new List<PaysModel>();

            foreach (PaysEntity pe in ListePaysFromDB)
            {
                PaysModel pm = new PaysModel();
                pm.IdPays = pe.IdPays;
                pm.NomPays = pe.Libelle;
                ListePaysForCtrl.Add(pm);
            } 
            return ListePaysForCtrl;*/


        // ajouter un bien
        public bool AddBien(AjoutBienModel abm)
        {
            MembreModel owner = (MembreModel)HttpContext.Current.Session["ConnectedUser"];
            AjoutBienEntity abe = new AjoutBienEntity();
            //mapping partie Bien
            abe.Titre = abm.Titre;
            abe.DescCourte = abm.DescCourte;
            abe.DescLong = abm.DescLong;
            abe.Numero = abm.Numero;
            abe.Rue = abm.Rue;
            abe.CodePostal = abm.CodePostal;
            abe.Ville = abm.Ville;
            abe.Pays = abm.Pays;
            abe.NombrePerson = abm.NombrePerson;
            abe.NbrSBD = abm.NbrSBD;
            abe.NbrWC = abm.NbrWC;
            abe.IdMembre = owner.IdMembre;
            if (abm.Latitude is null)
            {
                abe.Latitude = "000000000";
            }
            else { abe.Latitude = abm.Latitude; }

            if (abm.Longitude is null)
            {
                abe.Longitude = "000000000";
            }
            else { abe.Longitude = abm.Longitude; }

            if (abm.Photo is null)
            {
                abe.Photo = "pas de photo disponible";
            }
            else { abe.Photo = abm.Photo; }


            //je traiterai les options plus tard 
            /*//mapping partie OptionBien
            abe.ListeOption = new List<OptionEntity>();
            foreach (OptionModel item in abm.ListeIdOption)
            {
                OptionEntity option = new OptionEntity();
                option.IdOption = item.IdOption;
                option.Libelle = item.Libelle;
                abe.ListeOption.Add(option);
            }*/
            return _ajoutBienRepo.Insert(abe);
        }

        // modifier un bien
        public bool UpdateBien(BienModel bm)
        {
            BienEntity be = new BienEntity
            {
                Titre = bm.Titre,
                DescCourte = bm.DescCourte,
                DescLong = bm.DescLong,
                Numero = bm.Numero,
                Rue = bm.Rue,
                CodePostal = bm.CodePostal,
                Ville = bm.Ville,
                Pays = bm.Pays,
                NombrePerson = bm.NombrePerson,
                NbrSBD = bm.NbrSBD,
                NbrWC = bm.NbrWC,
            };
            return _bienRepo.Update(be);
        }
        #endregion

        #region Zone Search
        // envoyer une liste d'option pour la zone de recherche et le formumaire
        public List<OptionModel> GetAllOption()
        {
            return _optionRepo.Get()
                .Select(om => new OptionModel()
                { 
                    IdOption = om.IdOption,
                    Libelle = om.Libelle,
                }).ToList();
        }
        #endregion
    }
}
