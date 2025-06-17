using System.Collections.Generic;
using ClinicaEstetica.DAL;
using ClinicaEstetica.DTO;

namespace ClinicaEstetica.BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();


        public UsuarioDTO AutenticarUsuario(string email, string senha)
        {
            return usuarioDAL.Autenticar(email, senha);
        }


        public List<UsuarioDTO> ListarTodosUsuario()
        {
            return usuarioDAL.ListarTodos();
        }


        public List<TipoUsuarioDTO> GetTipoUsuario()
        {
            return usuarioDAL.GetTipos();
        }


        public void CreateUsuario(UsuarioDTO usuarioDTO)
        {
            usuarioDAL.Create(usuarioDTO);
        }

        public void UpdateUsuario(UsuarioDTO usuarioDTO)
        {
            usuarioDAL.Update(usuarioDTO);
        }

        public void DeletarUsuario(int idUsuario)
        {
            usuarioDAL.Delete(idUsuario);
        }


    }
}
