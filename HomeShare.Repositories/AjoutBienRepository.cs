using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    class AjoutBienRepository : BaseRepository<AjoutBienEntity>, IConcreteRepository<AjoutBienEntity>
    {
        public AjoutBienRepository(string connectionString) : base(connectionString)
        {
        }
        

        public List<AjoutBienEntity> Get()
        {
            throw new NotImplementedException();
        }

        public AjoutBienEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AjoutBienEntity toInsert)
        {   
            
            string requete = @"EXEC [dbo].[sp_Bien_Insert] 
             @titre
            ,@descCourte
            ,@descLong
            ,@numero
            ,@rue
            ,@codePostal
            ,@ville
            ,@pays
            ,@nombrePerson
            ,@nbrSBD
            ,@nbrWC
            ,@idMembre
            ,@latitude
            ,@longitude
            ,@photo";
            // ajouter le traitement des options ici mais pour l'instant c'est le casse tete 

            return Insert(toInsert, requete);
        }

        public bool Update(AjoutBienEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AjoutBienEntity toDelete)
        {
            throw new NotImplementedException();
        }

    }
}
