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
    public partial class WinClient : Form
    {
        private String etat;

        public WinClient()
        {
            InitializeComponent();

            InitialiserListeClient();
       

        }

        private void WinClient_Load(object sender, EventArgs e)
        {

        }

        //Gérer le changement de ligne
        private void Dgv_clients_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Récupère l'index de la ligne
            int indexLigne = e.RowIndex;
            DataGridViewRow ligne = dgv_clients.Rows[indexLigne];

            //Rempli la form
            tb_codeClient.Text = ligne.Cells["codeClient"].Value.ToString();
            tb_raisonSocial.Text = ligne.Cells["raisonSocial"].Value.ToString();
            tb_adressePostale.Text = ligne.Cells["adressePostale"].Value.ToString();
            tb_codePostale.Text = ligne.Cells["codePostal"].Value.ToString();
            tb_ville.Text = ligne.Cells["ville"].Value.ToString();
            tb_pays.Text = ligne.Cells["pays"].Value.ToString();

        }

        //Initialise la DATAGRID
        private void InitialiserListeClient()
        {

            dgv_clients.DataSource = ClientsService.getClients();
            dgv_clients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Ajouter Client
        private void ajouterClient()
        {
            //Vide les champs
            tb_codeClient.Text = ClientsService.getcdClientmax().ToString();
            tb_raisonSocial.Text = null;
            tb_adressePostale.Text = null;
            tb_codePostale.Text = null;
            tb_ville.Text = null;
            tb_pays.Text = null;

            //Active la modification des champs
            tb_raisonSocial.ReadOnly = false;
            tb_adressePostale.ReadOnly = false;
            tb_codePostale.ReadOnly = false;
            tb_ville.ReadOnly = false;
            tb_pays.ReadOnly = false;

            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

        }

        //Modifier Client
        private void modifierClient()
        {
            //Active la modification des champs
            tb_raisonSocial.ReadOnly = false;
            tb_adressePostale.ReadOnly = false;
            tb_codePostale.ReadOnly = false;
            tb_ville.ReadOnly = false;
            tb_pays.ReadOnly = false;

            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

        }

        //Supprimer Client
        private void SupprimerClient()
        {
            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;
        }



        private void gb_clients_Enter(object sender, EventArgs e)
        {

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etat = "AJOUT";

            ajouterClient();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etat = "MODIFIER";
            modifierClient();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etat = "SUPPRIMER";
            SupprimerClient();
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            switch (etat)
            {
                case "AJOUT":

                    ClientsService.ajoutClient(tb_raisonSocial.Text, tb_adressePostale.Text, tb_codePostale.Text, tb_ville.Text, tb_pays.Text);
                    //Actualiser tableau
                    InitialiserListeClient();

                    break;

                case "MODIFIER":

                    ClientsService.modifClient(Convert.ToInt32(tb_codeClient.Text), tb_raisonSocial.Text, tb_adressePostale.Text, tb_codePostale.Text, tb_ville.Text, tb_pays.Text);
                    //Actualiser tableau
                    InitialiserListeClient();

                    break;

                case "SUPPRIMER":

                    ClientsService.suppClient(Convert.ToInt32(tb_codeClient.Text));
                    //Actualiser tableau
                    InitialiserListeClient();

                    break;
            }


            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;

            //Actualise la form
            this.Refresh();

        }

        private void bt_annuler_Click(object sender, EventArgs e)
        {
           
            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;

            //Actualise la form
            this.Refresh();
        }
    }
}
