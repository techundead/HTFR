using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliosTransfert.Business
{
    class ErreurTransfert
    {
        public static Boolean ErreurTRFT(int cdServeur, int cdFlux, int cdClient, String designationFichier, String tailleFichier, DateTime date)
        {
            //Récupération des info du transfert
            int cdTrft = TransfertManager.getCdTransfert(cdFlux, cdClient, "En cours");

            //Enregistrement erreur
            TransactionManager.ajoutTransaction(cdTrft, "Transfert Fichier", null, "ERREUR", date);
            TransfertManager.modifTransfert(cdTrft, "Terminer");
            return true;
        }

    }
}
