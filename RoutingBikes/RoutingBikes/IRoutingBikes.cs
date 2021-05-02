using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RoutingBikes
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IRoutingBikesRest
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "closest?A1={a1}&A2={a2}", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string[] closest(string a1, string a2);
    }

    [ServiceContract]
    public interface IRoutingBikesSoap
    {
        [OperationContract]
        CompositeType getStatsByStation(string stationName);
        [OperationContract]
        CompositeType getMostUsedStation();
        [OperationContract]
        CompositeType getLastUsedStation();
    }

    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    // Vous pouvez ajouter des fichiers XSD au projet. Une fois le projet généré, vous pouvez utiliser directement les types de données qui y sont définis, avec l'espace de noms "RoutingBikes.ContractType".
    [DataContract]
    public class CompositeType
    {
        public string _stationName;
        public string _value;
        public CompositeType(string name, string value)
        {
            _stationName = name;
            _value = value;
        }

        [DataMember]
        public string value
        {
            get { return _value; }
            set { _value = value; }
        }

        [DataMember]
        public string stationName
        {
            get { return _stationName; }
            set { _stationName = value; }
        }
    }
}
