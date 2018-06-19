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


using System.Configuration;


namespace HELIOS_TRANSFERT_Serveur
{
    public partial class HeliosTransfertServeur : Form
    {
        ControlerServeurService Controler = new ControlerServeurService();
        Boolean etat = true;
        private Timer _timer = new Timer() { Interval = 5000 };

        public HeliosTransfertServeur()
        {

            InitializeComponent();

            //Initialiser Timer
            _timer.Tick += _timer_Tick;
            _timer.Start();

            //Initialiser Liste "Connexion en Cours"
            dgv_ConnexionEnCours.AutoGenerateColumns = false;
            dgv_ConnexionEnCours.DataSource = new BindingList<Transfert>(TransfertsService.getTransfertsEtat("En cours"));

            DataGridViewCell cell = new DataGridViewTextBoxCell();
            dgv_ConnexionEnCours.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "codeFlux", DataPropertyName = "codeFlux", HeaderText = "Code Flux" });
            dgv_ConnexionEnCours.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "codeTransfert", DataPropertyName = "codeTransfert", HeaderText = "Code Transfert" });
            dgv_ConnexionEnCours.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "designation", DataPropertyName = "designation", HeaderText = "Désignation" });
            dgv_ConnexionEnCours.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "ipSource", DataPropertyName = "ipSource", HeaderText = "Ip Source" });
            dgv_ConnexionEnCours.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "etat", DataPropertyName = "etat", HeaderText = "Etat" });
            dgv_ConnexionEnCours.Columns.Add(new DataGridViewColumn() { CellTemplate = cell, Name = "dateTransfert", DataPropertyName = "dateTransfert", HeaderText = "Date Transfert" });

            FormClosing += HeliosTransfertServeur_FormClosing;

        }

        private void HeliosTransfertServeur_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
            _timer.Tick -= _timer_Tick;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();

            //Initialiser Liste "Flux"
            dgv_ConnexionEnCours.AutoGenerateColumns = false;
            dgv_ConnexionEnCours.DataSource = new BindingList<Transfert>(TransfertsService.getTransfertsEtat("En cours"));

            dgv_ConnexionEnCours.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _timer.Start();
        }

        private void b_manageSrv_Click(object sender, EventArgs e)
        {
            if (etat == false)
            {
                ControlerServeurService.arreterServeur();
                etat = true;
                b_manageSrv.Text = "Démarrer Serveur";
                

            }
            else if (etat == true)
            {
                ControlerServeurService.demarrerServeur();
                etat = false;
                b_manageSrv.Text = "Arreter Serveur";
            }

        }

        private void b_quitter_Click(object sender, EventArgs e)
        {
            if (etat == false)
            {
                ControlerServeurService.arreterServeur();
                this.Close();

            }
            else if (etat == true)
            {
                this.Close();
            }
        }

        private void HeliosTransfertServeur_Load(object sender, EventArgs e)
        {

        }

        private void btn_clients_Click(object sender, EventArgs e)
        {
            Serveur.WinClient WinClient = new Serveur.WinClient();
            WinClient.Show();



        }

        private void bt_flux_Click(object sender, EventArgs e)
        {
            Serveur.WinFluxServeur WinFlux = new Serveur.WinFluxServeur();
            WinFlux.Show();
        }

        private void bt_parametre_Click(object sender, EventArgs e)
        {
            Serveur.WinParametreServeur WinParametre = new Serveur.WinParametreServeur();
            WinParametre.Show();
        }
    }
}
