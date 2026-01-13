namespace Painel_Admin
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BotaoEntrar = new System.Windows.Forms.Button();
            this.TxtSenha = new System.Windows.Forms.TextBox();
            this.btnMostrarSenha = new System.Windows.Forms.PictureBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegistrar = new System.Windows.Forms.ToolStripMenuItem();
            this.suporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BotaoLimpar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMostrarSenha)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(98, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // TxtNome
            // 
            this.TxtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNome.Location = new System.Drawing.Point(66, 158);
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.Size = new System.Drawing.Size(175, 22);
            this.TxtNome.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email";
            // 
            // BotaoEntrar
            // 
            this.BotaoEntrar.BackColor = System.Drawing.Color.Orange;
            this.BotaoEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BotaoEntrar.ForeColor = System.Drawing.Color.White;
            this.BotaoEntrar.Location = new System.Drawing.Point(180, 230);
            this.BotaoEntrar.Name = "BotaoEntrar";
            this.BotaoEntrar.Size = new System.Drawing.Size(61, 23);
            this.BotaoEntrar.TabIndex = 0;
            this.BotaoEntrar.Text = "&Entrar";
            this.BotaoEntrar.UseVisualStyleBackColor = false;
            this.BotaoEntrar.Click += new System.EventHandler(this.BotaoEntrar_Click);
            // 
            // TxtSenha
            // 
            this.TxtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSenha.Location = new System.Drawing.Point(66, 194);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.Size = new System.Drawing.Size(150, 22);
            this.TxtSenha.TabIndex = 6;
            this.TxtSenha.UseSystemPasswordChar = true;
            // 
            // btnMostrarSenha
            // 
            this.btnMostrarSenha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarSenha.Image = global::Painel_Admin.Properties.Resources.OlhoFechado;
            this.btnMostrarSenha.Location = new System.Drawing.Point(222, 194);
            this.btnMostrarSenha.Name = "btnMostrarSenha";
            this.btnMostrarSenha.Size = new System.Drawing.Size(24, 22);
            this.btnMostrarSenha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMostrarSenha.TabIndex = 8;
            this.btnMostrarSenha.TabStop = false;
            this.btnMostrarSenha.Click += new System.EventHandler(this.btnMostrarSenha_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Orange;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.suporteToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(286, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegistrar});
            this.loginToolStripMenuItem.Image = global::Painel_Admin.Properties.Resources.Usuario;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.loginToolStripMenuItem.Text = "&Login";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Image = global::Painel_Admin.Properties.Resources.Usuario;
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(122, 22);
            this.btnRegistrar.Text = "&Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.AcessoRegistar);
            // 
            // suporteToolStripMenuItem
            // 
            this.suporteToolStripMenuItem.Image = global::Painel_Admin.Properties.Resources.Notificacoes;
            this.suporteToolStripMenuItem.Name = "suporteToolStripMenuItem";
            this.suporteToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.suporteToolStripMenuItem.Text = "&Suporte";
            this.suporteToolStripMenuItem.Click += new System.EventHandler(this.AcessarSuporte);
            // 
            // BotaoLimpar
            // 
            this.BotaoLimpar.BackColor = System.Drawing.Color.Orange;
            this.BotaoLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BotaoLimpar.ForeColor = System.Drawing.Color.White;
            this.BotaoLimpar.Location = new System.Drawing.Point(66, 230);
            this.BotaoLimpar.Name = "BotaoLimpar";
            this.BotaoLimpar.Size = new System.Drawing.Size(58, 23);
            this.BotaoLimpar.TabIndex = 7;
            this.BotaoLimpar.Text = "&Limpar";
            this.BotaoLimpar.UseVisualStyleBackColor = false;
            this.BotaoLimpar.Click += new System.EventHandler(this.BotaoLimpar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "&Senha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Email:";
            // 
            // FormLogin
            // 
            this.AcceptButton = this.BotaoEntrar;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(286, 293);
            this.Controls.Add(this.btnMostrarSenha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BotaoLimpar);
            this.Controls.Add(this.TxtSenha);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BotaoEntrar);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMostrarSenha)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BotaoEntrar;
        private System.Windows.Forms.TextBox TxtSenha;
        private System.Windows.Forms.PictureBox btnMostrarSenha;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnRegistrar;
        private System.Windows.Forms.ToolStripMenuItem suporteToolStripMenuItem;
        private System.Windows.Forms.Button BotaoLimpar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}
