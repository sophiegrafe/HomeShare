using HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShare.infra
{
    public class SessionUtils
    {
        public static bool IsLogged
        {
            get
            {
                if (HttpContext.Current.Session["IsLogged"] == null)
                {
                    HttpContext.Current.Session["IsLogged"] = false;
                }
                return (bool)HttpContext.Current.Session["IsLogged"];
            }
            set
            {
                HttpContext.Current.Session["IsLogged"] = value;
            }
        }

        public static MembreModel ConnectedUser
        {
            get
            {
                return (MembreModel)HttpContext.Current.Session["ConnectedUser"];
            }

            set { HttpContext.Current.Session["ConnectedUser"] = value; }

        }

        public static int IdBienDetails
        {
            get
            {                
                return (int)HttpContext.Current.Session["IdBienDetails"];
            }
            set
            {
                HttpContext.Current.Session["IdBienDetails"] = value;
            }
        }
    }
}