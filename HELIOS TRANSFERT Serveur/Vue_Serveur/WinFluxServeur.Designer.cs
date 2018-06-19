namespace HELIOS_TRANSFERT_Serveur.Serveur
{
    partial class WinFluxServeur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinFluxServeur));
            this.dgv_flux = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_flux = new System.Windows.Forms.GroupBox();
            this.bt_choisirChemin = new System.Windows.Forms.Button();
            this.txt_designation = new System.Windows.Forms.Label();
            this.tb_cheminLocal = new System.Windows.Forms.TextBox();
            this.txt_cheminLocal = new System.Windows.Forms.Label();
            this.tb_designation = new System.Windows.Forms.TextBox();
            this.tb_codeFlux = new System.Windows.Forms.TextBox();
            this.txt_code_client = new System.Windows.Forms.Label();
            this.bt_annuler = new System.Windows.Forms.Button();
            this.bt_valider = new System.Windows.Forms.Button();
            this.selectChemin = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_flux)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gb_flux.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_flux
            // 
            this.dgv_flux.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_flux.Location = new System.Drawing.Point(12, 33);
            this.dgv_flux.Name = "dgv_flux";
            this.dgv_flux.ReadOnly = true;
            this.dgv_flux.Size = new System.Drawing.Size(527, 124);
            this.dgv_flux.TabIndex = 0;
            this.dgv_flux.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_flux_RowEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(556, 24);
            this.menuStrip1.TabIndex = 1;
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
            // gb_flux
            // 
            this.gb_flux.Controls.Add(this.bt_choisirChemin);
            this.gb_flux.Controls.Add(this.txt_designation);
            this.gb_flux.Controls.Add(this.tb_cheminLocal);
            this.gb_flux.Controls.Add(this.txt_cheminLocal);
            this.gb_flux.Controls.Add(this.tb_designation);
            this.gb_flux.Controls.Add(this.tb_codeFlux);
            this.gb_flux.Controls.Add(this.txt_code_client);
            this.gb_flux.Location = new System.Drawing.Point(12, 173);
            this.gb_flux.Name = "gb_flux";
            this.gb_flux.Size = new System.Drawing.Size(527, 140);
            this.gb_flux.TabIndex = 2;
            this.gb_flux.TabStop = false;
            this.gb_flux.Text = "Détails";
            this.gb_flux.Enter += new System.EventHandler(this.gb_flux_Enter);
            // 
            // bt_choisirChemin
            // 
            this.bt_choisirChemin.Location = new System.Drawing.Point(235, 99);
            this.bt_choisirChemin.Name = "bt_choisirChemin";
            this.bt_choisirChemin.Size = new System.Drawing.Size(112, 23);
            this.bt_choisirChemin.TabIndex = 18;
            this.bt_choisirChemin.Text = "Choisir un chemin";
            this.bt_choisirChemin.UseVisualStyleBackColor = true;
            this.bt_choisirChemin.Visible = false;
            this.bt_choisirChemin.Click += new System.EventHandler(this.bt_choisirChemin_Click);
            // 
            // txt_designation
            // 
            this.txt_designation.AutoSize = true;
            this.txt_designation.Location = new System.Drawing.Point(232, 50);
            this.txt_designation.Name = "txt_designation";
            this.txt_designation.Size = new System.Drawing.Size(63, 13);
            this.txt_designation.TabIndex = 13;
            this.txt_designation.Text = "Désignation";
            // 
            // tb_cheminLocal
            // 
            this.tb_cheminLocal.BackColor = System.Drawing.Color.White;
            this.tb_cheminLocal.Location = new System.Drawing.Point(118, 73);
            this.tb_cheminLocal.Name = "tb_cheminLocal";
            this.tb_cheminLocal.ReadOnly = true;
            this.tb_cheminLocal.Size = new System.Drawing.Size(379, 20);
            this.tb_cheminLocal.TabIndex = 12;
            // 
            // txt_cheminLocal
            // 
            this.txt_cheminLocal.AutoSize = true;
            this.txt_cheminLocal.Location = new System.Drawing.Point(8, 76);
            this.txt_cheminLocal.Name = "txt_cheminLocal";
            this.txt_cheminLocal.Size = new System.Drawing.Size(104, 13);
            this.txt_cheminLocal.TabIndex = 11;
            this.txt_cheminLocal.Text = "Chemin de réception";
            // 
            // tb_designation
            // 
            this.tb_designation.BackColor = System.Drawing.Color.White;
            this.tb_designation.Location = new System.Drawing.Point(299, 47);
            this.tb_designation.Name = "tb_designation";
            this.tb_designation.ReadOnly = true;
            this.tb_designation.Size = new System.Drawing.Size(198, 20);
            this.tb_designation.TabIndex = 10;
            // 
            // tb_codeFlux
            // 
            this.tb_codeFlux.BackColor = System.Drawing.Color.White;
            this.tb_codeFlux.Location = new System.Drawing.Point(117, 47);
            this.tb_codeFlux.Name = "tb_codeFlux";
            this.tb_codeFlux.ReadOnly = true;
            this.tb_codeFlux.Size = new System.Drawing.Size(100, 20);
            this.tb_codeFlux.TabIndex = 9;
            // 
            // txt_code_client
            // 
            this.txt_code_client.AutoSize = true;
            this.txt_code_client.Location = new System.Drawing.Point(57, 50);
            this.txt_code_client.Name = "txt_code_client";
            this.txt_code_client.Size = new System.Drawing.Size(54, 13);
            this.txt_code_client.TabIndex = 8;
            this.txt_code_client.Text = "Code Flux";
            // 
            // bt_annuler
            // 
            this.bt_annuler.Location = new System.Drawing.Point(342, 320);
            this.bt_annuler.Name = "bt_annuler";
            this.bt_annuler.Size = new System.Drawing.Size(112, 23);
            this.bt_annuler.TabIndex = 17;
            this.bt_annuler.Text = "Annuler";
            this.bt_annuler.UseVisualStyleBackColor = true;
            this.bt_annuler.Visible = false;
            this.bt_annuler.Click += new System.EventHandler(this.bt_annuler_Click);
            // 
            // bt_valider
            // 
            this.bt_valider.Location = new System.Drawing.Point(87, 320);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Size = new System.Drawing.Size(112, 23);
            this.bt_valider.TabIndex = 16;
            this.bt_valider.Text = "Valider";
            this.bt_valider.UseVisualStyleBackColor = true;
            this.bt_valider.Visible = false;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // WinFluxServeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 355);
            this.Controls.Add(this.bt_annuler);
            this.Controls.Add(this.bt_valider);
            this.Controls.Add(this.gb_flux);
            this.Controls.Add(this.dgv_flux);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(572, 394);
            this.MinimumSize = new System.Drawing.Size(572, 394);
            this.Name = "WinFluxServeur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flux / Serveur - HELIOS TRANSFERT";
            this.Load += new System.EventHandler(this.WinFluxServeur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_flux)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gb_flux.ResumeLayout(false);
            this.gb_flux.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_flux;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.GroupBox gb_flux;
        private System.Windows.Forms.Button bt_annuler;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.Label txt_designation;
        private System.Windows.Forms.TextBox tb_cheminLocal;
        private System.Windows.Forms.Label txt_cheminLocal;
        private System.Windows.Forms.TextBox tb_designation;
        private System.Windows.Forms.TextBox tb_codeFlux;
        private System.Windows.Forms.Label txt_code_client;
        private System.Windows.Forms.FolderBrowserDialog selectChemin;
        private System.Windows.Forms.Button bt_choisirChemin;
    }
}