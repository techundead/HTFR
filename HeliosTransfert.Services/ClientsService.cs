using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business.Dto;
using HeliosTransfert.Business;

namespace HeliosTransfert.Services
{
    public class ClientsService
    {
        public static void ajoutClient(String raisonSocial, String adressePostale, String codePostal, String ville, String pays)
        {

            ClientManager.ajoutClient(raisonSocial, adressePostale, codePostal, ville, pays);
        }

        public static void modifClient(int cdClient, String raisonSocial, String adressePostale, String codePostal, String ville, String pays)
        {

            ClientManager.modifClient(cdClient, raisonSocial, adressePostale, codePostal, ville, pays);
        }

        public static void suppClient(int cdClient)
        {

            ClientManager.suppClient(cdClient);
        }

        public static int getcdClientmax()
        {
           return ClientManager.getcdClientmax();
        }
        
        //Retourne un client
        public static Client getClient(int cdClient)
        {
            return ClientManager.getClient(cdClient);
        }

        //Retourne tout les clients
        public static IList<Client> getClients()
        {
            return ClientManager.getClients();
        }


    }
}
