using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert;

namespace HeliosTransfert.Business
{
    public class DemandeTransfert
    {
        public static Boolean autorisationTransfert(int cdFlux, int cdClient, String designation, String tailleFichier, String etat, String ipSource, DateTime date)
        {
            if(TransfertManager.ajoutTransfert(cdFlux, cdClient, designation, tailleFichier, etat, ipSource, date) == true)
            {
               int cdTrft = TransfertManager.getCdTransfert(cdFlux, cdClient, etat);
                return TransactionManager.ajoutTransaction(cdTrft, "Démarrage du transfert", null, "OK", date);

            }else
            {
                return false;
            }

        }


    }
}
