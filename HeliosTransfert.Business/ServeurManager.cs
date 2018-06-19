using HeliosTransfert.Business.Dto;
using HeliosTransfert.Dal;
using System;
using System.Collections.Generic;


namespace HeliosTransfert.Business
{
    public class ServeurManager
    {
        public static void ajoutServeur(String adresseIp, String ftpIdtf, String ftpMdp, String ftpPort, String trftPort, int cd_client_srv)
        {
            ServeurDal.InsertServeur(adresseIp, ftpIdtf, ftpMdp, ftpPort, trftPort, cd_client_srv);
        }

        public static void modifServeur(int cdServeur, String adresseIp, String ftpIdtf, String ftpMdp, String ftpPort, String trftPort, int cd_client_srv)
        {
            ServeurDal.UpdateServeur(cdServeur, adresseIp, ftpIdtf, ftpMdp, ftpPort, trftPort, cd_client_srv);
        }

        public static void suppServeur(int cdServeur)
        {
            ServeurDal.DeleteServeur(cdServeur);
        }

        public static int getcdServeurmax()
        {
            return ServeurDal.getCdServeurmax();
        }

        public static int getnbreServeur()
        {
            return ServeurDal.getnbreServeur();
        }

            public static String getAdresseIp(int cdServeur)
        {
            return ServeurDal.getAdresseIp(cdServeur);
        }

        public static String getFtpIdtf(int cdServeur)
        {
            return ServeurDal.getFtpIdtf(cdServeur);
        }

        public static String getFtpMdp(int cdServeur)
        {
            return ServeurDal.getFtpMdp(cdServeur);
        }

        public static String getFtpPort(int cdServeur)
        {
            return ServeurDal.getFtpPort(cdServeur);
        }

        public static String getTrftPort(int cdServeur)
        {
            return ServeurDal.getTrftPort(cdServeur);
        }

        public static Serveur getServeur(int cdServeur)
        {
            return ServeurDal.getServeur(cdServeur);
        }

        public static IList<Serveur> getServeurs()
        {
            return ServeurDal.getServeurs();
        }

        public static String getCdClient(int cdSrv)
        {
            return ServeurDal.getCdClient(cdSrv);
        }

    }
}
