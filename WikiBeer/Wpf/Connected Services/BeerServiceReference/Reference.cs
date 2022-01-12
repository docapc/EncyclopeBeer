﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeerServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BeerDto", Namespace="http://schemas.datacontract.org/2004/07/Ipme.WikiBeer.Dtos")]
    public partial class BeerDto : object
    {
        
        private float DegreeField;
        
        private float IbuField;
        
        private System.Guid IdField;
        
        private BeerServiceReference.IngredientDto[] IngredientsField;
        
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Degree
        {
            get
            {
                return this.DegreeField;
            }
            set
            {
                this.DegreeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Ibu
        {
            get
            {
                return this.IbuField;
            }
            set
            {
                this.IbuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BeerServiceReference.IngredientDto[] Ingredients
        {
            get
            {
                return this.IngredientsField;
            }
            set
            {
                this.IngredientsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="IngredientDto", Namespace="http://schemas.datacontract.org/2004/07/Ipme.WikiBeer.Dtos.Ingredients")]
    public partial class IngredientDto : object
    {
        
        private string DescriptionField;
        
        private System.Guid IdField;
        
        private string NameField;
        
        private string TypeOfIngredientField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TypeOfIngredient
        {
            get
            {
                return this.TypeOfIngredientField;
            }
            set
            {
                this.TypeOfIngredientField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BeerServiceReference.IBeerService")]
    public interface IBeerService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBeerService/GetBeers", ReplyAction="http://tempuri.org/IBeerService/GetBeersResponse")]
        BeerServiceReference.BeerDto[] GetBeers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBeerService/GetBeers", ReplyAction="http://tempuri.org/IBeerService/GetBeersResponse")]
        System.Threading.Tasks.Task<BeerServiceReference.BeerDto[]> GetBeersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IBeerServiceChannel : BeerServiceReference.IBeerService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class BeerServiceClient : System.ServiceModel.ClientBase<BeerServiceReference.IBeerService>, BeerServiceReference.IBeerService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public BeerServiceClient() : 
                base(BeerServiceClient.GetDefaultBinding(), BeerServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IBeerService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BeerServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(BeerServiceClient.GetBindingForEndpoint(endpointConfiguration), BeerServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BeerServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(BeerServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BeerServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(BeerServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BeerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public BeerServiceReference.BeerDto[] GetBeers()
        {
            return base.Channel.GetBeers();
        }
        
        public System.Threading.Tasks.Task<BeerServiceReference.BeerDto[]> GetBeersAsync()
        {
            return base.Channel.GetBeersAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IBeerService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IBeerService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:60260/BeerService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return BeerServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IBeerService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return BeerServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IBeerService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IBeerService,
        }
    }
}
