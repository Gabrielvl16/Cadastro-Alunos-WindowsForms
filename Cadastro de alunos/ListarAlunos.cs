using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cadastro_de_alunos
{
    public partial class ListarAlunos : Form
    {
        public ListarAlunos()
        {
            InitializeComponent();
            CarregarAlunos();
        }

        private void CarregarAlunos()
        {
            try
            {
                Conexao conexaoDB = new Conexao();
                MySqlConnection conn = conexaoDB.Conectar();

                string query = "SELECT * FROM alunos";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);

                dgvAlunos.DataSource = tabela;

                conexaoDB.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar alunos: " + ex.Message);
            }
        }


        private void btnCadastro_Click(object sender, EventArgs e)
        {
            CasatroAlunos cadastro = new CasatroAlunos();
            cadastro.Show();
            this.Hide();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            EditarAluno listar = new EditarAluno();
            listar.Show();
            this.Hide();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            ExcluirAlunos excluir = new ExcluirAlunos();
            excluir.Show();
            this.Hide();
        }
    }
}


