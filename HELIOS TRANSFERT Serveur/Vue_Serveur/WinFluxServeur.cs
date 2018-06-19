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
    public partial class WinFluxServeur : Form
    {

        private String etat;
        public WinFluxServeur()
        {
            InitializeComponent();
            InitialiserListeFlux();
        }

        //Gérer le changement de ligne
        private void dgv_flux_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Récupère l'index de la ligne
            int indexLigne = e.RowIndex;
            DataGridViewRow ligne = dgv_flux.Rows[indexLigne];

            //Rempli la form
            tb_codeFlux.Text = ligne.Cells["codeFlux"].Value.ToString();
            tb_designation.Text = ligne.Cells["designation"].Value.ToString();

            if (FluxService.getNbreFlux() == 0)
            {
                tb_cheminLocal.Text = null;
            }
            else
            {
                tb_cheminLocal.Text = ServeurFluxService.getCheminLocal(1, Convert.ToInt32(tb_codeFlux.Text));

            }
            
        }
        
       

        //Initialise la DATAGRID
        private void InitialiserListeFlux()
        {
            dgv_flux.DataSource = FluxService.getFluxs();
            dgv_flux.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }



        //Ajouter Flux
        private void ajouterFlux()
        {
            //Vide les champs
            tb_codeFlux.Text = FluxService.getcdFluxmax().ToString();
            tb_designation.Text = null;
            tb_cheminLocal.Text = null;


            //Active la modification des champs
            tb_designation.ReadOnly = false;
            tb_cheminLocal.ReadOnly = false;

            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

            bt_choisirChemin.Visible = true;

        }

        //Modifier Flux
        private void modifierFlux()
        {
            //Active la modification des champs
            tb_designation.ReadOnly = false;
            tb_cheminLocal.ReadOnly = false;


            //Affiche les boutons de validation 
            bt_valider.Visible = true;
            bt_annuler.Visible = true;

            bt_choisirChemin.Visible = true;

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

                    //Associe le Flux au serveur avec le chemin local
                    ServeurFluxService.ajoutServeurFlux(Convert.ToInt32(tb_codeFlux.Text), 1, tb_cheminLocal.Text, null);

                    //Actualiser tableau
                    InitialiserListeFlux();

                    break;

                case "MODIFIER":

                    //Modifie le flux choisi
                    FluxService.modifFlux(Convert.ToInt32(tb_codeFlux.Text), tb_designation.Text);

                    //Modifie le chemin lcoal du flux
                    ServeurFluxService.modifServeurFlux(Convert.ToInt32(tb_codeFlux.Text), 1, tb_cheminLocal.Text, null);


                    //Actualiser tableau
                    InitialiserListeFlux();

                    break;

                case "SUPPRIMER":

                
                    //Supprime le chemin looal du flux
                    ServeurFluxService.suppServeurFlux(1, Convert.ToInt32(tb_codeFlux.Text));

                    //Supprime le flux choisi
                    FluxService.suppFlux(Convert.ToInt32(tb_codeFlux.Text));

                    //Actualiser tableau
                    InitialiserListeFlux();

                    break;
            }


            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;

            bt_choisirChemin.Visible = false;

            //Désactive la modification des champs
            tb_designation.ReadOnly = true;
            tb_cheminLocal.ReadOnly = true;

            //Actualise la form
            this.Refresh();
        }

        private void bt_annuler_Click(object sender, EventArgs e)
        {
            //Désactive les boutons
            bt_valider.Visible = false;
            bt_annuler.Visible = false;

            bt_choisirChemin.Visible = false;

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

        private void gb_flux_Enter(object sender, EventArgs e)
        {

        }

        private void bt_choisirChemin_Click(object sender, EventArgs e)
        {
            if (selectChemin.ShowDialog() == DialogResult.OK)
            {
                tb_cheminLocal.Text = selectChemin.SelectedPath;
            }
        }


    }
}
