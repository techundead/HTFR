using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business.Dto;
using HeliosTransfert.Business;
using HeliosTransfert.Services;
using System.Timers;
using System.Threading;

namespace HeliosTransfert.Business
{
    public class ClientHeliosTransfert
    {

        //Effectue le transfert de tout les fluxs
        public void transfert()
        {
            IList<ServeurFlux> listFlux = ServeurFluxManager.getServeursFlux();

            foreach (ServeurFlux flux in listFlux)
            {
                transfertVersServeurs(flux);
            }
        }

        //Excute un transfert
        private static void transfertVersServeurs(ServeurFlux flux)
        {
            ClientTCP tcpClient = new ClientTCP();
            FTPHeliosTransfert ftpclient = new FTPHeliosTransfert();
            String etat;

            FileInfo fInfo = new FileInfo(@"" + flux.cheminLocal + "");
            long tailleFichier = fInfo.Length;
            String nomFichier = fInfo.Name;
            String cheminFichier = fInfo.DirectoryName;

            //Initialise un transfert vers serveur
            TransfertManager.ajoutTransfert(flux.codeFlux, Convert.ToInt32(ServeurManager.getCdClient(flux.codeServeur)), "Démarrage transfert", tailleFichier.ToString(), "En cours", ServeurManager.getAdresseIp(flux.codeServeur), DateTime.Now);

            //Récupération Code Transfert
            int cdTrft = TransfertManager.getCdTransfert(flux.codeFlux, Convert.ToInt32(ServeurManager.getCdClient(flux.codeServeur)), "En cours");

            //Connexion au serveur
            etat = tcpClient.connexionStream(ServeurManager.getAdresseIp(flux.codeServeur), Convert.ToInt32(ServeurManager.getTrftPort(flux.codeServeur)));

            if (etat == "true")
            {
                   
                //Enregistrement des transaction
                TransactionManager.ajoutTransaction(cdTrft, "Connexion Serveur Helios Transfert", null, "OK", DateTime.Now);

                //Demande envoi de transfert
                etat = tcpClient.DemandeTransfertFichier(Convert.ToInt32(ServeurManager.getCdClient(flux.codeServeur)), flux.codeFlux, nomFichier, tailleFichier.ToString());
                if ( etat == "true")
                {
                    //Déconnexion TCP - Permet de libérer le serveur d'une connexion (Modèle Asynchrone)
                    tcpClient.deconnexionStream();

                    //Enregistrement des transaction
                    TransactionManager.ajoutTransaction(cdTrft, "Demande de transfert de fichier", null, "OK", DateTime.Now);

                    //Envoi vers FTP
                    if (ftpclient.TransfertFTP(flux.codeServeur, cdTrft, cheminFichier, nomFichier) == true)
                    {

                        tcpClient.connexionStream(ServeurManager.getAdresseIp(flux.codeServeur), Convert.ToInt32(ServeurManager.getTrftPort(flux.codeServeur)));

                        etat = tcpClient.VerificationIntegraliteFichier(Convert.ToInt32(ServeurManager.getCdClient(flux.codeServeur)), flux.codeFlux, nomFichier, tailleFichier.ToString());

                        if (etat == "true")
                        {
                            //Enregistrement des transaction
                            TransactionManager.ajoutTransaction(cdTrft, "Vérification Intégralité du fichier envoyé", null, "OK", DateTime.Now);

                            //Terminer le transfert
                            TransfertManager.modifTransfert(cdTrft, "Terminer");

                            return;

                        }
                        else
                        {
                            //Enregistrement des transaction
                            TransactionManager.ajoutTransaction(cdTrft, "Vérification Intégralité du fichier envoyé", etat, "ERREUR", DateTime.Now);
                        }
                    }
                    else
                    {
                        tcpClient.EnvoiErreur(Convert.ToInt32(ServeurManager.getCdClient(flux.codeServeur)), flux.codeFlux, nomFichier, "Erreur FTP");
                    }

                }
                else
                {
                    //Enregistrement des transaction
                    TransactionManager.ajoutTransaction(cdTrft, "Demande de transfert de fichier", etat, "ERREUR", DateTime.Now);


                }


            }
            else
            {
                //Enregistrement des transaction
                TransactionManager.ajoutTransaction(cdTrft, "Connexion Serveur Helios Transfert", "Connexion Impossible", "ERREUR", DateTime.Now);
    
            }

            //Terminer le transfert
            TransfertManager.modifTransfert(cdTrft, "Terminer");

        }
    }
}
