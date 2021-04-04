using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomeShare.Models
{
    public class HomeViewModel
    {
        #region Field
        private UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        private List<BienModel> _last5Biens;

        #endregion
        public HomeViewModel()
        {

            Last5Biens = uow.GetLast5ForCtrl();

        }

        #region Properties

        public List<BienModel> Last5Biens
        {
            get
            {
                return _last5Biens;
            }

            set
            {
                _last5Biens = value;
            }
        }
        #endregion
    }
}