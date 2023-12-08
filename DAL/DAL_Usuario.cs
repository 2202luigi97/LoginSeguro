using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;

namespace DAL
{
    public class DAL_Usuario
    {
        private static byte[] key = Encoding.UTF8.GetBytes("S3Gur1d4d1nf0rm4t1c42o23");
        private static byte[] IV = Encoding.UTF8.GetBytes("L0g1nPr0y3ct2o23");

        public static Usuarios RegistrarUsuarioInvitado(Usuarios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro=DateTime.Now;
                Entidad.IdRol = 5;
                bd.Usuarios.Add(Entidad);
                bd.SaveChanges();
                Entidad.UsuarioRegistra = Entidad.IdUsuario;
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool ExisteUserName(string UserName)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower()== UserName.ToLower()).Count()>0;
            }
        }
        public static byte[] Encrypt(string FlatString)
        {
            return Encripty.Encrypt(FlatString, key, IV);
        }
        public static bool VerificarCuentaBloqueada(string UserName)
        {
            using (BDContexto bd= new BDContexto()) 
            {
                return bd.Usuarios.Where(a=>a.UserName.ToLower()==UserName.ToLower()&&a.Bloqueo).Count()>0;
            }
        }
        public static bool ValidarCredenciales(string UserName, byte[] Password)
        { 
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName && a.Password == Password).Count()>0;
            }
        }
        public static Usuarios ExisteUsuario_x_UserName(string UserName) 
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a=>a.UserName.ToLower()==UserName.ToLower()).SingleOrDefault();
            }
        }
        public static short CantidadIntentosFallidos(string UserName)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower()).SingleOrDefault().Contador;
            }
        }
        public static bool BloquearCuentaUsuario(int IdRegistro, bool Bloquear, int UsuarioActualiza)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Registro = bd.Usuarios.Find(IdRegistro);
                Registro.Bloqueo = Bloquear;
                if (!Bloquear) { Registro.Contador = 0; }
                Registro.UsuarioActualiza = UsuarioActualiza;
                Registro.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool SumarIntentosFallido(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Registro = bd.Usuarios.Find(IdRegistro);
                Registro.Contador = Convert.ToInt16(Registro.Contador + 1);
                return bd.SaveChanges() > 0;
            }
        }
        public static bool RestablecerIntentosFallido(int IdRegistro, int UsuarioActualiza)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Registro = bd.Usuarios.Find(IdRegistro);
                Registro.Contador = 0;
                Registro.UsuarioActualiza = UsuarioActualiza;
                Registro.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
    }
}
