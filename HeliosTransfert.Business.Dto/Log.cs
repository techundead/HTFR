using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeliosTransfert.Business.Dto
{
    public class Log
    {

        public static void CreerFichierLog()
        {

            if(Directory.Exists(Application.StartupPath + "\\log\\"))
            {

            }
            else
            {
                Directory.CreateDirectory(Application.StartupPath + "\\log\\");
            }

            DateTime dateJour = DateTime.Today;
            FileInfo file = new FileInfo(Application.StartupPath + "\\log\\" + dateJour.ToString("D") + ".txt");

            if (file.Exists)
            {
                file.Refresh();
                EcrirLog("Ouverture de l'application");
                return;
            }

            file.Create();           

        }

        public static void EcrirLog(String message)
        {
            try
            {
                DateTime dateJour = DateTime.Today;
                File.AppendAllText(Application.StartupPath + "\\log\\" + dateJour.ToString("D") + ".txt", DateTime.Now.ToString() + ": " + message + Environment.NewLine);
            }
            catch
            {
                return;
            }
                    
        }

    }
}
