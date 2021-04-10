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

        public bool Update(AjoutBienEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AjoutBienEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AjoutBienEntity abe)
        {
            string requete = $@"EXEC [dbo].[sp_Bien_Insert] 
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

            foreach (OptionEntity option in abe.ListeOption)
            {
                requete += $",@{option.Libelle.Trim()}";
            }

            Dictionary<string, object> parametre = new Dictionary<string, object>();
            foreach (OptionEntity option in abe.ListeOption)
            {
                parametre.Add(option.Libelle, option.IdOption);
            }
            //mapping abe --> dico
            parametre.Add("titre", abe.Titre);
            parametre.Add("descCourte", abe.DescCourte);
            parametre.Add("descLong", abe.DescLong);
            parametre.Add("numero", abe.Numero);
            parametre.Add("rue", abe.Rue);
            parametre.Add("codePostal", abe.CodePostal);
            parametre.Add("ville", abe.Ville);
            parametre.Add("pays", abe.Pays);
            parametre.Add("nombrePerson", abe.NombrePerson);
            parametre.Add("nbrSBD", abe.NbrSBD);
            parametre.Add("nbrWC", abe.NbrWC);
            parametre.Add("idMembre", abe.IdMembre);
            parametre.Add("latitude", abe.Latitude);
            parametre.Add("longitude", abe.Longitude);
            parametre.Add("photo", abe.Photo);


            return Insert(requete, parametre);
            
        }
    }
}
