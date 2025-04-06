using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cadastro_de_alunos
{
    public partial class ExcluirAlunos : Form
    {
        public ExcluirAlunos()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            // Verifica se o ID é válido
            if (!int.TryParse(txtId.Text.Trim(), out int alunoId))
            {
                MessageBox.Show("Digite um ID válido.");
                return;
            }

            // Confirmação antes de excluir
            DialogResult confirm = MessageBox.Show(
                $"Tem certeza que deseja excluir o aluno com ID {alunoId}?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.No)
                return;

            try
            {
                Conexao conexaoDB = new Conexao();
                MySqlConnection conn = conexaoDB.Conectar();

                string query = "DELETE FROM alunos WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", alunoId);

                int rowsAffected = cmd.ExecuteNonQuery();
                conexaoDB.Desconectar();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Aluno excluído com sucesso.");
                    txtId.Clear();
                }
                else
                {
                    MessageBox.Show("Nenhum aluno encontrado com esse ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir aluno: " + ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarAlunos listar = new ListarAlunos();
            listar.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarAluno listar = new EditarAluno();
            listar.Show();
            this.Hide();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            CasatroAlunos cadastro = new CasatroAlunos();
            cadastro.Show();
            this.Hide();
        }
    }
}
