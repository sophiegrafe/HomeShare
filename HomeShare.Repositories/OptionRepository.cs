using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class OptionRepository : BaseRepository<OptionEntity>, IConcreteRepository<OptionEntity>
    {
        public OptionRepository(string connectionString) : base(connectionString)
        {
        }

        public List<OptionEntity> Get()
        {
            string requete = "SELECT * FROM Options";
            return Get(requete);
        }

        public OptionEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(OptionEntity toInsert)
        {
            throw new NotImplementedException();
        }

        //adaptation de l'insert

        public bool Update(OptionEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(OptionEntity toDelete)
        {
            throw new NotImplementedException();
        }
    }
}
