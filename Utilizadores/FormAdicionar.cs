using BCrypt.Net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Painel_Admin.Utilizadores
{
    public partial class FormAdicionar : Form
    {
        private readonly UtilizadorRepository _repo;

        public FormAdicionar()
        {
            InitializeComponent();
            _repo = new UtilizadorRepository();

            AtualizarCorBotaoAtivo();
            CarregarPlanos();

            if (CmbCanal.Items.Count > 0)
                CmbCanal.SelectedIndex = 0;

            if (ComboTipoUtilizador.Items.Count > 0)
                ComboTipoUtilizador.SelectedIndex = 1;
        }

        private void CarregarPlanos()
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    const string query = "SELECT Id, Nome FROM planos ORDER BY Preco ASC";

                    using (var cmd = new MySqlCommand(query, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var listaPlanos = new List<PlanoItem>();

                        while (reader.Read())
                        {
                            listaPlanos.Add(new PlanoItem
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome")
                            });
                        }

                        CmbPlano.DataSource = listaPlanos;
                        CmbPlano.DisplayMember = "Nome";
                        CmbPlano.ValueMember = "Id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar planos:\n{ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // fallback local
                CmbPlano.Items.Clear();
                CmbPlano.Items.AddRange(new object[] { "Free", "Basic", "Standard", "Premium" });
                if (CmbPlano.Items.Count > 0)
                    CmbPlano.SelectedIndex = 0;
            }
        }


        private void TxtNome_TextChanged(object sender, EventArgs e) { }
        private void TxtEmail_TextChanged(object sender, EventArgs e) { }
        private void TxtSenha_TextChanged(object sender, EventArgs e) { }
        private void CmbPlano_SelectedIndexChanged(object sender, EventArgs e) { }
        private void CmbCanal_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ClbNotificacoes_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ComboTipoUtilizador_SelectedIndexChanged(object sender, EventArgs e) { }

        private void ChkAtivo_CheckedChanged(object sender, EventArgs e)
        {
            ChkAtivo.Checked = !ChkAtivo.Checked;
            AtualizarCorBotaoAtivo();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = TxtNome.Text.Trim();
                string email = TxtEmail.Text.Trim();
                string senha = TxtSenha.Text.Trim();
                bool ativo = ChkAtivo.Checked;
                string canal = CmbCanal.SelectedItem?.ToString() ?? "email";
                string tipo = ComboTipoUtilizador.SelectedItem?.ToString() ?? "Utilizador";
                int perfilId = tipo == "Admin" ? 1 : 2;

                if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                {
                    MessageBox.Show("Por favor, preencha Nome, Email e Senha.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
                _repo.Add(nome, email, senhaHash, ativo, perfilId);

                string referenciaId = ObterReferenciaIdUtilizador(email);
                ConfigurarPlanoUtilizador(referenciaId, canal);
                ConfigurarPreferenciasNotificacao(referenciaId);

                MessageBox.Show("Utilizador adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar utilizador:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObterReferenciaIdUtilizador(string email)
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    const string query = "SELECT ReferenciaID FROM utilizadores WHERE Email = @email";

                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "";
                    }
                }
            }
            catch
            {
                return "";
            }
        }

        private void ConfigurarPlanoUtilizador(string referenciaId, string canalPreferido)
        {
            try
            {
                if (CmbPlano.SelectedValue == null)
                    return;

                int planoId = Convert.ToInt32(CmbPlano.SelectedValue);

                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();

                    const string query = @"
                INSERT INTO configutilizador 
                (ReferenciaID, PlanoAtualId, PlanoAtivoId, LimiteProdutos, HistoricoDias, CanalPreferido, NotificacoesEnviadas, HistoricoAtivo) 
                SELECT @refId, @planoId, @planoId, LimiteProdutos, HistoricoDias, @canal, 0, 1 
                FROM planos 
                WHERE Id = @planoId";

                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@refId", referenciaId);
                        cmd.Parameters.AddWithValue("@planoId", planoId);
                        cmd.Parameters.AddWithValue("@canal", canalPreferido);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao configurar plano:\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ConfigurarPreferenciasNotificacao(string referenciaId)
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();

                    foreach (var item in ClbNotificacoes.CheckedItems)
                    {
                        string tipo = item.ToString().ToLower();

                        const string query = @"
                            INSERT INTO preferenciasnotificacao (ReferenciaID, Tipo, Ativo)
                            SELECT @refId, @tipo, 1
                            WHERE NOT EXISTS (
                                SELECT 1 FROM preferenciasnotificacao WHERE ReferenciaID = @refId AND Tipo = @tipo
                            );";

                        using (var cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@refId", referenciaId);
                            cmd.Parameters.AddWithValue("@tipo", tipo);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (ClbNotificacoes.CheckedItems.Count == 0)
                    {
                        const string query = @"
                            INSERT INTO preferenciasnotificacao (ReferenciaID, Tipo, Ativo)
                            SELECT @refId, 'email', 1
                            WHERE NOT EXISTS (
                                SELECT 1 FROM preferenciasnotificacao WHERE ReferenciaID = @refId AND Tipo = 'email'
                            );";

                        using (var cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@refId", referenciaId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao configurar notificações:\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AtualizarCorBotaoAtivo()
        {
            if (ChkAtivo.Checked)
            {
                BtnAtivo.BackColor = System.Drawing.Color.SeaGreen;
                BtnAtivo.ForeColor = System.Drawing.Color.White;
                BtnAtivo.Text = "Ativo ✅";
            }
            else
            {
                BtnAtivo.BackColor = System.Drawing.Color.DarkGray;
                BtnAtivo.ForeColor = System.Drawing.Color.White;
                BtnAtivo.Text = "Inativo ❌";
            }
        }

        private void FormAdicionar_Load(object sender, EventArgs e) { }
    }
}
