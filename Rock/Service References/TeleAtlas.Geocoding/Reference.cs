﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rock.TeleAtlas.Geocoding
{

#pragma warning disable 1591
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.wsdl", ConfigurationName="TeleAtlas.Geocoding.GeocodingPortType")]
    public interface GeocodingPortType {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ezlocate.na.teleatlas.com/Geocoding.xsd1) of message getServicesRequest does not match the default value (http://ezlocate.na.teleatlas.com/Geocoding.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="Geocoding:GeocodingPortType#getServices", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Rock.TeleAtlas.Geocoding.getServicesResponse getServices(Rock.TeleAtlas.Geocoding.getServicesRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ezlocate.na.teleatlas.com/Geocoding.xsd1) of message getServiceDescriptionRequest does not match the default value (http://ezlocate.na.teleatlas.com/Geocoding.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="Geocoding:GeocodingPortType#getServiceDescription", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Rock.TeleAtlas.Geocoding.getServiceDescriptionResponse getServiceDescription(Rock.TeleAtlas.Geocoding.getServiceDescriptionRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ezlocate.na.teleatlas.com/Geocoding.xsd1) of message findAddressRequest does not match the default value (http://ezlocate.na.teleatlas.com/Geocoding.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="Geocoding:GeocodingPortType#findAddress", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Rock.TeleAtlas.Geocoding.findAddressResponse findAddress(Rock.TeleAtlas.Geocoding.findAddressRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ezlocate.na.teleatlas.com/Geocoding.xsd1) of message findMultiAddressRequest does not match the default value (http://ezlocate.na.teleatlas.com/Geocoding.wsdl)
        [System.ServiceModel.OperationContractAttribute(Action="Geocoding:GeocodingPortType#findMultiAddress", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Rock.TeleAtlas.Geocoding.findMultiAddressResponse findMultiAddress(Rock.TeleAtlas.Geocoding.findMultiAddressRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1")]
    public partial class NameValue : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nameField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=1)]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("value");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1")]
    public partial class Geocode : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int resultCodeField;
        
        private NameValue[] mAttributesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int resultCode {
            get {
                return this.resultCodeField;
            }
            set {
                this.resultCodeField = value;
                this.RaisePropertyChanged("resultCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("nv", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public NameValue[] mAttributes {
            get {
                return this.mAttributesField;
            }
            set {
                this.mAttributesField = value;
                this.RaisePropertyChanged("mAttributes");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1")]
    public partial class MatchType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nameField;
        
        private string descriptionField;
        
        private int idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=1)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1")]
    public partial class OutputField : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nameField;
        
        private string descriptionField;
        
        private int typeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=1)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public int type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("type");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getServices", WrapperNamespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", IsWrapped=true)]
    public partial class getServicesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int identity;
        
        public getServicesRequest() {
        }
        
        public getServicesRequest(int identity) {
            this.identity = identity;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getServicesResponse", WrapperNamespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", IsWrapped=true)]
    public partial class getServicesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int resultCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=1)]
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("nv", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Rock.TeleAtlas.Geocoding.NameValue[] services;
        
        public getServicesResponse() {
        }
        
        public getServicesResponse(int resultCode, Rock.TeleAtlas.Geocoding.NameValue[] services) {
            this.resultCode = resultCode;
            this.services = services;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getServiceDescription", WrapperNamespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", IsWrapped=true)]
    public partial class getServiceDescriptionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string service;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int identity;
        
        public getServiceDescriptionRequest() {
        }
        
        public getServiceDescriptionRequest(string service, int identity) {
            this.service = service;
            this.identity = identity;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getServiceDescriptionResponse", WrapperNamespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", IsWrapped=true)]
    public partial class getServiceDescriptionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int resultCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string description;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string countryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=3)]
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("nv", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Rock.TeleAtlas.Geocoding.NameValue[] inputs;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=4)]
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("fields", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Rock.TeleAtlas.Geocoding.OutputField[] outputs;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=5)]
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("types", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Rock.TeleAtlas.Geocoding.MatchType[] matchTypes;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string matchTypeName;
        
        public getServiceDescriptionResponse() {
        }
        
        public getServiceDescriptionResponse(int resultCode, string description, string countryCode, Rock.TeleAtlas.Geocoding.NameValue[] inputs, Rock.TeleAtlas.Geocoding.OutputField[] outputs, Rock.TeleAtlas.Geocoding.MatchType[] matchTypes, string matchTypeName) {
            this.resultCode = resultCode;
            this.description = description;
            this.countryCode = countryCode;
            this.inputs = inputs;
            this.outputs = outputs;
            this.matchTypes = matchTypes;
            this.matchTypeName = matchTypeName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findAddress", WrapperNamespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", IsWrapped=true)]
    public partial class findAddressRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string service;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=1)]
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("nv", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Rock.TeleAtlas.Geocoding.NameValue[] input;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int identity;
        
        public findAddressRequest() {
        }
        
        public findAddressRequest(string service, Rock.TeleAtlas.Geocoding.NameValue[] input, int identity) {
            this.service = service;
            this.input = input;
            this.identity = identity;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findAddressResponse", WrapperNamespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", IsWrapped=true)]
    public partial class findAddressResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int resultCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Rock.TeleAtlas.Geocoding.Geocode result;
        
        public findAddressResponse() {
        }
        
        public findAddressResponse(int resultCode, Rock.TeleAtlas.Geocoding.Geocode result) {
            this.resultCode = resultCode;
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findMultiAddress", WrapperNamespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", IsWrapped=true)]
    public partial class findMultiAddressRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string service;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=1)]
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("record", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("nv", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, NestingLevel=1)]
        public Rock.TeleAtlas.Geocoding.NameValue[][] inputs;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int identity;
        
        public findMultiAddressRequest() {
        }
        
        public findMultiAddressRequest(string service, Rock.TeleAtlas.Geocoding.NameValue[][] inputs, int identity) {
            this.service = service;
            this.inputs = inputs;
            this.identity = identity;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findMultiAddressResponse", WrapperNamespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", IsWrapped=true)]
    public partial class findMultiAddressResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int resultCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ezlocate.na.teleatlas.com/Geocoding.xsd1", Order=1)]
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("sequence", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Rock.TeleAtlas.Geocoding.Geocode[] results;
        
        public findMultiAddressResponse() {
        }
        
        public findMultiAddressResponse(int resultCode, Rock.TeleAtlas.Geocoding.Geocode[] results) {
            this.resultCode = resultCode;
            this.results = results;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GeocodingPortTypeChannel : Rock.TeleAtlas.Geocoding.GeocodingPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GeocodingPortTypeClient : System.ServiceModel.ClientBase<Rock.TeleAtlas.Geocoding.GeocodingPortType>, Rock.TeleAtlas.Geocoding.GeocodingPortType {
        
        public GeocodingPortTypeClient() {
        }
        
        public GeocodingPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GeocodingPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GeocodingPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GeocodingPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Rock.TeleAtlas.Geocoding.getServicesResponse Rock.TeleAtlas.Geocoding.GeocodingPortType.getServices(Rock.TeleAtlas.Geocoding.getServicesRequest request) {
            return base.Channel.getServices(request);
        }
        
        public int getServices(int identity, out Rock.TeleAtlas.Geocoding.NameValue[] services) {
            Rock.TeleAtlas.Geocoding.getServicesRequest inValue = new Rock.TeleAtlas.Geocoding.getServicesRequest();
            inValue.identity = identity;
            Rock.TeleAtlas.Geocoding.getServicesResponse retVal = ((Rock.TeleAtlas.Geocoding.GeocodingPortType)(this)).getServices(inValue);
            services = retVal.services;
            return retVal.resultCode;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Rock.TeleAtlas.Geocoding.getServiceDescriptionResponse Rock.TeleAtlas.Geocoding.GeocodingPortType.getServiceDescription(Rock.TeleAtlas.Geocoding.getServiceDescriptionRequest request) {
            return base.Channel.getServiceDescription(request);
        }
        
        public int getServiceDescription(string service, int identity, out string description, out string countryCode, out Rock.TeleAtlas.Geocoding.NameValue[] inputs, out Rock.TeleAtlas.Geocoding.OutputField[] outputs, out Rock.TeleAtlas.Geocoding.MatchType[] matchTypes, out string matchTypeName) {
            Rock.TeleAtlas.Geocoding.getServiceDescriptionRequest inValue = new Rock.TeleAtlas.Geocoding.getServiceDescriptionRequest();
            inValue.service = service;
            inValue.identity = identity;
            Rock.TeleAtlas.Geocoding.getServiceDescriptionResponse retVal = ((Rock.TeleAtlas.Geocoding.GeocodingPortType)(this)).getServiceDescription(inValue);
            description = retVal.description;
            countryCode = retVal.countryCode;
            inputs = retVal.inputs;
            outputs = retVal.outputs;
            matchTypes = retVal.matchTypes;
            matchTypeName = retVal.matchTypeName;
            return retVal.resultCode;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Rock.TeleAtlas.Geocoding.findAddressResponse Rock.TeleAtlas.Geocoding.GeocodingPortType.findAddress(Rock.TeleAtlas.Geocoding.findAddressRequest request) {
            return base.Channel.findAddress(request);
        }
        
        public int findAddress(string service, Rock.TeleAtlas.Geocoding.NameValue[] input, int identity, out Rock.TeleAtlas.Geocoding.Geocode result) {
            Rock.TeleAtlas.Geocoding.findAddressRequest inValue = new Rock.TeleAtlas.Geocoding.findAddressRequest();
            inValue.service = service;
            inValue.input = input;
            inValue.identity = identity;
            Rock.TeleAtlas.Geocoding.findAddressResponse retVal = ((Rock.TeleAtlas.Geocoding.GeocodingPortType)(this)).findAddress(inValue);
            result = retVal.result;
            return retVal.resultCode;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Rock.TeleAtlas.Geocoding.findMultiAddressResponse Rock.TeleAtlas.Geocoding.GeocodingPortType.findMultiAddress(Rock.TeleAtlas.Geocoding.findMultiAddressRequest request) {
            return base.Channel.findMultiAddress(request);
        }
        
        public int findMultiAddress(string service, Rock.TeleAtlas.Geocoding.NameValue[][] inputs, int identity, out Rock.TeleAtlas.Geocoding.Geocode[] results) {
            Rock.TeleAtlas.Geocoding.findMultiAddressRequest inValue = new Rock.TeleAtlas.Geocoding.findMultiAddressRequest();
            inValue.service = service;
            inValue.inputs = inputs;
            inValue.identity = identity;
            Rock.TeleAtlas.Geocoding.findMultiAddressResponse retVal = ((Rock.TeleAtlas.Geocoding.GeocodingPortType)(this)).findMultiAddress(inValue);
            results = retVal.results;
            return retVal.resultCode;
        }
    }
}
