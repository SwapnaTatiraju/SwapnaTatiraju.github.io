﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DrawASCIShapes.ASCIShapeServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/ADCIShapeService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="DrawASCIShapes", ConfigurationName="ASCIShapeServiceReference1.IASCIService1")]
    public interface IASCIService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="DrawASCIShapes/IASCIService1/GetData", ReplyAction="DrawASCIShapes/IASCIService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="DrawASCIShapes/IASCIService1/GetDataUsingDataContract", ReplyAction="DrawASCIShapes/IASCIService1/GetDataUsingDataContractResponse")]
        DrawASCIShapes.ASCIShapeServiceReference1.CompositeType GetDataUsingDataContract(DrawASCIShapes.ASCIShapeServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="DrawASCIShapes/IASCIService1/GenerateSquare", ReplyAction="DrawASCIShapes/IASCIService1/GenerateSquareResponse")]
        string[] GenerateSquare(int height, string TxtToDisplay, int TxtRowNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="DrawASCIShapes/IASCIService1/GenerateRectangle", ReplyAction="DrawASCIShapes/IASCIService1/GenerateRectangleResponse")]
        string[] GenerateRectangle(int height, string TxtToDisplay, int TxtRowNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="DrawASCIShapes/IASCIService1/GenerateTriangle", ReplyAction="DrawASCIShapes/IASCIService1/GenerateTriangleResponse")]
        string[] GenerateTriangle(int height, string TxtToDisplay, int TxtRowNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="DrawASCIShapes/IASCIService1/GenerateDiamond1", ReplyAction="DrawASCIShapes/IASCIService1/GenerateDiamond1Response")]
        string[] GenerateDiamond1(int height, string TxtToDisplay, int TxtRowNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="DrawASCIShapes/IASCIService1/GenerateDiamond2", ReplyAction="DrawASCIShapes/IASCIService1/GenerateDiamond2Response")]
        string[] GenerateDiamond2(int height, string TxtToDisplay, int TxtRowNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="DrawASCIShapes/IASCIService1/SaveHistoryToFile", ReplyAction="DrawASCIShapes/IASCIService1/SaveHistoryToFileResponse")]
        void SaveHistoryToFile(string Shape, int height, string TxtToDisplay, int TxtRowNum);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IASCIService1Channel : DrawASCIShapes.ASCIShapeServiceReference1.IASCIService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ASCIService1Client : System.ServiceModel.ClientBase<DrawASCIShapes.ASCIShapeServiceReference1.IASCIService1>, DrawASCIShapes.ASCIShapeServiceReference1.IASCIService1 {
        
        public ASCIService1Client() {
        }
        
        public ASCIService1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ASCIService1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ASCIService1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ASCIService1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public DrawASCIShapes.ASCIShapeServiceReference1.CompositeType GetDataUsingDataContract(DrawASCIShapes.ASCIShapeServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public string[] GenerateSquare(int height, string TxtToDisplay, int TxtRowNum) {
            return base.Channel.GenerateSquare(height, TxtToDisplay, TxtRowNum);
        }
        
        public string[] GenerateRectangle(int height, string TxtToDisplay, int TxtRowNum) {
            return base.Channel.GenerateRectangle(height, TxtToDisplay, TxtRowNum);
        }
        
        public string[] GenerateTriangle(int height, string TxtToDisplay, int TxtRowNum) {
            return base.Channel.GenerateTriangle(height, TxtToDisplay, TxtRowNum);
        }
        
        public string[] GenerateDiamond1(int height, string TxtToDisplay, int TxtRowNum) {
            return base.Channel.GenerateDiamond1(height, TxtToDisplay, TxtRowNum);
        }
        
        public string[] GenerateDiamond2(int height, string TxtToDisplay, int TxtRowNum) {
            return base.Channel.GenerateDiamond2(height, TxtToDisplay, TxtRowNum);
        }
        
        public void SaveHistoryToFile(string Shape, int height, string TxtToDisplay, int TxtRowNum) {
            base.Channel.SaveHistoryToFile(Shape, height, TxtToDisplay, TxtRowNum);
        }
    }
}