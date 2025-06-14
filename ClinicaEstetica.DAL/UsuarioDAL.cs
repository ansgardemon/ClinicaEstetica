using System;
using System.Data.SqlClient;
using ClinicaEstetica.DTO;

namespace ClinicaEstetica.DAL
{
    public class UsuarioDAL : Conexao
    {
        public UsuarioDTO Autenticar(string Email, string Senha)
        {
			try
			{
				Conectar();
                command = new SqlCommand("SELECT * FROM Usuario WHERE Email = @Email AND Senha = @Senha;", conexao);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Senha", Senha);
                dataReader = command.ExecuteReader();


                UsuarioDTO usuario = null;
                if (dataReader.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.IdTipoUsuario = int.Parse(dataReader["IdTipoUsuario"].ToString());
                    usuario.Nome = dataReader["Nome"].ToString();
                    usuario.Email = dataReader["Email"].ToString();
                    usuario.Senha = dataReader["Senha"].ToString();
                    usuario.Status = bool.Parse(dataReader["Status"].ToString());
                }

                return usuario;
            }
			catch (Exception erro)
			{

				throw new Exception($"Erro: {erro.Message}");
			}
            finally
            {
                Desconectar();
            }
        }
    }
}
