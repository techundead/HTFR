using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using HeliosTransfert.Services;
using HeliosTransfert.Business.Dto;
using System.Threading;

namespace HELIOS_TRANSFERT_Serveur
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            //Verifie le mode choisi
            string mode = ConfigurationManager.AppSettings["mode"];

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Création du fichier de log
            Log.CreerFichierLog();


            //Mode CMD - Lancer les transferts avec le commande [START HELIOSTRANSFERT.EXE -t]
            args = Environment.GetCommandLineArgs();

            if(args.Length > 1)
            {
                if (args[1] == "-t" && mode=="CLIENT")
                {
                    ControlerClientService.demarrerTransfert();
                }

            }
            else //Mode Graphique
            {                

                //Choix du mode
                switch (mode)
                {
                    case "SERVEUR":
                        Application.Run(new HeliosTransfertServeur());
                        break;

                    case "CLIENT":
                        Application.Run(new HeliosTransfertClient());
                        break;

                    default:
                        MessageBox.Show("Aucun Mode choisis. Veillez paramétrer le fichier 'Base.config' !");
                        break;
                }
            }

            
        }
            
    }
}
