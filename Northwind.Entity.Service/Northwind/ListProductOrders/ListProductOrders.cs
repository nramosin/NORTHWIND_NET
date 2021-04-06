using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Northwind.Entity.Service.Northwind.ListProductOrders
{
    [DataContract]
    public class ListProductOrders
    {
        [DataMember]
        public int OrderID { get; set; }

        [DataMember]
        public string ContactName { get; set; }

        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public double UnitPrice { get; set; }

        [DataMember]
        public double Total { get; set; }
    }
}
