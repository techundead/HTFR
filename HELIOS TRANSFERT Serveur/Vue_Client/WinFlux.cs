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
    public partial class WinFlux : Form
    {
        private String etat;
        private int codeServeurOld;
        private int codeServeurNew;
        private IList<HeliosTransfert.Business.Dto.Serveur> lstserveur = ServeursService.getServeurs();

        public WinFlux()
        {
            InitializeComponent();
            InitialiserListeFlux();

        }

        private void dgv_flux_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Récupère l'index de la ligne
            int indexLigne = e.RowIndex;
            DataGridViewRow ligne = dgv_Flux.Rows[indexLigne];

            //Rempli la form
            tb_codeFlux.Text = ligne.Cells["codeFlux"].Value.ToString();
            tb_designation.Text = ligne.Cells["designation"].Value.ToString();


        }

        //Initialise la DATAGRID
        private void InitialiserListeFlux()
        {
            //Initialiser Liste "Flux"
            dgv_Flux.AutoGenerateColumns = false;
            dgv_Flux.DataSource = new BindingList<Flux>(FluxService.getFluxs());

            DataGridViewCell cell = new DataGridViewTextBoxCell();
            dgv_Flux.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "codeFlux", DataPropertyName = "codeFlux", HeaderText = "Code Flux" });
            dgv_Flux.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "designation", DataPropertyName = "designation", HeaderText = "Designation" });


            dgv_Flux.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Ajouter Flux
        private void ajouterFlux()
        {
            //Vide les champs
            tb_codeFlux.Text = FluxService.getcdFluxmax().ToString();
            tb_designation.Text = null; 

            //Active la modification des champs
            tb_designation.ReadOnly = false;

            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

        }

        //Modifier Flux
        private void modifierFlux()
        {

            //Active la modification des champs
            tb_designation.ReadOnly = false;

            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

        }

        //Supprimer Flux
        private void supprimerFlux()
        {
            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

        }



        private void WinFluxServeur_Load(object sender, EventArgs e)
        {

        }

        private void bt_valider_Click(object sender, EventArgs e)
        {
            switch (etat)
            {
                case "AJOUTER":

                    //Créer un nouveau Flux
                    FluxService.ajoutFlux(tb_designation.Text);

                    break;

                case "MODIFIER":

                    //Modifie le flux choisi
                    FluxService.modifFlux(Convert.ToInt32(tb_codeFlux.Text), tb_designation.Text);
                 
                    break;

                case "SUPPRIMER":

                    //Supprime le flux choisi
                    FluxService.suppFlux(Convert.ToInt32(tb_codeFlux.Text));

                    break;
            }

            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;


            //Désactive la modification des champs
            tb_designation.ReadOnly = true;

            //Actualise la form
            this.Refresh();

            //Actualiser tableau
            dgv_Flux.DataSource = new BindingList<Flux>(FluxService.getFluxs());
        }

        private void bt_annuler_Click(object sender, EventArgs e)
        {
            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;

            //Actualise la form
            this.Refresh();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etat = "AJOUTER";
            ajouterFlux();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etat = "MODIFIER";
            modifierFlux();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            etat = "SUPPRIMER";
            supprimerFlux();
        }

        private void listeFluxServeursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinLstFluxServeurs WinLstFluxServeurs = new WinLstFluxServeurs(Convert.ToInt32(tb_codeFlux.Text));
            WinLstFluxServeurs.Show();
        }

        private void WinFlux_Load(object sender, EventArgs e)
        {

        }
    }
}
