using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//Agregar referencia
using models = Northwind.Entity.Service.Northwind;

namespace Northwind.Web.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "INorthwindService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface INorthwindService
    {
        [OperationContract]
        List<models.ListOfOrders.ListOfOrders> ListOfOrders();

        [OperationContract]
        List<models.ListProductOrders.ListProductOrders> ListProductOrders(int orderId);

        [OperationContract]
        string RegisterOfOrders(models.RegisterOfOrders.RegisterOfOrders obj);
     
    }
}
