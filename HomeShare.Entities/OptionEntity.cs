using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Entities
{
    public class OptionEntity
    {
        #region Fields
        private int _idOption;
        private string _libelle;
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

        public string Libelle
        {
            get
            {
                return _libelle;
            }

            set
            {
                _libelle = value;
            }
        }
        #endregion
    }
}
