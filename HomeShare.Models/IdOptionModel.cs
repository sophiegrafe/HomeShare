using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class IdOptionModel
    {
        #region Field
        private int _idOption;
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
        #endregion
    }
}
