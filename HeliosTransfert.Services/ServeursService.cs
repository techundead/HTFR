using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business.Dto;
using HeliosTransfert.Business;

namespace HeliosTransfert.Services
{
    public class ServeursService
    {

        public static void ajoutServeur(String adresseIp, String ftpIdtf, String ftpMdp, String ftpPort, String trftPort, int cd_client_srv)
        {

            ServeurManager.ajoutServeur(adresseIp, ftpIdtf, ftpMdp, ftpPort, trftPort, cd_client_srv);
        }

        public static void modifServeur(int cdServeur, String adresseIp, String ftpIdtf, String ftpMdp, String ftpPort, String trftPort, int cd_client_srv)
        {

            ServeurManager.modifServeur(cdServeur, adresseIp, ftpIdtf, ftpMdp, ftpPort, trftPort, cd_client_srv);
        }

        public static void suppServeur(int cdServeur)
        {

            ServeurManager.suppServeur(cdServeur);
        }

        public static String getAdresseIp(int cdServeur)
        {
            return ServeurManager.getAdresseIp(cdServeur);
        }

        public static String getFtpIdtf(int cdServeur)
        {
            return ServeurManager.getFtpIdtf(cdServeur);
        }

        public static String getFtpMdp(int cdServeur)
        {
            return ServeurManager.getFtpMdp(cdServeur);
        }

        public static String getFtpPort(int cdServeur)
        {
            return ServeurManager.getFtpPort(cdServeur);
        }

        public static String getTrftPort(int cdServeur)
        {
            return ServeurManager.getTrftPort(cdServeur);
        }

        public static int getcdServeurmax()
        {
            return ServeurManager.getcdServeurmax();
        }

        public static int getnbreServeur()
        {
            return ServeurManager.getnbreServeur();
        }

        //Retourne un serveur
        public static Serveur getServeur(int cdServeur)
        {
            return ServeurManager.getServeur(cdServeur);
        }

        //Retourne tout les serveurs
        public static IList<Serveur> getServeurs()
        {
            return ServeurManager.getServeurs();
        }

        public static String getCdClient(int cdSrv)
        {
            return ServeurManager.getCdClient(cdSrv);
        }
    }
}
