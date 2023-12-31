﻿

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
            Caja = 4,
            Invitado = 5,
            Bodega = 6,
            Gerente_General = 7
        }
        //Definir valor de los Permisos
        public enum ePermisos
        {
            AgregarUsuario = 1,
            AnularUsuario = 2,
            BloquearUsuario=3,
            CrearFactura = 4,
            EditarFactura = 5,
            AnularFactura = 7,
            ReporteVenta = 8,
            ReporteInventario = 9,
            AgregarInventario = 10,
            EditarInventario = 11,
            AnularInventario = 12
        }

    }
}
