using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Agregamos referencias para conectarnos a la base de datos
using System.Data.SqlClient;
using System.Configuration;

namespace Northwind.Web.Services.ConexionDB
{
    public class Conexion
    {
        public SqlConnection ConectarDB()
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);

            return conexion;
        }
    }
}