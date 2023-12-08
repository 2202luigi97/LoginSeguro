using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class BL_Usuarios
    {
        public static Usuarios RegistrarUsuarioInvitado(Usuarios Entidad)
        {
            //return DAL_Usuario.RegistrarUsuario(Entidad);
            if (Entidad != null && Entidad.IdUsuario == 0)
            {
                Entidad = DAL_Usuario.RegistrarUsuarioInvitado(Entidad);
                if (Entidad.IdUsuario > 0)
                {
                    Entidad.UsuarioRegistra = Entidad.IdUsuario;
                }
            }
            return Entidad;
        }
        public static bool ExisteUserName(string UserName)
        {
            return DAL_Usuario.ExisteUserName(UserName);
        }
        public static byte[] Encrypt(string FlatString)
        {
            return DAL_Usuario.Encrypt(FlatString);
        }
        public static bool VerificarCuentaBloqueada(string UserName)
        {
            return DAL_Usuario.VerificarCuentaBloqueada(UserName);
        }
        public static bool ValidarCredenciales(string UserName, byte[] Password)
        {
            return DAL_Usuario.ValidarCredenciales(UserName, Password);
        }
    }
}
