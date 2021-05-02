using System;
using System.Net.Http;
using System.Text;

namespace ProxyCacheJC
{
    class DebugTextWriter : System.IO.TextWriter
    {
        public override void Write(char[] buffer, int index, int count)
        {
            System.Diagnostics.Debug.Write(new String(buffer, index, count));
        }

        public override void Write(string value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.Default; }
        }
    }
    public class Views
    {

        public Views() { }

        public string getStations()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync("https://api.jcdecaux.com/vls/v3/stations" + "?apiKey=a6bee3bdc9887565d08983011fe7d4ed0a181ede").Result;

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                DebugTextWriter debug = new DebugTextWriter();
                debug.Write("------------------------\n");
                debug.Write(dataObjects);
                debug.Write("\n------------------------\n");
                return dataObjects;
            }
            else
            {

                return "Error";
            }
        }

        public string getInfos(string stationNumber, string contractName)
        {
            HttpClient client = new HttpClient();
            Station stationTmp = new Station();

            HttpResponseMessage response = client.GetAsync("https://api.jcdecaux.com/vls/v3/stations/" + stationNumber + "?contract=" + contractName + "&apiKey=a6bee3bdc9887565d08983011fe7d4ed0a181ede").Result;

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                return dataObjects;
            }
            return "AUCUN";
        }
    }
}
