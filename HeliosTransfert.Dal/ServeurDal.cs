using HeliosTransfert.Business.Dto;
using Global.Oracle;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HeliosTransfert.Dal
{
    public class ServeurDal
    {

        public static void InsertServeur(String adresseIp, String ftpIdtf, String ftpMdp, String ftpPort, String trftPort, int cd_client_srv)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                int cd_serveur = getCdServeurmax();
                bool res = o.ExecuterUpdate("INSERT INTO trft_serveurs (CD_SRV,  ADRESSE_IP, FTP_IDENTIFIANT, FTP_MDP, FTP_PORT, TRFT_PORT, CD_CLIENT_SRV) VALUES (:1, :2, :3, :4, :5, :6, :7)", transac, cd_serveur, adresseIp, ftpIdtf, ftpMdp, ftpPort, trftPort,cd_client_srv).ErrCode == 0;

                if (res)
                    o.Commit(transac);
                else
                    o.RollBack(transac);
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }


        }

        public static void UpdateServeur(int cdServeur, String adresseIp, String ftpIdtf, String ftpMdp, String ftpPort, String trftPort, int cd_client_srv)
        {

            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("UPDATE trft_serveurs SET ADRESSE_IP = :2, FTP_IDENTIFIANT = :3, FTP_MDP = :4, FTP_PORT = :5, TRFT_PORT = :6, CD_CLIENT_SRV = :7 WHERE CD_SRV = :1 ", -1, cdServeur, adresseIp, ftpIdtf, ftpMdp, ftpPort, trftPort, cd_client_srv).ErrCode == 0;

                if (res)
                    o.Commit(transac);
                else
                    o.RollBack(transac);
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }

        }

        public static void DeleteServeur(int cdServeur)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("DELETE FROM trft_serveurs WHERE cd_srv = :1", transac, cdServeur).ErrCode == 0;

                if (res)
                    o.Commit(transac);
                else
                    o.RollBack(transac);
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }


        }


        public static int getCdServeurmax()
        {
            OracleTrans o = OracleTrans.getInstance;
            String re = o.ExecuterSelectScalar("SELECT MAX(cd_srv) FROM trft_serveurs", -1).Result.ToString();
            int cd_serveur;
            if (re == "")
            {
                cd_serveur = 1;
            }
            else
            {
                cd_serveur = Convert.ToInt32(o.ExecuterSelectScalar("SELECT MAX(cd_srv) FROM trft_serveurs", -1).Result) + 1;
            }

            return cd_serveur;
        }

        public static int getnbreServeur()
        {
            OracleTrans o = OracleTrans.getInstance;
            String re = o.ExecuterSelectScalar("SELECT COUNT(cd_srv) FROM trft_serveurs", -1).Result.ToString();

            return Convert.ToInt32(re);
        }


        public static String getAdresseIp(int cdSrv)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT ADRESSE_IP FROM trft_serveurs WHERE cd_srv = :1", -1, cdSrv).Result.ToString();
        }

        public static String getFtpIdtf(int cdSrv)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT FTP_IDENTIFIANT FROM trft_serveurs WHERE cd_srv = :1", -1, cdSrv).Result.ToString();
        }

        public static String getFtpMdp(int cdSrv)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT FTP_MDP FROM trft_serveurs WHERE cd_srv = :1", -1, cdSrv).Result.ToString();
        }

        public static String getFtpPort(int cdSrv)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT FTP_PORT FROM trft_serveurs WHERE cd_srv = :1", -1, cdSrv).Result.ToString();
        }

        public static String getTrftPort(int cdSrv)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT TRFT_PORT FROM trft_serveurs WHERE cd_srv = :1", -1, cdSrv).Result.ToString();
        }

        public static Serveur getServeur(int cdSrv)
        {
            OracleTrans o = OracleTrans.getInstance;
            var data = o.ExecuterSelect<Serveur>("SELECT CD_SRV, CD_CLIENT_SRV, ADRESSE_IP, FTP_IDENTIFIANT, FTP_MDP, FTP_PORT, TRFT_PORT FROM trft_serveurs WHERE cd_srv = :1 ", -1, cdSrv).Data;
            return data.FirstOrDefault(); 
        }

        public static IList<Serveur> getServeurs()
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<Serveur>("SELECT CD_SRV, CD_CLIENT_SRV, ADRESSE_IP, FTP_IDENTIFIANT, FTP_MDP, FTP_PORT, TRFT_PORT FROM trft_serveurs").Data;
        }

        public static String getCdClient(int cdSrv)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT CD_CLIENT_SRV FROM trft_serveurs WHERE cd_srv = :1", -1, cdSrv).Result.ToString();
        }

    }
}
