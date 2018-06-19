namespace HELIOS_TRANSFERT_Serveur
{
    partial class HeliosTransfertServeur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeliosTransfertServeur));
            this.gbConnexion = new System.Windows.Forms.GroupBox();
            this.dgv_ConnexionEnCours = new System.Windows.Forms.DataGridView();
            this.connexionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.b_manageSrv = new System.Windows.Forms.Button();
            this.b_quitter = new System.Windows.Forms.Button();
            this.btn_clients = new System.Windows.Forms.Button();
            this.bt_flux = new System.Windows.Forms.Button();
            this.bt_parametre = new System.Windows.Forms.Button();
            this.gbConnexion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConnexionEnCours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connexionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConnexion
            // 
            this.gbConnexion.Controls.Add(this.dgv_ConnexionEnCours);
            this.gbConnexion.Location = new System.Drawing.Point(12, 12);
            this.gbConnexion.Name = "gbConnexion";
            this.gbConnexion.Size = new System.Drawing.Size(802, 204);
            this.gbConnexion.TabIndex = 1;
            this.gbConnexion.TabStop = false;
            this.gbConnexion.Text = "Connexion en cours";
            // 
            // dgv_ConnexionEnCours
            // 
            this.dgv_ConnexionEnCours.AllowUserToAddRows = false;
            this.dgv_ConnexionEnCours.AllowUserToDeleteRows = false;
            this.dgv_ConnexionEnCours.AutoGenerateColumns = false;
            this.dgv_ConnexionEnCours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ConnexionEnCours.DataSource = this.connexionBindingSource;
            this.dgv_ConnexionEnCours.Location = new System.Drawing.Point(0, 19);
            this.dgv_ConnexionEnCours.Name = "dgv_ConnexionEnCours";
            this.dgv_ConnexionEnCours.ReadOnly = true;
            this.dgv_ConnexionEnCours.Size = new System.Drawing.Size(796, 175);
            this.dgv_ConnexionEnCours.TabIndex = 4;
            // 
            // connexionBindingSource
            // 
            this.connexionBindingSource.DataSource = typeof(HeliosTransfert.Business.Dto.Connexion);
            // 
            // b_manageSrv
            // 
            this.b_manageSrv.Location = new System.Drawing.Point(880, 162);
            this.b_manageSrv.Name = "b_manageSrv";
            this.b_manageSrv.Size = new System.Drawing.Size(170, 44);
            this.b_manageSrv.TabIndex = 2;
            this.b_manageSrv.Text = "Démarrer Serveur";
            this.b_manageSrv.UseVisualStyleBackColor = true;
            this.b_manageSrv.Click += new System.EventHandler(this.b_manageSrv_Click);
            // 
            // b_quitter
            // 
            this.b_quitter.Location = new System.Drawing.Point(880, 319);
            this.b_quitter.Name = "b_quitter";
            this.b_quitter.Size = new System.Drawing.Size(170, 44);
            this.b_quitter.TabIndex = 3;
            this.b_quitter.Text = "Quitter";
            this.b_quitter.UseVisualStyleBackColor = true;
            this.b_quitter.Click += new System.EventHandler(this.b_quitter_Click);
            // 
            // btn_clients
            // 
            this.btn_clients.Location = new System.Drawing.Point(880, 31);
            this.btn_clients.Name = "btn_clients";
            this.btn_clients.Size = new System.Drawing.Size(170, 44);
            this.btn_clients.TabIndex = 4;
            this.btn_clients.Text = "Clients";
            this.btn_clients.UseVisualStyleBackColor = true;
            this.btn_clients.Click += new System.EventHandler(this.btn_clients_Click);
            // 
            // bt_flux
            // 
            this.bt_flux.Location = new System.Drawing.Point(880, 95);
            this.bt_flux.Name = "bt_flux";
            this.bt_flux.Size = new System.Drawing.Size(170, 44);
            this.bt_flux.TabIndex = 5;
            this.bt_flux.Text = "Flux";
            this.bt_flux.UseVisualStyleBackColor = true;
            this.bt_flux.Click += new System.EventHandler(this.bt_flux_Click);
            // 
            // bt_parametre
            // 
            this.bt_parametre.Location = new System.Drawing.Point(880, 239);
            this.bt_parametre.Name = "bt_parametre";
            this.bt_parametre.Size = new System.Drawing.Size(170, 44);
            this.bt_parametre.TabIndex = 6;
            this.bt_parametre.Text = "Paramètre";
            this.bt_parametre.UseVisualStyleBackColor = true;
            this.bt_parametre.Click += new System.EventHandler(this.bt_parametre_Click);
            // 
            // HeliosTransfertServeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 375);
            this.Controls.Add(this.bt_parametre);
            this.Controls.Add(this.bt_flux);
            this.Controls.Add(this.btn_clients);
            this.Controls.Add(this.b_quitter);
            this.Controls.Add(this.b_manageSrv);
            this.Controls.Add(this.gbConnexion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1099, 414);
            this.MinimumSize = new System.Drawing.Size(1099, 414);
            this.Name = "HeliosTransfertServeur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serveur - HELIOS TRANSFERT";
            this.Load += new System.EventHandler(this.HeliosTransfertServeur_Load);
            this.gbConnexion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConnexionEnCours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connexionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConnexion;
        private System.Windows.Forms.Button b_manageSrv;
        private System.Windows.Forms.Button b_quitter;
        private System.Windows.Forms.DataGridView dgv_ConnexionEnCours;
        private System.Windows.Forms.BindingSource connexionBindingSource;
        private System.Windows.Forms.Button btn_clients;
        private System.Windows.Forms.Button bt_flux;
        private System.Windows.Forms.Button bt_parametre;
    }
}