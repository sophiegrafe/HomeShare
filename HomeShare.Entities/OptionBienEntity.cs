using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Entities
{
    public class OptionBienEntity
    {
        #region Fields
        private int _idOption, idBien;
        private bool _valeur;
        #endregion

        #region Properties
        public int IdOption
        {
            get
            {
                return _idOption;
            }

            set
            {
                _idOption = value;
            }
        }

        public int IdBien
        {
            get
            {
                return idBien;
            }

            set
            {
                idBien = value;
            }
        }

        public bool Valeur
        {
            get
            {
                return _valeur;
            }

            set
            {
                _valeur = value;
            }
        } 
        #endregion
    }
}
