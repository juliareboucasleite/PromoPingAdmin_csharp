using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Painel_Admin
{
    public class UtilizadorRepository
    {
        public DataTable GetAll()
        {
            using (var con = new MySqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                string query = @"SELECT ReferenciaID, Nome, Email, PerfilId, Ativo, DataRegisto 
                                 FROM utilizadores";

                using (var cmd = new MySqlCommand(query, con))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public void Add(string nome, string email, string senhaHash, bool ativo, int perfilId)
        {
            using (var con = new MySqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                string query = @"INSERT INTO utilizadores 
                        (Nome, Email, SenhaHash, Ativo, PerfilId, DataRegisto, EmailVerificado)
                        VALUES (@nome, @mail, @senhaHash, @ativo, @perfil, NOW(), 1)";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@senhaHash", senhaHash);
                    cmd.Parameters.AddWithValue("@ativo", ativo ? 1 : 0);
                    cmd.Parameters.AddWithValue("@perfil", perfilId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(string referenciaId, string nome, string email, bool ativo, int perfilId)
        {
            using (var con = new MySqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                string query = @"UPDATE utilizadores 
                         SET Nome=@nome, Email=@mail, Ativo=@ativo, PerfilId=@perfil
                         WHERE ReferenciaID=@refId";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@refId", referenciaId);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@ativo", ativo ? 1 : 0);
                    cmd.Parameters.AddWithValue("@perfil", perfilId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string referenciaId)
        {
            using (var con = new MySqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                string query = "DELETE FROM utilizadores WHERE ReferenciaID=@refId";
                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@refId", referenciaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
