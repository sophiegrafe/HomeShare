using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class PaysModel
    {
        #region Fields

        private int _idPays;
        private string _nomPays;
        #endregion

        #region Properties

        public int IdPays
        {
            get
            {
                return _idPays;
            }

            set
            {
                _idPays = value;
            }
        }

        public string NomPays
        {
            get
            {
                return _nomPays;
            }

            set
            {
                _nomPays = value;
            }
        }
        #endregion
    }
}