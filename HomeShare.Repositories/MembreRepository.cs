using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class MembreRepository : BaseRepository<MembreEntity>, IConcreteRepository<MembreEntity>
    {
        #region Ctor
        public MembreRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Delete(MembreEntity toDelete)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Methodes
        public List<MembreEntity> Get()
        {
            throw new NotImplementedException();
        }

        public MembreEntity GetFromLogin(string login, string password)
        {
            string requete = @"EXEC [dbo].[sp_Verification_Login] 
                                                        @login,
                                                        @password";
            Dictionary<string, object> parametre = new Dictionary<string, object>();
            parametre.Add("login", login);
            parametre.Add("password", password);

            return base.Get(requete, parametre).FirstOrDefault();
        }

        public MembreEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MembreEntity toInsert)
        {
            string requete = @"EXEC [dbo].[sp_Membre_Insert] 
            @login
            ,@password
            ,@nom
            ,@prenom
            ,@email
            ,@telephone
            ,@pays";

            return base.Insert(toInsert, requete);
        }

        public bool Update(MembreEntity toUpdate)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
