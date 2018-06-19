using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business.Dto;
using HeliosTransfert.Business;

namespace HeliosTransfert.Services
{
    public class TransactionsService
    {


        //Retourne tout les transactions
        public static IList<Transaction> getTransactions(int cdTRFT)
        {
            return TransactionManager.getTransactions(cdTRFT);
        }

    }
}
