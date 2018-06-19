namespace HELIOS_TRANSFERT_Serveur.Client
{
    partial class WinFlux
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinFlux));
            this.tb_designation = new System.Windows.Forms.TextBox();
            this.txt_designation = new System.Windows.Forms.Label();
            this.tb_codeFlux = new System.Windows.Forms.TextBox();
            this.txt_code_flux = new System.Windows.Forms.Label();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_annuler = new System.Windows.Forms.Button();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv_Flux = new System.Windows.Forms.DataGridView();
            this.gb_serveurHT = new System.Windows.Forms.GroupBox();
            this.bt_valider = new System.Windows.Forms.Button();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_WinServeur = new System.Windows.Forms.MenuStrip();
            this.listeFluxServeursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectchemin = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Flux)).BeginInit();
            this.gb_serveurHT.SuspendLayout();
            this.menu_WinServeur.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_designation
            // 
            this.tb_designation.BackColor = System.Drawing.Color.White;
            this.tb_designation.Location = new System.Drawing.Point(85, 49);
            this.tb_designation.Name = "tb_designation";
            this.tb_designation.ReadOnly = true;
            this.tb_designation.Size = new System.Drawing.Size(240, 20);
            this.tb_designation.TabIndex = 9;
            // 
            // txt_designation
            // 
            this.txt_designation.AutoSize = true;
            this.txt_designation.Location = new System.Drawing.Point(16, 52);
            this.txt_designation.Name = "txt_designation";
            this.txt_designation.Size = new System.Drawing.Size(63, 13);
            this.txt_designation.TabIndex = 8;
            this.txt_designation.Text = "Désignation";
            // 
            // tb_codeFlux
            // 
            this.tb_codeFlux.BackColor = System.Drawing.Color.White;
            this.tb_codeFlux.Location = new System.Drawing.Point(85, 19);
            this.tb_codeFlux.Name = "tb_codeFlux";
            this.tb_codeFlux.ReadOnly = true;
            this.tb_codeFlux.Size = new System.Drawing.Size(69, 20);
            this.tb_codeFlux.TabIndex = 3;
            // 
            // txt_code_flux
            // 
            this.txt_code_flux.AutoSize = true;
            this.txt_code_flux.Location = new System.Drawing.Point(25, 22);
            this.txt_code_flux.Name = "txt_code_flux";
            this.txt_code_flux.Size = new System.Drawing.Size(54, 13);
            this.txt_code_flux.TabIndex = 1;
            this.txt_code_flux.Text = "Code Flux";
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
            this.bt_annuler.Location = new System.Drawing.Point(225, 299);
            this.bt_annuler.Name = "bt_annuler";
            this.bt_annuler.Size = new System.Drawing.Size(112, 23);
            this.bt_annuler.TabIndex = 27;
            this.bt_annuler.Text = "Annuler";
            this.bt_annuler.UseVisualStyleBackColor = true;
            this.bt_annuler.Visible = false;
            this.bt_annuler.Click += new System.EventHandler(this.bt_annuler_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // dgv_Flux
            // 
            this.dgv_Flux.AllowUserToAddRows = false;
            this.dgv_Flux.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Flux.Location = new System.Drawing.Point(12, 27);
            this.dgv_Flux.Name = "dgv_Flux";
            this.dgv_Flux.ReadOnly = true;
            this.dgv_Flux.Size = new System.Drawing.Size(357, 175);
            this.dgv_Flux.TabIndex = 22;
            this.dgv_Flux.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_flux_RowEnter);
            // 
            // gb_serveurHT
            // 
            this.gb_serveurHT.Controls.Add(this.tb_designation);
            this.gb_serveurHT.Controls.Add(this.txt_designation);
            this.gb_serveurHT.Controls.Add(this.tb_codeFlux);
            this.gb_serveurHT.Controls.Add(this.txt_code_flux);
            this.gb_serveurHT.Location = new System.Drawing.Point(12, 209);
            this.gb_serveurHT.Name = "gb_serveurHT";
            this.gb_serveurHT.Size = new System.Drawing.Size(357, 84);
            this.gb_serveurHT.TabIndex = 23;
            this.gb_serveurHT.TabStop = false;
            this.gb_serveurHT.Text = "Détails ";
            // 
            // bt_valider
            // 
            this.bt_valider.Location = new System.Drawing.Point(42, 299);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Size = new System.Drawing.Size(112, 23);
            this.bt_valider.TabIndex = 26;
            this.bt_valider.Text = "Valider";
            this.bt_valider.UseVisualStyleBackColor = true;
            this.bt_valider.Visible = false;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // menu_WinServeur
            // 
            this.menu_WinServeur.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem,
            this.listeFluxServeursToolStripMenuItem});
            this.menu_WinServeur.Location = new System.Drawing.Point(0, 0);
            this.menu_WinServeur.Name = "menu_WinServeur";
            this.menu_WinServeur.Size = new System.Drawing.Size(379, 24);
            this.menu_WinServeur.TabIndex = 24;
            this.menu_WinServeur.Text = "menuStrip1";
            // 
            // listeFluxServeursToolStripMenuItem
            // 
            this.listeFluxServeursToolStripMenuItem.Name = "listeFluxServeursToolStripMenuItem";
            this.listeFluxServeursToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.listeFluxServeursToolStripMenuItem.Text = "Liste Flux Serveurs";
            this.listeFluxServeursToolStripMenuItem.Click += new System.EventHandler(this.listeFluxServeursToolStripMenuItem_Click);
            // 
            // selectchemin
            // 
            this.selectchemin.FileName = "selectchemin";
            // 
            // WinFlux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 328);
            this.Controls.Add(this.bt_annuler);
            this.Controls.Add(this.dgv_Flux);
            this.Controls.Add(this.gb_serveurHT);
            this.Controls.Add(this.bt_valider);
            this.Controls.Add(this.menu_WinServeur);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(395, 367);
            this.MinimumSize = new System.Drawing.Size(395, 367);
            this.Name = "WinFlux";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flux - HELIOS TRANSFERT";
            this.Load += new System.EventHandler(this.WinFlux_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Flux)).EndInit();
            this.gb_serveurHT.ResumeLayout(false);
            this.gb_serveurHT.PerformLayout();
            this.menu_WinServeur.ResumeLayout(false);
            this.menu_WinServeur.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_designation;
        private System.Windows.Forms.Label txt_designation;
        private System.Windows.Forms.TextBox tb_codeFlux;
        private System.Windows.Forms.Label txt_code_flux;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.Button bt_annuler;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv_Flux;
        private System.Windows.Forms.GroupBox gb_serveurHT;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menu_WinServeur;
        private System.Windows.Forms.OpenFileDialog selectchemin;
        private System.Windows.Forms.ToolStripMenuItem listeFluxServeursToolStripMenuItem;
    }
}