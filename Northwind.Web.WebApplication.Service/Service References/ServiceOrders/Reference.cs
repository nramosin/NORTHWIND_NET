﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Northwind.Web.WebApplication.Service.ServiceOrders {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceOrders.INorthwindService")]
    public interface INorthwindService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INorthwindService/ListOfOrders", ReplyAction="http://tempuri.org/INorthwindService/ListOfOrdersResponse")]
        Northwind.Entity.Service.Northwind.ListOfOrders.ListOfOrders[] ListOfOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INorthwindService/ListOfOrders", ReplyAction="http://tempuri.org/INorthwindService/ListOfOrdersResponse")]
        System.Threading.Tasks.Task<Northwind.Entity.Service.Northwind.ListOfOrders.ListOfOrders[]> ListOfOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INorthwindService/ListProductOrders", ReplyAction="http://tempuri.org/INorthwindService/ListProductOrdersResponse")]
        Northwind.Entity.Service.Northwind.ListProductOrders.ListProductOrders[] ListProductOrders(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INorthwindService/ListProductOrders", ReplyAction="http://tempuri.org/INorthwindService/ListProductOrdersResponse")]
        System.Threading.Tasks.Task<Northwind.Entity.Service.Northwind.ListProductOrders.ListProductOrders[]> ListProductOrdersAsync(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INorthwindService/RegisterOfOrders", ReplyAction="http://tempuri.org/INorthwindService/RegisterOfOrdersResponse")]
        string RegisterOfOrders(Northwind.Entity.Service.Northwind.RegisterOfOrders.RegisterOfOrders obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INorthwindService/RegisterOfOrders", ReplyAction="http://tempuri.org/INorthwindService/RegisterOfOrdersResponse")]
        System.Threading.Tasks.Task<string> RegisterOfOrdersAsync(Northwind.Entity.Service.Northwind.RegisterOfOrders.RegisterOfOrders obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INorthwindServiceChannel : Northwind.Web.WebApplication.Service.ServiceOrders.INorthwindService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NorthwindServiceClient : System.ServiceModel.ClientBase<Northwind.Web.WebApplication.Service.ServiceOrders.INorthwindService>, Northwind.Web.WebApplication.Service.ServiceOrders.INorthwindService {
        
        public NorthwindServiceClient() {
        }
        
        public NorthwindServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NorthwindServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NorthwindServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NorthwindServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Northwind.Entity.Service.Northwind.ListOfOrders.ListOfOrders[] ListOfOrders() {
            return base.Channel.ListOfOrders();
        }
        
        public System.Threading.Tasks.Task<Northwind.Entity.Service.Northwind.ListOfOrders.ListOfOrders[]> ListOfOrdersAsync() {
            return base.Channel.ListOfOrdersAsync();
        }
        
        public Northwind.Entity.Service.Northwind.ListProductOrders.ListProductOrders[] ListProductOrders(int orderId) {
            return base.Channel.ListProductOrders(orderId);
        }
        
        public System.Threading.Tasks.Task<Northwind.Entity.Service.Northwind.ListProductOrders.ListProductOrders[]> ListProductOrdersAsync(int orderId) {
            return base.Channel.ListProductOrdersAsync(orderId);
        }
        
        public string RegisterOfOrders(Northwind.Entity.Service.Northwind.RegisterOfOrders.RegisterOfOrders obj) {
            return base.Channel.RegisterOfOrders(obj);
        }
        
        public System.Threading.Tasks.Task<string> RegisterOfOrdersAsync(Northwind.Entity.Service.Northwind.RegisterOfOrders.RegisterOfOrders obj) {
            return base.Channel.RegisterOfOrdersAsync(obj);
        }
    }
}