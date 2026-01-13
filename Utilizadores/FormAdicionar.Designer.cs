namespace Painel_Admin.Utilizadores
{
    partial class FormAdicionar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer do Windows Forms

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdicionar));
            this.LblNome = new System.Windows.Forms.Label();
            this.TxtNome = new System.Windows.Forms.TextBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblSenha = new System.Windows.Forms.Label();
            this.TxtSenha = new System.Windows.Forms.TextBox();
            this.LblPlano = new System.Windows.Forms.Label();
            this.CmbPlano = new System.Windows.Forms.ComboBox();
            this.LblNotificacoes = new System.Windows.Forms.Label();
            this.ClbNotificacoes = new System.Windows.Forms.CheckedListBox();
            this.ChkAtivo = new System.Windows.Forms.CheckBox();
            this.BtnAtivo = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblCanal = new System.Windows.Forms.Label();
            this.CmbCanal = new System.Windows.Forms.ComboBox();
            this.LblTipo = new System.Windows.Forms.Label();
            this.ComboTipoUtilizador = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LblNome
            // 
            this.LblNome.AutoSize = true;
            this.LblNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LblNome.Location = new System.Drawing.Point(31, 38);
            this.LblNome.Name = "LblNome";
            this.LblNome.Size = new System.Drawing.Size(44, 15);
            this.LblNome.Text = "&Nome:";
            // 
            // TxtNome
            // 
            this.TxtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNome.Location = new System.Drawing.Point(126, 35);
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.Size = new System.Drawing.Size(250, 23);
            this.TxtNome.TextChanged += new System.EventHandler(this.TxtNome_TextChanged);
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LblEmail.Location = new System.Drawing.Point(31, 78);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(39, 15);
            this.LblEmail.Text = "&Email:";
            // 
            // TxtEmail
            // 
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.Location = new System.Drawing.Point(126, 75);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(250, 23);
            this.TxtEmail.TextChanged += new System.EventHandler(this.TxtEmail_TextChanged);
            // 
            // LblSenha
            // 
            this.LblSenha.AutoSize = true;
            this.LblSenha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LblSenha.Location = new System.Drawing.Point(31, 118);
            this.LblSenha.Name = "LblSenha";
            this.LblSenha.Size = new System.Drawing.Size(44, 15);
            this.LblSenha.Text = "&Senha:";
            // 
            // TxtSenha
            // 
            this.TxtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSenha.Location = new System.Drawing.Point(126, 115);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.Size = new System.Drawing.Size(250, 23);
            this.TxtSenha.TextChanged += new System.EventHandler(this.TxtSenha_TextChanged);
            // 
            // LblPlano
            // 
            this.LblPlano.AutoSize = true;
            this.LblPlano.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LblPlano.Location = new System.Drawing.Point(31, 158);
            this.LblPlano.Name = "LblPlano";
            this.LblPlano.Size = new System.Drawing.Size(40, 15);
            this.LblPlano.Text = "&Plano:";
            // 
            // CmbPlano
            // 
            this.CmbPlano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPlano.FormattingEnabled = true;
            this.CmbPlano.Location = new System.Drawing.Point(126, 155);
            this.CmbPlano.Name = "CmbPlano";
            this.CmbPlano.Size = new System.Drawing.Size(250, 23);
            this.CmbPlano.SelectedIndexChanged += new System.EventHandler(this.CmbPlano_SelectedIndexChanged);
            // 
            // LblCanal
            // 
            this.LblCanal.AutoSize = true;
            this.LblCanal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LblCanal.Location = new System.Drawing.Point(31, 196);
            this.LblCanal.Name = "LblCanal";
            this.LblCanal.Size = new System.Drawing.Size(95, 15);
            this.LblCanal.Text = "&Canal preferido:";
            // 
            // CmbCanal
            // 
            this.CmbCanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCanal.FormattingEnabled = true;
            this.CmbCanal.Items.AddRange(new object[] { "email", "discord" });
            this.CmbCanal.Location = new System.Drawing.Point(126, 193);
            this.CmbCanal.Name = "CmbCanal";
            this.CmbCanal.Size = new System.Drawing.Size(250, 23);
            this.CmbCanal.SelectedIndexChanged += new System.EventHandler(this.CmbCanal_SelectedIndexChanged);
            // 
            // LblNotificacoes
            // 
            this.LblNotificacoes.AutoSize = true;
            this.LblNotificacoes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LblNotificacoes.Location = new System.Drawing.Point(31, 232);
            this.LblNotificacoes.Name = "LblNotificacoes";
            this.LblNotificacoes.Size = new System.Drawing.Size(79, 15);
            this.LblNotificacoes.Text = "&Notificações:";
            // 
            // ClbNotificacoes
            // 
            this.ClbNotificacoes.CheckOnClick = true;
            this.ClbNotificacoes.Items.AddRange(new object[] { "Email", "Discord" });
            this.ClbNotificacoes.Location = new System.Drawing.Point(126, 230);
            this.ClbNotificacoes.Name = "ClbNotificacoes";
            this.ClbNotificacoes.Size = new System.Drawing.Size(250, 38);
            this.ClbNotificacoes.SelectedIndexChanged += new System.EventHandler(this.ClbNotificacoes_SelectedIndexChanged);
            // 
            // LblTipo
            // 
            this.LblTipo.AutoSize = true;
            this.LblTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LblTipo.Location = new System.Drawing.Point(31, 282);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Size = new System.Drawing.Size(91, 15);
            this.LblTipo.Text = "&Tipo Utilizador:";
            // 
            // ComboTipoUtilizador
            // 
            this.ComboTipoUtilizador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipoUtilizador.FormattingEnabled = true;
            this.ComboTipoUtilizador.Items.AddRange(new object[] { "Admin", "Utilizador" });
            this.ComboTipoUtilizador.Location = new System.Drawing.Point(126, 279);
            this.ComboTipoUtilizador.Name = "ComboTipoUtilizador";
            this.ComboTipoUtilizador.Size = new System.Drawing.Size(250, 23);
            this.ComboTipoUtilizador.SelectedIndexChanged += new System.EventHandler(this.ComboTipoUtilizador_SelectedIndexChanged);
            // 
            // BtnAtivo
            // 
            this.BtnAtivo.BackColor = System.Drawing.Color.DarkGray;
            this.BtnAtivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAtivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BtnAtivo.ForeColor = System.Drawing.Color.White;
            this.BtnAtivo.Location = new System.Drawing.Point(34, 320);
            this.BtnAtivo.Name = "BtnAtivo";
            this.BtnAtivo.Size = new System.Drawing.Size(90, 30);
            this.BtnAtivo.Text = "Inativo ❌";
            this.BtnAtivo.Click += new System.EventHandler(this.ChkAtivo_CheckedChanged);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalvar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BtnSalvar.ForeColor = System.Drawing.Color.White;
            this.BtnSalvar.Location = new System.Drawing.Point(145, 320);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(100, 30);
            this.BtnSalvar.Text = "💾 Salvar";
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(276, 320);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(100, 30);
            this.BtnCancelar.Text = "❌ Cancelar";
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FormAdicionar
            // 
            this.ClientSize = new System.Drawing.Size(420, 388);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.BtnAtivo);
            this.Controls.Add(this.ComboTipoUtilizador);
            this.Controls.Add(this.LblTipo);
            this.Controls.Add(this.ClbNotificacoes);
            this.Controls.Add(this.LblNotificacoes);
            this.Controls.Add(this.CmbCanal);
            this.Controls.Add(this.LblCanal);
            this.Controls.Add(this.CmbPlano);
            this.Controls.Add(this.LblPlano);
            this.Controls.Add(this.TxtSenha);
            this.Controls.Add(this.LblSenha);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.TxtNome);
            this.Controls.Add(this.LblNome);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Utilizador";
            this.Load += new System.EventHandler(this.FormAdicionar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label LblNome;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label LblSenha;
        private System.Windows.Forms.TextBox TxtSenha;
        private System.Windows.Forms.Label LblPlano;
        private System.Windows.Forms.ComboBox CmbPlano;
        private System.Windows.Forms.Label LblCanal;
        private System.Windows.Forms.ComboBox CmbCanal;
        private System.Windows.Forms.Label LblNotificacoes;
        private System.Windows.Forms.CheckedListBox ClbNotificacoes;
        private System.Windows.Forms.Label LblTipo;
        private System.Windows.Forms.ComboBox ComboTipoUtilizador;
        private System.Windows.Forms.Button BtnAtivo;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.CheckBox ChkAtivo;
    }
}
