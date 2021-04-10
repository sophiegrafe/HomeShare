using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Entities
{
    public class AjoutBienEntity
    {
        #region Fields
        private int _idBien, _idMembre, _nombrePerson, _nbrSBD, _nbrWC, _pays;
        private string _titre, _descCourte, _descLong, _ville, _rue, _numero, _codePostal, _photo, _latitude, _longitude;
        private bool _assuranceObligatoire, _isEnabled;
        private DateTime? _disabledDate;
        

        //private string optionsString;

        private List<OptionEntity> _listeOption;
        //private List<OptionBienEntity> _listeOptionBien;

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



        //public List<OptionBienEntity> ListeOptionBien
        //{
        //    get
        //    {
        //        return _listeOptionBien;
        //    }

        //    set
        //    {
        //        _listeOptionBien = value;
        //    }
        //}

        public List<OptionEntity> ListeOption
        {
            get
            {
                return _listeOption;
            }

            set
            {
                _listeOption = value;
            }
        }

        //public string OptionsString
        //{
        //    get
        //    {
        //        return optionsString;
        //    }

        //    set
        //    {
        //        optionsString = value;
        //    }
        //}
        #endregion
        #endregion
    }
}
