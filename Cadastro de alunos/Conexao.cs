using MySql.Data.MySqlClient;

namespace Cadastro_de_alunos
{
    public class Conexao
    {
        private MySqlConnection conexao;
        private string connString = "server=localhost;user=root;password=;database=escola_db;";

        public MySqlConnection Conectar()
        {
            conexao = new MySqlConnection(connString);
            conexao.Open();
            return conexao;
        }

        public void Desconectar()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
