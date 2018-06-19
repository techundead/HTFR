using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business;

namespace HeliosTransfert.Business.Dto
{
    public class TraitementTCP
    {

        public static String Analyse(String trame, String ipSource, int cdServeur)
        {

            //Découpage de la trame
            Char delimiter = ',';
            String[] information = trame.Split(delimiter);
            Boolean reponse;

            int codeClient = Int32.Parse(information[0]);
            int codeFlux = Int32.Parse(information[1]);
            String demande = information[2];
            String designationFichier = information[3];
            String tailleFichier = information[4];
            DateTime date = DateTime.Now;
            String etat = "En cours";


            switch (information[2])
            {
                case "DemandeTransfertFichier":

                    reponse = DemandeTransfert.autorisationTransfert(codeFlux, codeClient, designationFichier, tailleFichier, etat, ipSource, date);
                    return reponse.ToString().ToLower();


                case "VerificationIntegraliteFichier":

                    reponse = VerificationIntegralite.verificationFichier(cdServeur, codeFlux, codeClient, designationFichier, tailleFichier, date);
                    return reponse.ToString().ToLower();

                case "ErreurTransfert":

                    reponse = ErreurTransfert.ErreurTRFT(cdServeur, codeFlux, codeClient, designationFichier, tailleFichier, date);
                    return reponse.ToString().ToLower();

                default:


                    break;
            }

            return null;
        }

    }
}
