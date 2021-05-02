using System.Net.Http;

using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Device.Location;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace RoutingBikes
{
    public class Views
    {
        public Views() { }

        public List<Station> getStations()
        {
            HttpClient client = new HttpClient();
            List<Station> stations = new List<Station>();

            HttpResponseMessage response = client.GetAsync("http://localhost:10003/ProxyCacheJC/WebProxyRest/getStation").Result;

            if (response.IsSuccessStatusCode)
            {
                DebugTextWriter debug = new DebugTextWriter();
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(dataObjects);
                debug.Write("----------------------------\n");
                debug.Write(jObject + "\n");
                debug.Write(jObject["getStationsResult"]);
                debug.Write("\n----------------------------\n");

                stations = JsonConvert.DeserializeObject<List<Station>>(jObject["getStationsResult"].ToString());
            }
            else
            {
                DebugTextWriter debug = new DebugTextWriter();
                debug.Write("----------------------------\n");
                debug.Write("requete mauvaise");
                debug.Write("----------------------------\n");
            }
            return stations;
        }

        public String PathBetweenPoints(GeoCoordinate pos1, GeoCoordinate pos2, string mode)
        {
            HttpClient client = new HttpClient();
            List<Station> stations = new List<Station>();
            DebugTextWriter test = new DebugTextWriter();
            test.Write("https://api.openrouteservice.org/v2/directions/"+mode+"?api_key=5b3ce3597851110001cf6248691a8db2077e474e92e56f19cbcd3f32&start=" + getPosFormatted(pos1) + "&end=" + getPosFormatted(pos2));
            HttpResponseMessage response = client.GetAsync("https://api.openrouteservice.org/v2/directions/"+mode+"?api_key=5b3ce3597851110001cf6248691a8db2077e474e92e56f19cbcd3f32&start=" + getPosFormatted(pos1) + "&end=" + getPosFormatted(pos2)).Result;
            string responseData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject(responseData);
            return responseData;
        }

        private string getPosFormatted(GeoCoordinate pos)
        {
            return pos.Longitude.ToString() + "," + pos.Latitude.ToString();
        }

        public Station getStations(string stationNumber, string contractName)
        {
            HttpClient client = new HttpClient();
            Station stationTmp = new Station();

            HttpResponseMessage response = client.GetAsync("https://api.jcdecaux.com/vls/v3/stations/" + stationNumber + "?contract=" + contractName + "&apiKey=a6bee3bdc9887565d08983011fe7d4ed0a181ede").Result;

            var dataObjects = response.Content.ReadAsStringAsync().Result;
            Station station = JsonConvert.DeserializeObject<Station>(dataObjects);
            return station;
        }

        public Station findClosestStation(GeoCoordinate point, List<Station> stations)
        {
            var dic = new Dictionary<Station, double>();

            foreach (var station in stations)
            {
                GeoCoordinate ptmp = new GeoCoordinate(station.position.latitude, station.position.longitude);
                dic.Add(station, point.GetDistanceTo(ptmp));
            }
            DebugTextWriter debug = new DebugTextWriter();

            foreach (KeyValuePair<Station, double> item in dic.OrderBy(key => key.Value))
            {
                Station s = getStations(item.Key.number, item.Key.contractName);
                if (s.totalStands.availabilities.bikes > 0)
                {
                    debug.Write("\nLa station la plus proche avec des bikes : "+s.address+"\n");
                    return s;
                }
            }
            return stations[0];
        }
    }
}
