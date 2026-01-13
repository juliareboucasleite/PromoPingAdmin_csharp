using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Painel_Admin.Utilizadores;

namespace Painel_Admin
{
    public partial class FormPerfilEditar : Form
    {
        private string _userId; // ReferenciaID

        public FormPerfilEditar(string referenciaId, string nome, string email, string planoId, string canal, bool ativo)
        {
            InitializeComponent();
            _userId = referenciaId;

            txtNome.Text = nome;
            txtEmail.Text = email;
            chkAtivo.Checked = ativo;

            clbNotificacoes.Items.Clear();
            clbNotificacoes.Items.Add("Email", false);
            clbNotificacoes.Items.Add("Discord", false);

            AtualizarCorBotaoAtivo();
            CarregarPlanos();

            this.Load += (s, e) =>
            {
                SelecionarPlanoAtual(planoId);
                CarregarPreferencias();

                if (!string.IsNullOrEmpty(canal))
                    cmbCanal.SelectedItem = char.ToUpper(canal[0]) + canal.Substring(1);
            };
        }
        /// <summary>
        /// Carrega os planos disponíveis da base de dados e popula o ComboBox cmbPlano.
        /// </summary>
        private void CarregarPlanos()
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT Id, Nome FROM planos ORDER BY Preco ASC";

                    using (var cmd = new MySqlCommand(query, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var lista = new List<PlanoItem>();
                        while (reader.Read())
                        {
                            lista.Add(new PlanoItem
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome")
                            });
                        }

                        cmbPlano.DataSource = lista;
                        cmbPlano.DisplayMember = "Nome";
                        cmbPlano.ValueMember = "Id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar planos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Seleciona o plano atual do utilizador no ComboBox com base no ID fornecido.
        /// </summary>
        /// <param name="planoId"></param>
        private void SelecionarPlanoAtual(string planoId)
        {
            if (string.IsNullOrEmpty(planoId))
                return;

            if (int.TryParse(planoId, out int id))
            {
                cmbPlano.SelectedValue = id;
                if (cmbPlano.SelectedValue == null || (int)cmbPlano.SelectedValue != id)
                {
                    foreach (PlanoItem item in cmbPlano.Items)
                    {
                        if (item.Id == id)
                        {
                            cmbPlano.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Carrega as preferncias de notificações do utilizador e marca os itens correspondentes na CheckedListBox.
        /// </summary>
        private void CarregarPreferencias()
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT Tipo, Ativo FROM preferenciasnotificacao WHERE ReferenciaID=@refId";

                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@refId", _userId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tipo = reader["Tipo"].ToString();
                                bool ativo = Convert.ToInt32(reader["Ativo"]) == 1;

                                int index = clbNotificacoes.Items.IndexOf(char.ToUpper(tipo[0]) + tipo.Substring(1));
                                if (index >= 0)
                                    clbNotificacoes.SetItemChecked(index, ativo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar preferências: " + ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    var cmd = new MySqlCommand(@"
                        UPDATE utilizadores
                        SET Nome=@nome, 
                            Email=@mail, 
                            Ativo=@ativo
                        WHERE ReferenciaID=@refId;", con);

                    cmd.Parameters.AddWithValue("@refId", _userId);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@mail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@ativo", chkAtivo.Checked ? 1 : 0);
                    cmd.ExecuteNonQuery();

                    AtualizarPlanoUtilizador(con);
                    AtualizarCanalPreferido(con);
                    AtualizarPreferencias(con);
                }

                MessageBox.Show("Perfil atualizado com sucesso!", "Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }
        /// <summary>
        /// Atualiza o plano do utilizador na tabela configutilizador.
        /// </summary>
        /// <param name="con"></param>
        private void AtualizarPlanoUtilizador(MySqlConnection con)
        {
            try
            {
                if (cmbPlano.SelectedValue != null)
                {
                    int planoId = Convert.ToInt32(cmbPlano.SelectedValue);

                    // Verifica se já existe registro na configutilizador
                    var checkCmd = new MySqlCommand("SELECT PlanoAtualId FROM configutilizador WHERE ReferenciaID = @refId", con);
                    checkCmd.Parameters.AddWithValue("@refId", _userId);
                    var planoAtualObj = checkCmd.ExecuteScalar();
                    int planoAtual = planoAtualObj != DBNull.Value && planoAtualObj != null ? Convert.ToInt32(planoAtualObj) : -1;

                    if (planoAtual == -1)
                    {
                        // Novo registro
                        var insertCmd = new MySqlCommand(@"
                    INSERT INTO configutilizador 
                        (ReferenciaID, PlanoAtualId, PlanoAtivoId, LimiteProdutos, HistoricoDias, CanalPreferido, NotificacoesEnviadas, HistoricoAtivo, StatusAssinatura, DataInicio)
                    SELECT @refId, Id, Id, LimiteProdutos, HistoricoDias, 'email', 0, 1, 'Ativa', NOW()
                    FROM planos WHERE Id = @planoId;", con);

                        insertCmd.Parameters.AddWithValue("@refId", _userId);
                        insertCmd.Parameters.AddWithValue("@planoId", planoId);
                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Configuração criada e plano definido com sucesso ✅", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Atualiza plano existente
                        var updateCmd = new MySqlCommand(@"
                    UPDATE configutilizador 
                    SET PlanoAtualId = @planoId,
                        PlanoAtivoId = @planoId,
                        LimiteProdutos = (SELECT LimiteProdutos FROM planos WHERE Id = @planoId),
                        HistoricoDias = (SELECT HistoricoDias FROM planos WHERE Id = @planoId),
                        StatusAssinatura = 'Ativa'
                    WHERE ReferenciaID = @refId;", con);

                        updateCmd.Parameters.AddWithValue("@refId", _userId);
                        updateCmd.Parameters.AddWithValue("@planoId", planoId);
                        updateCmd.ExecuteNonQuery();

                        if (planoId != planoAtual)
                        {
                            var planoNome = ((PlanoItem)cmbPlano.SelectedItem).Nome;
                            MessageBox.Show($"Plano atualizado para \"{planoNome}\" com sucesso", "Plano Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar plano: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Atualiza o canal preferido do utilizador na tabela configutilizador.
        /// </summary>
        /// <param name="con"></param>
        private void AtualizarCanalPreferido(MySqlConnection con)
        {
            string canal = cmbCanal.SelectedItem?.ToString() ?? "email";
            var cmd = new MySqlCommand("UPDATE configutilizador SET CanalPreferido=@canal WHERE ReferenciaID=@refId", con);
            cmd.Parameters.AddWithValue("@refId", _userId);
            cmd.Parameters.AddWithValue("@canal", canal.ToLower());
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Atualiza as preferências de notificações do utilizador na tabela preferenciasnotificacao.
        /// </summary>
        /// <param name="con"></param>
        private void AtualizarPreferencias(MySqlConnection con)
        {
            foreach (string item in clbNotificacoes.Items)
            {
                int ativo = clbNotificacoes.CheckedItems.Contains(item) ? 1 : 0;
                var cmd2 = new MySqlCommand(@"
                    INSERT INTO preferenciasnotificacao (ReferenciaID, Tipo, Ativo)
                    VALUES (@refId, @tipo, @ativo)
                    ON DUPLICATE KEY UPDATE Ativo=@ativo;", con);

                cmd2.Parameters.AddWithValue("@refId", _userId);
                cmd2.Parameters.AddWithValue("@tipo", item.ToLower());
                cmd2.Parameters.AddWithValue("@ativo", ativo);
                cmd2.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Botao mudar estado Ativo/Inativo
        /// </summary>
        private void AtualizarCorBotaoAtivo()
        {
            if (chkAtivo.Checked)
            {
                btnAtivo.BackColor = System.Drawing.Color.SeaGreen;
                btnAtivo.ForeColor = System.Drawing.Color.White;
                btnAtivo.Text = "Ativo";
            }
            else
            {
                btnAtivo.BackColor = System.Drawing.Color.DarkGray;
                btnAtivo.ForeColor = System.Drawing.Color.White;
                btnAtivo.Text = "Inativo";
            }
        }

        private void chkAtivo_CheckedChanged(object sender, EventArgs e)
        {
            chkAtivo.Checked = !chkAtivo.Checked;
            AtualizarCorBotaoAtivo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormPerfilEditar_Load(object sender, EventArgs e)
        {

        }
    }
}
