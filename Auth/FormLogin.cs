using MySql.Data.MySqlClient;
using Painel_Admin.Auth;
using System;
using System.Configuration;
using System.Windows.Forms;
using BCrypt.Net;

namespace Painel_Admin
{
    public partial class FormLogin : Form
    {
        private bool senhaVisivel = false;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            TxtNome.Clear();
            TxtSenha.Clear();
            TxtSenha.UseSystemPasswordChar = true;
            btnMostrarSenha.Image = Properties.Resources.OlhoFechado;
        }

        private void BotaoEntrar_Click(object sender, EventArgs e)
        {
            string email = TxtNome.Text.Trim();
            string password = TxtSenha.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();
                    string query = "SELECT ReferenciaID, Nome, Email, SenhaHash FROM utilizadores WHERE Email = @email";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string senhaDb = reader["SenhaHash"].ToString();

                                bool senhaCorreta =
                                    (senhaDb.StartsWith("$2a$") || senhaDb.StartsWith("$2b$") || senhaDb.StartsWith("$2y$"))
                                    ? BCrypt.Net.BCrypt.Verify(password, senhaDb)
                                    : password == senhaDb;

                                if (senhaCorreta)
                                {
                                    Sessao.UserId = reader["ReferenciaID"].ToString();
                                    Sessao.Nome = reader["Nome"].ToString();
                                    Sessao.Email = reader["Email"].ToString();

                                    MessageBox.Show($"Bem-vindo, {Sessao.Nome}!", "Login efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Hide();
                                    using (var formMain = new PainelForm())
                                        formMain.ShowDialog();
                                    this.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Senha incorreta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Utilizador não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao autenticar:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarSenha_Click(object sender, EventArgs e)
        {
            senhaVisivel = !senhaVisivel;

            if (senhaVisivel)
            {
                TxtSenha.UseSystemPasswordChar = false;
                btnMostrarSenha.Image = Properties.Resources.OlhoAberto;
            }
            else
            {
                TxtSenha.UseSystemPasswordChar = true;
                btnMostrarSenha.Image = Properties.Resources.OlhoFechado;
            }
        }

        private void BotaoLimpar_Click(object sender, EventArgs e)
        {
            TxtNome.Clear();
            TxtSenha.Clear();
        }

        private void AcessoRegistar(object sender, EventArgs e)
        {
            using (var formRegistar = new FormRegistar())
            {
                formRegistar.ShowDialog();
            }
        }

        private void AcessarSuporte(object sender, EventArgs e)
        {
            using (var formSuporte = new Suporte())
            {
                formSuporte.ShowDialog();
            }
        }
    }
}
