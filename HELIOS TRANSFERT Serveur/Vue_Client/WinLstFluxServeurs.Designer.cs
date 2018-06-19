namespace HELIOS_TRANSFERT_Serveur.Client
{
    partial class WinLstFluxServeurs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinLstFluxServeurs));
            this.selectchemin = new System.Windows.Forms.OpenFileDialog();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_cheminLocal = new System.Windows.Forms.TextBox();
            this.cb_adresseIP = new System.Windows.Forms.ComboBox();
            this.bt_choisirChemin = new System.Windows.Forms.Button();
            this.txt_cheminFichier = new System.Windows.Forms.Label();
            this.bt_annuler = new System.Windows.Forms.Button();
            this.dgv_FluxServeurs = new System.Windows.Forms.DataGridView();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_serveurHT = new System.Windows.Forms.GroupBox();
            this.tb_designation = new System.Windows.Forms.TextBox();
            this.txt_designation = new System.Windows.Forms.Label();
            this.txt_adresseIP = new System.Windows.Forms.Label();
            this.tb_codeFlux = new System.Windows.Forms.TextBox();
            this.txt_code_flux = new System.Windows.Forms.Label();
            this.bt_valider = new System.Windows.Forms.Button();
            this.menu_WinServeur = new System.Windows.Forms.MenuStrip();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FluxServeurs)).BeginInit();
            this.gb_serveurHT.SuspendLayout();
            this.menu_WinServeur.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectchemin
            // 
            this.selectchemin.FileName = "selectchemin";
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // tb_cheminLocal
            // 
            this.tb_cheminLocal.BackColor = System.Drawing.Color.White;
            this.tb_cheminLocal.Location = new System.Drawing.Point(67, 281);
            this.tb_cheminLocal.Name = "tb_cheminLocal";
            this.tb_cheminLocal.ReadOnly = true;
            this.tb_cheminLocal.Size = new System.Drawing.Size(373, 20);
            this.tb_cheminLocal.TabIndex = 20;
            // 
            // cb_adresseIP
            // 
            this.cb_adresseIP.FormattingEnabled = true;
            this.cb_adresseIP.Location = new System.Drawing.Point(67, 255);
            this.cb_adresseIP.Name = "cb_adresseIP";
            this.cb_adresseIP.Size = new System.Drawing.Size(192, 21);
            this.cb_adresseIP.TabIndex = 22;
            // 
            // bt_choisirChemin
            // 
            this.bt_choisirChemin.Location = new System.Drawing.Point(446, 279);
            this.bt_choisirChemin.Name = "bt_choisirChemin";
            this.bt_choisirChemin.Size = new System.Drawing.Size(112, 23);
            this.bt_choisirChemin.TabIndex = 21;
            this.bt_choisirChemin.Text = "Choisir un fichier";
            this.bt_choisirChemin.UseVisualStyleBackColor = true;
            this.bt_choisirChemin.Visible = false;
            this.bt_choisirChemin.Click += new System.EventHandler(this.bt_choisirChemin_Click);
            // 
            // txt_cheminFichier
            // 
            this.txt_cheminFichier.AutoSize = true;
            this.txt_cheminFichier.Location = new System.Drawing.Point(23, 284);
            this.txt_cheminFichier.Name = "txt_cheminFichier";
            this.txt_cheminFichier.Size = new System.Drawing.Size(38, 13);
            this.txt_cheminFichier.TabIndex = 19;
            this.txt_cheminFichier.Text = "Fichier";
            // 
            // bt_annuler
            // 
            this.bt_annuler.Location = new System.Drawing.Point(364, 350);
            this.bt_annuler.Name = "bt_annuler";
            this.bt_annuler.Size = new System.Drawing.Size(112, 23);
            this.bt_annuler.TabIndex = 32;
            this.bt_annuler.Text = "Annuler";
            this.bt_annuler.UseVisualStyleBackColor = true;
            this.bt_annuler.Visible = false;
            this.bt_annuler.Click += new System.EventHandler(this.bt_annuler_Click);
            // 
            // dgv_FluxServeurs
            // 
            this.dgv_FluxServeurs.AllowUserToAddRows = false;
            this.dgv_FluxServeurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FluxServeurs.Location = new System.Drawing.Point(7, 55);
            this.dgv_FluxServeurs.Name = "dgv_FluxServeurs";
            this.dgv_FluxServeurs.ReadOnly = true;
            this.dgv_FluxServeurs.Size = new System.Drawing.Size(551, 184);
            this.dgv_FluxServeurs.TabIndex = 28;
            this.dgv_FluxServeurs.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_FluxServeurs_RowEnter);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // gb_serveurHT
            // 
            this.gb_serveurHT.Controls.Add(this.tb_cheminLocal);
            this.gb_serveurHT.Controls.Add(this.dgv_FluxServeurs);
            this.gb_serveurHT.Controls.Add(this.cb_adresseIP);
            this.gb_serveurHT.Controls.Add(this.bt_choisirChemin);
            this.gb_serveurHT.Controls.Add(this.txt_cheminFichier);
            this.gb_serveurHT.Controls.Add(this.tb_designation);
            this.gb_serveurHT.Controls.Add(this.txt_designation);
            this.gb_serveurHT.Controls.Add(this.txt_adresseIP);
            this.gb_serveurHT.Controls.Add(this.tb_codeFlux);
            this.gb_serveurHT.Controls.Add(this.txt_code_flux);
            this.gb_serveurHT.Location = new System.Drawing.Point(12, 27);
            this.gb_serveurHT.Name = "gb_serveurHT";
            this.gb_serveurHT.Size = new System.Drawing.Size(564, 317);
            this.gb_serveurHT.TabIndex = 29;
            this.gb_serveurHT.TabStop = false;
            this.gb_serveurHT.Text = "Détails ";
            // 
            // tb_designation
            // 
            this.tb_designation.BackColor = System.Drawing.Color.White;
            this.tb_designation.Location = new System.Drawing.Point(253, 19);
            this.tb_designation.Name = "tb_designation";
            this.tb_designation.ReadOnly = true;
            this.tb_designation.Size = new System.Drawing.Size(279, 20);
            this.tb_designation.TabIndex = 9;
            // 
            // txt_designation
            // 
            this.txt_designation.AutoSize = true;
            this.txt_designation.Location = new System.Drawing.Point(184, 22);
            this.txt_designation.Name = "txt_designation";
            this.txt_designation.Size = new System.Drawing.Size(63, 13);
            this.txt_designation.TabIndex = 8;
            this.txt_designation.Text = "Désignation";
            // 
            // txt_adresseIP
            // 
            this.txt_adresseIP.AutoSize = true;
            this.txt_adresseIP.Location = new System.Drawing.Point(16, 259);
            this.txt_adresseIP.Name = "txt_adresseIP";
            this.txt_adresseIP.Size = new System.Drawing.Size(44, 13);
            this.txt_adresseIP.TabIndex = 4;
            this.txt_adresseIP.Text = "Serveur";
            // 
            // tb_codeFlux
            // 
            this.tb_codeFlux.BackColor = System.Drawing.Color.White;
            this.tb_codeFlux.Location = new System.Drawing.Point(109, 19);
            this.tb_codeFlux.Name = "tb_codeFlux";
            this.tb_codeFlux.ReadOnly = true;
            this.tb_codeFlux.Size = new System.Drawing.Size(69, 20);
            this.tb_codeFlux.TabIndex = 3;
            // 
            // txt_code_flux
            // 
            this.txt_code_flux.AutoSize = true;
            this.txt_code_flux.Location = new System.Drawing.Point(49, 22);
            this.txt_code_flux.Name = "txt_code_flux";
            this.txt_code_flux.Size = new System.Drawing.Size(54, 13);
            this.txt_code_flux.TabIndex = 1;
            this.txt_code_flux.Text = "Code Flux";
            // 
            // bt_valider
            // 
            this.bt_valider.Location = new System.Drawing.Point(102, 350);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Size = new System.Drawing.Size(112, 23);
            this.bt_valider.TabIndex = 31;
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
            this.menu_WinServeur.Size = new System.Drawing.Size(588, 24);
            this.menu_WinServeur.TabIndex = 30;
            this.menu_WinServeur.Text = "menuStrip1";
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // WinLstFluxServeurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 385);
            this.Controls.Add(this.bt_annuler);
            this.Controls.Add(this.gb_serveurHT);
            this.Controls.Add(this.bt_valider);
            this.Controls.Add(this.menu_WinServeur);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(604, 424);
            this.MinimumSize = new System.Drawing.Size(604, 424);
            this.Name = "WinLstFluxServeurs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flux / Serveurs - HELIOS TRANSFERT";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FluxServeurs)).EndInit();
            this.gb_serveurHT.ResumeLayout(false);
            this.gb_serveurHT.PerformLayout();
            this.menu_WinServeur.ResumeLayout(false);
            this.menu_WinServeur.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog selectchemin;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_cheminLocal;
        private System.Windows.Forms.ComboBox cb_adresseIP;
        private System.Windows.Forms.Button bt_choisirChemin;
        private System.Windows.Forms.Label txt_cheminFichier;
        private System.Windows.Forms.Button bt_annuler;
        private System.Windows.Forms.DataGridView dgv_FluxServeurs;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.GroupBox gb_serveurHT;
        private System.Windows.Forms.TextBox tb_designation;
        private System.Windows.Forms.Label txt_designation;
        private System.Windows.Forms.Label txt_adresseIP;
        private System.Windows.Forms.TextBox tb_codeFlux;
        private System.Windows.Forms.Label txt_code_flux;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.MenuStrip menu_WinServeur;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
    }
}