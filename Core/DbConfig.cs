using System;
using System.Configuration;

namespace Painel_Admin
{
    public static class DbConfig
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    try
                    {
                        // Tenta ler do App.config primeiro
                        var connString = ConfigurationManager.ConnectionStrings["MySqlConn"];
                        if (connString != null && !string.IsNullOrEmpty(connString.ConnectionString))
                        {
                            _connectionString = connString.ConnectionString;
                        }
                        else
                        {
                            // Fallback para string padrão se não encontrar no config
                            _connectionString = "Server=localhost;Database=pap;Uid=root;Pwd=;SslMode=none;";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Se houver erro ao ler o config, usa a string padrão
                        _connectionString = "Server=localhost;Database=pap;Uid=root;Pwd=;SslMode=none;";
                        System.Diagnostics.Debug.WriteLine($"Erro ao ler connection string do config: {ex.Message}");
                    }
                }
                return _connectionString;
            }
        }

        /// <summary>
        /// Testa a conexão com o banco de dados
        /// </summary>
        /// <returns>True se a conexão for bem-sucedida, False caso contrário</returns>
        public static bool TestConnection()
        {
            try
            {
                using (var connection = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
