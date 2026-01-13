namespace Painel_Admin
{
    partial class FormPerfilDetalhes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPerfilDetalhes));
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.IdAtivo = new System.Windows.Forms.Label();
            this.IdPlano = new System.Windows.Forms.Label();
            this.IdEmail = new System.Windows.Forms.Label();
            this.IdNome = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPlano = new System.Windows.Forms.Label();
            this.lblAtivo = new System.Windows.Forms.Label();
            this.grpEstatisticas = new System.Windows.Forms.GroupBox();
            this.IdCanalPreferido = new System.Windows.Forms.Label();
            this.IdLimitesProdutos = new System.Windows.Forms.Label();
            this.IdUltimoLogin = new System.Windows.Forms.Label();
            this.IdMembroDesde = new System.Windows.Forms.Label();
            this.IdDinheiro = new System.Windows.Forms.Label();
            this.IdNotificacoes = new System.Windows.Forms.Label();
            this.IdProdutos = new System.Windows.Forms.Label();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.lblNotificacoes = new System.Windows.Forms.Label();
            this.lblPoupado = new System.Windows.Forms.Label();
            this.lblMembroDesde = new System.Windows.Forms.Label();
            this.lblUltimoLogin = new System.Windows.Forms.Label();
            this.lblLimiteProdutos = new System.Windows.Forms.Label();
            this.lblCanalPreferido = new System.Windows.Forms.Label();
            this.grpPreferencias = new System.Windows.Forms.GroupBox();
            this.clbNotificacoes = new System.Windows.Forms.CheckedListBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnEditarPerfil = new System.Windows.Forms.Button();
            this.grpInfo.SuspendLayout();
            this.grpEstatisticas.SuspendLayout();
            this.grpPreferencias.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.BackColor = System.Drawing.Color.White;
            this.grpInfo.Controls.Add(this.IdAtivo);
            this.grpInfo.Controls.Add(this.IdPlano);
            this.grpInfo.Controls.Add(this.IdEmail);
            this.grpInfo.Controls.Add(this.IdNome);
            this.grpInfo.Controls.Add(this.lblNome);
            this.grpInfo.Controls.Add(this.lblEmail);
            this.grpInfo.Controls.Add(this.lblPlano);
            this.grpInfo.Controls.Add(this.lblAtivo);
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpInfo.Location = new System.Drawing.Point(20, 20);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(360, 130);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Informações Pessoais";
            // 
            // IdAtivo
            // 
            this.IdAtivo.AutoSize = true;
            this.IdAtivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdAtivo.Location = new System.Drawing.Point(240, 100);
            this.IdAtivo.Name = "IdAtivo";
            this.IdAtivo.Size = new System.Drawing.Size(32, 15);
            this.IdAtivo.TabIndex = 9;
            this.IdAtivo.Text = "Sim";
            // 
            // IdPlano
            // 
            this.IdPlano.AutoSize = true;
            this.IdPlano.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdPlano.Location = new System.Drawing.Point(55, 100);
            this.IdPlano.Name = "IdPlano";
            this.IdPlano.Size = new System.Drawing.Size(43, 15);
            this.IdPlano.TabIndex = 8;
            this.IdPlano.Text = "PlanoX";
            // 
            // IdEmail
            // 
            this.IdEmail.AutoSize = true;
            this.IdEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdEmail.Location = new System.Drawing.Point(55, 50);
            this.IdEmail.Name = "IdEmail";
            this.IdEmail.Size = new System.Drawing.Size(122, 15);
            this.IdEmail.TabIndex = 4;
            this.IdEmail.Text = "usuario@email.com";
            // 
            // IdNome
            // 
            this.IdNome.AutoSize = true;
            this.IdNome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdNome.Location = new System.Drawing.Point(55, 25);
            this.IdNome.Name = "IdNome";
            this.IdNome.Size = new System.Drawing.Size(95, 15);
            this.IdNome.TabIndex = 2;
            this.IdNome.Text = "Nome Completo";
            // 
            // lblNome
            // 
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNome.Location = new System.Drawing.Point(10, 25);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(45, 23);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome:";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(10, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(43, 23);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            // 
            // lblPlano
            // 
            this.lblPlano.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPlano.Location = new System.Drawing.Point(10, 100);
            this.lblPlano.Name = "lblPlano";
            this.lblPlano.Size = new System.Drawing.Size(45, 23);
            this.lblPlano.TabIndex = 7;
            this.lblPlano.Text = "Plano:";
            // 
            // lblAtivo
            // 
            this.lblAtivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAtivo.Location = new System.Drawing.Point(200, 100);
            this.lblAtivo.Name = "lblAtivo";
            this.lblAtivo.Size = new System.Drawing.Size(45, 23);
            this.lblAtivo.TabIndex = 10;
            this.lblAtivo.Text = "Ativo:";
            // 
            // grpEstatisticas
            // 
            this.grpEstatisticas.BackColor = System.Drawing.Color.White;
            this.grpEstatisticas.Controls.Add(this.IdCanalPreferido);
            this.grpEstatisticas.Controls.Add(this.IdLimitesProdutos);
            this.grpEstatisticas.Controls.Add(this.IdUltimoLogin);
            this.grpEstatisticas.Controls.Add(this.IdMembroDesde);
            this.grpEstatisticas.Controls.Add(this.IdDinheiro);
            this.grpEstatisticas.Controls.Add(this.IdNotificacoes);
            this.grpEstatisticas.Controls.Add(this.IdProdutos);
            this.grpEstatisticas.Controls.Add(this.lblProdutos);
            this.grpEstatisticas.Controls.Add(this.lblNotificacoes);
            this.grpEstatisticas.Controls.Add(this.lblPoupado);
            this.grpEstatisticas.Controls.Add(this.lblMembroDesde);
            this.grpEstatisticas.Controls.Add(this.lblUltimoLogin);
            this.grpEstatisticas.Controls.Add(this.lblLimiteProdutos);
            this.grpEstatisticas.Controls.Add(this.lblCanalPreferido);
            this.grpEstatisticas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpEstatisticas.Location = new System.Drawing.Point(20, 160);
            this.grpEstatisticas.Name = "grpEstatisticas";
            this.grpEstatisticas.Size = new System.Drawing.Size(360, 170);
            this.grpEstatisticas.TabIndex = 1;
            this.grpEstatisticas.TabStop = false;
            this.grpEstatisticas.Text = "Estatísticas";
            // 
            // IdCanalPreferido
            // 
            this.IdCanalPreferido.AutoSize = true;
            this.IdCanalPreferido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdCanalPreferido.Location = new System.Drawing.Point(115, 150);
            this.IdCanalPreferido.Name = "IdCanalPreferido";
            this.IdCanalPreferido.Size = new System.Drawing.Size(46, 15);
            this.IdCanalPreferido.TabIndex = 13;
            this.IdCanalPreferido.Text = "Email";
            // 
            // IdLimitesProdutos
            // 
            this.IdLimitesProdutos.AutoSize = true;
            this.IdLimitesProdutos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdLimitesProdutos.Location = new System.Drawing.Point(130, 130);
            this.IdLimitesProdutos.Name = "IdLimitesProdutos";
            this.IdLimitesProdutos.Size = new System.Drawing.Size(13, 15);
            this.IdLimitesProdutos.TabIndex = 11;
            this.IdLimitesProdutos.Text = "5";
            // 
            // IdUltimoLogin
            // 
            this.IdUltimoLogin.AutoSize = true;
            this.IdUltimoLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdUltimoLogin.Location = new System.Drawing.Point(100, 110);
            this.IdUltimoLogin.Name = "IdUltimoLogin";
            this.IdUltimoLogin.Size = new System.Drawing.Size(64, 15);
            this.IdUltimoLogin.TabIndex = 9;
            this.IdUltimoLogin.Text = "01/01/2025";
            // 
            // IdMembroDesde
            // 
            this.IdMembroDesde.AutoSize = true;
            this.IdMembroDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdMembroDesde.Location = new System.Drawing.Point(110, 90);
            this.IdMembroDesde.Name = "IdMembroDesde";
            this.IdMembroDesde.Size = new System.Drawing.Size(64, 15);
            this.IdMembroDesde.TabIndex = 7;
            this.IdMembroDesde.Text = "01/01/2020";
            // 
            // IdDinheiro
            // 
            this.IdDinheiro.AutoSize = true;
            this.IdDinheiro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdDinheiro.ForeColor = System.Drawing.Color.ForestGreen;
            this.IdDinheiro.Location = new System.Drawing.Point(130, 65);
            this.IdDinheiro.Name = "IdDinheiro";
            this.IdDinheiro.Size = new System.Drawing.Size(50, 15);
            this.IdDinheiro.TabIndex = 5;
            this.IdDinheiro.Text = "€ 0.00";
            // 
            // IdNotificacoes
            // 
            this.IdNotificacoes.AutoSize = true;
            this.IdNotificacoes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdNotificacoes.Location = new System.Drawing.Point(140, 45);
            this.IdNotificacoes.Name = "IdNotificacoes";
            this.IdNotificacoes.Size = new System.Drawing.Size(13, 15);
            this.IdNotificacoes.TabIndex = 3;
            this.IdNotificacoes.Text = "0";
            // 
            // IdProdutos
            // 
            this.IdProdutos.AutoSize = true;
            this.IdProdutos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IdProdutos.Location = new System.Drawing.Point(155, 25);
            this.IdProdutos.Name = "IdProdutos";
            this.IdProdutos.Size = new System.Drawing.Size(13, 15);
            this.IdProdutos.TabIndex = 1;
            this.IdProdutos.Text = "0";
            // 
            // lblProdutos
            // 
            this.lblProdutos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProdutos.Location = new System.Drawing.Point(10, 25);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(150, 23);
            this.lblProdutos.TabIndex = 0;
            this.lblProdutos.Text = "Produtos monitorizados:";
            // 
            // lblNotificacoes
            // 
            this.lblNotificacoes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNotificacoes.Location = new System.Drawing.Point(10, 45);
            this.lblNotificacoes.Name = "lblNotificacoes";
            this.lblNotificacoes.Size = new System.Drawing.Size(140, 23);
            this.lblNotificacoes.TabIndex = 2;
            this.lblNotificacoes.Text = "Notificações enviadas:";
            // 
            // lblPoupado
            // 
            this.lblPoupado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPoupado.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPoupado.Location = new System.Drawing.Point(10, 65);
            this.lblPoupado.Name = "lblPoupado";
            this.lblPoupado.Size = new System.Drawing.Size(130, 23);
            this.lblPoupado.TabIndex = 4;
            this.lblPoupado.Text = "Dinheiro poupado:";
            // 
            // lblMembroDesde
            // 
            this.lblMembroDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMembroDesde.Location = new System.Drawing.Point(10, 90);
            this.lblMembroDesde.Name = "lblMembroDesde";
            this.lblMembroDesde.Size = new System.Drawing.Size(110, 23);
            this.lblMembroDesde.TabIndex = 6;
            this.lblMembroDesde.Text = "Membro desde:";
            // 
            // lblUltimoLogin
            // 
            this.lblUltimoLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUltimoLogin.Location = new System.Drawing.Point(10, 110);
            this.lblUltimoLogin.Name = "lblUltimoLogin";
            this.lblUltimoLogin.Size = new System.Drawing.Size(100, 23);
            this.lblUltimoLogin.TabIndex = 8;
            this.lblUltimoLogin.Text = "Último login:";
            // 
            // lblLimiteProdutos
            // 
            this.lblLimiteProdutos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLimiteProdutos.Location = new System.Drawing.Point(10, 130);
            this.lblLimiteProdutos.Name = "lblLimiteProdutos";
            this.lblLimiteProdutos.Size = new System.Drawing.Size(120, 23);
            this.lblLimiteProdutos.TabIndex = 10;
            this.lblLimiteProdutos.Text = "Limite de produtos:";
            // 
            // lblCanalPreferido
            // 
            this.lblCanalPreferido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCanalPreferido.Location = new System.Drawing.Point(10, 150);
            this.lblCanalPreferido.Name = "lblCanalPreferido";
            this.lblCanalPreferido.Size = new System.Drawing.Size(110, 23);
            this.lblCanalPreferido.TabIndex = 12;
            this.lblCanalPreferido.Text = "Canal preferido:";
            // 
            // grpPreferencias
            // 
            this.grpPreferencias.BackColor = System.Drawing.Color.White;
            this.grpPreferencias.Controls.Add(this.clbNotificacoes);
            this.grpPreferencias.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPreferencias.Location = new System.Drawing.Point(20, 340);
            this.grpPreferencias.Name = "grpPreferencias";
            this.grpPreferencias.Size = new System.Drawing.Size(360, 110);
            this.grpPreferencias.TabIndex = 2;
            this.grpPreferencias.TabStop = false;
            this.grpPreferencias.Text = "Preferências de Notificação";
            // 
            // clbNotificacoes
            // 
            this.clbNotificacoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbNotificacoes.CheckOnClick = true;
            this.clbNotificacoes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbNotificacoes.Items.AddRange(new object[] {
            "Email",
            "Discord"});
            this.clbNotificacoes.Location = new System.Drawing.Point(10, 25);
            this.clbNotificacoes.Name = "clbNotificacoes";
            this.clbNotificacoes.Size = new System.Drawing.Size(200, 38);
            this.clbNotificacoes.TabIndex = 0;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(20, 470);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(150, 35);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "💾 Salvar Preferências";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnEditarPerfil
            // 
            this.btnEditarPerfil.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEditarPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarPerfil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarPerfil.ForeColor = System.Drawing.Color.White;
            this.btnEditarPerfil.Location = new System.Drawing.Point(230, 470);
            this.btnEditarPerfil.Name = "btnEditarPerfil";
            this.btnEditarPerfil.Size = new System.Drawing.Size(150, 35);
            this.btnEditarPerfil.TabIndex = 4;
            this.btnEditarPerfil.Text = "✏️ Editar Perfil";
            this.btnEditarPerfil.UseVisualStyleBackColor = false;
            this.btnEditarPerfil.Click += new System.EventHandler(this.btnEditarPerfil_Click);
            // 
            // FormPerfilDetalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(400, 520);
            this.Controls.Add(this.btnEditarPerfil);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.grpPreferencias);
            this.Controls.Add(this.grpEstatisticas);
            this.Controls.Add(this.grpInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPerfilDetalhes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes do Perfil";
            this.Load += new System.EventHandler(this.FormPerfilDetalhes_Load);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpEstatisticas.ResumeLayout(false);
            this.grpEstatisticas.PerformLayout();
            this.grpPreferencias.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPlano;
        private System.Windows.Forms.Label lblAtivo;
        private System.Windows.Forms.Label IdNome;
        private System.Windows.Forms.Label IdEmail;
        private System.Windows.Forms.Label IdPlano;
        private System.Windows.Forms.Label IdAtivo;

        private System.Windows.Forms.GroupBox grpEstatisticas;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Label lblNotificacoes;
        private System.Windows.Forms.Label lblPoupado;
        private System.Windows.Forms.Label lblMembroDesde;
        private System.Windows.Forms.Label lblUltimoLogin;
        private System.Windows.Forms.Label lblLimiteProdutos;
        private System.Windows.Forms.Label lblCanalPreferido;
        private System.Windows.Forms.Label IdProdutos;
        private System.Windows.Forms.Label IdNotificacoes;
        private System.Windows.Forms.Label IdDinheiro;
        private System.Windows.Forms.Label IdMembroDesde;
        private System.Windows.Forms.Label IdUltimoLogin;
        private System.Windows.Forms.Label IdLimitesProdutos;
        private System.Windows.Forms.Label IdCanalPreferido;

        private System.Windows.Forms.GroupBox grpPreferencias;
        private System.Windows.Forms.CheckedListBox clbNotificacoes;

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnEditarPerfil;
    }
}
