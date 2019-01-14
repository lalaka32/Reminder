﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BLL.AdvertisingReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Advertising", Namespace="http://schemas.datacontract.org/2004/07/WFC")]
    [System.SerializableAttribute()]
    public partial class Advertising : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] PictureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
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
        public byte[] Picture {
            get {
                return this.PictureField;
            }
            set {
                if ((object.ReferenceEquals(this.PictureField, value) != true)) {
                    this.PictureField = value;
                    this.RaisePropertyChanged("Picture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AdvertisingReference.IAdvertisingService")]
    public interface IAdvertisingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdvertisingService/GetRandomAdvertising", ReplyAction="http://tempuri.org/IAdvertisingService/GetRandomAdvertisingResponse")]
        BLL.AdvertisingReference.Advertising GetRandomAdvertising();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdvertisingService/GetRandomAdvertising", ReplyAction="http://tempuri.org/IAdvertisingService/GetRandomAdvertisingResponse")]
        System.Threading.Tasks.Task<BLL.AdvertisingReference.Advertising> GetRandomAdvertisingAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAdvertisingServiceChannel : BLL.AdvertisingReference.IAdvertisingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdvertisingServiceClient : System.ServiceModel.ClientBase<BLL.AdvertisingReference.IAdvertisingService>, BLL.AdvertisingReference.IAdvertisingService {
        
        public AdvertisingServiceClient() {
        }
        
        public AdvertisingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AdvertisingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdvertisingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdvertisingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public BLL.AdvertisingReference.Advertising GetRandomAdvertising() {
            return base.Channel.GetRandomAdvertising();
        }
        
        public System.Threading.Tasks.Task<BLL.AdvertisingReference.Advertising> GetRandomAdvertisingAsync() {
            return base.Channel.GetRandomAdvertisingAsync();
        }
    }
}
