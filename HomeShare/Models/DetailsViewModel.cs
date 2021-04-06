using HomeShare.infra;
using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomeShare.Models
{
    public class DetailsViewModel
    {
        
        #region Field
        private UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        private BienModel _detailsBien;

        #endregion
        public DetailsViewModel()
        {

            DetailsBien = uow.GetBienDetails();

        }

        #region Properties
        public BienModel DetailsBien
        {
            get
            {
                return _detailsBien;
            }

            set
            {
                _detailsBien = value;
            }
        }
        #endregion

    }
}