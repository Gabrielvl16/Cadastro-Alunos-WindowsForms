using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cadastro_de_alunos
{
    public partial class CasatroAlunos : Form
    {
        public CasatroAlunos()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            // Verifica se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtCurso.Text) ||
                string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            try
            {
                // Conecta ao banco de dados
                Conexao conexaoDB = new Conexao();
                MySqlConnection conn = conexaoDB.Conectar();

                // Obtém os dados do formulário
                string nome = txtNome.Text.Trim();
                DateTime dataNascimento = dtpNascimento.Value;
                string curso = txtCurso.Text.Trim();
                string telefone = txtTelefone.Text.Trim();

                // Prepara a query
                string query = "INSERT INTO alunos (nome, data_nascimento, curso, telefone) " +
                               "VALUES (@nome, @data, @curso, @telefone)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@data", dataNascimento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@curso", curso);
                cmd.Parameters.AddWithValue("@telefone", telefone);

                // Executa a inserção
                cmd.ExecuteNonQuery();

                // Mensagem de sucesso
                MessageBox.Show("Cadastro concluído com sucesso!");

                // Limpa os campos
                txtNome.Clear();
                txtCurso.Clear();
                txtTelefone.Clear();
                dtpNascimento.Value = DateTime.Today;

                // Desconecta
                conexaoDB.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarAlunos listar = new ListarAlunos();
            listar.Show();
            this.Hide();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            EditarAluno listar = new EditarAluno();
            listar.Show();
            this.Hide();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirAlunos excluir = new ExcluirAlunos();
            excluir.Show();
            this.Hide();
        }
    }
}

