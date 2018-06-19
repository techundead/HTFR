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
    public partial class WinLstFluxServeurs : Form
    {
        private String etat;
        private int codeServeurOld;
        private int codeServeurNew;
        private int cdFlux;

        private int indexLigne;
        private DataGridViewRow ligne;
        private IList<HeliosTransfert.Business.Dto.Serveur> lstserveur = ServeursService.getServeurs();

        public WinLstFluxServeurs(int codeFlux)
        {
            cdFlux = codeFlux;
            InitializeComponent();
            InitialiserListeFlux();

        }

        private void dgv_FluxServeurs_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Récupère l'index de la ligne
            indexLigne = e.RowIndex;
            ligne = dgv_FluxServeurs.Rows[indexLigne];

            //Rempli la form
            tb_codeFlux.Text = ligne.Cells["codeFlux"].Value.ToString();

            tb_cheminLocal.Text = ligne.Cells["cheminLocal"].Value.ToString();
            tb_designation.Text = ligne.Cells["designation"].Value.ToString();
            cb_adresseIP.Text = ligne.Cells["adresseIP"].Value.ToString();

            int codeServeur = Convert.ToInt32(ligne.Cells["codeServeur"].Value.ToString());


        }

        //Initialise la DATAGRID
        private void InitialiserListeFlux()
        {
            //Initialiser Liste "Flux"
            dgv_FluxServeurs.AutoGenerateColumns = false;
            dgv_FluxServeurs.DataSource = new BindingList<ServeurFlux>(ServeurFluxService.getLstServeursFlux(cdFlux));

            DataGridViewCell cell = new DataGridViewTextBoxCell();
            dgv_FluxServeurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "codeFlux", DataPropertyName = "codeFlux", HeaderText = "Code Flux", Visible = false });
            dgv_FluxServeurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "codeServeur", DataPropertyName = "codeServeur", HeaderText = "Code Serveur" });
            dgv_FluxServeurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "adresseIP", DataPropertyName = "adresseIP", HeaderText = "Serveur" });
            dgv_FluxServeurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "designation", DataPropertyName = "designation", HeaderText = "Designation", Visible = false});
            dgv_FluxServeurs.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "cheminLocal", DataPropertyName = "cheminLocal", HeaderText = "Fichier" });

            dgv_FluxServeurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Ajouter Flux
        private void ajouterFlux()
        {
            //Vide les champs
            tb_codeFlux.Text = cdFlux.ToString();
            tb_designation.Text = null;
            tb_cheminLocal.Text = null;
            //BindingList<>

            List<String> lstNomSrv = new List<string>();


            foreach (HeliosTransfert.Business.Dto.Serveur srv in lstserveur)
            {
                lstNomSrv.Add(srv.adresseIp.ToString());
            }

            cb_adresseIP.DataSource = lstNomSrv;


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

            List<String> lstNomSrv = new List<string>();

            foreach (HeliosTransfert.Business.Dto.Serveur srv in lstserveur)
            {
                lstNomSrv.Add(srv.adresseIp.ToString());

                if (srv.adresseIp.ToString() == cb_adresseIP.Text)
                {
                    codeServeurOld = srv.codeServeur;
                }
            }

            cb_adresseIP.DataSource = lstNomSrv;


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


                    foreach (HeliosTransfert.Business.Dto.Serveur srv in lstserveur)
                    {
                        if (srv.adresseIp.ToString() == cb_adresseIP.Text)
                        {
                            codeServeurNew = Convert.ToInt32(srv.codeServeur.ToString());
                        }

                    }


                    //Associe le Flux au serveur avec le chemin local
                    ServeurFluxService.ajoutServeurFlux(cdFlux, codeServeurNew, tb_cheminLocal.Text, null);

                    break;

                case "MODIFIER":


                    foreach (HeliosTransfert.Business.Dto.Serveur srv in lstserveur)
                    {
                        if (srv.adresseIp.ToString() == cb_adresseIP.Text)
                        {
                            codeServeurNew = Convert.ToInt32(srv.codeServeur.ToString());
                        }

                    }


                    //Modifie le chemin lcoal du flux
                    ServeurFluxService.modifCdSRVServeurFlux(cdFlux, codeServeurOld, codeServeurNew, tb_cheminLocal.Text, null);



                    break;

                case "SUPPRIMER":

                    //Supprime le chemin locoal du flux
                    ServeurFluxService.suppServeurFlux(Convert.ToInt32(ligne.Cells["codeServeur"].Value.ToString()), cdFlux);

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

            //Actualiser tableau
            dgv_FluxServeurs.DataSource = new BindingList<ServeurFlux>(ServeurFluxService.getLstServeursFlux(cdFlux));
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


        private void bt_choisirChemin_Click(object sender, EventArgs e)
        {

            if (selectchemin.ShowDialog() == DialogResult.OK)
            {
                tb_cheminLocal.Text = selectchemin.FileName;
            }
        }

    }
}
