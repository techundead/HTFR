using HeliosTransfert.Business.Dto;
using Global.Oracle;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HeliosTransfert.Dal
{
    public class TransfertDal
    {
        public static Boolean InsertTransfert(int cdFlux, int cdClient, String designation, String tailleFichier, String etat, String ipSource, DateTime date)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();
            Boolean res;
            try
            {
                int cd_transfert = getCdTransfertmax();
                res = o.ExecuterUpdate("INSERT INTO trft_transfert (CD_TRFT, CD_FLUX, CD_CLIENT, DESIGNATION, TAILLE_FICHIER, ETAT, IP_SOURCE, DATE_TRANSFERT) VALUES (:1, :2, :3, :4, :5, :6, :7, :8)", transac, cd_transfert, cdFlux, cdClient, designation, tailleFichier, etat, ipSource, date).ErrCode == 0;

                if (res)
                    o.Commit(transac);
                else
                    o.RollBack(transac);
            }
            catch (Exception ex)
            {
                o.RollBack(transac);
                res = false;
            }

            return res;
        }

        public static void UpdateTransfertEtat(int cdTransfert, String etat)
        {

            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("UPDATE trft_transfert SET ETAT = :2 WHERE CD_TRFT = :1 ", -1, cdTransfert, etat).ErrCode == 0;

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

        public static int getCdTransfertmax()
        {
            OracleTrans o = OracleTrans.getInstance;
            String re = o.ExecuterSelectScalar("SELECT MAX(CD_TRFT) FROM trft_transfert", -1).Result.ToString();
            int cd_transfert;
            if (re == "")
            {
                cd_transfert = 1;
            }
            else
            {
                cd_transfert = Convert.ToInt32(o.ExecuterSelectScalar("SELECT MAX(cd_trft) FROM trft_transfert", -1).Result) + 1;
            }

            return cd_transfert;
        }

        public static int getCdTransfert(int cdFlux, int cdClient, String etat)
        {
            OracleTrans o = OracleTrans.getInstance;
            return Convert.ToInt32(o.ExecuterSelectScalar("SELECT CD_TRFT FROM trft_transfert WHERE cd_flux= :1 AND cd_Client = :2 AND etat = :3", -1, cdFlux, cdClient, etat).Result.ToString());
        }

        public static String getDesignation(int cdTRFT)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT DESIGNATION FROM trft_transfert WHERE cd_trft = :1", -1, cdTRFT).Result.ToString();
        }

        public static String getTailleFichier(int cdTRFT)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT TAILLE_FICHIER FROM trft_transfert WHERE cd_trft = :1", -1, cdTRFT).Result.ToString();
        }

        public static String getEtat(int cdTRFT)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT ETAT FROM trft_transfert WHERE cd_trft = :1", -1, cdTRFT).Result.ToString();
        }


        public static String getIpSource(int cdTRFT)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT IP_SOURCE FROM trft_transfert WHERE cd_trft = :1", -1, cdTRFT).Result.ToString();
        }
        public static String getDate(int cdTRFT)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT DATE FROM trft_transfert WHERE cd_trft = :1", -1, cdTRFT).Result.ToString();
        }

        public static Transfert getTransfert(int cdTRFT)
        {
            OracleTrans o = OracleTrans.getInstance;
            var data = o.ExecuterSelect<Transfert>("SELECT CD_TRFT, CD_FLUX, CD_CLIENT, DESIGNATION, TAILLE_FICHIER, ETAT, IP_SOURCE, DATE FROM trft_transfert WHERE cd_trft = :1 ", -1, cdTRFT).Data;
            return data.FirstOrDefault();
        }

        public static IList<Transfert> getTransferts()
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<Transfert>("SELECT * FROM trft_transfert").Data;
        }

        public static IList<Transfert> getTransfertsEtat(String etat)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<Transfert>("SELECT * FROM trft_transfert WHERE Etat = :1", -1, etat).Data;
        }


    }
}
