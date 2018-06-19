namespace HELIOS_TRANSFERT_Serveur.Serveur
{
    partial class WinClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinClient));
            this.dgv_clients = new System.Windows.Forms.DataGridView();
            this.gb_clients = new System.Windows.Forms.GroupBox();
            this.bt_annuler = new System.Windows.Forms.Button();
            this.bt_valider = new System.Windows.Forms.Button();
            this.tb_pays = new System.Windows.Forms.TextBox();
            this.txt_pays = new System.Windows.Forms.Label();
            this.tb_ville = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_codePostale = new System.Windows.Forms.TextBox();
            this.txt_codePostale = new System.Windows.Forms.Label();
            this.tb_adressePostale = new System.Windows.Forms.TextBox();
            this.txt_adressePostale = new System.Windows.Forms.Label();
            this.tb_raisonSocial = new System.Windows.Forms.TextBox();
            this.txt_raison_social = new System.Windows.Forms.Label();
            this.tb_codeClient = new System.Windows.Forms.TextBox();
            this.txt_code_client = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clients)).BeginInit();
            this.gb_clients.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_clients
            // 
            this.dgv_clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clients.Location = new System.Drawing.Point(12, 27);
            this.dgv_clients.Name = "dgv_clients";
            this.dgv_clients.ReadOnly = true;
            this.dgv_clients.Size = new System.Drawing.Size(664, 177);
            this.dgv_clients.TabIndex = 0;
            this.dgv_clients.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_clients_RowEnter);
            // 
            // gb_clients
            // 
            this.gb_clients.Controls.Add(this.bt_annuler);
            this.gb_clients.Controls.Add(this.bt_valider);
            this.gb_clients.Controls.Add(this.tb_pays);
            this.gb_clients.Controls.Add(this.txt_pays);
            this.gb_clients.Controls.Add(this.tb_ville);
            this.gb_clients.Controls.Add(this.label1);
            this.gb_clients.Controls.Add(this.tb_codePostale);
            this.gb_clients.Controls.Add(this.txt_codePostale);
            this.gb_clients.Controls.Add(this.tb_adressePostale);
            this.gb_clients.Controls.Add(this.txt_adressePostale);
            this.gb_clients.Controls.Add(this.tb_raisonSocial);
            this.gb_clients.Controls.Add(this.txt_raison_social);
            this.gb_clients.Controls.Add(this.tb_codeClient);
            this.gb_clients.Controls.Add(this.txt_code_client);
            this.gb_clients.Location = new System.Drawing.Point(9, 210);
            this.gb_clients.Name = "gb_clients";
            this.gb_clients.Size = new System.Drawing.Size(667, 173);
            this.gb_clients.TabIndex = 1;
            this.gb_clients.TabStop = false;
            this.gb_clients.Text = "Détails";
            this.gb_clients.Enter += new System.EventHandler(this.gb_clients_Enter);
            // 
            // bt_annuler
            // 
            this.bt_annuler.Location = new System.Drawing.Point(390, 138);
            this.bt_annuler.Name = "bt_annuler";
            this.bt_annuler.Size = new System.Drawing.Size(112, 23);
            this.bt_annuler.TabIndex = 15;
            this.bt_annuler.Text = "Annuler";
            this.bt_annuler.UseVisualStyleBackColor = true;
            this.bt_annuler.Visible = false;
            this.bt_annuler.Click += new System.EventHandler(this.bt_annuler_Click);
            // 
            // bt_valider
            // 
            this.bt_valider.Location = new System.Drawing.Point(135, 138);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Size = new System.Drawing.Size(112, 23);
            this.bt_valider.TabIndex = 14;
            this.bt_valider.Text = "Valider";
            this.bt_valider.UseVisualStyleBackColor = true;
            this.bt_valider.Visible = false;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // tb_pays
            // 
            this.tb_pays.BackColor = System.Drawing.Color.White;
            this.tb_pays.Location = new System.Drawing.Point(147, 94);
            this.tb_pays.Name = "tb_pays";
            this.tb_pays.ReadOnly = true;
            this.tb_pays.Size = new System.Drawing.Size(162, 20);
            this.tb_pays.TabIndex = 13;
            // 
            // txt_pays
            // 
            this.txt_pays.AutoSize = true;
            this.txt_pays.Location = new System.Drawing.Point(58, 97);
            this.txt_pays.Name = "txt_pays";
            this.txt_pays.Size = new System.Drawing.Size(30, 13);
            this.txt_pays.TabIndex = 12;
            this.txt_pays.Text = "Pays";
            // 
            // tb_ville
            // 
            this.tb_ville.BackColor = System.Drawing.Color.White;
            this.tb_ville.Location = new System.Drawing.Point(315, 68);
            this.tb_ville.Name = "tb_ville";
            this.tb_ville.ReadOnly = true;
            this.tb_ville.Size = new System.Drawing.Size(211, 20);
            this.tb_ville.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ville";
            // 
            // tb_codePostale
            // 
            this.tb_codePostale.BackColor = System.Drawing.Color.White;
            this.tb_codePostale.Location = new System.Drawing.Point(147, 68);
            this.tb_codePostale.Name = "tb_codePostale";
            this.tb_codePostale.ReadOnly = true;
            this.tb_codePostale.Size = new System.Drawing.Size(100, 20);
            this.tb_codePostale.TabIndex = 9;
            // 
            // txt_codePostale
            // 
            this.txt_codePostale.AutoSize = true;
            this.txt_codePostale.Location = new System.Drawing.Point(58, 71);
            this.txt_codePostale.Name = "txt_codePostale";
            this.txt_codePostale.Size = new System.Drawing.Size(69, 13);
            this.txt_codePostale.TabIndex = 8;
            this.txt_codePostale.Text = "Code postale";
            // 
            // tb_adressePostale
            // 
            this.tb_adressePostale.BackColor = System.Drawing.Color.White;
            this.tb_adressePostale.Location = new System.Drawing.Point(147, 42);
            this.tb_adressePostale.Name = "tb_adressePostale";
            this.tb_adressePostale.ReadOnly = true;
            this.tb_adressePostale.Size = new System.Drawing.Size(379, 20);
            this.tb_adressePostale.TabIndex = 7;
            // 
            // txt_adressePostale
            // 
            this.txt_adressePostale.AutoSize = true;
            this.txt_adressePostale.Location = new System.Drawing.Point(58, 45);
            this.txt_adressePostale.Name = "txt_adressePostale";
            this.txt_adressePostale.Size = new System.Drawing.Size(45, 13);
            this.txt_adressePostale.TabIndex = 6;
            this.txt_adressePostale.Text = "Adresse";
            // 
            // tb_raisonSocial
            // 
            this.tb_raisonSocial.BackColor = System.Drawing.Color.White;
            this.tb_raisonSocial.Location = new System.Drawing.Point(328, 19);
            this.tb_raisonSocial.Name = "tb_raisonSocial";
            this.tb_raisonSocial.ReadOnly = true;
            this.tb_raisonSocial.Size = new System.Drawing.Size(198, 20);
            this.tb_raisonSocial.TabIndex = 5;
            // 
            // txt_raison_social
            // 
            this.txt_raison_social.AutoSize = true;
            this.txt_raison_social.Location = new System.Drawing.Point(250, 22);
            this.txt_raison_social.Name = "txt_raison_social";
            this.txt_raison_social.Size = new System.Drawing.Size(72, 13);
            this.txt_raison_social.TabIndex = 4;
            this.txt_raison_social.Text = "Raison Social";
            // 
            // tb_codeClient
            // 
            this.tb_codeClient.BackColor = System.Drawing.Color.White;
            this.tb_codeClient.Location = new System.Drawing.Point(146, 16);
            this.tb_codeClient.Name = "tb_codeClient";
            this.tb_codeClient.ReadOnly = true;
            this.tb_codeClient.Size = new System.Drawing.Size(100, 20);
            this.tb_codeClient.TabIndex = 3;
            // 
            // txt_code_client
            // 
            this.txt_code_client.AutoSize = true;
            this.txt_code_client.Location = new System.Drawing.Point(58, 19);
            this.txt_code_client.Name = "txt_code_client";
            this.txt_code_client.Size = new System.Drawing.Size(61, 13);
            this.txt_code_client.TabIndex = 1;
            this.txt_code_client.Text = "Code Client";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // WinClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 395);
            this.Controls.Add(this.gb_clients);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgv_clients);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(701, 434);
            this.MinimumSize = new System.Drawing.Size(701, 434);
            this.Name = "WinClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clients - HELIOS TRANSFERT";
            this.Load += new System.EventHandler(this.WinClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clients)).EndInit();
            this.gb_clients.ResumeLayout(false);
            this.gb_clients.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_clients;
        private System.Windows.Forms.GroupBox gb_clients;
        private System.Windows.Forms.TextBox tb_codeClient;
        private System.Windows.Forms.Label txt_code_client;
        private System.Windows.Forms.TextBox tb_codePostale;
        private System.Windows.Forms.Label txt_codePostale;
        private System.Windows.Forms.TextBox tb_adressePostale;
        private System.Windows.Forms.Label txt_adressePostale;
        private System.Windows.Forms.TextBox tb_raisonSocial;
        private System.Windows.Forms.Label txt_raison_social;
        private System.Windows.Forms.TextBox tb_ville;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_pays;
        private System.Windows.Forms.Label txt_pays;
        private System.Windows.Forms.Button bt_annuler;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
    }
}