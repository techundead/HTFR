using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business.Dto;
using HeliosTransfert.Business;

namespace HeliosTransfert.Services
{
    public class TransfertsService
    {
        //Retourne un transfert
        public static Transfert getTransfert(int cdTransfert)
        {
            return TransfertManager.getTransfert(cdTransfert);
        }

        //Retourne tout les transferts
        public static IList<Transfert> getTransferts()
        {
            return TransfertManager.getTransferts();
        }

        public static IList<Transfert> getTransfertsEtat(String etat)
        {
            return TransfertManager.getTransfertsEtat(etat);
        }

    }
}
