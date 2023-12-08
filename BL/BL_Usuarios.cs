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
        public static Usuarios ExisteUsuario_x_UserName(string UserName)
        {
            return DAL_Usuario.ExisteUsuario_x_UserName(UserName);
        }
        public static short CantidadIntentosFallidos(string UserName)
        {
            return DAL_Usuario.CantidadIntentosFallidos(UserName);
        }
        public static bool BloquearCuentaUsuario(int IdRegistro, bool Bloquear, int IdUsuarioActualiza)
        {
            return DAL_Usuario.BloquearCuentaUsuario(IdRegistro, Bloquear, IdUsuarioActualiza);
        }
        public static bool SumarIntentosFallido(int IdRegistro)
        {
            return DAL_Usuario.SumarIntentosFallido(IdRegistro);
        }
        public static bool RestablecerIntentosFallido(int IdRegistro, int IdUsuarioActualiza)
        {
            return DAL_Usuario.RestablecerIntentosFallido(IdRegistro, IdUsuarioActualiza);
        }
        public static Usuarios Registro(int IdRegistro)
        {
            return DAL_Usuario.Registro(IdRegistro);
        }
    }
}
