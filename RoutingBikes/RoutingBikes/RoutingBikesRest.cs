using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Text;
using Aspose.Cells;

namespace RoutingBikes
{
    // Add this class somewhere in your project...
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

    // Then attach it to the Log property of your DataContext...
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "IRoutingBikes" à la fois dans le code et le fichier de configuration.
    public class RoutingBikesRest : IRoutingBikesRest
    {
        private Views views;
        private Workbook wb;
        private Worksheet sheet;

        public RoutingBikesRest()
        {
            views = new Views();
            wb = new Workbook(@"Excel.xlsx");
            sheet = wb.Worksheets[0];
        }
        public string[] closest(string a1, string a2)
        {
            System.ServiceModel.Web.WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            System.ServiceModel.Web.WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            System.ServiceModel.Web.WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
            DebugTextWriter d = new DebugTextWriter();
            d.Write("-----------------Passe---------------------\n");
            GeoCoordinate posFrom = parseAddr(a1);
            GeoCoordinate posTo = parseAddr(a2);
            List<Station> stations = views.getStations();
            Station stationFrom = views.findClosestStation(posFrom, stations);
            Station stationTo = views.findClosestStation(posTo, stations);
            wrInFile(stationFrom.name);
            wrInFile(stationTo.name);
            return new string[]{
                views.PathBetweenPoints(posFrom, new GeoCoordinate(stationFrom.position.latitude, stationFrom.position.longitude), "foot-walking"),
                views.PathBetweenPoints(new GeoCoordinate(stationFrom.position.latitude, stationFrom.position.longitude), new GeoCoordinate(stationTo.position.latitude, stationTo.position.longitude), "cycling-regular"),
                views.PathBetweenPoints(new GeoCoordinate(stationTo.position.latitude, stationTo.position.longitude), posTo, "foot-walking")
            };
        }

        public void wrInFile(string station)
        {
            //recherche si la clé (nom station) existe pas déjà
            FindOptions opts = new FindOptions();
            opts.LookInType = LookInType.Values;
            opts.LookAtType = LookAtType.EntireContent;

            Cell cell = sheet.Cells.Find(station, null, opts);
            // Si oui: alors il la recupère puis il incrémente son nb d'utilisation
            if(cell != null)
            {
                Cell cellVal = sheet.Cells[cell.Row, 1];
                cellVal.PutValue(int.Parse(cellVal.StringValue) + 1);
                Cell c3 = sheet.Cells[cell.Row, 2];
                c3.PutValue(DateTime.Now.Date.ToString());
            }
            // Si pas trouvé et pas de données dans lexcel: alors il la créer avec son nom de station et 0
            else if(sheet.Cells.MaxDataRow == -1)
            {
                Cell c1 = sheet.Cells[0, 0];
                c1.PutValue(station);
                Cell c2 = sheet.Cells[0, 1];
                c2.PutValue(1);
                Cell c3 = sheet.Cells[0, 2];
                c3.PutValue(DateTime.Now.Date.ToString());
            }
            // Si pas trouvé et que déjà des données dans lexcel: alors il la créer avec son nom de station et 0
            else
            {
                int lastRowIndex = sheet.Cells.MaxDataRow;
                Cell c1 = sheet.Cells[lastRowIndex+1, 0];
                c1.PutValue(station);
                Cell c2 = sheet.Cells[lastRowIndex + 1, 1];
                c2.PutValue(1);
                Cell c3 = sheet.Cells[lastRowIndex + 1, 2];
                c3.PutValue(DateTime.Now.Date.ToString());
            }
            // Save the Excel file as .xlsx.
            wb.Save(@"Excel.xlsx", SaveFormat.Xlsx);
        }

        private GeoCoordinate parseAddr(string addr)
        {
            string[] res = addr.Split('_');
            return new GeoCoordinate(Double.Parse(res[0]), Double.Parse(res[1]));
        }
    }
}
