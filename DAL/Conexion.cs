using System.Data.SqlClient;

namespace DAL
{
    public static class Conexion
    {
        private static string NombreAplicacion = "Login";
        private static string Servidor = @"DESKTOP-FL8S9TQ\SQLEXPRESS";
        private static string BaseDatos = "Seguridad";

        public static string ConexionString(bool windowsAuthentication = true)
        {
            SqlConnectionStringBuilder constructor = new SqlConnectionStringBuilder()
            {
                ApplicationName = NombreAplicacion,
                DataSource = Servidor,
                InitialCatalog = BaseDatos,
                IntegratedSecurity = windowsAuthentication
            };
            if (!windowsAuthentication)
            {
                constructor.UserID = "luigi";
                constructor.Password = "&cuadra&";
            }
            return constructor.ConnectionString;
        }
    }
}

