namespace ProxyCacheJC
{
    public class WebProxyRest : IWebProxyRest
    {
        public string getStations()
        {
            return new Views().getStations();
        }
    }
}