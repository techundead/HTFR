namespace HELIOS_TRANSFERT_Serveur.Client
{
    partial class WinServeur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinServeur));
            this.gb_serveurFTP = new System.Windows.Forms.GroupBox();
            this.tb_mdpFTP = new System.Windows.Forms.TextBox();
            this.txt_mdpFTP = new System.Windows.Forms.Label();
            this.tb_portFTP = new System.Windows.Forms.TextBox();
            this.txt_portFTP = new System.Windows.Forms.Label();
            this.tb_idtfFTP = new System.Windows.Forms.TextBox();
            this.txt_idtfFTP = new System.Windows.Forms.Label();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_annuler = new System.Windows.Forms.Button();
            this.tb_adresseIP = new System.Windows.Forms.TextBox();
            this.gb_serveurHT = new System.Windows.Forms.GroupBox();
            this.tb_codeClient = new System.Windows.Forms.TextBox();
            this.txt_codeClient = new System.Windows.Forms.Label();
            this.tb_portTRFT = new System.Windows.Forms.TextBox();
            this.txt_portTRFT = new System.Windows.Forms.Label();
            this.txt_adresseIP = new System.Windows.Forms.Label();
            this.tb_codeServeur = new System.Windows.Forms.TextBox();
            this.txt_code_serveur = new System.Windows.Forms.Label();
            this.bt_valider = new System.Windows.Forms.Button();
            this.menu_WinServeur = new System.Windows.Forms.MenuStrip();
            this.dgv_serveurs = new System.Windows.Forms.DataGridView();
            this.gb_serveurFTP.SuspendLayout();
            this.gb_serveurHT.SuspendLayout();
            this.menu_WinServeur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_serveurs)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_serveurFTP
            // 
            this.gb_serveurFTP.Controls.Add(this.tb_mdpFTP);
            this.gb_serveurFTP.Controls.Add(this.txt_mdpFTP);
            this.gb_serveurFTP.Controls.Add(this.tb_portFTP);
            this.gb_serveurFTP.Controls.Add(this.txt_portFTP);
            this.gb_serveurFTP.Controls.Add(this.tb_idtfFTP);
            this.gb_serveurFTP.Controls.Add(this.txt_idtfFTP);
            this.gb_serveurFTP.Location = new System.Drawing.Point(314, 243);
            this.gb_serveurFTP.Name = "gb_serveurFTP";
            this.gb_serveurFTP.Size = new System.Drawing.Size(351, 135);
            this.gb_serveurFTP.TabIndex = 19;
            this.gb_serveurFTP.TabStop = false;
            this.gb_serveurFTP.Text = "Détails Serveur FTP";
            // 
            // tb_mdpFTP
            // 
            this.tb_mdpFTP.BackColor = System.Drawing.Color.White;
            this.tb_mdpFTP.Location = new System.Drawing.Point(86, 54);
            this.tb_mdpFTP.Name = "tb_mdpFTP";
            this.tb_mdpFTP.PasswordChar = '*';
            this.tb_mdpFTP.ReadOnly = true;
            this.tb_mdpFTP.Size = new System.Drawing.Size(225, 20);
            this.tb_mdpFTP.TabIndex = 13;
            // 
            // txt_mdpFTP
            // 
            this.txt_mdpFTP.AutoSize = true;
            this.txt_mdpFTP.Location = new System.Drawing.Point(6, 57);
            this.txt_mdpFTP.Name = "txt_mdpFTP";
            this.txt_mdpFTP.Size = new System.Drawing.Size(76, 13);
            this.txt_mdpFTP.TabIndex = 12;
            this.txt_mdpFTP.Text = "Mots de passe";
            // 
            // tb_portFTP
            // 
            this.tb_portFTP.BackColor = System.Drawing.Color.White;
            this.tb_portFTP.Location = new System.Drawing.Point(87, 80);
            this.tb_portFTP.Name = "tb_portFTP";
            this.tb_portFTP.ReadOnly = true;
            this.tb_portFTP.Size = new System.Drawing.Size(58, 20);
            this.tb_portFTP.TabIndex = 9;
            // 
            // txt_portFTP
            // 
            this.txt_portFTP.AutoSize = true;
            this.txt_portFTP.Location = new System.Drawing.Point(52, 83);
            this.txt_portFTP.Name = "txt_portFTP";
            this.txt_portFTP.Size = new System.Drawing.Size(26, 13);
            this.txt_portFTP.TabIndex = 8;
            this.txt_portFTP.Text = "Port";
            // 
            // tb_idtfFTP
            // 
            this.tb_idtfFTP.BackColor = System.Drawing.Color.White;
            this.tb_idtfFTP.Location = new System.Drawing.Point(87, 28);
            this.tb_idtfFTP.Name = "tb_idtfFTP";
            this.tb_idtfFTP.ReadOnly = true;
            this.tb_idtfFTP.Size = new System.Drawing.Size(224, 20);
            this.tb_idtfFTP.TabIndex = 7;
            // 
            // txt_idtfFTP
            // 
            this.txt_idtfFTP.AutoSize = true;
            this.txt_idtfFTP.Location = new System.Drawing.Point(29, 31);
            this.txt_idtfFTP.Name = "txt_idtfFTP";
            this.txt_idtfFTP.Size = new System.Drawing.Size(53, 13);
            this.txt_idtfFTP.TabIndex = 6;
            this.txt_idtfFTP.Text = "Identifiant";
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // bt_annuler
            // 
            this.bt_annuler.Location = new System.Drawing.Point(346, 385);
            this.bt_annuler.Name = "bt_annuler";
            this.bt_annuler.Size = new System.Drawing.Size(112, 23);
            this.bt_annuler.TabIndex = 21;
            this.bt_annuler.Text = "Annuler";
            this.bt_annuler.UseVisualStyleBackColor = true;
            this.bt_annuler.Visible = false;
            this.bt_annuler.Click += new System.EventHandler(this.bt_annuler_Click);
            // 
            // tb_adresseIP
            // 
            this.tb_adresseIP.BackColor = System.Drawing.Color.White;
            this.tb_adresseIP.Location = new System.Drawing.Point(86, 56);
            this.tb_adresseIP.Name = "tb_adresseIP";
            this.tb_adresseIP.ReadOnly = true;
            this.tb_adresseIP.Size = new System.Drawing.Size(204, 20);
            this.tb_adresseIP.TabIndex = 5;
            // 
            // gb_serveurHT
            // 
            this.gb_serveurHT.Controls.Add(this.tb_codeClient);
            this.gb_serveurHT.Controls.Add(this.txt_codeClient);
            this.gb_serveurHT.Controls.Add(this.tb_portTRFT);
            this.gb_serveurHT.Controls.Add(this.txt_portTRFT);
            this.gb_serveurHT.Controls.Add(this.tb_adresseIP);
            this.gb_serveurHT.Controls.Add(this.txt_adresseIP);
            this.gb_serveurHT.Controls.Add(this.tb_codeServeur);
            this.gb_serveurHT.Controls.Add(this.txt_code_serveur);
            this.gb_serveurHT.Location = new System.Drawing.Point(12, 243);
            this.gb_serveurHT.Name = "gb_serveurHT";
            this.gb_serveurHT.Size = new System.Drawing.Size(296, 135);
            this.gb_serveurHT.TabIndex = 17;
            this.gb_serveurHT.TabStop = false;
            this.gb_serveurHT.Text = "Détails Serveur HELIOS TRANSFERT";
            // 
            // tb_codeClient
            // 
            this.tb_codeClient.BackColor = System.Drawing.Color.White;
            this.tb_codeClient.Location = new System.Drawing.Point(86, 109);
            this.tb_codeClient.Name = "tb_codeClient";
            this.tb_codeClient.ReadOnly = true;
            this.tb_codeClient.Size = new System.Drawing.Size(58, 20);
            this.tb_codeClient.TabIndex = 11;
            // 
            // txt_codeClient
            // 
            this.txt_codeClient.AutoSize = true;
            this.txt_codeClient.Location = new System.Drawing.Point(17, 112);
            this.txt_codeClient.Name = "txt_codeClient";
            this.txt_codeClient.Size = new System.Drawing.Size(61, 13);
            this.txt_codeClient.TabIndex = 10;
            this.txt_codeClient.Text = "Code Client";
            // 
            // tb_portTRFT
            // 
            this.tb_portTRFT.BackColor = System.Drawing.Color.White;
            this.tb_portTRFT.Location = new System.Drawing.Point(86, 82);
            this.tb_portTRFT.Name = "tb_portTRFT";
            this.tb_portTRFT.ReadOnly = true;
            this.tb_portTRFT.Size = new System.Drawing.Size(58, 20);
            this.tb_portTRFT.TabIndex = 9;
            // 
            // txt_portTRFT
            // 
            this.txt_portTRFT.AutoSize = true;
            this.txt_portTRFT.Location = new System.Drawing.Point(52, 85);
            this.txt_portTRFT.Name = "txt_portTRFT";
            this.txt_portTRFT.Size = new System.Drawing.Size(26, 13);
            this.txt_portTRFT.TabIndex = 8;
            this.txt_portTRFT.Text = "Port";
            // 
            // txt_adresseIP
            // 
            this.txt_adresseIP.AutoSize = true;
            this.txt_adresseIP.Location = new System.Drawing.Point(20, 56);
            this.txt_adresseIP.Name = "txt_adresseIP";
            this.txt_adresseIP.Size = new System.Drawing.Size(58, 13);
            this.txt_adresseIP.TabIndex = 4;
            this.txt_adresseIP.Text = "Adresse IP";
            // 
            // tb_codeServeur
            // 
            this.tb_codeServeur.BackColor = System.Drawing.Color.White;
            this.tb_codeServeur.Location = new System.Drawing.Point(86, 30);
            this.tb_codeServeur.Name = "tb_codeServeur";
            this.tb_codeServeur.ReadOnly = true;
            this.tb_codeServeur.Size = new System.Drawing.Size(58, 20);
            this.tb_codeServeur.TabIndex = 3;
            // 
            // txt_code_serveur
            // 
            this.txt_code_serveur.AutoSize = true;
            this.txt_code_serveur.Location = new System.Drawing.Point(6, 33);
            this.txt_code_serveur.Name = "txt_code_serveur";
            this.txt_code_serveur.Size = new System.Drawing.Size(72, 13);
            this.txt_code_serveur.TabIndex = 1;
            this.txt_code_serveur.Text = "Code Serveur";
            // 
            // bt_valider
            // 
            this.bt_valider.Location = new System.Drawing.Point(170, 384);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Size = new System.Drawing.Size(112, 23);
            this.bt_valider.TabIndex = 20;
            this.bt_valider.Text = "Valider";
            this.bt_valider.UseVisualStyleBackColor = true;
            this.bt_valider.Visible = false;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // menu_WinServeur
            // 
            this.menu_WinServeur.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.menu_WinServeur.Location = new System.Drawing.Point(0, 0);
            this.menu_WinServeur.Name = "menu_WinServeur";
            this.menu_WinServeur.Size = new System.Drawing.Size(671, 24);
            this.menu_WinServeur.TabIndex = 18;
            this.menu_WinServeur.Text = "menuStrip1";
            // 
            // dgv_serveurs
            // 
            this.dgv_serveurs.AllowUserToAddRows = false;
            this.dgv_serveurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_serveurs.Location = new System.Drawing.Point(8, 27);
            this.dgv_serveurs.Name = "dgv_serveurs";
            this.dgv_serveurs.ReadOnly = true;
            this.dgv_serveurs.Size = new System.Drawing.Size(657, 210);
            this.dgv_serveurs.TabIndex = 23;
            this.dgv_serveurs.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_serveurs_RowEnter);
            // 
            // WinServeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 420);
            this.Controls.Add(this.dgv_serveurs);
            this.Controls.Add(this.gb_serveurFTP);
            this.Controls.Add(this.bt_annuler);
            this.Controls.Add(this.gb_serveurHT);
            this.Controls.Add(this.bt_valider);
            this.Controls.Add(this.menu_WinServeur);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(687, 459);
            this.MinimumSize = new System.Drawing.Size(687, 459);
            this.Name = "WinServeur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serveurs - HELIOS TRANSFERT";
            this.Load += new System.EventHandler(this.WinServeur_Load);
            this.gb_serveurFTP.ResumeLayout(false);
            this.gb_serveurFTP.PerformLayout();
            this.gb_serveurHT.ResumeLayout(false);
            this.gb_serveurHT.PerformLayout();
            this.menu_WinServeur.ResumeLayout(false);
            this.menu_WinServeur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_serveurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_serveurFTP;
        private System.Windows.Forms.TextBox tb_mdpFTP;
        private System.Windows.Forms.Label txt_mdpFTP;
        private System.Windows.Forms.TextBox tb_portFTP;
        private System.Windows.Forms.Label txt_portFTP;
        private System.Windows.Forms.TextBox tb_idtfFTP;
        private System.Windows.Forms.Label txt_idtfFTP;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.Button bt_annuler;
        private System.Windows.Forms.TextBox tb_adresseIP;
        private System.Windows.Forms.GroupBox gb_serveurHT;
        private System.Windows.Forms.TextBox tb_portTRFT;
        private System.Windows.Forms.Label txt_portTRFT;
        private System.Windows.Forms.Label txt_adresseIP;
        private System.Windows.Forms.TextBox tb_codeServeur;
        private System.Windows.Forms.Label txt_code_serveur;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.MenuStrip menu_WinServeur;
        private System.Windows.Forms.TextBox tb_codeClient;
        private System.Windows.Forms.Label txt_codeClient;
        private System.Windows.Forms.DataGridView dgv_serveurs;
    }
}