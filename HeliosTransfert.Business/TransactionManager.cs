using HeliosTransfert.Business.Dto;
using HeliosTransfert.Dal;
using System;
using System.Collections.Generic;

namespace HeliosTransfert.Business
{
    public class TransactionManager
    {
        public static Boolean ajoutTransaction(int cdTransfert, String detail, String codeErreur, String etat, DateTime date)
        {
            return TransactionDal.InsertTransaction(cdTransfert, detail, codeErreur, etat, date);
        }

        public static int getcdTransactionmax()
        {
            return TransactionDal.getCdTransactionmax();
        }

        public static String getDetail(int cdTransaction)
        {
            return TransactionDal.getDetail(cdTransaction);
        }

        public static String getCodeErreur(int cdTransaction)
        {
            return TransactionDal.getCodeErreur(cdTransaction);
        }

        public static String getEtat(int cdTransaction)
        {
            return TransactionDal.getEtat(cdTransaction);
        }

        public static String getDate(int cdTransaction)
        {
            return TransactionDal.getDate(cdTransaction);
        }


        public static IList<Transaction> getTransactions(int cdTRFT)
        {
            return TransactionDal.getTransactions(cdTRFT);
        }

        public static String getMaxTransactTRFT(int cdTRFT)
        {
            return TransactionDal.getMaxTransactTRFT(cdTRFT);
        }

    }
}
