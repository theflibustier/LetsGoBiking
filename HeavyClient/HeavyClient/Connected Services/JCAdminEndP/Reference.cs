﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JCAdminEndP
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/RoutingBikes")]
    public partial class CompositeType : object
    {
        
        private string stationNameField;
        
        private string valueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string stationName
        {
            get
            {
                return this.stationNameField;
            }
            set
            {
                this.stationNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JCAdminEndP.IRoutingBikesSoap")]
    public interface IRoutingBikesSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoutingBikesSoap/getStatsByStation", ReplyAction="http://tempuri.org/IRoutingBikesSoap/getStatsByStationResponse")]
        System.Threading.Tasks.Task<JCAdminEndP.CompositeType> getStatsByStationAsync(string stationName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoutingBikesSoap/getMostUsedStation", ReplyAction="http://tempuri.org/IRoutingBikesSoap/getMostUsedStationResponse")]
        System.Threading.Tasks.Task<JCAdminEndP.CompositeType> getMostUsedStationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoutingBikesSoap/getLastUsedStation", ReplyAction="http://tempuri.org/IRoutingBikesSoap/getLastUsedStationResponse")]
        System.Threading.Tasks.Task<JCAdminEndP.CompositeType> getLastUsedStationAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface IRoutingBikesSoapChannel : JCAdminEndP.IRoutingBikesSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class RoutingBikesSoapClient : System.ServiceModel.ClientBase<JCAdminEndP.IRoutingBikesSoap>, JCAdminEndP.IRoutingBikesSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public RoutingBikesSoapClient() : 
                base(RoutingBikesSoapClient.GetDefaultBinding(), RoutingBikesSoapClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IRoutingBikesSoap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RoutingBikesSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(RoutingBikesSoapClient.GetBindingForEndpoint(endpointConfiguration), RoutingBikesSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RoutingBikesSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(RoutingBikesSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RoutingBikesSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(RoutingBikesSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RoutingBikesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<JCAdminEndP.CompositeType> getStatsByStationAsync(string stationName)
        {
            return base.Channel.getStatsByStationAsync(stationName);
        }
        
        public System.Threading.Tasks.Task<JCAdminEndP.CompositeType> getMostUsedStationAsync()
        {
            return base.Channel.getMostUsedStationAsync();
        }
        
        public System.Threading.Tasks.Task<JCAdminEndP.CompositeType> getLastUsedStationAsync()
        {
            return base.Channel.getLastUsedStationAsync();
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IRoutingBikesSoap))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IRoutingBikesSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:10002/RoutingBikes/RoutingBikesSoap");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return RoutingBikesSoapClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IRoutingBikesSoap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return RoutingBikesSoapClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IRoutingBikesSoap);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IRoutingBikesSoap,
        }
    }
}
