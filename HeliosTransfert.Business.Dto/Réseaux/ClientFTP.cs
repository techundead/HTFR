
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Security.Authentication;
using System.Net.Security;

namespace HeliosTransfert.Business.Dto
{
    public class ClientFTP
    {       

        //Initialise un objet FTP
        public FtpClient getFTP()
        {
            FtpClient clientFTP = new FtpClient();

            return clientFTP;
        }

        //Initialise une connexion FTP
        public String connexion(FtpClient clientFTP, String adresseFTP, String idftFTP, String mdpFTP, int portFTP)
        {
            String etat;

            try
            {
                clientFTP.Host = adresseFTP;
                clientFTP.Port = portFTP;
                clientFTP.Credentials = new NetworkCredential(idftFTP, mdpFTP);
                clientFTP.EncryptionMode = FtpEncryptionMode.Explicit;
                clientFTP.SslProtocols = SslProtocols.Tls;
                clientFTP.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);


                clientFTP.Connect();

                etat = "true";
            }
            catch (Exception ex)
            {

                etat = ex.Message;
            }

            return etat;
        }


        public String deconnexion(FtpClient clientFTP)
        {
            String etat;

            try
            {
                clientFTP.Disconnect();

                etat = "true";
            }
            catch (FtpException ex)
            {

                etat = ex.Message;
            }

            return etat;
        }

        void OnValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
        {
            // add logic to test if certificate is valid here
            e.Accept = true;
        }


    }
}
