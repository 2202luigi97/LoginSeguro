using DAL;
using EL;
using System.Collections.Generic;

namespace BL
{
    public class BL_RolPermisos
    {
        public static List<RolPermiso> List(int IdRol, bool Activo = true)
        {
            return DAL_RolPermisos.List(IdRol, Activo);
        }
    }
}
