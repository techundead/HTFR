using HeliosTransfert.Business.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliosTransfert.Business
{
    class VerificationIntegralite
    {
        public static Boolean verificationFichier(int cdServeur, int cdFlux, int cdClient, String designationFichier, String tailleFichier, DateTime date)
        {

            //Récupération des info du transfert
            int cdTrft = TransfertManager.getCdTransfert(cdFlux, cdClient, "En cours");

            //Récupération de l'emplacement serveur
            String CheminServeur = ServeurFluxManager.getCheminLocal(cdServeur, cdFlux);

            //Construction du chemin 
            string fichier = @"" + CheminServeur + "\\" + designationFichier;

            //Calcul de la taille du fichier reçu
            FileInfo fInfo = new FileInfo(fichier);
            String tailleFichierRecu= fInfo.Length.ToString();

            //Vérification de l'intégralité du fichier
            if (tailleFichier == tailleFichierRecu)
            {
                TransactionManager.ajoutTransaction(cdTrft, "Verification integralité", null, "OK", date);
                TransactionManager.ajoutTransaction(cdTrft, "Transfert terminé", null, "OK", date);
                TransfertManager.modifTransfert(cdTrft, "Terminer");
                
                return true;
            }
            else
            {
                TransactionManager.ajoutTransaction(cdTrft, "Verification integralité", null, "ERREUR", date);
                return false;
            }

        }

    }
}
