using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomeShare.Models
{
    public class AjouterBienViewModel
    {
        #region Fields

        private BienModel _newBien;
        private List<PaysModel> _listePays;
        #endregion

        #region Ctor

        private UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        public AjouterBienViewModel()
        {
            
            ListePays = uow.GetAllPays();
        }
        #endregion

        #region Properties

        public BienModel NewBien
        {
            get
            {
                return _newBien;
            }

            set
            {
                _newBien = value;
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
        #endregion
    }
}