﻿using System.Reflection.Emit;
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
    }
}
