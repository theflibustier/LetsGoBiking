using Aspose.Cells;
using System;

namespace RoutingBikes
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "IRoutingBikes" à la fois dans le code et le fichier de configuration.
    public class RoutingBikesSoap : IRoutingBikesSoap
    {
        private Workbook wb;
        private Worksheet sheet;

        public RoutingBikesSoap()
        {
            wb = new Workbook(@"Excel.xlsx");
            sheet = wb.Worksheets[0];
        }
        public CompositeType getMostUsedStation()
        {
            int index = 0;
            int maxVal = 0;
            for (int i = 0; i < sheet.Cells.GetLastDataRow(1); i++)
            {
                if (maxVal < int.Parse(sheet.Cells.GetRow(i).GetCellOrNull(1).StringValue))
                {
                    index = i;
                }
            }
            string station = sheet.Cells.GetRow(index).GetCellOrNull(0).StringValue;
            string val = sheet.Cells.GetRow(index).GetCellOrNull(1).StringValue;
            return new CompositeType(station, parseStat(val));
        }


        private string parseStat(string value)
        {
            int sum = getTotalOfUsagesAllStations();
            double res = (int.Parse(value) * 1.0 / sum) * 100;
            return String.Format("{0:0.00}", res);
        }

        private int getTotalOfUsagesAllStations()
        {
            int sum = 0;
            for (int i = 0; i <= sheet.Cells.GetLastDataRow(1); i++)
            {
                sum +=int.Parse(sheet.Cells.GetRow(i).GetCellOrNull(1).StringValue);
            }
            return sum;
        }

        public CompositeType getStatsByStation(string stationName)
        {
            FindOptions opts = new FindOptions();
            opts.LookInType = LookInType.Values;
            opts.LookAtType = LookAtType.EntireContent;

            Cell cell = sheet.Cells.Find(stationName, null, opts);

            return new CompositeType(cell.StringValue, parseStat(sheet.Cells[cell.Row, 1].StringValue));
        }

        public CompositeType getLastUsedStation()
        {
            string station = sheet.Cells.GetRow(0).GetCellOrNull(0).StringValue;
            string val = sheet.Cells.GetRow(0).GetCellOrNull(1).StringValue;
            DateTime upper = DateTime.Parse(sheet.Cells.GetRow(0).GetCellOrNull(2).StringValue);
            for (int i = 0; i < sheet.Cells.GetLastDataRow(1); i++)
            {
                if(DateTime.Parse(sheet.Cells.GetRow(i).GetCellOrNull(2).StringValue).CompareTo(upper) >= 0)
                {
                    station = sheet.Cells.GetRow(i).GetCellOrNull(0).StringValue;
                    val = sheet.Cells.GetRow(i).GetCellOrNull(1).StringValue;
                }
            }
            return new CompositeType(station, parseStat(val));
        }
    }
}
