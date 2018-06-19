using HeliosTransfert.Business.Dto;
using HeliosTransfert.Dal;
using System;
using System.Collections.Generic;



namespace HeliosTransfert.Business
{
    public class ClientManager
    {

        public static void ajoutClient(String raisonSocial, String adressePostale, String codePostal, String ville, String pays)
        {
             ClientDal.InsertClient(raisonSocial, adressePostale, codePostal, ville, pays);
        }

        public static void modifClient(int cdClient, String raisonSocial, String adressePostale, String codePostal, String ville, String pays)
        {
            ClientDal.UpdateClient(cdClient, raisonSocial, adressePostale, codePostal, ville, pays);
        }

        public static void suppClient(int cdClient)
        {
            ClientDal.DeleteClient(cdClient);
        }

        public static int getcdClientmax()
        {
            return ClientDal.getCdClientmax();
        }
        
        public static String getRaisonSocial(int cdClient)
        {
            return ClientDal.getRaisonSocial(cdClient);
        }

        public static String getAdressePostale(int cdClient)
        {
            return ClientDal.getAdressePostale(cdClient);
        }

        public static String getCodepostal(int cdClient)
        {
            return ClientDal.getCodepostal(cdClient);
        }

        public static String getVille(int cdClient)
        {
            return ClientDal.getVille(cdClient);
        }
    
        public static String getPays(int cdClient)
        {
            return ClientDal.getPays(cdClient);
        }

        public static Client getClient(int cdClient)
        {
            return ClientDal.getClient(cdClient);
        }

        public static IList<Client> getClients()
        {
            return ClientDal.getClients();
        }
    }
}
