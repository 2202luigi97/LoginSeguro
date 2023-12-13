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
        public static Usuarios Insert(Usuarios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Usuarios.Add(Entidad);
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
        public static Usuarios Registro(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Find(IdRegistro);
            }
        }
        public static List<vUsuarios> vUsuarios(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = (from tblUsuarios in bd.Usuarios
                                join tblRoles in bd.Roles on tblUsuarios.IdRol equals tblRoles.IdRol
                                where tblUsuarios.Activo == Activo && tblRoles.Activo == Activo
                                orderby tblUsuarios.Nombre ascending
                                select new vUsuarios
                                {
                                    IdUsuario = tblUsuarios.IdUsuario,
                                    Nombre = tblUsuarios.Nombre,
                                    Correo = tblUsuarios.Correo,
                                    UserName = tblUsuarios.UserName,
                                    Bloqueo = tblUsuarios.Bloqueo,
                                    CuentaBloqueada = (tblUsuarios.Bloqueo) ? "SI" : "NO",
                                    Contador = tblUsuarios.Contador,
                                    IdRol = tblUsuarios.IdRol,
                                    Rol = tblRoles.Rol
                                }).ToList();
                return Consulta;
            }
        }
        public static vUsuarios vUsuario(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = (from tblUsuarios in bd.Usuarios
                                join tblRoles in bd.Roles on tblUsuarios.IdRol equals tblRoles.IdRol
                                where tblUsuarios.Activo == true && tblRoles.Activo == true && tblUsuarios.IdUsuario == IdRegistro
                                select new vUsuarios
                                {
                                    IdUsuario = tblUsuarios.IdUsuario,
                                    Nombre = tblUsuarios.Nombre,
                                    Correo = tblUsuarios.Correo,
                                    UserName = tblUsuarios.UserName,
                                    Bloqueo = tblUsuarios.Bloqueo,
                                    CuentaBloqueada = (tblUsuarios.Bloqueo) ? "SI" : "NO",
                                    Contador = tblUsuarios.Contador,
                                    IdRol = tblUsuarios.IdRol,
                                    Rol = tblRoles.Rol
                                }).SingleOrDefault();
                return Consulta;
            }
        }
        public static bool Update(Usuarios Entidad, bool UpdatePassword)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Usuarios.Find(Entidad.IdUsuario);
                RegistroBD.Nombre = Entidad.Nombre;
                RegistroBD.Correo = Entidad.Correo;
                RegistroBD.UserName = Entidad.UserName;
                if (UpdatePassword)
                {
                    RegistroBD.Password = Entidad.Password;
                }
                RegistroBD.IdRol = Entidad.IdRol;
                RegistroBD.UsuarioActualiza = Entidad.UsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool ExisteUserNameUpdate(string UserName, int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower() && a.IdUsuario != IdRegistro).Count() > 0;
            }
        }

    }
}
