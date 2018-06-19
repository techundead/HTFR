using HeliosTransfert.Business.Dto;
using HeliosTransfert.Dal;
using System;
using System.Collections.Generic;


namespace HeliosTransfert.Business
{
    public class ClientServeurManager
    {
        public static void ajoutClientServeur(int cdClient, int cdServeur)
        {
            ClientServeurDal.InsertClientServeur(cdClient, cdServeur);
        }

        public static void modifClientServeur(int cdClient, int cdServeur)
        {
            ClientServeurDal.UpdateClientServeur(cdClient, cdServeur);
        }

        public static void suppClientServeur(int cdClient, int cdServeur)
        {
            ClientServeurDal.DeleteClientServeur(cdClient, cdServeur);
        }

        public static String getCdClient(int cdSrv)
        {
            return ClientServeurDal.getCdClient(cdSrv);
        }

        public static IList<ClientServeur> getClientServeur()
        {
            return ClientServeurDal.getClientServeurs();
        }

        public static IList<ClientServeur> getClientsServeur()
        {
            return ClientServeurDal.getClientsServeurs();
        }
    }
}
