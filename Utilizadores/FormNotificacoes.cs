using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Painel_Admin
{
    public partial class FormNotificacoes : Form
    {
        private readonly PreferenciaNotificacaoRepository _repo;

        public FormNotificacoes()
        {
            InitializeComponent();
            _repo = new PreferenciaNotificacaoRepository();
        }

        private void FormNotificacoes_Load(object sender, EventArgs e)
        {
            CarregarPreferencias();
        }

        private void CarregarPreferencias()
        {
            try
            {
                dgvNotificacoes.DataSource = _repo.GetAll();

                if (dgvNotificacoes.Columns.Contains("Id"))
                    dgvNotificacoes.Columns["Id"].HeaderText = "ID";

                if (dgvNotificacoes.Columns.Contains("UsuarioNome"))
                    dgvNotificacoes.Columns["UsuarioNome"].HeaderText = "Usuário";

                if (dgvNotificacoes.Columns.Contains("Tipo"))
                    dgvNotificacoes.Columns["Tipo"].HeaderText = "Tipo";

                if (dgvNotificacoes.Columns.Contains("Ativo"))
                    dgvNotificacoes.Columns["Ativo"].HeaderText = "Ativo";

                dgvNotificacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvNotificacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvNotificacoes.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar notificações: " + ex.Message);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var form = new FormNotificacaoEditar();
            if (form.ShowDialog() == DialogResult.OK)
                CarregarPreferencias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvNotificacoes.CurrentRow != null)
            {
                try
                {
                    int id = Convert.ToInt32(dgvNotificacoes.CurrentRow.Cells["Id"].Value);
                    string referenciaId = dgvNotificacoes.CurrentRow.Cells["ReferenciaID"]?.Value?.ToString() ?? "";
                    string tipo = dgvNotificacoes.CurrentRow.Cells["Tipo"].Value.ToString();
                    bool ativo = Convert.ToInt32(dgvNotificacoes.CurrentRow.Cells["Ativo"].Value) == 1;
                    
                    var form = new FormNotificacaoEditar(id, referenciaId, tipo, ativo);
                    if (form.ShowDialog() == DialogResult.OK)
                        CarregarPreferencias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao editar: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma notificação para editar!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvNotificacoes.CurrentRow != null)
            {
                try
                {
                    int id = Convert.ToInt32(dgvNotificacoes.CurrentRow.Cells["Id"].Value);
                    if (MessageBox.Show("Deseja realmente remover esta preferência?", "Confirmação",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _repo.Delete(id);
                        CarregarPreferencias();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao remover: " + ex.Message);
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarPreferencias();
        }
    }
}
