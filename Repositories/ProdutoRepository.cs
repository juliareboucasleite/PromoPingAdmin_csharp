using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Painel_Admin
{
    public class ProdutoRepository
    {
        public DataTable GetAll()
        {
            using (var con = new MySqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                string query = @"
                    SELECT 
                        p.Id,
                        u.Nome AS UsuarioNome,
                        p.Nome,
                        p.Link,
                        p.PrecoAlvo,
                        p.PrecoAtual,
                        p.DataLimite,
                        p.Shipping,
                        l.Nome AS LojaNome
                    FROM produtos p
                    INNER JOIN utilizadores u ON u.ReferenciaID = p.ReferenciaID
                    LEFT JOIN lojas l ON l.Id = p.LojaId
                    WHERE p.DeletedAt IS NULL
                    ORDER BY p.Id ASC;";

                using (var cmd = new MySqlCommand(query, con))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void Add(string referenciaId, string nome, string link, decimal precoAlvo, DateTime? dataLimite, int? lojaId)
        {
            using (var con = new MySqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                string query = @"INSERT INTO produtos 
                                (ReferenciaID, Nome, Link, PrecoAlvo, DataLimite, LojaId)
                                 VALUES (@refId, @nome, @link, @precoAlvo, @dataLimite, @lojaId)";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@refId", referenciaId);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@link", link);
                    cmd.Parameters.AddWithValue("@precoAlvo", precoAlvo);
                    cmd.Parameters.AddWithValue("@dataLimite", (object)dataLimite ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@lojaId", (object)lojaId ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(int id, string nome, string link, decimal precoAlvo, DateTime? dataLimite, int? lojaId)
        {
            using (var con = new MySqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                string query = @"UPDATE produtos 
                                 SET Nome=@nome, Link=@link, PrecoAlvo=@precoAlvo, 
                                     DataLimite=@dataLimite, LojaId=@lojaId
                                 WHERE Id=@id";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@link", link);
                    cmd.Parameters.AddWithValue("@precoAlvo", precoAlvo);
                    cmd.Parameters.AddWithValue("@dataLimite", (object)dataLimite ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@lojaId", (object)lojaId ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetUserIdsComProdutos()
        {
            using (var con = new MySqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                string query = @"
                    SELECT DISTINCT u.ReferenciaID, CONCAT(u.ReferenciaID, ' - ', u.Nome) AS Nome
                    FROM produtos p
                    INNER JOIN utilizadores u ON u.ReferenciaID = p.ReferenciaID
                    WHERE p.DeletedAt IS NULL
                    ORDER BY u.ReferenciaID ASC;";

                using (var cmd = new MySqlCommand(query, con))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public void Delete(int id)
        {
            using (var con = new MySqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                string query = "DELETE FROM produtos WHERE Id=@id";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
