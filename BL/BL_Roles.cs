using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class BL_Roles
    {
        public static Roles ObtenerRolPorId(int idRol)
        {
            return DAL_Roles.ObtenerRolPorId(idRol);
        }
        public static List<Roles> List(bool Activo = true)
        {
            return DAL_Roles.List(Activo);
        }
    }
}
