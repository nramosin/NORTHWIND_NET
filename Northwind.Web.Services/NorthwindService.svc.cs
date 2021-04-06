using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
// Agregamos referencias para conectarnos a la base de datos
using System.Data;
using System.Data.SqlClient;
using models = Northwind.Entity.Service.Northwind;
using System.Collections;

namespace Northwind.Web.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "NorthwindService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione NorthwindService.svc o NorthwindService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class NorthwindService : INorthwindService
    {
        ConexionDB.Conexion cn = new ConexionDB.Conexion();

        SqlConnection conexion;
        List<models.ListOfOrders.ListOfOrders> INorthwindService.ListOfOrders()
        {
            List<models.ListOfOrders.ListOfOrders> listPedidos = new List<models.ListOfOrders.ListOfOrders>();

            conexion = cn.ConectarDB();

            SqlCommand cmd = new SqlCommand("[SP_LISTAR_PEDIDOS_PENDIENTE]", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            //Inicia conexion
            conexion.Open();
            IDataReader dr = null;

            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    models.ListOfOrders.ListOfOrders p = new models.ListOfOrders.ListOfOrders();
                    p.OrderID = Convert.ToInt16(dr["Nro Orden"].ToString());
                    p.OrderDate = dr["Fecha"].ToString();
                    p.ContactName = dr["Nombre/Razon Social"].ToString();
                    p.Phone = dr["Telefono"].ToString();

                    listPedidos.Add(p);
                }

                dr.Close();
                conexion.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return listPedidos;
        }

        List<models.ListProductOrders.ListProductOrders> INorthwindService.ListProductOrders(int orderId)
        {
            List<models.ListProductOrders.ListProductOrders> listProductos = new List<models.ListProductOrders.ListProductOrders>();

            conexion = cn.ConectarDB();

            SqlCommand cmd = new SqlCommand("SP_LISTAR_PRODUCTOS", conexion);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", orderId);

            //Inicia conexion
            conexion.Open();
            IDataReader dr = null;

            try
            {
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    models.ListProductOrders.ListProductOrders p = new models.ListProductOrders.ListProductOrders();
                    p.OrderID = Convert.ToInt16(dr["Pedido"]);
                    p.ContactName = dr["Nombre/Razon Social"].ToString();
                    p.ProductID = Convert.ToInt16(dr["Código"]);
                    p.ProductName = dr["Descripción"].ToString();
                    p.Quantity = Convert.ToInt16(dr["Cantidad"]);
                    p.UnitPrice = Convert.ToDouble(dr["Precio"]);
                    p.Total = Convert.ToDouble(dr["Total"]);

                    listProductos.Add(p);
                }
                dr.Close();
                conexion.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return listProductos;
        }
        
        string INorthwindService.RegisterOfOrders(models.RegisterOfOrders.RegisterOfOrders obj)
        {
            var strMensaje = "";
            //var strCodConfirm = "";
            conexion = cn.ConectarDB();

            SqlCommand cmd = new SqlCommand("SP_REGISTRAR_PEDIDOS", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DateConfirmation", obj.DateConfirmation);
            cmd.Parameters.AddWithValue("@Confirmed", obj.Confirmed);
            cmd.Parameters.AddWithValue("@Comments", obj.Comments);

            //Abrir conexion
            conexion.Open();

            try
            {
                cmd.ExecuteNonQuery();
                strMensaje = "0|Confirmación de pedido exitoso";
            }
            catch(Exception ex)
            {
                strMensaje = ex.Message;
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                conexion.Dispose();
                cmd.Dispose();
            }
            return strMensaje;

        }
    }
}
