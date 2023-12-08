using DAL;
using EL;
using System.Collections.Generic;


namespace BL
{
    public class BL_RolFormulario
    {
        public static List<RolFormulario> List(int IdRol, bool Activo = true)
        {
            return DAL_RolFormulario.List(IdRol, Activo);
        }
    }
}
