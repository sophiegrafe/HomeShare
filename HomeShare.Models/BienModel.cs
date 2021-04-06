using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class BienModel
    {
        #region Fields
        private int _idBien, _idMembre, _nombrePerson, _nbrSBD, _nbrWC, _pays;
        private string _titre, _descCourte, _descLong, _ville, _rue, _numero, _codePostal, _photo, _latitude, _longitude;
        private bool _assuranceObligatoire, _isEnabled;
        private DateTime? _disabledDate;
        private DateTime _dateCreation;
        #endregion

        #region Properties
        public int IdBien
        {
            get
            {
                return _idBien;
            }

            set
            {
                _idBien = value;
            }
        }

        public int IdMembre
        {
            get
            {
                return _idMembre;
            }

            set
            {
                _idMembre = value;
            }
        }

        [Required]        
        public int NombrePerson
        {
            get
            {
                return _nombrePerson;
            }

            set
            {
                _nombrePerson = value;
            }
        }

        [Required]        
        public int NbrSBD
        {
            get
            {
                return _nbrSBD;
            }

            set
            {
                _nbrSBD = value;
            }
        }

        [Required]
        public int NbrWC
        {
            get
            {
                return _nbrWC;
            }

            set
            {
                _nbrWC = value;
            }
        }

        [Required]
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

        [Required]
        [MaxLength(50)]
        public string Titre
        {
            get
            {
                return _titre;
            }

            set
            {
                _titre = value;
            }
        }

        [Required]
        [MaxLength(150)]
        public string DescCourte
        {
            get
            {
                return _descCourte;
            }

            set
            {
                _descCourte = value;
            }
        }

        [Required]
        [MaxLength(1000)]
        public string DescLong
        {
            get
            {
                return _descLong;
            }

            set
            {
                _descLong = value;
            }
        }

        [Required]
        [MaxLength(50)]
        public string Ville
        {
            get
            {
                return _ville;
            }

            set
            {
                _ville = value;
            }
        }

        [Required]
        [MaxLength(50)]
        public string Rue
        {
            get
            {
                return _rue;
            }

            set
            {
                _rue = value;
            }
        }

        [Required]
        [MaxLength(5)]
        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        [Required]
        [MaxLength(50)]
        public string CodePostal
        {
            get
            {
                return _codePostal;
            }

            set
            {
                _codePostal = value;
            }
        }

        [Required]
        [MaxLength(50)]
        public string Photo
        {
            get
            {
                return _photo;
            }

            set
            {
                _photo = value;
            }
        }


        public bool AssuranceObligatoire
        {
            get
            {
                return _assuranceObligatoire;
            }

            set
            {
                _assuranceObligatoire = value;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }

            set
            {
                _isEnabled = value;
            }
        }

        public DateTime? DisabledDate
        {
            get
            {
                return _disabledDate;
            }

            set
            {
                _disabledDate = value;
            }
        }

        public DateTime DateCreation
        {
            get
            {
                return _dateCreation;
            }

            set
            {
                _dateCreation = value;
            }
        }

        public string Latitude
        {
            get
            {
                return _latitude;
            }

            set
            {
                _latitude = value;
            }
        }

        public string Longitude
        {
            get
            {
                return _longitude;
            }

            set
            {
                _longitude = value;
            }
        }
        #endregion
    }
}
