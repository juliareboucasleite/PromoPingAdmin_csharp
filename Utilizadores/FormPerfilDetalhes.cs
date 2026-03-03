using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Painel_Admin
{
    public partial class FormPerfilDetalhes : Form
    {
        private readonly string _referenciaId;

        public FormPerfilDetalhes(string referenciaId)
        {
            InitializeComponent();
            _referenciaId = referenciaId;
        }

        private void FormPerfilDetalhes_Load(object sender, EventArgs e)
        {
            CarregarPerfil();
            CarregarPreferencias();
        }

        private void CarregarPerfil()
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            u.Nome, 
                            u.Email, 
                            p.Nome AS Perfil,
                            u.Ativo,
                            u.DataRegisto,
                            u.UltimoLogin,
                            u.dinheiro_poupado,
                            pl.Nome AS Plano,
                            c.LimiteProdutos,
                            c.CanalPreferido
                        FROM utilizadores u
                        LEFT JOIN perfis p ON p.Id = u.PerfilId
                        LEFT JOIN configutilizador c ON c.ReferenciaID = u.ReferenciaID
                        LEFT JOIN planos pl ON pl.Id = c.PlanoAtualId
                        WHERE u.ReferenciaID = @refId;";

                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@refId", _referenciaId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IdNome.Text = reader["Nome"].ToString();
                                IdEmail.Text = reader["Email"].ToString();

                                IdPlano.Text = reader["Plano"] != DBNull.Value ? reader["Plano"].ToString() : "Free";
                                AplicarCorPlano(IdPlano.Text);

                                // Ativo pode aparecer de formas distintas; usar método auxiliar para ser tolerante
                                var ativoObj = GetField(reader, "Ativo", "ativo");
                                bool ativo = ativoObj != DBNull.Value && Convert.ToInt32(ativoObj) == 1;
                                IdAtivo.Text = ativo ? "Sim ✅" : "Não ❌";
                                IdAtivo.ForeColor = ativo ? Color.ForestGreen : Color.Firebrick;

                                IdProdutos.Text = ObterTotal("produtos", "ReferenciaID", _referenciaId).ToString();
                                IdNotificacoes.Text = ObterTotal("notificacoes", "ReferenciaID", _referenciaId).ToString();

                                // Tratamento robusto para dinheiro_poupado (evita FormatException)
                                var dinheiroObj = GetField(reader, "dinheiro_poupado", "DinheiroPoupado", "dinheiroPoupado");
                                decimal dinheiro = 0m;
                                if (dinheiroObj != null && dinheiroObj != DBNull.Value)
                                {
                                    try
                                    {
                                        if (dinheiroObj is decimal decVal)
                                        {
                                            dinheiro = decVal;
                                        }
                                        else if (dinheiroObj is double dblVal)
                                        {
                                            dinheiro = Convert.ToDecimal(dblVal);
                                        }
                                        else if (dinheiroObj is float fltVal)
                                        {
                                            dinheiro = Convert.ToDecimal(fltVal);
                                        }
                                        else if (dinheiroObj is long lVal)
                                        {
                                            dinheiro = Convert.ToDecimal(lVal);
                                        }
                                        else if (dinheiroObj is int iVal)
                                        {
                                            dinheiro = Convert.ToDecimal(iVal);
                                        }
                                        else
                                        {
                                            // Tenta parse com cultura pt-BR (virgula) e depois Invariant (ponto)
                                            string s = dinheiroObj.ToString();
                                            if (!decimal.TryParse(s, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out decVal) &&
                                                !decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decVal) &&
                                                !decimal.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out decVal))
                                            {
                                                decVal = 0m;
                                            }
                                            dinheiro = decVal;
                                        }
                                    }
                                    catch
                                    {
                                        dinheiro = 0m;
                                    }
                                }

                                IdDinheiro.Text = "€ " + dinheiro.ToString("F2");

                                IdMembroDesde.Text = reader["DataRegisto"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["DataRegisto"]).ToString("dd/MM/yyyy HH:mm")
                                    : "---";

                                var ultimoLoginObj = GetField(reader, "UltimoLogin", "ultimo_login", "ultimoLogin");
                                IdUltimoLogin.Text = ultimoLoginObj != DBNull.Value
                                    ? Convert.ToDateTime(ultimoLoginObj).ToString("dd/MM/yyyy HH:mm")
                                    : "---";

                                IdLimitesProdutos.Text = reader["LimiteProdutos"] != DBNull.Value
                                    ? reader["LimiteProdutos"].ToString()
                                    : "5";

                                // CanalPreferido na base é 'discord' por defeito — refletir essa preferência aqui
                                IdCanalPreferido.Text = reader["CanalPreferido"] != DBNull.Value
                                    ? reader["CanalPreferido"].ToString()
                                    : "discord";

                                AplicarCorCanal(IdCanalPreferido.Text);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar perfil: " + ex.Message);
            }
        }

        private void AplicarCorPlano(string plano)
        {
            switch (plano.ToLower())
            {
                case "free":
                    IdPlano.ForeColor = Color.Gray;
                    break;
                case "basic":
                    IdPlano.ForeColor = Color.RoyalBlue;
                    break;
                case "standard":
                    IdPlano.ForeColor = Color.DarkOrange;
                    break;
                case "premium":
                    IdPlano.ForeColor = Color.ForestGreen;
                    break;
                default:
                    IdPlano.ForeColor = Color.Black;
                    break;
            }
        }

        private void AplicarCorCanal(string canal)
        {
            switch (canal.ToLower())
            {
                case "email":
                    IdCanalPreferido.ForeColor = Color.MediumBlue;
                    break;
                case "discord":
                    IdCanalPreferido.ForeColor = Color.Purple;
                    break;
                default:
                    IdCanalPreferido.ForeColor = Color.Black;
                    break;
            }
        }

        private int ObterTotal(string tabela, string campoUser, string referenciaId)
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    string query = $"SELECT COUNT(*) FROM {tabela} WHERE {campoUser} = @refId;";
                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@refId", referenciaId);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private void CarregarPreferencias()
        {
            try
            {
                for (int i = 0; i < clbNotificacoes.Items.Count; i++)
                    clbNotificacoes.SetItemChecked(i, false);

                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT Tipo, Ativo FROM preferenciasnotificacao WHERE ReferenciaID=@refId";

                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@refId", _referenciaId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tipo = reader["Tipo"].ToString();
                                bool ativo = Convert.ToInt32(reader["Ativo"]) == 1;

                                int index = clbNotificacoes.Items.IndexOf(
                                    char.ToUpper(tipo[0]) + tipo.Substring(1)
                                );

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

                    foreach (string item in clbNotificacoes.Items)
                    {
                        int ativo = clbNotificacoes.CheckedItems.Contains(item) ? 1 : 0;
                        var cmd = new MySqlCommand(@"
                            INSERT INTO preferenciasnotificacao (ReferenciaID, Tipo, Ativo)
                            VALUES (@refId, @tipo, @ativo)
                            ON DUPLICATE KEY UPDATE Ativo=@ativo;", con);

                        cmd.Parameters.AddWithValue("@refId", _referenciaId);
                        cmd.Parameters.AddWithValue("@tipo", item.ToLower());
                        cmd.Parameters.AddWithValue("@ativo", ativo);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Preferências atualizadas com sucesso!", "Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarPreferencias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar preferências: " + ex.Message);
            }
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            var editar = new FormPerfilEditar(
                _referenciaId,
                IdNome.Text,
                IdEmail.Text,
                IdPlano.Text,
                IdCanalPreferido.Text,
                IdAtivo.Text.Contains("Sim")
            );

            if (editar.ShowDialog() == DialogResult.OK)
            {
                CarregarPerfil();
                CarregarPreferencias();
            }
        }

        private void IdProdutos_Click(object sender, EventArgs e) { }
        private void IdNotificacoes_Click(object sender, EventArgs e) { }
        private void IdMembroDesde_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Busca o primeiro campo existente entre os nomes fornecidos no reader.
        /// Útil para compatibilidade com mudanças de nomes (camelCase / snake_case).
        /// </summary>
        private object GetField(IDataRecord reader, params string[] names)
        {
            foreach (var name in names)
            {
                try
                {
                    int ord = reader.GetOrdinal(name);
                    return reader.GetValue(ord);
                }
                catch (IndexOutOfRangeException)
                {
                    // ignorar e tentar o próximo nome
                }
            }
            return DBNull.Value;
        }

        private void IdDinheiro_Click(object sender, EventArgs e)
        {

        }
    }
}