﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdventureWorks.WcfService.Testes.AdventureWorksServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/AdventureWorks.Repositorios.SqlServer.EF." +
        "DatabaseFirst")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ColorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DaysToManufactureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DiscontinuedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool FinishedGoodsFlagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal ListPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool MakeFlagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ModifiedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductLineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ProductModelIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ProductSubcategoryIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short ReorderPointField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short SafetyStockLevelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> SellEndDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime SellStartDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SizeUnitMeasureCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal StandardCostField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StyleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> WeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WeightUnitMeasureCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid rowguidField;
        
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
        public string Class {
            get {
                return this.ClassField;
            }
            set {
                if ((object.ReferenceEquals(this.ClassField, value) != true)) {
                    this.ClassField = value;
                    this.RaisePropertyChanged("Class");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Color {
            get {
                return this.ColorField;
            }
            set {
                if ((object.ReferenceEquals(this.ColorField, value) != true)) {
                    this.ColorField = value;
                    this.RaisePropertyChanged("Color");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DaysToManufacture {
            get {
                return this.DaysToManufactureField;
            }
            set {
                if ((this.DaysToManufactureField.Equals(value) != true)) {
                    this.DaysToManufactureField = value;
                    this.RaisePropertyChanged("DaysToManufacture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DiscontinuedDate {
            get {
                return this.DiscontinuedDateField;
            }
            set {
                if ((this.DiscontinuedDateField.Equals(value) != true)) {
                    this.DiscontinuedDateField = value;
                    this.RaisePropertyChanged("DiscontinuedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool FinishedGoodsFlag {
            get {
                return this.FinishedGoodsFlagField;
            }
            set {
                if ((this.FinishedGoodsFlagField.Equals(value) != true)) {
                    this.FinishedGoodsFlagField = value;
                    this.RaisePropertyChanged("FinishedGoodsFlag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal ListPrice {
            get {
                return this.ListPriceField;
            }
            set {
                if ((this.ListPriceField.Equals(value) != true)) {
                    this.ListPriceField = value;
                    this.RaisePropertyChanged("ListPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool MakeFlag {
            get {
                return this.MakeFlagField;
            }
            set {
                if ((this.MakeFlagField.Equals(value) != true)) {
                    this.MakeFlagField = value;
                    this.RaisePropertyChanged("MakeFlag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ModifiedDate {
            get {
                return this.ModifiedDateField;
            }
            set {
                if ((this.ModifiedDateField.Equals(value) != true)) {
                    this.ModifiedDateField = value;
                    this.RaisePropertyChanged("ModifiedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductLine {
            get {
                return this.ProductLineField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductLineField, value) != true)) {
                    this.ProductLineField = value;
                    this.RaisePropertyChanged("ProductLine");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ProductModelID {
            get {
                return this.ProductModelIDField;
            }
            set {
                if ((this.ProductModelIDField.Equals(value) != true)) {
                    this.ProductModelIDField = value;
                    this.RaisePropertyChanged("ProductModelID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductNumber {
            get {
                return this.ProductNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNumberField, value) != true)) {
                    this.ProductNumberField = value;
                    this.RaisePropertyChanged("ProductNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ProductSubcategoryID {
            get {
                return this.ProductSubcategoryIDField;
            }
            set {
                if ((this.ProductSubcategoryIDField.Equals(value) != true)) {
                    this.ProductSubcategoryIDField = value;
                    this.RaisePropertyChanged("ProductSubcategoryID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short ReorderPoint {
            get {
                return this.ReorderPointField;
            }
            set {
                if ((this.ReorderPointField.Equals(value) != true)) {
                    this.ReorderPointField = value;
                    this.RaisePropertyChanged("ReorderPoint");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short SafetyStockLevel {
            get {
                return this.SafetyStockLevelField;
            }
            set {
                if ((this.SafetyStockLevelField.Equals(value) != true)) {
                    this.SafetyStockLevelField = value;
                    this.RaisePropertyChanged("SafetyStockLevel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> SellEndDate {
            get {
                return this.SellEndDateField;
            }
            set {
                if ((this.SellEndDateField.Equals(value) != true)) {
                    this.SellEndDateField = value;
                    this.RaisePropertyChanged("SellEndDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime SellStartDate {
            get {
                return this.SellStartDateField;
            }
            set {
                if ((this.SellStartDateField.Equals(value) != true)) {
                    this.SellStartDateField = value;
                    this.RaisePropertyChanged("SellStartDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Size {
            get {
                return this.SizeField;
            }
            set {
                if ((object.ReferenceEquals(this.SizeField, value) != true)) {
                    this.SizeField = value;
                    this.RaisePropertyChanged("Size");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SizeUnitMeasureCode {
            get {
                return this.SizeUnitMeasureCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.SizeUnitMeasureCodeField, value) != true)) {
                    this.SizeUnitMeasureCodeField = value;
                    this.RaisePropertyChanged("SizeUnitMeasureCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal StandardCost {
            get {
                return this.StandardCostField;
            }
            set {
                if ((this.StandardCostField.Equals(value) != true)) {
                    this.StandardCostField = value;
                    this.RaisePropertyChanged("StandardCost");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Style {
            get {
                return this.StyleField;
            }
            set {
                if ((object.ReferenceEquals(this.StyleField, value) != true)) {
                    this.StyleField = value;
                    this.RaisePropertyChanged("Style");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Weight {
            get {
                return this.WeightField;
            }
            set {
                if ((this.WeightField.Equals(value) != true)) {
                    this.WeightField = value;
                    this.RaisePropertyChanged("Weight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WeightUnitMeasureCode {
            get {
                return this.WeightUnitMeasureCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.WeightUnitMeasureCodeField, value) != true)) {
                    this.WeightUnitMeasureCodeField = value;
                    this.RaisePropertyChanged("WeightUnitMeasureCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid rowguid {
            get {
                return this.rowguidField;
            }
            set {
                if ((this.rowguidField.Equals(value) != true)) {
                    this.rowguidField = value;
                    this.RaisePropertyChanged("rowguid");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AdventureWorksServiceReference.IProdutos")]
    public interface IProdutos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProdutos/Get", ReplyAction="http://tempuri.org/IProdutos/GetResponse")]
        AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.Product Get(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProdutos/Get", ReplyAction="http://tempuri.org/IProdutos/GetResponse")]
        System.Threading.Tasks.Task<AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.Product> GetAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProdutos/GetByName", ReplyAction="http://tempuri.org/IProdutos/GetByNameResponse")]
        AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.Product[] GetByName(string nome);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProdutos/GetByName", ReplyAction="http://tempuri.org/IProdutos/GetByNameResponse")]
        System.Threading.Tasks.Task<AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.Product[]> GetByNameAsync(string nome);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProdutosChannel : AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.IProdutos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProdutosClient : System.ServiceModel.ClientBase<AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.IProdutos>, AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.IProdutos {
        
        public ProdutosClient() {
        }
        
        public ProdutosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProdutosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProdutosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProdutosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.Product Get(int id) {
            return base.Channel.Get(id);
        }
        
        public System.Threading.Tasks.Task<AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.Product> GetAsync(int id) {
            return base.Channel.GetAsync(id);
        }
        
        public AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.Product[] GetByName(string nome) {
            return base.Channel.GetByName(nome);
        }
        
        public System.Threading.Tasks.Task<AdventureWorks.WcfService.Testes.AdventureWorksServiceReference.Product[]> GetByNameAsync(string nome) {
            return base.Channel.GetByNameAsync(nome);
        }
    }
}
