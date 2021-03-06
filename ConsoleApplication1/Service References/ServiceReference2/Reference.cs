﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MyException", Namespace="http://schemas.datacontract.org/2004/07/TrainService")]
    [System.SerializableAttribute()]
    public partial class MyException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MsgField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Msg {
            get {
                return this.MsgField;
            }
            set {
                if ((object.ReferenceEquals(this.MsgField, value) != true)) {
                    this.MsgField = value;
                    this.RaisePropertyChanged("Msg");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.Service1")]
    public interface Service1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service1/GetTripWithDate", ReplyAction="http://tempuri.org/Service1/GetTripWithDateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ConsoleApplication1.ServiceReference2.MyException), Action="http://tempuri.org/Service1/GetTripWithDateMyExceptionFault", Name="MyException", Namespace="http://schemas.datacontract.org/2004/07/TrainService")]
        string[] GetTripWithDate(string fromCity, string toCity, System.DateTime fromDate, System.DateTime toDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service1/GetTripWithDate", ReplyAction="http://tempuri.org/Service1/GetTripWithDateResponse")]
        System.Threading.Tasks.Task<string[]> GetTripWithDateAsync(string fromCity, string toCity, System.DateTime fromDate, System.DateTime toDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service1/GetTripWithoutDate", ReplyAction="http://tempuri.org/Service1/GetTripWithoutDateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ConsoleApplication1.ServiceReference2.MyException), Action="http://tempuri.org/Service1/GetTripWithoutDateMyExceptionFault", Name="MyException", Namespace="http://schemas.datacontract.org/2004/07/TrainService")]
        string[] GetTripWithoutDate(string fromCity, string toCity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service1/GetTripWithoutDate", ReplyAction="http://tempuri.org/Service1/GetTripWithoutDateResponse")]
        System.Threading.Tasks.Task<string[]> GetTripWithoutDateAsync(string fromCity, string toCity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Service1Channel : ConsoleApplication1.ServiceReference2.Service1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ConsoleApplication1.ServiceReference2.Service1>, ConsoleApplication1.ServiceReference2.Service1 {
        
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
