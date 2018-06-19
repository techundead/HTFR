using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeliosTransfert.Services;
using HeliosTransfert.Business.Dto;

namespace HELIOS_TRANSFERT_Serveur.Serveur
{
    public partial class WinParametreServeur : Form
    {
        Boolean nouveau = false;
        public WinParametreServeur()
        {
            InitializeComponent();
            initialiserFenetre();

        }

        private void initialiserFenetre()
        {
            if (ServeursService.getnbreServeur()==0)
            {
                nouveau = true;
                tb_adresseIp.Text = "localhost";
            }
            else
            {
                tb_adresseIp.Text = ServeursService.getAdresseIp(1);
                tb_port.Text = ServeursService.getTrftPort(1);
            }
            
        }


        private void txt_code_client_Click(object sender, EventArgs e)
        {

        }

        private void tb_codeFlux_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cheminLocal_Click(object sender, EventArgs e)
        {

        }

        private void tb_cheminLocal_TextChanged(object sender, EventArgs e)
        {

        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

            //Débloque les champs
            tb_adresseIp.ReadOnly = false;
            tb_port.ReadOnly = false;

        }

        private void bt_annuler_Click(object sender, EventArgs e)
        {
            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;

            //Actualise la form
            this.Refresh();
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            if (nouveau == true)
            {
                ServeursService.ajoutServeur(tb_adresseIp.Text, "0", "0", "0", tb_port.Text, 0);
            }
            else if(nouveau==false)
            {
                ServeursService.modifServeur(1,tb_adresseIp.Text, "0", "0", "0", tb_port.Text,0);
            }

            //Bloque les champs
            tb_adresseIp.ReadOnly = true;
            tb_port.ReadOnly = true;

            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;

            //Actualise la form
            this.Refresh();
        }
    }
}
