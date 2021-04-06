using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Northwind.Entity.Service.Northwind.RegisterOfOrders
{
    [DataContract]
    public class RegisterOfOrders
    {
        [DataMember]
        public string DateConfirmation { get; set; }

        [DataMember]
        public int Confirmed { get; set; }

        [DataMember]
        public string Comments { get; set; }
    }
}
