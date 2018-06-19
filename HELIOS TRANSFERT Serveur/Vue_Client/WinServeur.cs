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
using HELIOS_TRANSFERT_Serveur;

namespace HELIOS_TRANSFERT_Serveur.Client
{
    public partial class WinServeur : Form
    {
        private String etat;


        public WinServeur()
        {
            InitializeComponent();
            InitialiserListeServeur();

        }

        private void dgv_serveurs_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Récupère l'index de la ligne
            int indexLigne = e.RowIndex;
            DataGridViewRow ligne = dgv_serveurs.Rows[indexLigne];

            //Rempli la form
            tb_codeServeur.Text = ligne.Cells["codeServeur"].Value.ToString();
            tb_adresseIP.Text = ligne.Cells["adresseIp"].Value.ToString();
            tb_portTRFT.Text = ligne.Cells["trftPort"].Value.ToString();
            tb_idtfFTP.Text = ligne.Cells["ftpIdtf"].Value.ToString();
            tb_mdpFTP.Text = ligne.Cells["ftpMdp"].Value.ToString();
            tb_portFTP.Text = ligne.Cells["ftpPort"].Value.ToString();
            tb_codeClient.Text = ligne.Cells["code_client_srv"].Value.ToString();
                      


        }


        //Initialise la DATAGRID
        private void InitialiserListeServeur()
        {

            dgv_serveurs.AutoGenerateColumns = false;
            dgv_serveurs.DataSource = new BindingList<HeliosTransfert.Business.Dto.Serveur>(ServeursService.getServeurs());

            DataGridViewCell cell = new DataGridViewTextBoxCell();           
            dgv_serveurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "codeServeur", DataPropertyName = "codeServeur", HeaderText = "Code Serveur" });
            dgv_serveurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "adresseIP", DataPropertyName = "adresseIP", HeaderText = "Serveur" });
            dgv_serveurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "code_client_srv", DataPropertyName = "code_client_srv", HeaderText = "Code Client" });
            dgv_serveurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "ftpIdtf", DataPropertyName = "ftpIdtf", HeaderText = "FTP Identifiant" });
            dgv_serveurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "ftpMdp", DataPropertyName = "ftpMdp", HeaderText = "FTP Mot de Passe", Visible=false });
            dgv_serveurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "ftpPort", DataPropertyName = "ftpPort", HeaderText = "FTP Port" });
            dgv_serveurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "trftPort", DataPropertyName = "trftPort", HeaderText = "TRFT Port" });

            dgv_serveurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        //Ajouter Serveur
        private void ajouterServeur()
        {
            //Vide les champs
            tb_codeServeur.Text = ServeursService.getcdServeurmax().ToString();
            tb_adresseIP.Text = null;
            tb_portTRFT.Text = null;
            tb_idtfFTP.Text = null;
            tb_mdpFTP.Text = null;
            tb_portFTP.Text = null;
            tb_codeClient.Text = null;

            //Active la modification des champs
            tb_adresseIP.ReadOnly = false;
            tb_portTRFT.ReadOnly = false;
            tb_idtfFTP.ReadOnly = false;
            tb_mdpFTP.ReadOnly = false;
            tb_portFTP.ReadOnly = false;
            tb_codeClient.ReadOnly = false;

            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

        }

        //Modifier Serveur
        private void modifierServeur()
        {
            //Active la modification des champs
            tb_adresseIP.ReadOnly = false;
            tb_portTRFT.ReadOnly = false;
            tb_idtfFTP.ReadOnly = false;
            tb_mdpFTP.ReadOnly = false;
            tb_portFTP.ReadOnly = false;
            tb_codeClient.ReadOnly = false;

            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

        }

        //Supprimer Serveur
        private void SupprimerServeur()
        {
            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etat = "AJOUT";

            ajouterServeur();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etat = "MODIFIER";
            modifierServeur();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etat = "SUPPRIMER";
            SupprimerServeur();
        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            switch (etat)
            {
                case "AJOUT":

                    //Ajoute Serveur
                    ServeursService.ajoutServeur(tb_adresseIP.Text, tb_idtfFTP.Text, tb_mdpFTP.Text, tb_portFTP.Text, tb_portTRFT.Text, Convert.ToInt32(tb_codeClient.Text));


                    //Actualiser tableau
                    InitialiserListeServeur();

                    break;

                case "MODIFIER":

                    //Modifie les infos du serveur
                    ServeursService.modifServeur(Convert.ToInt32(tb_codeServeur.Text), tb_adresseIP.Text, tb_idtfFTP.Text, tb_mdpFTP.Text, tb_portFTP.Text, tb_portTRFT.Text, Convert.ToInt32(tb_codeClient.Text));

                    //Actualiser tableau
                    InitialiserListeServeur();

                    break;

                case "SUPPRIMER":


                    //Supprime le serveur
                    ServeursService.suppServeur(Convert.ToInt32(tb_codeServeur.Text));

                    
                    //Actualiser tableau
                    InitialiserListeServeur();

                    break;
            }


            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;

            //Actualise la form
            this.Refresh();

            //Désactiver la modification des champs
            tb_adresseIP.ReadOnly = true;
            tb_portTRFT.ReadOnly = true;
            tb_idtfFTP.ReadOnly = true;
            tb_mdpFTP.ReadOnly = true;
            tb_portFTP.ReadOnly = true;
            tb_codeClient.ReadOnly = true;

        }

        private void bt_annuler_Click(object sender, EventArgs e)
        {

            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;

            //Actualise la form
            this.Refresh();

            //Désactiver la modification des champs
            tb_adresseIP.ReadOnly = true;
            tb_portTRFT.ReadOnly = true;
            tb_idtfFTP.ReadOnly = true;
            tb_mdpFTP.ReadOnly = true;
            tb_portFTP.ReadOnly = true;
        }

        private void WinServeur_Load(object sender, EventArgs e)
        {

        }


    }
}
