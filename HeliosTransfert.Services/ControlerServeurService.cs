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
    public class ControlerServeurService
    {
        public static void demarrerServeur()
        {
             ControlerServeur.Instance.Demarrer();
        }

        public static void arreterServeur()
        {
            ControlerServeur.Instance.Arreter();
        }

        public List<Connexion> GetConnexions()
        {
            return ConnexionManager.Instance.GetConnexions();

        }
    }
}
