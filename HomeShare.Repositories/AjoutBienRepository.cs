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

            return Insert(requete, toInsert);

            // version avec utilisation d'un dico pour envoyer les options + le bien dans ps insert bien
            // ça ne passe pas vers la ps après le passage (sans erreur) dans BaseRepo 
            // --> Message d'erreur : -- erreur de syntaxe proche de 'int', '@tittre' scalar fnction doit être déclaré --???????

            /*  //,@tVPOption";

                //si TVPOfOption dispo alors je commente ceci
                //générer autant de @param pour la requete qu'il y a d'option cochées 
                foreach (OptionEntity option in toInsert.ListeOption)
                {
                    string libelle = option.Libelle;
                    string libellePrDB = libelle.Replace(" ", "_");
                    requete += $",@{libellePrDB}";
                }

                //créer un dicotionnaire pour récupérer ttes les données sous forme de clés-valeur 
                Dictionary<string, object> parametre = new Dictionary<string, object>();

                //insérer les options et leur id dans le dico
                foreach (OptionEntity option in toInsert.ListeOption)
                {
                    parametre.Add(option.Libelle, option.IdOption);
                }

                // si TVPOfOption dispo alors je commente ceci:
                //injecter l'objet toInsert dans le dico
                parametre.Add("titre", toInsert.Titre);
                parametre.Add("descCourte", toInsert.DescCourte);
                parametre.Add("descLong", toInsert.DescLong);
                parametre.Add("numero", toInsert.Numero);
                parametre.Add("rue", toInsert.Rue);
                parametre.Add("codePostal", toInsert.CodePostal);
                parametre.Add("ville", toInsert.Ville);
                parametre.Add("pays", toInsert.Pays);
                parametre.Add("nombrePerson", toInsert.NombrePerson);
                parametre.Add("nbrSBD", toInsert.NbrSBD);
                parametre.Add("nbrWC", toInsert.NbrWC);
                parametre.Add("idMembre", toInsert.IdMembre);
                parametre.Add("latitude", toInsert.Latitude);
                parametre.Add("longitude", toInsert.Longitude);
                parametre.Add("photo", toInsert.Photo);

                // si TVPOfOption
                return Insert(requete, parametre); //, toInsert
                //return Insert(requete, parametre);  */

        }
    }
}
