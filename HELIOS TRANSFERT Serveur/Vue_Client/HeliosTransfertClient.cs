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
using HELIOS_TRANSFERT_Serveur;

namespace HELIOS_TRANSFERT_Serveur
{
    public partial class HeliosTransfertClient : Form
    {
        public HeliosTransfertClient()
        {
            InitializeComponent();
            InitialiserListeTransfert();
           
        }

        private void HeliosTransfertClient_Load(object sender, EventArgs e)
        {

        }


        private void listClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Gérer le changement de ligne
        private void dgv_transfert_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Récupère l'index de la ligne
            int indexLigne = e.RowIndex;
            DataGridViewRow ligne = dgv_transfert.Rows[indexLigne];

            int cdTRFT = Convert.ToInt32(ligne.Cells["codetransfert"].Value.ToString());

            dgv_transaction.DataSource = TransactionsService.getTransactions(cdTRFT);
            dgv_transaction.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        //Initialise la DATAGRID
        private void InitialiserListeTransfert()
        {

            dgv_transfert.DataSource = TransfertsService.getTransferts();
            dgv_transfert.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void bt_serveurs_Click(object sender, EventArgs e)
        {
            Client.WinServeur WinServeur = new Client.WinServeur();
            WinServeur.Show();
        }

        private void bt_flux_Click(object sender, EventArgs e)
        {
            Client.WinFlux WinFlux = new Client.WinFlux();
            WinFlux.Show();
        }

        private void bt_transfert_Click(object sender, EventArgs e)
        {
            bt_transfert.Enabled = false;
            bw_transfert.RunWorkerAsync();
            dgv_transfert.DataSource = TransfertsService.getTransferts();
        }

        private void bw_transfert_DoWork(object sender, DoWorkEventArgs e)
        {
            ControlerClientService.demarrerTransfert();
        }

        private void bw_transfert_ProgessChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bw_transfert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bt_transfert.Enabled = true;
            dgv_transfert.DataSource = TransfertsService.getTransferts();
            ControlerClientService.arreterTransfert();
        }
    }
}
