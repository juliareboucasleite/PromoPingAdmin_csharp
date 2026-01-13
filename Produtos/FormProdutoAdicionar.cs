using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painel_Admin.Produtos
{
    public partial class FormProdutoAdicionar : Form
    {
        private readonly ProdutoRepository _produtoRepo;
        public FormProdutoAdicionar()
        {
            InitializeComponent();
            _produtoRepo = new ProdutoRepository();
        }

        private void FormAdicionarProduto_Load(object sender, EventArgs e)
        {
            try
            {
                var users = _produtoRepo.GetUserIdsComProdutos();
                ComboBoxID.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de utilizadores: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            chkSemData.CheckedChanged += (s, ev) =>
            {
                dtpDataLimite.Enabled = !chkSemData.Checked;
            };
            chkSemData.Checked = true;
            dtpDataLimite.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxID.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um ID de utilizador!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string referenciaId = ComboBoxID.SelectedValue?.ToString() ?? "";
                string nome = txtNome.Text.Trim();
                string link = txtLink.Text.Trim();
                decimal precoAlvo = decimal.TryParse(txtPrecoAlvo.Text, out decimal preco) ? preco : 0;
                DateTime? dataLimite = chkSemData.Checked ? (DateTime?)null : dtpDataLimite.Value;
                
                // Tentar converter loja para ID, se não conseguir, usar null
                int? lojaId = null;
                if (!string.IsNullOrEmpty(txtLoja.Text.Trim()) && int.TryParse(txtLoja.Text.Trim(), out int lojaIdValue))
                {
                    lojaId = lojaIdValue;
                }

                if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(link))
                {
                    MessageBox.Show("Nome e Link são obrigatórios!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(referenciaId))
                {
                    MessageBox.Show("Selecione um utilizador!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _produtoRepo.Add(referenciaId, nome, link, precoAlvo, dataLimite, lojaId);

                MessageBox.Show("✅ Produto adicionado com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar produto: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
