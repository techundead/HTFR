using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//En cours de développement


namespace HELIOS_TRANSFERT_Serveur
{
    public partial class WinParametrage : Form
    {
        String mode;
        public WinParametrage()
        {
            InitializeComponent();
        }

        private void txt_base_Click(object sender, EventArgs e)
        {

        }

        private void bt_terminer_Click(object sender, EventArgs e)
        {
            

            if(rb_client.Checked == true)
            {
                mode = "CLIENT";

            }else if(rb_modeServeur.Checked == true){

                mode = "SERVEUR";
            }


            var appSettings = ConfigurationManager.AppSettings;

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            var settings = configFile.AppSettings.Settings;

            settings["base"].Value = tb_nom_base.Text;

            configFile.Save();
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            //config.AppSettings.Settings.Add("mode", mode);

            //config.Save(ConfigurationSaveMode.Modified);

            // config.Save();
            //config.AppSettings.Settings.Remove("base");
            //config.AppSettings.Settings.Add("base", tb_nom_base.Text);

            //config.AppSettings.Settings.Remove("user");
            //config.AppSettings.Settings.Add("user", tb_user_base.Text);

            //config.AppSettings.Settings.Remove("pass");
            //config.AppSettings.Settings.Add("pass", tb_mdp_base.Text);
     

            //config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");

            if (rb_client.Checked == true)
            {
              //  Application.Run(new HeliosTransfertClient());

            }
            else if (rb_modeServeur.Checked == true)
            {

                //Application.Run(new HeliosTransfertServeur());
            }

            this.Close();
        }

        private void WinParametrage_Load(object sender, EventArgs e)
        {

        }
    }
}
