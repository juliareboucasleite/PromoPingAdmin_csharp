namespace Painel_Admin
{
    partial class ProdutosListForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdutosListForm));
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.panelBotoes = new System.Windows.Forms.Panel();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnEditarProduto = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            this.btnAtualizarLista = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.panelBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutos.EnableHeadersVisualStyles = false;
            this.dgvProdutos.GridColor = System.Drawing.Color.LightGray;
            this.dgvProdutos.Location = new System.Drawing.Point(0, 0);
            this.dgvProdutos.MultiSelect = false;
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(900, 420);
            this.dgvProdutos.TabIndex = 1;
            this.dgvProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellContentClick);
            // 
            // panelBotoes
            // 
            this.panelBotoes.BackColor = System.Drawing.Color.Orange;
            this.panelBotoes.Controls.Add(this.btnAdicionarProduto);
            this.panelBotoes.Controls.Add(this.btnEditarProduto);
            this.panelBotoes.Controls.Add(this.btnRemoverProduto);
            this.panelBotoes.Controls.Add(this.btnAtualizarLista);
            this.panelBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotoes.Location = new System.Drawing.Point(0, 420);
            this.panelBotoes.Name = "panelBotoes";
            this.panelBotoes.Size = new System.Drawing.Size(900, 45);
            this.panelBotoes.TabIndex = 1;
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAdicionarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdicionarProduto.FlatAppearance.BorderSize = 0;
            this.btnAdicionarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionarProduto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdicionarProduto.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarProduto.Location = new System.Drawing.Point(10, 10);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(90, 27);
            this.btnAdicionarProduto.TabIndex = 0;
            this.btnAdicionarProduto.Text = "➕ &Adicionar";
            this.btnAdicionarProduto.UseVisualStyleBackColor = false;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditarProduto
            // 
            this.btnEditarProduto.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEditarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEditarProduto.FlatAppearance.BorderSize = 0;
            this.btnEditarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarProduto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarProduto.ForeColor = System.Drawing.Color.White;
            this.btnEditarProduto.Location = new System.Drawing.Point(110, 10);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(90, 27);
            this.btnEditarProduto.TabIndex = 1;
            this.btnEditarProduto.Text = "✏️ &Editar";
            this.btnEditarProduto.UseVisualStyleBackColor = false;
            this.btnEditarProduto.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.BackColor = System.Drawing.Color.Firebrick;
            this.btnRemoverProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRemoverProduto.FlatAppearance.BorderSize = 0;
            this.btnRemoverProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoverProduto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoverProduto.ForeColor = System.Drawing.Color.White;
            this.btnRemoverProduto.Location = new System.Drawing.Point(210, 10);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(90, 27);
            this.btnRemoverProduto.TabIndex = 2;
            this.btnRemoverProduto.Text = "🗑️ &Remover";
            this.btnRemoverProduto.UseVisualStyleBackColor = false;
            this.btnRemoverProduto.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAtualizarLista
            // 
            this.btnAtualizarLista.BackColor = System.Drawing.Color.DimGray;
            this.btnAtualizarLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAtualizarLista.FlatAppearance.BorderSize = 0;
            this.btnAtualizarLista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtualizarLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAtualizarLista.ForeColor = System.Drawing.Color.White;
            this.btnAtualizarLista.Location = new System.Drawing.Point(310, 10);
            this.btnAtualizarLista.Name = "btnAtualizarLista";
            this.btnAtualizarLista.Size = new System.Drawing.Size(100, 27);
            this.btnAtualizarLista.TabIndex = 3;
            this.btnAtualizarLista.Text = "🔄 &Atualizar";
            this.btnAtualizarLista.UseVisualStyleBackColor = false;
            this.btnAtualizarLista.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // ProdutosListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(900, 465);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.panelBotoes);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProdutosListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Produtos";
            this.Load += new System.EventHandler(this.EditarProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.panelBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Panel panelBotoes;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnEditarProduto;
        private System.Windows.Forms.Button btnRemoverProduto;
        private System.Windows.Forms.Button btnAtualizarLista;
    }
}
