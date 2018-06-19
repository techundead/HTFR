using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HeliosTransfert.Business;
using HeliosTransfert.Business.Dto;

namespace HeliosTransfert.Services
{
    public class ControlerServeur
    {
        ServeurHeliosTransfert ServeurHTRFT;
        Thread ProcessServeur;

        private static readonly object _lock = new object();
        private static ControlerServeur _instance;
        public static ControlerServeur Instance
        {
            get
            {
                    if (_instance == null)
                    _instance = new ControlerServeur();
                    
                return _instance;
            }
        }

        private ControlerServeur()
        {
            ServeurHTRFT = new ServeurHeliosTransfert();
            ProcessServeur = new Thread(ServeurHTRFT.DemarrerServeur);
        }
        public void Demarrer()
        { 
            ProcessServeur.Start();
        }

        public void Arreter()
        {
            ServeurHTRFT.ArreterServeur();
            ProcessServeur.Abort();
            _instance = null;
        }

        public List<Connexion> GetConnexions()
        {
            return ConnexionManager.Instance.GetConnexions();

        }
    }
}
