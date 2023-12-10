using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Roles
    {
        public static Roles ObtenerRolPorId(int idRol)
        {
            using (BDContexto bd = new BDContexto()) 
            {
                return bd.Roles.FirstOrDefault(r => r.IdRol == idRol);
            }
            
        }
        public static List<Roles> List(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Roles.Where(a => a.Activo == Activo).ToList();
            }
        }

    }
}
