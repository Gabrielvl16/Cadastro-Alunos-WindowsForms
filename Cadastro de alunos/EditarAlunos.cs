using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cadastro_de_alunos
{
    public partial class EditarAluno : Form
    {
        private int alunoId;

        public EditarAluno()
        {
            InitializeComponent();
            // Todos os campos ficam visíveis desde o início
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text.Trim(), out alunoId))
            {
                MessageBox.Show("Digite um ID válido.");
                return;
            }

            try
            {
                Conexao conexaoDB = new Conexao();
                MySqlConnection conn = conexaoDB.Conectar();

                string query = "SELECT * FROM alunos WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", alunoId);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNome.Text = reader["nome"].ToString();
                    dtpNascimento.Value = Convert.ToDateTime(reader["data_nascimento"]);
                    txtCurso.Text = reader["curso"].ToString();
                    txtTelefone.Text = reader["telefone"].ToString();
                }
                else
                {
                    MessageBox.Show("Aluno com esse ID não foi encontrado.");
                    LimparCampos();
                }

                reader.Close();
                conexaoDB.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar aluno: " + ex.Message);
            }
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            DateTime dataNascimento = dtpNascimento.Value;
            string curso = txtCurso.Text.Trim();
            string telefone = txtTelefone.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(curso) || string.IsNullOrWhiteSpace(telefone))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            try
            {
                Conexao conexaoDB = new Conexao();
                MySqlConnection conn = conexaoDB.Conectar();

                string query = "UPDATE alunos SET nome = @nome, data_nascimento = @data, curso = @curso, telefone = @telefone WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@data", dataNascimento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@curso", curso);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@id", alunoId);

                cmd.ExecuteNonQuery();
                conexaoDB.Desconectar();

                MessageBox.Show("Alterações salvas com sucesso!");
                // this.Close(); // Removido para manter o formulário aberto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar alterações: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtCurso.Clear();
            txtTelefone.Clear();
            dtpNascimento.Value = DateTime.Today;
        }

        private void btnListar_Click_1(object sender, EventArgs e)
        {
            ListarAlunos listar = new ListarAlunos();
            listar.Show();
            this.Hide();
        }

        private void btnCadastro_Click_1(object sender, EventArgs e)
        {
            CasatroAlunos cadastro = new CasatroAlunos();
            cadastro.Show();
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
