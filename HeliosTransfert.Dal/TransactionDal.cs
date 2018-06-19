using HeliosTransfert.Business.Dto;
using Global.Oracle;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HeliosTransfert.Dal
{
    public class TransactionDal
    {

        public static Boolean InsertTransaction(int cdTransfert, String detail, String codeErreur, String etat, DateTime date)
        {
            OracleTrans o = OracleTrans.getInstance;

            int transac = o.DebutTransaction();
            Boolean res;
            try
            {
                int cd_transaction = getCdTransactionmax();
                res = o.ExecuterUpdate("INSERT INTO trft_transaction (CD_TRST, CD_TRFT, DETAIL, CODE_ERREUR, ETAT, DATE_TRANSACTION) VALUES (:1, :2, :3, :4, :5, :6)", transac, cd_transaction, cdTransfert, detail, codeErreur, etat, date).ErrCode == 0;

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

        public static int getCdTransactionmax()
        {
            OracleTrans o = OracleTrans.getInstance;
            String re = o.ExecuterSelectScalar("SELECT MAX(cd_trst) FROM trft_transaction", -1).Result.ToString();
            int cd_transaction;
            if (re == "")
            {
                cd_transaction = 1;
            }
            else
            {
                cd_transaction = Convert.ToInt32(o.ExecuterSelectScalar("SELECT MAX(cd_trst) FROM trft_transaction", -1).Result) + 1;
            }

            return cd_transaction;
        }

        public static String getDetail(int cdTRST)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT DETAIL FROM trft_transaction WHERE cd_trst = :1", -1, cdTRST).Result.ToString();
        }

        public static String getCodeErreur(int cdTRST)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT CODE_ERREUR FROM trft_transaction WHERE cd_trst = :1", -1, cdTRST).Result.ToString();
        }

        public static String getEtat(int cdTRST)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT ETAT FROM trft_transaction WHERE cd_trst = :1", -1, cdTRST).Result.ToString();
        }
        public static String getDate(int cdTRST)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelectScalar("SELECT DATE FROM trft_transaction WHERE cd_trst = :1", -1, cdTRST).Result.ToString();
        }


        public static IList<Transaction> getTransactions(int cdTRFT)
        {
            OracleTrans o = OracleTrans.getInstance;
            return o.ExecuterSelect<Transaction>("SELECT CD_TRST, CD_TRFT, DETAIL, CODE_ERREUR, ETAT, DATE_TRANSACTION FROM trft_transaction WHERE cd_trft = :1", -1, cdTRFT).Data;
        }

    }
}
