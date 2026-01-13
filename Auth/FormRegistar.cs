using BCrypt.Net;
using MySql.Data.MySqlClient;
using Painel_Admin.Auth;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Painel_Admin
{
    public partial class FormRegistar : Form
    {
        private bool senhaVisivel = false;

        public FormRegistar()
        {
            InitializeComponent();
        }

        private void FormRegistar_Load(object sender, EventArgs e)
        {
            TxtNome.Clear();
            TxtEmail.Clear();
            TxtSenha.Clear();
            TxtSenha.PasswordChar = '•';
        }

        private void BotaoEntrar_Click(object sender, EventArgs e)
        {
            string nome = TxtNome.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string senha = TxtSenha.Text.Trim();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();

                    var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM utilizadores WHERE Email=@mail", con);
                    checkCmd.Parameters.AddWithValue("@mail", email);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Já existe um utilizador registado com este e-mail.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string query = @"INSERT INTO utilizadores 
                                    (Nome, Email, SenhaHash, Ativo, PerfilId, DataRegisto, EmailVerificado)
                                    VALUES (@nome, @mail, @senhaHash, 1, 2, NOW(), 1)";

                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@mail", email);
                        cmd.Parameters.AddWithValue("@senhaHash", senhaHash);
                        cmd.ExecuteNonQuery();
                    }
                }

                // ✅ Mensagem de sucesso
                MessageBox.Show($"Bem-vindo, {nome}!\nRegistro concluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                using (var formMain = new PainelForm())
                    formMain.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registar o utilizador:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarSenha_Click(object sender, EventArgs e)
        {
            senhaVisivel = !senhaVisivel;

            if (senhaVisivel)
            {
                TxtSenha.PasswordChar = '\0';
                btnMostrarSenha.Image = Properties.Resources.OlhoAberto;
            }
            else
            {
                TxtSenha.PasswordChar = '•';
                btnMostrarSenha.Image = Properties.Resources.OlhoFechado;
            }
        }

        private void BotaoLimpar_Click(object sender, EventArgs e)
        {
            TxtNome.Clear();
            TxtEmail.Clear();
            TxtSenha.Clear();
        }

        private void btnLogin(object sender, EventArgs e)
        {
            this.Hide();
            using (var login = new FormLogin())
                login.ShowDialog();
            this.Show();
        }

        private void suporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var suporte = new Suporte())
            {
                suporte.ShowDialog();
            }
        }
    }
}
