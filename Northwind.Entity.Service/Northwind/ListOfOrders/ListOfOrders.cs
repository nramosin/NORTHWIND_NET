using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Northwind.Entity.Service.Northwind.ListOfOrders
{
    [DataContract]
    public class ListOfOrders
    {
        [DataMember]
        public int OrderID { get; set; }

        [DataMember]
        public string OrderDate { get; set; }

        [DataMember]
        public string ContactName { get; set; }

        [DataMember]
        public string Phone { get; set; }
    }
}
