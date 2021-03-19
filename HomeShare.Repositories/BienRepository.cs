using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class BienRepository : BaseRepository<BienEntity>, IConcreteRepository<BienEntity>
    {
        public BienRepository(string connectionString) : base(connectionString)
        {
        }        

        public List<BienEntity> Get()
        {
            string requete = "SELECT * FROM BienEchange ORDER BY DateCreation DESC";
            return base.Get(requete);
        }

        public List<BienEntity> GetLast5()
        {
            string requete = "SELECT * FROM Vue_CinqDernierBiens";
            return base.Get(requete);
        }

        public BienEntity GetOne(int PK)
        {
            string requete = "SELECT * FROM BienEchange WHERE IdBien = @id";

            return base.GetOne(PK, requete);
        }

        public bool Insert(BienEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BienEntity toDelete)
        {
            throw new NotImplementedException();
        }
    }
}
