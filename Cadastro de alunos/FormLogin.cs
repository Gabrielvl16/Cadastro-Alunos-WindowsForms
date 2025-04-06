using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_alunos
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = "admin";
            string senha = "admin";

            if (txtUsuario.Text == usuario & txtSenha.Text == senha)
            {
                MessageBox.Show("Login realizado com sucesso!");
                CasatroAlunos form1 = new CasatroAlunos();
                form1.Show();
                this.Hide();
            }
            else if (txtUsuario.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
            }
        }
    }
}
