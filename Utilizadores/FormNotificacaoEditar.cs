using System;
using System.Data;
using System.Windows.Forms;

namespace Painel_Admin
{
    public partial class FormNotificacaoEditar : Form
    {
        private readonly PreferenciaNotificacaoRepository _repo;
        private readonly ProdutoRepository _produtoRepo; 
        private int _id;

        public FormNotificacaoEditar()
        {
            InitializeComponent();
            _repo = new PreferenciaNotificacaoRepository();
            _produtoRepo = new ProdutoRepository();
            _id = 0;
        }

        public FormNotificacaoEditar(int id, int userId, string tipo, bool ativo)
        {
            InitializeComponent();
            _repo = new PreferenciaNotificacaoRepository();
            _produtoRepo = new ProdutoRepository();
            _id = id;

            CarregarUtilizadores();

            if (userId > 0)
                cmbUser.SelectedValue = userId;

            cmbTipo.SelectedItem = tipo;
            chkAtivo.Checked = ativo;
        }

        private void FormNotificacaoEditar_Load(object sender, EventArgs e)
        {
            CarregarUtilizadores();

            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Email");
            cmbTipo.Items.Add("Discord");


            if (string.IsNullOrEmpty(cmbTipo.Text))
                cmbTipo.SelectedIndex = 0;
        }

        private void CarregarUtilizadores()
        {
            try
            {
                DataTable dtUsers = _produtoRepo.GetUserIdsComProdutos();

                cmbUser.DataSource = dtUsers;
                cmbUser.DisplayMember = "Nome";
                cmbUser.ValueMember = "Id";
                cmbUser.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar utilizadores: " + ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUser.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um utilizador!");
                    return;
                }

                int userId = Convert.ToInt32(cmbUser.SelectedValue);
                string tipo = cmbTipo.SelectedItem?.ToString() ?? "email";
                bool ativo = chkAtivo.Checked;

                if (_id == 0)
                    _repo.Add(userId, tipo, ativo);
                else
                    _repo.Update(_id, userId, tipo, ativo);

                MessageBox.Show("Preferência salva com sucesso!",
                                "Notificações", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormNotificacaoEditar_Load_1(object sender, EventArgs e) { }
    }
}
