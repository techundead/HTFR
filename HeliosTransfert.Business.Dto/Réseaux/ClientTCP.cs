using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace HeliosTransfert.Business.Dto
{
    public class ClientTCP
    {
        private TcpClient client;
        private NetworkStream ns;

        public String connexionStream(String ipServeur, int port)
        {
            String etat = "true";
            try
            {
                 client = new TcpClient(ipServeur, port);
                 ns = client.GetStream();
                 etat = "true";

            }catch(Exception tcpExpetion)
            {
                etat = tcpExpetion.Message;
            }
            
            return etat;

        }


        public String deconnexionStream()
        {
            String etat = "true";
            try
            {
                ns.Close();
                client.Close();
                etat = "true";

            }
            catch (Exception tcpExpetion)
            {
                etat = tcpExpetion.Message;
            }

            return etat;

        }

        public String DemandeTransfertFichier(int codeClient, int codeFlux, String nomFichier, String tailleFichier)
        {
            String etat = "true";

            try
            {
                
                byte[] bytes = new byte[1024];

                //Construction de la trame TCP
                byte[] byteTime = Encoding.ASCII.GetBytes(@"" + codeClient.ToString() + "," + codeFlux.ToString() + ",DemandeTransfertFichier," + nomFichier + "," + tailleFichier);

                try
                {
                    //Envoie de la Trame
                    ns.Write(byteTime, 0, byteTime.Length);
                    etat = "true";

                }
                catch (Exception tcpException)
                {
                    etat = tcpException.Message;
                }

                bool done = false;

                while (!done)
                {

                    int bytesRead = ns.Read(bytes, 0, bytes.Length);
                    etat = null;
                    //Récupération Message


                    etat = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                    if (etat != null)
                    {
                        done = true;
                    }
                }

            }
            catch(Exception tcpException)
            {
                etat = tcpException.Message;
            }

            return etat;
        }


        public String VerificationIntegraliteFichier(int codeClient, int codeFlux, String nomFichier, String tailleFichier)
        {
            String etat = "true";

            try
            {

                byte[] bytes = new byte[1024];

                //Construction de la trame TCP
                byte[] byteTime = Encoding.ASCII.GetBytes(@"" + codeClient.ToString() + "," + codeFlux.ToString() + ",VerificationIntegraliteFichier," + nomFichier + "," + tailleFichier);

                try
                {
                    //Envoie de la Trame
                    ns.Write(byteTime, 0, byteTime.Length);
                    etat = "true";

                }
                catch (Exception tcpException)
                {
                    etat = tcpException.Message;
                }

                bool done = false;

                while (!done)
                {

                    int bytesRead = ns.Read(bytes, 0, bytes.Length);

                    etat = null;
                    //Récupération Message
                    etat = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                    if (etat != null)
                    {
                        done = true;
                    }

                }

            }
            catch (Exception tcpException)
            {
                etat = tcpException.Message;
            }

            return etat;
        }

        public String EnvoiErreur(int codeClient, int codeFlux, String nomFichier, String erreur)
        {
            String etat = "true";

            try
            {

                byte[] bytes = new byte[1024];

                //Construction de la trame TCP
                byte[] byteTime = Encoding.ASCII.GetBytes(@"" + codeClient.ToString() + "," + codeFlux.ToString() + ",ErreurTransfert," + nomFichier + "," + erreur);

                try
                {
                    //Envoie de la Trame
                    ns.Write(byteTime, 0, byteTime.Length);
                    etat = "true";

                }
                catch (Exception tcpException)
                {
                    etat = tcpException.Message;
                }

                bool done = false;

                while (!done)
                {

                    int bytesRead = ns.Read(bytes, 0, bytes.Length);

                    etat = null;
                    //Récupération Message
                    etat = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                    if (etat != null)
                    {
                        done = true;
                    }

                }

            }
            catch (Exception tcpException)
            {
                etat = tcpException.Message;
            }

            return etat;
        }



    }
}
