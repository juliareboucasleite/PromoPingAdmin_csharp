using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Painel_Admin
{
    public partial class PainelForm : Form
    {
        public PainelForm() {InitializeComponent(); }
        private void PainelForm_Load(object sender, EventArgs e) { AtualizarDashboard(); }
        private void btnAtualizarDashboard_Click(object sender, EventArgs e) { AtualizarDashboard(); }
        private void AtualizarDashboard()
        {
            string connStr = DbConfig.ConnectionString;
            try {
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM utilizadores", con))
                    {
                        lblTotalUsers.Text = $"{cmd.ExecuteScalar()}";
                    }
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM produtos", con))
                    {
                        lblTotalProdutos.Text = $"{cmd.ExecuteScalar()}";
                    }
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM preferenciasnotificacao WHERE Ativo = 1", con))
                    {
                        lblTotalNotificacoes.Text = $"{cmd.ExecuteScalar()}";
                    }
                    using (var cmd = new MySqlCommand("SELECT IFNULL(SUM(PrecoAlvo), 0) FROM produtos", con))
                    {
                        decimal poupado = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblTotalPoupado.Text = $"€{poupado:0.00}";
                    }
                }
            } catch (Exception ex) { MessageBox.Show("Erro ao atualizar o dashboard: " + ex.Message); }
        }

        private void editarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProdutosListForm().ShowDialog();

        }

        private void painelPerfisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PainelPerfis().ShowDialog();
        }

        private void perfilDetalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Auth.Sessao.UserId))
            {
                new FormPerfilDetalhes(Auth.Sessao.UserId).ShowDialog();
            }
            else
            {
                MessageBox.Show("Utilizador não autenticado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void perfilEditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Auth.Sessao.UserId))
            {
                new FormPerfilEditar(Auth.Sessao.UserId, Auth.Sessao.Nome, Auth.Sessao.Email, "1", "email", true).ShowDialog();
            }
            else
            {
                MessageBox.Show("Utilizador não autenticado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editarNotificacoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormNotificacaoEditar()) {form.ShowDialog(); }
        }

        private void notificacoesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var form = new FormNotificacoes()) {form.ShowDialog(); }
        }

        private void listarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new ProdutosListForm()) {form.ShowDialog(); }
        }

        private void suporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new Suporte()) {form.ShowDialog(); }
        }

        private void painelPerfisUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormUtilizadoresList()) { form.ShowDialog(); }
        }
    }
}
