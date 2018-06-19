namespace HELIOS_TRANSFERT_Serveur.Serveur
{
    partial class WinParametreServeur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinParametreServeur));
            this.gb_parametre = new System.Windows.Forms.GroupBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.txt_cheminLocal = new System.Windows.Forms.Label();
            this.tb_adresseIp = new System.Windows.Forms.TextBox();
            this.txt_code_client = new System.Windows.Forms.Label();
            this.bt_annuler = new System.Windows.Forms.Button();
            this.bt_valider = new System.Windows.Forms.Button();
            this.menu_parametre = new System.Windows.Forms.MenuStrip();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_parametre.SuspendLayout();
            this.menu_parametre.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_parametre
            // 
            this.gb_parametre.Controls.Add(this.tb_port);
            this.gb_parametre.Controls.Add(this.txt_cheminLocal);
            this.gb_parametre.Controls.Add(this.tb_adresseIp);
            this.gb_parametre.Controls.Add(this.txt_code_client);
            this.gb_parametre.Location = new System.Drawing.Point(12, 25);
            this.gb_parametre.Name = "gb_parametre";
            this.gb_parametre.Size = new System.Drawing.Size(349, 100);
            this.gb_parametre.TabIndex = 3;
            this.gb_parametre.TabStop = false;
            this.gb_parametre.Text = "Détails";
            // 
            // tb_port
            // 
            this.tb_port.BackColor = System.Drawing.Color.White;
            this.tb_port.Location = new System.Drawing.Point(112, 66);
            this.tb_port.Name = "tb_port";
            this.tb_port.ReadOnly = true;
            this.tb_port.Size = new System.Drawing.Size(59, 20);
            this.tb_port.TabIndex = 12;
            this.tb_port.TextChanged += new System.EventHandler(this.tb_cheminLocal_TextChanged);
            // 
            // txt_cheminLocal
            // 
            this.txt_cheminLocal.AutoSize = true;
            this.txt_cheminLocal.Location = new System.Drawing.Point(68, 69);
            this.txt_cheminLocal.Name = "txt_cheminLocal";
            this.txt_cheminLocal.Size = new System.Drawing.Size(26, 13);
            this.txt_cheminLocal.TabIndex = 11;
            this.txt_cheminLocal.Text = "Port";
            this.txt_cheminLocal.Click += new System.EventHandler(this.txt_cheminLocal_Click);
            // 
            // tb_adresseIp
            // 
            this.tb_adresseIp.BackColor = System.Drawing.Color.White;
            this.tb_adresseIp.Location = new System.Drawing.Point(111, 40);
            this.tb_adresseIp.Name = "tb_adresseIp";
            this.tb_adresseIp.ReadOnly = true;
            this.tb_adresseIp.Size = new System.Drawing.Size(198, 20);
            this.tb_adresseIp.TabIndex = 9;
            this.tb_adresseIp.TextChanged += new System.EventHandler(this.tb_codeFlux_TextChanged);
            // 
            // txt_code_client
            // 
            this.txt_code_client.AutoSize = true;
            this.txt_code_client.Location = new System.Drawing.Point(40, 43);
            this.txt_code_client.Name = "txt_code_client";
            this.txt_code_client.Size = new System.Drawing.Size(58, 13);
            this.txt_code_client.TabIndex = 8;
            this.txt_code_client.Text = "Adresse IP";
            this.txt_code_client.Click += new System.EventHandler(this.txt_code_client_Click);
            // 
            // bt_annuler
            // 
            this.bt_annuler.Location = new System.Drawing.Point(209, 141);
            this.bt_annuler.Name = "bt_annuler";
            this.bt_annuler.Size = new System.Drawing.Size(112, 23);
            this.bt_annuler.TabIndex = 19;
            this.bt_annuler.Text = "Annuler";
            this.bt_annuler.UseVisualStyleBackColor = true;
            this.bt_annuler.Visible = false;
            this.bt_annuler.Click += new System.EventHandler(this.bt_annuler_Click);
            // 
            // bt_valider
            // 
            this.bt_valider.Location = new System.Drawing.Point(71, 141);
            this.bt_valider.Name = "bt_valider";
            this.bt_valider.Size = new System.Drawing.Size(112, 23);
            this.bt_valider.TabIndex = 18;
            this.bt_valider.Text = "Valider";
            this.bt_valider.UseVisualStyleBackColor = true;
            this.bt_valider.Visible = false;
            this.bt_valider.Click += new System.EventHandler(this.bt_valider_Click);
            // 
            // menu_parametre
            // 
            this.menu_parametre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifierToolStripMenuItem});
            this.menu_parametre.Location = new System.Drawing.Point(0, 0);
            this.menu_parametre.Name = "menu_parametre";
            this.menu_parametre.Size = new System.Drawing.Size(369, 24);
            this.menu_parametre.TabIndex = 20;
            this.menu_parametre.Text = "menuStrip1";
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // WinParametreServeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 176);
            this.Controls.Add(this.bt_annuler);
            this.Controls.Add(this.bt_valider);
            this.Controls.Add(this.gb_parametre);
            this.Controls.Add(this.menu_parametre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_parametre;
            this.MaximumSize = new System.Drawing.Size(385, 215);
            this.MinimumSize = new System.Drawing.Size(385, 215);
            this.Name = "WinParametreServeur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paramètre Serveur - HELIOS TRANSFERT";
            this.gb_parametre.ResumeLayout(false);
            this.gb_parametre.PerformLayout();
            this.menu_parametre.ResumeLayout(false);
            this.menu_parametre.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_parametre;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label txt_cheminLocal;
        private System.Windows.Forms.TextBox tb_adresseIp;
        private System.Windows.Forms.Label txt_code_client;
        private System.Windows.Forms.Button bt_annuler;
        private System.Windows.Forms.Button bt_valider;
        private System.Windows.Forms.MenuStrip menu_parametre;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
    }
}