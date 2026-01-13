using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Painel_Admin.Utilizadores;

namespace Painel_Admin
{
    public partial class FormUtilizadoresList : Form
    {
        public FormUtilizadoresList()
        {
            InitializeComponent();
        }

        private void FormUtilizadoresList_Load(object sender, EventArgs e)
        {
            CorrigirPerfisNulos();
            CarregarUtilizadores();
        }

        private void CorrigirPerfisNulos()
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    string query = "UPDATE utilizadores SET PerfilId = 2 WHERE PerfilId IS NULL;";
                    new MySqlCommand(query, con).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao corrigir perfis nulos: " + ex.Message,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CarregarUtilizadores()
        {
            try
            {
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            u.ReferenciaID,
                            u.Nome,
                            u.Email,
                            p.Nome AS Perfil,
                            u.Ativo
                        FROM utilizadores u
                        INNER JOIN perfis p ON p.Id = u.PerfilId
                        WHERE u.PerfilId = 2
                        ORDER BY u.Nome ASC;";

                    var adapter = new MySqlDataAdapter(query, con);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUtilizadores.DataSource = dt;
                    dgvUtilizadores.Columns["ReferenciaID"].HeaderText = "Referência";
                    dgvUtilizadores.Columns["Nome"].HeaderText = "Nome";
                    dgvUtilizadores.Columns["Email"].HeaderText = "Email";
                    dgvUtilizadores.Columns["Perfil"].HeaderText = "Perfil";
                    dgvUtilizadores.Columns["Ativo"].HeaderText = "Ativo";
                    dgvUtilizadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvUtilizadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvUtilizadores.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar utilizadores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var form = new FormAdicionar();
            if (form.ShowDialog() == DialogResult.OK)
                CarregarUtilizadores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUtilizadores.CurrentRow == null)
            {
                MessageBox.Show("Selecione um utilizador para editar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string referenciaId = dgvUtilizadores.CurrentRow.Cells["ReferenciaID"].Value.ToString();
                string nome = dgvUtilizadores.CurrentRow.Cells["Nome"].Value.ToString();
                string email = dgvUtilizadores.CurrentRow.Cells["Email"].Value.ToString();
                bool ativo = Convert.ToBoolean(dgvUtilizadores.CurrentRow.Cells["Ativo"].Value);
                string canal = "email";
                using (var con = new MySqlConnection(DbConfig.ConnectionString))
                {
                    con.Open();
                    var cmd = new MySqlCommand("SELECT CanalPreferido FROM configutilizador WHERE ReferenciaID=@refId", con);
                    cmd.Parameters.AddWithValue("@refId", referenciaId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        canal = result.ToString();
                }

                var form = new FormPerfilEditar(referenciaId, nome, email, "1", canal, ativo);
                if (form.ShowDialog() == DialogResult.OK)
                    CarregarUtilizadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar utilizador: " + ex.Message,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvUtilizadores.CurrentRow == null)
            {
                MessageBox.Show("Selecione um utilizador para remover!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string referenciaId = dgvUtilizadores.CurrentRow.Cells["ReferenciaID"].Value.ToString();
            if (MessageBox.Show("Remover este utilizador?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var con = new MySqlConnection(DbConfig.ConnectionString))
                    {
                        con.Open();
                        var cmd = new MySqlCommand("DELETE FROM utilizadores WHERE ReferenciaID=@refId", con);
                        cmd.Parameters.AddWithValue("@refId", referenciaId);
                        cmd.ExecuteNonQuery();
                    }
                    CarregarUtilizadores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao remover utilizador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CorrigirPerfisNulos();
            CarregarUtilizadores();
        }
        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            if (dgvUtilizadores.CurrentRow == null)
            {
                MessageBox.Show("Selecione um utilizador para ver os detalhes!","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string referenciaId = dgvUtilizadores.CurrentRow.Cells["ReferenciaID"].Value.ToString();
                var form = new FormPerfilDetalhes(referenciaId);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir detalhes: " + ex.Message,  "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
