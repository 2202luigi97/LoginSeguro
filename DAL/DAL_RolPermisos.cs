using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_RolPermisos
    {
        public static List<RolPermiso> List(int IdRol, bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.RolPermisos.Where(a => a.IdRol == IdRol && a.Activo == Activo).ToList();
            }
        }
    }
}
