

namespace EL
{
    public class Enums
    {
        //Definir valor de los Formularios
        public enum eFormulario
        {
            AdministracionUsuario = 1,
            Ventas = 2,
            Inventario = 3,
            Reportes = 5
        }
        //Definir valor a los Roles
        public enum eRoles
        {
            Administrador = 1,
            Jefe_Ventas = 2,
            Jefe_Almacen = 3,
            Gerente_General = 4,
            Invitado = 5
        }
        //Definir valor de los Permisos
        public enum ePermisos
        {
            Escritura = 1,
            Anular = 2,
            Bloqueo = 3,
            Facturar = 4,
            Reporte = 5
        }

    }
}
