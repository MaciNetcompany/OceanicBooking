
using DatabaseComponent.Entitities;
using ExportingComponent.Interfaces;
using ExportingComponent.NewFolder;

namespace ExportingComponent.Services
{
    public class CSVExporter : ICSVExporter
    {
        private readonly string _csvColumns="RouteID,Date,SourcePoint,DestinationPoint,Weight,Width,Height,Length,Price,Category";
        public string SaveToCSV(IEnumerable<FlyRoute> routes)
        {
            string csv = "";
            //using (var stream = File.Open("file.csv", FileMode.CreateNew))
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                        writer.Write(_csvColumns);
                        writer.Write(writer.NewLine);
                        foreach (FlyRoute flyRoute in routes)
                        {
                            writer.Write(flyRoute.ToCSVRow());
                            writer.Write(writer.NewLine);
                        }
                        writer.Flush();
                        stream.Seek(0, SeekOrigin.Begin);
                    var reader = new StreamReader(stream);
                    csv = reader.ReadToEnd();
                    reader.Close();
                }
            }


            return csv;

        }

        public string SaveToCSV(IEnumerable<BookingsJPA> bookings, IEnumerable<CitiesJPA> cities, IEnumerable<FlightsJPA> flights)
        {
            var routes = new List<FlyRoute>();
            foreach (BookingsJPA bookingsJpa in bookings)
            {
                var route = new FlyRoute();
                route.PopulateFromBookingDB(bookingsJpa);
                route.PopulateFromCitiesDB(cities);
                route.PopulateFromFlightsDB(flights);
                routes.Add(route);
            }
            return SaveToCSV(routes);
        }

    }
}