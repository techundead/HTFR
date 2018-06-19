namespace HELIOS_TRANSFERT_Serveur
{
    partial class HeliosTransfertClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeliosTransfertClient));
            this.bt_transfert = new System.Windows.Forms.Button();
            this.dgv_transfert = new System.Windows.Forms.DataGridView();
            this.dgv_transaction = new System.Windows.Forms.DataGridView();
            this.bt_serveurs = new System.Windows.Forms.Button();
            this.bt_flux = new System.Windows.Forms.Button();
            this.bw_transfert = new System.ComponentModel.BackgroundWorker();
            this.notify_TRFT_client = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transfert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transaction)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_transfert
            // 
            this.bt_transfert.Location = new System.Drawing.Point(810, 261);
            this.bt_transfert.Name = "bt_transfert";
            this.bt_transfert.Size = new System.Drawing.Size(163, 41);
            this.bt_transfert.TabIndex = 0;
            this.bt_transfert.Text = "Transférer";
            this.bt_transfert.UseVisualStyleBackColor = true;
            this.bt_transfert.Click += new System.EventHandler(this.bt_transfert_Click);
            // 
            // dgv_transfert
            // 
            this.dgv_transfert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_transfert.Location = new System.Drawing.Point(12, 12);
            this.dgv_transfert.Name = "dgv_transfert";
            this.dgv_transfert.ReadOnly = true;
            this.dgv_transfert.Size = new System.Drawing.Size(769, 179);
            this.dgv_transfert.TabIndex = 1;
            this.dgv_transfert.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_transfert_RowEnter);
            // 
            // dgv_transaction
            // 
            this.dgv_transaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_transaction.Location = new System.Drawing.Point(12, 203);
            this.dgv_transaction.Name = "dgv_transaction";
            this.dgv_transaction.ReadOnly = true;
            this.dgv_transaction.Size = new System.Drawing.Size(769, 150);
            this.dgv_transaction.TabIndex = 2;
            // 
            // bt_serveurs
            // 
            this.bt_serveurs.Location = new System.Drawing.Point(810, 51);
            this.bt_serveurs.Name = "bt_serveurs";
            this.bt_serveurs.Size = new System.Drawing.Size(163, 41);
            this.bt_serveurs.TabIndex = 3;
            this.bt_serveurs.Text = "Liste Serveurs";
            this.bt_serveurs.UseVisualStyleBackColor = true;
            this.bt_serveurs.Click += new System.EventHandler(this.bt_serveurs_Click);
            // 
            // bt_flux
            // 
            this.bt_flux.Location = new System.Drawing.Point(810, 131);
            this.bt_flux.Name = "bt_flux";
            this.bt_flux.Size = new System.Drawing.Size(163, 41);
            this.bt_flux.TabIndex = 4;
            this.bt_flux.Text = "Liste Flux";
            this.bt_flux.UseVisualStyleBackColor = true;
            this.bt_flux.Click += new System.EventHandler(this.bt_flux_Click);
            // 
            // bw_transfert
            // 
            this.bw_transfert.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_transfert_DoWork);
            this.bw_transfert.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_transfert_ProgessChanged);
            this.bw_transfert.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_transfert_RunWorkerCompleted);
            // 
            // notify_TRFT_client
            // 
            this.notify_TRFT_client.Icon = ((System.Drawing.Icon)(resources.GetObject("notify_TRFT_client.Icon")));
            this.notify_TRFT_client.Text = "Helios Transfert Client";
            this.notify_TRFT_client.Visible = true;
            // 
            // HeliosTransfertClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 365);
            this.Controls.Add(this.bt_flux);
            this.Controls.Add(this.bt_serveurs);
            this.Controls.Add(this.dgv_transaction);
            this.Controls.Add(this.dgv_transfert);
            this.Controls.Add(this.bt_transfert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1001, 404);
            this.MinimumSize = new System.Drawing.Size(1001, 404);
            this.Name = "HeliosTransfertClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client - HELIOS TRANSFERT";
            this.Load += new System.EventHandler(this.HeliosTransfertClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transfert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transaction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_transfert;
        private System.Windows.Forms.DataGridView dgv_transfert;
        private System.Windows.Forms.DataGridView dgv_transaction;
        private System.Windows.Forms.Button bt_serveurs;
        private System.Windows.Forms.Button bt_flux;
        private System.ComponentModel.BackgroundWorker bw_transfert;
        private System.Windows.Forms.NotifyIcon notify_TRFT_client;
    }
}