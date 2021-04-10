using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class PaysRepository : BaseRepository<PaysEntity>, IConcreteRepository<PaysEntity>
    {
        #region Ctor
        public PaysRepository(string connectionString) : base(connectionString)
        {
        } 
        #endregion

        #region Methodes
        public List<PaysEntity> Get()
        {
            string requete = "SELECT * FROM Pays";
            return Get(requete);
        }

        public PaysEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PaysEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(PaysEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PaysEntity toDelete)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
