using System.Globalization;
using CsvHelper;
using ExportingComponent.Interfaces;
using ExportingComponent.NewFolder;

namespace ExportingComponent.Services
{
    public class CSVExporter : ICSVExporter
    {
        public bool SaveToCSV(IEnumerable<FlyRoute> routes)
        {
            using (var stream = File.Open("filePersons.csv", FileMode.CreateNew))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {

                foreach (FlyRoute flyRoute in routes)
                {
                    csv.WriteRecord(flyRoute);
                    writer.Write("\r\n");
                }
            }

            return true;

        }

    }
}