using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class MembreModel
    {
        #region Fields
        private int idMembre;
        private string _nom, _prenom, _email, _pays, _telephone, _login, _password, _passwordConfirmation;
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
        public string Pays
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
        [Required]
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
        [Required]
        [MaxLength(50)]
        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }
        [Required]
        [MaxLength(64)]
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
        [Required]
        [MaxLength(64)]
        [Compare("Password", ErrorMessage = "Les mots de passe entrés ne correspondent pas")]
        public string PasswordConfirmation
        {
            get
            {
                return _passwordConfirmation;
            }

            set
            {
                _passwordConfirmation = value;
            }
        }
        #endregion
    }

}
