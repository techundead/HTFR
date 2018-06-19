namespace HELIOS_TRANSFERT_Serveur
{
    partial class WinParametrage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinParametrage));
            this.rb_client = new System.Windows.Forms.RadioButton();
            this.rb_modeServeur = new System.Windows.Forms.RadioButton();
            this.txt_mode = new System.Windows.Forms.Label();
            this.txt_base = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.Label();
            this.txt_mdp = new System.Windows.Forms.Label();
            this.tb_nom_base = new System.Windows.Forms.TextBox();
            this.tb_user_base = new System.Windows.Forms.TextBox();
            this.tb_mdp_base = new System.Windows.Forms.TextBox();
            this.bt_terminer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rb_client
            // 
            this.rb_client.AutoSize = true;
            this.rb_client.Location = new System.Drawing.Point(163, 29);
            this.rb_client.Name = "rb_client";
            this.rb_client.Size = new System.Drawing.Size(51, 17);
            this.rb_client.TabIndex = 0;
            this.rb_client.TabStop = true;
            this.rb_client.Text = "Client";
            this.rb_client.UseVisualStyleBackColor = true;
            // 
            // rb_modeServeur
            // 
            this.rb_modeServeur.AutoSize = true;
            this.rb_modeServeur.Location = new System.Drawing.Point(220, 29);
            this.rb_modeServeur.Name = "rb_modeServeur";
            this.rb_modeServeur.Size = new System.Drawing.Size(62, 17);
            this.rb_modeServeur.TabIndex = 1;
            this.rb_modeServeur.TabStop = true;
            this.rb_modeServeur.Text = "Serveur";
            this.rb_modeServeur.UseVisualStyleBackColor = true;
            // 
            // txt_mode
            // 
            this.txt_mode.AutoSize = true;
            this.txt_mode.Location = new System.Drawing.Point(121, 31);
            this.txt_mode.Name = "txt_mode";
            this.txt_mode.Size = new System.Drawing.Size(37, 13);
            this.txt_mode.TabIndex = 2;
            this.txt_mode.Text = "Mode:";
            // 
            // txt_base
            // 
            this.txt_base.AutoSize = true;
            this.txt_base.Location = new System.Drawing.Point(53, 59);
            this.txt_base.Name = "txt_base";
            this.txt_base.Size = new System.Drawing.Size(105, 13);
            this.txt_base.TabIndex = 3;
            this.txt_base.Text = "Nom Base ORACLE:";
            this.txt_base.Click += new System.EventHandler(this.txt_base_Click);
            // 
            // txt_user
            // 
            this.txt_user.AutoSize = true;
            this.txt_user.Location = new System.Drawing.Point(29, 86);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(129, 13);
            this.txt_user.TabIndex = 4;
            this.txt_user.Text = "Utilisateur Base ORACLE:";
            // 
            // txt_mdp
            // 
            this.txt_mdp.AutoSize = true;
            this.txt_mdp.Location = new System.Drawing.Point(10, 114);
            this.txt_mdp.Name = "txt_mdp";
            this.txt_mdp.Size = new System.Drawing.Size(148, 13);
            this.txt_mdp.TabIndex = 5;
            this.txt_mdp.Text = "Mot de Passe Base ORACLE:";
            // 
            // tb_nom_base
            // 
            this.tb_nom_base.Location = new System.Drawing.Point(163, 56);
            this.tb_nom_base.Name = "tb_nom_base";
            this.tb_nom_base.Size = new System.Drawing.Size(151, 20);
            this.tb_nom_base.TabIndex = 6;
            // 
            // tb_user_base
            // 
            this.tb_user_base.Location = new System.Drawing.Point(163, 83);
            this.tb_user_base.Name = "tb_user_base";
            this.tb_user_base.Size = new System.Drawing.Size(151, 20);
            this.tb_user_base.TabIndex = 7;
            // 
            // tb_mdp_base
            // 
            this.tb_mdp_base.Location = new System.Drawing.Point(163, 109);
            this.tb_mdp_base.Name = "tb_mdp_base";
            this.tb_mdp_base.Size = new System.Drawing.Size(151, 20);
            this.tb_mdp_base.TabIndex = 8;
            // 
            // bt_terminer
            // 
            this.bt_terminer.Location = new System.Drawing.Point(99, 152);
            this.bt_terminer.Name = "bt_terminer";
            this.bt_terminer.Size = new System.Drawing.Size(183, 37);
            this.bt_terminer.TabIndex = 9;
            this.bt_terminer.Text = "Terminer";
            this.bt_terminer.UseVisualStyleBackColor = true;
            this.bt_terminer.Click += new System.EventHandler(this.bt_terminer_Click);
            // 
            // WinParametrage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 204);
            this.Controls.Add(this.bt_terminer);
            this.Controls.Add(this.tb_mdp_base);
            this.Controls.Add(this.tb_user_base);
            this.Controls.Add(this.tb_nom_base);
            this.Controls.Add(this.txt_mdp);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.txt_base);
            this.Controls.Add(this.txt_mode);
            this.Controls.Add(this.rb_modeServeur);
            this.Controls.Add(this.rb_client);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(360, 243);
            this.MinimumSize = new System.Drawing.Size(360, 243);
            this.Name = "WinParametrage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Démarrage - HELIOS TRANSFERT";
            this.Load += new System.EventHandler(this.WinParametrage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_client;
        private System.Windows.Forms.RadioButton rb_modeServeur;
        private System.Windows.Forms.Label txt_mode;
        private System.Windows.Forms.Label txt_base;
        private System.Windows.Forms.Label txt_user;
        private System.Windows.Forms.Label txt_mdp;
        private System.Windows.Forms.TextBox tb_nom_base;
        private System.Windows.Forms.TextBox tb_user_base;
        private System.Windows.Forms.TextBox tb_mdp_base;
        private System.Windows.Forms.Button bt_terminer;
    }
}