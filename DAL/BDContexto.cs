using EL;
using System.Data.Entity;


namespace DAL
{
    public class BDContexto:DbContext
    {
        public BDContexto() : base(Conexion.ConexionString())
        { }

        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Formularios> Formularios { get; set; }
        public virtual DbSet<RolFormulario> RolFormularios { get; set; }
        public virtual DbSet<RolPermiso> RolPermisos { get; set; }
    }
}
