using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Web.WebApplication.Service.Models
{
    public class ProductosBL
    {
        public int OrderID { get; set; }
        public string ContactName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public double UnitPrice { get; set; }
    }
}