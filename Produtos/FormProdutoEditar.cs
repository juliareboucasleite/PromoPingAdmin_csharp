using System;
using System.Windows.Forms;
using Painel_Admin.Auth;

namespace Painel_Admin
{
    public partial class FormProdutoEditar : Form
    {
        private readonly ProdutoRepository _produtoRepo;
        private int _id;

        public FormProdutoEditar()
        {
            InitializeComponent();
            _produtoRepo = new ProdutoRepository();
            _id = 0;

            chkSemData.Checked = true;
            dtpDataLimite.Enabled = false;
        }

        public FormProdutoEditar(int id, string referenciaId, string nome, string link, decimal precoAlvo, DateTime? dataLimite, int? lojaId)
        {
            InitializeComponent();
            _produtoRepo = new ProdutoRepository();
            _id = id;

            txtNome.Text = nome;
            txtLink.Text = link;
            txtPrecoAlvo.Text = precoAlvo.ToString("0.00");

            if (dataLimite.HasValue)
            {
                dtpDataLimite.Value = dataLimite.Value;
                chkSemData.Checked = false;
                dtpDataLimite.Enabled = true;
            }
            else
            {
                chkSemData.Checked = true;
                dtpDataLimite.Enabled = false;
            }

            txtLoja.Text = lojaId?.ToString() ?? "";
        }

        private void FormProdutoEditar_Load(object sender, EventArgs e)
        {
            try
            {
                var users = _produtoRepo.GetUserIdsComProdutos(); 
                ComboBoxID.DataSource = users;
                ComboBoxID.DisplayMember = "Nome"; 
                ComboBoxID.ValueMember = "ReferenciaID";   
                ComboBoxID.SelectedIndex = -1;    

                chkSemData.CheckedChanged += (s, ev) =>
                {
                    dtpDataLimite.Enabled = !chkSemData.Checked;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de utilizadores: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxID.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um ID de utilizador válido!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string referenciaId = ComboBoxID.SelectedValue?.ToString() ?? "";
                string nome = txtNome.Text.Trim();
                string link = txtLink.Text.Trim();
                decimal precoAlvo = decimal.TryParse(txtPrecoAlvo.Text, out decimal preco) ? preco : 0;
                DateTime? dataLimite = chkSemData.Checked ? (DateTime?)null : dtpDataLimite.Value;
                
                // Tentar converter loja para ID
                int? lojaId = null;
                if (!string.IsNullOrEmpty(txtLoja.Text.Trim()) && int.TryParse(txtLoja.Text.Trim(), out int lojaIdValue))
                {
                    lojaId = lojaIdValue;
                }

                if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(link))
                {
                    MessageBox.Show("Nome e Link são obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_id == 0)
                {
                    if (string.IsNullOrEmpty(referenciaId))
                    {
                        MessageBox.Show("Selecione um utilizador!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _produtoRepo.Add(referenciaId, nome, link, precoAlvo, dataLimite, lojaId);
                }
                else
                {
                    _produtoRepo.Update(_id, nome, link, precoAlvo, dataLimite, lojaId);
                }

                MessageBox.Show("Produto salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ComboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxID.SelectedItem is System.Data.DataRowView row)
            {
                string referenciaId = row["ReferenciaID"]?.ToString() ?? "";
                string nome = row["Nome"]?.ToString() ?? "";
                Console.WriteLine($"Selecionado: ReferenciaID = {referenciaId}, Nome = {nome}");
            }
        }
        private void txtNome_TextChanged(object sender, EventArgs e){ }

        private void txtLink_TextChanged(object sender, EventArgs e) {}

        private void txtPrecoAlvo_TextChanged(object sender, EventArgs e) { }

        private void txtLoja_TextChanged(object sender, EventArgs e){}
    }
}
