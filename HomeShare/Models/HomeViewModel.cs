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

        private List<BienModel> _last5Biens;
        private List<PaysModel> _listePays;
        private List<OptionModel> _listeOption;

        #endregion

        #region Ctor
        private UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        public HomeViewModel()
        {
            Last5Biens = uow.GetLast5ForCtrl();
            ListePays = uow.GetAllPays();
            ListeOption = uow.GetAllOption();
        }
        #endregion

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

        public List<PaysModel> ListePays
        {
            get
            {
                return _listePays;
            }

            set
            {
                _listePays = value;
            }
        }

        public List<OptionModel> ListeOption
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
        #endregion
    }
}