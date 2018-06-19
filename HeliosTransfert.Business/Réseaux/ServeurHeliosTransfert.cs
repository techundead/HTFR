using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using HeliosTransfert.Business.Dto;
using System.Windows.Forms;
using HeliosTransfert;
using HeliosTransfert.Dal;

namespace HeliosTransfert.Business
{
    public class ServeurHeliosTransfert
    {
        TcpListener listener;

        bool etatServeur = false;
        byte[] bytereponse;
        int cdServeur;

        public void DemarrerServeur()
        {
            //Récupère info  iD Serveur
            cdServeur = 1;

            //Initilisation d'un serveur TCP
            listener = ServeurTCP.DemarrageServeur(ServeurManager.getAdresseIp(1), Convert.ToInt32(ServeurManager.getTrftPort(1)));

            //Démarrage du serveur HELIO TRANSFERT
            DemarrerServeur(listener);
            return;
        }

        public void ArreterServeur()
        {

            //Démarrage du serveur HELIO TRANSFERT
            ArreterServeur(listener);
            return;
        }

        private void DemarrerServeur(TcpListener listener)
        {

            while (!etatServeur)
            {
                try
                {
                    //En attente d'une connexion CLIENT
                    TcpClient client = listener.AcceptTcpClient();

                //Connexion CLIENT Connecté -> Ouverture d'un flux réseau
                NetworkStream fluxReseau= client.GetStream();

                //Création d"une connexion
                Connexion co = new Connexion();
                co.Date = DateTime.Now;
                co.Ip = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                //Lecture de la trame reçu
                byte[] bytes = new byte[1024];
                int bytesRead = fluxReseau.Read(bytes, 0, bytes.Length);


                //Vérification de la connexion client
                if (ConnexionManager.Instance.VerificationConnexion(co) == false)
                {
                    //Connexion Refusé
                    bytereponse = Encoding.ASCII.GetBytes("false");
                }
                else{

                    //Connexion Autorisé - Ajouter la connexion dans la liste
                    ConnexionManager.Instance.AddConnexion(co);

                    //Analyse de la trame
                   bytereponse = Encoding.ASCII.GetBytes(TraitementTCP.Analyse(Encoding.ASCII.GetString(bytes, 0, bytesRead), ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString(), cdServeur));

                }



                //Envoi réponse
                
                    fluxReseau.Write(bytereponse, 0, bytereponse.Length);
                    fluxReseau.Close();
                    client.Close();
                    ConnexionManager.Instance.DelConnexion(co);
                  //  ConnexionManager.Instance.DelConnexion(co);

                }
                catch (Exception e)
                {
                    
                }
            }

            

            return;
        }

        private void ArreterServeur(TcpListener listener)
        {
            //Arreter du serveur
            listener.Stop();
            etatServeur = true;

            ConnexionManager.Instance.ResetConnexion();
        }
    }
}
