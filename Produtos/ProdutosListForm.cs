
using System;
using System.Windows.Forms;
using Painel_Admin.Produtos;
using MySql.Data.MySqlClient;

namespace Painel_Admin
{
    public partial class ProdutosListForm : Form
    {
        private readonly ProdutoRepository _produtoRepo;
        public ProdutosListForm()
        {
            InitializeComponent();
            _produtoRepo = new ProdutoRepository();
        }

        private void EditarProdutos_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }
        private void CarregarProdutos()
        {
            try
            {
                dgvProdutos.DataSource = _produtoRepo.GetAll();

                if (dgvProdutos.Columns.Count > 0)
                {
                    dgvProdutos.Columns["Id"].HeaderText = "ID";
                    dgvProdutos.Columns["UsuarioNome"].HeaderText = "Usuário";
                    dgvProdutos.Columns["Nome"].HeaderText = "Nome";
                    dgvProdutos.Columns["Link"].HeaderText = "Link";
                    dgvProdutos.Columns["PrecoAlvo"].HeaderText = "Preço Alvo";
                    dgvProdutos.Columns["DataLimite"].HeaderText = "Data Limite";
                    if (dgvProdutos.Columns.Contains("LojaNome"))
                        dgvProdutos.Columns["LojaNome"].HeaderText = "Loja";
                }

                dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProdutos.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var form = new FormProdutoAdicionar())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CarregarProdutos();
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null)
            {
                try
                {
                    int id = Convert.ToInt32(dgvProdutos.CurrentRow.Cells["Id"].Value);
                    string nome = dgvProdutos.CurrentRow.Cells["Nome"].Value.ToString();
                    string link = dgvProdutos.CurrentRow.Cells["Link"].Value.ToString();
                    decimal precoAlvo = dgvProdutos.CurrentRow.Cells["PrecoAlvo"].Value != DBNull.Value ? Convert.ToDecimal(dgvProdutos.CurrentRow.Cells["PrecoAlvo"].Value) : 0;
                    DateTime? dataLimite = dgvProdutos.CurrentRow.Cells["DataLimite"].Value != DBNull.Value ? Convert.ToDateTime(dgvProdutos.CurrentRow.Cells["DataLimite"].Value) : (DateTime?)null;
                    // Obter ReferenciaID do produto - buscar da base de dados
                    string referenciaId = "";
                    int? lojaId = null;
                    
                    try
                    {
                        using (var con = new MySql.Data.MySqlClient.MySqlConnection(DbConfig.ConnectionString))
                        {
                            con.Open();
                            var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT ReferenciaID, LojaId FROM produtos WHERE Id=@id", con);
                            cmd.Parameters.AddWithValue("@id", id);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    referenciaId = reader["ReferenciaID"].ToString();
                                    if (reader["LojaId"] != DBNull.Value)
                                        lojaId = Convert.ToInt32(reader["LojaId"]);
                                }
                            }
                        }
                    }
                    catch { }
                    
                    using (var form = new FormProdutoEditar(id, referenciaId, nome, link, precoAlvo, dataLimite, lojaId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            CarregarProdutos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao editar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProdutos.SelectedRows[0].Cells["Id"].Value);

                if (MessageBox.Show("Deseja remover este produto?", "Confirmação",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _produtoRepo.Delete(id);
                        CarregarProdutos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao remover produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para remover!","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarProdutos();
        }
    }
}
