using HeliosTransfert.Business.Dto;
using Global.Oracle;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HeliosTransfert.Dal
{
    public class ClientServeurDal
    {

        //Ajoute un client au serveur
        public static void InsertClientServeur(int cdClient, int cdServeur)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {

                bool res = o.ExecuterUpdate("INSERT INTO trft_client_serveur (CD_CLIENT, CD_SRV) VALUES (:1, :2)", transac, cdClient, cdServeur).ErrCode == 0;

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

        public static void UpdateClientServeur(int cdClient, int cdServeur)
        {

            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("UPDATE trft_client_serveur SET CD_CLIENT = :2, CD_SRV = :1 WHERE CD_SRV = :1", -1, cdServeur, cdClient).ErrCode == 0;

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

        public static void DeleteClientServeur(int cdServeur, int cdClient)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("DELETE FROM trft_client_serveur WHERE cd_srv = :1 AND cd_client = :2", transac, cdServeur, cdClient).ErrCode == 0;

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


        public static String getCdClient(int cdSrv)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT CD_CLIENT FROM trft_client_serveur WHERE cd_srv = :1", -1, cdSrv).Result.ToString();
        }


        public static IList<ClientServeur> getClientServeurs()
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<ClientServeur>("SELECT CD_SRV, CD_CLIENT FROM trft_client_serveur").Data;
        }

        public static IList<ClientServeur> getClientsServeurs()
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<ClientServeur>("SELECT TRFT_CLIENT_SERVEUR.CD_CLIENT, TRFT_SERVEURS.CD_SRV, TRFT_SERVEURS.ADRESSE_IP, TRFT_SERVEURS.FTP_IDENTIFIANT, TRFT_SERVEURS.FTP_MDP, TRFT_SERVEURS.FTP_PORT, TRFT_SERVEURS.TRFT_PORT FROM TRFT_CLIENT_SERVEUR, TRFT_SERVEURS WHERE TRFT_CLIENT_SERVEUR.CD_SRV = TRFT_SERVEURS.CD_SRV").Data;
        }

    }
}
