using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeliosTransfert.Business.Dto;
using HeliosTransfert.Business;
using FluentFTP;
using System.IO;

namespace HeliosTransfert.Services
{
    public class FTPHeliosTransfert
    {
        ClientFTP ClientFtp = new ClientFTP();

        public  Boolean TransfertFTP(int code_Serveur, int code_Transfert, string chemin, string nomFichier)
        {
            Boolean etat = false;
            

            FtpClient SocketFTP = ClientFtp.getFTP();

            //Connexion au srv FTP
            String result;
            do
            {
                result = ClientFtp.connexion(SocketFTP, ServeurManager.getAdresseIp(code_Serveur), ServeurManager.getFtpIdtf(code_Serveur), ServeurManager.getFtpMdp(code_Serveur), Convert.ToInt32(ServeurManager.getFtpPort(code_Serveur)));
                if (result == "true")
                {
                    etat = true;

                    //Enregistrement transaction "Connexion SRV FTP"
                    TransactionManager.ajoutTransaction(code_Transfert, "Connexion au serveur FTP", null, "OK", DateTime.Now);

                    //Envoi fichier
                    etat = envoiFichier(code_Serveur, code_Transfert, SocketFTP, nomFichier, chemin);

                    //Fermeture de la connexion FTP
                    ClientFtp.deconnexion(SocketFTP);
                }
                else
                {
                    //Enregistrement transaction "Connexion SRF FTP"
                    TransactionManager.ajoutTransaction(code_Transfert, "Connexion au serveur FTP", "Connexion Impossible", "ERREUR", DateTime.Now);
                }

            } while (result != "true");
           
            return etat ;
        }

        private Boolean envoiFichier(int code_Serveur, int code_Transfert, FtpClient clientFTP, String Fichier, String CheminLocal)
        {
            string CheminDistant;
            bool erreurEnvoi = false;
            bool etat = false;
            CheminLocal = @""+CheminLocal + "\\" + Fichier;
            CheminDistant = @"" + Fichier;
            FileStream StreamFichier = File.OpenRead(CheminLocal);


            try
            {
                
                //Lancement de l'envoi
                clientFTP.UploadFile(CheminLocal, CheminDistant);
                
               

                //Enregistrement transaction "Envoi Fichier"
                TransactionManager.ajoutTransaction(code_Transfert, "Envoi Fichier"+ Fichier, null, "OK", DateTime.Now);

                //
                etat = true;


            }
            catch (FtpException ex)
            {

                //activation de la reprise sur erreur
                erreurEnvoi = true;
                
                //Enregistrement transaction "Envoi fichier"
                TransactionManager.ajoutTransaction(code_Transfert, "Envoi Fichier" + Fichier, ex.Message, "ERREUR", DateTime.Now);

                //Enregistrement transaction "Relance envoi"
                TransactionManager.ajoutTransaction(code_Transfert, "Relance de l'envoi du fichier vers le serveur", null, "En cours", DateTime.Now);

                //Attente pour relance
                System.Threading.Thread.Sleep(10000);

                //Enregistrement transaction "Connexion SRF FTP"
                TransactionManager.ajoutTransaction(code_Transfert, "Relance de l'envoi du fichier vers le serveur", null, "OK", DateTime.Now);

                //Lancement de la reprise sur erreur
                while (erreurEnvoi == true)
                {


                    try
                    {

                            //Relance l'envoi
                            clientFTP.UploadFile(@CheminLocal, CheminDistant, FtpExists.Append);

                            //Enregistrement transaction "Envoi Fichier"
                            TransactionManager.ajoutTransaction(code_Transfert, "Envoi Fichier" + Fichier, null, "OK", DateTime.Now);

                            //Désactivation de la reprise sur erreur
                            erreurEnvoi = false;
                        //Valide le transfert
                        etat = true;


                    }
                    catch (Exception erreurRelance)
                    {
                        //Activation de la reprise sur erreur
                        erreurEnvoi = true;

                        //Enregistrement transaction "Envoi fichier"
                        TransactionManager.ajoutTransaction(code_Transfert, "Envoi Fichier" + Fichier, ex.Message, "ERREUR", DateTime.Now);

                        //Enregistrement transaction "Relance envoi"
                        TransactionManager.ajoutTransaction(code_Transfert, "Relance de l'envoi du fichier vers le serveur", null, "En cours", DateTime.Now);

                        //Attente pour relance
                        System.Threading.Thread.Sleep(10000);

                        //Enregistrement transaction "Connexion SRF FTP"
                        TransactionManager.ajoutTransaction(code_Transfert, "Relance de l'envoi du fichier vers le serveur", null, "OK", DateTime.Now);

                    }


                }

            }
            return etat;
        }


    }
}
