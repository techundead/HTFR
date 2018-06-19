using HeliosTransfert.Business.Dto;
//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HeliosTransfert.Business
{


    public class ConnexionManager
    {
        private static readonly object _lock = new object();

        private List<Connexion> _connexionList;

        private static ConnexionManager _instance;
        public static ConnexionManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new ConnexionManager();
                }
                return _instance;
            }
        }

        private ConnexionManager()
        {
            _connexionList = new List<Connexion>();
        }

        public void AddConnexion(Connexion c)
        {
            _connexionList.Add(c);
        }

        public void DelConnexion(Connexion c)
        {
            _connexionList.Remove(c);
        }

        public void ResetConnexion()
        {
            _connexionList.Clear();
        }

        public Boolean VerificationConnexion(Connexion c)
        {
            foreach (Connexion connexion in _connexionList)
            {
                if( connexion.Ip == c.Ip)
                {
                    return false;
                }
            }

            return true;
        }

        public List<Connexion> GetConnexions(/* param */ )
        {
            return _connexionList;
        }


    }
}