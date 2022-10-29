//teste inicial

using MySql.Data.MySqlClient;

namespace DAL
{
    public class DatabaseService
    {
        private MySqlConnection _connection;
        public DatabaseService()
        {
            _connection = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=classicmodels");
            _connection.Open();
        }

        public MySqlDataReader Select(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, _connection);
            return command.ExecuteReader();
        }
    }

}

//https://www.devmedia.com.br/como-criar-um-sistema-sistema-de-autenticacao-em-asp-net-e-csharp/31701

// precisamos programar a:
// > criação de conta por parte do usuário e das oficinas
// > login de clientes cadastrados
// > depois partimos pras outras etapas...