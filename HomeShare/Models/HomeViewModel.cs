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

        private List<BienModel> _listTopBien;

        #endregion
        public HomeViewModel()
        {

            ListTopBien = uow.GetAllBien();

        }

        #region Properties

        public List<BienModel> ListTopBien
        {
            get
            {
                return _listTopBien;
            }

            set
            {
                _listTopBien = value;
            }
        }
        #endregion
    }
}