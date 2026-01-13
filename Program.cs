using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Painel_Admin
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Testa a conexão com o banco de dados antes de iniciar a aplicação
            if (!DbConfig.TestConnection())
            {
                var builder = new MySqlConnectionStringBuilder(DbConfig.ConnectionString);
                var errorMsg = $"Não foi possível conectar ao banco de dados.\n\n" +
                              $"Servidor: {builder.Server}\n" +
                              $"Banco de Dados: {builder.Database}\n" +
                              $"Usuário: {builder.UserID}\n\n" +
                              $"Verifique se:\n" +
                              $"1. O servidor MySQL/MariaDB está em execução\n" +
                              $"2. O banco de dados 'pap' existe\n" +
                              $"3. As credenciais estão corretas no arquivo App.config\n" +
                              $"4. O usuário tem permissões para acessar o banco";

                MessageBox.Show(errorMsg, "Erro de Conexão", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}