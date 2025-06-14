using System;
using System.Windows.Forms;
using ClinicaEstetica.BLL;
using ClinicaEstetica.DTO;

namespace ClinicaEstetica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            UsuarioDTO usuarioDTO = new UsuarioDTO();
            UsuarioBLL usuarioBLL = new UsuarioBLL();



            usuarioDTO = usuarioBLL.AutenticarUsuario(email, senha);

            if (usuarioDTO != null)
            {
                MessageBox.Show($"Bem Vindo(a) {usuarioDTO.Nome}", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show($"Não foi possível efetuar o login. Tente novamente!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
