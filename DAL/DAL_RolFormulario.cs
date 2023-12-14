using EL;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_RolFormulario
    {
        public static List<RolFormulario> List(int IdRol, bool Activo= true) 
        {
            using (BDContexto bd = new BDContexto()) 
            {
                return bd.RolFormularios.Where(a=>a.IdRol==IdRol &&  a.Activo==Activo).ToList();
            }
        }
    }
}
