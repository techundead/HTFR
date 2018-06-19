using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business;
using HeliosTransfert.Business.Dto;

namespace HeliosTransfert.Services
{
    public class ClientServeurService
    {

        public static void ajoutClientServeur(int cdClient, int cdServeur)
        {
            ClientServeurManager.ajoutClientServeur(cdClient, cdServeur);
        }

        public static void modifClientServeur(int cdClient, int cdServeur)
        {
            ClientServeurManager.modifClientServeur(cdClient, cdServeur);
        }

        public static void suppClientServeur(int cdClient, int cdServeur)
        {
            ClientServeurManager.suppClientServeur(cdClient, cdServeur);
        }

        public static String getCdClient(int cdSrv)
        {
            return ClientServeurManager.getCdClient(cdSrv);
        }

        public static IList<ClientServeur> getClientServeur()
        {
            return ClientServeurManager.getClientServeur();
        }

        public static IList<ClientServeur> getClientsServeur()
        {
            return ClientServeurManager.getClientsServeur();
        }


    }
}
