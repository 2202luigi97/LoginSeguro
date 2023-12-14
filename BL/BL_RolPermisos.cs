using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
