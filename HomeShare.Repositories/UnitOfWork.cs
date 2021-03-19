using HomeShare.Entities;
using HomeShare.Models;
using HomeShare.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
