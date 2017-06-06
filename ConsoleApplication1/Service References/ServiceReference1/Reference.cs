﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTripWithDate", ReplyAction="http://tempuri.org/IService1/GetTripWithDateResponse")]
        string[] GetTripWithDate(string fromCity, string toCity, System.DateTime fromDate, System.DateTime toDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTripWithDate", ReplyAction="http://tempuri.org/IService1/GetTripWithDateResponse")]
        System.Threading.Tasks.Task<string[]> GetTripWithDateAsync(string fromCity, string toCity, System.DateTime fromDate, System.DateTime toDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTripWithoutDate", ReplyAction="http://tempuri.org/IService1/GetTripWithoutDateResponse")]
        string[] GetTripWithoutDate(string fromCity, string toCity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTripWithoutDate", ReplyAction="http://tempuri.org/IService1/GetTripWithoutDateResponse")]
        System.Threading.Tasks.Task<string[]> GetTripWithoutDateAsync(string fromCity, string toCity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ConsoleApplication1.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ConsoleApplication1.ServiceReference1.IService1>, ConsoleApplication1.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetTripWithDate(string fromCity, string toCity, System.DateTime fromDate, System.DateTime toDate) {
            return base.Channel.GetTripWithDate(fromCity, toCity, fromDate, toDate);
        }
        
        public System.Threading.Tasks.Task<string[]> GetTripWithDateAsync(string fromCity, string toCity, System.DateTime fromDate, System.DateTime toDate) {
            return base.Channel.GetTripWithDateAsync(fromCity, toCity, fromDate, toDate);
        }
        
        public string[] GetTripWithoutDate(string fromCity, string toCity) {
            return base.Channel.GetTripWithoutDate(fromCity, toCity);
        }
        
        public System.Threading.Tasks.Task<string[]> GetTripWithoutDateAsync(string fromCity, string toCity) {
            return base.Channel.GetTripWithoutDateAsync(fromCity, toCity);
        }
    }
}