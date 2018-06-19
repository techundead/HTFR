using HeliosTransfert.Business.Dto;
using Global.Oracle;
using System;
using System.Linq;
using System.Collections.Generic;



namespace HeliosTransfert.Dal
{
   public class ClientDal
    {

        public static void InsertClient(String raisonSocial, String adressePostale, String codePostal, String ville, String pays)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                int cd_client = getCdClientmax();
                bool res = o.ExecuterUpdate("INSERT INTO trft_client (CD_CLIENT, RAISON_SOCIAL, ADRESSE_POSTALE, CODE_POSTAL, VILLE, PAYS) VALUES (:1, :2, :3, :4, :5, :6)", transac, cd_client, raisonSocial, adressePostale, codePostal, ville, pays).ErrCode == 0;

                if (res)
                    o.Commit(transac);
                else
                    o.RollBack(transac);
            } catch (Exception ex)
            {
                o.RollBack(transac);
                throw ex;
            }
                      

        }

        public static void UpdateClient(int cdClient, String raisonSocial, String adressePostale, String codePostal, String ville, String pays)
        {

            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("UPDATE trft_client SET RAISON_SOCIAL = :2, ADRESSE_POSTALE = :3, CODE_POSTAL = :4, VILLE = :5, PAYS = :6 WHERE CD_CLIENT = :1 ", -1, cdClient, raisonSocial, adressePostale, codePostal, ville, pays).ErrCode == 0;

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

        public static void DeleteClient(int cd_client)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();

            try
            {
                bool res = o.ExecuterUpdate("DELETE FROM trft_client WHERE cd_client = :1", transac, cd_client).ErrCode == 0;

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


        public static int getCdClientmax()
        {
            OracleTrans o = OracleTrans.getInstance;
            String re = o.ExecuterSelectScalar("SELECT MAX(cd_client) FROM trft_client", -1).Result.ToString();
            int cd_client;
            if (re=="")
            {
                cd_client = 1;
            }
            else
            {
                cd_client = Convert.ToInt32(o.ExecuterSelectScalar("SELECT MAX(cd_client) FROM trft_client", -1).Result) + 1;
            }

            return cd_client;
        }


        public static String getRaisonSocial(int cdClient)
        {
           OracleTrans o = OracleTrans.getInstance;
           return  o.ExecuterSelectScalar("SELECT RAISON_SOCIAL FROM trft_client WHERE cd_client = :1", -1, cdClient).Result.ToString();
        }

        public static String getAdressePostale(int cdClient)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT ADRESSE_POSTALE FROM trft_client WHERE cd_client = :1", -1, cdClient).Result.ToString();
        }

        public static String getCodepostal(int cdClient)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT CODE_POSTAL FROM trft_client WHERE cd_client = :1", -1, cdClient).Result.ToString();
        }


        public static String getVille(int cdClient)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT VILLE FROM trft_client WHERE cd_client = :1", -1, cdClient).Result.ToString();
        }
        public static String getPays(int cdClient)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT PAYS FROM trft_client WHERE cd_client = :1", -1, cdClient).Result.ToString();
        }

        public static Client getClient(int cdClient)
        {
            OracleTrans o = OracleTrans.getInstance;
            var data = o.ExecuterSelect<Client>("SELECT RAISON_SOCIAL, ADRESSE_POSTALE, CODE_POSTAL, VILLE, PAYS FROM TRFT_CLIENT WHERE cd_client = :1 ", -1, cdClient).Data;
            return data.FirstOrDefault();
        }

        public static IList<Client> getClients()
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<Client>("SELECT CD_CLIENT, RAISON_SOCIAL, ADRESSE_POSTALE, CODE_POSTAL, VILLE, PAYS FROM TRFT_CLIENT").Data;
        }


    }
}
