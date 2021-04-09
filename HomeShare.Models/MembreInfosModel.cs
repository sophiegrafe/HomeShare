using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class MembreInfosModel
    {
        #region Fields
        private int idMembre, _pays;
        private string _nom, _prenom, _email, _telephone;
        #endregion

        #region Properties

        public int IdMembre
        {
            get
            {
                return idMembre;
            }

            set
            {
                idMembre = value;
            }
        }
        
        [MaxLength(50)]
        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }
        
        [MaxLength(50)]
        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }
        
        [MaxLength(256)]
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }
        
        public int Pays
        {
            get
            {
                return _pays;
            }

            set
            {
                _pays = value;
            }
        }
        
        [MaxLength(20)]
        public string Telephone
        {
            get
            {
                return _telephone;
            }

            set
            {
                _telephone = value;
            }
        }
        
        #endregion
    }
}
