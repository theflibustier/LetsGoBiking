using System.ServiceModel;
using System.ServiceModel.Web;

namespace ProxyCacheJC
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IWebProxyRest
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getStation", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string getStations();
    }
}
