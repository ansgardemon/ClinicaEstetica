using System;
using System.Windows.Forms;
using ClinicaEstetica.BLL;
using ClinicaEstetica.DTO;

namespace ClinicaEstetica
{
    public partial class frmUsuarios : Form
    {

        private UsuarioBLL usuarioBLL = new UsuarioBLL();
        private UsuarioDTO usuarioDTO = new UsuarioDTO();

        public frmUsuarios()
        {
            InitializeComponent();
        }



        private void CarregarUsuarios()
        {
            var usuarios = usuarioBLL.ListarTodosUsuario();
            dgvUsuarios.DataSource = usuarios;
        }

        private void LimparCampos()
        {
            txtId.Text = string.Empty;
            cboTipo.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtSenha.Text = string.Empty;
            chkStatus.Checked = false;
            txtEmail.Text = string.Empty;
        }

        private void SalvarUsuarios()
        {

        }



        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
            cboTipo.DisplayMember = "Nome";
            cboTipo.DataSource = usuarioBLL.GetTipoUsuario();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var usuario = (UsuarioDTO)dgvUsuarios.SelectedRows[0].DataBoundItem;
                usuarioDTO = usuario;
                txtId.Text = usuario.IdUsuario.ToString();
                var tipo = usuario.IdTipoUsuario == 1 ? "Administrador" : "Operador";
                cboTipo.Text = tipo;
                txtNome.Text = usuario.Nome.ToString();
                txtEmail.Text = usuario.Email.ToString();
                txtSenha.Text = usuario.Senha.ToString();
                chkStatus.Checked = usuario.Status;

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha o nome!");
                return;
            }

            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                IdTipoUsuario = cboTipo.Text == "Administrador" ? 1 : 2,
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                Status = chkStatus.Checked
            };

            if (string.IsNullOrEmpty(txtId.Text))
            {
                usuarioBLL.CreateUsuario(usuarioDTO);
                MessageBox.Show($"Usuário {usuarioDTO.Nome} cadastrado com sucesso!");
                CarregarUsuarios();
            }
            else
            {
                usuarioDTO.IdUsuario = int.Parse(txtId.Text);
                usuarioBLL.UpdateUsuario(usuarioDTO);
                MessageBox.Show($"Usuário {usuarioDTO.Nome} atualizado com sucesso!");
                CarregarUsuarios();
            }


        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (usuarioDTO == null) return;


            var escolha = MessageBox.Show($"Deseja excluir o usuário {usuarioDTO.Nome}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (escolha == DialogResult.Yes)
            {
                usuarioBLL.DeletarUsuario(usuarioDTO.IdUsuario);
                MessageBox.Show($"Usuário {usuarioDTO.Nome} excluído com sucesso!");
                CarregarUsuarios();
            }
        }
    }
}

