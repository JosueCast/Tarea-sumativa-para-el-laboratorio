using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    public class DataBase
    {
        // Propiedad estática que obtiene la cadena de conexión a la base de datos
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión desde el archivo de configuración
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Crea un objeto SqlConnectionStringBuilder para construir la cadena de conexión
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Asigna el nombre de la aplicación si se ha definido, o mantiene el que ya está en la cadena de conexión
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Asigna el tiempo de espera de la conexión si es mayor a 0, o mantiene el que ya está en la cadena de conexión
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Retorna la cadena de conexión completa como una cadena de texto
                return conexionBuilder.ToString();
            }
        }

        // Propiedad estática para definir el tiempo de espera de la conexión
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática para definir el nombre de la aplicación
        public static string ApplicationName { get; set; }

        // Método estático que crea y abre una conexión a la base de datos usando la cadena de conexión
        public static SqlConnection GetSqlConnection()
        {
            // Crea una nueva conexión SQL utilizando la cadena de conexión configurada
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión
            conexion.Open();

            // Retorna la conexión abierta
            return conexion;
        }
    }

}
