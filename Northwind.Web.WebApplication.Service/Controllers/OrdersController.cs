using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Agregamos referencias
using System.Collections;
using Northwind.Web.WebApplication.Service.ServiceOrders;
using models = Northwind.Entity.Service.Northwind;

namespace Northwind.Web.WebApplication.Service.Controllers
{
    public class OrdersController : Controller
    {
        //Instanciamos el servicio nuevo
        NorthwindServiceClient serviceOrders = new NorthwindServiceClient();
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListOfOrders()
        {
            return View();
        }

        #region GetListOfOrders
        //Metodo que obtiene la lista de Pedidos
        public JsonResult GetListOfOrders()
        {
            ArrayList dataOfOrdersList2 = new ArrayList();
            
            var dataOfOrdersList = serviceOrders.ListOfOrders();

            for (int i = 0; i < dataOfOrdersList.Length; i++)
            {
                models.ListOfOrders.ListOfOrders o = new models.ListOfOrders.ListOfOrders();

                o.OrderID = dataOfOrdersList[i].OrderID;
                o.OrderDate = Convert.ToDateTime(dataOfOrdersList[i].OrderDate).ToString("yyyy/MM/dd");
                o.ContactName = dataOfOrdersList[i].ContactName;
                o.Phone = dataOfOrdersList[i].Phone;

                //Agregamos los datos al ArrayList
                dataOfOrdersList2.Add(o);
            }
                return Json(new { data = dataOfOrdersList2 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult OrderConfirmation()
        {
            return View();
        }

        #region GetListProductOrders
        // Metodo que obtiene la lista de productos por pedidos
        public JsonResult GetListProductOrders(int orderId)
        {
            ArrayList dataListProducts2 = new ArrayList();
    
            var dataListProducts = serviceOrders.ListProductOrders(orderId);

            foreach (var data in dataListProducts)
            {
                models.ListProductOrders.ListProductOrders p = new models.ListProductOrders.ListProductOrders();
                p.ProductID = data.ProductID;
                p.ProductName = data.ProductName;
                p.Quantity = data.Quantity;
                p.UnitPrice = data.UnitPrice;
                p.Total = Convert.ToDouble(data.Quantity * data.UnitPrice);
                dataListProducts2.Add(p);
            }

            return Json(new { Data = dataListProducts2}, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region GetRegistertProductOrders
        //etodo que confirma el pedido
        public JsonResult GetRegistertProductOrders(models.RegisterOfOrders.RegisterOfOrders obj)
        {
            var objResultData = serviceOrders.RegisterOfOrders(obj);
            return Json(new {data = objResultData }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}